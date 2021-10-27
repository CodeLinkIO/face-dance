using Unity.MARS.Settings;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Recorded
{
    [ScriptableSettingsPath(MARSCore.UserSettingsFolder)]
    [MovedFrom("Unity.MARS")]
    public class SessionRecordingSettings : ScriptableSettings<SessionRecordingSettings>
    {
        [SerializeField]
        [Tooltip("The interval on which we record the camera pose, in seconds")]
        float m_CameraPoseInterval = 0.1f;

        public float CameraPoseInterval { get { return m_CameraPoseInterval; } }
    }
}
