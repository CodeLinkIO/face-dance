using MARS.Tests.Editor;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.MARS.Query;
using Unity.MARS.Tests;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Data.Tests.QueryData
{
    class LowLevelSetRegistrationTests
    {
        ParallelGroupData m_Data;

        [OneTimeSetUp]
        public void Setup()
        {
            const int initialCapacity = 8;
            m_Data = new ParallelGroupData(initialCapacity);
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
        public void Register(SetQueryArgs args)
        {
            var countBefore = m_Data.Count;
            var queryMatchId = RegisterFromSetArgs(args);

            Assert.AreEqual(countBefore + 1, m_Data.Count);

            int index;
            Assert.True(m_Data.MatchIdToIndex.TryGetValue(queryMatchId, out index));
            Assert.True(m_Data.ValidIndices.Contains(index));

            Assert.AreEqual(m_Data.SetQueryArgs[index], args);
            Assert.AreEqual(m_Data.UpdateMatchInterval[index], args.commonQueryData.updateMatchInterval);
            Assert.AreEqual(m_Data.TimeOuts[index], args.commonQueryData.timeOut);
            Assert.AreEqual(m_Data.ReAcquireOnLoss[index], args.commonQueryData.reacquireOnLoss);
            Assert.AreEqual(m_Data.Relations[index], args.relations);
            Assert.AreEqual(m_Data.AcquireHandlers[index], args.onAcquire);
            Assert.AreEqual(m_Data.UpdateHandlers[index], args.onMatchUpdate);
            Assert.AreEqual(m_Data.LossHandlers[index], args.onLoss);
            Assert.AreEqual(m_Data.TimeoutHandlers[index], args.onTimeout);
            // make sure we got all necessary intermediate / result containers from the pools when we registered
            Assert.NotNull(m_Data.CachedTraits[index]);
            Assert.NotNull(m_Data.RelationIndexPairs[index]);
            Assert.NotNull(m_Data.LocalRelationIndexPairs[index]);
            Assert.NotNull(m_Data.RelationRatings[index]);
            Assert.NotNull(m_Data.QueryResults[index]);
        }

        [TestCaseSource(typeof(QueryArgsSource), nameof(QueryArgsSource.RegisterCases))]
        public void Remove(SetQueryArgs args)
        {
            var queryMatchId = RegisterFromSetArgs(args);

            int index;
            Assert.True(m_Data.MatchIdToIndex.TryGetValue(queryMatchId, out index));

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

            Assert.AreEqual(m_Data.SetQueryArgs[index], default(SetQueryArgs));
            Assert.AreEqual(m_Data.UpdateMatchInterval[index], default(float));
            Assert.AreEqual(m_Data.LastUpdateCheckTime[index], default(float));
            Assert.AreEqual(m_Data.TimeOuts[index], default(float));
            Assert.AreEqual(m_Data.ReAcquireOnLoss[index], default(bool));
            Assert.AreEqual(m_Data.OrderWeights[index], default(float));
            Assert.Null(m_Data.Relations[index]);
            Assert.Null(m_Data.AcquireHandlers[index]);
            Assert.Null(m_Data.UpdateHandlers[index]);
            Assert.Null(m_Data.LossHandlers[index]);
            Assert.Null(m_Data.TimeoutHandlers[index]);
            Assert.Null(m_Data.CachedTraits[index]);
            Assert.Null(m_Data.RelationRatings[index]);
            Assert.Null(m_Data.UsedByMatch[index]);
            Assert.Null(m_Data.QueryResults[index]);
            Assert.Null(m_Data.RelationIndexPairs[index]);
            Assert.Null(m_Data.LocalRelationIndexPairs[index]);
            Assert.Null(m_Data.SearchData[index]);
        }

        [Test]
        public void Clear()
        {
            const int queryCount = 3;
            // fill with some stub data so we can verify that clearing works
            for (var i = 0; i < queryCount; i++)
            {
                GameObject go;
                TestUtils.CreateDefaultTestProxy(out go);
                RegisterFromSetArgs(GetTestQueryArgs(go));
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
            // make sure the query data gets cleared by making sure all data is the default for their type
            AssertUtils.AllEqual(m_Data.QueryMatchIds);
            AssertUtils.AllEqual(m_Data.ReAcquireOnLoss);
            AssertUtils.AllEqual(m_Data.TimeOuts);
            AssertUtils.AllEqual(m_Data.UpdateMatchInterval);
            AssertUtils.AllEqual(m_Data.LastUpdateCheckTime);
            AssertUtils.AllNull(m_Data.Relations);
            AssertUtils.AllNull(m_Data.SetQueryArgs);
            AssertUtils.AllNull(m_Data.CachedTraits);
            AssertUtils.AllNull(m_Data.RelationRatings);
            AssertUtils.AllNull(m_Data.UsedByMatch);
            AssertUtils.AllNull(m_Data.SearchData);
            AssertUtils.AllNull(m_Data.QueryResults);
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
            Assert.AreEqual(newCapacity, m_Data.SetQueryArgs.Length);
            Assert.AreEqual(newCapacity, m_Data.ReAcquireOnLoss.Length);
            Assert.AreEqual(newCapacity, m_Data.TimeOuts.Length);
            Assert.AreEqual(newCapacity, m_Data.OrderWeights.Length);
            Assert.AreEqual(newCapacity, m_Data.RelationIndexPairs.Length);
            Assert.AreEqual(newCapacity, m_Data.LocalRelationIndexPairs.Length);
            Assert.AreEqual(newCapacity, m_Data.UpdateMatchInterval.Length);
            Assert.AreEqual(newCapacity, m_Data.LastUpdateCheckTime.Length);
            Assert.AreEqual(newCapacity, m_Data.Relations.Length);
            Assert.AreEqual(newCapacity, m_Data.CachedTraits.Length);
            Assert.AreEqual(newCapacity, m_Data.RelationRatings.Length);
            Assert.AreEqual(newCapacity, m_Data.UsedByMatch.Length);
            Assert.AreEqual(newCapacity, m_Data.SearchData.Length);
            Assert.AreEqual(newCapacity, m_Data.QueryResults.Length);
            Assert.AreEqual(newCapacity, m_Data.AcquireHandlers.Length);
            Assert.AreEqual(newCapacity, m_Data.UpdateHandlers.Length);
            Assert.AreEqual(newCapacity, m_Data.LossHandlers.Length);
            Assert.AreEqual(newCapacity, m_Data.TimeoutHandlers.Length);
        }

        [Test]
        public void ResizeOnInsertIfNecessary()
        {
            var startingCapacity = m_Data.Capacity;
            var queryCount = startingCapacity * 2;
            for (var i = 0; i < queryCount; i++)
            {
                TestUtils.CreateDefaultTestProxy(out GameObject go);
                RegisterFromSetArgs(GetTestQueryArgs(go));
            }

            Assert.AreEqual(startingCapacity * m_Data.ResizeMultiplier, m_Data.Capacity);
        }

        QueryMatchID RegisterFromSetArgs(SetQueryArgs args)
        {
            var matchId = QueryMatchID.Generate();
            // for these low-level tests, we don't need member indices / relation data pairs filled in.
            var memberIndices = new int[args.relations.children.Count];
            var relationDataPairs = new RelationDataPair[args.relations.Count];
            m_Data.Register(matchId, memberIndices, relationDataPairs, args);
            return matchId;
        }

        static SetQueryArgs GetTestQueryArgs(GameObject gameObject)
        {
            return new SetQueryArgs()
            {
                commonQueryData = new CommonQueryData
                {
                    timeOut = 20f,
                    overrideTimeout = false,
                    reacquireOnLoss = true,
                    updateMatchInterval = 0.1f
                },
                relations = new Relations(gameObject, new Dictionary<IMRObject, SetChildArgs>()),
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
                    TestUtils.CreateDefaultTestProxy(out GameObject go);
                    var args = GetTestQueryArgs(go);
                    yield return new TestCaseData(args);
                    UnityObject.DestroyImmediate(go);
                }
            }
        }
    }
}
