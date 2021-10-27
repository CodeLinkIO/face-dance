using System;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Companion.CloudStorage
{
    /// <summary>
    /// Defines the API for a Cloud Data Storage Provider
    /// This functionality provider is responsible for providing key/value cloud storage
    /// </summary>
    public interface IProvidesCloudStorage : IFunctionalityProvider
    {
        /// <summary>
        /// Set the current project identifier
        /// </summary>
        /// <param name="id">The project identifier to set</param>
        void SetProjectIdentifier(string id);

        /// <summary>
        /// Get the current project identifier
        /// </summary>
        /// <returns>The current project identifier</returns>
        string GetProjectIdentifier();

        /// <summary>
        /// Save to the cloud asynchronously the data of an object of a certain type with a specified key
        /// </summary>
        /// <param name="key">String that uniquely identifies this instance of the type. </param>
        /// <param name="serializedObject">String serialization of the object being saved. </param>
        /// <param name="callback">A callback when the asynchronous call is done to show whether it was successful,
        /// with the response code and string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        /// <returns>A handle to the request which can be used to cancel it</returns>
        RequestHandle CloudSaveAsync(string key, string serializedObject, Action<bool, long, string> callback = null,
            ProgressCallback progress = null, int timeout = CloudStorageDefaults.DefaultTimeout);

        /// <summary>
        /// Save to the cloud asynchronously data in a byte array with a specified key
        /// </summary>
        /// <param name="key">String that uniquely identifies this instance of the type. </param>
        /// <param name="bytes">Bytes array of the object being saved</param>
        /// <param name="callback">A callback when the asynchronous call is done to show whether it was successful,
        /// with the response code and string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        /// <returns>A handle to the request which can be used to cancel it</returns>
        RequestHandle CloudSaveAsync(string key, byte[] bytes, Action<bool, long, string> callback = null,
            ProgressCallback progress = null, int timeout = CloudStorageDefaults.DefaultTimeout);

        /// <summary>
        /// Load from the cloud asynchronously the data of an object which was saved with a known key
        /// </summary>
        /// <param name="key">String that uniquely identifies this instance of the type. </param>
        /// <param name="callback">A callback which returns whether the operation was successful, as well as the
        /// response code and serialized string of the object if it was</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        /// <returns>A handle to the request which can be used to cancel it</returns>
        RequestHandle CloudLoadAsync(string key, Action<bool, long, string> callback, ProgressCallback progress = null,
            int timeout = CloudStorageDefaults.DefaultTimeout);

        /// <summary>
        /// Load from the cloud asynchronously the byte array which was saved with a known key
        /// </summary>
        /// <param name="key">String that uniquely identifies this instance of the type</param>
        /// <param name="callback">A callback which returns whether the operation was successful, as well as the
        /// response code and byte array if it was. If the operation failed, the byte array will contain the error string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        /// <returns>A handle to the request which can be used to cancel it</returns>
        RequestHandle CloudLoadAsync(string key, Action<bool, long, byte[]> callback, ProgressCallback progress = null,
            int timeout = CloudStorageDefaults.DefaultTimeout);

        /// <summary>
        /// Load a texture asynchronously from cloud storage
        /// </summary>
        /// <param name="key">String that uniquely identifies this instance of the type. </param>
        /// <param name="callback">A callback which returns whether the operation was successful, as well as the
        /// response payload if it was. If the operation failed, the byte array will contain the error string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        /// <returns>A handle to the request which can be used to cancel it</returns>
        RequestHandle CloudLoadTextureAsync(string key, LoadTextureCallback callback, ProgressCallback progress = null,
            int timeout = CloudStorageDefaults.DefaultTimeout);

        /// <summary>
        /// Load a texture asynchronously from local storage
        /// </summary>
        /// <param name="path">Path to the texture. </param>
        /// <param name="callback">A callback which returns whether the operation was successful, as well as the
        /// response payload if it was. If the operation failed, the byte array will contain the error string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        /// <returns>A handle to the request which can be used to cancel it</returns>
        RequestHandle LoadLocalTextureAsync(string path, LoadTextureCallback callback, ProgressCallback progress = null,
            // ReSharper disable once UnusedParameter.Global
            int timeout = CloudStorageDefaults.DefaultTimeout);

        /// <summary>
        /// Cancel a request with the given request handle
        /// </summary>
        /// <param name="handle">The handle to the request, which was returned by the method which initiated it</param>
        void CancelRequest(RequestHandle handle);

        /// <summary>
        /// Cancel all currently active requests
        /// </summary>
        void CancelAllRequests();
    }
}
