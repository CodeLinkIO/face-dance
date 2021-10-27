using Unity.MARS.Authoring;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Settings
{
    /// <summary>
    /// Holds global references to major MARS components for script access
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class MARSRuntimePrefabs : ScriptableSettings<MARSRuntimePrefabs>
    {
#pragma warning disable 649
        [SerializeField]
        GameObject m_UserPrefab;

        [SerializeField]
        ColorPreset m_EntityColors;

        [SerializeField]
        GameObject m_PlaneSizeHandle;

        [SerializeField]
        GameObject m_DistanceHandle;

        [SerializeField]
        GameObject m_ElevationHandle;
#pragma warning restore 649

        public GameObject UserPrefab { get { return m_UserPrefab; } }

        public GameObject PlaneSizeHandle { get { return m_PlaneSizeHandle; } }

        public GameObject DistanceHandle { get { return m_DistanceHandle; } }

        public GameObject ElevationHandle { get { return m_ElevationHandle; } }

        public ColorPreset entityColors
        {
            get
            {
                if (m_EntityColors == null)
                {
                    var presets = Resources.FindObjectsOfTypeAll<ColorPreset>();
                    if (presets.Length > 0)
                        m_EntityColors = presets[0];
                    else
                        Debug.LogError("MARSRuntimePrefabs cannot find a ColorPreset asset.");
                }

                return m_EntityColors;
            }
        }
    }
}

