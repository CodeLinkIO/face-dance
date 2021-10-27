using System;
using System.Collections.Generic;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    class IssueHandlingModule : ScriptableSettings<IssueHandlingModule>, IModule, IProvidesIssueHandling
    {
#pragma warning disable 649
        [Serializable]
        struct Entry
        {
            public string Name;
            public IssueDialogSettings Settings;
        }

        [SerializeField]
        Entry[] m_Entries = new Entry[0];
#pragma warning restore 649

        public event IssueHandlingRequested OnIssueRaised;

        HashSet<string> m_IgnoredIssueCodes = new HashSet<string>();

        IssueDialogSettings GetSettingsByIssueCode(string issueCode)
        {
            for (var i = 0; i < m_Entries.Length; i++)
            {
                var entry = m_Entries[i];
                if (entry.Name == issueCode)
                    return entry.Settings;
            }

            Debug.LogError($"User attempted to get non-existent issue {issueCode}");
            return default;
        }

        void Ignore(string issueCode) => m_IgnoredIssueCodes.Add(issueCode);

        public bool IsIgnored(string issueCode) => m_IgnoredIssueCodes.Contains(issueCode);

        public void LoadModule() { }

        public void UnloadModule() { }

        public void LoadProvider() { }

        public void ConnectSubscriber(object obj) => this.TryConnectSubscriber<IProvidesIssueHandling>(obj);

        public void UnloadProvider() { }

        public void RaiseIssueRequest(in IssueHandlingRequest request)
        {
            if (IsIgnored(request.IssueCode))
                return;

            var hasForceIgnore = request.Settings.ForceIgnoreToggle;
            if (hasForceIgnore)
            {
                var modifiedSettings = request.Settings;

                modifiedSettings.HasToggle = true;
                modifiedSettings.ToggleText = "Ignore this message until I close the app.";

                var previousCallback = request.HandledCallback;
                var issueCode = request.IssueCode;
                void WrappedIgnoreCallback(IssueHandlingResult result)
                {
                    previousCallback?.Invoke(result);
                    if (result.Toggled)
                        Ignore(issueCode);
                }

                var modifiedRequest = new IssueHandlingRequest(issueCode, modifiedSettings, WrappedIgnoreCallback);
                LogAndSendRequest(modifiedRequest);
            }
            else
            {
                LogAndSendRequest(request);
            }
        }

        void LogAndSendRequest(in IssueHandlingRequest request)
        {
            var message = request.Settings.Description;
            switch (request.Settings.LogType)
            {
                case LogType.Error:
                    Debug.LogError(message);
                    break;
                case LogType.Assert:
                    Debug.LogAssertion(message);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(message);
                    break;
                case LogType.Log:
                    Debug.Log(message);
                    break;
                case LogType.Exception:
                    Debug.LogException(request.Exception);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            OnIssueRaised?.Invoke(request);
        }

        public void RaiseIssueRequest(string issueCode, IssueDialogSettings? settings = null,
            IssueHandledCallback callback = null, bool useToggle = false, bool toggleStatus = false)
        {
            IssueDialogSettings resultSettings;

            if (settings.HasValue)
            {
                resultSettings = settings.Value;
            }
            else if (GetIssueDialogSettings(issueCode, out var issueDialogData))
            {
                resultSettings = issueDialogData;
            }
            else
            {
                resultSettings = new IssueDialogSettings
                {
                    AcceptText = "Accept",
                    CancelText = string.Empty,
                    Title = issueCode,
                    Description = "Unknown issue: " + issueCode,
                    HasToggle = useToggle,
                    LogType = LogType.Error,
                    ForceIgnoreToggle = false,
                };
            }

            RaiseIssueRequest(new IssueHandlingRequest(issueCode, resultSettings, callback, toggleStatus));
        }

        public void RaiseIssueRequest(string description, string issueCode, Action closedCallback = null)
        {
            var hasSettings = GetIssueDialogSettings(issueCode, out var settings);

            if (hasSettings)
                settings.Description = description;

            IssueHandledCallback callback = null;
            if (closedCallback != null)
                callback = result => closedCallback();

            RaiseIssueRequest(new IssueHandlingRequest(issueCode, settings, callback));
        }

        public void RaiseIssueRequest(string issueCode, Action closedCallback)
        {
            GetIssueDialogSettings(issueCode, out var settings);

            IssueHandledCallback callback = null;
            if (closedCallback != null)
                callback = result => closedCallback();

            RaiseIssueRequest(new IssueHandlingRequest(issueCode, settings, callback));
        }

        public bool GetIssueDialogSettings(string issueCode, out IssueDialogSettings settings)
        {
            settings = GetSettingsByIssueCode(issueCode);
            return settings.IsValid;
        }
    }
}
