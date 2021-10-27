using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager.UI;
using UnityEngine;

namespace Unity.ContentManager
{
    /// <summary>
    /// Allows for queuing up of actions to add, update, and remove Content Packs.
    /// The action queue persists after a domain reload, allowing for installation of samples and Unity Packages.
    /// </summary>
    class ContentManagerDriver : ScriptableObject
    {
        const string k_ProductSearchFilter = "t:ContentProduct";
        const string k_CollectionSearchFilter = "t:ContentPack";
        const string k_PackageReferenceKey = "packages/";
        const string k_LocalPackagePath = "LocalContentPacks";
        static string s_CachedPackagePath;
        const string k_AutoPreviewVersion = "preview";

        [SerializeField]
        [Tooltip("List of all requested Content Manager actions.")]
        List<ContentEvent> m_QueuedEvents = new List<ContentEvent>();

        static ContentManagerDriver s_Instance;
        static bool s_StatusRequested;
        static bool s_StatusInitialized;
        static bool s_EditorUpdate;

        /// <summary>
        /// If true, Unity logs status and event updates that the Content Manager goes through.
        /// </summary>
        public static bool LogEvents { get; set; } = false;

        static Action<bool, string> OnStatusUpdate { get; set; }
        static Action<bool, string> OnInstallContent { get; set; }
        static Action<bool, string> OnUninstallContent { get; set; }
        static Action OnContentChanged { get; set; }

        static ContentEvent s_CurrentEvent;

        internal static readonly List<ContentPack> AvailableContentPacks = new List<ContentPack>();
        internal static readonly List<ContentProduct> AvailableContentProducts = new List<ContentProduct>();

        static List<ContentEvent> QueuedEvents
        {
            get { return s_Instance.m_QueuedEvents; }
        }

        internal static ContentManagerDriver Instance
        {
            get
            {
                if (s_Instance == null)
                    Initialize();

                return s_Instance;
            }
        }

        /// <summary>
        /// Ensures a single instance of the Content Manager driver is available when needed.
        /// </summary>
        [InitializeOnLoadMethod]
        static void Initialize()
        {
            var result = "Initialize: ";

            // Cache the path to the library
            s_CachedPackagePath = $"{Path.GetDirectoryName(Application.dataPath)?.ToLower()}{Path.DirectorySeparatorChar}library";

            if (s_Instance != null)
            {
                result += "Duplicate";
                ConditionalLog(result);
                return;
            }

            if (s_Instance == null)
            {
                result += " Instance not set, searching.";
                s_Instance = Resources.FindObjectsOfTypeAll<ContentManagerDriver>().FirstOrDefault();
            }

            if (s_Instance == null)
            {
                result += " Instance not found, creating.";
                s_Instance = CreateInstance<ContentManagerDriver>();
            }

            s_CurrentEvent = null;
            s_StatusRequested = false;
            s_StatusInitialized = false;

            SubscribeStatusCallback(LogStatusResult);
            SubscribeInstallCallback(LogInstallResult);
            SubscribeUninstallCallback(LogUninstallResult);

            // Is there any queued events?  Start a status update which will kick off events again
            if (s_Instance.m_QueuedEvents.Count > 0)
            {
                result += " Events already enqueue - updated status.";
                UpdateContentStatus();
            }

            ConditionalLog(result);
        }

        /// <summary>
        /// Receive events when the list of available Content Packs (or their status) changes.
        /// </summary>
        /// <param name="statusCallback">Function to call when status changes</param>
        internal static void SubscribeStatusCallback(Action<bool, string> statusCallback)
        {
            OnStatusUpdate += statusCallback;
        }

        /// <summary>
        /// Stop receiving events when the list of available content packs (or their status) changes.
        /// </summary>
        /// <param name="statusCallback">Function that no longer should receive status changes</param>
        internal static void UnsubscribeStatusCallback(Action<bool, string> statusCallback)
        {
            OnStatusUpdate -= statusCallback;
        }

        /// <summary>
        /// Receive events when a Content Pack install operation completes.
        /// </summary>
        /// /// <param name="installCallback">Function to call when installation status changes</param>
        internal static void SubscribeInstallCallback(Action<bool, string> installCallback)
        {
            OnInstallContent += installCallback;
        }

