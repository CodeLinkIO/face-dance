#if UNITY_WSA
using UnityEditor.Build.Reporting;

namespace UnityEditor.MARS.Build
{
    public class ElectiveExtensionsConfigurationWsa : ElectiveExtensions
    {
        public override void OnPreprocessBuild(BuildReport report)
        {
            RunReport(ConfigWsa);
        }

        public static readonly SupportedConfiguration ConfigWsa = new SupportedConfiguration(
            "Universal Windows Platform",
            new[] {BuildTarget.WSAPlayer},
            new[]
            {
                #if UNITY_2021_1_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "4.1"),
                new PackageItem("com.unity.xr.windowsmr", "3.0")
                #elif UNITY_2020_2_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "4.0"),
                new PackageItem("com.unity.xr.windowsmr", "3.0")
                #elif UNITY_2020_1_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "3.1"),
                new PackageItem("com.unity.xr.windowsmr", "3.0")
                #elif UNITY_2019_3_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "2.1"),
                new PackageItem("com.unity.xr.windowsmr", "2.0")
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
            reportOutputLevel: SupportedConfiguration.ReportOutputLevels.DebugLogOnly);
    }
}
#endif
