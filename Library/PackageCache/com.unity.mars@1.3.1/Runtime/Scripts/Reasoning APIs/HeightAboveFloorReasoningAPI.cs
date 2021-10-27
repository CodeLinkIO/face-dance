using System.Collections.Generic;
using UnityEngine;
using Unity.MARS.Query;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Reasoning
{
    /// <summary>
    /// Calculates the height of all planes that are not floors above the nearest floor
    /// </summary>
    [CreateAssetMenu(menuName = "MARS/Height Above Floor Reasoning API")]
    [MovedFrom("Unity.MARS.Data")]
    public class HeightAboveFloorReasoningAPI : ScriptableObject, IReasoningAPI, IProvidesTraits<float>,
        IRequiresTraits<bool>, IRequiresTraits<Pose>
    {
        static readonly TraitDefinition[] k_ProvidedTraits = { TraitDefinitions.HeightAboveFloor };
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Floor, TraitDefinitions.Pose, TraitDefinitions.Plane };

        [SerializeField]
        [Tooltip("Sets the number of seconds to wait between processing scene data")]
        float m_ProcessSceneInterval = 2f;

        Dictionary<int,Pose> m_FloorDataIds = new Dictionary<int, Pose>();

        /// <inheritdoc />
        public float processSceneInterval => m_ProcessSceneInterval;

        /// <inheritdoc />
        public TraitDefinition[] GetProvidedTraits() { return k_ProvidedTraits; }

        /// <inheritdoc />
        public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

        /// <inheritdoc />
        public void Setup()
        {
        }

        /// <inheritdoc />
        public void TearDown()
        {
        }

        bool TryGetPoseForDataId(int dataId, out Pose pose)
        {
            return IRequiresTraitsMethods<Pose>.TryGetTraitValue(dataId, TraitNames.Pose, out pose);
        }

        bool TryFindClosestFloorInfo(Vector3 testLocation, out int floorId, out Pose floorPose)
        {
            floorId = (int)ReservedDataIDs.Invalid;
            float bestScore = 0.0f;
            floorPose = Pose.identity;
            if (m_FloorDataIds.Count < 1) return false;
            foreach (var kv in m_FloorDataIds)
            {
                var score = (testLocation - kv.Value.position).magnitude;
                if ((floorId == (int)ReservedDataIDs.Invalid) || (score < bestScore))
                {
                    floorId = kv.Key;
                    bestScore = score;
                    floorPose = kv.Value;
                }
            }
            return (floorId != (int)ReservedDataIDs.Invalid);
        }

        /// <inheritdoc />
        public void ProcessScene()
        {
            m_FloorDataIds.Clear();
            IRequiresTraitsMethods<bool>.ForEachContextIdWithTrait(TraitNames.Floor, dataId =>
            {
                if (TryGetPoseForDataId(dataId, out Pose pose))
                {
                    m_FloorDataIds.Add(dataId, pose);
                }
            });

            IRequiresTraitsMethods<bool>.ForEachContextIdWithTrait(TraitNames.Plane, planeDataId =>
            {
                bool shouldRemove = true;
                if (!m_FloorDataIds.ContainsKey(planeDataId))
                {
                    if (TryGetPoseForDataId(planeDataId, out var planePose))
                    {
                        if (TryFindClosestFloorInfo(planePose.position, out var floorId, out var floorPose))
                        {
                            shouldRemove = false;
                            var offset = planePose.position.y - floorPose.position.y;
                            this.AddOrUpdateTrait(planeDataId, TraitNames.HeightAboveFloor, offset);
                        }
                    }
                }
                if (shouldRemove)
                {
                    this.RemoveTrait(planeDataId, TraitNames.HeightAboveFloor);
                }
            });
        }

        /// <inheritdoc />
        public void UpdateData() {}
    }
}
