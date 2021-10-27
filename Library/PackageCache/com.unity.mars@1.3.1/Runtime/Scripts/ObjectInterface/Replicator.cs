using System;
using System.Collections.Generic;
using Unity.MARS.Attributes;
using Unity.MARS.MARSUtils;
using Unity.MARS.Query;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// MARS Entity for replicating proxies on all available data
    /// Add a proxy as a child object to this behavior's GameObject and it will be replicated for all data that matches
    /// that proxy's conditions, or up to the number specified in the Max Instances property
    /// </summary>
    [HelpURL(DocumentationConstants.ReplicatorsDocs)]
    [MonoBehaviourComponentMenu(typeof(Replicator), "Replicator")]
    public class Replicator : MARSEntity, IUsesFunctionalityInjection
    {
        const string k_TooManyError = "Replicator '{0}' must contain only a single Proxy or Proxy Group as its child!";
        const string k_TooFewError = "Replicator '{0}' does not contain a single Proxy or Proxy Group as its child, and cannot function!";

        const string k_NoReplicatorRecursion = "You cannot replicate a Replicator.";
        const string k_ReplicatorAncestorError = "There is a Replicator ancestor of this Replicator named {0}! " + k_NoReplicatorRecursion;
        const string k_ReplicatorChildError = "There is a Replicator child of this Replicator named {0}! " + k_NoReplicatorRecursion;

        MARSEntity m_SourceReplicateEntity;
        List<MARSEntity> m_ActiveEntities = new List<MARSEntity>();

#pragma warning disable 649
        [SerializeField]
        [Tooltip("Sets the maximum number of GameObjects that can be spawned. A value of 0 indicates no maximum.")]
        int m_MaxInstances;
#pragma warning restore 649

        [SerializeField]
        [Tooltip("When enabled, each instance will be spawned as a child of this transform")]
        bool m_SpawnAsChild = true;

        QueryMatchID m_MasterQuery;
        QueryMatchID m_CurrentQuery;

        readonly List<ISimulatable> m_OriginalSimulatables = new List<ISimulatable>();

        bool m_IsGroupReplicator;
        Transform m_OriginalTransform;
        Action<QueryResult> m_ProxyMatchAction;
        Action<SetQueryResult> m_GroupMatchAction;

        static readonly List<Replicator> k_ReplicatorComponents = new List<Replicator>();

        IProvidesFunctionalityInjection IFunctionalitySubscriber<IProvidesFunctionalityInjection>.provider { get; set; }

        /// <summary>
        /// The total number of instances spawned, included ones seeking a match
        /// </summary>
        public int instanceCount => m_ActiveEntities.Count;

        /// <summary>
        /// The number of spawned instances that are currently matched
        /// </summary>
        public int matchCount {
            get
            {
                int count = 0;
                for (var i = 0; i < m_ActiveEntities.Count; i++)
                {
                    if (IsEntityTracking(m_ActiveEntities[i]))
                        count++;
                }
                return count;
            }
        }

        internal bool HasSourceObject => (m_SourceReplicateEntity != null);

        bool IsEntityTracking(MARSEntity entity)
        {
            if ((!entity) || (!entity.isActiveAndEnabled)) // destroyed or deactivated
                return false;

            if (m_IsGroupReplicator)
                return (((ProxyGroup)entity).queryState == QueryState.Tracking);
            else
                return (((Proxy)entity).queryState == QueryState.Tracking);
        }

        /// <summary>
        /// Sets the maximum number of GameObjects that can be spawned. A value of 0 indicates no maximum
        /// </summary>
        public int MaxInstances { get => m_MaxInstances; set => m_MaxInstances = value; }

        // Local method use only -- created here to reduce garbage collection
        static readonly List<IFunctionalitySubscriber> k_ChildSubscribers = new List<IFunctionalitySubscriber>();
        static readonly List<ISimulatable> k_SpawnedSimulatables = new List<ISimulatable>();

        void OnEnable()
        {
            // Find a compatible template to spawn
            if (!FindInitialSpawn())
            {
                enabled = false;
                return;
            }

            if (m_ActiveEntities.Count > 0)
            {
                // already setup
                CheckForNewSpawnNecessary();
                return;
            }

            m_ProxyMatchAction = ((q) => OnReplicatedMatchAcquired());
            m_GroupMatchAction = ((q) => OnReplicatedMatchAcquired());

            m_SourceReplicateEntity.gameObject.SetActive(false);

            // Get a QueryID to use for all spawns
            m_MasterQuery = QueryMatchID.Generate();
            m_CurrentQuery = m_MasterQuery;

            // Prepare the next entry to spawn
            PrepareNewSpawn();
        }

        internal GameObject CheckReplicatorSetup(ref string errorMessage)
        {
            // See if we have too many children at this level
            if (transform.childCount > 1)
            {
                errorMessage = string.Format(k_TooManyError, name);
                return null;
            }

            // See if we have too few children at this level
            if (transform.childCount < 1)
            {
                errorMessage = string.Format(k_TooFewError, name);
                return null;
            }

            GetComponentsInParent(true, k_ReplicatorComponents);
            if (k_ReplicatorComponents.Count >= 2)
            {
                // use the name of the first one found that's not on this object
                errorMessage = string.Format(k_ReplicatorAncestorError, k_ReplicatorComponents[1].name);
                return null;
            }

            GetComponentsInChildren(true, k_ReplicatorComponents);
            if (k_ReplicatorComponents.Count >= 2)
            {
                errorMessage = string.Format(k_ReplicatorChildError, k_ReplicatorComponents[1].name);
                return null;
            }

            // Try to get a ProxyGroup
            var potentialSet = GetComponentInChildren<ProxyGroup>();
            if (potentialSet != null)
            {
                if (potentialSet.transform.parent == transform)
                    return potentialSet.gameObject;
            }

            var potentialSpawn = GetComponentInChildren<Proxy>();
            if (potentialSpawn != null)
            {
                if (potentialSpawn.transform.parent == transform)
                    return potentialSpawn.gameObject;
            }

            errorMessage = string.Format(k_TooFewError, name);
            return null;
        }

        bool FindInitialSpawn()
        {
            if (m_SourceReplicateEntity != null)
                return true;

            var errorMessage = string.Empty;
            var potentialSpawn = CheckReplicatorSetup(ref errorMessage);
            if (potentialSpawn == null)
            {
                Debug.LogWarning(errorMessage);
                return false;
            }

            if (potentialSpawn.GetComponent<ProxyGroup>() != null)
                m_IsGroupReplicator = true;

            m_SourceReplicateEntity = (m_IsGroupReplicator ? (MARSEntity)potentialSpawn.GetComponent<ProxyGroup>() : potentialSpawn.GetComponent<Proxy>());

            // Setup the initial spawn as the original
            AddSpawnSourceToSimulationManager(m_SourceReplicateEntity.gameObject);

            return true;
        }

        void PrepareNewSpawn()
        {
            if (m_SourceReplicateEntity == null)
                return;

            // If there is still room, duplicate the current entry
            MARSEntity nextEntity;
            if (m_MaxInstances <= 0 || m_ActiveEntities.Count < m_MaxInstances)
            {
                var parent = (m_SpawnAsChild ? transform : transform.parent);
                m_SourceReplicateEntity.gameObject.SetActive(false);
                var nextSpawn = GameObjectUtils.Instantiate(m_SourceReplicateEntity.gameObject, parent);

                m_CurrentQuery = m_CurrentQuery.NextMatch();
                if (m_IsGroupReplicator)
                {
                    var group = nextSpawn.GetComponent<ProxyGroup>();
                    group.AssociatedReplicator = this;
                    group.OverrideGroupQueryID(m_CurrentQuery);
                    nextEntity = group;
                }
                else
                {
                    var proxy = nextSpawn.GetComponent<Proxy>();
                    proxy.AssociatedReplicator = this;
                    proxy.OverrideQueryID(m_CurrentQuery);
                    nextEntity = proxy;
                }
                m_ActiveEntities.Add(nextEntity);
                InjectFunctionalityOnSpawn(nextSpawn);
                AddSpawnToSimulationManager(nextSpawn);
                nextSpawn.transform.parent = parent;
            }
            else
            {
                return;
            }

            nextEntity.gameObject.SetActive(true);
        }

        internal void AddReplicatorCallbacksProxy(Proxy proxy, QueryArgs queryArgs)
        {
            queryArgs.onAcquire += m_ProxyMatchAction;
        }

        internal void AddReplicatorCallbacksGroup(ProxyGroup group, SetQueryArgs queryArgs)
        {
            queryArgs.onAcquire += m_GroupMatchAction;
        }

        void CheckForNewSpawnNecessary()
        {
            if (matchCount == m_ActiveEntities.Count)
            {
                PrepareNewSpawn();
            }
        }

        void OnReplicatedMatchAcquired()
        {
            if (!this || !isActiveAndEnabled)
                return;
            CheckForNewSpawnNecessary();
        }

        void InjectFunctionalityOnSpawn(GameObject target)
        {
            target.GetComponentsInChildren(true, k_ChildSubscribers);
            foreach (var currentSubscriber in k_ChildSubscribers)
            {
                this.InjectFunctionalitySingle(currentSubscriber);
            }
            k_ChildSubscribers.Clear();
        }

        void AddSpawnSourceToSimulationManager(GameObject spawn)
        {
#if UNITY_EDITOR
            m_OriginalSimulatables.Clear();
            m_OriginalTransform = spawn.transform;
            spawn.GetComponentsInChildren(m_OriginalSimulatables);
#endif
        }

        void AddSpawnToSimulationManager(GameObject spawn)
        {
#if UNITY_EDITOR
            if (EditorOnlyDelegates.AddSpawnedTransformToSimulationManager == null
                || EditorOnlyDelegates.AddSpawnedSimulatableToSimulationManager == null )
                return;

            EditorOnlyDelegates.AddSpawnedTransformToSimulationManager(spawn.transform, m_OriginalTransform);

            spawn.GetComponentsInChildren(k_SpawnedSimulatables);
            for (var i = 0; i < m_OriginalSimulatables.Count; i++)
            {
                var originalSimulatable = m_OriginalSimulatables[i];
                var spawnedSimulatable = k_SpawnedSimulatables[i];

                EditorOnlyDelegates.AddSpawnedSimulatableToSimulationManager(spawnedSimulatable, originalSimulatable);
            }
            k_SpawnedSimulatables.Clear();
#endif
        }
    }
}
