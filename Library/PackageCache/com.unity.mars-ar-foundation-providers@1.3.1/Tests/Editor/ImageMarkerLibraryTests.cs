using NUnit.Framework;

#if ARFOUNDATION_2_1_OR_NEWER
using System.Collections;
using UnityEditor;
using UnityEngine;
using Unity.MARS;
using Unity.MARS.Data;
using Unity.MARS.Data.ARFoundation;
using Unity.MARS.Providers;
using UnityEngine.XR.ARSubsystems;

namespace  Unity.MARS.Providers.ARFoundation.Tests
{
    class ImageMarkerLibraryTests
    {
        static string s_MarkerLibraryAssetPath;
        static string s_ARFMarkerLibraryAssetPath;
        const string k_Extension = ".asset";
        static readonly string k_NewMarkerLibraryPath = $"Assets/New{nameof(MarsMarkerLibrary)}";

        [UnitySetUp]
        public IEnumerator Setup()
        {
            var markerLib = ScriptableObject.CreateInstance<MarsMarkerLibrary>();
            var path = AssetDatabase.GenerateUniqueAssetPath(k_NewMarkerLibraryPath);
            s_MarkerLibraryAssetPath = path + k_Extension;
            s_ARFMarkerLibraryAssetPath = string.Format(MarkerProviderSettings.ARFLibrarySuffixFormat, path) + k_Extension;

            AssetDatabase.CreateAsset(markerLib, s_MarkerLibraryAssetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            yield return null;
        }

        [Test]
        public void ImageMarkerNonEmptyGuidCreation()
        {
            var markerLib = AssetDatabase.LoadAssetAtPath<MarsMarkerLibrary>(s_MarkerLibraryAssetPath);
            markerLib.CreateAndAdd();
            AssetDatabase.Refresh();

            Assert.AreNotEqual(markerLib[markerLib.Count-1].MarkerId,System.Guid.Empty);
        }

        [Test]
        public void ImageMarkerARFFileCreation()
        {
            Assert.IsTrue(AssetDatabase.LoadAssetAtPath<XRReferenceImageLibrary>(s_ARFMarkerLibraryAssetPath));
        }

        [TearDown]
        public void TearDown()
        {
            MarkerProviderSettings.instance.Remove(
                AssetDatabase.LoadAssetAtPath<MarsMarkerLibrary>(s_MarkerLibraryAssetPath));

            AssetDatabase.DeleteAsset(s_MarkerLibraryAssetPath);
            AssetDatabase.DeleteAsset(s_ARFMarkerLibraryAssetPath);

            // Save change to MarkerProviderSettings
            AssetDatabase.SaveAssets();
        }
    }
}
#else
namespace Unity.MARS.Providers.ARFoundation.Tests
{
    class MARSARFoundationProvidersTests
    {
        [Test]
        public void ValidationTest()
        {
            Assert.IsTrue(true);
        }
    }
}
#endif