        /// <summary>
        /// Stop receiving events when a Content Pack install operation completes.
        /// </summary>
        /// /// <param name="installCallback">Function that should no longer receive installation status changes</param>
        internal static void UnsubscribeInstallCallback(Action<bool, string> installCallback)
        {
            OnInstallContent -= installCallback;
        }

        /// <summary>
        /// Receive events when a Content Pack install operation completes.
        /// </summary>
        /// /// <param name="uninstallCallback">Function to call when uninstall status changes</param>
        internal static void SubscribeUninstallCallback(Action<bool, string> uninstallCallback)
        {
            OnUninstallContent += uninstallCallback;
        }

        /// <summary>
        /// Stop receiving events when a Content Pack install operation completes.
        /// </summary>
        /// <param name="uninstallCallback">Function that should no longer receive uninstallation status changes</param>
        internal static void UnsubscribeUninstallCallback(Action<bool, string> uninstallCallback)
        {
            OnUninstallContent -= uninstallCallback;
        }

        /// <summary>
        /// Receive events when the internal state of the Content Manager changes.
        /// </summary>
        /// /// <param name="changeCallback">Function to call when the internal state of the Content Manager changes</param>
        internal static void SubscribeChangeCallback(Action changeCallback)
        {
            OnContentChanged += changeCallback;
        }

        /// <summary>
        /// Stop receiving events when the internal state of the Content Manager changes.
        /// </summary>
        /// <param name="changeCallback">Function that should no longer receive state change notifications</param>
        internal static void UnsubscribeChangeCallback(Action changeCallback)
        {
            OnContentChanged -= changeCallback;
        }

        /// <summary>
        /// Gets a list of all available Content Packs with updated installation status.
        /// </summary>
        internal static void UpdateContentStatus()
        {
            ConditionalLog("UpdateContentStatus");
            if (s_StatusRequested)
                return;

            StartEditorUpdates();
            s_StatusRequested = true;
        }

        /// <summary>
        /// Queues up an installation of a Content Pack.
        /// </summary>
        /// <param name="contentToInstall">The Content Pack to install</param>
        internal static void InstallContent(ContentPack contentToInstall)
        {
            ConditionalLog($"InstallContent {contentToInstall.DisplayName}");

            // Check if this content is already queued up for install
            if (contentToInstall.InstallStatus.HasFlag(InstallationStatus.InstallQueued))
                return;

            StartEditorUpdates();
            contentToInstall.InstallStatus |= InstallationStatus.InstallQueued;
            QueuedEvents.Add(new ContentEvent { action = PackageAction.Add, targetPack = contentToInstall });
            OnContentChanged?.Invoke();
        }

        /// <summary>
        /// Queues up an uninstallation of a Content Pack.
        /// </summary>
        /// <param name="contentToUninstall">The Content Pack to uninstall</param>
        internal static void UninstallContent(ContentPack contentToUninstall)
        {
            ConditionalLog($"UninstallContent {contentToUninstall.DisplayName}");

            // Check if this content is already queued up for uninstall
            if (contentToUninstall.InstallStatus.HasFlag(InstallationStatus.UninstallQueued))
                return;

            StartEditorUpdates();
            contentToUninstall.InstallStatus |= InstallationStatus.UninstallQueued;
            QueuedEvents.Add(new ContentEvent { action = PackageAction.Remove, targetPack = contentToUninstall });
            OnContentChanged?.Invoke();
        }

        /// <summary>
        /// Stops any pending Content Manager actions relating to a particular Content Pack.
        /// </summary>
        /// <param name="contentToCancel">The Content Pack to stop all actions for</param>
        internal static void CancelContentAction(ContentPack contentToCancel)
        {
            var eventQueue = QueuedEvents;

            ConditionalLog($"CancelContentAction {contentToCancel.DisplayName}");

            // Search through the queued content list for events concerning this content pack
            var cancelableEvents = eventQueue.Where(entry => entry.targetPack == contentToCancel).ToList();

            // Remove them
            foreach (var targetEvent in cancelableEvents)
            {
                eventQueue.Remove(targetEvent);
            }

            // Undo any queued flags
            contentToCancel.InstallStatus &= ~(InstallationStatus.InstallQueued | InstallationStatus.UninstallRequested);
            OnContentChanged?.Invoke();
        }

