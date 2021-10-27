using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.MARS.Tests
{
    class EntitlementUtilsTests
    {
        bool m_CurrentEditorMarsIsEntitledDone;

        [UnityTest]
        public IEnumerator CurrentEditorMarsIsEntitled()
        {
            EntitlementUtils.GetMarsEntitlementAsync(Callback);
            while (!m_CurrentEditorMarsIsEntitledDone)
            {
                yield return null;
            }
        }

        void Callback(bool success, EntitlementUtils.MarsSku sku)
        {
            m_CurrentEditorMarsIsEntitledDone = true;
            Assert.True(success);
        }
    }
}
