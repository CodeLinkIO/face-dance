using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.ContentManager.EditorTests
{
    class ContentManagerTests : ScriptableObject
    {
        // This should be set by default references
        [SerializeField]
#pragma warning disable 649
        ContentPack m_TargetContentPack;
#pragma warning restore 649

        bool m_AddComplete;
        bool m_AddSuccess;
        bool m_RemoveComplete;
        bool m_RemoveSuccess;

        [OneTimeSetUp]
        public void Setup()
        {
            // Ensure the driver exists as setup can happen at odd points of loading
            var unused = ContentManagerDriver.Instance;
            ContentManagerDriver.SubscribeInstallCallback(ProcessAddResult);
            ContentManagerDriver.SubscribeUninstallCallback(ProcessRemoveResult);
            m_AddComplete = false;
            m_AddSuccess = false;
            m_RemoveComplete = false;
            m_RemoveSuccess = false;
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            ContentManagerDriver.UnsubscribeInstallCallback(ProcessAddResult);
            ContentManagerDriver.UnsubscribeInstallCallback(ProcessRemoveResult);
        }

        [UnityTest]
        public IEnumerator TestAddRemoveContent()
        {
            Assert.True(m_TargetContentPack != null, "Test content pack is not set.");

            // Remove the test pack if it already was installed
            ContentManagerDriver.UninstallContent(m_TargetContentPack);

            while (m_RemoveComplete != true)
            {
                yield return null;
            }

            m_RemoveComplete = false;
            m_RemoveSuccess = false;

            // Add the test pack
            ContentManagerDriver.InstallContent(m_TargetContentPack);

            while (m_AddComplete != true)
            {
                yield return null;
            }

            Assert.True(m_AddSuccess);

            ContentManagerDriver.UninstallContent(m_TargetContentPack);
            while (m_RemoveComplete != true)
            {
                yield return null;
            }

            Assert.True(m_RemoveSuccess);

            yield return null;
        }

        void ProcessAddResult(bool status, string message)
        {
            m_AddSuccess = status;
            m_AddComplete = true;
        }

        void ProcessRemoveResult(bool status, string message)
        {
            m_RemoveSuccess = status;
            m_RemoveComplete = true;
        }
    }
}
