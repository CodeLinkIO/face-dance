using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.Query;

namespace Unity.MARS.Data.Tests
{
    class PreviousSetMatchesTests
    {
        internal static class Cases
        {
            public static List<int[]> UsedCombos3 = new List<int[]>
            {
                new [] {2, 6, 4}, new [] {1, 5, 3}, new [] {10, 11, 12}, new [] {20, 14, 16}
            };
            public static List<int[]> UsedCombos4 = new List<int[]>
            {
                new [] {2, 6, 4, 5}, new [] {1, 7, 9, 8}, new [] {10, 11, 12, 13}, new [] {20, 14, 16, 15}
            };

            public static IEnumerable Add
            {
                get
                {
                    yield return new TestCaseData(UsedCombos3);
                    yield return new TestCaseData(UsedCombos4);
                }
            }

            public static IEnumerable CheckPreviousUsed
            {
                get
                {
                    var similarButUnused3 = new []
                    {
                        new KeyValuePair<int, float>(2, 1f),
                        new KeyValuePair<int, float>(6, 0.8f),
                        new KeyValuePair<int, float>(5, 0.7f),
                    };
                    yield return new TestCaseData(UsedCombos3, similarButUnused3, false);

                    var similarButUnused4 = new []
                    {
                        new KeyValuePair<int, float>(2, 1f),
                        new KeyValuePair<int, float>(6, 0.8f),
                        new KeyValuePair<int, float>(4, 0.5f),
                        new KeyValuePair<int, float>(3, 0.7f),
                    };
                    yield return new TestCaseData(UsedCombos4, similarButUnused4, false);

                    var previouslyUsed3 = new []
                    {
                        new KeyValuePair<int, float>(2, 1f),
                        new KeyValuePair<int, float>(6, 0.8f),
                        new KeyValuePair<int, float>(4, 0.7f),
                    };
                    yield return new TestCaseData(UsedCombos3, previouslyUsed3, true);

                    var previouslyUsed4 = new []
                    {
                        new KeyValuePair<int, float>(10, 0.8f),
                        new KeyValuePair<int, float>(11, 1f),
                        new KeyValuePair<int, float>(12, 0.5f),
                        new KeyValuePair<int, float>(13, 0.7f),
                    };
                    yield return new TestCaseData(UsedCombos4, previouslyUsed4, true);
                }
            }
        }

        [TestCase(2, 10)]
        [TestCase(4, 8)]
        public void Constructor(int setSize, int capacity)
        {
            var record = new PreviousSetMatches(setSize, capacity);
            Assert.AreEqual(0, record.Count);
            Assert.AreEqual(setSize, record.SetSize);
            Assert.AreEqual(capacity, record.Capacity);
        }

        [TestCaseSource(typeof(Cases), nameof(Cases.Add))]
        public void Add(List<int[]> usedCombos)
        {
            var record = new PreviousSetMatches(usedCombos[0].Length, usedCombos.Count);
            foreach (var combination in usedCombos)
            {
                record.Add(combination);
            }

            Assert.AreEqual(usedCombos.Count, record.Count);
        }

        [TestCaseSource(typeof(Cases), nameof(Cases.CheckPreviousUsed))]
        public void CheckPrevious(List<int[]> usedCombos, KeyValuePair<int, float>[] hypothesis, bool expected)
        {
            var record = new PreviousSetMatches(usedCombos[0].Length, usedCombos.Count);
            foreach (var combination in usedCombos)
            {
                record.Add(combination);
            }

            Assert.AreEqual(expected, record.AssignmentPreviouslyUsed(hypothesis));
        }
    }
}
