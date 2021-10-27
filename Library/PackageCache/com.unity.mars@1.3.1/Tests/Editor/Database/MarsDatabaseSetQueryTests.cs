using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS.Conditions;
using Unity.MARS.Query;
using Unity.MARS.Tests;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Data.Tests
{
    class MarsDatabaseSetQueryTests
    {
        const string k_CommonTrait = "Common";
        const string k_FloatTrait1 = "Float_1";
        const string k_FloatTrait2 = "Float_2";
        const string k_Vector2Trait1 = "Vector2_1";
        const string k_Vector2Trait2 = "Vector2_2";
        const int k_RelationCount = 3;

        public abstract class TestRelation<T> : MonoBehaviour, IRelation<T>
        {
            protected static readonly TraitRequirement[] k_RequiredTraits = null;

            public IMRObject child1 { get; private set; }
            public IMRObject child2 { get; private set; }
            public string child1TraitName { get; private set; }
            public string child2TraitName { get; private set; }

            public void Initialize(IMRObject child1, IMRObject child2, string trait1, string trait2)
            {
                this.child1 = child1;
                this.child2 = child2;
                child1TraitName = trait1;
                child2TraitName = trait2;
            }

            public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

            public abstract float RateDataMatch(ref T child1Data, ref T child2Data);
        }

        public class FloatRelation : TestRelation<float>
        {
            public override float RateDataMatch(ref float child1Data, ref float child2Data)
            {
                return Mathf.Approximately(child1Data + 1f, child2Data) ? 1f : 0f;
            }
        }

        public class Vector2Relation : TestRelation<Vector2>
        {
            public override float RateDataMatch(ref Vector2 child1Data, ref Vector2 child2Data)
            {
                return Mathf.Approximately(child1Data.x + 1f, child2Data.x) ? 1f : 0f;
            }
        }

        public class TrivialRelation : TestRelation<float>
        {
            public override float RateDataMatch(ref float child1Data, ref float child2Data)
            {
                return 1f;
            }
        }

        // We use this internal class for storing the match data that we expect
        class ChildMatchInfo
        {
            public int dataID;
            public Dictionary<string, bool> semanticTagTraits = new Dictionary<string, bool>();
            public Dictionary<string, float> floatTraits = new Dictionary<string, float>();
            public Dictionary<string, Vector2> vector2Traits = new Dictionary<string, Vector2>();
        }

        MARSDatabase m_Db;
        GroupQueryPipeline m_GroupPipeline;
        SetMatchData m_MatchingData;

        MARSTraitDataProvider<float> m_FloatTraitProvider;
        MARSTraitDataProvider<bool> m_TagTraitProvider;
        MARSTraitDataProvider<Vector2> m_Vector2TraitProvider;

        static readonly Dictionary<int, float> k_Ratings = new Dictionary<int, float>();
        static readonly List<Object> k_ToDestroy = new List<Object>();

        static SetQueryArgs s_SetArgs;

        [SetUp]
        public void SetupBeforeEach()
        {
            m_Db = new MARSDatabase();
            var dbModule = (IModule)m_Db;
            dbModule.LoadModule();

            m_GroupPipeline = new GroupQueryPipeline(m_Db);
            m_GroupPipeline.SetupData();
            var pipelineModule = ModuleLoaderCore.instance.GetModule<QueryPipelinesModule>();
            pipelineModule.GroupPipeline = m_GroupPipeline;

            m_MatchingData = new SetMatchData
            {
                dataAssignments = new Dictionary<IMRObject, int>(),
                exclusivities = new Dictionary<IMRObject, Exclusivity>()
            };

            m_Db.GetTraitProvider(out m_FloatTraitProvider);
            m_Db.GetTraitProvider(out m_TagTraitProvider);
            m_Db.GetTraitProvider(out m_Vector2TraitProvider);

            k_Ratings.Clear();
            k_ToDestroy.Clear();
        }

        [TearDown]
        public void AfterEach()
        {
            foreach (var obj in k_ToDestroy)
            {
                Object.DestroyImmediate(obj);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var dbModule = (IModule)m_Db;
            dbModule.UnloadModule();
            var gameObjects = UnityObject.FindObjectsOfType<GameObject>();
            foreach (var go in gameObjects)
            {
                if (go == null)
                    continue;

                if (go.GetComponent<ProxyGroup>() != null
                    || go.GetComponent<Proxy>() != null
                    || go.name == "Set")
                {
                    UnityObject.DestroyImmediate(go);
                }
            }
        }

        [Test]
        public void SetQueryDataDirty_DataNotMarkedAsUsed_ReturnsFalse()
        {
            const int count = 4;
            for (var i = 0; i < count; i++)
            {
                m_Db.MarkSetDataUsedForUpdates(new QueryMatchID(i, 0), new HashSet<int>());
            }

            for (var i = 0; i < count; i++)
            {
                // check queries with previous match, but a new match id
                Assert.False(m_Db.IsSetQueryDataDirty(new QueryMatchID(i, 1)));
                // check queries with no previous matches
                Assert.False(m_Db.IsSetQueryDataDirty(new QueryMatchID(i + 10, 0)));
            }
        }

        [Test]
        public void SetQueryDataDirty_DataMarkedAsUsedAndNoDataChanged_ReturnsFalse()
        {
            const int count = 4;
            var idsSets = new HashSet<int>[count];

            for (var i = 0; i < count; i++)
            {
                idsSets[i] = new HashSet<int>(new [] { i + 10, 1 * 10 });
                m_Db.MarkSetDataUsedForUpdates(new QueryMatchID(i, 0), idsSets[i]);
            }

            for (var i = 0; i < count; i++)
            {
                Assert.False(m_Db.IsSetQueryDataDirty(new QueryMatchID(i, 0)));
            }
        }

        void MarkDataUsed(SetQueryResult result, Dictionary<IMRObject, ChildMatchInfo> childrenExpectedMatchInfo)
        {
            StubRegistration(result.queryMatchId, s_SetArgs, childrenExpectedMatchInfo);
            var usedSet = UsedSetFromChildMatches(childrenExpectedMatchInfo);
            m_Db.MarkSetDataUsedForUpdates(result.queryMatchId, usedSet);
        }

        // convert from the old format to new format for marking data used
        static HashSet<int> UsedSetFromChildMatches(Dictionary<IMRObject, ChildMatchInfo> matchInfos)
        {
            var usedSet = new HashSet<int>();
            foreach (var kvp in matchInfos)
            {
                usedSet.Add(kvp.Value.dataID);
            }

            return usedSet;
        }

        [Test]
        public void SetQueryDataDirty_DataMarkedAsUsedAndDataChanged_ReturnsTrue()
        {
            var childrenExpectedMatchInfo = new Dictionary<IMRObject, ChildMatchInfo>();
            var relations = MakeBaseSet(out var result, childrenExpectedMatchInfo);
            MarkDataUsed(result, childrenExpectedMatchInfo);
            UpdateData(childrenExpectedMatchInfo);
            Assert.True(m_Db.IsSetQueryDataDirty(result.queryMatchId));
        }

        void StubRegistration(QueryMatchID id, SetQueryArgs args,
            Dictionary<IMRObject, ChildMatchInfo> expectedMatches = null)
        {
            m_GroupPipeline.Register(id, args);

            if (expectedMatches == null)
                return;

            var memberCount = 0;
            var setIndex = m_GroupPipeline.Data.MatchIdToIndex[id];
            var memberIndices = m_GroupPipeline.Data.MemberIndices[setIndex];
            // fake like we already acquired the match
            foreach (var child in expectedMatches)
            {
                var memberIndex = memberIndices[memberCount];
                var matchInfo = child.Value;
                m_GroupPipeline.MemberData.BestMatchDataIds[memberIndex] = matchInfo.dataID;
                memberCount++;
            }
        }

        [Test]
        public void TryUpdateSetQueryMatchData_ReturnsUpdatedData()
        {
            var childrenExpectedMatchInfo = new Dictionary<IMRObject, ChildMatchInfo>();
            var relations = MakeBaseSet(out var result, childrenExpectedMatchInfo);
            AddDataThatMatchesQuery(childrenExpectedMatchInfo);
            AssignExpectedMatchInfo(childrenExpectedMatchInfo);

            foreach (var kvp in result.childResults)
            {
                kvp.Value.SetTrait("Float_1", -1f);
            }

            Assert.True(m_Db.TryUpdateSetQueryMatchData(m_MatchingData, relations, result));

            foreach (var kvp in result.childResults)
            {
                Assert.True(kvp.Value.TryGetTrait("Float_1", out float childValue));
                Assert.AreNotEqual(-1, childValue);
            }
        }

        void AssignExpectedMatchInfo(Dictionary<IMRObject, ChildMatchInfo> childrenExpectedMatchInfo)
        {
            m_MatchingData.exclusivities.Clear();
            m_MatchingData.dataAssignments.Clear();
            foreach (var kvp in childrenExpectedMatchInfo)
            {
                m_MatchingData.exclusivities[kvp.Key] = Exclusivity.ReadOnly;
                m_MatchingData.dataAssignments[kvp.Key] = kvp.Value.dataID;
            }
        }

        [Test]
        public void TryUpdateSetQueryMatchData_MatchLost_ReturnsFalse()
        {
            var childrenExpectedMatchInfo = new Dictionary<IMRObject, ChildMatchInfo>();
            var relations = MakeBaseSet(out var result, childrenExpectedMatchInfo);
            MarkDataUsed(result, childrenExpectedMatchInfo);
            AddDataThatMatchesQuery(childrenExpectedMatchInfo);
            AssignExpectedMatchInfo(childrenExpectedMatchInfo);
            InvalidateSet(childrenExpectedMatchInfo.First().Value);
            Assert.False(m_Db.TryUpdateSetQueryMatchData(m_MatchingData, relations, result));
        }

        [Test]
        public void TryUpdateSetQueryMatchData_MatchLostForOrdinaryCondition_ReturnsFalse()
        {
            SetQueryResult result;
            var childrenExpectedMatchInfo = new Dictionary<IMRObject, ChildMatchInfo>();
            var relations = MakeBaseSet(out result, childrenExpectedMatchInfo);
            AddDataThatMatchesQuery(childrenExpectedMatchInfo);
            AssignExpectedMatchInfo(childrenExpectedMatchInfo);

            Assert.True(m_Db.TryUpdateSetQueryMatchData(m_MatchingData, relations, result));

            // Remove a tag trait needed by a child condition.
            var firstMatchInfo = childrenExpectedMatchInfo.First().Value;
            m_TagTraitProvider.RemoveTrait(firstMatchInfo.dataID, firstMatchInfo.semanticTagTraits.First().Key);

            Assert.False(m_Db.TryUpdateSetQueryMatchData(m_MatchingData, relations, result));
        }

        [Test]
        public void TryUpdateSetQueryMatchData_NonRequiredChildLost_ReturnsTrue()
        {
            SetQueryResult result;
            var childrenExpectedMatchInfo = new Dictionary<IMRObject, ChildMatchInfo>();
            var nonRequiredChildren = new List<IMRObject>();
            var conditions = MakeSetWithNonRequiredChildren(out result, childrenExpectedMatchInfo, nonRequiredChildren);
            AddDataThatMatchesQuery(childrenExpectedMatchInfo);
            AssignExpectedMatchInfo(childrenExpectedMatchInfo);

            UpdateData(childrenExpectedMatchInfo);
            LoseNonRequiredChildren(childrenExpectedMatchInfo, nonRequiredChildren);

            Assert.True(m_Db.TryUpdateSetQueryMatchData(m_MatchingData, conditions, result));
            foreach (var kvp in childrenExpectedMatchInfo)
            {
                Assert.False(nonRequiredChildren.Contains(kvp.Key));
                Assert.False(result.nonRequiredChildrenLost.Contains(kvp.Key));
            }

            foreach (var child in nonRequiredChildren)
            {
                Assert.True(result.nonRequiredChildrenLost.Contains(child));
                // There should still be a result for the child so it can be passed to the child's loss handler.
                Assert.Contains(child, result.childResults.Keys);
            }

            // we should still have all query results
            Assert.AreEqual(m_MatchingData.dataAssignments.Count, result.childResults.Count);
        }

        [Test]
        public void CacheRelationTraitReferences()
        {
            var workingIndices = new List<int> { 0, 1 };
            var fulfilledIndices = new List<int>();

            const string presentTrait = "present";
            var go1 = new GameObject("relation trait cache test present", typeof(ProxyGroup));
            go1.AddFloatRelation(presentTrait, presentTrait);
            m_FloatTraitProvider.AddOrUpdateTrait(10, presentTrait, 1);

            // the set with this relation should fail to progress to the next step, because it does not have data
            const string absentTrait = "absent";
            var go2 = new GameObject("relation trait cache test absent", typeof(ProxyGroup));
            go2.AddFloatRelation(absentTrait, absentTrait);

            var relations1 = TestUtils.GetRelations(go1);
            var relations2 = TestUtils.GetRelations(go2);
            var relationsCollection = new [] { relations1, relations2 };
            var traitCacheCollection = new [] { new RelationTraitCache(relations1), new RelationTraitCache(relations2)};

            m_Db.CacheTraitReferences(workingIndices, fulfilledIndices, relationsCollection, ref traitCacheCollection);

            UnityObject.DestroyImmediate(go1);
            UnityObject.DestroyImmediate(go2);

            // because one set found all traits for its relations, we should have one in the filtered indices
            Assert.AreEqual(1, fulfilledIndices.Count);
            Assert.AreEqual(0, fulfilledIndices.First());

            var fulfilledCollection = traitCacheCollection[0];
            Assert.True(fulfilledCollection.Fulfilled);
            Assert.False(traitCacheCollection[1].Fulfilled);

            Assert.True(fulfilledCollection.TryGetType(out List<RelationTraitCache.ChildTraits<float>> floatTraits));
            foreach (var cache in floatTraits)
            {
                Assert.NotNull(cache.One);
                Assert.NotNull(cache.Two);
            }
        }

        static Relations MakeBaseSet(out SetQueryResult result, Dictionary<IMRObject, ChildMatchInfo> childrenExpectedMatchInfo)
        {
            var gameObject = new GameObject("Set");
            gameObject.AddComponent<ProxyGroup>();
            k_ToDestroy.Add(gameObject);

            // Make child MR objects and give them ordinary relations
            var children = new Dictionary<IMRObject, SetChildArgs>();
            for (var i = 0; i < k_RelationCount + 1; ++i)
            {
                var childGameObject = new GameObject("Child" + i);
                k_ToDestroy.Add(childGameObject);
                childGameObject.transform.SetParent(gameObject.transform);
                var conditionsRoot = childGameObject.AddComponent<TestMRObject>();
                var expectedMatchInfo = new ChildMatchInfo();
                childrenExpectedMatchInfo[conditionsRoot] = expectedMatchInfo;

                var hasTraitCondition = childGameObject.AddComponent<SemanticTagCondition>();
                hasTraitCondition.SetTraitName(k_CommonTrait);
                expectedMatchInfo.semanticTagTraits.Add(k_CommonTrait, true);

                var conditions = ProxyConditions.FromGenericIMRObject(conditionsRoot);
                var childArgs = new SetChildArgs(conditions);
                children[conditionsRoot] = childArgs;
            }

            // Make relations and store the expected trait values that will match them
            var childrenList = new List<IMRObject>(children.Keys);
            for (var i = 0; i < k_RelationCount; ++i)
            {
                var child1 = childrenList[i];
                var child2 = childrenList[i + 1];

                var floatRelation = gameObject.AddComponent<FloatRelation>();
                floatRelation.Initialize(child1, child2, k_FloatTrait1, k_FloatTrait2);
                childrenExpectedMatchInfo[child1].floatTraits[floatRelation.child1TraitName] = i;
                childrenExpectedMatchInfo[child2].floatTraits[floatRelation.child2TraitName] = i + 1f;

                var vector2Relation = gameObject.AddComponent<Vector2Relation>();
                vector2Relation.Initialize(child1, child2, k_Vector2Trait1, k_Vector2Trait2);
                childrenExpectedMatchInfo[child1].vector2Traits[vector2Relation.child1TraitName] = new Vector2(i, 0f);
                childrenExpectedMatchInfo[child2].vector2Traits[vector2Relation.child2TraitName] = new Vector2(i + 1f, 0f);
            }

            result = new SetQueryResult(QueryMatchID.Generate(), childrenList);

            var relations = new Relations(gameObject, children);
            s_SetArgs = new SetQueryArgs { relations = relations };
            return relations;
        }

        static Relations MakeSetWithNonRequiredChildren(
            out SetQueryResult result, Dictionary<IMRObject, ChildMatchInfo> childrenExpectedMatchInfo,
            List<IMRObject> nonRequiredChildren, Exclusivity childrenExclusivity = Exclusivity.ReadOnly)
        {
            var relations = MakeBaseSet(out result, childrenExpectedMatchInfo);
            var childrenList = new List<IMRObject>(childrenExpectedMatchInfo.Keys);
            for (var i = 0; i < childrenList.Count; ++i)
            {
                var child = childrenList[i];
                var args = relations.children[child];

                // Half of the children will be non-required.
                if (i < childrenList.Count / 2)
                {
                    nonRequiredChildren.Add(child);
                    args.required = false;
                }

                args.tryBestMatchArgs.exclusivity = childrenExclusivity;
                relations.children[child] = args;
            }

            return relations;
        }

        void UpdateData(Dictionary<IMRObject, ChildMatchInfo> childrenExpectedMatchInfo)
        {
            var childrenList = new List<IMRObject>(childrenExpectedMatchInfo.Keys);
            foreach (var child in childrenList)
            {
                var matchInfo = childrenExpectedMatchInfo[child];
                var dataID = matchInfo.dataID;
                var updateInfo = new ChildMatchInfo
                {
                    dataID = dataID,
                    semanticTagTraits = new Dictionary<string, bool>(matchInfo.semanticTagTraits)
                };

                // Shifting all trait values by the same amount will update the data
                // while maintaining the validity of this data for our test relations.
                foreach (var floatKVP in matchInfo.floatTraits)
                {
                    var name = floatKVP.Key;
                    var value = floatKVP.Value + 1f;
                    updateInfo.floatTraits[name] = value;
                    m_FloatTraitProvider.AddOrUpdateTrait(dataID, name, value);
                }
                foreach (var vector2KVP in matchInfo.vector2Traits)
                {
                    var name = vector2KVP.Key;
                    var value = vector2KVP.Value + Vector2.right;
                    updateInfo.vector2Traits[name] = value;
                    m_Vector2TraitProvider.AddOrUpdateTrait(dataID, name, value);
                }

                childrenExpectedMatchInfo[child] = updateInfo;
            }
        }

        void LoseNonRequiredChildren(Dictionary<IMRObject, ChildMatchInfo> childrenExpectedMatchInfo, List<IMRObject> nonRequiredChildren)
        {
            foreach (var child in nonRequiredChildren)
            {
                InvalidateSet(childrenExpectedMatchInfo[child]);
                childrenExpectedMatchInfo.Remove(child);
            }
        }

        void InvalidateSet(ChildMatchInfo matchInfo)
        {
            // Just one trait not matching should cause a loss.
            var firstFloatTrait = matchInfo.floatTraits.First();
            m_FloatTraitProvider.RemoveTrait(matchInfo.dataID, firstFloatTrait.Key);
        }

        void AddDataThatMatchesQuery(Dictionary<IMRObject, ChildMatchInfo> childrenExpectedMatchInfo)
        {
            foreach (var kvp in childrenExpectedMatchInfo)
            {
                var matchInfo = kvp.Value;
                var dataID = m_Db.synthesizedObjectData.AddData(default);
                matchInfo.dataID = dataID;
                
                foreach (var tagKvp in matchInfo.semanticTagTraits)
                {
                    m_TagTraitProvider.AddOrUpdateTrait(dataID, tagKvp.Key, tagKvp.Value);
                }
                foreach (var floatKVP in matchInfo.floatTraits)
                {
                    m_FloatTraitProvider.AddOrUpdateTrait(dataID, floatKVP.Key, floatKVP.Value);
                }
                foreach (var vector2KVP in matchInfo.vector2Traits)
                {
                    m_Vector2TraitProvider.AddOrUpdateTrait(dataID, vector2KVP.Key, vector2KVP.Value);
                }
            }
        }
    }
}
