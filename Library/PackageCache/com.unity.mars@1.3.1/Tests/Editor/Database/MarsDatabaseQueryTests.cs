using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.Attributes;
using Unity.MARS.Conditions;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Data.Tests
{
    class MarsDatabaseQueryTests
    {
        const string k_Trait = "Trait";
        const int k_ConditionsPerType = 10;
        const int k_DataID = 1;            // use a non-zero ID to ensure we don't pass tests with default values

        const string k_ExcludedTrait = "desk";
        const int k_ExcludedDataId = 0;
        const int k_ExclusiveTagDataCount = 4;

        ProxyTraitRequirements m_TraitRequirements = new ProxyTraitRequirements(new List<TraitRequirement>()
        {
            TraitDefinitions.Pose, TraitDefinitions.Bounds2D, TraitDefinitions.Alignment, TraitDefinitions.Floor
        });

        [ExcludeInMARSEditor]
        internal class TestSemanticTagCondition : SemanticTagCondition
        {
            public void Initialize(int traitIndex)
            {
                SetTraitName(TraitNameForIndex(traitIndex));
            }
        }

        [ExcludeInMARSEditor]
        internal abstract class TestCondition<T> : MonoBehaviour, ICondition<T>
        {
            protected static readonly TraitRequirement[] k_RequiredTraits = new TraitRequirement[1];

            public string traitName { get; internal set; }

            public virtual void Initialize(int traitIndex)
            {
                traitName = TraitNameForIndex<T>(traitIndex);
                k_RequiredTraits[0] = new TraitRequirement(traitName, typeof(T));
            }

            public TraitRequirement[] GetRequiredTraits() { return new[] { new TraitRequirement(traitName, typeof(T)) }; }

            public abstract float RateDataMatch(ref T data);
        }

        [ExcludeInMARSEditor]
        internal class IntCondition : TestCondition<int>
        {
            public int greaterThan;

            public override void Initialize(int traitIndex)
            {
                base.Initialize(traitIndex);
                greaterThan = traitIndex;
            }

            public override float RateDataMatch(ref int data)
            {
                return data > greaterThan ? 1f : 0f;
            }
        }

        [ExcludeInMARSEditor]
        internal class FloatCondition : TestCondition<float>
        {
            public float greaterThan;

            public override void Initialize(int traitIndex)
            {
                base.Initialize(traitIndex);
                greaterThan = traitIndex;
            }

            public override float RateDataMatch(ref float data)
            {
                return Mathf.Clamp01(data - greaterThan);
            }
        }

        [ExcludeInMARSEditor]
        internal class Vector2Condition : TestCondition<Vector2>
        {
            public float xGreaterThan;

            public override void Initialize(int traitIndex)
            {
                base.Initialize(traitIndex);
                xGreaterThan = traitIndex;
            }

            public override float RateDataMatch(ref Vector2 data)
            {
                return Mathf.Clamp01(data.x - xGreaterThan);
            }
        }

        [ExcludeInMARSEditor]
        internal class Vector3Condition : TestCondition<Vector3>
        {
            public float xGreaterThan;

            public override void Initialize(int traitIndex)
            {
                base.Initialize(traitIndex);
                xGreaterThan = traitIndex;
            }

            public override float RateDataMatch(ref Vector3 data)
            {
                return Mathf.Clamp01(data.x - xGreaterThan);
            }
        }

        [ExcludeInMARSEditor]
        internal class PoseCondition : TestCondition<Pose>
        {
            public float xGreaterThan;

            public override void Initialize(int traitIndex)
            {
                base.Initialize(traitIndex);
                xGreaterThan = traitIndex;
            }

            public override float RateDataMatch(ref Pose data)
            {
                return Mathf.Clamp01(data.position.x - xGreaterThan);
            }
        }

        MARSDatabase m_Db;
        QueryMatchID m_QueryMatchId;
        int m_DataID;
        GameObject m_ConditionsGameObject;
        GameObject m_CameraGameObject;
        ProxyConditions m_Conditions;
        QueryResult m_QueryResult;

        ProxyTraitRequirements m_EmptyTraitRequirements = new ProxyTraitRequirements(new List<TraitRequirement>());

        readonly HashSet<int> m_AllMatchingIDs = new HashSet<int>();
        readonly Dictionary<int, float> m_Ratings = new Dictionary<int, float>();

        MARSDataProvider<float> m_FloatProvider;
        TestMarsDataUser<float> m_FloatUser;

        MARSTraitDataProvider<float> m_FloatTraitProvider;
        MARSTraitDataProvider<int> m_IntTraitProvider;
        MARSTraitDataProvider<bool> m_TagTraitProvider;
        MARSTraitDataProvider<Vector2> m_Vector2TraitProvider;
        MARSTraitDataProvider<Pose> m_PoseTraitProvider;


        [OneTimeSetUp]
        public void Setup()
        {
            m_ConditionsGameObject = new GameObject("test conditions object");
            var conditionsRoot = m_ConditionsGameObject.AddComponent<TestMRObject>();

            for (var i = 0; i < k_ConditionsPerType; ++i)
            {
                var tagCondition = m_ConditionsGameObject.AddComponent<TestSemanticTagCondition>();
                tagCondition.Initialize(i);

                var floatCondition = m_ConditionsGameObject.AddComponent<FloatCondition>();
                floatCondition.Initialize(i);

                var vector2Condition = m_ConditionsGameObject.AddComponent<Vector2Condition>();
                vector2Condition.Initialize(i);
            }

            m_Conditions = ProxyConditions.FromGenericIMRObject(conditionsRoot);
            m_QueryMatchId = QueryMatchID.Generate();

            m_FloatProvider = new MARSDataProvider<float>();
            m_FloatUser = new TestMarsDataUser<float>();
        }

        [SetUp]
        public void SetupBeforeEach()
        {
            m_Db = new MARSDatabase();
            var dbModule = (IModule)m_Db;
            dbModule.LoadModule();

            m_Db.GetTraitProvider(out m_FloatTraitProvider);
            m_Db.GetTraitProvider(out m_TagTraitProvider);
            m_Db.GetTraitProvider(out m_IntTraitProvider);
            m_Db.GetTraitProvider(out m_Vector2TraitProvider);
            m_Db.GetTraitProvider(out m_PoseTraitProvider);

            var dbOffsetSubscriber = (IUsesCameraOffset) m_Db;
            m_CameraGameObject = new GameObject();
            dbOffsetSubscriber.provider = m_CameraGameObject.AddComponent<CameraOffsetProvider>();

            m_DataID = -1;
            m_QueryResult = new QueryResult(m_QueryMatchId);
            m_AllMatchingIDs.Clear();
            m_Ratings.Clear();
        }

        [TearDown]
        public void TearDownAfterEach()
        {
            Object.DestroyImmediate(m_CameraGameObject);
        }

        [Test]
        public void QueryDataDirty_DataNotMarkedAsUsedAndDataChanged_ReturnsFalse()
        {
            m_Db.GetTraitProvider(out MARSTraitDataProvider<float> floatTraits);
            for (var i = 0; i < k_ConditionsPerType; ++i)
            {
                floatTraits.AddOrUpdateTrait(k_DataID, TraitNameForIndex<float>(i), default(float));
            }
            Assert.True(m_Db.QueryDataDirty(m_QueryMatchId));
        }

        [TestCaseSource(typeof(QueryTestData), "SingleExclusivities")]
        public void QueryDataDirty_DataMarkedAsUsedAndNoDataChanged_ReturnsFalse(Exclusivity exclusivity)
        {
            m_Db.MarkDataUsedForUpdates(m_DataID, m_QueryMatchId, exclusivity);
            Assert.True(m_Db.QueryDataDirty(m_QueryMatchId));
        }

        [TestCaseSource(typeof(QueryTestData), "SingleExclusivities")]
        public void QueryDataDirty_DataMarkedAsUsedAndDataChanged_ReturnsTrue(Exclusivity exclusivity)
        {
            m_Db.MarkDataUsedForUpdates(k_DataID, m_QueryMatchId, exclusivity);
            m_Db.GetTraitProvider(out MARSTraitDataProvider<float> floatTraits);
            for (var i = 0; i < k_ConditionsPerType; ++i)
            {
                floatTraits.AddOrUpdateTrait(k_DataID, TraitNameForIndex<float>(i), default(float));
            }
            Assert.True(m_Db.QueryDataDirty(m_QueryMatchId));
        }


        [Test]
        public void TryUpdateQueryMatchData_ReturnsUpdatedData()
        {
            var updatedFloats = new float[k_ConditionsPerType];
            var updatedVector2s = new Vector2[k_ConditionsPerType];
            var dataID = m_Db.synthesizedObjectData.AddData(default);
            for (var i = 0; i < k_ConditionsPerType; ++i)
            {
                var updatedFloat = MatchingFloatForIndex(i) + 1;
                var updatedVector2 = MatchingVector2ForIndex(i) + Vector2.right;

                updatedFloats[i] = updatedFloat;
                updatedVector2s[i] = updatedVector2;

                m_Db.GetTraitProvider(out MARSTraitDataProvider<float> floatTraits);
                m_FloatTraitProvider.AddOrUpdateTrait(dataID, TraitNameForIndex<float>(i), updatedFloat);

                m_Db.GetTraitProvider(out MARSTraitDataProvider<bool> semanticTagTraits);
                semanticTagTraits.AddOrUpdateTrait(dataID, TraitNameForIndex(i), true);

                m_Db.GetTraitProvider(out MARSTraitDataProvider<Vector2> vector2Traits);
                vector2Traits.AddOrUpdateTrait(dataID, TraitNameForIndex<Vector2>(i), updatedVector2);
            }

            Assert.True(m_Db.TryUpdateQueryMatchData(dataID, m_Conditions, m_EmptyTraitRequirements, m_QueryResult));
            for (var i = 0; i < k_ConditionsPerType; ++i)
            {
                var tagTraitName = TraitNameForIndex(i);
                Assert.True(m_QueryResult.TryGetTrait(tagTraitName, out bool tagValue));

                var floatTraitName = TraitNameForIndex<float>(i);
                Assert.True(m_QueryResult.TryGetTrait(floatTraitName, out float floatValue));
                Assert.AreEqual(updatedFloats[i], floatValue, Mathf.Epsilon);

                var vector2TraitName = TraitNameForIndex<Vector2>(i);
                Assert.True(m_QueryResult.TryGetTrait(vector2TraitName, out Vector2 vector2Value));
                Assert.AreEqual(updatedVector2s[i], vector2Value);
            }
        }

        [Test]
        public void TryUpdateQueryMatchData_MatchLost_ReturnsFalse()
        {
            TestDataThatMatchesQuery();

            m_FloatTraitProvider.AddOrUpdateTrait(k_DataID, TraitNameForIndex<float>(0), default(float));
            Assert.False(m_Db.TryUpdateQueryMatchData(m_DataID, m_Conditions, m_EmptyTraitRequirements, m_QueryResult));
        }

        [Test]
        public void TryUpdateQueryMatchData_TagMatchSetToFalse_ReturnsFalse()
        {
            TestDataThatMatchesQuery();
            m_TagTraitProvider.AddOrUpdateTrait(k_DataID, TraitNameForIndex(0), false);
            Assert.False(m_Db.TryUpdateQueryMatchData(m_DataID, m_Conditions, m_EmptyTraitRequirements, m_QueryResult));
        }

        [Test]
        public void TryUpdateQueryMatchData_TagMatchRemoved_ReturnsFalse()
        {
            TestDataThatMatchesQuery();
            m_TagTraitProvider.RemoveTrait(k_DataID, TraitNameForIndex(0));
            Assert.False(m_Db.TryUpdateQueryMatchData(m_DataID, m_Conditions, m_EmptyTraitRequirements, m_QueryResult));
        }

        [Test]
        public void DataUsedAsReadOnly_DoNotAffectDataOwnership()
        {
            var reservedQueryID = QueryMatchID.Generate();
            var sharedQueryID = QueryMatchID.Generate();
            var readOnlyQueryID = QueryMatchID.Generate();

            Assert.True(m_Db.DataAvailableForUse(k_DataID, reservedQueryID.queryID, Exclusivity.Reserved));
            Assert.True(m_Db.DataAvailableForUse(k_DataID, sharedQueryID.queryID, Exclusivity.Shared));
            Assert.True(m_Db.DataAvailableForUse(k_DataID, readOnlyQueryID.queryID, Exclusivity.ReadOnly));

            m_Db.MarkDataUsedForUpdates(k_DataID, reservedQueryID, Exclusivity.Reserved);
            Assert.False(m_Db.DataAvailableForUse(k_DataID, reservedQueryID.queryID, Exclusivity.Reserved));
            Assert.False(m_Db.DataAvailableForUse(k_DataID, sharedQueryID.queryID, Exclusivity.Shared));
            Assert.True(m_Db.DataAvailableForUse(k_DataID, readOnlyQueryID.queryID, Exclusivity.ReadOnly));

            m_Db.MarkDataUsedForUpdates(k_DataID, readOnlyQueryID, Exclusivity.ReadOnly);
            Assert.False(m_Db.DataAvailableForUse(k_DataID, reservedQueryID.queryID, Exclusivity.Reserved));
            Assert.False(m_Db.DataAvailableForUse(k_DataID, sharedQueryID.queryID, Exclusivity.Shared));
            // since we previously marked this query as using this data, even though it's read only,
            // it should now not be available for use
            Assert.False(m_Db.DataAvailableForUse(k_DataID, readOnlyQueryID.queryID, Exclusivity.ReadOnly));

            m_Db.UnmarkDataUsedForUpdates(readOnlyQueryID);
            Assert.False(m_Db.DataAvailableForUse(k_DataID, reservedQueryID.queryID, Exclusivity.Reserved));
            Assert.False(m_Db.DataAvailableForUse(k_DataID, sharedQueryID.queryID, Exclusivity.Shared));
            // available for use again now that this query isn't using it
            Assert.True(m_Db.DataAvailableForUse(k_DataID, readOnlyQueryID.queryID, Exclusivity.ReadOnly));
        }

        [Test]
        public void DisabledConditionComponentsAreIgnored()
        {
            var go = new GameObject("ignored conditions test");
            var conditionsRoot = go.AddComponent<TestMRObject>();
            var tagCondition = go.AddComponent<SemanticTagCondition>();
            var ignoredFloatCondition = go.AddComponent<FloatCondition>();
            ignoredFloatCondition.enabled = false;
            var ignoredVector2Condition = go.AddComponent<Vector2Condition>();
            ignoredVector2Condition.enabled = false;

            var newConditions = ProxyConditions.FromGenericIMRObject(conditionsRoot);
            Object.DestroyImmediate(go);

            newConditions.TryGetType(out ICondition<float>[] floatConditions);
            Assert.Zero(floatConditions.Length);
            newConditions.TryGetType(out ICondition<Vector2>[] vector2Conditions);
            Assert.Zero(vector2Conditions.Length);
            newConditions.TryGetType(out ISemanticTagCondition[] semanticTagConditions);
            Assert.AreEqual(1, semanticTagConditions.Length);
        }

        [Test]
        public void QueryResult_ResolveValueViaProvider()
        {
            const float kValue = 0.5f;
            var dataId = m_FloatProvider.AddData(kValue);
            var result = new QueryResult();
            result.SetDataId(dataId);

            var returnedValue = result.ResolveValue(m_FloatUser);
            Assert.AreEqual(kValue, returnedValue);
        }

        [Test]
        public void TryFillRequirementsUpdate_ReturnsFalse_WhenAnyRequiredTraitNotPresent()
        {
            const int dataId = 72;
            var result = new QueryResult();
            // none of the required traits are present yet - should fail
            Assert.False(m_Db.TryFillTraitRequirementsUpdate(dataId, m_TraitRequirements, result));
            const int alignmentValue = 1;
            m_IntTraitProvider.AddOrUpdateTrait(dataId, TraitNames.Alignment, alignmentValue);
            m_TagTraitProvider.AddOrUpdateTrait(dataId, TraitNames.Floor, true);
            m_Vector2TraitProvider.AddOrUpdateTrait(dataId, TraitNames.Bounds2D, Vector2.one);
            // all but one of the required traits are present - should still fail
            Assert.False(m_Db.TryFillTraitRequirementsUpdate(dataId, m_TraitRequirements, result));
            m_PoseTraitProvider.AddOrUpdateTrait(dataId, TraitNames.Pose, Pose.identity);
            Assert.True(m_Db.TryFillTraitRequirementsUpdate(dataId, m_TraitRequirements, result));
        }

        [TearDown]
        public void TearDown()
        {
            UnityObject.DestroyImmediate(m_ConditionsGameObject);
        }

        void TestDataThatMatchesQuery()
        {
            for (var i = 0; i < k_ConditionsPerType; ++i)
            {
                m_TagTraitProvider.AddOrUpdateTrait(k_DataID, TraitNameForIndex(i), true);
                m_FloatTraitProvider.AddOrUpdateTrait(k_DataID, TraitNameForIndex<float>(i), MatchingFloatForIndex(i));
                m_Vector2TraitProvider.AddOrUpdateTrait(k_DataID, TraitNameForIndex<Vector2>(i), MatchingVector2ForIndex(i));
            }
        }

        static float MatchingFloatForIndex(int index)
        {
            return index + 1;
        }

        static Vector2 MatchingVector2ForIndex(int index)
        {
            return Vector2.right * (index + 1);
        }

        static string TraitNameForIndex(int index)
        {
            return k_Trait + index;
        }

        static string TraitNameForIndex<T>(int index)
        {
            return typeof(T) + k_Trait + index;
        }

        static SemanticTagCondition AddSemanticTagCondition(GameObject go, string traitName = "", SemanticTagMatchRule rule = SemanticTagMatchRule.Match)
        {
            var condition = go.AddComponent<SemanticTagCondition>();
            condition.SetTraitName(traitName);
            condition.matchRule = rule;
            return condition;
        }

        void AddSemanticTagToRange(int startingDataId, string traitName, bool value, int count)
        {
            for (int i = startingDataId; i < count; i++)
            {
                m_TagTraitProvider.AddOrUpdateTrait(i, traitName, value);
            }
        }

        ProxyConditions SetupExclusiveSemanticTagTest(int count)
        {
            var go = new GameObject("tag matching test");
            var conditionsRoot = go.AddComponent<TestMRObject>();
            AddSemanticTagCondition(go, TraitNames.Plane);
            AddSemanticTagCondition(go, k_ExcludedTrait, SemanticTagMatchRule.Exclude);
            AddSemanticTagToRange(0, TraitNames.Plane, true, count);
            var conditions = ProxyConditions.FromGenericIMRObject(conditionsRoot);
            Object.DestroyImmediate(go);
            return conditions;
        }

        static TryBestMatchArguments MatchArgsForConditions(ProxyConditions conditions, Exclusivity exclusivity)
        {
            return new TryBestMatchArguments(conditions, exclusivity);
        }
    }
}
