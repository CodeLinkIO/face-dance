#if UNITY_EDITOR
using System.Collections;
using NUnit.Framework;
using Unity.MARS.Providers;
using Unity.MARS.Settings;
using UnityEngine;
using UnityEngine.TestTools;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Data.Tests
{
    /*  These tests pass unless an exception happens
     *  Open the profiler & look at how how much time the Update() for a
     *  given MonoBehaviourTest takes to use them for profiling the DB
     */
    class MARSDatabaseProviderPerformance
    {
        [UnityTest]
        public IEnumerator AddData()
        {
            yield return new MonoBehaviourTest<AddDataTest>();
        }

        [UnityTest]
        public IEnumerator UpdateData()
        {
            yield return new MonoBehaviourTest<UpdateDataTest>();
        }

        [UnityTest]
        public IEnumerator RemoveData()
        {
            yield return new MonoBehaviourTest<RemoveDataTest>();
        }

        [UnityTest]
        public IEnumerator AddTraitData()
        {
            yield return new MonoBehaviourTest<AddTraitsTest>();
        }

        [UnityTest]
        public IEnumerator UpdateTraitData()
        {
            yield return new MonoBehaviourTest<UpdateTraitsTest>();
        }

        [UnityTest]
        public IEnumerator RemoveTraitData()
        {
            yield return new MonoBehaviourTest<RemoveTraitDataTest>();
        }
    }

    class MarsDatabaseConditionPerformance
    {
        [SetUp]
        public void BeforeAll()
        {
            // stop the main MARS system while we test parts of the DB
            MARSCore.instance.paused = true;
        }

        [TearDown]
        public void AfterAll()
        {
            MARSCore.instance.paused = false;

            // Clean up the camera offset provider
            var offsetProvider = UnityObject.FindObjectOfType<CameraOffsetProvider>();
            if (offsetProvider)
                UnityObject.DestroyImmediate(offsetProvider.transform.parent.gameObject);
        }

        [UnityTest]
        public IEnumerator ElevationRelationMatchRating()
        {
            yield return new MonoBehaviourTest<ElevationRatingPerformance>();
        }

        [UnityTest]
        public IEnumerator DistanceRelationMatchRating()
        {
            yield return new MonoBehaviourTest<DistanceRatingPerformance>();
        }

        [UnityTest]
        public IEnumerator PlaneSizeConditionMatchRating()
        {
            yield return new MonoBehaviourTest<PlaneSizeRatingPerformance>();
        }

        [UnityTest]
        public IEnumerator AlignmentConditionMatchRating()
        {
            yield return new MonoBehaviourTest<AlignmentConditionRatingPerformance>();
        }

        [UnityTest]
        public IEnumerator TagConditionInclusiveMatchRating()
        {
            yield return new MonoBehaviourTest<TagConditionInclusiveMatchRatingPerformance>();
        }

        [UnityTest]
        public IEnumerator TagConditionExclusiveMatchRating()
        {
            yield return new MonoBehaviourTest<TagConditionExclusiveMatchRatingPerformance>();
        }
    }
}
#endif
