namespace Unity.XRTools.ModuleLoader
{
    /// <summary>
    /// Provides a non-generic base for IFunctionalitySubscriber for collecting subscribers
    /// </summary>
    public interface IFunctionalitySubscriber
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// Grants implementors the ability to access functionality provided by a TProvider. Methods on the provider object
    /// are exposed via extension method, so that they can be treated like instance methods. For example, a
    /// provider with a method Foo can be called within an implementing class as this.Foo().
    /// Code generation will fill in a `TProvider provider` property which is used within these extension methods to
    /// call the corresponding method on the provider.
    /// </summary>
    /// <typeparam name="TProvider">The type which will provide functionality</typeparam>
    public interface IFunctionalitySubscriber<TProvider> : IFunctionalitySubscriber where TProvider : IFunctionalityProvider
    {
        /// <summary>
        /// The functionality provider
        /// </summary>
        TProvider provider { get; set; }
    }

    /// <summary>
    /// Extension methods for all Functionality Subscribers
    /// </summary>
    public static class FunctionalitySubscriberMethods
    {
        /// <summary>
        /// Check whether this subscriber has a provider of the given type
        /// </summary>
        /// <param name="subscriber">The functionality subscriber on which to check for a provider</param>
        /// <typeparam name="TProvider">The provider type for which to check</typeparam>
        /// <returns>True if the subscriber has a provider of the given type</returns>
        public static bool HasProvider<TProvider>(this IFunctionalitySubscriber<TProvider> subscriber)
            where TProvider : class, IFunctionalityProvider
        {
            return subscriber.provider != null;
        }
    }
}
