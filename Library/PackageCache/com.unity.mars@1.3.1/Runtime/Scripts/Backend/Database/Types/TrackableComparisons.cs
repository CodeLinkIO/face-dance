using System;
using System.Collections.Generic;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Definitions of ways to compare trackable data 
    /// </summary>
    public static class TrackableComparisons<T> where T: IMRTrackable
    {
        public static Comparison<KeyValuePair<int, T>> ComparisonForJobType(ProcessingJobType type)
        {
            switch (type)
            {
                case ProcessingJobType.ElevationSorting:
                    return Elevation;
            }

            return null;
        }

        public static int Elevation(KeyValuePair<int, T> a, KeyValuePair<int, T> b)
        {
            return a.Value.pose.position.y.CompareTo(b.Value.pose.position.y);
        }
    }
}
