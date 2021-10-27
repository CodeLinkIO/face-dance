using System;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a Cloud Data Storage Provider
    /// This functionality provider is responsible for providing a storage in the cloud for
    /// </summary>
    [MovedFrom("Unity.MARS")]
    [Obsolete(IUsesCloudDataStorageMethods.ObsoleteMessage)]
    public interface IProvidesCloudDataStorage : IFunctionalityProvider
    {
        /// <summary>
        /// Get the current state of the connection to the cloud storage
        /// </summary>
        /// <returns>True if the Cloud Storage is connected to this client, false otherwise.</returns>
        [Obsolete(IUsesCloudDataStorageMethods.ObsoleteMessage)]
        bool IsConnected();

        /// <summary>
        /// Set the current authentication token
        /// </summary>
        /// <param name="key">String that uniquely identifies this instance of the type. </param>
        [Obsolete(IUsesCloudDataStorageMethods.ObsoleteMessage)]
        void SetAPIKey(string key);

        /// <summary>
        /// Get the current authentication token
        /// </summary>
        /// <returns>String that uniquely identifies this instance of the type. </returns>
        [Obsolete(IUsesCloudDataStorageMethods.ObsoleteMessage)]
        string GetAPIKey();

        /// <summary>
        /// Set the current project identifier
        /// </summary>
        /// <param name="id"> String that uniquely identifies this instance of the type. </param>
        [Obsolete(IUsesCloudDataStorageMethods.ObsoleteMessage)]
        void SetProjectIdentifier(string id);

        /// <summary>
        /// Set the current project identifier
        /// </summary>
        /// <returns>String that uniquely identifies this instance of the type. </returns>
        [Obsolete(IUsesCloudDataStorageMethods.ObsoleteMessage)]
        string GetProjectIdentifier();

        /// <summary>
        /// Save to the cloud asynchronously the data of an object of a certain type with a specified key
        /// </summary>
        /// <param name="key"> string that uniquely identifies this instance of the type. </param>
        /// <param name="serializedObject"> string serialization of the object being saved. </param>
        /// <param name="callback"> a callback when the asynchronous call is done to show whether it was successful,
        /// with the response code and string. </param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        [Obsolete(IUsesCloudDataStorageMethods.ObsoleteMessage)]
        void CloudSaveAsync(string key, string serializedObject, Action<bool, long, string> callback = null, ProgressCallback progress = null);

        /// <summary>
        /// Save to the cloud asynchronously data in a byte array with a specified key
        /// </summary>
        /// <param name="key"> string that uniquely identifies this instance of the type. </param>
        /// <param name="bytesObject">Bytes array of the object being saved</param>
        /// <param name="callback"> a callback when the asynchronous call is done to show whether it was successful,
        /// with the response code and string. </param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        [Obsolete(IUsesCloudDataStorageMethods.ObsoleteMessage)]
        void CloudSaveAsync(string key, byte[] bytesObject, Action<bool, long, string> callback = null, ProgressCallback progress = null);

        /// <summary>
        /// Load from the cloud asynchronously the data of an object of a certain type which was saved with a known key
        /// </summary>
        /// <param name="key"> string that uniquely identifies this instance of the type. </param>
        /// <param name="callback">a callback which returns whether the operation was successful, as well as the
        /// response code and serialized string of the object if it was. </param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        [Obsolete(IUsesCloudDataStorageMethods.ObsoleteMessage)]
        void CloudLoadAsync(string key, Action<bool, long, string> callback, ProgressCallback progress = null);

        /// <summary>
        /// Load from the cloud asynchronously the byte array which was saved with a known key
        /// </summary>
        /// <param name="key"> string that uniquely identifies this instance of the type. </param>
        /// <param name="callback">a callback which returns whether the operation was successful, as well as the
        /// response code and byte array if it was. If the operation failed, the byte array will contain the error string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        [Obsolete(IUsesCloudDataStorageMethods.ObsoleteMessage)]
        void CloudLoadAsync(string key, Action<bool, long, byte[]> callback, ProgressCallback progress = null);

        /// <summary>
        /// Load a texture asynchronously from cloud storage
        /// </summary>
        /// <param name="key">String that uniquely identifies this instance of the type. </param>
        /// <param name="callback">A callback which returns whether the operation was successful, as well as the
        /// response payload if it was. If the operation failed, the byte array will contain the error string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        [Obsolete(IUsesCloudDataStorageMethods.ObsoleteMessage)]
        void CloudLoadTextureAsync(string key, LoadTextureCallback callback, ProgressCallback progress = null);

        /// <summary>
        /// Load a texture asynchronously from local storage
        /// </summary>
        /// <param name="path">Path to the texture. </param>
        /// <param name="callback">A callback which returns whether the operation was successful, as well as the
        /// response payload if it was. If the operation failed, the byte array will contain the error string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        [Obsolete(IUsesCloudDataStorageMethods.ObsoleteMessage)]
        void LoadLocalTextureAsync(string path, LoadTextureCallback callback, ProgressCallback progress = null);
    }
}
