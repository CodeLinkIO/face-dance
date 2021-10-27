using System.Collections.Generic;

namespace Unity.MARS.Data
{
    public class MARSTrackableDataProvider<T> where T: IMRTrackable
    {
        readonly TrackableMARSDataCollection<T> m_Collection = new TrackableMARSDataCollection<T>();

        readonly Dictionary<int, MarsTrackableId> m_DataIdLookup = new Dictionary<int, MarsTrackableId>();

        readonly TrackableProcessingJobContainer<T> m_Jobs;

        bool m_DataDirty;

#if UNITY_EDITOR
        internal Dictionary<MarsTrackableId, KeyValuePair<int, T>> dictionary
        {
            get { return m_Collection.dictionary; }
        }
#endif
        public MARSTrackableDataProvider()
        {
            m_Jobs = new TrackableProcessingJobContainer<T>(m_Collection);

            IUsesMARSTrackableDataMethods<T>.AddOrUpdateData = AddOrUpdateData;
            IUsesMARSTrackableDataMethods<T>.AddDataById = AddData;
            IUsesMARSTrackableDataMethods<T>.RemoveData = RemoveData;
            IUsesMARSTrackableDataMethods<T>.GetIdValue = GetIdValue;
            IUsesMARSTrackableDataMethods<T>.GetCollection = GetCollection;
            IUsesMARSTrackableDataMethods<T>.RegisterProcessingJob = RegisterProcessingJob;
            IUsesMARSTrackableDataMethods<T>.UnregisterProcessingJob = UnregisterProcessingJob;
        }

        internal void Unload()
        {
            IUsesMARSTrackableDataMethods<T>.AddOrUpdateData = AddOrUpdateDataNoop;
            IUsesMARSTrackableDataMethods<T>.AddDataById = AddDataNoop;
            IUsesMARSTrackableDataMethods<T>.RemoveData = RemoveDataNoop;
            IUsesMARSTrackableDataMethods<T>.GetIdValue = null;
            IUsesMARSTrackableDataMethods<T>.GetCollection = null;
            IUsesMARSTrackableDataMethods<T>.RegisterProcessingJob = null;
            IUsesMARSTrackableDataMethods<T>.UnregisterProcessingJob = UnregisterProcessingJobNoop;
        }

        public void GetAllData(IDictionary<int, T> data)
        {
            data.Clear();
            foreach (var entry in m_Collection)
            {
                var kvp = entry.Value;
                data.Add(kvp.Key, kvp.Value);
            }
        }

        internal bool ValidIdValue(int dataId)
        {
            return m_DataIdLookup.ContainsKey(dataId);
        }

        public T GetIdValue(int dataId)
        {
            MarsTrackableId trackableKey;
            if(m_DataIdLookup.TryGetValue(dataId, out trackableKey))
            {
                return m_Collection[trackableKey].Value;
            }

            return default(T);
        }

        public int AddOrUpdateData(T data)
        {
            m_DataDirty = true;
            var dataId = m_Collection.AddOrUpdate(data);
            m_DataIdLookup[dataId] = data.id;
            return dataId;
        }

        public void AddData(int dataID, T data)
        {
            m_DataDirty = true;
            m_DataIdLookup[dataID] = data.id;
            m_Collection.Add(dataID, data);
        }

        public int RemoveData(T data)
        {
            int id = -1;
            KeyValuePair<int, T> kvp;
            if (m_Collection.dictionary.TryGetValue(data.id, out kvp))
            {
                id = kvp.Key;
                m_Collection.Remove(data.id);
                m_DataIdLookup.Remove(id);
                m_DataDirty = true;
            }
            return id;
        }

        public void Clear()
        {
            m_DataIdLookup.Clear();
            m_Collection.Clear();
        }

        public List<KeyValuePair<int, T>> RegisterProcessingJob(ProcessingJobType jobType)
        {
            return m_Jobs.Register(jobType);
        }

        public ICollection<KeyValuePair<int, T>> GetCollection()
        {
            return m_Collection.collection.Values;
        }

        public int UnregisterProcessingJob(ProcessingJobType jobType)
        {
            return m_Jobs.Unregister(jobType);
        }

        static int UnregisterProcessingJobNoop(ProcessingJobType jobType) { return 0; }

        static int RemoveDataNoop(T value) { return 0; }

        static void AddDataNoop(int dataId, T value) { }

        static int AddOrUpdateDataNoop(T value) { return 0; }

        // it should be fine to call this method every frame - if data hasn't updated, nothing will happen
        public void RunProcessingJobs()
        {
            if (m_DataDirty)
            {
                m_Jobs.RunAll();
                m_DataDirty = false;
            }
        }
    }
}