        /// <summary>
        /// Called internally to go from installing a package to making it writeable.
        /// </summary>
        /// <param name="contentToEmbed">The Content Pack to make a writeable package</param>
        static void EmbedContent(ContentPack contentToEmbed)
        {
            ConditionalLog($"EmbedContent {contentToEmbed.DisplayName}");

            // Content must be installed or installing to embed
            if (!(contentToEmbed.InstallStatus.HasFlag(InstallationStatus.Installed) || contentToEmbed.InstallStatus.HasFlag(InstallationStatus.Installing)))
                return;

            StartEditorUpdates();
            contentToEmbed.InstallStatus |= InstallationStatus.InstallQueued;

            // We stick the embed event at the beginning of the list because it happens automatically after an install
            QueuedEvents.Insert(0, new ContentEvent { action = PackageAction.Embed, targetPack = contentToEmbed });
            OnContentChanged?.Invoke();
        }

        /// <summary>
        /// Called internally to go from installing a package to installing a sample.
        /// </summary>
        /// <param name="contentToInstall">The Content Pack that contains a sample to install</param>
        static void InstallContentSample(ContentPack contentToInstall)
        {
            ConditionalLog($"InstallContentSample {contentToInstall.DisplayName}");

            // Content must be installed or installing to add a sample
            if (!(contentToInstall.InstallStatus.HasFlag(InstallationStatus.Installed) || contentToInstall.InstallStatus.HasFlag(InstallationStatus.Installing)))
                return;

            StartEditorUpdates();
            contentToInstall.InstallStatus |= InstallationStatus.InstallQueued;

            // We stick the sample event at the beginning of the list because it happens automatically after an install
            QueuedEvents.Insert(0, new ContentEvent { action = PackageAction.SampleInstall, targetPack = contentToInstall });
            OnContentChanged?.Invoke();
        }

        /// <summary>
        /// Attempts to get a list of all available and installed packages
        /// so that they can be compared with the list of available Content Packs.
        /// </summary>
        static void StartStatusEvent()
        {
            s_CurrentEvent.request = Client.List();
        }

        /// <summary>
        /// Called when the list of available and installed packages is ready.
        /// Updates the installation status of all Content Packs to match with this data.
        /// </summary>
        static void CompleteStatusEvent()
        {
            s_StatusInitialized = true;
            s_StatusRequested = false;

            var listRequest = s_CurrentEvent.request as ListRequest;
            if (listRequest == null)
                return;

            if (listRequest.Status == StatusCode.Failure)
            {
                OnStatusUpdate?.Invoke(false, listRequest.Error.message);
                return;
            }

            var packageCollection = listRequest.Result;

            // Gather all content packs
            var contentPackGuids = AssetDatabase.FindAssets(k_CollectionSearchFilter);
            AvailableContentPacks.Clear();

            foreach (var guid in contentPackGuids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var currentContentPack = AssetDatabase.LoadAssetAtPath<ContentPack>(assetPath);
                currentContentPack.Path = assetPath.ToLower();
                AvailableContentPacks.Add(currentContentPack);
            }

            // See which ones are already installed
            // Update our list of packs
            foreach (var currentContentPack in AvailableContentPacks)
            {
                // If package collection contains content pack, it is installed, otherwise it is not
                currentContentPack.InstallStatus = InstallationStatus.Unknown;

                var installedPackage = packageCollection.FirstOrDefault(package => package.name == currentContentPack.PackageName);
                if (installedPackage != null)
                {
                    currentContentPack.InstallStatus |= InstallationStatus.Installed;
                    var contentPackVersion = currentContentPack.Version;
                    if (string.IsNullOrEmpty(contentPackVersion) || contentPackVersion == k_AutoPreviewVersion)
                    {
                        if (string.IsNullOrEmpty(installedPackage.versions.verified) || contentPackVersion == k_AutoPreviewVersion)
                            contentPackVersion = installedPackage.versions.latestCompatible;
                        else
                            contentPackVersion = installedPackage.versions.verified;

                        currentContentPack.AutoVersion = contentPackVersion;
                    }
                    else
                        currentContentPack.AutoVersion = "";

                    if (installedPackage.version != contentPackVersion)
                        currentContentPack.InstallStatus |= InstallationStatus.DifferentVersion;
                }

                // Check if an installation action is queued
                var contentEvent = QueuedEvents.Find(currentEvent => currentEvent.targetPack == currentContentPack);
                if (contentEvent != null)
                {
                    if (contentEvent.action == PackageAction.Add)
                        currentContentPack.InstallStatus |= InstallationStatus.InstallQueued;
                    else
                        currentContentPack.InstallStatus |= InstallationStatus.UninstallRequested;
                }
            }

            // Gather all products
            var contentProductGuids = AssetDatabase.FindAssets(k_ProductSearchFilter);
            AvailableContentProducts.Clear();

            foreach (var guid in contentProductGuids)
            {
                var currentContentProduct = AssetDatabase.LoadAssetAtPath<ContentProduct>(AssetDatabase.GUIDToAssetPath(guid));
                AvailableContentProducts.Add(currentContentProduct);
            }


            OnStatusUpdate?.Invoke(true, "Successfully updated content packs status");
        }

