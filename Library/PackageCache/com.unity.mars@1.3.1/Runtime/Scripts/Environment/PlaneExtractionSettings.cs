using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    [MovedFrom("Unity.MARS")]
    [HelpURL(DocumentationConstants.PlaneExtractionSettingsDocs)]
    public class PlaneExtractionSettings : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        PlaneVoxelGenerationParams m_VoxelGenerationParams;

        [SerializeField]
        VoxelPlaneFindingParams m_PlaneFindingParams;
#pragma warning restore 649

        /// <summary>
        /// Settings used by MARS to generate and voxelize a point cloud of the simulated environment,
        /// used when preparing the environment for plane extraction.
        /// </summary>
        public PlaneVoxelGenerationParams VoxelGenerationParams
        {
            get => m_VoxelGenerationParams;
            set => m_VoxelGenerationParams = value;
        }

        /// <summary>
        /// Settings used by MARS to generate environment surface data based on points and
        /// voxels generated using <see cref="VoxelGenerationParams"/>.
        /// </summary>
        public VoxelPlaneFindingParams PlaneFindingParams
        {
            get => m_PlaneFindingParams;
            set => m_PlaneFindingParams = value;
        }
    }
}
