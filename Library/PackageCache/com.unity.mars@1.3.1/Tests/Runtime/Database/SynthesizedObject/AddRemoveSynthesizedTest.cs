#if UNITY_EDITOR
using NUnit.Framework;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    /// <summary>
    /// Tests that adding and removing a synthesized object properly adds and removes entries from the database
    /// </summary>
    [AddComponentMenu("")]
    class AddRemoveSynthesizedTest : SynthesizedObjectTest
    {
        int m_CurrentFrame;
        GameObject m_QueryObject;
        GameObject m_SynthesizedObject;
        GameObject m_QueryChild;

        protected override void OnMarsUpdate()
        {
            switch (m_CurrentFrame)
            {
                case 0:
                    // Make the query object
                    m_QueryObject = InstantiateReferenceObject(m_References.Test1QueryObject);
                    m_QueryChild = m_QueryObject.transform.GetChild(0).gameObject;
                    break;
                case 2:
                    // Ensure query doesn't match - we do this by checking if its child is active or not
                    Assert.False(m_QueryChild.activeInHierarchy);

                    // Make synthesized object to now supply the needed data
                    m_SynthesizedObject = InstantiateReferenceObject(m_References.SynthesizedObject);
                    break;
                case 4:
                    // Ensure query *does* match
                    Assert.True(m_QueryChild.activeInHierarchy);
                    break;

                case 6:
                    // Remove the synthesized object
                    Destroy(m_SynthesizedObject);
                    break;
                case 8:
                    // Ensure the query is lost
                    Assert.False(m_QueryChild.activeInHierarchy);
                    break;
            }
            ForceUpdateQueries();
            m_CurrentFrame++;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (m_QueryObject)
                Destroy(m_QueryObject);

            if (m_SynthesizedObject)
                Destroy(m_SynthesizedObject);
        }
    }
}
#endif
