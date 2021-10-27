namespace UnityEditor.MARS.Build
{
    class ElectiveExtensionsToolbarMenu : Editor
    {
        const string k_BuildSettingsTitle = "Build Settings Check";

        [MenuItem(MenuConstants.MenuPrefix + k_BuildSettingsTitle, priority = MenuConstants.ElectiveExtensionsRunBuildCheckPriority)]
        static void RunElectiveExtensionsBuildCheck()
        {
            var result = "";
#if UNITY_ANDROID
            result = ElectiveExtensions.RunReport(ElectiveExtensionsConfigurationAndroid.ConfigAndroid);
#elif UNITY_IOS
            result = ElectiveExtensions.RunReport(ElectiveExtensionsConfigurationIOS.ConfigIOS);
#elif UNITY_LUMIN
            result = ElectiveExtensions.RunReport(ElectiveExtensionsConfigurationLumin.ConfigLumin);
#elif UNITY_WSA
            result = ElectiveExtensions.RunReport(ElectiveExtensionsConfigurationWsa.ConfigWsa);
#else
            result = ("ElectiveExtensions is not supported on this platform \n " +
                "ElectiveExtensions reports are supported on Android, iOS, Universal Windows Platform, and Lumin build targets.");
#endif
            EditorUtility.DisplayDialog(k_BuildSettingsTitle, result, "OK");
        }
    }
}
