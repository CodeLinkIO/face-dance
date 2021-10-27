using System;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Companion.CloudStorage
{
    /// <summary>
    /// Users will have access to key/value cloud storage
    /// </summary>
    public interface IUsesCloudStorage : IFunctionalitySubscriber<IProvidesCloudStorage>
    {
    }

    /// <summary>
    /// Extension methods for cloud data storage users
    /// </summary>
    public static class CloudStorageMethods
    {
        /// <summary>
        /// Set the current project identifier
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="id">The project identifier to set</param>
        public static void SetProjectIdentifier(this IUsesCloudStorage user, string id)
        {
            user.provider.SetProjectIdentifier(id);
        }

        /// <summary>
        /// Get the current project identifier
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <returns>The current project identifier</returns>
        // ReSharper disable once UnusedMember.Global
        public static string GetProjectIdentifier(this IUsesCloudStorage user)
        {
            return user.provider.GetProjectIdentifier();
        }

        /// <summary>
        /// Save to the cloud asynchronously the data of an object with a specified key
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="key">String that uniquely identifies this instance of the type. </param>
        /// <param name="serializedObject">String serialization of the object being saved. </param>
        /// <param name="callback">A callback when the asynchronous call is done to show whether it was successful,
        /// with the response code and string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        /// <returns>A handle to the request which can be used to cancel it</returns>
        public static RequestHandle CloudSaveAsync(this IUsesCloudStorage user, string key, string serializedObject,
            Action<bool, long, string> callback = null, ProgressCallback progress = null,
            int timeout = CloudStorageDefaults.DefaultTimeout)
        {
            return user.provider.CloudSaveAsync(key, serializedObject, callback, progress, timeout);
        }

        /// <summary>
        /// Save to the cloud asynchronously data in a byte array with a specified key
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="key">String that uniquely identifies this instance of the type. </param>
        /// <param name="bytes">Bytes array of the object being saved</param>
        /// <param name="callback">A callback when the asynchronous call is done to show whether it was successful,
        /// with the response code and string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        /// <returns>A handle to the request which can be used to cancel it</returns>
        public static RequestHandle CloudSaveAsync(this IUsesCloudStorage user, string key, byte[] bytes,
            Action<bool, long, string> callback = null, ProgressCallback progress = null,
            int timeout = CloudStorageDefaults.DefaultTimeout)
        {
            return user.provider.CloudSaveAsync(key, bytes, callback, progress, timeout);
        }

        /// <summary>
        /// Load from the cloud asynchronously the data of an object which was saved with a known key
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="key">String that uniquely identifies this instance of the type. </param>
        /// <param name="callback">A callback which returns whether the operation was successful, as well as the
        /// response code and serialized string of the object if it was</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        /// <returns>A handle to the request which can be used to cancel it</returns>
        public static RequestHandle CloudLoadAsync(this IUsesCloudStorage user, string key, Action<bool, long, string> callback,
            ProgressCallback progress = null, int timeout = CloudStorageDefaults.DefaultTimeout)
        {
            return user.provider.CloudLoadAsync(key, callback, progress, timeout);
        }

        /// <summary>
        /// Load from the cloud asynchronously the byte array which was saved with a known key
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="key">String that uniquely identifies this instance of the type</param>
        /// <param name="callback">A callback which returns whether the operation was successful, as well as the
        /// response code and byte array if it was. If the operation failed, the byte array will contain the error string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        /// <returns>A handle to the request which can be used to cancel it</returns>
        public static RequestHandle CloudLoadAsync(this IUsesCloudStorage user, string key, Action<bool, long, byte[]> callback,
            ProgressCallback progress = null, int timeout = CloudStorageDefaults.DefaultTimeout)
        {
            return user.provider.CloudLoadAsync(key, callback, progress, timeout);
        }

        /// <summary>
        /// Load a texture asynchronously from cloud storage
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="key">String that uniquely identifies this instance of the type. </param>
        /// <param name="callback">A callback which returns whether the operation was successful, as well as the
        /// response payload if it was. If the operation failed, the byte array will contain the error string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        /// <returns>A handle to the request which can be used to cancel it</returns>
        public static RequestHandle CloudLoadTextureAsync(this IUsesCloudStorage user, string key, LoadTextureCallback callback,
            ProgressCallback progress = null, int timeout = CloudStorageDefaults.DefaultTimeout)
        {
            return user.provider.CloudLoadTextureAsync(key, callback, progress, timeout);
        }

        /// <summary>
        /// Load a texture asynchronously from local storage
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="path">Path to the texture. </param>
        /// <param name="callback">A callback which returns whether the operation was successful, as well as the
        /// response payload if it was. If the operation failed, the byte array will contain the error string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        /// <returns>A handle to the request which can be used to cancel it</returns>
        public static RequestHandle LoadLocalTextureAsync(this IUsesCloudStorage user, string path, LoadTextureCallback callback,
            ProgressCallback progress = null, int timeout = CloudStorageDefaults.DefaultTimeout)
        {
            return user.provider.LoadLocalTextureAsync(path, callback, progress, timeout);
        }

        /// <summary>
        /// Cancel a request with the given request handle
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="handle">The handle to the request, which was returned by the method which initiated it</param>
        public static void CancelRequest(this IUsesCloudStorage user, RequestHandle handle)
        {
            user.provider.CancelRequest(handle);
        }

        /// <summary>
        /// Cancel all currently active requests
        /// </summary>
        /// <param name="user">The functionality user</param>
        public static void CancelAllRequests(this IUsesCloudStorage user)
        {
            user.provider.CancelAllRequests();
        }
    }
}
