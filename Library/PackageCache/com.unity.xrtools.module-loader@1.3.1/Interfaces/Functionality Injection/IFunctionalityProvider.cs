namespace Unity.XRTools.ModuleLoader
{
    /// <summary>
    /// Provides functionality for an IFunctionalitySubscriber
    /// </summary>
    public interface IFunctionalityProvider
    {
        /// <summary>
        /// Called when the provider is loaded into a <c>FunctionalityIsland</c>
        /// </summary>
        void LoadProvider();

        /// <summary>
        /// Called by the <c>FunctionalityIsland</c> containing this provider when injecting functionality on an object
        /// </summary>
        /// <param name="obj">The object onto which functionality is being injected. If this implements a subscriber
        /// interface that subscribes to functionality provided by this object, it will set itself as the provider</param>
        void ConnectSubscriber(object obj);

        /// <summary>
        /// Called when the provider is unloaded by the containing <c>FunctionalityIsland</c>
        /// </summary>
        void UnloadProvider();
    }

    /// <summary>
    /// Extension methods for all Functionality Providers
    /// </summary>
    public static class FunctionalityProviderMethods
    {
        /// <summary>
        /// Use pattern matching cast to try converting a given object to IFunctionalitySubscriber&gt;TProvider&lt;
        /// If the cast succeeds, set the object's provider property to this object
        /// Make sure to use the same generic argument that is used in IFunctionalitySubscriber, not an extension of that type
        /// </summary>
        /// <param name="provider">Provider to try to connect to the subscriber</param>
        /// <param name="obj">An object which should be connected to the provider, if it implements the matching subscriber interface</param>
        /// <typeparam name="TProvider">The provider type we are connecting</typeparam>
        public static void TryConnectSubscriber<TProvider>(this TProvider provider, object obj)
            where TProvider : IFunctionalityProvider
        {
            if (obj is IFunctionalitySubscriber<TProvider> subscriber)
                subscriber.provider = provider;
        }
    }
}
