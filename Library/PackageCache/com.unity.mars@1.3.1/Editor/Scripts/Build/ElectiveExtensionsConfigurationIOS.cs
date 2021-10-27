#if UNITY_IOS
using UnityEditor.Build.Reporting;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Build
{
    [MovedFrom("Unity.MARS.Build")]
    public class ElectiveExtensionsConfigurationIOS : ElectiveExtensions
    {
        public override void OnPreprocessBuild(BuildReport report)
        {
            RunReport(ConfigIOS);
        }

        public static readonly SupportedConfiguration ConfigIOS = new SupportedConfiguration(
            "iOS",
            new[] {BuildTarget.iOS},
            new[]
            {
                #if UNITY_2021_1_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "4.1"),
                new PackageItem("com.unity.xr.arkit", "4.1")
                #elif UNITY_2020_2_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "4.0"),
                new PackageItem("com.unity.xr.arkit", "4.0")
                #elif UNITY_2020_1_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "3.1"),
                new PackageItem("com.unity.xr.arkit", "3.1")
                #elif UNITY_2019_3_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "2.1"),
                new PackageItem("com.unity.xr.arkit", "2.1"),
                new PackageItem("com.unity.xr.arkit-face-tracking", "1.0")
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
            reportOutputLevel: SupportedConfiguration.ReportOutputLevels.WarnOnIssue);
    }
}
#endif
