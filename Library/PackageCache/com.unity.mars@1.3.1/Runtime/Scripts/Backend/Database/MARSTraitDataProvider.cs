using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.Data
{
    public abstract class MARSTraitDataProvider
    {
        const int k_DefaultFilterBufferCapacity = 256;
        protected static int[] s_IdsToFilter = new int[k_DefaultFilterBufferCapacity];

        protected static int s_FilteredIdCount;
    }

    public class MARSTraitDataProvider<T> : MARSTraitDataProvider
    {

        readonly List<BufferedCommandType> m_CommandList = new List<BufferedCommandType>();
        readonly Queue<RemoveTraitCommand> m_RemoveCommandBuffer = new Queue<RemoveTraitCommand>();
        readonly Queue<AddOrUpdateTraitCommand<T>> m_UpdateCommandBuffer = new Queue<AddOrUpdateTraitCommand<T>>();

        //  the database provides this action
        Action<int> setDataDirtyIfNeeded;

        MARSTraitMultiCollection<T> m_Traits = new MARSTraitMultiCollection<T>();
        readonly MARSDatabase m_Database;

        internal Dictionary<string, Dictionary<int, T>> dictionary
        {
            get { return m_Traits.dictionary; }
        }

        public MARSTraitDataProvider(Action<int> setDataDirty, MARSDatabase database)
        {
            m_Database = database;

            if (setDataDirty == null)
            {
                Debug.LogError("setDataDirty action must be provided to trait data providers");
                setDataDirtyIfNeeded = id => { };           // to avoid null ref errors
                return;
            }

            setDataDirtyIfNeeded = setDataDirty;

            // setup our static FI for trait providers - this replaces ConnectSubscriber
            IProvidesTraitsMethods<T>.AddOrUpdateTrait = AddOrUpdateTrait;
            IRequiresTraitsMethods<T>.TryGetTraitValue = TryGetTraitValue;
            IRequiresTraitsMethods<T>.TryGetAllTraitsWithSemanticTag = TryGetAllTraitsWithSemanticTag;
            IProvidesTraitsMethods<T>.RemoveTrait = RemoveTrait;
            IRequiresTraitsMethods<T>.ForEachContextIdWithTrait = ForEachContextIdWithTrait;
            
            // setup the internal representation of this trait type
            MarsDataType.Register<T>();
        }

        internal void Unload()
        {
            IProvidesTraitsMethods<T>.AddOrUpdateTrait = AddOrUpdateTraitNoop;
            IRequiresTraitsMethods<T>.TryGetTraitValue = null;
            IRequiresTraitsMethods<T>.TryGetAllTraitsWithSemanticTag = null;
            IProvidesTraitsMethods<T>.RemoveTrait = RemoveTraitNoop;

            // remove this type's solver-internal representation
            MarsDataType.Remove<T>();
        }

        /// <summary>
        /// While the query cycle is running, we want to prevent trait values from changing.
        /// But we don't want clients to have to care.  So, all Add / Update / Remove calls
        /// get queued until the cycle is done.
        /// </summary>
        internal void StartUpdateBuffering()
        {
            m_CommandList.Clear();
            m_UpdateCommandBuffer.Clear();
            m_RemoveCommandBuffer.Clear();
            IProvidesTraitsMethods<T>.AddOrUpdateTrait = AddOrUpdateTraitBuffered;
            IProvidesTraitsMethods<T>.RemoveTrait = RemoveTraitBuffered;
        }

        /// <summary>
        /// Once the query cycle is done, flush any add / update / remove commands.
        /// </summary>
        internal void StopUpdateBuffering()
        {
            // we follow the order in the command list to ensure that
            // the order of updates and removes is exactly the same as unbuffered
            foreach (var entryType in m_CommandList)
            {
                switch (entryType)
                {
                    case BufferedCommandType.AddOrUpdate:
                        var update = m_UpdateCommandBuffer.Dequeue();
                        m_Traits.AddOrUpdateTrait(update.dataId, update.traitName, update.value);
                        break;
                    case BufferedCommandType.Remove:
                        var remove = m_RemoveCommandBuffer.Dequeue();
                        m_Traits.RemoveTraitById(remove.dataId, remove.traitName);
                        break;
                }
            }

            m_CommandList.Clear();

            // restore normal trait updating functionality
            IProvidesTraitsMethods<T>.AddOrUpdateTrait = AddOrUpdateTrait;
            IProvidesTraitsMethods<T>.RemoveTrait = RemoveTrait;
        }

        public void AddOrUpdateTrait(int dataID, string traitName, T value)
        {
            m_Traits.AddOrUpdateTrait(dataID, traitName, value);
            setDataDirtyIfNeeded(dataID);
        }

        void AddOrUpdateTraitBuffered(int dataId, string traitName, T value)
        {
            m_UpdateCommandBuffer.Enqueue(new AddOrUpdateTraitCommand<T>()
            {
                dataId = dataId,
                traitName = traitName,
                value = value
            });

            m_CommandList.Add(BufferedCommandType.AddOrUpdate);
        }

        static void AddOrUpdateTraitNoop(int dataId, string traitName, T value) { }

        public bool RemoveTrait(int dataID, string traitName)
        {
            setDataDirtyIfNeeded(dataID);
            return m_Traits.RemoveTraitById(dataID, traitName);
        }

        public bool RemoveTraitNoop(int dataID, string traitName)
        {
            return false;
        }

        bool RemoveTraitBuffered(int dataId, string traitName)
        {
            if (!m_Traits.dictionary.ContainsKey(traitName))
                return false;

            m_RemoveCommandBuffer.Enqueue(new RemoveTraitCommand()
            {
                dataId = dataId,
                traitName = traitName
            });

            m_CommandList.Add(BufferedCommandType.Remove);
            return true;
        }

        public bool TryGetAllTraitValues(string traitName, out Dictionary<int, T> traits)
        {
            return m_Traits.TryGetValue(traitName, out traits);
        }

        public bool TryGetTraitValue(int dataID, string traitName, out T value)
        {
            return m_Traits.TryGetTraitById(dataID, traitName, out value);
        }

        public bool TryGetAllTraitsWithSemanticTag(string traitName, string tag, out Dictionary<int, T> traits)
        {
            traits = new Dictionary<int, T>();

            m_Database.GetTraitProvider(out MARSTraitDataProvider<bool> semanticTagProvider);
            if (semanticTagProvider.TryGetAllTraitValues(tag, out var tags))
            {
                foreach (var kvp in tags)
                {
                    var id = kvp.Key;
                    if (m_Traits.TryGetTraitById(id, traitName, out var trait))
                    {
                        traits.Add(id, trait);
                    }
                }
            }

            return traits.Count > 0;
        }

        internal void ForEachContextIdWithTrait(string traitName, Action<int> action)
        {
            if (!m_Traits.TryGetValue(traitName, out var traitValues))
                return;

            foreach (var id in traitValues.Keys)
            {
                action(id);
            }
        }

        internal void FilterByTraitPresence(string traitName, HashSet<int> matchSet)
        {
            if (!m_Traits.TryGetValue(traitName, out var traitValues))
            {
                matchSet.Clear();
                return;
            }

            // if we might need more capacity in our filter buffer, add it
            if(matchSet.Count > s_IdsToFilter.Length)
                Array.Resize(ref s_IdsToFilter, matchSet.Count);

            foreach (var dataId in matchSet)
            {
                if (!traitValues.ContainsKey(dataId))
                {
                    s_IdsToFilter[s_FilteredIdCount] = dataId;
                    s_FilteredIdCount++;
                }
            }

            // instead of adding everything we want to filter to a List<int>, we use an array
            // and manually keep track of how much of the buffer we're using each time.
            // This is so we can filter potentially thousands of IDs quickly.
            for (var i = 0; i < s_FilteredIdCount; i++)
            {
                matchSet.Remove(s_IdsToFilter[i]);
            }

            // note that we do not Clear() the array, and rely on the counter to keep us within bounds.
            s_FilteredIdCount = 0;
        }

        // this overload supports the older matching codepath, which is still in use by Sets
        internal void FilterByTraitPresence(string traitName, Dictionary<int, float> matchRatings)
        {
            if (!m_Traits.TryGetValue(traitName, out var traitValues))
                return;

            // if we might need more capacity in our filter buffer, add it
            if(matchRatings.Count > s_IdsToFilter.Length)
                Array.Resize(ref s_IdsToFilter, matchRatings.Count);

            foreach (var kvp in matchRatings)
            {
                if (!traitValues.ContainsKey(kvp.Key))
                {
                    s_IdsToFilter[s_FilteredIdCount] = kvp.Key;
                    s_FilteredIdCount++;
                }
            }

            // instead of adding everything we want to filter to a List<int>, we use an array
            // and manually keep track of how much of the buffer we're using each time.
            // This is so we can filter potentially thousands of IDs quickly.
            for (var i = 0; i < s_FilteredIdCount; i++)
            {
                matchRatings.Remove(s_IdsToFilter[i]);
            }

            // note that we do not Clear() the array, and rely on the counter to keep us within bounds.
            s_FilteredIdCount = 0;
        }

        public void Clear()
        {
            m_Traits.Clear();
            m_CommandList.Clear();
            m_RemoveCommandBuffer.Clear();
            m_UpdateCommandBuffer.Clear();
        }
    }
}
