#if UNITY_EDITOR
using NUnit.Framework;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    /// <summary>
    /// Tests that moving a synthesized object properly triggers an update of its representation in the database
    /// </summary>
    [AddComponentMenu("")]
    class UpdateSynthesizedTest : SynthesizedObjectTest
    {
        int m_CurrentFrame;
        GameObject m_QueryObject;
        GameObject m_SynthesizedObjectBase;
        GameObject m_SynthesizedObjectDistance;
        GameObject m_QueryChildBase;
        GameObject m_QueryChildDistance;

        protected override void OnMarsUpdate()
        {
            switch (m_CurrentFrame)
            {
                case 0:
                    // Make the query object
                    m_QueryObject = InstantiateReferenceObject(m_References.Test2QueryObject);
                    m_QueryChildBase = m_QueryObject.transform.Find("Find Object").transform.GetChild(0).gameObject;
                    m_QueryChildDistance = m_QueryObject.transform.Find("Find Object at distance").transform.GetChild(0).gameObject;

                    // Make synthesized object to support the starting object
                    m_SynthesizedObjectBase = InstantiateReferenceObject(m_References.SynthesizedObject);

                    break;
                case 2:
                    // Set is expecting 2 synth objects with a minimum distance, so should be deactivated when there is only 1
                    Assert.False(m_QueryChildBase.activeInHierarchy || m_QueryChildDistance.activeInHierarchy);

                    // Make a second synthesized object
                    m_SynthesizedObjectDistance = InstantiateReferenceObject(m_References.SynthesizedObject);
                    break;
                case 4:
                    // Second query still doesn't match because distance is too close to each other (min distance is 0.5)
                    Assert.False(m_QueryChildBase.activeInHierarchy || m_QueryChildDistance.activeInHierarchy);

                    // Move the object to a proper distance
                    m_SynthesizedObjectDistance.transform.position = new Vector3(1.0f, 0.0f, 0.0f);
                    break;
                case 6:
                    // Both queries now match
                    Assert.True(m_QueryChildBase.activeInHierarchy && m_QueryChildDistance.activeInHierarchy);
                    break;
            }
            ForceUpdateQueries();
            m_CurrentFrame++;
        }

        protected override void OnDisable()
        {
            if (m_QueryObject)
                Destroy(m_QueryObject);

            if (m_SynthesizedObjectBase)
                Destroy(m_SynthesizedObjectBase);

            if (m_SynthesizedObjectDistance)
                Destroy(m_SynthesizedObjectDistance);

            base.OnDisable();
        }
    }
}
#endif
