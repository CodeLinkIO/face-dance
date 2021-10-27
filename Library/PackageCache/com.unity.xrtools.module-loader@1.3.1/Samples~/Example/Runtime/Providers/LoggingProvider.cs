using UnityEngine;

namespace Unity.XRTools.ModuleLoader.Example
{
    // ReSharper disable once UnusedMember.Global
    class LoggingProvider : IProvidesLogging
    {
        void IFunctionalityProvider.LoadProvider() { }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesLogging>(obj);
        }
        void IFunctionalityProvider.UnloadProvider() { }

        void IProvidesLogging.Log(object obj)
        {
            Debug.Log(obj);
        }
    }
}
