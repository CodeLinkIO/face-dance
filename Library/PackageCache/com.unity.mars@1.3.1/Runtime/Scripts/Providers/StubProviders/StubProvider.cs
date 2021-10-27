using Unity.MARS.MARSUtils;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Providers
{
    abstract class StubProvider : MonoBehaviour, IFunctionalityProvider
    {
        public bool SuppressWarnings { get; set; }

        public virtual void LoadProvider()
        {
            if (SuppressWarnings)
                return;

#if UNITY_EDITOR
            // Suppress warnings in one-shot simulation
            var temporalSim = EditorOnlyDelegates.IsSimulatingTemporal != null && EditorOnlyDelegates.IsSimulatingTemporal();
            if (!temporalSim && !Application.isPlaying)
                return;
#endif

            foreach (var providerInterface in GetType().GetInterfaces())
            {
                if (providerInterface == typeof(IFunctionalityProvider))
                    continue;

                if (!typeof(IFunctionalityProvider).IsAssignableFrom(providerInterface))
                    continue;

                Debug.LogWarning($"Using stub provider for {providerInterface} - no other providers found");
            }
        }

        public abstract void ConnectSubscriber(object obj);

        public virtual void UnloadProvider() { }
    }
}
