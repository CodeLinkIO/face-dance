using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to a remote data connection.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesRemoteDataConnection : IFunctionalitySubscriber<IProvidesRemoteDataConnection>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesRemoteDataConnectionMethods
    {
        /// <summary>
        /// Get the current state of the remote data connection
        /// </summary>
        /// <returns>True if connected to a remote, false if not</returns>
        public static bool IsConnected(this IUsesRemoteDataConnection obj)
        {
            return obj.provider.IsConnected();
        }

        /// <summary>
        /// Connect the module to an editor remote
        /// </summary>
        public static void ConnectRemote(this IUsesRemoteDataConnection obj)
        {
            obj.provider.ConnectRemote();
        }

        /// <summary>
        /// Disconnect from the editor remote
        /// </summary>
        public static void DisconnectRemote(this IUsesRemoteDataConnection obj)
        {
            obj.provider.DisconnectRemote();
        }

        /// <summary>
        /// Update the connection to the editor remote
        /// </summary>
        public static void UpdateRemote(this IUsesRemoteDataConnection obj)
        {
            obj.provider.UpdateRemote();
        }
    }
}
