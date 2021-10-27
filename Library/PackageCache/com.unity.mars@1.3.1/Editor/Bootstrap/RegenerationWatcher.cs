using System;
using System.IO;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEditor.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Forces code regeneration when the MARS package version changes
    /// </summary>
    [ScriptableSettingsPath(Constants.AssetMarsRootFolder + "/Settings")] // must match: PackageSource/com.unity.mars/Runtime/Scripts/MARSCore.cs
    [InitializeOnLoad]
    class RegenerationWatcher : EditorScriptableSettings<RegenerationWatcher>
    {
        const string k_UnityGenerateAll = "unity_generate_all_csproj";

        // From com.unity.ide.rider >= 2.0
        const string k_UnityProjectGenerationFlag = "unity_project_generation_flag";
        const int k_DefaultPackagesFlag = 3;
        const int k_RegistryPackagesFlag = 1 << 2;

        static ListRequest s_PackageListRequest;
        static bool s_ClearLogCalled;

        [SerializeField]
        string m_PreviousMarsPackageVersion;

#pragma warning disable 649
        [SerializeField]
        bool m_DisableDeleteGenerated;

        [HideInInspector]
        [SerializeField]
        bool m_TriedToSetGenerateAllProjects;
#pragma warning restore 649

        [UnityEditor.Callbacks.DidReloadScripts]
        static void OnReloadScripts()
        {
            CompilationPipeline.compilationStarted += StartCheck;
        }

        static RegenerationWatcher() => OnReloadScripts();

        protected override void OnLoaded()
        {
            if (!m_TriedToSetGenerateAllProjects)
            {
                m_TriedToSetGenerateAllProjects = true;
                EditorUtility.SetDirty(this);

                // Force save in case of error
                AssetDatabase.SaveAssets();

                // Enable "Generate all .csproj files" preference
                EditorPrefs.SetBool(k_UnityGenerateAll, true);

                //Handle Rider plugin with custom EditorPref
                var currentFlag = EditorPrefs.GetInt(k_UnityProjectGenerationFlag, k_DefaultPackagesFlag);
                currentFlag |= k_RegistryPackagesFlag;
                EditorPrefs.SetInt(k_UnityProjectGenerationFlag, currentFlag);
            }
        }

        static void StartCheck(object context = null)
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode || Application.isBatchMode)
                return;

            s_ClearLogCalled = false;
            s_PackageListRequest = Client.List(true);
            EditorApplication.update += PackageCheckUpdate;
            Application.logMessageReceived += OnLogMessage;
        }

        static void PackageCheckUpdate()
        {
            if (s_PackageListRequest == null || !s_PackageListRequest.IsCompleted)
                return;

            if (s_PackageListRequest.Status == StatusCode.Success)
            {
                foreach (var package in s_PackageListRequest.Result)
                {
                    if (package.name != Constants.MarsPackageName)
                        continue;

                    if (package.version != instance.m_PreviousMarsPackageVersion)
                    {
                        instance.m_PreviousMarsPackageVersion = package.version;
                        EditorUtility.SetDirty(instance);
                        // because the version has changed, delete existing generated code
                        DeleteGeneratedFiles();
                    }

                    break;
                }
            }

            // if the request for packages fails, just do nothing.
            EditorApplication.update -= PackageCheckUpdate;
            CompilationPipeline.compilationStarted -= StartCheck;
            Application.logMessageReceived -= OnLogMessage;
            s_PackageListRequest = null;
        }

        static void DeleteGeneratedFiles()
        {
            if (instance.m_DisableDeleteGenerated)
                return;

            if (!s_ClearLogCalled)  // to prevent logging the message more than once
            {
                DebugUtils.Log($"Clearing MARS generated code in {Constants.GeneratedPath}");
                s_ClearLogCalled = true;
            }

            try
            {
                foreach (var filePath in Directory.EnumerateFiles(Constants.GeneratedPath))
                {
                    if (filePath.EndsWith(".meta"))
                    {
                        File.Delete(filePath);
                    }
                    else if (filePath.EndsWith(".cs"))
                    {
                        // To prevent a possible compiler error from missing files, write a blank instead of deleting
                        File.WriteAllText(filePath, string.Empty);
                    }
                }

                // After the asset database refreshes, the usual code generation process should kick off
                AssetDatabase.Refresh();
            }
            catch (DirectoryNotFoundException)
            {
                DebugUtils.LogWarning($"Could not find the MARS generated code folder {Constants.GeneratedPath}!");
            }
            catch (Exception e)
            {
                DebugUtils.LogException(e);
            }
        }

        static void OnLogMessage(string message, string stackTrace, LogType logType)
        {
            if (logType == LogType.Error && message.Contains(Constants.GeneratedPath))
            {
                // as soon as we detect a single compile error in the generated code, stop and delete it.
                EditorApplication.delayCall += DeleteGeneratedFiles;
                Application.logMessageReceived -= OnLogMessage;
            }
        }
    }
}