        /// <summary>
        /// Attempts to install a package specified within the currently active Content Pack.
        /// </summary>
        static void StartAddEvent()
        {
            // Is the package already installed? Do nothing
            // Otherwise, start an add action
            if (s_CurrentEvent.targetPack.InstallStatus.HasFlag(InstallationStatus.Installed) && !s_CurrentEvent.targetPack.InstallStatus.HasFlag(InstallationStatus.DifferentVersion))
            {
                OnInstallContent?.Invoke(true, $"{s_CurrentEvent.targetPack.PackageName} already installed");
                s_CurrentEvent = null;
                return;
            }

            s_CurrentEvent.targetPack.InstallStatus |= InstallationStatus.Locked;
            var currentUrl = s_CurrentEvent.targetPack.Url.ToLower();
            if (currentUrl.StartsWith(k_PackageReferenceKey))
            {
                // Local content packs can be in embedded packages, which is fine
                // Or they can be in the library folder, in which case we need to copy them to a temporary folder for installation
                currentUrl = Path.GetFullPath(currentUrl).ToLower();

                if (currentUrl.StartsWith(s_CachedPackagePath))
                {
                    try
                    {
                        // The content pack is located within the library folder - we must copy it to a temporary folder
                        var localPackageInfo = new DirectoryInfo(currentUrl);
                        if (localPackageInfo.Exists)
                        {
                            var localFolder = localPackageInfo.Name;
                            var targetPath = $"{Path.GetDirectoryName(Application.dataPath)}{Path.DirectorySeparatorChar}{k_LocalPackagePath}{Path.DirectorySeparatorChar}{localFolder}";

                            Directory.CreateDirectory(targetPath);
                            FileUtil.ReplaceDirectory(currentUrl.Replace(Path.DirectorySeparatorChar, '/'), targetPath.Replace(Path.DirectorySeparatorChar, '/'));
                            currentUrl = $"file:{ToRelativeUnityPath(targetPath)}";
                        }
                        else
                        {
                            OnInstallContent?.Invoke(false, $"{s_CurrentEvent.targetPack.PackageName} cannot be found");
                            s_CurrentEvent = null;
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        OnInstallContent?.Invoke(false, $"Exception installing {s_CurrentEvent?.targetPack.PackageName}:{ex.Message}");
                        s_CurrentEvent = null;
                        return;
                    }
                }
                else
                {
                    // Convert the packages path to a relative path for version control niceness
                    currentUrl = $"file:{ToRelativeUnityPath(Path.GetFullPath(currentUrl))}";
                }
            }

            if (!string.IsNullOrEmpty(s_CurrentEvent.targetPack.AutoVersion))
                currentUrl += $"@{s_CurrentEvent.targetPack.AutoVersion}";

            s_CurrentEvent.request = Client.Add(currentUrl);
            OnContentChanged?.Invoke();
        }

        /// <summary>
        /// Called when the Package Manager has completed the add request.
        /// Queues up additional actions if the content is set to be installed to the project folder.
        /// </summary>
        static void CompleteAddEvent()
        {
            var targetPack = s_CurrentEvent.targetPack;
            var addRequest = s_CurrentEvent.request as AddRequest;

            if (addRequest == null)
                return;

            if (addRequest.Status == StatusCode.Failure)
            {
                targetPack.InstallStatus &= ~InstallationStatus.Installing;
                OnInstallContent?.Invoke(false, addRequest.Error.message);
                OnContentChanged?.Invoke();
                return;
            }

            switch (targetPack.InstallType)
            {
                case InstallationType.Package:
                    FinishInstallation(targetPack);
                    break;
                case InstallationType.WriteablePackage:
                    EmbedContent(targetPack);
                    break;
                case InstallationType.UnityPackage:
                    InstallContentSample(targetPack);

                    // Update the status so the sample can be found
                    UpdateContentStatus();
                    break;
            }
        }

        /// <summary>
        /// Attempts to embed a package specified within the currently active Content Pack.
        /// </summary>
        static void StartEmbedEvent()
        {
            var targetPack = s_CurrentEvent.targetPack;
            ConditionalLog($"Start Embed Event {targetPack.DisplayName}");
            targetPack.InstallStatus |= InstallationStatus.Locked;
            s_CurrentEvent.request = Client.Embed(targetPack.PackageName);
            OnContentChanged?.Invoke();
        }

        /// <summary>
        /// Called when Package Manager has completed the embed request.
        /// </summary>
        static void CompleteEmbedEvent()
        {
            var targetPack = s_CurrentEvent.targetPack;
            var embedRequest = s_CurrentEvent.request as EmbedRequest;

            ConditionalLog($"Complete Embed Event {targetPack.DisplayName}");

            if (embedRequest == null)
                return;

            if (embedRequest.Status == StatusCode.Failure)
            {
                targetPack.InstallStatus &= ~InstallationStatus.Installing;
                OnInstallContent?.Invoke(false, $"Embed: {embedRequest.Error.message}");
                OnContentChanged?.Invoke();
                return;
            }

            FinishInstallation(targetPack);
        }

        /// <summary>
        /// Attempts to install the sample associated with the currently active Content Pack.
        /// </summary>
        static void ProcessSampleEvent()
        {
            var targetPack = s_CurrentEvent.targetPack;
            var samples = Sample.FindByPackage(targetPack.PackageName, targetPack.Version);

            // We manually set the event null this time because we have no asynchronous request to process
            s_CurrentEvent = null;

            if (!samples.Any())
            {
                targetPack.InstallStatus &= ~InstallationStatus.Installing;
                OnInstallContent?.Invoke(false, $"Can't install content - no sample available.");
                OnContentChanged?.Invoke();
                return;
            }

            var targetSample = samples.First();
            if (!targetSample.Import())
            {
                targetPack.InstallStatus &= ~InstallationStatus.Installing;
                OnInstallContent?.Invoke(false, $"Failed to import associated content sample.");
                OnContentChanged?.Invoke();
                return;
            }

            FinishInstallation(targetPack);
        }

        static void FinishInstallation(ContentPack targetPack)
        {
            targetPack.InstallStatus = InstallationStatus.Installed;
            OnInstallContent?.Invoke(true, $"Successfully installed {targetPack.PackageName}");
            OnContentChanged?.Invoke();

            // We do an update here to ensure icon state is maintained - enough can change between dependencies and cross-references that just changing the target pack can be misleading
            if (QueuedEvents.Count == 0)
                UpdateContentStatus();
        }

        /// <summary>
        /// Attempts to remove the package that the currently active event contains.
        /// </summary>
        static void StartUninstallEvent()
        {
            // If the package is not installed, do nothing.
            if (!s_CurrentEvent.targetPack.InstallStatus.HasFlag(InstallationStatus.Installed))
            {
                OnUninstallContent?.Invoke(true, $"{s_CurrentEvent.targetPack.PackageName} not installed");
                s_CurrentEvent = null;
                return;
            }

            s_CurrentEvent.targetPack.InstallStatus |= InstallationStatus.Locked;
            s_CurrentEvent.request = Client.Remove(s_CurrentEvent.targetPack.PackageName);
            OnContentChanged?.Invoke();
        }

        /// <summary>
        /// Called when Package Manager has completed a remove request.
        /// </summary>
        static void CompleteUninstallEvent()
        {
            var targetPack = s_CurrentEvent.targetPack;
            var removeRequest = s_CurrentEvent.request as RemoveRequest;

            if (removeRequest == null)
                return;

            if (removeRequest.Status == StatusCode.Failure)
            {
                targetPack.InstallStatus &= ~(InstallationStatus.UninstallRequested | InstallationStatus.Locked);
                OnUninstallContent?.Invoke(false, removeRequest.Error.message);
                OnContentChanged?.Invoke();
                return;
            }

            targetPack.InstallStatus = InstallationStatus.Unknown;
            OnUninstallContent?.Invoke(true, $"Successfully uninstalled {s_CurrentEvent.targetPack.PackageName}");
            OnContentChanged?.Invoke();

            // We do an update here to ensure icon state is maintained - enough can change between dependencies and cross-references that just changing the target pack can be misleading
            if (QueuedEvents.Count == 0)
                UpdateContentStatus();
        }

        /// <summary>
        /// Tells the driver to start checking for and running queued Content Manager actions.
        /// </summary>
        static void StartEditorUpdates()
        {
            EditorApplication.update -= ContentRequestUpdate;
            EditorApplication.update += ContentRequestUpdate;
            s_EditorUpdate = true;
        }

        /// <summary>
        /// Tells the driver to stop attempting to run Content Manager actions.
        /// </summary>
        static void StopEditorUpdates()
        {
            if (!s_EditorUpdate)
                return;

            EditorApplication.update -= ContentRequestUpdate;
            s_EditorUpdate = false;
        }

        /// <summary>
        /// Checks the status of currently running Content Manager actions and queues up new ones if current actions have finished.
        /// Runs every frame while a Content Manager action is available or running.
        /// </summary>
        static void ContentRequestUpdate()
        {
            ConditionalLog("Request update loop");
            var eventQueue = QueuedEvents;

            // Queue up an event if we're open for one
            // If an event is running, see if it has finished
            if (s_CurrentEvent == null)
            {
                if (eventQueue.Count > 0 || s_StatusRequested)
                {
                    if (s_StatusRequested || !s_StatusInitialized)
                    {
                        s_CurrentEvent = new ContentEvent { action = PackageAction.Status };
                    }
                    else
                    {
                        s_CurrentEvent = eventQueue[0];
                        eventQueue.RemoveAt(0);
                    }

                    // Start the next action
                    switch (s_CurrentEvent.action)
                    {
                        case PackageAction.Status:
                            StartStatusEvent();
                            break;
                        case PackageAction.Add:
                            StartAddEvent();
                            break;
                        case PackageAction.Remove:
                            StartUninstallEvent();
                            break;
                        case PackageAction.Embed:
                            StartEmbedEvent();
                            break;
                        case PackageAction.SampleInstall:
                            ProcessSampleEvent();
                            break;
                    }
                }
                else
                    StopEditorUpdates();
            }
            else
            {
                // Check the request status
                if (s_CurrentEvent.request != null && s_CurrentEvent.request.IsCompleted)
                {
                    // Complete the action
                    switch (s_CurrentEvent.action)
                    {
                        case PackageAction.Status:
                            CompleteStatusEvent();
                            break;
                        case PackageAction.Add:
                            CompleteAddEvent();
                            break;
                        case PackageAction.Remove:
                            CompleteUninstallEvent();
                            break;
                        case PackageAction.Embed:
                            CompleteEmbedEvent();
                            break;
                    }

                    s_CurrentEvent = null;
                }
            }
        }

        static string ToRelativeUnityPath(string targetPath)
        {
            targetPath = targetPath.ToLower();
            var relativeSource = Path.GetDirectoryName(Application.dataPath).ToLower();
            if (targetPath.StartsWith(relativeSource))
                targetPath = $"..{targetPath.Substring(relativeSource.Length)}";

            return targetPath.Replace(Path.DirectorySeparatorChar, '/');
        }
        static void ConditionalLog(object message)
        {
            if (!LogEvents)
                return;

            Debug.Log(message);
        }

        static void LogStatusResult(bool status, string message)
        {
            ConditionalLog($"Content status {status} : {message}");
        }

        static void LogInstallResult(bool status, string message)
        {
            ConditionalLog($"Content install {status} : {message}");
        }

        static void LogUninstallResult(bool status, string message)
        {
            ConditionalLog($"Content uninstall {status} : {message}");
        }
    }
}
