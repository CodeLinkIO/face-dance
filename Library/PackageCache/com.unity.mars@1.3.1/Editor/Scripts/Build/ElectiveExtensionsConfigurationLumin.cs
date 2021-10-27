#if UNITY_LUMIN
using UnityEngine.Rendering;
using UnityEditor.Build.Reporting;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Build
{
    [MovedFrom("Unity.MARS.Build")]
    public class ElectiveExtensionsConfigurationLumin : ElectiveExtensions
    {
        public override void OnPreprocessBuild(BuildReport report)
        {
            RunReport(ConfigLumin);
        }

        public static readonly SupportedConfiguration ConfigLumin = new SupportedConfiguration(
            "Lumin",
            new[] {BuildTarget.Lumin},
            new[]
            {
                #if UNITY_2021_1_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "4.1"),
                new PackageItem("com.unity.xr.magicleap", "5.0")
                #elif UNITY_2020_2_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "4.0"),
                new PackageItem("com.unity.xr.magicleap", "5.0")
                #elif UNITY_2020_1_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "3.1"),
                new PackageItem("com.unity.xr.magicleap", "5.0")
                #elif UNITY_2019_3_OR_NEWER
                new PackageItem("com.unity.xr.arfoundation", "2.1"),
                new PackageItem("com.unity.xr.magicleap", "4.0"),
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
            new[]
            {
                GraphicsDeviceType.OpenGLCore, GraphicsDeviceType.OpenGLES3
            },
            supportedGraphicsApIsIsOrdered:true,
            reportOutputLevel: SupportedConfiguration.ReportOutputLevels.DebugLogOnly);
    }
}
#endif
