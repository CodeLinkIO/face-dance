using Unity.MARS.Settings;
using Unity.XRTools.Utils;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS
{
    [ScriptableSettingsPath(MARSCore.UserSettingsFolder)]
    [MovedFrom("Unity.MARS")]
    internal class MarsWorldScaleSettings : EditorScriptableSettings<MarsWorldScaleSettings>
    {
        [SerializeField]
        bool m_ScaleEntityPositions = true;

#pragma warning disable 649
        [SerializeField]
        bool m_ScaleEntityChildren;

        [SerializeField]
        bool m_ScaleSceneAudio;

        [SerializeField]
        bool m_ScaleSceneLighting;
#pragma warning restore 649

        [SerializeField]
        bool m_ScaleClippingPlanes = true;

        internal bool scaleEntityPositions { get { return m_ScaleEntityPositions; } }
        internal bool scaleEntityChildren { get { return m_ScaleEntityChildren; } }
        internal bool scaleSceneAudio { get { return m_ScaleSceneAudio; } }
        internal bool scaleSceneLighting { get { return m_ScaleSceneLighting; } }
        internal bool scaleClippingPlanes { get { return m_ScaleClippingPlanes; } }
    }
}
