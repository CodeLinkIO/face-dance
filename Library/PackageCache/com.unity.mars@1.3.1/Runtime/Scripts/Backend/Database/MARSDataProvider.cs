using System.Collections.Generic;

namespace Unity.MARS.Data
{
    public class MARSDataProvider<T>
    {
        readonly GenericMARSDataCollection<T> m_Collection = new GenericMARSDataCollection<T>();

#if UNITY_EDITOR
        internal Dictionary<int, T> dictionary
        {
            get { return m_Collection.dictionary; }
        }
#endif

        public int Count { get { return m_Collection.dictionary.Count; }}

        public MARSDataProvider()
        {
            IUsesMARSDataMethods<T>.AddData = AddData;
            IUsesMARSDataMethods<T>.GetIdValue = GetIdValue;
            IUsesMARSDataMethods<T>.UpdateData = UpdateData;
            IUsesMARSDataMethods<T>.RemoveData = RemoveData;
            IUsesMARSDataMethods<T>.GetCollection = GetCollection;
        }

        public void Unload()
        {
            IUsesMARSDataMethods<T>.AddData = null;
            IUsesMARSDataMethods<T>.GetIdValue = null;
            IUsesMARSDataMethods<T>.UpdateData = null;
            IUsesMARSDataMethods<T>.RemoveData = RemoveDataNoop;
            IUsesMARSDataMethods<T>.GetCollection = null;
        }

        public bool RemoveData(int dataId)
        {
            return m_Collection.Remove(dataId);
        }

        public T GetIdValue(int dataId)
        {
            T value;
            if(m_Collection.TryGetValue(dataId, out value))
            {
                return value;
            }

            return default(T);
        }

        public int AddData(T data)
        {
            var dataId = m_Collection.Add(data);
            return dataId;
        }

        public bool UpdateData(int dataId, T value)
        {
            return m_Collection.TryUpdate(dataId, value);
        }

        public void Clear()
        {
            m_Collection.Clear();
        }

        public ICollection<KeyValuePair<int, T>> GetCollection()
        {
            return m_Collection.collection;
        }

        internal bool ValidIdValue(int dataId) {
            return m_Collection.dictionary.ContainsKey(dataId);
        }

        static bool RemoveDataNoop(int dataId) { return false; }
    }
}
