using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unity.MARS.Data
{
    public class TrackableMARSDataCollection<T> where T: IMRTrackable
    {
        readonly Dictionary<MarsTrackableId, KeyValuePair<int, T>> m_Dictionary =
            new Dictionary<MarsTrackableId, KeyValuePair<int, T>>();

        ReadOnlyDictionary<MarsTrackableId, KeyValuePair<int, T>> m_ReadOnlyWrapper;

        public Dictionary<MarsTrackableId, KeyValuePair<int, T>> dictionary
        {
            get { return m_Dictionary; }
        }

        public ReadOnlyDictionary<MarsTrackableId, KeyValuePair<int, T>> collection
        {
            get
            {
                return m_ReadOnlyWrapper ??
                       (m_ReadOnlyWrapper = new ReadOnlyDictionary<MarsTrackableId, KeyValuePair<int, T>>(m_Dictionary));
            }
        }

        public static implicit operator Dictionary<MarsTrackableId, KeyValuePair<int, T>>(TrackableMARSDataCollection<T> collection)
        {
            return collection.m_Dictionary;
        }

        public int AddOrUpdate(T value)
        {
            KeyValuePair<int, T> entry;
            var id = value.id;
            if (m_Dictionary.TryGetValue(id, out entry))
            {
                entry = new KeyValuePair<int, T>(entry.Key, value);
                m_Dictionary[id] = entry;
                return entry.Key;
            }

            var dataId = MARSDatabase.nextDataID;
            entry = new KeyValuePair<int, T>(dataId, value);
            m_Dictionary.Add(value.id, entry);
            return dataId;
        }

        public void Add(int dataId, T value)
        {
            var kvp = new KeyValuePair<int, T>(dataId, value);
            m_Dictionary.Add(value.id, kvp);
        }

        public KeyValuePair<int, T> this[MarsTrackableId key]
        {
            get { return m_Dictionary[key]; }
        }

        public void Remove(MarsTrackableId key)
        {
            m_Dictionary.Remove(key);
        }

        public void Clear()
        {
            m_Dictionary.Clear();
        }

        public void SortAscending(Comparison<KeyValuePair<int, T>> comparison, List<KeyValuePair<int, T>> sorted)
        {
            sorted.Clear();
            foreach (var kvp in m_Dictionary)
            {
                sorted.Add(kvp.Value);
            }

            sorted.Sort(comparison);
        }

        public Dictionary<MarsTrackableId, KeyValuePair<int, T>>.Enumerator GetEnumerator()
        {
            return m_Dictionary.GetEnumerator();
        }
    }
}
