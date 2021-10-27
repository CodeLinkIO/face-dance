using Unity.MARS.MARSUtils;
using UnityEditor;
using UnityEngine;

namespace Unity.MARS
{
    [InitializeOnLoad]
    static class CameraPermissionUtils
    {
        internal const string CameraPermissionPref = "MARS.has_camera_permission";

        const string k_MacOS = "Mac OS X";
        const string k_PermissionDialogTitle = "MARS Camera Permission";
        const string k_PermissionDialogBody = "The requested simulation mode requires the use of the camera on your computer. Please grant permission for MARS to use the camera. Unity will not store or collect your images.  Take care to keep security on your machine up to date.";
        const string k_PermissionDialogAllow = "Allow";
        const string k_PermissionDialogDeny = "Deny";
        const int k_MojaveVersion = 14;

        const string k_NoPermissionWarningDefault = "MARS was unable to use the camera because the user denied access. To allow access, go to Preferences > MARS and enable Camera permission";
        const string k_NoPermissionWarningOSXWithPermissions = "MARS was unable to use the camera because the user denied access. To allow access, go to System Preferences > Security & Privacy > Camera and enable Unity Hub";

        static CameraPermissionUtils()
        {
            EditorOnlyDelegates.PerformCameraPermissionCheck = PerformCameraPermissionCheck;
        }

        static bool SuppressPermissionCheck()
        {
            if (Application.isBatchMode)
                return true;

            return IsOSXWithPermissions();
        }

        internal static bool IsOSXWithPermissions()
        {
            var osVersion = SystemInfo.operatingSystem;
            if (osVersion.Contains(k_MacOS))
            {
                // Check if minor version >= 14 (Mojave)
                var parts = osVersion.Split('.');
                if (int.TryParse(parts[1], out var minorVersion))
                {
                    if (minorVersion >= k_MojaveVersion)
                        return true;
                }
            }

            return false;
        }

        static bool PerformCameraPermissionCheck(bool withLog = true)
        {
            if (SuppressPermissionCheck())
                return true;

            var hasChecked = EditorPrefs.HasKey(CameraPermissionPref);
            var hasPermission = EditorPrefs.GetBool(CameraPermissionPref, false);
            if (!hasChecked && !hasPermission)
            {
                hasPermission = EditorUtility.DisplayDialog(k_PermissionDialogTitle, k_PermissionDialogBody, k_PermissionDialogAllow, k_PermissionDialogDeny);
                EditorPrefs.SetBool(CameraPermissionPref, hasPermission);
            }

            if (!hasPermission && withLog)
                Debug.LogWarning(IsOSXWithPermissions() ? k_NoPermissionWarningOSXWithPermissions : k_NoPermissionWarningDefault);

            return hasPermission;
        }
    }
}
