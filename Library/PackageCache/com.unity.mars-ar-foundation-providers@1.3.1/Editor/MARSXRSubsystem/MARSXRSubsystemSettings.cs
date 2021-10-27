#if XRMANAGEMENT_3_2_OR_NEWER
using UnityEngine;
using System;
using UnityEngine.XR.Management;

namespace Unity.MARS.XRSubsystem
{
    /// <summary>
    /// MARS XR Subsystems settings.
    /// </summary>
    [XRConfigurationData("MARS Simulation", MARSXRSubsystemLoader.SettingsKey)]
    [Serializable]
    public class MARSXRSubsystemSettings : ScriptableObject
    {
    }
}
#endif
