using System;
using System.Collections.Generic;
using Unity.MARS.Attributes;
using Unity.MARS.Query;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils.GUI;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// Class that automatically inserts and updates data in MARS' reality database
    /// Intrinsically linked to the Real World Object it is parented to
    /// </summary>
    [HelpURL(DocumentationConstants.SynthesizedObjectDocs)]
    [ExcludeInMARSEditor]
    [MovedFrom("Unity.MARS.Data")]
    public class SynthesizedObject : MonoBehaviour, IMatchAcquireHandler, IMatchUpdateHandler, IMatchLossHandler,
        IUsesMARSData<SynthesizedObject>, IUsesFunctionalityInjection
    {
        const int k_Unset = (int) ReservedDataIDs.Unset;

        static readonly List<SynthesizedTrackable> k_TrackableBuffer = new List<SynthesizedTrackable>(4);
        static readonly List<SynthesizedTrait> k_TraitBuffer = new List<SynthesizedTrait>(4);

        readonly List<SynthesizedTrackable> m_Data = new List<SynthesizedTrackable>();
        readonly List<SynthesizedTrait> m_Traits = new List<SynthesizedTrait>();
        Proxy m_ParentClient;

        [SerializeField]
        [EnumDisplay(ReservedDataIDs.Unset, ReservedDataIDs.ImmediateEnvironment, ReservedDataIDs.LocalUser)]
        int m_OverrideDataID = k_Unset;

        int m_DataID = k_Unset;

        bool m_FullUpdateRequested;

        IProvidesFunctionalityInjection IFunctionalitySubscriber<IProvidesFunctionalityInjection>.provider { get; set; }

        bool HasValidDataId => m_DataID != k_Unset;

        void OnEnable()
        {
            MarsTime.MarsUpdate += OnMarsUpdate;

            // Get all the traits and data to associate with this object
            CollectValidDataTraits(k_TrackableBuffer, m_Data);
            CollectValidDataTraits(k_TraitBuffer, m_Traits);

            this.EnsureFunctionalityInjected();
            foreach (var trait in m_Traits)
            {
                this.InjectFunctionalitySingle(trait);
                trait.HasFunctionalityInjected = true;
            }

            foreach (var trackable in m_Data)
            {
                this.InjectFunctionalitySingle(trackable);
            }

            // If an acquire call is not going to make us active, call the insert method right away
            if (transform.parent != null)
                m_ParentClient = transform.parent.GetComponentInParent<Proxy>();

            if (m_ParentClient == null || m_ParentClient.queryState == QueryState.Tracking)
            {
                InitializeData();
            }

            // Otherwise we wait
        }

        void OnMarsUpdate()
        {
            if (!HasValidDataId)
            {
                m_FullUpdateRequested = false;
                return;
            }

            if (m_FullUpdateRequested)
            {
                UpdateAllData();
                m_FullUpdateRequested = false;
                transform.hasChanged = false;
            }
            else if (transform.hasChanged)
            {
                // All trackable data has poses attached, so we update those with transforms
                foreach (var currentData in m_Data)
                {
                    currentData.UpdateSynthData();
                }

                // Traits conditionally change
                foreach (var currentTrait in m_Traits)
                {
                    if (currentTrait.UpdateWithTransform)
                        currentTrait.UpdateTrait(m_DataID);
                }

                transform.hasChanged = false;
            }
        }

        void OnDisable()
        {
            MarsTime.MarsUpdate -= OnMarsUpdate;
            RemoveAllData();
        }

        void CollectValidDataTraits<T>(List<T> source, List<T> destination)
            where T : MonoBehaviour, ISynthesizedData
        {
            source.Clear();
            GetComponents(source);

            destination.Clear();
            foreach (var dataTrait in source)
            {
                if(dataTrait.HasValidValue)
                    destination.Add(dataTrait);
            }
            source.Clear();
        }

        static bool TryAdd<T>(T datum, List<T> data)
            where T : MonoBehaviour, ISynthesizedData
        {
            if (!datum.HasValidValue || data.Contains(datum))
                return false;

            data.Add(datum);
            return true;
        }

        static bool TryRemove<T>(T datum, List<T> data)
            where T : MonoBehaviour, ISynthesizedData
        {
            return datum.HasValidValue && data.Remove(datum);
        }

        internal bool TryAddTrait(SynthesizedTrait trait)
        {
            if (!TryAdd(trait, m_Traits))
                return false;

            if (!trait.HasFunctionalityInjected)
                this.InjectFunctionalitySingle(trait);

            if (HasValidDataId)
                trait.AddTrait(m_DataID);

            return true;

        }

        internal bool TryRemoveTrait(SynthesizedTrait trait)
        {
            if (!TryRemove(trait, m_Traits))
                return false;

            if (HasValidDataId)
                trait.RemoveTrait(m_DataID);

            return true;
        }

        internal bool TryAddTrackable(SynthesizedTrackable trackable)
        {
            if (!TryAdd(trackable, m_Data))
                return false;

            if (HasValidDataId)
                trackable.AddSynthData(m_DataID);

            return true;
        }

        internal bool TryRemoveTrackable(SynthesizedTrackable trackable)
        {
            if (!TryRemove(trackable, m_Data))
                return false;

            if (HasValidDataId)
                trackable.RemoveSynthData(m_DataID);

            return true;
        }

        /// <inheritdoc />
        public void OnMatchAcquire(QueryResult queryResult)
        {
            if (isActiveAndEnabled)
                InitializeData();
        }

        /// <inheritdoc />
        public void OnMatchLoss(QueryResult queryResult)
        {
            if (isActiveAndEnabled)
                RemoveAllData();
        }

        /// <inheritdoc />
        public void OnMatchUpdate(QueryResult queryResult)
        {
            if (isActiveAndEnabled)
            {
                UpdateAllData();
                transform.hasChanged = false;
            }
        }

        /// <summary>
        /// Called if the database that the synthesized object feeds into shuts down.
        /// In that case, we just reset our data ID so we don't try to interact with the database anymore.
        /// </summary>
        public void OnDataBaseLost()
        {
            m_DataID = k_Unset;
        }

        void InitializeData()
        {
            if (HasValidDataId)
                return;

            m_DataID = m_OverrideDataID == k_Unset ? this.AddData(this) : m_OverrideDataID;

            foreach (var currentData in m_Data)
            {
                currentData.AddSynthData(m_DataID);
            }

            foreach (var currentTrait in m_Traits)
            {
                currentTrait.AddTrait(m_DataID);
            }
        }

        void UpdateAllData()
        {
            foreach (var currentData in m_Data)
            {
                currentData.UpdateSynthData();
            }

            foreach (var currentTrait in m_Traits)
            {
                currentTrait.UpdateTrait(m_DataID);
            }
        }

        void RemoveAllData()
        {
            if (!HasValidDataId)
            {
                return;
            }

            foreach (var currentTrait in m_Traits)
            {
                currentTrait.RemoveTrait(m_DataID);
            }

            foreach (var currentData in m_Data)
            {
                currentData.RemoveSynthData(m_DataID);
            }

            this.RemoveData(m_DataID);
            m_DataID = k_Unset;
        }

        /// <summary>
        /// Flags the SynthesizedObject to do a full update on the next frame.
        /// Useful for traits that are normally static upon creation,
        /// but can be changed dynamically by user scripts.
        /// </summary>
        public void SyncModifications() => m_FullUpdateRequested = true;
    }
}
