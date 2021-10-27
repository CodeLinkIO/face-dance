namespace Unity.XRTools.ModuleLoader.Example
{
    /// <summary>
    /// Provides access to logging functionality
    /// </summary>
    public interface IUsesLogging : IFunctionalitySubscriber<IProvidesLogging>
    {
    }

    /// <summary>
    /// Extension methods for users of Logging
    /// </summary>
    public static class IUsesLoggingMethods
    {
        /// <summary>
        /// Log a string representation of an object to the console
        /// </summary>
        /// <param name="user">The logging user whose provider will be used</param>
        /// <param name="obj">The object to be converted to a string and logged</param>
        public static void Log(this IUsesLogging user, object obj)
        {
            user.provider.Log(obj);
        }
    }
}
