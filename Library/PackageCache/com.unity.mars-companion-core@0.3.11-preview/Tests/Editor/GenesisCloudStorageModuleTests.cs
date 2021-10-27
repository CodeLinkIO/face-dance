using System;
using System.Collections;
using NUnit.Framework;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.MARS.Companion.CloudStorage
{
    class GenesisCloudStorageModuleTests
    {
        GenesisCloudStorageModule m_Module;

        const string k_Key1 = "001";
        const string k_Key2 = "002";
        const string k_Key3 = "003";
        const string k_Data1 = "abcdef";
        const string k_Data2 = "{\"$type\" \"Unity.MARS.Companion.Core.ResourceList, Unity.MARS.Companion.Core\",\"m_Resources\" {\"$type\" \"System.Collections.Generic.List`1[System.Object], mscorlib\", \"$elements\" [\"class\", \"null\", \"!@#$%^&*()\\\\_+-=,.<>/?|:;\", \"private\", \"void\"]},\"m_BundleResources\" {\"$type\" \"System.Collections.Generic.List`1[System.Object], mscorlib\",\"$elements\" []}}"; // Test including nonsense special characters and words
        static readonly byte[] k_Data3 = { 54, 68, 69, 73, 20, 69, 73, 20, 61, 20, 74, 65, 73, 74 }; // UTF8 encoded "This is a test"

        OAuthTokenGenesisModule m_MarsIdentity;
        const string k_TestIntent = "REPLACE_WITH_INTENT_TO_TEST";

        [OneTimeSetUp]
        public void Setup()
        {
            m_Module = ModuleLoaderCore.instance.GetModule<GenesisCloudStorageModule>();
        }

        IEnumerator WaitForGenesisProfile()
        {
            m_MarsIdentity = new OAuthTokenGenesisModule();
            var loginTask = m_MarsIdentity.SignIn(intent: k_TestIntent);
            while (loginTask.MoveNext())
            {
                yield return null;
            }
        }

        static void TestIntentFormattingForMars(string intent)
        {
            if (!intent.StartsWith("mars://on-registration-completed/"))
                Assert.Ignore("Intent is not formatted for MARS launch. Is the intent present?");
        }

        [UnityTest]
        public IEnumerator SaveDataInCloud()
        {
            TestIntentFormattingForMars(k_TestIntent);
            yield return WaitForGenesisProfile();
            var saveDataInCloudDone = false;
            m_Module.IdentityProvider = m_MarsIdentity;
            m_Module.CloudSaveAsync(k_Key1, k_Data1, (saveSuccess, responseCode, response) =>
            {
                saveDataInCloudDone = true;
                Assert.True(saveSuccess);
                Assert.AreEqual(200L, responseCode);
            });

            while (!saveDataInCloudDone)
            {
                yield return null;
            }
        }

        [UnityTest]
        public IEnumerator SaveDataInCloudAndLoadItBack()
        {
            TestIntentFormattingForMars(k_TestIntent);
            yield return WaitForGenesisProfile();
            var testComplete = false;
            m_Module.CloudSaveAsync(k_Key2, k_Data2, (saveSuccess, responseCode, response) =>
            {
                Assert.True(saveSuccess);
                Assert.AreEqual(200L, responseCode);
                m_Module.CloudLoadAsync(k_Key2, (bool loadSuccess, long loadResponseCode, string dataLoaded) =>
                {
                    testComplete = true;
                    Assert.True(loadSuccess);
                    Assert.AreEqual(k_Data2, dataLoaded);
                    Assert.AreEqual(200L, loadResponseCode);
                });
            });

            while (!testComplete)
            {
                yield return null;
            }
        }

        [UnityTest]
        public IEnumerator SaveByteDataInCloudAndLoadItBack()
        {
            TestIntentFormattingForMars(k_TestIntent);
            yield return WaitForGenesisProfile();
            var testComplete = false;
            m_Module.IdentityProvider = m_MarsIdentity;
            m_Module.CloudSaveAsync(k_Key3, k_Data3, (saveSuccess, responseCode, response) =>
            {
                Assert.True(saveSuccess);
                Assert.AreEqual(200L, responseCode);
                m_Module.CloudLoadAsync(k_Key3, (bool loadSuccess, long loadResponseCode, byte[] dataLoaded) =>
                {
                    testComplete = true;
                    Assert.True(loadSuccess);
                    Assert.AreEqual(k_Data3, dataLoaded);
                    Assert.AreEqual(200L, loadResponseCode);
                });
            });

            while (!testComplete)
            {
                yield return null;
            }
        }

        [Test]
        public void SetProjectId()
        {
            var previousId = m_Module.GetProjectIdentifier();
            const string testId = "test";
            m_Module.SetProjectIdentifier(testId);
            Assert.AreEqual(testId, m_Module.GetProjectIdentifier());
            m_Module.SetProjectIdentifier(previousId);
        }
    }
}
