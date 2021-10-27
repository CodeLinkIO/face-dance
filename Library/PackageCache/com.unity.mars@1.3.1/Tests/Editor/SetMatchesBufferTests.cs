using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.Query;

namespace Unity.MARS.Tests
{
    class SetMatchesBufferTests
    {
        [TestCase(10, 2)]
        [TestCase(20, 3)]
        [TestCase(30, 5)]
        public void Constructor(int capacity, int setSize)
        {
            var buffer = new SetMatchesBuffer(setSize, capacity);
            Assert.AreEqual(0, buffer.Count);
            Assert.AreEqual(capacity, buffer.Capacity);
            Assert.GreaterOrEqual(buffer.Ratings.Length, capacity);
            Assert.GreaterOrEqual(buffer.DataIds.Length, capacity * setSize);
        }

        [TestCase(2)]
        [TestCase(3)]
        public void Add(int setSize)
        {
            var matchesBuffer = new SetMatchesBuffer(setSize, 10);
            var addBuffer = new KeyValuePair<int, float>[setSize];

            Assert.AreEqual(0, matchesBuffer.Count);

            const int addCount = 2;
            for (var n = 0; n < addCount; n++)
            {
                for (var i = 0; i < addBuffer.Length; i++)
                {
                    addBuffer[i] = new KeyValuePair<int, float>(i + 1, 0.5f);
                }

                matchesBuffer.Add(addBuffer, 1f / n + 1);
            }

            Assert.AreEqual(addCount, matchesBuffer.Count);
            for (var i = 0; i < addCount; i++)
            {
                Assert.AreNotEqual(0f, matchesBuffer.Ratings[i]);
            }
            for (var i = 0; i < addCount * setSize; i++)
            {
                Assert.AreNotEqual(0, matchesBuffer.DataIds[i]);
            }
        }

        [TestCaseSource(typeof(SetMatchesBufferTestData), nameof(SetMatchesBufferTestData.NoTiesCases))]
        public void FindHighestRated_NoTies(List<KeyValuePair<int, float>[]> hypotheses, List<float> ratings,
            KeyValuePair<float, int> expectedRatingToIndex)
        {
            var tieBuffer = new int[4];
            var matchesBuffer = new SetMatchesBuffer(hypotheses[0].Length, 10);
            AddMultipleHypotheses(matchesBuffer, hypotheses, ratings);

            var highestRatingToCount = matchesBuffer.FindHighestRated(ref tieBuffer);
            Assert.AreEqual(expectedRatingToIndex.Key, highestRatingToCount.Key);
            // only one entry in the tie buffer ?
            Assert.AreEqual(expectedRatingToIndex.Value, tieBuffer[0]);
            Assert.AreEqual(tieBuffer[1], default(int));
        }

        [TestCaseSource(typeof(SetMatchesBufferTestData), nameof(SetMatchesBufferTestData.HasTiesCases))]
        public void FindHighestRated_HasTies(List<KeyValuePair<int, float>[]> hypotheses, List<float> ratings,
            KeyValuePair<float, int[]> expectedRatingToIndices)
        {
            var tieBuffer = new int[4];
            var matchesBuffer = new SetMatchesBuffer(hypotheses[0].Length, 10);
            AddMultipleHypotheses(matchesBuffer, hypotheses, ratings);

            var highestRatingToCount = matchesBuffer.FindHighestRated(ref tieBuffer);
            Assert.AreEqual(expectedRatingToIndices.Key, highestRatingToCount.Key);
            // did we get exactly the indices we expected in the tie buffer ?
            Assert.AreEqual(expectedRatingToIndices.Value.Length, highestRatingToCount.Value);
            for (var i = 0; i < expectedRatingToIndices.Value.Length; i++)
            {
                Assert.AreEqual(expectedRatingToIndices.Value[i], tieBuffer[i]);
            }
        }

        [TestCaseSource(typeof(SetMatchesBufferTestData), nameof(SetMatchesBufferTestData.TieChoiceCases))]
        public void ChooseHighestRated_WithFirstBehavior(List<KeyValuePair<int, float>[]> hypotheses, List<float> ratings,
            KeyValuePair<int, float> expectedIndexToRating)
        {
            var tieBuffer = new int[4];
            var matchesBuffer = new SetMatchesBuffer(hypotheses[0].Length, 10);
            AddMultipleHypotheses(matchesBuffer, hypotheses, ratings);

            var chosenIndexToRating = matchesBuffer.ChooseHighestRated(tieBuffer, TieChoiceBehavior.First);
            Assert.AreEqual(expectedIndexToRating, chosenIndexToRating);
        }

