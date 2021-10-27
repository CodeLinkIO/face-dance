using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Unity.MARS.Companion.Core;
using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace Unity.MARS.Companion.CloudStorage
{
    [ScriptableSettingsPath(MARSCore.UserSettingsFolder)]
    class GenesisCloudStorageModule : ScriptableSettings<GenesisCloudStorageModule>,
        IModuleBehaviorCallbacks, IProvidesCloudStorage, IUsesIssueHandling
    {
        internal const int MaxKeyLengthBytes = 1024;

        const string k_GenesisEndpoint = "https://api.unity.com/v1/mars_companion";
        const string k_CacheControlHeaderOptions = "public, no-cache, no-store, max-age=0";
        const string k_InvalidKeyRegex = @"[\[\]\#\?\*\n\r]";
        const string k_InvalidKeySubstringRegex = @"[_\[\]\#\?\*\n\r]";
        const int k_GenesisRequestTimeout = 30;
        const int k_RequestHandshakeTimeout = 5;

        static readonly Uri k_GetObjectsUri = new Uri(k_GenesisEndpoint + "/get_objects");
        static readonly byte[] k_RequestCanceledMessage = Encoding.UTF8.GetBytes("Request was canceled");

#pragma warning disable 649, 414
        [SerializeField]
        bool m_OfflineMode;

        [SerializeField]
        float m_TestingDelay;
#pragma warning restore 649, 414

        string m_ProjectIdentifier;

        readonly Dictionary<RequestHandle, IRequest> m_GenesisRequests = new Dictionary<RequestHandle, IRequest>();
        readonly Dictionary<RequestHandle, IRequest> m_Requests = new Dictionary<RequestHandle, IRequest>();

        internal IMarsIdentity IdentityProvider { get; set; }
        internal Dictionary<RequestHandle, IRequest> GenesisRequests => m_GenesisRequests;
        internal Dictionary<RequestHandle, IRequest> Requests => m_Requests;

        IProvidesIssueHandling IFunctionalitySubscriber<IProvidesIssueHandling>.provider { get; set; }

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly Dictionary<RequestHandle, IRequest> k_RequestsCopy = new Dictionary<RequestHandle, IRequest>();

        static class HttpContentTypes
        {
            public const string ApplicationOctetStream = "application/octet-stream";
            public const string ApplicationJson = "application/json";
        }

        enum ContentTypes
        {
            ByteArray,
            String,
            Texture
        }

        internal interface IRequest
        {
            UnityWebRequest UnityWebRequest { get; }
            ProgressCallback Progress { get; }
            float StartTime { get; }
            void OnComplete();
            void Cancel();
        }

        class BytesRequest : IRequest
        {
            public UnityWebRequest UnityWebRequest { get; }
            public ProgressCallback Progress { get; }
            public float StartTime { get; }

            readonly Action<bool, long, byte[]> m_Callback;

            public BytesRequest(UnityWebRequest request, Action<bool, long, byte[]> callback, ProgressCallback progress = null)
            {
                UnityWebRequest = request;
                m_Callback = callback;
                Progress = progress;
                StartTime = Time.realtimeSinceStartup;
            }

            public void OnComplete()
            {
                if (m_Callback == null)
                    return;

                var responseCode = UnityWebRequest.responseCode;
                var downloadHandler = UnityWebRequest.downloadHandler;

#if UNITY_2020_1_OR_NEWER
                var isError = UnityWebRequest.result == UnityWebRequest.Result.ConnectionError;
#else
                var isError = UnityWebRequest.isNetworkError;
#endif

                if (isError)
                    m_Callback(false, responseCode, Encoding.UTF8.GetBytes(UnityWebRequest.error));
                else
                    m_Callback(responseCode == 200, responseCode, downloadHandler?.data);
            }

            public void Cancel()
            {
                m_Callback?.Invoke(false, 0, k_RequestCanceledMessage);
                UnityWebRequest.Abort();
                UnityWebRequest.downloadHandler?.Dispose();
                UnityWebRequest.uploadHandler?.Dispose();
                UnityWebRequest.Dispose();
            }

            public override string ToString()
            {
                return $"BytesRequest - {StartTime} - {UnityWebRequest.url}";
            }
        }

        class TextureRequest : IRequest
        {
            public UnityWebRequest UnityWebRequest { get; }
            public ProgressCallback Progress { get; }
            public float StartTime { get; }

            readonly LoadTextureCallback m_Callback;

            public TextureRequest(UnityWebRequest request, LoadTextureCallback callback, ProgressCallback progress)
            {
                UnityWebRequest = request;
                m_Callback = callback;
                Progress = progress;
                StartTime = Time.realtimeSinceStartup;
            }

            public void OnComplete()
            {
                if (m_Callback == null)
                    return;

#if UNITY_2020_1_OR_NEWER
                var isError = UnityWebRequest.result == UnityWebRequest.Result.ConnectionError;
#else
                var isError = UnityWebRequest.isNetworkError;
#endif

                var responseCode = UnityWebRequest.responseCode;
                var success = !isError && responseCode == 200;
                if (!success)
                {
                    m_Callback(false, responseCode, null, Encoding.UTF8.GetBytes(UnityWebRequest.error));
                }
                else
                {
                    if (!(UnityWebRequest.downloadHandler is DownloadHandlerTexture downloadHandler))
                    {
                        Debug.LogError("Tried to process Texture download without texture download handler");
                        return;
                    }

                    m_Callback(responseCode == 200, responseCode, downloadHandler.texture, downloadHandler.data);
                }
            }

            public void Cancel()
            {
                m_Callback?.Invoke(false, 0, null, k_RequestCanceledMessage);
                UnityWebRequest.Abort();
                UnityWebRequest.downloadHandler?.Dispose();
                UnityWebRequest.uploadHandler?.Dispose();
                UnityWebRequest.Dispose();
            }

            public override string ToString()
            {
                return $"TextureRequest - {StartTime} - {UnityWebRequest.url}";
            }
        }

        // ReSharper disable InconsistentNaming
        [Serializable]
        class GenesisSecuredObject
        {
            public string object_rename;
            public string url;

            public GenesisSecuredObject(string objectRename, string url)
            {
                this.url = url;
                object_rename = objectRename;
            }
        }

        [Serializable]
        class GenesisSecuredURLObjectListing
        {
            public List<GenesisSecuredObject> objects;

            public GenesisSecuredURLObjectListing(List<GenesisSecuredObject> objects) { this.objects = objects; }
        }
        // ReSharper restore InconsistentNaming

        /// <summary>
        /// Set the current project identifier
        /// </summary>
        public void SetProjectIdentifier(string id) { m_ProjectIdentifier = id; }

        /// <summary>
        /// Get the current project identifier
        /// </summary>
        public string GetProjectIdentifier() { return m_ProjectIdentifier; }

        /// <summary>
        /// Save to the cloud asynchronously the data of an object of a certain type with a specified key
        /// </summary>
        /// <param name="key"> string that uniquely identifies this instance of the type. </param>
        /// <param name="serializedObject"> string serialization of the object being saved. </param>
        /// <param name="callback"> a callback when the asynchronous call is done to show whether it was successful,
        /// with the response code and string. </param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        /// <returns>A handle to this request which can be used to cancel it</returns>
        public RequestHandle CloudSaveAsync(string key, string serializedObject, Action<bool, long, string> callback = null,
            ProgressCallback progress = null, int timeout = CloudStorageDefaults.DefaultTimeout)
        {
            return CloudSaveAsyncBytes(key, Encoding.UTF8.GetBytes(serializedObject), timeout, callback, progress,
                ContentTypes.String);
        }

        /// <summary>
        /// Save to the cloud asynchronously data in a byte array with a specified key
        /// </summary>
        /// <param name="key"> string that uniquely identifies this instance of the type. </param>
        /// <param name="bytes">Bytes array of the object being saved</param>
        /// <param name="callback"> a callback when the asynchronous call is done to show whether it was successful,
        /// with the response code and string. </param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        /// <returns>A handle to this request which can be used to cancel it</returns>
        public RequestHandle CloudSaveAsync(string key, byte[] bytes, Action<bool, long, string> callback = null,
            ProgressCallback progress = null, int timeout = CloudStorageDefaults.DefaultTimeout)
        {
            return CloudSaveAsyncBytes(key, bytes, timeout, callback, progress);
        }

        RequestHandle CloudSaveAsyncBytes(string key, byte[] bytes, int timeout, Action<bool, long, string> callback,
            ProgressCallback progress, ContentTypes contentType = ContentTypes.ByteArray)
        {
            if (!IsValidKey(key))
            {
                Debug.LogWarning($"Invalid cloud storage key: {key}");
                return default;
            }

            if (m_OfflineMode)
            {
                callback?.Invoke(false, 0, null);
                return default;
            }

            var httpMethod = UnityWebRequest.kHttpVerbPUT;
            if (bytes == null || bytes.Length == 0)
            {
                httpMethod = UnityWebRequest.kHttpVerbDELETE;
            }

            var requestToGenesis = GenesisRequestBuilder(key, httpMethod);
            if (requestToGenesis == null)
            {
                callback?.Invoke(false, 0, null);
                return default;
            }

            var requestHandle = RequestHandle.Create($"{key} - {httpMethod}");
            SendGenesisWebRequest(requestHandle, requestToGenesis, (genesisSuccess, genesisResponseCode, genesisBytes) =>
            {
                string responseFromGenesis = null;
                if (genesisBytes != null)
                {
                    responseFromGenesis = Encoding.UTF8.GetString(genesisBytes);

                    if (!genesisSuccess || responseFromGenesis.ToLower().Contains("error"))
                    {
                        Debug.Log($"Genesis request error: '{responseFromGenesis}'");
                        callback?.Invoke(false, genesisResponseCode, responseFromGenesis);
                        return;
                    }

                    var securedObject = ParseJsonToGenesisSecuredObject(responseFromGenesis);

                    // ReSharper disable once StringLiteralTypo
                    // Check if URL has Google Authentication and key matches
                    genesisSuccess = securedObject.url.Contains("Goog-Algorithm") && securedObject.object_rename == key;

                    var requestToGoogle = ProjectRequestBuilder(httpMethod, contentType, securedObject.url, timeout, bytes);

                    void ConvertResponseToString(bool success, long responseCode, byte[] responseBytes)
                    {
                        var responseFromGoogle = responseBytes == null ? null : Encoding.UTF8.GetString(responseBytes);
                        callback?.Invoke(success, responseCode, responseFromGoogle);
                    }

                    if (genesisSuccess)
                        SendWebRequest(requestHandle, requestToGoogle, ConvertResponseToString, progress);
                }

                if (genesisSuccess)
                    return;

                callback?.Invoke(false, genesisResponseCode, responseFromGenesis);
            });

            return requestHandle;
        }

        static GenesisSecuredObject ParseJsonToGenesisSecuredObject(string responseFromGenesis)
        {
            var jsonString = responseFromGenesis.Replace("\"object\"", "\"object_rename\""); // Replace C# reserved words
            var securedObjectListing = JsonUtility.FromJson<GenesisSecuredURLObjectListing>(jsonString);
            var securedObject = securedObjectListing.objects[0];
            return securedObject;
        }

        UnityWebRequest GenesisRequestBuilder(string key, string httpMethod)
        {
            var projectId = m_ProjectIdentifier;
            if (!ProjectIdentifierIsValid(projectId))
                return null;

            if (IdentityProvider == null)
                return null;

            if (!IdentityProvider.IsValid)
            {
                this.RaiseIssueRequest(CoreIssueCodes.UserNotSignedIn);

                return null;
            }

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                this.RaiseIssueRequest(CoreIssueCodes.NetworkUnreachable);
                return null;
            }

            var request = new UnityWebRequest(k_GetObjectsUri, UnityWebRequest.kHttpVerbPOST);
            request.timeout = k_GenesisRequestTimeout;
            request.SetRequestHeader("Content-Type", HttpContentTypes.ApplicationJson);
            request.SetRequestHeader("Authorization", $"Bearer {IdentityProvider.Token}");
            request.SetRequestHeader("Cache-Control", "no-cache");
            var secureLinkRequestBody = $@"{{""project_id"":""{projectId}"", ""object_list"":[""{key}""], ""http_method"":""{httpMethod}""}}";
            request.downloadHandler = new DownloadHandlerBuffer();
            request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(secureLinkRequestBody));
            return request;
        }

        /// <summary>
        /// Load from the cloud asynchronously the data of an object which was saved with a known key
        /// </summary>
        /// <param name="key"> string that uniquely identifies this instance of the type. </param>
        /// <param name="callback">a callback which returns whether the operation was successful, as well as the
        /// serialized string of the object if it was. </param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        public RequestHandle CloudLoadAsync(string key, Action<bool, long, string> callback, ProgressCallback progress = null,
            int timeout = CloudStorageDefaults.DefaultTimeout)
        {
            void ConvertResponseToString(bool success, long responseCode, byte[] bytes)
            {
                string response = null;
                if (bytes != null)
                    response = Encoding.UTF8.GetString(bytes);

                callback(success, responseCode, response);
            }

            return CloudLoadAsyncBytes(key, ConvertResponseToString, timeout, progress, ContentTypes.String);
        }

        /// <summary>
        /// Load from the cloud asynchronously the byte array which was saved with a known key
        /// </summary>
        /// <param name="key"> string that uniquely identifies this instance of the type. </param>
        /// <param name="callback">a callback which returns whether the operation was successful, as well as the
        /// response code and byte array if it was. If the operation failed, the byte array will contain the error string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        public RequestHandle CloudLoadAsync(string key, Action<bool, long, byte[]> callback, ProgressCallback progress = null,
            int timeout = CloudStorageDefaults.DefaultTimeout)
        {
            return CloudLoadAsyncBytes(key, callback, timeout, progress);
        }

        RequestHandle CloudLoadAsyncBytes(string key, Action<bool, long, byte[]> callback, int timeout,
            ProgressCallback progress, ContentTypes contentType = ContentTypes.ByteArray)
        {
            if (callback == null)
            {
                Debug.LogWarning($"{nameof(CloudLoadAsync)} callback is null");
                return default;
            }

            if (!IsValidKey(key))
            {
                Debug.LogWarning($"Invalid cloud storage key: {key}");
                return default;
            }

            if (m_OfflineMode)
            {
                progress?.Invoke(1, 1);
                callback(false, 0, null);
                return default;
            }

            var requestToGenesis = GenesisRequestBuilder(key, UnityWebRequest.kHttpVerbGET);
            if (requestToGenesis == null)
            {
                progress?.Invoke(1, 1);
                callback(false, 0, null);
                return default;
            }

            var requestHandle = RequestHandle.Create($"{key} - Genesis");
            SendGenesisWebRequest(requestHandle, requestToGenesis, (genesisSuccess, genesisResponseCode, genesisBytes) =>
            {
                if (genesisBytes != null)
                {
                    var responseFromGenesis = Encoding.UTF8.GetString(genesisBytes);

                    if (!genesisSuccess || responseFromGenesis.ToLower().Contains("error"))
                    {
                        Debug.Log($"Genesis request error loading key: {key}\n{responseFromGenesis}");
                        callback(false, genesisResponseCode, null);
                    }
                    else
                    {
                        var securedObject = ParseJsonToGenesisSecuredObject(responseFromGenesis);

                        // ReSharper disable once StringLiteralTypo
                        genesisSuccess = securedObject.url.Contains("Goog-Algorithm") && securedObject.object_rename == key; // URL has Google Authentication and key matches
                        var requestToGoogle = ProjectRequestBuilder(UnityWebRequest.kHttpVerbGET, contentType, securedObject.url, timeout);
                        SendWebRequest(requestHandle, requestToGoogle, callback, progress);
                    }
                }

                if (genesisSuccess)
                    return;

                callback(false, genesisResponseCode, null);
            });

            return requestHandle;
        }

        void SendGenesisWebRequest(RequestHandle handle, UnityWebRequest request, Action<bool, long, byte[]> callback)
        {
            request.SendWebRequest();
            m_GenesisRequests[handle] = new BytesRequest(request, callback);
        }

        void SendWebRequest(RequestHandle handle, UnityWebRequest request, Action<bool, long, byte[]> callback,
            ProgressCallback progress = null)
        {
            request.SendWebRequest();
            m_Requests[handle] = new BytesRequest(request, callback, progress);
        }

        /// <summary>
        /// Load a texture asynchronously from cloud storage
        /// </summary>
        /// <param name="key">String that uniquely identifies this instance of the type. </param>
        /// <param name="callback">A callback which returns whether the operation was successful, as well as the
        /// response payload if it was. If the operation failed, the byte array will contain the error string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        public RequestHandle CloudLoadTextureAsync(string key, LoadTextureCallback callback, ProgressCallback progress = null,
            int timeout = CloudStorageDefaults.DefaultTimeout)
        {
            return CloudLoadAsyncTexture(key, callback, timeout, progress);
        }

        /// <summary>
        /// Load a texture asynchronously from local storage
        /// </summary>
        /// <param name="path">Path to the texture. </param>
        /// <param name="callback">A callback which returns whether the operation was successful, as well as the
        /// response payload if it was. If the operation failed, the byte array will contain the error string</param>
        /// <param name="progress">Called every frame while the request is in progress with two 0-1 values indicating
        /// upload and download progress, respectively</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        public RequestHandle LoadLocalTextureAsync(string path, LoadTextureCallback callback, ProgressCallback progress = null,
            int timeout = CloudStorageDefaults.DefaultTimeout)
        {
            if (callback == null)
            {
                Debug.LogWarning($"{nameof(LoadLocalTextureAsync)} callback is null");
                return default;
            }

            if (m_OfflineMode)
            {
                progress?.Invoke(1, 1);
                callback(false, 0, null, null);
                return default;
            }

            var uri = new Uri(path);
            var request = new UnityWebRequest(uri, UnityWebRequest.kHttpVerbGET);
            request.timeout = timeout;
            var downloadHandler = new DownloadHandlerTexture();
            request.downloadHandler = downloadHandler;

            var requestHandle = RequestHandle.Create($"{path} - Texture");
            SendWebRequest(requestHandle, request, callback, progress);
            return requestHandle;
        }

        /// <summary>
        /// Cancel a request with the given request handle
        /// </summary>
        /// <param name="handle">The handle to the request, which was returned by the method which initiated it</param>
        public void CancelRequest(RequestHandle handle)
        {
            TryCancelRequest(m_GenesisRequests, handle);
            TryCancelRequest(m_Requests, handle);
        }

        static void TryCancelRequest(Dictionary<RequestHandle, IRequest> requests, RequestHandle handle)
        {
            if (!requests.TryGetValue(handle, out var request))
                return;

            // Remove the request before canceling it in case callbacks try to modify or cancel requests
            requests.Remove(handle);
            request.Cancel();
        }

        /// <summary>
        /// Cancel all currently active requests
        /// </summary>
        public void CancelAllRequests()
        {
            CancelAllRequests(m_GenesisRequests);
            CancelAllRequests(m_Requests);
        }

        static void CancelAllRequests(Dictionary<RequestHandle, IRequest> requests)
        {
            k_RequestsCopy.Clear();
            foreach (var kvp in requests)
            {
                k_RequestsCopy[kvp.Key] = kvp.Value;
            }

            // Clear requests before canceling them in case callbacks try to modify or cancel requests
            requests.Clear();
            foreach (var kvp in k_RequestsCopy)
            {
                kvp.Value.Cancel();
            }

            k_RequestsCopy.Clear();
        }

        RequestHandle CloudLoadAsyncTexture(string key, LoadTextureCallback callback, int timeout,  ProgressCallback progress)
        {
            if (callback == null)
            {
                Debug.LogWarning($"{nameof(CloudLoadTextureAsync)} callback is null");
                return default;
            }

            if (m_OfflineMode)
            {
                progress?.Invoke(1, 1);
                callback(false, 0, null, null);
                return default;
            }

            var requestToGenesis = GenesisRequestBuilder(key, UnityWebRequest.kHttpVerbGET);
            if (requestToGenesis == null)
            {
                callback(false, 0, null, null);
                return default;
            }

            var requestHandle = RequestHandle.Create($"{key} - Genesis");
            SendGenesisWebRequest(requestHandle, requestToGenesis, (genesisSuccess, genesisResponseCode, genesisBytes) =>
            {
                if (genesisBytes != null)
                {
                    var responseFromGenesis = Encoding.UTF8.GetString(genesisBytes);

                    if (!genesisSuccess || responseFromGenesis.ToLower().Contains("error"))
                    {
                        Debug.Log($"Genesis request error loading key: {key}\n{responseFromGenesis}");
                        callback(false, genesisResponseCode, null, null);
                    }
                    else
                    {
                        var securedObject = ParseJsonToGenesisSecuredObject(responseFromGenesis);

                        // ReSharper disable once StringLiteralTypo
                        genesisSuccess = securedObject.url.Contains("Goog-Algorithm") && securedObject.object_rename == key; // URL has Google Authentication abd key matches
                        var requestToGoogle = ProjectRequestBuilder(UnityWebRequest.kHttpVerbGET, ContentTypes.Texture,  securedObject.url, timeout);
                        SendWebRequest(requestHandle, requestToGoogle, callback, progress);
                    }
                }

                if (genesisSuccess)
                    return;

                callback(false, genesisResponseCode, null, null);
            });

            return requestHandle;
        }

        void SendWebRequest(RequestHandle handle, UnityWebRequest request, LoadTextureCallback callback, ProgressCallback progress = null)
        {
            request.SendWebRequest();
            m_Requests[handle] = new TextureRequest(request, callback, progress);
        }

        static UnityWebRequest RequestBuilder(string httpMethod, ContentTypes contentType, string url, int timeout, byte[] payload = null)
        {
            var request = new UnityWebRequest(new Uri(url), httpMethod);
            request.timeout = timeout;
            request.SetRequestHeader("Content-Type", HttpContentTypes.ApplicationOctetStream);
            request.SetRequestHeader("Cache-Control", k_CacheControlHeaderOptions);
            if (httpMethod == UnityWebRequest.kHttpVerbGET)
            {
                switch (contentType)
                {
                    case ContentTypes.Texture:
                        request.downloadHandler = new DownloadHandlerTexture();
                        break;
                    default:
                        request.downloadHandler = new DownloadHandlerBuffer();
                        break;
                }
            }

            if (payload != null && payload.Length > 0)
            {
                request.uploadHandler = new UploadHandlerRaw(payload);
            }

            return request;
        }

        UnityWebRequest ProjectRequestBuilder(string httpMethod, ContentTypes contentType, string url, int timeout, byte[] payload = null)
        {
            var projectId = m_ProjectIdentifier;
            if (!ProjectIdentifierIsValid(projectId))
            {
                Debug.Log("Invalid project identifier");
            }

            return RequestBuilder(httpMethod, contentType, url, timeout, payload);
        }

        /// <summary>
        /// Checks if the provided Project Identifier is valid
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns>True if the project identifier is valid, false otherwise.</returns>
        static bool ProjectIdentifierIsValid(string projectID)
        {
            // Basic check, to be made more comprehensive with Genesis
            return projectID != null && projectID.Length > 32;
        }

        void UpdateRequests()
        {
            UpdateRequests(m_Requests);
            UpdateRequests(m_GenesisRequests);
        }

        void UpdateRequests(Dictionary<RequestHandle, IRequest> requests)
        {
            if (requests.Count == 0)
                return;

            k_RequestsCopy.Clear();
            foreach (var kvp in requests)
            {
                k_RequestsCopy[kvp.Key] = kvp.Value;
            }

            var time = Time.realtimeSinceStartup;
            foreach (var kvp in k_RequestsCopy)
            {
                var request = kvp.Value;
                var unityWebRequest = request.UnityWebRequest;
                request.Progress?.Invoke(unityWebRequest.uploadProgress, unityWebRequest.downloadProgress);
                var elapsed = time - request.StartTime;
                if (elapsed < m_TestingDelay)
                    continue;

                if (unityWebRequest.isDone)
                {
                    requests.Remove(kvp.Key);

                    try
                    {
                        request.OnComplete();
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }

                    unityWebRequest.downloadHandler?.Dispose();
                    unityWebRequest.uploadHandler?.Dispose();
                    unityWebRequest.Dispose();
                    continue;
                }

                // If no progress within a given window, all requests should time out
                if (unityWebRequest.uploadedBytes > 0 || unityWebRequest.downloadedBytes > 0)
                    continue;

                if (elapsed > k_RequestHandshakeTimeout)
                {
                    // Remove the request before canceling it in case callbacks try to modify or cancel requests
                    requests.Remove(kvp.Key);
                    request.Cancel();
                }
            }

            k_RequestsCopy.Clear();
        }

        void IModule.LoadModule()
        {
#if UNITY_EDITOR
            EditorApplication.update += UpdateRequests;

            // Play mode should act the same as player builds
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                return;

            CloudProjectSettings.RefreshAccessToken(null);
            IdentityProvider = new OAuthTokenGenesisModule();
            CoroutineUtils.StartCoroutine(IdentityProvider.SignIn(onlyCached: true));
#endif
        }

        void IModule.UnloadModule()
        {

#if UNITY_EDITOR
            // ReSharper disable once DelegateSubtraction
            EditorApplication.update -= UpdateRequests;
#endif
        }

        void IModuleBehaviorCallbacks.OnBehaviorAwake() { }

        void IModuleBehaviorCallbacks.OnBehaviorEnable() { }

        void IModuleBehaviorCallbacks.OnBehaviorStart() { }

        void IModuleBehaviorCallbacks.OnBehaviorUpdate()
        {
#if !UNITY_EDITOR
            UpdateRequests(m_GenesisRequests);
            UpdateRequests(m_Requests);
#endif
        }

        void IModuleBehaviorCallbacks.OnBehaviorDisable() { }

        void IModuleBehaviorCallbacks.OnBehaviorDestroy() { }

        void IFunctionalityProvider.LoadProvider() { }

        void IFunctionalityProvider.ConnectSubscriber(object obj) { this.TryConnectSubscriber<IProvidesCloudStorage>(obj); }

        void IFunctionalityProvider.UnloadProvider() { }

        /// <summary>
        /// Perform a get request to the given uri, adding the given token to the request header
        /// </summary>
        /// <param name="uri">The web address of the object to be gotten</param>
        /// <param name="authToken">The authentication token to be added to the request header</param>
        /// <param name="callback">An action to be called when the request is completed, whose parameters are:
        ///     (bool) success    - Whether or not the request was successful
        ///     (string) response - A string value containing the server's response</param>
        /// <param name="timeout">The timeout duration (in seconds) for this request</param>
        public RequestHandle AuthenticatedGetRequest(string uri, string authToken, Action<bool, string> callback,
            int timeout = CloudStorageDefaults.DefaultTimeout)
        {
            var request = new UnityWebRequest(uri, UnityWebRequest.kHttpVerbGET);
            request.timeout = timeout;
            request.SetRequestHeader("Authorization", $"Bearer {authToken}");
            request.downloadHandler = new DownloadHandlerBuffer();
            var requestHandle = RequestHandle.Create($"{uri} - GET");
            SendWebRequest(requestHandle, request, (success, responseCode, bytes) =>
            {
                if (success)
                {
                    var str = Encoding.UTF8.GetString(bytes);
                    callback(true, str);
                    return;
                }

                callback(false, null);
            });

            return requestHandle;
        }

        internal static bool IsValidKeySubstring(string keySubstring)
        {
            if (Regex.IsMatch(keySubstring, k_InvalidKeySubstringRegex))
                return false;

            try
            {
                XmlConvert.VerifyXmlChars(keySubstring);
            }
            catch
            {
                return false;
            }

            return true;
        }

        static bool IsValidKey(string key)
        {
            if (key == "." || key == "..")
                return false;

            if (Encoding.UTF8.GetByteCount(key) > MaxKeyLengthBytes)
                return false;

            if (Regex.IsMatch(key, k_InvalidKeyRegex))
                return false;

            try
            {
                XmlConvert.VerifyXmlChars(key);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
