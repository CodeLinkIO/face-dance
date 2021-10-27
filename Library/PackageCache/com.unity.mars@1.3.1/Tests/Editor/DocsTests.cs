#if UNITY_EDITOR
using NUnit.Framework;
using System.Reflection;

namespace Unity.MARS.Tests
{
    class DocsTests
    {
        [Test]
        public void DocsVersionMatchWithMARSPackage()
        {
            var myPackage = UnityEditor.PackageManager.PackageInfo.FindForAssembly(Assembly.GetExecutingAssembly());
            if (myPackage != null)
            {
                // We only need the major and minor version from the package, since that's what matters when referencing
                // the docs pages. i.e: 1.3.1 would be referred to as -> 1.3
                var splitVersion = myPackage.version.Split('.');
                var correctedMarsVersion = $"{splitVersion[0]}.{splitVersion[1]}"; // Only use major and minor version

                Assert.AreEqual(correctedMarsVersion, DocumentationConstants.CurrentDocsVersion);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
#endif
