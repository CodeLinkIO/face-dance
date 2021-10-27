#if UNITY_ANDROID
using UnityEngine.Rendering;
using UnityEditor.Build.Reporting;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Build
{
    [MovedFrom("Unity.MARS.Build")]
    public class ElectiveExtensionsConfigurationAndroid : ElectiveExtensions
    {
        public override void OnPreprocessBuild(BuildReport report)
        {
            RunReport(ConfigAndroid);
        }

        public static readonly SupportedConfiguration ConfigAndroid = new SupportedConfiguration(
            "Android",
            new[] {BuildTarget.Android},
            new[]
            {
                #if UNITY_2021_1_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "4.1"),
                new PackageItem("com.unity.xr.arcore", "4.1")
                #elif UNITY_2020_2_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "4.0"),
                new PackageItem("com.unity.xr.arcore", "4.0")
                #elif UNITY_2020_1_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "3.1"),
                new PackageItem("com.unity.xr.arcore", "3.1")
                #elif UNITY_2019_3_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "2.1"),
                new PackageItem("com.unity.xr.arcore", "2.1")
                #endif
            },
            new[]
            {
                //UNITY_CCU
                new DefineSymbolItem("UNITY_CCU",
                    true
                    #if UNITY_CCU
                    ,true
                    #endif
                    )
                },
            supportedEditorVersions: new[]
            {
                "2019.3"
            },
            reportOutputLevel: SupportedConfiguration.ReportOutputLevels.WarnOnIssue);
    }
}
#endif