        [TestCaseSource(typeof(SetMatchesBufferTestData), nameof(SetMatchesBufferTestData.TieChoiceCases))]
        public void ChooseHighestRated_WithRandomBehavior(List<KeyValuePair<int, float>[]> hypotheses, List<float> ratings,
            KeyValuePair<int, float> expectedIndexToRating)
        {
            var tieBuffer = new int[4];
            var matchesBuffer = new SetMatchesBuffer(hypotheses[0].Length, 10);
            AddMultipleHypotheses(matchesBuffer, hypotheses, ratings);

            var anyNonFirstChoices = false;
            for (var i = 0; i < 10; i++)
            {
                UnityEngine.Random.InitState((i + 1) * 1000);
                var chosenIndexToRating = matchesBuffer.ChooseHighestRated(tieBuffer, TieChoiceBehavior.Random);

                Assert.Contains(chosenIndexToRating.Key, tieBuffer);
                anyNonFirstChoices |= chosenIndexToRating.Key != expectedIndexToRating.Key;
                // all random choices should be sure to have the same value
                Assert.AreEqual(expectedIndexToRating.Value, chosenIndexToRating.Value);
            }

            // make sure that a random choice resulted in something different than a first choice would have
            Assert.True(anyNonFirstChoices);
        }

        static void AddMultipleHypotheses(SetMatchesBuffer buffer,
            List<KeyValuePair<int, float>[]> hypotheses, List<float> ratings)
        {
            for (var i = 0; i < hypotheses.Count; i++)
            {
                buffer.Add(hypotheses[i], ratings[i]);
            }
        }

        static class SetMatchesBufferTestData
        {
            public static KeyValuePair<int, float>[] Hypothesis1 =
            {
                new KeyValuePair<int, float>(1, 0.8f), new KeyValuePair<int, float>(4, 1f),
                new KeyValuePair<int, float>(8, 0.3f), new KeyValuePair<int, float>(10, 0.9f),
            };
            public static KeyValuePair<int, float>[] Hypothesis2 =
            {
                new KeyValuePair<int, float>(2, 0.7f), new KeyValuePair<int, float>(5, 0.9f),
                new KeyValuePair<int, float>(8, 0.3f), new KeyValuePair<int, float>(10, 0.9f),
            };
            public static KeyValuePair<int, float>[] Hypothesis3 =
            {
                new KeyValuePair<int, float>(3, 0.6f), new KeyValuePair<int, float>(6, 0.8f),
                new KeyValuePair<int, float>(8, 0.3f), new KeyValuePair<int, float>(10, 0.9f),
            };
            public static KeyValuePair<int, float>[] Hypothesis4 =
            {
                new KeyValuePair<int, float>(3, 0.6f), new KeyValuePair<int, float>(6, 0.8f),
                new KeyValuePair<int, float>(9, 0.2f), new KeyValuePair<int, float>(11, 0.6f),
            };

            public static List<KeyValuePair<int, float>[]> HypothesisList1 = new List<KeyValuePair<int, float>[]>
            {
                Hypothesis1, Hypothesis2, Hypothesis3
            };
            public static List<KeyValuePair<int, float>[]> HypothesisList2 = new List<KeyValuePair<int, float>[]>
            {
                Hypothesis1, Hypothesis2, Hypothesis3, Hypothesis4
            };

            public static IEnumerable NoTiesCases
            {
                get
                {
                    const float highestRating1 = 0.92f;
                    var ratings1 = new List<float> { 0.9f, highestRating1, 0.85f };
                    var expected1 = new KeyValuePair<float, int>(highestRating1, 1);
                    yield return new TestCaseData(HypothesisList1, ratings1, expected1);

                    const float highestRating2 = 0.95f;
                    var ratings2 = new List<float> { 0.72f, 0.65f, highestRating2, 0.8f };
                    var expected2 = new KeyValuePair<float, int>(highestRating2, 2);
                    yield return new TestCaseData(HypothesisList2, ratings2, expected2);
                }
            }

            public static IEnumerable HasTiesCases
            {
                get
                {
                    const float highestRating1 = 0.92f;
                    var ratings1 = new List<float> { 0.8f, highestRating1, highestRating1, 0.64f };
                    // the expected variables here map highest expected rating to expected tie buffer
                    var expected1 = new KeyValuePair<float, int[]>(highestRating1, new [] {1, 2});
                    yield return new TestCaseData(HypothesisList1, ratings1, expected1);

                    const float highestRating2 = 0.95f;
                    var ratings2 = new List<float> { highestRating2, 0.65f, highestRating2, highestRating2 };
                    var expected2 = new KeyValuePair<float, int[]>(highestRating2, new [] {0, 2, 3});
                    yield return new TestCaseData(HypothesisList2, ratings2, expected2);
                }
            }

            public static IEnumerable TieChoiceCases
            {
                get
                {
                    const float highestRating1 = 0.92f;
                    var ratings1 = new List<float> { 0.8f, highestRating1, highestRating1, 0.64f };
                    var expected1 = new KeyValuePair<int, float>(1, highestRating1);
                    yield return new TestCaseData(HypothesisList1, ratings1, expected1);

                    const float highestRating2 = 0.95f;
                    var ratings2 = new List<float> { highestRating2, 0.65f, highestRating2, highestRating2 };
                    var expected2 = new KeyValuePair<int, float>(0, highestRating2);
                    yield return new TestCaseData(HypothesisList2, ratings2, expected2);
                }
            }
        }
    }
}
