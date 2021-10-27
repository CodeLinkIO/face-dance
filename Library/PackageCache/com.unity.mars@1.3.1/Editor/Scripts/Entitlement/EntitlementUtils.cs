using System;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;

namespace Unity.MARS
{
    static class EntitlementUtils
    {
        /// <summary>
        /// Strings for MARS SKUs as reported with Genesis namespace "unity_mars"
        /// </summary>
        static class MarsSkuSearchLabels
        {
            public const string Base = "UnityMars"; // Basic license to use MARS, used for all features
            public const string Free = "UnityMarsFree"; // Free version of MARS (with an undetermined subset of features)
        }

        public enum MarsSku
        {
            NotEntitled,
            Free,
            Base
        }

        static MarsSku s_EntitlementCurrent = MarsSku.Base;
        static event Action EntitlementChanged;
        static bool s_EntitlementRequested;
        static bool s_EntitlementReceived;
        static bool s_EntitlementCheckEnabled = true; // Check for licenses with Genesis when true, or enable MARS without checking if false
        const string k_EntitlementEndpoint = "https://api.unity.com/v1/entitlements?userId={0}";
        const string k_EntitlementLocalId = "MARS.last_time_entitled";
        const int k_EntitlementDays = 14;
        const int k_EntitlementFramesToWait = 10;
        #pragma warning disable 649
        static bool s_EntitlementAlwaysFail; // use to test not having a license
        static bool s_UseUnityHub; // Use Unity Hub flags when true, otherwise UnityWebRequest to Genesis API
        #pragma warning restore 649

        /// <summary>
        /// True if an entitlement check has failed because the Unity ID login token was expired
        /// </summary>
        internal static bool EntitlementTokenExpired { get; private set; }

        /// <summary>
        /// Synchronous but can update later
        /// </summary>
        static MarsSku EntitlementCurrent
        {
            get
            {
                if (s_EntitlementRequested)
                    return s_EntitlementCurrent;

                GetMarsEntitlementAsync(null);
                return s_EntitlementCurrent;
            }
            set
            {
                s_EntitlementCurrent = value;
                s_EntitlementReceived = true;
                EntitlementChanged?.Invoke();
            }
        }

        /// <summary>
        /// Refresh and ensure we have the latest entitlement
        /// </summary>
        /// <returns></returns>
        internal static bool RefreshEntitlement()
        {
            s_EntitlementRequested = false;
            s_EntitlementReceived = false;
            return IsEntitled(false);
        }

        /// <summary>
        /// See if the system is currently entitled, and kick off async test.
        /// </summary>
        /// <param name="valueIfWaiting">Value to return if async test is still in progress</param>
        /// <returns>If the system is entitled</returns>
        public static bool IsEntitled(bool valueIfWaiting)
        {
            var current = EntitlementCurrent; // causes check to begin
            if (s_EntitlementReceived)
                return (current != MarsSku.NotEntitled);
            if (SavedEntitlement != MarsSku.NotEntitled)
                return true;
            return valueIfWaiting;
        }

        public delegate void EntitlementCallback(bool didSucceed, MarsSku version);

        /// <summary>
        ///  Get the mars entitlement level, either from Hub cache or asynchronously
        /// </summary>
        /// <param name="callback">a callback which returns whether entitlement query was successful, as well as the
        /// MarsSKUs the account is entitled to if it was</param>
        /// <returns></returns>
        public static void GetMarsEntitlementAsync(EntitlementCallback callback)
        {
            if (s_EntitlementReceived)
            {
                callback?.Invoke(true, s_EntitlementCurrent);
                return;
            }
            if (s_EntitlementRequested)
            {
                EntitlementChanged += (() =>
                {
                    if (callback != null)
                    {
                        var original = callback;
                        callback = null;
                        original?.Invoke(true, s_EntitlementCurrent);
                    }
                });
                return;
            }
            s_EntitlementRequested = true;

            var didRequestSucceed = true;
            if (Application.isBatchMode)
            {
                EntitlementCurrent = MarsSku.Free;
            }
            else if (BuildPipeline.isBuildingPlayer)
            {
                EntitlementCurrent = MarsSku.Free;
            }
            else if (Environment.GetCommandLineArgs().Contains("-runTests"))
            {
                EntitlementCurrent = MarsSku.Free;
            }
            else if (s_EntitlementAlwaysFail)
            {
                EntitlementCurrent = MarsSku.NotEntitled;
            }
            else if (s_EntitlementCheckEnabled)
            {
                if (s_UseUnityHub)
                {
                    EntitlementCurrent = DetermineMarsEntitlementThroughHub();
                    SavedEntitlement = EntitlementCurrent;
                }
                else if (SavedEntitlement != MarsSku.NotEntitled)
                {
                    EntitlementCurrent = SavedEntitlement;
                }
                else
                {
                    WaitForAccountInfoToLoad(callback);
                    return;
                }
            }
            else
            {
                EntitlementCurrent = MarsSku.Base;
            }

            s_EntitlementReceived = true;
            if (s_EntitlementCurrent == MarsSku.NotEntitled)
            {
                Debug.LogWarning(MARSSession.NotEntitledMessageWithUrl);
            }

            callback?.Invoke(didRequestSucceed, s_EntitlementCurrent);
        }

