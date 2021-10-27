using NUnit.Framework;
using System.Collections.Generic;
using Unity.MARS.Query;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Data.Tests
{
    internal static class MatchConflictTestData
    {
        public static IEnumerable<TestCaseData> All
        {
            get
            {
                yield return new TestCaseData(CaseTwo(Exclusivity.Reserved));
                yield return new TestCaseData(CaseTwo(Exclusivity.Shared));
                yield return new TestCaseData(CaseTwo(Exclusivity.ReadOnly));
                // cases that test the rules for sharing with a single piece of reserved data
                yield return new TestCaseData(CaseThree(Exclusivity.Reserved, 1));
                yield return new TestCaseData(CaseThree(Exclusivity.Shared, 1));
                yield return new TestCaseData(CaseThree(Exclusivity.ReadOnly, 2));

                // test what happens when some shared queries don't have backup options when there is conflict
                yield return new TestCaseData(CaseFour(Exclusivity.Shared));
                // what if there are 2 reserved queries with the same data conflict as the case above ?
                yield return new TestCaseData(CaseFour(Exclusivity.Reserved));
            }
        }

        public static IEnumerable<TestCaseData> CaseOneVariations
        {
            get { yield return new TestCaseData(CaseOne()); }
        }

        public static IEnumerable<TestCaseData> CaseTwoVariations
        {
            get
            {
                yield return new TestCaseData(CaseTwo(Exclusivity.Reserved));
                yield return new TestCaseData(CaseTwo(Exclusivity.Reserved, true));
                yield return new TestCaseData(CaseTwo(Exclusivity.Shared));
                yield return new TestCaseData(CaseTwo(Exclusivity.Shared, true));
                yield return new TestCaseData(CaseTwo(Exclusivity.ReadOnly));
                yield return new TestCaseData(CaseTwo(Exclusivity.ReadOnly, true));
            }
        }

        public static IEnumerable<TestCaseData> SingleReservedConflictCases
        {
            get
            {
                // cases that test the rules for sharing with a single piece of reserved data
                yield return new TestCaseData(CaseThree(Exclusivity.Reserved, 1));
                yield return new TestCaseData(CaseThree(Exclusivity.Shared, 1));
                yield return new TestCaseData(CaseThree(Exclusivity.ReadOnly, 2));
            }
        }

        public static IEnumerable<TestCaseData> CaseFourVariations
        {
            get
            {
                // test what happens when some shared queries don't have backup options when there is conflict
                yield return new TestCaseData(CaseFour(Exclusivity.Shared));
                // what if there are 2 reserved queries with the same data conflict as the case above ?
                yield return new TestCaseData(CaseFour(Exclusivity.Reserved));
            }
        }

        public static IEnumerable<TestCaseData> ReservedPriorityCases
        {
            get
            {
                yield return new TestCaseData(ReservedPriorityPrecedence());
            }
        }

        static MatchConflictTestInput CaseOne()
        {
            int[] expectedAssignments = {1, 1, 2, 1};
            var exclusivities = new []
            {
                Exclusivity.Shared, Exclusivity.Shared, Exclusivity.ReadOnly, Exclusivity.ReadOnly
            };

            var ratings = new []
            {
                // the two shared queries should share their data - id 0 - with the readonly query.
                new Dictionary<int, float> {{1, 1f}, {2, 0.3f}},
                new Dictionary<int, float> {{1, 0.7f}, {3, 0.5f}},
                new Dictionary<int, float> {{2, 0.9f}, {0, 0.4f}},
                new Dictionary<int, float> {{1, 0.8f}, {3, 0.6f}}
            };

            return new MatchConflictTestInput(exclusivities, ratings, expectedAssignments);
        }

        // if all queries requested different data IDs for their best matches,
        // they all get them, regardless of exclusivity rules or priority.
        static MatchConflictTestInput CaseTwo(Exclusivity exclusivity, bool mixedPriority = false)
        {
            int[] expectedAssignments = {2, 1, 4, 3};
            var exclusivities = new []
            {
                exclusivity, exclusivity, exclusivity, exclusivity
            };
            var ratings = new []
            {
                new Dictionary<int, float> {{2, 1f}, {1, 0.3f}},
                new Dictionary<int, float> {{1, 0.9f}, {3, 0.5f}},
                new Dictionary<int, float> {{4, 0.9f}, {2, 0.4f}},
                new Dictionary<int, float> {{3, 0.8f}, {1, 0.6f}}
            };

            // we want to sometimes check that this test case produces the same results regardless of priority
            var priorities = mixedPriority ? new[]
                {
                    MarsEntityPriority.Low, MarsEntityPriority.Normal,
                    MarsEntityPriority.Normal, MarsEntityPriority.High
                }
                : null;

            return new MatchConflictTestInput(exclusivities, ratings, expectedAssignments, priorities);
        }

        // if two queries request one ID, what do we expect for each exclusivity case ?
        static MatchConflictTestInput CaseThree(Exclusivity secondDataExclusivity, int expectedSecondId)
        {
            int[] expectedAssignments = {2, expectedSecondId};
            var exclusivities = new [] { Exclusivity.Reserved, secondDataExclusivity };
            var ratings = new []
            {
                new Dictionary<int, float> {{2, 1f}, {3, 0.8f}},
                // when readonly, this second query should get id 2.  otherwise, id 1.
                new Dictionary<int, float> {{2, 0.9f}, {1, 0.7f}},
            };

            return new MatchConflictTestInput(exclusivities, ratings, expectedAssignments);
        }

        static MatchConflictTestInput CaseFour(Exclusivity conflictingIdExclusivity)
        {
            int[] expectedAssignments = {2, 1, (int)ReservedDataIDs.Invalid, 2, 1};
            var exclusivities = new []
            {
                Exclusivity.Reserved, Exclusivity.Shared, conflictingIdExclusivity,
                Exclusivity.ReadOnly, Exclusivity.ReadOnly
            };
            var ratings = new []
            {
                // because this is the only option for our only reserved query,
                // we let it take precedence over shared data with a better rating
                new Dictionary<int, float> {{2, 0.9f}},
                // this shared data query has another option - id 1 - so it gets to use that this time.
                new Dictionary<int, float> {{2, 1f}, {1, 0.7f}},
                // this shared data query has no other option, and it will not get to match this time.
                new Dictionary<int, float> {{2, 0.8f}},
                // these two are readonly and should match
                new Dictionary<int, float> {{2, 0.7f}},
                new Dictionary<int, float> {{1, 0.8f}},
            };

            return new MatchConflictTestInput(exclusivities, ratings, expectedAssignments);
        }

        static MatchConflictTestInput ReservedPriorityPrecedence()
        {
            int[] expectedAssignments = {2, 1, 3, 4};
            var exclusivities = new []
            {
                Exclusivity.Reserved, Exclusivity.Reserved, Exclusivity.Reserved, Exclusivity.Reserved
            };
            var priorities = new []
            {
                MarsEntityPriority.High, MarsEntityPriority.Normal, MarsEntityPriority.Normal, MarsEntityPriority.Low
            };

            var ratingSet = new Dictionary<int, float> {{2, 1f}, {1, 0.9f}};
            var ratingSet2 = new Dictionary<int, float> {{2, 1f}, {1, 0.8f}, {3, 0.7f}, {4, 0.6f }};
            var ratings = new []
            {
                // high priority
                ratingSet,
                // normal priority
                ratingSet,
                // normal priority, but a lower rating for id 1, so this one should get id 3
                ratingSet2,
                // low priority
                ratingSet2
            };

            return new MatchConflictTestInput(exclusivities, ratings, expectedAssignments, priorities);
        }

        internal static MatchConflictTestInput MultipleConflictMediumCase()
        {
            int[] expectedAssignments = {2, 4, 3, 4, 1, 5, (int)ReservedDataIDs.Invalid, (int)ReservedDataIDs.Invalid, 2, 3};
            var exclusivities = new []
            {
                Exclusivity.Reserved, Exclusivity.Shared, Exclusivity.Reserved, Exclusivity.Shared,
                Exclusivity.Reserved, Exclusivity.Shared, Exclusivity.Reserved, Exclusivity.Shared,
                Exclusivity.ReadOnly, Exclusivity.ReadOnly
            };
            var ratings = new []
            {
                // this reserved query has no other option
                new Dictionary<int, float> {{2, 0.9f}},
                new Dictionary<int, float> {{2, 1f}, {4, 0.8f}},
                // this reserved query has other options, and should claim id 3
                new Dictionary<int, float> {{2, 0.8f}, {3, 0.6f}, {4, 0.5f}},
                new Dictionary<int, float> {{2, 0.8f}, {4, 0.7f}},                // shared
                new Dictionary<int, float> {{1, 0.8f}},                           // reserved
                new Dictionary<int, float> {{5, 0.9f}},                           // shared, no conflict
                // reserved, but should not match since query index 2 should take that match.
                // this tests that the solve goes beyond a single level
                new Dictionary<int, float> {{3, 0.3f}},
                // shared, but will run out of options
                new Dictionary<int, float> {{2, 0.8f}},
                // these last two are read-only
                new Dictionary<int, float> {{2, 0.8f}},
                new Dictionary<int, float> {{3, 0.7f}},
            };

            return new MatchConflictTestInput(exclusivities, ratings, expectedAssignments);
        }
    }
}
