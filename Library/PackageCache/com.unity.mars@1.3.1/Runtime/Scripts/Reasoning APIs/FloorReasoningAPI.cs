using System.Collections.Generic;
using Unity.MARS.MARSUtils;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Reasoning
{
    /// <summary>
    /// Determines which plane should be assigned the "floor" trait
    /// </summary>
    [CreateAssetMenu(menuName = "MARS/Floor ReasoningAPI")]
    [MovedFrom("Unity.MARS.Data")]
    public class FloorReasoningAPI : ScriptableObject, IReasoningAPI, IProvidesTraits<bool>,
        IUsesMARSTrackableData<MRPlane>, IRequiresTraits, IUsesSlowTasks
    {
        static readonly TraitDefinition[] k_ProvidedTraits = { TraitDefinitions.Floor };
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Plane };

        [SerializeField]
        [Tooltip("Sets the number of planes that must be available before any plane can be semantically tagged as a floor")]
        int m_PlanesRequired = 2;

        [SerializeField]
        [Tooltip("Sets the number of seconds to wait, if there aren't yet enough planes available, " +
            "before decrementing the number of planes required")]
        float m_TimeToDecreasePlanesRequired = 6f;

        [SerializeField]
        [Tooltip("If a plane has at least this size, then it will be semantically tagged as a floor regardless of the number of planes available.")]
        Vector2 m_FloorPlaneSize = new Vector2(3f, 3f);

        [SerializeField]
        [Tooltip("Sets the number of seconds to wait between processing scene data")]
        float m_ProcessSceneInterval = 1f;

        [SerializeField]
        [Tooltip("Sets the speed at which process scene will run after we find a floor")]
        float m_SlowProcessSceneInterval = 2;

        float m_ActiveProcessSceneInterval;

        int m_CurrentFloorID;
        bool m_AnyFloorFound;
        int m_CurrentPlanesRequired;

        List<KeyValuePair<int, MRPlane>> m_SortedPlanes;

        IProvidesSlowTasks IFunctionalitySubscriber<IProvidesSlowTasks>.provider { get; set; }

        /// <inheritdoc />
        public float processSceneInterval { get { return m_ActiveProcessSceneInterval; } }

        /// <inheritdoc />
        public TraitDefinition[] GetProvidedTraits() { return k_ProvidedTraits; }

        /// <inheritdoc />
        public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

        /// <inheritdoc />
        public void Setup()
        {
            m_ActiveProcessSceneInterval = m_ProcessSceneInterval;
            m_CurrentFloorID = -1;
            m_CurrentPlanesRequired = m_PlanesRequired;
            m_SortedPlanes = this.RegisterProcessingJob(ProcessingJobType.ElevationSorting);
            this.AddMarsTimeSlowTask(DecreasePlanesRequired, m_TimeToDecreasePlanesRequired);
        }

        /// <inheritdoc />
        public void TearDown()
        {
            this.UnregisterProcessingJob(ProcessingJobType.ElevationSorting);
            this.RemoveMarsTimeSlowTask(DecreasePlanesRequired);
        }

        void DecreasePlanesRequired()
        {
            // To make sure we provide more reliable data, we require a certain number of planes to be present before
            // tagging any of them as the floor. We relax this requirement at regular intervals to ensure that
            // a floor is found eventually (assuming there are any planes present at all).
            m_CurrentPlanesRequired--;
            if (m_CurrentPlanesRequired == 1)
                this.RemoveMarsTimeSlowTask(DecreasePlanesRequired);
        }

        /// <inheritdoc />
        public void ProcessScene()
        {
            var planesCount = m_SortedPlanes.Count;
            // if we've already tagged a floor, and the lowest plane is still that plane, we should be good, but -
            // this early out won't work in cases where a smaller plane below the floor exists, like walking downstairs.
            if (planesCount > 0 && m_CurrentFloorID == m_SortedPlanes[0].Key)
                return;

            if (planesCount == 0 && m_CurrentFloorID < 0)
                return;

            var foundLargePlane = false;
            int floorPlaneID = -1;
            for (var i = 0; i < planesCount; i++)
            {
                var planeData = m_SortedPlanes[i];
                var plane = planeData.Value;
                if (plane.alignment != MarsPlaneAlignment.HorizontalUp)
                    continue;

                var extents = plane.extents;
                if (extents.x >= m_FloorPlaneSize.x && extents.y >= m_FloorPlaneSize.y ||
                    extents.x >= m_FloorPlaneSize.y && extents.y >= m_FloorPlaneSize.x)
                {
                    foundLargePlane = true;
                    floorPlaneID = planeData.Key;
                    if (!m_AnyFloorFound)
                    {
                        m_AnyFloorFound = true;
                        m_ActiveProcessSceneInterval = m_SlowProcessSceneInterval;
                    }

                    break;
                }
            }

            if (!foundLargePlane && planesCount >= m_CurrentPlanesRequired)
                floorPlaneID = m_SortedPlanes[0].Key;

            if (m_CurrentFloorID != floorPlaneID)
            {
                this.RemoveTrait(m_CurrentFloorID, TraitNames.Floor);
                m_CurrentFloorID = floorPlaneID;
                if (m_CurrentFloorID >= 0)
                    this.AddOrUpdateTrait(m_CurrentFloorID, TraitNames.Floor, true);
            }
        }

        /// <inheritdoc />
        public void UpdateData() {}
    }
}
