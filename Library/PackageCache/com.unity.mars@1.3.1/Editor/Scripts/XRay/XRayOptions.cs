using Unity.MARS;
using Unity.MARS.Settings;
using Unity.XRTools.Utils;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation.Rendering
{
    /// <summary>
    /// Options for x-ray rendering
    /// </summary>
    [ScriptableSettingsPath(MARSCore.UserSettingsFolder)]
    [MovedFrom("Unity.MARS")]
    public class XRayOptions : EditorScriptableSettings<XRayOptions>
    {
        [SerializeField]
        [Tooltip("Flip the Depth direction that the X-Ray clips the model in URP.")]
        bool m_FlipXRayDirection;

        /// <summary>
        /// Flip the depth direction for X-Ray clipping in render pipes that require it (universal).
        /// </summary>
        public bool FlipXRayDirection
        {
            get { return m_FlipXRayDirection; }
            set
            {
                m_FlipXRayDirection = value;
                XRayModule.SetXRayDirectionKeyword();
            }
        }
    }
}
