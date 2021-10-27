using UnityEngine;

namespace Unity.MARS.XRSubsystem
{
    interface IMarsXRSubsystem : ISubsystem
    {
        IMarsXRSubscriber FunctionalitySubscriber { get; }
    }
}
