using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unity.MARS.Data
{
    public class GenericMARSDataCollection<T>
    {
        readonly Dictionary<int, T> m_Dictionary = new Dictionary<int, T>();
        readonly ReadOnlyDictionary<int, T> m_ReadOnlyWrapper;

        internal Dictionary<int, T> dictionary
        {
            get { return m_Dictionary; }
        }

        public ReadOnlyDictionary<int, T> collection { get { return m_ReadOnlyWrapper; } }

        public static implicit operator Dictionary<int, T>(GenericMARSDataCollection<T> collection)
        {
            return collection.m_Dictionary;
        }

        public GenericMARSDataCollection()
        {
            m_ReadOnlyWrapper = new ReadOnlyDictionary<int, T>(m_Dictionary);
        }

        public int Add(T value)
        {
            var id = MARSDatabase.nextDataID;
            m_Dictionary.Add(id, value);
            return id;
        }

        public bool TryGetValue(int dataId, out T value)
        {
            T tempValue;
            if (m_Dictionary.TryGetValue(dataId, out tempValue))
            {
                value = tempValue;
                return true;
            }

            value = default(T);
            return false;
        }

        public bool TryUpdate(int dataId, T value)
        {
            if (m_Dictionary.ContainsKey(dataId))
            {
                m_Dictionary[dataId] = value;
                return true;
            }

            return false;
        }

        public T this[int dataId]
        {
            get { return m_Dictionary[dataId]; }
        }

        public bool Remove(int dataId)
        {
            return m_Dictionary.Remove(dataId);
        }

        public void Clear()
        {
            m_Dictionary.Clear();
        }

        public Dictionary<int, T>.Enumerator GetEnumerator()
        {
            return m_Dictionary.GetEnumerator();
        }
    }
}
