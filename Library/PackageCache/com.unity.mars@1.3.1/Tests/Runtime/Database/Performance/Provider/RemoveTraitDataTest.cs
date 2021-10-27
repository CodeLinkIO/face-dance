#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    class RemoveTraitDataTest : DatabasePerformanceTest, IMonoBehaviourTest
    {
        const int k_TotalDataCount = 10000;
        static int s_RemoveIndex;

        static int s_NextId;
        static int[] s_DataIds = new int[k_TotalDataCount];

        MARSTraitDataProvider<float> m_Provider;

        public new bool IsTestFinished
        {
            get
            {
                if (s_RemoveIndex >= k_TotalDataCount)
                {
                    enabled = false;
                    return true;
                }

                return false;
            }
        }

        public void OnEnable()
        {
            ConnectDb();
            m_Db.GetTraitProvider(out m_Provider);
            m_TraitNames = new string[k_TotalDataCount];
            m_StartFrame = Time.frameCount;

            for (int i = 0; i < k_TotalDataCount; i++)
            {
                s_NextId++;
                m_TraitNames[i] = "trait_" + i;
                s_DataIds[i] = s_NextId;

                m_Provider.AddOrUpdateTrait(s_NextId, m_TraitNames[i], Random.Range(-10f, 10f));
            }
        }

        public void Update()
        {
            for (int i = s_RemoveIndex; i < s_RemoveIndex + s_DataCount; i++)
                m_Provider.RemoveTrait(s_DataIds[i], m_TraitNames[i]);

            s_RemoveIndex += s_DataCount;
        }
    }
}
#endif
