using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    class FilterRelationMemberMatchesStageTests
    {
        FilterRelationMemberMatchesTransform m_DataTransform;

        Dictionary<int, float> m_SingleMemberRatings = new Dictionary<int, float>();

        RelationRatingsData m_SingleRelationRatings = new RelationRatingsData
        {
            new Dictionary<RelationDataPair, float>
            {
                {new RelationDataPair(30, 3), 0.9f}, {new RelationDataPair(16, 8), 0.8f},
                {new RelationDataPair(20, 7), 0.7f}, {new RelationDataPair(11, 13), 0.6f},
            }
        };

        RelationRatingsData m_MultiRelationRatings = new RelationRatingsData
        {
            new Dictionary<RelationDataPair, float>
            {
                {new RelationDataPair(30, 3), 0.9f}, {new RelationDataPair(16, 8), 0.8f},
                {new RelationDataPair(20, 7), 0.7f}, {new RelationDataPair(11, 13), 0.6f},
            },
            new Dictionary<RelationDataPair, float>
            {
                {new RelationDataPair(30, 3), 0.9f}, {new RelationDataPair(20, 8), 0.8f},
                {new RelationDataPair(8, 3), 0.9f}, {new RelationDataPair(10, 12), 0.8f},
            }
        };

        Dictionary<int, float>[] m_GlobalMemberRatings;

        RelationMembership[][] m_AllRelationMemberships;

        RelationRatingsData[] m_GlobalRelationRatings;
        int[][] m_AllSetMemberIndices;

        [OneTimeSetUp]
        public void Setup()
        {
            m_DataTransform = new FilterRelationMemberMatchesTransform();
            m_GlobalMemberRatings = new Dictionary<int, float>[2];
            m_GlobalRelationRatings = new[]
            {
                m_MultiRelationRatings, m_MultiRelationRatings
            };

            m_AllSetMemberIndices = new[]
            {
                new[] { 0, 1 },
                new[] { 1, 0 },
            };

            m_AllRelationMemberships = new []
            {
                new [] { new RelationMembership(0, true) },
                new [] { new RelationMembership(1, false) }
            };
        }

        [SetUp]
        public void BeforeEach()
        {
            m_SingleMemberRatings = new Dictionary<int, float>
            {
                {20, 1f}, {24, 0.9f}, {16, 0.8f}, {12, 0.7f}, {30, 0.6f}, {8, 0.5f}, {10, 0.4f}, {2, 0.3f}
            };

            m_GlobalMemberRatings = new []
            {
                m_SingleMemberRatings, new Dictionary<int, float>(m_SingleMemberRatings)
            };
        }

        [Test]
        public void FilterSingleMember()
        {
            var memberships = new []
            {
                // this set member belongs to a single relation, and is the first child of it
                new RelationMembership(0, true)
            };

            // all member IDs found as the first child of the relation should pass the filter
            var firstChildren = m_SingleRelationRatings.SelectMany(d => d.Keys.Select(pair => pair.Child1)).ToList();
            var expectedSet = m_SingleMemberRatings.Where(kvp => firstChildren.Contains(kvp.Key))
                                                   .Select(kvp => kvp.Key).ToArray();

            m_DataTransform.RemoveInvalidMemberMatches(memberships, m_SingleRelationRatings, m_SingleMemberRatings);

            Assert.AreEqual(expectedSet.Length, m_SingleMemberRatings.Count);
            foreach (var expected in expectedSet)
            {
                Assert.True(m_SingleMemberRatings.ContainsKey(expected));
            }
        }

        [Test]
        public void FilterStage()
        {
            var workingIndices = new List<int> {0, 1};

            m_DataTransform.ProcessStage(workingIndices, m_AllSetMemberIndices, m_GlobalRelationRatings, m_AllRelationMemberships,
                ref m_GlobalMemberRatings);

            // The expected results here are calculated manually based on the above test data
            // 20, 16, and 30 should remain for the first member
            var memberOneRatings = m_GlobalMemberRatings[0];
            Assert.AreEqual(3, memberOneRatings.Count);
            Assert.True(memberOneRatings.ContainsKey(20));
            Assert.True(memberOneRatings.ContainsKey(16));
            Assert.True(memberOneRatings.ContainsKey(30));

            // only ids 8 & 12 should match for the second member
            var memberTwoRatings = m_GlobalMemberRatings[1];
            Assert.AreEqual(2, memberTwoRatings.Count);
            Assert.True(memberTwoRatings.ContainsKey(8));
            Assert.True(memberTwoRatings.ContainsKey(12));
        }
    }
}
