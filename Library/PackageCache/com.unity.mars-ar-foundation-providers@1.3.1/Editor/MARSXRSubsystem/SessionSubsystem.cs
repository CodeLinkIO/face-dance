#if ARSUBSYSTEMS_2_1_OR_NEWER
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace Unity.MARS.XRSubsystem
{
    /// <summary>
    /// Session subsystem implementation for MARS XR Subsystems.
    /// </summary>
    public sealed class SessionSubsystem : XRSessionSubsystem
    {

#if ARSUBSYSTEMS_3_OR_NEWER
#if !UNITY_2020_2_OR_NEWER
        protected override Provider CreateProvider() => new MARSXRProvider();
#endif
#else
        protected override IProvider CreateProvider() => new MARSXRProvider();
#endif

#if ARSUBSYSTEMS_3_OR_NEWER
        class MARSXRProvider : Provider
#else
        class MARSXRProvider : IProvider
#endif
        {
            public override TrackingState trackingState => TrackingState.Tracking;

            public override Promise<SessionAvailability> GetAvailabilityAsync() =>
                Promise<SessionAvailability>.CreateResolvedPromise(SessionAvailability.Installed | SessionAvailability.Supported);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
            XRSessionSubsystemDescriptor.RegisterDescriptor(new XRSessionSubsystemDescriptor.Cinfo
            {
                id = "MARS-Session",
#if UNITY_2020_2_OR_NEWER
                providerType = typeof(SessionSubsystem.MARSXRProvider),
                subsystemTypeOverride = typeof(SessionSubsystem),
#else
                subsystemImplementationType = typeof(SessionSubsystem),
#endif
                supportsInstall = false,
                supportsMatchFrameRate = false,
            });
        }
    }
}
#endif
