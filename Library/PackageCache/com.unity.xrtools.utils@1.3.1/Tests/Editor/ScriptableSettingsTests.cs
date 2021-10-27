using NUnit.Framework;
using System.Collections;
using Unity.XRTools.Utils.Internal;
using UnityEngine;
using UnityEngine.TestTools;

namespace UnityEditor.XRTools.Utils.Tests
{
    class ScriptableSettingsTests
    {
        // These fields are accessed via reflection using TestCaseSource
#pragma warning disable 414
        static IEnumerable s_ValidatePathValidData = new[]
        {
            new TestCaseData("Some/Path", "Some/Path/"),
            new TestCaseData(@"  Some/Path/Two ", "Some/Path/Two/"),
            new TestCaseData("Something////", "Something/"),
            new TestCaseData(@"Some///Path//Two/", "Some/Path/Two/")
        };

        static IEnumerable s_AbsolutePathData = new[]
        {
            new TestCaseData("C:/Some/Absolute/Windows/Path"),
            new TestCaseData("/Some/Absolute/Path")
        };
#pragma warning restore 414

        [TestCaseSource(typeof(ScriptableSettingsTests), "s_ValidatePathValidData")]
        public void ValidatePath_ValidPath(string path, string expectedCleanedPath)
        {
            string cleanedPath;
            var valid = ScriptableSettingsBase.ValidatePath(path, out cleanedPath);
            Assert.True(valid);
            Assert.AreEqual(expectedCleanedPath, cleanedPath);
        }

        [Test]
        public void ValidatePath_NullPath()
        {
            string cleanedPath;
            LogAssert.Expect(LogType.Warning, ScriptableSettingsBase.nullPathMessage);
            ScriptableSettingsBase.ValidatePath(null, out cleanedPath);
        }

        [Test]
        public void ValidatePath_PathWithPeriod()
        {
            string cleanedPath;
            LogAssert.Expect(LogType.Warning, ScriptableSettingsBase.pathWithPeriodMessage);
            ScriptableSettingsBase.ValidatePath("../Some/Path", out cleanedPath);
        }

        [TestCaseSource(typeof(ScriptableSettingsTests), "s_AbsolutePathData")]
        public void ValidatePath_AbsolutePath(string path)
        {
            string cleanedPath;
            Assert.IsFalse(ScriptableSettingsBase.ValidatePath(path, out cleanedPath));
        }

        [Test]
        public void ValidatePath_InvalidCharacter()
        {
            string cleanedPath;
            LogAssert.Expect(LogType.Warning, ScriptableSettingsBase.pathWithInvalidCharacterMessage);
            ScriptableSettingsBase.ValidatePath(@"Some/Path/With""Quote\\s", out cleanedPath);
        }
    }
}
