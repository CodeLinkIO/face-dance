using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.MARSUtils;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Data.Tests
{
    class MarsDatabaseBestMatchTests
    {
        MARSDatabase m_Db;
        int m_DataID;

        GameObject m_GameObject;            // will be freshly created before every single test start
        TestMRObject m_ConditionsRoot;

        ProxyConditions m_Conditions;
        ConditionRatingsData m_ConditionRatings;
        CachedTraitCollection m_TraitCache;

        MARSTraitDataProvider<float> m_FloatTraits;

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly Dictionary<int, float> k_Ratings = new Dictionary<int, float>();

        void SetupObject(GameObject go)
        {
            var rwo = go.AddComponent<Proxy>();
            m_Conditions = ProxyConditions.FromGenericIMRObject(rwo);
            m_ConditionRatings = new ConditionRatingsData(m_Conditions);
            m_TraitCache = new CachedTraitCollection(m_Conditions);
            m_Db.FindTraitCollections(m_Conditions, m_TraitCache);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            m_Db = new MARSDatabase();
            var dbModule = (IModule)m_Db;
            dbModule.LoadModule();
        }

        [SetUp]
        public void SetupBeforeEach()
        {
            m_GameObject = new GameObject("blank");
            m_ConditionsRoot = m_GameObject.AddComponent<TestMRObject>();
            m_Db.GetTraitProvider(out m_FloatTraits);

            // clear and repopulate the database with a standard set of test data before every test
            m_Db.Clear();
            DatabaseTestData.PopulateDatabase(m_Db, 3);

            SlowTaskModule.instance.ClearTasks();
        }

        [TearDown]
        public void TearDownBeforeEach()
        {
            UnityObject.DestroyImmediate(m_GameObject);
        }

        [Test]
        public void RateConditionMatchesGeneric_AllConditionsMetReturnsTrue_WithFilledRatingSets()
        {
            var floatCondition1 = m_GameObject.AddTestFloatCondition();
            var floatCondition2 = m_GameObject.AddTestFloatCondition(1, 0.2f);

            var conditions = new ICondition<float>[] { floatCondition1, floatCondition2 };
            var ratings = NewRatingsCollection(2);

            var traitValues1 = m_FloatTraits.dictionary[floatCondition1.traitName];
            var traitValues2 = m_FloatTraits.dictionary[floatCondition2.traitName];
            var traitRefs = new List<Dictionary<int, float>> { traitValues1, traitValues2 };

            Assert.True(MatchRatingDataTransform.RateConditionMatches(conditions, traitRefs, ratings));
            Assert.AreEqual(7, ratings[0].Count);
            Assert.AreEqual(6, ratings[1].Count);
        }

        [Test]
        public void RateConditionMatchesGeneric_NoConditionsMet_ReturnsFalse()
        {
            var floatCondition1 = m_GameObject.AddTestFloatCondition(0, 90f);
            // all our test trait values are far below 100, so this should have no matches
            var floatCondition2 = m_GameObject.AddTestFloatCondition(1, 100f);

            var conditions = new ICondition<float>[] { floatCondition1, floatCondition2 };
            var ratings = NewRatingsCollection(2);

            var traitValues1 = m_FloatTraits.dictionary[floatCondition1.traitName];
            var traitValues2 = m_FloatTraits.dictionary[floatCondition2.traitName];
            var traitRefs = new List<Dictionary<int, float>> {traitValues1, traitValues2};
            Assert.False(MatchRatingDataTransform.RateConditionMatches(conditions, traitRefs, ratings));
            Assert.AreEqual(0, ratings[0].Count);
            Assert.AreEqual(0, ratings[1].Count);
        }

        [Test]
        public void RateConditionMatchesGeneric_SomeConditionsMet_ReturnsFalse()
        {
            var floatCondition1 = m_GameObject.AddTestFloatCondition();
            // all our test trait values are far below 100, so this should have no matches
            var floatCondition2 = m_GameObject.AddTestFloatCondition(1, 100f);

            var conditions = new ICondition<float>[] { floatCondition1, floatCondition2 };
            var ratings = NewRatingsCollection(2);

            var traitValues1 = m_FloatTraits.dictionary[floatCondition1.traitName];
            var traitValues2 = m_FloatTraits.dictionary[floatCondition2.traitName];
            var traitRefs = new List<Dictionary<int, float>> {traitValues1, traitValues2};
            Assert.False(MatchRatingDataTransform.RateConditionMatches(conditions, traitRefs, ratings));
            Assert.AreEqual(7, ratings[0].Count);
            Assert.AreEqual(0, ratings[1].Count);
        }

        [Test]
        public void RateConditionMatches_NoConditionsMet_ReturnsFalse_WithEmptyRatingSets()
        {
            // all our test trait values are far below 90 / 100, so both should have no matches
            m_GameObject.AddTestFloatCondition(0, 90f);
            m_GameObject.AddTestVector2Condition(100f);
            m_GameObject.AddSemanticTagCondition("traitNotFound");

            SetupObject(m_GameObject);
            Assert.False(MatchRatingDataTransform.RateConditionMatches(m_Conditions, m_TraitCache, m_ConditionRatings));
            Assert.AreEqual(0, m_ConditionRatings[typeof(float)][0].Count);
            Assert.AreEqual(0, m_ConditionRatings[typeof(Vector2)][0].Count);
            Assert.AreEqual(0, m_ConditionRatings[typeof(bool)][0].Count);
        }

        [Test]
        public void RateConditionMatches_AllConditionsMet_ReturnsTrueWithAllProposals()
        {
            m_GameObject.AddTestFloatCondition();
            m_GameObject.AddTestVector2Condition(0.9f);
            var matchingTagCondition = m_GameObject.AddSemanticTagCondition("tagTrait");

            m_Db.GetTraitProvider(out MARSTraitDataProvider<bool> semanticTagProvider);
            foreach (var kvp in DatabaseTestData.FloatTraits)
            {
                semanticTagProvider.AddOrUpdateTrait(kvp.Key, matchingTagCondition.traitName, true);
            }

            SetupObject(m_GameObject);

            Assert.True(MatchRatingDataTransform.RateConditionMatches(m_Conditions, m_TraitCache, m_ConditionRatings));
            Assert.AreEqual(7, m_ConditionRatings[typeof(float)][0].Count);
            Assert.AreEqual(7, m_ConditionRatings[typeof(Vector2)][0].Count);
            Assert.AreEqual(10, m_ConditionRatings[typeof(bool)][0].Count);
        }

        [Test]
        public void RateConditionMatches_SomeConditionsMet_ReturnsFalse()
        {
            m_GameObject.AddTestFloatCondition();
            m_GameObject.AddTestFloatCondition(1, 100f);        // this one will not match
            m_GameObject.AddTestVector2Condition(0.9f);
            SetupObject(m_GameObject);

            Assert.False(MatchRatingDataTransform.RateConditionMatches(m_Conditions, m_TraitCache, m_ConditionRatings));
            Assert.AreEqual(7, m_ConditionRatings[typeof(float)][0].Count);
            Assert.AreEqual(0, m_ConditionRatings[typeof(float)][1].Count);

            // even though this condition would receive some valid ratings based on our data,
            // because a previous condition had 0 matches, we early-out and don't generate ratings for the rest.
            Assert.AreEqual(0, m_ConditionRatings[typeof(Vector2)][0].Count);
        }

        [Test]
        public void RateConditionMatches_TraitCacheUnfulfilled_ReturnsFalse()
        {
            m_GameObject.AddSemanticTagCondition("tagTrait");
            SetupObject(m_GameObject);

            Assert.False(MatchRatingDataTransform.RateConditionMatches(m_Conditions, m_TraitCache, m_ConditionRatings));
        }

        // This tests the step where we combine individual conditions into a score for the whole query
        // All of the test cases enumerated here show a set of ratings & approximately
        // what we expect them to combine into
        [TestCase(1f, 1f, 1f, 1f, 0.99999f, 1f)]              // all perfect ratings
        [TestCase(1f, 1f, 0.96f, 0.97f, 0.97f, 0.99f)]        // 2 perfect, 2 near-perfect
        [TestCase(0.96f, 0.97f, 0.98f, 0.99f, 0.97f, 0.98f)]  // 4 near-perfect
        [TestCase(0.9f, 0.92f, 0.93f, 0.95f, 0.92f, 0.93f)]   // 4 great
        [TestCase(1f, 0.87f, 0.95f, 0.9f, 0.9f, 0.95f)]       // 1 perfect, 3 great
        [TestCase(1f, 1f, 0.9f, 0.7f, 0.85f, 0.9f)]           // 2 perfect, 1 great, 1 good
        [TestCase(1f, 1f, 0.9f, 0.5f, 0.8f, 0.82f)]           // 2 perfect, 1 great, 1 mediocre
        [TestCase(1f, 1f, 0.9f, 0.25f, 0.68f, 0.7f)]          // 2 perfect, 1 great, 1 bad
        [TestCase(1f, 1f, 0.9f, 0.1f, 0.49f, 0.7f)]           // 2 perfect, 1 great, 1 near-fail
        [TestCase(1f, 0.89f, 0.9f, 0.5f, 0.78f, 0.8f)]        // 1 perfect, 2 great, 1 mediocre
        [TestCase(1f, 0.89f, 0.9f, 0.3f, 0.68f, 0.71f)]       // 1 perfect, 2 great, 1 bad
        [TestCase(1f, 0.89f, 0.9f, 0.1f, 0.45f, 0.55f)]       // 1 perfect, 2 great, 1 near-fail
        [TestCase(0.85f, 0.75f, 0.8f, 0.1f, 0.4f, 0.5f)]      // 3 good  & 1 bad one
        [TestCase(0.6f, 0.5f, 0.55f, 0.1f, 0.3f, 0.4f)]       // 3 ok  & 1 bad one
        [TestCase(0.45f, 0.4f, 0.35f, 0.1f, 0.2f, 0.3f)]      // 3 mediocre  & 1 bad one
        [TestCase(0.45f, 0.4f, 0.35f, 0.3f, 0.3f, 0.4f)]      // 4 mediocre
        [TestCase(0.15f, 0.18f, 0.2f, 0.1f, 0.1f, 0.2f)]      // 4 bad
        [TestCase(0.05f, 0.06f, 0.08f, 0.1f, 0.05f, 0.1f)]    // 4 near-failures
        public void GetRatingForId_ImplementsInversePowerReduction(
            float one, float two, float three, float four,     // condition ratings
            float minBound, float maxBound)                    // expected boundaries
        {
            const int dataId = 3;
            var rwo = m_GameObject.AddComponent<Proxy>();
            m_GameObject.AddTestFloatCondition();
            m_GameObject.AddTestFloatCondition();
            m_GameObject.AddTestVector2Condition();
            m_GameObject.AddSemanticTagCondition();

            var conditions = ProxyConditions.FromGenericIMRObject(rwo);
            var proposal = new ConditionRatingsData(conditions);
            proposal[typeof(float)][0].Add(dataId, one);
            proposal[typeof(float)][1].Add(dataId, two);
            proposal[typeof(Vector2)][0].Add(dataId, three);
            proposal[typeof(bool)][0].Add(dataId, four);
            AssertBetween(proposal.RatingForId(dataId), minBound, maxBound);
        }

        [Test]
        public void ConditionRatingsData_ConstructsCorrectSizeArray_ForConditionCount()
        {
            AddOneOfEachConditionType(m_GameObject);
            m_GameObject.AddTestFloatCondition();
            m_GameObject.AddTestFloatCondition();
            m_GameObject.AddComponent<TestConditions.Pose>();

            var ratings = new ConditionRatingsData(ProxyConditions.FromGenericIMRObject(m_ConditionsRoot));

            Assert.AreEqual(10, ratings.totalConditionCount);
            Assert.AreEqual(3, ratings[typeof(float)].Count);
            Assert.AreEqual(2, ratings[typeof(Pose)].Count);
            Assert.AreEqual(1, ratings[typeof(bool)].Count);
            Assert.AreEqual(1, ratings[typeof(Vector2)].Count);
            Assert.AreEqual(1, ratings[typeof(Vector3)].Count);
            Assert.AreEqual(1, ratings[typeof(int)].Count);
            Assert.AreEqual(1, ratings[typeof(string)].Count);

            ratings[typeof(int)].AssertCollectionsCreated();
            ratings[typeof(float)].AssertCollectionsCreated();
            ratings[typeof(bool)].AssertCollectionsCreated();
            ratings[typeof(Vector2)].AssertCollectionsCreated();
            ratings[typeof(Vector3)].AssertCollectionsCreated();
            ratings[typeof(string)].AssertCollectionsCreated();
            ratings[typeof(Pose)].AssertCollectionsCreated();
        }

        [Test]
        public void TryBestMatchArgs_ConstructingFromPreviousAllocatesCorrectly()
        {
            AddOneOfEachConditionType(m_GameObject);

            var matchArgs = m_GameObject.GetMatchArgs();
            var ratings = matchArgs.ratings;
            var nextMatchArgs = new TryBestMatchArguments(matchArgs);
            var nextRatings = nextMatchArgs.ratings;

            // we re-use the same ratings collections for every single match for a replicator
            Assert.True(ReferenceEquals(ratings, nextRatings));
        }

        static void AddOneOfEachConditionType(GameObject go)
        {
            go.AddComponent<TestConditions.Int>();
            go.AddComponent<TestConditions.Float>();
            go.AddComponent<TestConditions.TestSemanticTagCondition>();
            go.AddComponent<TestConditions.Vector2>();
            go.AddComponent<TestConditions.Vector3>();
            go.AddComponent<TestConditions.String>();
            go.AddComponent<TestConditions.Pose>();
        }

        // allocation of result dictionaries normally happens in the ConditionRatingsData constructor
        static List<Dictionary<int, float>> NewRatingsCollection(int count)
        {
            var ratings = new List<Dictionary<int, float>>(count);
            for (var i = 0; i < count; i++)
            {
                ratings.Add(new Dictionary<int, float>());
            }

            return ratings;
        }

        static void AssertBetween(float value, float exclusiveMin, float inclusiveMax)
        {
            Assert.Greater(value, exclusiveMin);
            Assert.LessOrEqual(value, inclusiveMax);
        }
    }
}
