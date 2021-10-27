using System.Collections.Generic;

namespace Unity.MARS.Data
{
    class TrackableProcessingJobContainer<T> :
        Dictionary<ProcessingJobType, TrackableProcessingJob<T>>
        where T : IMRTrackable
    {
        TrackableMARSDataCollection<T> m_Source;

        public TrackableProcessingJobContainer(TrackableMARSDataCollection<T> source)
        {
            m_Source = source;
        }

        public List<KeyValuePair<int, T>> Register(ProcessingJobType jobType)
        {
            TrackableProcessingJob<T> tempJob;
            if (TryGetValue(jobType, out tempJob))
            {
                tempJob.userCount++;
                return tempJob.processed;
            }

            var list = new List<KeyValuePair<int, T>>();
            var comparison = TrackableComparisons<T>.ComparisonForJobType(jobType);
            Add(jobType, new TrackableProcessingJob<T>(m_Source, list, comparison));
            return list;
        }

        public int Unregister(ProcessingJobType jobType)
        {
            TrackableProcessingJob<T> tempJob;
            if (TryGetValue(jobType, out tempJob))
            {
                tempJob.userCount--;
                if (tempJob.userCount <= 0)
                    Remove(jobType);

                return tempJob.userCount;
            }

            return -1;
        }

        public void RunAll()
        {
            foreach (var kvp in this)
                kvp.Value.Execute();
        }
    }
}
