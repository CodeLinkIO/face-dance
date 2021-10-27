using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using Unity.MARS.Companion.CloudStorage;
using Unity.MARS.Companion.Core;
using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

#if UNITY_IOS && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace Unity.MARS.Companion
{
    /// <summary>
    /// Handles user sign in and sign out process for obtaining a Genesis access token
    /// </summary>
    class OAuthTokenGenesisModule : OAuthTokenModule
    {
        const string k_GetTokenInfoUrlFormat = "https://api.unity.com/v1/oauth2/tokeninfo?access_token={0}";
        const string k_GetUserDataUrlFormat = "https://api.unity.com/v1/users/{0}";
        const int k_DefaultTimeout = 30;
        static readonly string k_DeepLinkCachePath = Path.Combine(Application.persistentDataPath, "lastSignIn");

        GenesisCredential m_GenesisCredential;
        UserTokenInfo m_UserTokenInfo;
        UserInfo m_UserInfo;

        bool m_IsValid;
        bool m_IsInUserTransition;
        readonly Stack<RequestHandle> m_Requests = new Stack<RequestHandle>();

#if UNITY_EDITOR
        /// <summary>
        /// Path where authentication deep link will be cached
        /// </summary>
        public static string DeepLinkCachePath => k_DeepLinkCachePath;

        /// <summary>
        /// Url used to obtain access token
        /// </summary>
        public
#endif
#if UNITY_IOS && !UNITY_EDITOR
            static string GeneratedLaunchUrl => $"https://api.unity.com/v1/oauth2/authorize?client_id=mars_companion&redirect_uri=mars%3A%2F%2Fon-registration-completed&response_type=token&state={CreateRandomString(16)}&apple_store_app_login=true";

        const string k_LogoutUrl = "https://api.unity.com/v1/oauth2/end-session";
#else
            static string GeneratedLaunchUrl => $"https://api.unity.com/v1/oauth2/authorize?client_id=mars_companion&redirect_uri=mars%3A%2F%2Fon-registration-completed&response_type=token&state={CreateRandomString(16)}";
#endif

#if UNITY_IOS && !UNITY_EDITOR
        [DllImport("__Internal")]
        static extern void LaunchSafariWebViewUrl(string url);
#endif

        public override bool IsValid
        {
            get
            {
#if UNITY_EDITOR
                if (!m_IsValid && !Application.isPlaying)
                    return !string.IsNullOrEmpty(CloudProjectSettings.accessToken);
#endif

                return m_IsValid;
            }
        }

        public override string Token
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying && string.IsNullOrEmpty(m_Token))
                    return CloudProjectSettings.accessToken;
#endif

                return m_IsValid ? m_Token : string.Empty;
            }
        }

        /// <summary>
        /// Sign in asynchronously and obtain an access token
        /// </summary>
        /// <param name="callback">Called when sign in is complete; bool parameter indicates whether sign in was successful</param>
        /// <param name="intent">Cached sign in intent to obtain an access token for a previous successful sign in</param>
        /// <param name="onlyCached">Only sign in if there is a cached intent</param>
        /// <returns>Enumerator used to continue the process, generally passed to StartCoroutine</returns>
        public override IEnumerator SignIn(Action<bool> callback = null, string intent = "", bool onlyCached = false)
        {
            if (m_IsValid || m_IsInUserTransition || m_GenesisCredential != null)
            {
                callback?.Invoke(false);
                yield break;
            }

            var cachedIntent = TryLoadCachedIntentIfEmpty(intent);
            while (cachedIntent.MoveNext())
            {
                yield return null;
            }

            intent = cachedIntent.Current;

            var isEmptyIntent = string.IsNullOrEmpty(intent);
            if (isEmptyIntent && onlyCached)
                yield break;

            if (isEmptyIntent)
            {
                LaunchBrowserGenesisSignOnRequest();
                callback?.Invoke(false);
                yield break;
            }

            m_IsInUserTransition = true;

            var signIn = PerformSignIn(intent);
            while (signIn.MoveNext())
            {
                yield return null;
            }

            m_IsInUserTransition = false;

            callback?.Invoke(signIn.Current);
        }

        IEnumerator<bool> PerformSignIn(string intent)
        {
            m_GenesisCredential = new GenesisCredential(intent);

            if (m_GenesisCredential.InitializationSucceeded)
                m_Token = m_GenesisCredential.AccessToken;

            if (string.IsNullOrEmpty(m_Token))
            {
                yield return false;
                yield break;
            }

            var getTokenInfo = GetTokenInfo();
            while (getTokenInfo.MoveNext())
            {
                yield return getTokenInfo.Current;
            }

            if (!getTokenInfo.Current)
                yield break;

            var getUserData = GetUserData();
            while (getUserData.MoveNext())
            {
                yield return getUserData.Current;
            }

            if (!getUserData.Current)
                yield break;

            var trySaveCacheIntent = TrySaveCacheIntent(intent);
            while (trySaveCacheIntent.MoveNext())
            {
                yield return false;
            }

            m_IsValid = true;
            yield return true;
        }

        static bool HandleRequestError(UnityWebRequest request)
        {
            if (string.IsNullOrEmpty(request.error))
                return true;

            Debug.LogError(request.error);

            return false;
        }

        IEnumerator<bool> GetTokenInfo()
        {
            if (string.IsNullOrEmpty(m_Token))
                yield break;

            var url = string.Format(k_GetTokenInfoUrlFormat, m_Token);
            var request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbGET);
            request.timeout = k_DefaultTimeout;
            request.downloadHandler = new DownloadHandlerBuffer();
            request.disposeDownloadHandlerOnDispose = true;

            request.SetRequestHeader("Content-Type", "application/json");
            request.SendWebRequest();
            while (!request.isDone)
            {
                yield return false;
            }

            if (!HandleRequestError(request))
                yield break;

            var json = request.downloadHandler.text;

            m_UserTokenInfo = TryParse<UserTokenInfo>(json);
            var success = m_UserTokenInfo != null && m_UserTokenInfo.access_token == m_Token;

            request.Dispose();

            yield return success;
        }

        IEnumerator<bool> GetUserData()
        {
            if (string.IsNullOrEmpty(m_Token))
                yield break;

            var url = string.Format(k_GetUserDataUrlFormat, m_UserTokenInfo.sub);
            var storageModule = ModuleLoaderCore.instance.GetModule<GenesisCloudStorageModule>();
            bool? gotUserData = null;
            m_Requests.Push(storageModule.AuthenticatedGetRequest(url, m_Token, (success, response) =>
            {
                m_Requests.Pop();
                if (!success)
                {
                    Debug.LogError(response);
                    gotUserData = false;
                    return;
                }

                m_UserInfo = TryParse<UserInfo>(response);
                gotUserData = m_UserInfo != null && m_UserTokenInfo.sub == m_UserInfo.id;
            }));

            while (gotUserData == null)
            {
                yield return false;
            }

            yield return gotUserData.Value;
        }

        static T TryParse<T>(string json)
        {
            try
            {
                return JsonUtility.FromJson<T>(json);
            }
            catch (Exception e)
            {
                Debug.LogException(e);

                return default;
            }
        }

        static void LaunchBrowserGenesisSignOnRequest()
        {
            var url = GeneratedLaunchUrl;
#if UNITY_IOS && !UNITY_EDITOR
            LaunchSafariWebViewUrl(url);
#else
            Application.OpenURL(url);
#endif
        }

        static void LaunchBrowserGenesisSignOutRequest()
        {
#if UNITY_IOS && !UNITY_EDITOR
            LaunchSafariWebViewUrl(k_LogoutUrl);
#endif
        }

        /// <summary>
        /// Sign out asynchronously, clearing any cached sign in intents
        /// </summary>
        /// <returns>Enumerator used to continue the process, generally passed to StartCoroutine</returns>
        public override void SignOut()
        {
            if (m_Requests.Count > 0)
            {
                var storageModule = ModuleLoaderCore.instance.GetModule<GenesisCloudStorageModule>();
                if (storageModule != null)
                {
                    while (m_Requests.Count > 0)
                    {
                        var request = m_Requests.Pop();
                        storageModule.CancelRequest(request);
                    }
                }
            }

            m_IsValid = false;
            m_UserTokenInfo = null;
            m_UserInfo = null;
            m_GenesisCredential = null;
            m_IsInUserTransition = false;

            if (File.Exists(k_DeepLinkCachePath))
            {
                File.Delete(k_DeepLinkCachePath);
            }

            LaunchBrowserGenesisSignOutRequest();
        }

        static IEnumerator TrySaveCacheIntent(string intent)
        {
            Assert.IsFalse(string.IsNullOrEmpty(intent));
            return CompanionFileUtils.WriteFileAsync(k_DeepLinkCachePath, intent);
        }

        static IEnumerator<string> TryLoadCachedIntentIfEmpty(string intent)
        {
            if (!string.IsNullOrEmpty(intent))
            {
                yield return intent;
                yield break;
            }

            if (!File.Exists(k_DeepLinkCachePath))
            {
                yield return intent;
                yield break;
            }

            var creation = File.GetCreationTimeUtc(k_DeepLinkCachePath);
            var now = DateTime.UtcNow;

            var sinceCreation = now - creation;
            const int sevenDays = 7;
            if (sinceCreation >= TimeSpan.FromDays(sevenDays))
                File.Delete(k_DeepLinkCachePath);
            else
                intent = File.ReadAllText(k_DeepLinkCachePath);

            yield return intent;
        }

        class GenesisCredential
        {
            public bool InitializationSucceeded { get; private set; }
            public readonly string AccessToken;

            static int FindKey(NameValueCollection collection, string key)
            {
                for (var i = 0; i < collection.Count; i++)
                {
                    if (collection.GetKey(i) == key)
                    {
                        return i;
                    }
                }

                return -1;
            }

            bool VerifyKey(NameValueCollection collection, string key, out string value, string message = null)
            {
                var valueIndex = FindKey(collection, key);
                if (valueIndex > -1)
                {
                    value = collection[valueIndex];
                    return true;
                }

                FailWithError(message ?? $"No {key}");

                value = null;
                return false;
            }

            bool VerifyKey(NameValueCollection collection, string key, string message = null) { return VerifyKey(collection, key, out var _, message); }

            void FailWithError(string message)
            {
                InitializationSucceeded = false;
                Debug.LogError(message);
            }

            void FailWithWarning(string message)
            {
                InitializationSucceeded = false;
                Debug.LogWarning(message);
            }

            static NameValueCollection ParseQueryStringCustom(string url)
            {
                var result = new NameValueCollection();

                if (string.IsNullOrEmpty(url))
                    return result;

                var args = url.Contains('?') ? url.Substring(url.IndexOf('?') + 1) : url;
                args = args.Contains('#') ? args.Substring(args.IndexOf('#') + 1) : args;
                var parts = args.Split('&');
                foreach (var part in parts)
                {
                    if (part.Contains('='))
                    {
                        var position = part.IndexOf('=');
                        var value = part.Substring(position + 1); // Intentionally not removing escape characters
                        result.Add(part.Substring(0, position), value);
                    }
                    else
                    {
                        result.Add(part, "");
                    }
                }

                return result;
            }

            public GenesisCredential(string intent)
            {
                if (intent == null || !intent.Contains("on-registration-completed"))
                {
                    FailWithWarning("Argument to OAuthTokenGenesisModule PopulateWithIntentString does not contain 'on-registration-completed'");
                    return;
                }

                var removeIntentIndex = intent.IndexOf('#') + 1;
                var reducedUrl = intent.Remove(0, removeIntentIndex);
                var collection = !string.IsNullOrEmpty(intent) ? ParseQueryStringCustom(reducedUrl) : new NameValueCollection(0);

                if (!VerifyKey(collection, "access_token", out AccessToken))
                {
                    return;
                }

                if (!VerifyKey(collection, "state"))
                {
                    return;
                }

                if (!VerifyKey(collection, "token_type", out var tokenType))
                {
                    return;
                }

                if (tokenType != "Bearer")
                {
                    FailWithError("Attempting to process intent found tokenType != 'Bearer`");
                    return;
                }

                if (!VerifyKey(collection, "locale"))
                {
                    return;
                }

                if (!VerifyKey(collection, "session_state"))
                {
                    return;
                }

                InitializationSucceeded = true;
            }
        }

        // ReSharper disable InconsistentNaming
        // ReSharper disable ClassNeverInstantiated.Local
        // ReSharper disable UnassignedField.Global
#pragma warning disable 649
        class UserTokenInfo
        {
            public string sub;
            public string access_token;
        }

        class UserInfo
        {
            public string id;
            public string username;
        }
#pragma warning restore 649
        // ReSharper restore UnassignedField.Global
        // ReSharper restore ClassNeverInstantiated.Local
        // ReSharper restore InconsistentNaming
    }
}
