using UnityEngine;

namespace Unity.MARS.XRSubsystem
{
    public interface IMarsXRSubscriber
    {
        void SubscribeToEvents();
        void UnsubscribeFromEvents();
    }
}
