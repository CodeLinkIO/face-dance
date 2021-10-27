using System.Collections.Generic;
using System.Linq;
using Unity.MARS.Actions;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using Unity.MARS.Query;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// Creates MARS proxies with conditions based on trait data. Proxies can be created immediately with defaults
    /// or opens a window for choosing the conditions and name of the created object.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class CreateProxyFromData : CreateFromDataBase
    {
        Proxy m_DataSourceObject;
        List<PotentialCondition> m_PotentialConditions = new List<PotentialCondition>();

        GameObject m_PlacedChildContent;

        GameObject m_BackupObject;
        TraitDataSnapshot m_DataSnapshot = new TraitDataSnapshot();

        internal List<PotentialCondition> PotentialConditions => m_PotentialConditions;

        /// <summary>
        /// The result game object that has been created
        /// </summary>
        public GameObject CreatedGameObject => m_CreatedObject;

        /// <summary>
        /// Whether this create data is editing an existing proxy.
        /// If true, the proxy will be restored to its prior state when the create is cancelled rather than being destroyed.
        /// </summary>
        public bool EditMode { get; private set; }

        internal GameObject CreateImmediately(Proxy dataSourceObject)
        {
            m_DataSourceObject = dataSourceObject;
            CreateProxy();
            CollectPotentialConditions();
            return m_CreatedObject;
        }

        internal void EditCreatedProxy()
        {
            if (m_CreatedObject == null)
                return;

            EditMode = true;
            Replicate = false;
            m_BackupObject = UnityObject.Instantiate(m_CreatedObject);
            m_BackupObject.name = m_CreatedObject.name + "(BACKUP)";
            m_BackupObject.hideFlags = HideFlags.HideInHierarchy;
        }

        internal void SetProxyName(string newName)
        {
            if (m_CreatedObject != null)
                m_CreatedObject.name = newName;
        }

        /// <summary>
        /// Creates a new proxy with the provided content object as the child and a target proxy gameObject.
        /// The trait data of the target proxy's current match will be used to create the conditions on the new proxy
        /// </summary>
        /// <param name="droppedObject">The content that will be attached to the new proxy.</param>
        /// <param name="target">The target gameobject that has a matched proxy component.</param>
        public void OnObjectDropped(GameObject droppedObject, GameObject target)
        {
            m_PlacedChildContent = droppedObject;
            CreateImmediately(target.GetComponent<Proxy>());
        }

        internal override void CancelCreate()
        {
            if (EditMode)
            {
                if (m_CreatedObject == null) // Possible if child was already destroyed by closing the create window
                {
                    UnityObjectUtils.Destroy(m_BackupObject);
                }
                else
                {
                    m_BackupObject.transform.parent = m_CreatedObject.transform.parent;
                    m_BackupObject.transform.SetSiblingIndex(m_CreatedObject.transform.GetSiblingIndex());
                    m_BackupObject.name = m_BackupObject.name.Remove(m_BackupObject.name.LastIndexOf("(BACKUP)"));
                    foreach (var potentialCondition in m_PotentialConditions)
                        potentialCondition.gameObjectOwner = m_BackupObject;

                    UnityObjectUtils.Destroy(m_CreatedObject);
                    m_CreatedObject = m_BackupObject;
                    m_CreatedObject.hideFlags &= ~HideFlags.HideInHierarchy;
                }
            }
            else
            {
                if (m_PlacedChildContent != null)
                    UnityObjectUtils.Destroy(m_PlacedChildContent);

                base.CancelCreate();
            }
        }

        internal void ConfirmCreate()
        {
            if (m_BackupObject != null)
                UnityObject.DestroyImmediate(m_BackupObject);
        }

        internal string GenerateProxyName()
        {
            var traitNames = m_PotentialConditions
                .Where(condition => condition.use && condition.componentType == typeof(SemanticTagCondition))
                .Select(potentialTagCondition => ((PotentialTagCondition) potentialTagCondition).tagName)
                .ToList();

            if (traitNames.Count == 0)
                return "Generated Proxy";

            traitNames[0] = traitNames[0].FirstToUpper();

            return string.Join(", ", traitNames);
        }

        void CollectPotentialConditions()
        {
            m_PotentialConditions.Clear();
            if (m_DataSourceObject == null || m_DataSourceObject.currentData == null)
                return;

            m_DataSnapshot.TakeSnapshot(m_DataSourceObject.currentData);
            m_DataSnapshot.GetPotentialConditions(m_PotentialConditions, m_CreatedObject);
            m_DataSnapshot.GetPotentialTags(m_PotentialConditions, m_CreatedObject);

            if (m_PotentialConditions.Count > 0)
            {
                m_PotentialConditions.Sort((a, b) =>
                {
                    var orderCompare = a.order.CompareTo(b.order);
                    if (orderCompare != 0)
                        return orderCompare;

                    return a.componentType.Name.CompareTo(b.componentType.Name);
                });
            }

            SetProxyName(GenerateProxyName());
        }

        void CreateProxy()
        {
            if (m_DataSourceObject == null)
                return;

            m_CreatedObject = new GameObject("Proxy", typeof(Proxy), typeof(SetPoseAction), typeof(ShowChildrenOnTrackingAction));
            m_CreatedObject.transform.rotation = m_DataSourceObject.transform.rotation;
            m_CreatedObject.transform.SetParent(ObjectParent, false);

            if (Replicate)
                SetupReplicator();

            var proxy = m_CreatedObject.GetComponent<Proxy>();
            proxy.exclusivity = Exclusivity.ReadOnly; // Make it read-only so it will match when simulation restarts

            if (m_PlacedChildContent == null)
                return;

            var relativePos = m_PlacedChildContent.transform.position - m_PlacedChildContent.transform.parent.position;
            m_PlacedChildContent.transform.SetParent(m_CreatedObject.transform);
            m_PlacedChildContent.transform.position = m_CreatedObject.transform.position + relativePos;
            m_PlacedChildContent = null;
        }
    }
}
