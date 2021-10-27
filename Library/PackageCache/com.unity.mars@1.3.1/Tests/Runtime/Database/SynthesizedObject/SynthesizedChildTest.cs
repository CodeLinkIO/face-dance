#if UNITY_EDITOR
using NUnit.Framework;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    /// <summary>
    /// Tests that an synthesized object that is a child of a MARS Query exists as the query is acquired and lost
    /// </summary>
    [AddComponentMenu("")]
    class SynthesizedChildTest : SynthesizedObjectTest
    {
        int m_CurrentFrame;
        GameObject m_DependentQuery;
        GameObject m_DependentChild;
        GameObject m_SynthesizedObject;
        GameObject m_BaseQuery;

        protected override void OnMarsUpdate()
        {

            switch (m_CurrentFrame)
            {
                case 0:
                    // Make the second query object and the first synthesized object
                    m_DependentQuery = InstantiateReferenceObject(m_References.Test3QueryObject2);
                    m_DependentChild = m_DependentQuery.transform.GetChild(0).gameObject;

                     m_SynthesizedObject = InstantiateReferenceObject(m_References.SynthesizedObject);
                    break;
                case 2:
                    // Ensure this query doesn't match - it relies on a trait that shows up in a secondary query
                    Assert.False(m_DependentChild.activeInHierarchy);

                    // Make the base query object, that has a -child- synthesized object
                    m_BaseQuery = InstantiateReferenceObject(m_References.Test3QueryObject1);
                    break;
                case 4:
                    // Ensure query *does* match
                    Assert.True(m_DependentChild.activeInHierarchy);
                    break;

                case 6:
                    // Remove the synthesized object
                    Destroy(m_SynthesizedObject);
                    break;
                case 8:
                    // Ensure the query is lost
                    Assert.False(m_DependentChild.activeInHierarchy);
                    break;
            }
            ForceUpdateQueries();
            m_CurrentFrame++;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (m_DependentQuery)
                Destroy(m_DependentQuery);

            if (m_SynthesizedObject)
                Destroy(m_SynthesizedObject);

            if (m_BaseQuery)
                Destroy(m_DependentQuery);
        }
    }
}
#endif
