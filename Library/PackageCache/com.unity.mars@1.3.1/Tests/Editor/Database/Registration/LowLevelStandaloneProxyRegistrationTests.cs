using NUnit.Framework;
using System;
using System.Collections;
using MARS.Tests.Editor;
using Unity.MARS.Query;
using Unity.MARS.Tests;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Data.Tests.QueryData
{
    class LowLevelStandaloneProxyRegistrationTests
    {
        ParallelQueryData m_Data;

        [OneTimeSetUp]
        public void Setup()
        {
            const int initialCapacity = 8;
            m_Data = new ParallelQueryData(initialCapacity);
        }

        [TearDown]
        public void TearDown()
        {
            TestUtils.DestroyDefaultProxyObjects();
        }

        [SetUp]
        public void SetupBeforeEach()
        {
            m_Data.Clear();
        }

        [TestCaseSource(typeof(QueryArgsSource), nameof(QueryArgsSource.RegisterCases))]
        public void Register(QueryArgs args)
        {
            var queryMatchId = QueryMatchID.Generate();

            var countBefore = m_Data.Count;
            m_Data.Register(queryMatchId, args);

            // make sure we increment the global counter
            Assert.AreEqual(countBefore + 1, m_Data.Count);

            int index;
            Assert.True(m_Data.MatchIdToIndex.TryGetValue(queryMatchId, out index));
            Assert.True(m_Data.ValidIndices.Contains(index));

            Assert.AreEqual(m_Data.QueryArgs[index], args);
            Assert.AreEqual(m_Data.Exclusivities[index], args.exclusivity);
            Assert.AreEqual(m_Data.UpdateMatchInterval[index], args.commonQueryData.updateMatchInterval);
            Assert.AreEqual(m_Data.TimeOuts[index], args.commonQueryData.timeOut);
            Assert.AreEqual(m_Data.ReAcquireOnLoss[index], args.commonQueryData.reacquireOnLoss);
            Assert.AreEqual(m_Data.Conditions[index], args.conditions);
            Assert.AreEqual(m_Data.TraitRequirements[index], args.traitRequirements);
            Assert.AreEqual(m_Data.AcquireHandlers[index], args.onAcquire);
            Assert.AreEqual(m_Data.UpdateHandlers[index], args.onMatchUpdate);
            Assert.AreEqual(m_Data.LossHandlers[index], args.onLoss);
            Assert.AreEqual(m_Data.TimeoutHandlers[index], args.onTimeout);
            // make sure we got all necessary intermediate / result containers from the pools when we registered
            Assert.NotNull(m_Data.CachedTraits[index]);
            Assert.NotNull(m_Data.ConditionRatings[index]);
            Assert.NotNull(m_Data.ConditionMatchSets[index]);
            Assert.NotNull(m_Data.ReducedConditionRatings[index]);
            Assert.NotNull(m_Data.QueryResults[index]);
            // make sure we initialize the best match id to an invalid id
            Assert.AreEqual(m_Data.BestMatchDataIds[index], (int) ReservedDataIDs.Invalid);
        }

        // register 3, free 1, register another and see if the last one uses the freed
        [Test]
        public void RegisteringUsesFreedIndexIfAvailable()
        {
            GameObject tempGameObject;
            var proxy = TestUtils.CreateDefaultTestProxy(out tempGameObject);

            var args = GetTestQueryArgs(proxy);
            m_Data.Register(QueryMatchID.Generate(), args);
            var queryMatchToFree = QueryMatchID.Generate();
            m_Data.Register(queryMatchToFree, args);

            int indexToFree;
            Assert.True(m_Data.MatchIdToIndex.TryGetValue(queryMatchToFree, out indexToFree));
            m_Data.Register(QueryMatchID.Generate(), args);
            m_Data.Remove(queryMatchToFree);

            // register another query, which should occupy the index previously used by the removed one
            Assert.AreEqual(1, m_Data.FreedIndices.Count);
            Assert.AreEqual(2, m_Data.Count);
            var queryMatchToReplace = QueryMatchID.Generate();
            m_Data.Register(queryMatchToReplace, args);
            Assert.AreEqual(3, m_Data.Count);
            Assert.AreEqual(0, m_Data.FreedIndices.Count);

            int indexOfReplacement;
            Assert.True(m_Data.MatchIdToIndex.TryGetValue(queryMatchToReplace, out indexOfReplacement));
            Assert.AreEqual(indexToFree, indexOfReplacement);
        }

        [TestCaseSource(typeof(QueryArgsSource), nameof(QueryArgsSource.RegisterCases))]
        public void Remove(QueryArgs args)
        {
            var queryMatchId = QueryMatchID.Generate();
            m_Data.Register(queryMatchId, args);

            int index;
            Assert.True(m_Data.MatchIdToIndex.TryGetValue(queryMatchId, out index));
            // pretend this query got a match, so we can confirm that this number is removed
            m_Data.BestMatchDataIds[index] = 2;

            var countBefore = m_Data.Count;
            var freedIndicesCountBefore = m_Data.FreedIndices.Count;
            Assert.True(m_Data.Remove(queryMatchId));

            // make sure we decrement the global counter
            Assert.AreEqual(countBefore - 1, m_Data.Count);
            // make sure we added the index we free to the queue
            Assert.AreEqual(freedIndicesCountBefore + 1, m_Data.FreedIndices.Count);
            Assert.True(m_Data.FreedIndices.Contains(index));

            Assert.False(m_Data.ValidIndices.Contains(index));
            Assert.False(m_Data.MatchIdToIndex.ContainsKey(queryMatchId));

            Assert.AreEqual(m_Data.Exclusivities[index], default(Exclusivity));
            Assert.AreEqual(m_Data.UpdateMatchInterval[index], default(float));
            Assert.AreEqual(m_Data.TimeOuts[index], default(float));
            Assert.AreEqual(m_Data.ReAcquireOnLoss[index], default(bool));
            Assert.Null(m_Data.QueryArgs[index]);
            Assert.Null(m_Data.Conditions[index]);
            Assert.Null(m_Data.TraitRequirements[index]);
            Assert.Null(m_Data.CachedTraits[index]);
            Assert.Null(m_Data.ConditionRatings[index]);
            Assert.Null(m_Data.ConditionMatchSets[index]);
            Assert.Null(m_Data.ReducedConditionRatings[index]);
            Assert.Null(m_Data.QueryResults[index]);
            Assert.AreEqual((int) ReservedDataIDs.Invalid, m_Data.BestMatchDataIds[index]);
            Assert.Null(m_Data.AcquireHandlers[index]);
            Assert.Null(m_Data.UpdateHandlers[index]);
            Assert.Null(m_Data.LossHandlers[index]);
            Assert.Null(m_Data.TimeoutHandlers[index]);
        }

        [Test]
        public void Clear()
        {
            const int queryCount = 3;
            // fill with some stub data so we can verify that clearing works
            for (var i = 0; i < queryCount; i++)
            {
                var proxy = TestUtils.CreateDefaultTestProxy(out GameObject go, i);
                m_Data.Register(QueryMatchID.Generate(), GetTestQueryArgs(proxy));
                UnityObject.DestroyImmediate(go);
            }

            Assert.AreEqual(queryCount, m_Data.Count);

            m_Data.Clear();

            Assert.Zero(m_Data.Count);
            Assert.Zero(m_Data.MatchIdToIndex.Count);
            // make sure all the working index sets get cleared
            Assert.Zero(m_Data.AcquiringIndices.Count);
            Assert.Zero(m_Data.FilteredAcquiringIndices.Count);
            Assert.Zero(m_Data.PotentialMatchAcquiringIndices.Count);
            Assert.Zero(m_Data.DefiniteMatchAcquireIndices.Count);
            Assert.Zero(m_Data.UpdatingIndices.Count);
            // make sure all the actual query data gets cleared
            AssertUtils.AllEqual(m_Data.QueryMatchIds);
            AssertUtils.AllNull(m_Data.QueryArgs);
            AssertUtils.AllNull(m_Data.Conditions);
            AssertUtils.AllNull(m_Data.TraitRequirements);
            AssertUtils.AllNull(m_Data.CachedTraits);
            AssertUtils.AllNull(m_Data.ConditionRatings);
            AssertUtils.AllNull(m_Data.ConditionMatchSets);
            AssertUtils.AllNull(m_Data.ReducedConditionRatings);
            AssertUtils.AllEqual(m_Data.BestMatchDataIds);
            AssertUtils.AllNull(m_Data.QueryResults);
            AssertUtils.AllEqual(m_Data.ReAcquireOnLoss);
            AssertUtils.AllEqual(m_Data.TimeOuts);
            AssertUtils.AllEqual(m_Data.UpdateMatchInterval);
            AssertUtils.AllNull(m_Data.AcquireHandlers);
            AssertUtils.AllNull(m_Data.UpdateHandlers);
            AssertUtils.AllNull(m_Data.LossHandlers);
            AssertUtils.AllNull(m_Data.TimeoutHandlers);
        }

        [Test]
        public void ResizeEffectsAllArrays()
        {
            const int capacityIncrease = 4;
            var newCapacity = m_Data.Capacity + capacityIncrease;

            m_Data.Resize(newCapacity);

            Assert.AreEqual(newCapacity, m_Data.QueryMatchIds.Length);
            Assert.AreEqual(newCapacity, m_Data.QueryArgs.Length);
            Assert.AreEqual(newCapacity, m_Data.Exclusivities.Length);
            Assert.AreEqual(newCapacity, m_Data.UpdateMatchInterval.Length);
            Assert.AreEqual(newCapacity, m_Data.TimeOuts.Length);
            Assert.AreEqual(newCapacity, m_Data.ReAcquireOnLoss.Length);
            Assert.AreEqual(newCapacity, m_Data.Conditions.Length);
            Assert.AreEqual(newCapacity, m_Data.TraitRequirements.Length);
            Assert.AreEqual(newCapacity, m_Data.CachedTraits.Length);
            Assert.AreEqual(newCapacity, m_Data.ConditionRatings.Length);
            Assert.AreEqual(newCapacity, m_Data.ConditionMatchSets.Length);
            Assert.AreEqual(newCapacity, m_Data.ReducedConditionRatings.Length);
            Assert.AreEqual(newCapacity, m_Data.BestMatchDataIds.Length);
            Assert.AreEqual(newCapacity, m_Data.QueryResults.Length);
            Assert.AreEqual(newCapacity, m_Data.AcquireHandlers.Length);
            Assert.AreEqual(newCapacity, m_Data.UpdateHandlers.Length);
            Assert.AreEqual(newCapacity, m_Data.LossHandlers.Length);
            Assert.AreEqual(newCapacity, m_Data.TimeoutHandlers.Length);
        }

        static QueryArgs GetTestQueryArgs(Proxy proxy, Exclusivity exclusivity = Exclusivity.ReadOnly)
        {
            return new QueryArgs
            {
                commonQueryData = new CommonQueryData
                {
                    timeOut = 20f,
                    overrideTimeout = false,
                    reacquireOnLoss = true,
                    updateMatchInterval = 0.1f
                },
                conditions = new ProxyConditions(proxy),
                exclusivity = exclusivity,
                onAcquire = (result) => { },
                onMatchUpdate = (result) => { },
                onLoss = (result) => { },
                onTimeout = (queryArgs) => { }
            };
        }

        static class QueryArgsSource
        {
            public static IEnumerable RegisterCases
            {
                get
                {
                    var go = new GameObject("query registration test", typeof(Proxy));
                    go.AddTestFloatCondition();
                    go.AddTestVector2Condition();
                    var realWorldObject = go.GetComponent<Proxy>();

                    foreach (Exclusivity exclusivity in Enum.GetValues(typeof(Exclusivity)))
                    {
                        var args = GetTestQueryArgs(realWorldObject, exclusivity);
                        yield return new TestCaseData(args);
                    }

                    UnityObject.DestroyImmediate(go);
                }
            }
        }
    }
}
