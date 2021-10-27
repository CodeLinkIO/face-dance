using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Query;
using UnityEngine;

namespace MARS.Tests.Editor
{
    static class AssertUtils
    {
        internal static void Between(float value, float exclusiveMinimum, float inclusiveMaximum)
        {
            Assert.Greater(value, exclusiveMinimum);
            Assert.LessOrEqual(value, inclusiveMaximum);
        }

        internal static void MatchRatingsValid(HashSet<int> matches, Dictionary<int, float> ratings)
        {
            foreach (var id in matches)
            {
                MatchRatingValid(ratings[id]);
            }
        }

        internal static void MatchRatingValid(float rating)
        {
            Between(rating, MARSDatabase.MinimumPassingConditionRating, 1f);
        }

        // since arrays don't lose Length when you clear them, check that all values get cleared instead
        public static void AllEqual<T>(IEnumerable<T> array, T value = default(T)) where T: struct
        {
            foreach (var t in array)
            {
                Assert.True(t.Equals(value));
            }
        }

        public static void AllNull<T>(IEnumerable<T> array) where T: class
        {
            foreach (var t in array)
            {
                Assert.Null(t);
            }
        }

        internal static void DeepEqual<T>(T[] a, T[] b) where T : IEquatable<T>
        {
            Assert.AreEqual(a.Length, b.Length);
            for (var i = 0; i < a.Length; i++)
            {
                var aValue = a[i];
                var bValue = b[i];
                Assert.True(aValue.Equals(bValue), string.Format(
                    "Expected {0} to be equal to {1} at index {2}", bValue, aValue, i));
            }
        }

        internal static void DeepEqual<T>(T[] a, Dictionary<int, T> b) where T : IEquatable<T>
        {
            Assert.AreEqual(a.Length, b.Count);
            for (var i = 0; i < a.Length; i++)
            {
                var aValue = a[i];
                var bValue = b[i];
                Assert.True(aValue.Equals(bValue), string.Format(
                    "Expected {0} to be equal to {1} at index {2}", bValue, aValue, i));
            }
        }

        internal static void DeepEqual<T>(List<T> a, List<T> b) where T : IEquatable<T>
        {
            Assert.AreEqual(a.Count, b.Count);
            for (var i = 0; i < a.Count; i++)
            {
                var aValue = a[i];
                var bValue = b[i];
                Assert.True(aValue.Equals(bValue), string.Format(
                    "Expected {0} to be equal to {1} at index {2}", bValue, aValue, i));
            }
        }

        internal static void MatchRatingsSorted(Dictionary<int, float> ratings)
        {
            var previous = float.MaxValue;
            foreach (var kvp in ratings)
            {
                Debug.Log(kvp);
                Assert.LessOrEqual(kvp.Value, previous);
                previous = kvp.Value;
            }
        }

        // check if a query stage / data transform has all of its inputs & outputs hooked up
        internal static void DataWired<T1, T2>(DataTransform<T1, T2> dt)
        {
            Assert.NotNull(dt.WorkingIndices);
            Assert.NotNull(dt.Input1);
            Assert.NotNull(dt.Output);
            Assert.NotNull(dt.Process);
        }

        internal static void DataWired<T1, T2, T3>(DataTransform<T1, T2, T3> dt)
        {
            Assert.NotNull(dt.WorkingIndices);
            Assert.NotNull(dt.Input1);
            Assert.NotNull(dt.Input2);
            Assert.NotNull(dt.Output);
            Assert.NotNull(dt.Process);
        }

        internal static void DataWired<T1, T2, T3, T4>(DataTransform<T1, T2, T3, T4> dt)
        {
            Assert.NotNull(dt.WorkingIndices);
            Assert.NotNull(dt.Input1);
            Assert.NotNull(dt.Input2);
            Assert.NotNull(dt.Input3);
            Assert.NotNull(dt.Output);
            Assert.NotNull(dt.Process);
        }

        internal static void DataWired<T1, T2, T3, T4, T5>(DataTransform<T1, T2, T3, T4, T5> dt)
        {
            Assert.NotNull(dt.WorkingIndices);
            Assert.NotNull(dt.Input1);
            Assert.NotNull(dt.Input2);
            Assert.NotNull(dt.Input3);
            Assert.NotNull(dt.Input4);
            Assert.NotNull(dt.Output);
            Assert.NotNull(dt.Process);
        }

        internal static void DataWired<T1, T2, T3, T4, T5, T6>(DataTransform<T1, T2, T3, T4, T5, T6> dt)
        {
            Assert.NotNull(dt.WorkingIndices);
            Assert.NotNull(dt.Input1);
            Assert.NotNull(dt.Input2);
            Assert.NotNull(dt.Input3);
            Assert.NotNull(dt.Input4);
            Assert.NotNull(dt.Input5);
            Assert.NotNull(dt.Output);
            Assert.NotNull(dt.Process);
        }
        
        internal static void DataWired<T1, T2, T3, T4, T5, T6, T7>(DataTransform<T1, T2, T3, T4, T5, T6, T7> dt)
        {
            Assert.NotNull(dt.WorkingIndices);
            Assert.NotNull(dt.Input1);
            Assert.NotNull(dt.Input2);
            Assert.NotNull(dt.Input3);
            Assert.NotNull(dt.Input4);
            Assert.NotNull(dt.Input5);
            Assert.NotNull(dt.Input6);
            Assert.NotNull(dt.Output);
            Assert.NotNull(dt.Process);
        }
    }
}
