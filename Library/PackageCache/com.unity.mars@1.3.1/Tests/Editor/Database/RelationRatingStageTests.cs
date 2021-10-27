using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.Query;
using Unity.MARS.Tests;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    class RelationRatingStageTests : ScriptableObject
    {
#pragma warning disable 649
        [SerializeField]
        GameObject m_SetQueryTestObject;
#pragma warning restore 649

        GameObject m_GameObject;
        TestFloatRelation m_FloatRelation;

        [OneTimeSetUp]
        public void Setup()
        {
            MARSSession.TestMode = true;
            m_GameObject = new GameObject("relation rating stage tests", typeof(ProxyGroup));
            m_FloatRelation = m_GameObject.AddComponent<TestFloatRelation>();
        }

        [SetUp]
        public void SetupBeforeEach()
        {
            // Ensure a consistent random seed for all test runs
            Random.InitState(0);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            MARSSession.TestMode = false;
            DestroyImmediate(m_GameObject);
        }

        [Test]
        public void TryMatchSingleRelation()
        {
            var dataSet = new RelationRatingTestData.SingleMatchUsingSameTrait();
            // both members using the same trait is common - Distance & Elevation have both use "pose"
            var childTraits = new RelationTraitCache.ChildTraits<float>(dataSet.FloatTraitValues);
            var relationRatings = new Dictionary<RelationDataPair, float>();

            // if one of the relation members has no matches, this relation can't match
            Assert.False(RelationRatingTransform.RateMatches(m_FloatRelation, childTraits,
                dataSet.MemberOneRatings, new Dictionary<int, float>(), relationRatings));

            // once that same member has matches, we should be able to match this relation
            Assert.True(RelationRatingTransform.RateMatches(m_FloatRelation, childTraits,
                dataSet.MemberOneRatings, dataSet.MemberTwoRatings, relationRatings));

            VerifyRelationRatings(relationRatings, childTraits);
        }

        [Test]
        public void TryMatchRelationType()
        {
            var dataSet = new RelationRatingTestData.SingleMatchUsingSameTrait();
            var childTraits = new RelationTraitCache.ChildTraits<float>(dataSet.FloatTraitValues);
            var childTraitsList = new List<RelationTraitCache.ChildTraits<float>> {childTraits, childTraits};
            var relationArray = new IRelation<float>[] {m_FloatRelation, m_FloatRelation};
            var relationRatingsList = new List<Dictionary<RelationDataPair, float>>().Fill(2);
            var dataPairs = new [] {new RelationDataPair(0, 1), new RelationDataPair(1, 0)};
            var memberRatings = new []
            {
                // start with one of the members having no matches, to test the failure case
                TestUtils.RandomRatings(), new Dictionary<int, float>()
            };

            // this index resetting is normally done by the function that wraps this function
            RelationRatingTransform.CurrentRelationPairIndex = 0;
            Assert.False(RelationRatingTransform.RateMatches(relationArray, childTraitsList, dataPairs,
                memberRatings, relationRatingsList));

            // give the member with no matches some matches, which should result in the whole type passing
            memberRatings[1] = TestUtils.RandomRatings();
            RelationRatingTransform.CurrentRelationPairIndex = 0;
            Assert.True(RelationRatingTransform.RateMatches(relationArray, childTraitsList, dataPairs,
                memberRatings, relationRatingsList));

            VerifyRelationRatings(relationRatingsList[0], childTraits);
            VerifyRelationRatings(relationRatingsList[1], childTraits);
        }

        [Test]
        public void TryMatchAll()
        {
            var dataSet = new RelationRatingTestData.SingleMatchUsingSameTrait();
            var testObject = m_SetQueryTestObject;
            var relations = TestUtils.GetRelations(testObject);

            var traitCache = new RelationTraitCache(relations);

            Assert.True(traitCache.TryGetType(out List<RelationTraitCache.ChildTraits<float>> floatTraits));
            traitCache.TryGetType(out List<RelationTraitCache.ChildTraits<Pose>> poseTraits);
            floatTraits[0] = new RelationTraitCache.ChildTraits<float>(dataSet.FloatTraitValues);
            // start with one of our trait values being empty of data, so we can test a failure case
            poseTraits[0] = new RelationTraitCache.ChildTraits<Pose>(new Dictionary<int, Pose>());

            var relationRatings = new RelationRatingsData(relations);
            var memberRatingsArray = RandomRatingsArray(relations.children.Count);
            var relationIndexPairs = new RelationDataPair[relations.Count];
            for (var i = 0; i < relations.Count; i++)
            {
                // for the purposes of this test, we just want to see that the lower-level
                // abstraction that works on a per-type basis works for all types,
                // so it doesn't matter if the index pair data is accurate
                relationIndexPairs[i] = new RelationDataPair(i, i == relations.Count -1 ? 0 : i + 1);
            }

            // because our pose relation has no trait data, it should fail and cause the whole result to be false
            Assert.False(RelationRatingTransform.TryMatchAll(relations, traitCache, relationRatings,
                memberRatingsArray, relationIndexPairs));

            // assign usable data to the trait that had no values before, and then re-try - now it should succeed
            poseTraits[0] = new RelationTraitCache.ChildTraits<Pose>(dataSet.PoseTraitValues);

            Assert.True(RelationRatingTransform.TryMatchAll(relations, traitCache, relationRatings,
                memberRatingsArray, relationIndexPairs));

            // The default set test prefab has a float and pose relation on it, so we expect 2
            Assert.AreEqual(2, relationRatings.Count);

            VerifyRelationRatings(relationRatings[0], floatTraits[0]);
            VerifyRelationRatings(relationRatings[1], poseTraits[0]);
        }

        static Dictionary<int, float>[] RandomRatingsArray(int count)
        {
            var array = new Dictionary<int, float>[count];
            for (var i = 0; i < count; i++)
            {
                array[i] = TestUtils.RandomRatings();
            }

            return array;
        }

        static void VerifyRelationRatings<T>(Dictionary<RelationDataPair, float> ratings,
            RelationTraitCache.ChildTraits<T> childTraits, int greaterThanCount = 0)
        {
            Assert.Greater(ratings.Count, greaterThanCount);
            foreach (var kvp in ratings)
            {
                // make sure we don't use the same data for both members
                Assert.AreNotEqual(kvp.Key.Child1, kvp.Key.Child2);
                Assert.True(childTraits.One.ContainsKey(kvp.Key.Child1));
                Assert.True(childTraits.Two.ContainsKey(kvp.Key.Child2));
                Assert.Greater(kvp.Value, 0f);
            }
        }
    }

    class RelationRatingTestData
    {
        public class SingleMatchUsingSameTrait
        {
            public readonly Dictionary<int, float> MemberOneRatings = new Dictionary<int, float>
            {
                {10, 1f}, {8, 0.9f}, {16, 0.8f}, {4, 0.7f}, {6, 0.6f},
                {5, 0.5f}, {12, 0.4f}, {2, 0.3f}, {15, 0.2f}, {3, 0.1f}
            };

            public readonly Dictionary<int, float> MemberTwoRatings = new Dictionary<int, float>
            {
                {2, 1f}, {14, 0.9f}, {11, 0.8f}, {3, 0.7f}, {5, 0.6f},
                {13, 0.5f}, {8, 0.4f}, {7, 0.3f}, {1, 0.2f}, {9, 0.1f}
            };

            public readonly Dictionary<int, float> FloatTraitValues = new Dictionary<int, float>();
            public readonly Dictionary<int, int> IntTraitValues = new Dictionary<int, int>();
            public readonly Dictionary<int, Vector2> Vector2TraitValues = new Dictionary<int, Vector2>();
            public readonly Dictionary<int, Vector3> Vector3TraitValues = new Dictionary<int, Vector3>();
            public readonly Dictionary<int, string> StringTraitValues = new Dictionary<int, string>();
            public readonly Dictionary<int, Pose> PoseTraitValues = new Dictionary<int, Pose>();

            public SingleMatchUsingSameTrait()
            {
                const int count = 20;
                for (var i = 0; i < count; i++)
                {
                    FloatTraitValues.Add(i, Random.Range(0f, 10f));
                    IntTraitValues.Add(i, Random.Range(1, 10));
                    Vector2TraitValues.Add(i, TestUtils.RandomVector2());
                    Vector3TraitValues.Add(i, TestUtils.RandomVector3());
                    StringTraitValues.Add(i, TestUtils.RandomString());
                    PoseTraitValues.Add(i, TestUtils.RandomPose());
                }
            }
        }
    }
}
