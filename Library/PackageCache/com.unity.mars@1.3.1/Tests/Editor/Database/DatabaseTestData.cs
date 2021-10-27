using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    // the idea with the members of this class is:  It's helpful to have small, fixed data sets
    // where you can easily calculate manually the number of matches (or lack thereof) that you expect.
    // This helps us have more detailed unit tests that we can easily manually verify the accuracy of.
    // the actual numbers in here are arbitrary, but should STAY THE SAME!  Otherwise tests will break.
    static class DatabaseTestData
    {

        // the test "ratings sets" bypass the step where relations rate data matches,
        // for the purpose of only testing the later stages
        internal static class TinyRatingSet
        {
            // in this rating set, IDs 3 & 7 should match.
            public static Dictionary<int, float> floatRatings = new Dictionary<int, float>
            {
                {3, 0.9f}, {5, 0.7f}, {7, 0.6f}, {8, 1f}
            };
            public static Dictionary<int, float> poseRatings = new Dictionary<int, float>
            {
                {3, 1f}, {7, 0.8f}, {10, 0.5f}
            };

            public static readonly HashSet<int> expectedMatchSet = new HashSet<int> {3, 7};

            internal static ConditionRatingsData Setup()
            {
                var go = new GameObject();
                go.AddComponent<Proxy>();
                go.AddTestFloatCondition();
                go.AddComponent<TestConditions.Pose>();
                var conditions = ProxyConditions.FromGameObject<Proxy>(go);
                var ratings = new ConditionRatingsData(conditions);
                ratings[typeof(float)][0] = floatRatings;
                ratings[typeof(Pose)][0] = poseRatings;
                return ratings;
            }
        }

        const string k_Trait = "Trait";

        internal static readonly Dictionary<int, float> FloatTraits = new Dictionary<int, float>
        {
            { 0, -0.5f },
            { 1, -0.2f },
            { 2, 0f },
            { 3, 0.2f },
            { 4, 0.4f },
            { 5, 0.5f },
            { 6, 0.6f },
            { 7, 0.7f },
            { 8, 0.9f },
            { 9, 1f },
        };

        internal static readonly Dictionary<int, Vector2> EqualMemberVector2Traits = new Dictionary<int, Vector2>
        {
            { 0, new Vector2(0.2f, 0.2f) },
            { 1, new Vector2(0.5f, 0.5f) },
            { 2, new Vector2(0.8f, 0.8f) },
            { 3, new Vector2(1f, 1f) },
            { 4, new Vector2(1.2f, 1.2f) },
            { 5, new Vector2(1.5f, 1.5f) },
            { 6, new Vector2(1.8f, 1.8f) },
            { 7, new Vector2(2f, 2f) },
            { 8, new Vector2(2.5f, 2.5f) },
            { 9, new Vector2(3f, 3f) }
        };

        internal static readonly Dictionary<int, Vector2> UnequalMemberVector2Traits = new Dictionary<int, Vector2>
        {
            { 0, new Vector2(0.2f, 0.5f) },
            { 1, new Vector2(0.6f, 0.3f) },
            { 2, new Vector2(0.4f, 1f) },
            { 3, new Vector2(0.8f, 0.5f) },
            { 4, new Vector2(0.6f, 2f) },
            { 5, new Vector2(1f, 0.7f) },
            { 6, new Vector2(1.2f, 2f) },
            { 7, new Vector2(1.5f, 3) },
            { 8, new Vector2(1.8f, 1f) },
            { 9, new Vector2(2f, 1f) }
        };

        internal static readonly Dictionary<int, float>[] RatingSetOne =
        {
            // the null members are present to test that memberIndices works correctly in stages, by ignoring it
            null,
            new Dictionary<int, float> {{0, 0.9f}, {1, 0.3f}},
            new Dictionary<int, float> {{2, 0.8f}, {3, 0.7f}, {4, 0.6f}, {5, 0.5f}},
            new Dictionary<int, float> {{11, 0.8f}, {12, 0.7f}, {13, 0.6f}, {14, 0.5f}, {15, 0.3f}},
            new Dictionary<int, float> {{7, 1f}, {8, 0.9f}, {9, 0.7f}}
        };

        internal static readonly Dictionary<int, float>[] RatingSetTwo =
        {
            null,
            new Dictionary<int, float> {{0, 0.9f}, {1, 0.7f}, {4, 0.5f}, {5, 0.2f}},
            new Dictionary<int, float> {{2, 0.8f}, {3, 0.7f}, {4, 0.6f}, {5, 0.5f}, {10, 0.4f}, {11, 0.2f}},
            new Dictionary<int, float> {{11, 0.8f}, {12, 0.7f}, {13, 0.6f}, {14, 0.5f}, {15, 0.3f}, {17, 0.2f}},
            new Dictionary<int, float> {{7, 1f}, {8, 0.9f}, {9, 0.7f}, {25, 0.5f}, {30, 0.7f}}
        };

        public static IEnumerable RatingSets
        {
            get
            {
                const int expectedCountOne = 2 * 4 * 5 * 3;
                yield return new TestCaseData(RatingSetOne, expectedCountOne);
                const int expectedCountTwo = 4 * 6 * 6 * 5;
                yield return new TestCaseData(RatingSetTwo, expectedCountTwo);
            }
        }

        internal static void PopulateDatabase(MARSDatabase database, int perTypeTraitCount = 1)
        {
            database.GetTraitProvider(out MARSTraitDataProvider<float> floatTraits);
            database.GetTraitProvider(out MARSTraitDataProvider<Vector2> vector2Traits);

            PopulateTraitProvider(floatTraits, FloatTraits, "", perTypeTraitCount);
            PopulateTraitProvider(vector2Traits, EqualMemberVector2Traits, "", perTypeTraitCount);
            // fake plane sizes
            PopulateTraitProvider(vector2Traits, UnequalMemberVector2Traits, "bounds2d");
        }

        internal static void PopulateTraitProvider<T>(MARSTraitDataProvider<T> provider,
            Dictionary<int, T> data, string traitNamePrefix = "", int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                var traitName = string.IsNullOrEmpty(traitNamePrefix)
                    ? TraitNameForIndex<T>(i)
                    : count == 1 ? traitNamePrefix                    // inserts an exact trait name
                        : string.Format("{0}{1}", traitNamePrefix, i);

                foreach (var kvp in data)
                {
                    provider.AddOrUpdateTrait(kvp.Key, traitName, kvp.Value);
                }
            }
        }

        internal static string TraitNameForIndex<T>(int index)
        {
            // to allow for inserting exact trait names, the first index does not have a '0' suffix
            return index == 0 ? typeof(T) + k_Trait : typeof(T) + k_Trait + index;
        }
    }
}
