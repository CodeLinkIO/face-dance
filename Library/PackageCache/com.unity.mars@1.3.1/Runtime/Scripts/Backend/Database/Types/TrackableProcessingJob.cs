using System;
using System.Collections.Generic;

namespace Unity.MARS.Data
{
    /// <summary>
    /// A task that processes spatial data in the database
    /// </summary>
    /// <typeparam name="T">The concrete type implementing IMRTrackable that we're processing</typeparam>
    public class TrackableProcessingJob<T> : ProcessingJob<TrackableMARSDataCollection<T>, List<KeyValuePair<int, T>>>
        where T: IMRTrackable
    {
        Comparison<KeyValuePair<int, T>> m_Comparison;

        /// <summary>
        /// Create a new trackable processing job
        /// </summary>
        /// <param name="source">The source collection of trackable data</param>
        /// <param name="processed">The collection to put processed data into</param>
        /// <param name="comparison">How we determine the sorting this job performs</param>
        public TrackableProcessingJob(TrackableMARSDataCollection<T> source, List<KeyValuePair<int, T>> processed, Comparison<KeyValuePair<int, T>> comparison)
        {
            m_Source = source;
            m_Processed = processed;
            m_Comparison = comparison;
            userCount = 1;
        }

        /// <summary>
        /// Perform this job's processing
        /// </summary>
        public override void Execute()
        {
            m_Source.SortAscending(m_Comparison, m_Processed);
        }
    }
}