        static void WaitForAccountInfoToLoad(EntitlementCallback callback)
        {
            if (string.IsNullOrEmpty(CloudProjectSettings.accessToken))
            {
                var hasToken = false;
                var framesWaited = 0;
                EditorApplication.update += (() =>
                {
                    if (hasToken)
                        return;

                    if (!string.IsNullOrEmpty(CloudProjectSettings.accessToken))
                    {
                        hasToken = true;
                        GetEntitlementViaWebAsync(callback);
                    }
                    else
                    {
                        framesWaited++;
                        if (framesWaited > k_EntitlementFramesToWait)
                        {
                            // no access token, assume no account and thus not-entitled:
                            EntitlementCurrent = MarsSku.NotEntitled;
                            hasToken = true;
                        }
                    }
                });
                return;
            }
            GetEntitlementViaWebAsync(callback);
        }

        static void GetEntitlementViaWebAsync(EntitlementCallback callback)
        {
            var userEmail = CloudProjectSettings.userName.ToLower();
            if (userEmail.EndsWith("@unity3d.com") || userEmail.EndsWith("@unity.com"))
            {
                EntitlementCurrent = MarsSku.Base;
                SavedEntitlement = EntitlementCurrent;
                callback?.Invoke(true, EntitlementCurrent);
                return;
            }

            var url = string.Format(k_EntitlementEndpoint, CloudProjectSettings.userId);
            var request = UnityWebRequest.Get(url);
            var bufferHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Cache-Control", "no-cache");
            request.SetRequestHeader("Authorization", $"Bearer {CloudProjectSettings.accessToken}");
            request.downloadHandler = bufferHandler;
            try
            {
                request.SendWebRequest().completed += ((x) =>
                {
                    var licenseData = bufferHandler.text;
                    if (licenseData.Contains("Expired Access Token") || licenseData.Contains("Invalid Access Token") ||
                        licenseData.Contains("132.107") || licenseData.Contains("132.108") ||
                        licenseData.Contains("120.003"))
                    {
                        Debug.LogWarning($"{MARSSession.TokenExpiredMessage}:\n{licenseData}");
                        EntitlementTokenExpired = true;
                        EntitlementCurrent = MarsSku.NotEntitled;
                    }
                    else
                    {
                        EntitlementTokenExpired = false;
                        EntitlementCurrent = SearchStringForMarsSku(licenseData);
                        SavedEntitlement = EntitlementCurrent;
                    }

                    s_EntitlementReceived = true;
                    callback?.Invoke(true, s_EntitlementCurrent);
                });
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                s_EntitlementReceived = true;
                callback?.Invoke(false, EntitlementCurrent);
            }
        }

        static MarsSku SavedEntitlement
        {
            get
            {
                if (EditorPrefs.HasKey(k_EntitlementLocalId))
                {
                    var timeString = EditorPrefs.GetString(k_EntitlementLocalId);
                    if (DateTime.TryParse(timeString, out var timeGood))
                    {
                        var delta = (timeGood - DateTime.UtcNow).Days;
                        if (Math.Abs(delta) < k_EntitlementDays)
                            return MarsSku.Base;
                    }
                }
                return MarsSku.NotEntitled;
            }
            set
            {
                if (value != MarsSku.NotEntitled)
                {
                    EditorPrefs.SetString(k_EntitlementLocalId, DateTime.UtcNow.ToString());
                }
            }
        }

        static MarsSku DetermineMarsEntitlementThroughHub()
        {
            var entitlementThroughSubscriptionPlan = EntitledToMarsThroughSubscriptionPlan();
            return entitlementThroughSubscriptionPlan;
        }

        static MarsSku EntitledToMarsThroughSubscriptionPlan()
        {
            // Examples from GetLicenseInfo():
            //licenseInfo = "Unity Pro, Team License, iOS Pro, Android Pro, Windows Store Pro Serial number: I3-AB8P-9S8P-7ANM-EWWP-XXXX";
            //licenseInfo = "Unity Pro, UnityMars, Team License, Windows Store Pro Serial number: I3-ABCD-9S8P-7ANM-EWWP-XXXX";
            //licenseInfo = "UnityMarsFree, UnityMars Serial number: I3-ABCD-9S8P-7ANM-AAAA-XXXX";

            return SearchStringForMarsSku(UnityEditorInternal.InternalEditorUtility.GetLicenseInfo());
        }

        static MarsSku SearchStringForMarsSku(string licenseInfo)
        {
            if (licenseInfo.Contains(MarsSkuSearchLabels.Free))
            {
                // If the user has more than one MARS entitlement, consider it a paid entitlement
                return Regex.Matches(licenseInfo,MarsSkuSearchLabels.Base).Count > 1
                    ? MarsSku.Base : MarsSku.Free;
            }
            return licenseInfo.Contains(MarsSkuSearchLabels.Base) ? MarsSku.Base : MarsSku.NotEntitled;
        }
    }
}
