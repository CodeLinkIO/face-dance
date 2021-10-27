#if XRMANAGEMENT_3_2_OR_NEWER
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.XR.Management.Metadata;
using UnityEngine;

namespace Unity.MARS.XRSubsystem
{
    class MARSXRSubsystemPackage : IXRPackage
    {
        class MARSXRSubsystemLoaderMetadata : IXRLoaderMetadata
        {
            public string loaderName { get; set; }
            public string loaderType { get; set; }
            public List<BuildTargetGroup> supportedBuildTargets { get; set; }
        }

        class MARSXFSubsystemPackageMetadata : IXRPackageMetadata
        {
            public string packageName { get; set; }
            public string packageId { get; set; }
            public string settingsType { get; set; }
            public List<IXRLoaderMetadata> loaderMetadata { get; set; }
        }

        static IXRPackageMetadata s_Metadata = new MARSXFSubsystemPackageMetadata
        {
            packageName = "MARS XR Subsystem",
            packageId = "com.unity.mars-ar-foundation-providers",
            settingsType = typeof(MARSXRSubsystemSettings).FullName,
            loaderMetadata = new List<IXRLoaderMetadata>
            {
                new MARSXRSubsystemLoaderMetadata
                {
                    loaderName = "MARS Simulation",
                    loaderType = typeof(MARSXRSubsystemLoader).FullName,
                    supportedBuildTargets = new List<BuildTargetGroup>
                    {
                        BuildTargetGroup.Standalone,
                    }
                }
            }
        };

        public IXRPackageMetadata metadata => s_Metadata;

        public bool PopulateNewSettingsInstance(ScriptableObject obj) { return true; }
    }
}
#endif
