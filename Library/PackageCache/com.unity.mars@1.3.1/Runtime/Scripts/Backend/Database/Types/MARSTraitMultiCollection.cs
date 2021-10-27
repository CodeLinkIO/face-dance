using System.Collections.Generic;
using Unity.MARS.MARSUtils;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Map trait names to the list of their objects and values
    /// </summary>
    /// <typeparam name="T">The trait data type</typeparam>
    public class MARSTraitMultiCollection<T>
    {
        readonly Dictionary<string, Dictionary<int, T>> m_Dictionary = new Dictionary<string, Dictionary<int, T>>();

        internal Dictionary<string, Dictionary<int, T>> dictionary
        {
            get { return m_Dictionary; }
        }

        public void AddOrUpdateTrait(int dataID, string traitName, T value)
        {
#if UNITY_EDITOR
            if (!EditorOnlyDelegates.IsEntitled(true))
                return;
#endif

            Dictionary<int, T> collection;
            if (!m_Dictionary.TryGetValue(traitName, out collection))
            {
                collection = new Dictionary<int, T>();
                m_Dictionary.Add(traitName, collection);
            }

            collection[dataID] = value;
        }

        public bool TryGetTraitById(int dataID, string traitName, out T value)
        {
            Dictionary<int, T> tempCollection;
            if (m_Dictionary.TryGetValue(traitName, out tempCollection))
                return tempCollection.TryGetValue(dataID, out value);

            value = default(T);
            return false;
        }

        public bool RemoveTraitById(int dataID, string traitName)
        {
            Dictionary<int, T> collection;
            return m_Dictionary.TryGetValue(traitName, out collection) && collection.Remove(dataID);
        }

        public bool TryGetValue(string traitName, out Dictionary<int, T> traits)
        {
            Dictionary<int, T> collection;
            if (m_Dictionary.TryGetValue(traitName, out collection))
            {
                traits = collection;
                return true;
            }
            traits = null;
            return false;
        }

        public void Clear()
        {
            m_Dictionary.Clear();
        }
    }
}
