using System;
using System.Collections.Generic;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Data
{
    /// <summary>
    /// The central store for world data and traits in MARS.
    /// </summary>
    [ModuleOrder(ModuleOrders.DatabaseLoadOrder)]
    [ModuleUnloadOrder(ModuleOrders.DatabaseLoadOrder)]
    public partial class MARSDatabase : IModuleMarsUpdate, IUsesCameraOffset, IUsesCameraPose
    {
        static int s_DataIDCounter = (int) ReservedDataIDs.FirstDataId;

        internal readonly Dictionary<int, HashSet<int>> DataUsedByQueries =
            new Dictionary<int, HashSet<int>>(MARSMemoryOptions.instance.DataUseTrackingCapacity);

        internal readonly Dictionary<QueryMatchID, int> DataUsedByQueryMatches =
            new Dictionary<QueryMatchID, int>(MARSMemoryOptions.instance.DataUseTrackingCapacity);

        internal readonly Dictionary<int, int> SharedDataUsersCounter =
            new Dictionary<int, int>(MARSMemoryOptions.instance.DataUseTrackingCapacity);

        internal readonly Dictionary<int, QueryMatchID> ReservedData =
            new Dictionary<int, QueryMatchID>(MARSMemoryOptions.instance.DataUseTrackingCapacity);

        readonly Dictionary<int, Dictionary<QueryMatchID, bool>> m_QueryDataDirtyStates =
            new Dictionary<int, Dictionary<QueryMatchID, bool>>(MARSMemoryOptions.instance.DataUseTrackingCapacity);

        /// <summary>
        /// Map a trait data type to an Action that we can use to filter results for that type
        /// </summary>
        internal readonly Dictionary<Type, Action<string, HashSet<int>>> TypeToFilterAction =
            new Dictionary<Type, Action<string, HashSet<int>>>(7);

        MARSMemoryOptions m_MemoryOptions;

        /// <summary>
        /// Maps each trait type to the function that will update the fill the initial value of a trait requirement of that type.
        /// Filled by generated code.
        /// </summary>
        internal readonly Dictionary<MarsDataType, FillRequirementTypeAction> TypeToRequirementFill =
            new Dictionary<MarsDataType, FillRequirementTypeAction>();

        /// <summary>
        /// Maps each trait type to the function that will update the value of a trait requirement of that type.
        /// Filled by generated code.
        /// </summary>
        internal readonly Dictionary<MarsDataType, UpdateRequirementTypeAction> TypeToRequirementUpdate =
            new Dictionary<MarsDataType, UpdateRequirementTypeAction>();

        // Local method use only -- created here to reduce garbage collection
        static readonly HashSet<int> k_IDsToRemove = new HashSet<int>();
        static readonly List<QueryMatchID> k_QueryMatchIDs = new List<QueryMatchID>();

        public MARSTrackableDataProvider<MRPlane> planeData { get; protected set; }
        public MARSTrackableDataProvider<MRReferencePoint> referencePointData { get; protected set; }
        public MARSTrackableDataProvider<IMRFace> faceData { get; protected set; }
        public MARSTrackableDataProvider<IMarsBody> bodyData { get; protected set; }

        public MARSTrackableDataProvider<MRMarker> markerData { get; protected set; }

        public MARSDataProvider<SynthesizedObject> synthesizedObjectData { get; protected set; }

        internal static int nextDataID { get { return s_DataIDCounter++; } }

        /// <summary>
        /// So that conditions which barely pass have a more than negligible effect on the total
        /// match rating, we have a minimum value that a passing condition should be rated
        /// </summary>
        public const float MinimumPassingConditionRating = 0.05f;

        /// <summary>
        /// Used in linear interpolation going from 1 to the minimum rating in place of (to - from)
        /// </summary>
        public const float MinimumRatingMinusOne = MinimumPassingConditionRating - 1f;

#if UNITY_EDITOR // only used by database viewer, not available at runtime
        /// <summary>
        /// Editor Only action used by the database viewer, not available at runtime.
        /// </summary>
        public static event Action dataUpdating;
#endif

        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }
        IProvidesCameraPose IFunctionalitySubscriber<IProvidesCameraPose>.provider { get; set; }

        internal delegate bool UpdateRequirementTypeAction(TraitRequirement requirement, int dataId, QueryResult result);
        internal delegate void FillRequirementTypeAction(TraitRequirement requirement, int dataId, QueryResult result);

        /// <summary>
        ///  All providers in here setup their own static FI, as does the database itself
        /// <inheritdoc />
        /// </summary>
        void IModule.LoadModule()
        {
            // pre-allocate collections used in tracking state
            m_MemoryOptions = MARSMemoryOptions.instance;
            Pools.QueryDataDirtyStates.PreAllocate(m_MemoryOptions.DataDirtyStatesPreAllocationCount);
            Pools.DataIdHashSets.PreAllocate(m_MemoryOptions.MatchIdHashSetPreAllocationCount);

            planeData = new MARSTrackableDataProvider<MRPlane>();
            referencePointData = new MARSTrackableDataProvider<MRReferencePoint>();
            faceData = new MARSTrackableDataProvider<IMRFace>();
            bodyData = new MARSTrackableDataProvider<IMarsBody>();
            markerData = new MARSTrackableDataProvider<MRMarker>();

            synthesizedObjectData = new MARSDataProvider<SynthesizedObject>();

            Action<int> setDirtyIfNeeded = SetDirtyIfNeeded;
            InitializeTraitProviders(setDirtyIfNeeded);
            AddRequirementUpdateMethods(this);

            IUsesDatabaseQueryingMethods.MarkDataUsedForUpdates = MarkDataUsedForUpdates;
            IUsesDatabaseQueryingMethods.UnmarkDataUsedForUpdates = UnmarkDataUsedForUpdates;
            IUsesDatabaseQueryingMethods.QueryDataDirty = QueryDataDirty;
            IUsesDatabaseQueryingMethods.TryUpdateQueryMatchData = TryUpdateQueryMatchData;
            IUsesDatabaseQueryingMethods.MarkSetDataUsedForUpdates = MarkSetDataUsedForUpdates;
            IUsesDatabaseQueryingMethods.UnmarkSetDataUsedForUpdates = UnmarkSetDataUsedForUpdates;
            IUsesDatabaseQueryingMethods.UnmarkPartialSetDataUsedForUpdates = UnmarkPartialSetDataUsedForUpdates;
            IUsesDatabaseQueryingMethods.IsSetQueryDataDirty = IsSetQueryDataDirty;
            IUsesDatabaseQueryingMethods.TryUpdateSetQueryMatchData = TryUpdateSetQueryMatchData;
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            planeData.Unload();
            referencePointData.Unload();
            faceData.Unload();
            bodyData.Unload();
            markerData.Unload();

            synthesizedObjectData.Unload();

            UnloadTraits(this);

            IUsesDatabaseQueryingMethods.MarkDataUsedForUpdates = null;
            IUsesDatabaseQueryingMethods.UnmarkDataUsedForUpdates = null;
            IUsesDatabaseQueryingMethods.QueryDataDirty = null;
            IUsesDatabaseQueryingMethods.TryUpdateQueryMatchData = null;
            IUsesDatabaseQueryingMethods.MarkSetDataUsedForUpdates = null;
            IUsesDatabaseQueryingMethods.UnmarkSetDataUsedForUpdates = null;
            IUsesDatabaseQueryingMethods.UnmarkPartialSetDataUsedForUpdates = null;
            IUsesDatabaseQueryingMethods.IsSetQueryDataDirty = null;
            IUsesDatabaseQueryingMethods.TryUpdateSetQueryMatchData = null;
            Clear();
        }

        public void Clear()
        {
            s_DataIDCounter = (int) ReservedDataIDs.FirstDataId;

            // If load fails or was never called because of an exception, data providers can be null and break Unload
            if (planeData == null)
                return;

            planeData.Clear();
            referencePointData.Clear();
            faceData.Clear();
            bodyData.Clear();
            markerData.Clear();

            foreach (var synthesizedObjectPair in synthesizedObjectData.GetCollection())
            {
                var value = synthesizedObjectPair.Value;
                if (value == null)
                    continue;

                value.OnDataBaseLost();
            }
            synthesizedObjectData.Clear();

            ClearTraits(this);

            ClearQueryData();
        }

        internal void ClearQueryData()
        {
            DataUsedByQueries.Clear();
            DataUsedByQueryMatches.Clear();
            SetDataUsedByQueries.Clear();
            SetDataUsedByQueryMatches.Clear();

            m_QueryDataDirtyStates.Clear();
            SharedDataUsersCounter.Clear();
            ReservedData.Clear();
        }

        internal void CacheTraitReferences(List<int> indexes, List<int> filteredIndexes, ProxyConditions[] conditions, ref CachedTraitCollection[] references)
        {
            filteredIndexes.Clear();
            foreach (var i in indexes)
            {
                var foundTraitCollections = references[i];
                // this shouldn't happen, but has been seen in really extreme cases of toggling data and proxies on and off.
                if (foundTraitCollections == null)
                    continue;

                if (foundTraitCollections.fulfilled)
                {
                    // TODO - better solution here to make sure no traits have been removed
                    if (foundTraitCollections.CheckForDestroyedCollections())
                    {
                        foundTraitCollections.fulfilled = false;
                        if (!FindTraitCollections(conditions[i], foundTraitCollections))
                            continue;
                    }

                    filteredIndexes.Add(i);
                    continue;
                }

                // if we find all the traits we're looking for, mark this query's reference cache as fulfilled
                if (FindTraitCollections(conditions[i], foundTraitCollections))
                {
                    filteredIndexes.Add(i);
                }
            }
        }

        void MarkDataAsChanged(int dataID, QueryMatchID queryMatchID = default)
        {
            if (m_QueryDataDirtyStates.TryGetValue(dataID, out var dirtyStates))
            {
                if (!queryMatchID.IsNullQuery())
                {
                    dirtyStates.Remove(queryMatchID);
                    if (dirtyStates.Count != 0)
                        return;
                }
                Pools.QueryDataDirtyStates.Recycle(dirtyStates);
                m_QueryDataDirtyStates.Remove(dataID);
            }
        }

        public void MarkDataUsedForUpdates(int dataID, QueryMatchID queryMatchID, Exclusivity exclusivity)
        {
            if (DataUsedByQueryMatches.ContainsKey(queryMatchID))
            {
                Debug.LogErrorFormat(
                    "Query '{0}' is already using data. If you wish to mark new data as used, " +
                    "first call UnmarkDataUsedForUpdates with this query ID.", queryMatchID);
                return;
            }

            DataUsedByQueryMatches[queryMatchID] = dataID;
            var queryID = queryMatchID.queryID;
            HashSet<int> dataUsedByQuery;
            if (DataUsedByQueries.TryGetValue(queryID, out dataUsedByQuery))
                dataUsedByQuery.Add(dataID);
            else
            {
                var set = Pools.DataIdHashSets.Get();
                set.Add(dataID);
                DataUsedByQueries[queryID] = set;
            }

            ReserveDataForQueryMatch(dataID, queryMatchID, exclusivity);
        }

        internal void MarkDataUsedAction(List<int> indices, int[] dataIds, QueryMatchID[] queryMatchIds, ref Exclusivity[] exclusivities)
        {
            foreach (var i in indices)
            {
                MarkDataUsedForUpdates(dataIds[i], queryMatchIds[i], exclusivities[i]);
            }
        }

        internal void ReserveDataForQueryMatch(int dataID, QueryMatchID queryMatchID, Exclusivity exclusivity)
        {
            MarkDataAsChanged(dataID, queryMatchID);

            switch (exclusivity)
            {
                case Exclusivity.Shared:
                    int count;
                    if (SharedDataUsersCounter.TryGetValue(dataID, out count))
                        SharedDataUsersCounter[dataID] = count + 1;
                    else
                        SharedDataUsersCounter[dataID] = 1;
                    break;
                case Exclusivity.Reserved:
                    if (!ReservedData.ContainsKey(dataID))
                        ReservedData[dataID] = queryMatchID;
                    break;
            }
        }

        public void UnmarkDataUsedForUpdates(QueryMatchID queryMatchID)
        {
            int dataID;
            if (!DataUsedByQueryMatches.TryGetValue(queryMatchID, out dataID))
                return;

            DataUsedByQueryMatches.Remove(queryMatchID);
            var queryID = queryMatchID.queryID;

            if (DataUsedByQueries.TryGetValue(queryID, out var dataUsedByQuery))
            {
                dataUsedByQuery.Remove(dataID);
                if (dataUsedByQuery.Count == 0)
                    DataUsedByQueries.Remove(queryID);
            }

            UnreserveDataForQueryMatch(dataID, queryMatchID);
        }

        void UnreserveDataForQueryMatch(int dataID, QueryMatchID queryMatchID)
        {
            MarkDataAsChanged(dataID, queryMatchID);

            int count;
            if (SharedDataUsersCounter.TryGetValue(dataID, out count))
            {
                SharedDataUsersCounter[dataID] = --count;
                if (count == 0)
                    SharedDataUsersCounter.Remove(dataID);
            }
            else
            {
                QueryMatchID dataOwner;
                if (ReservedData.TryGetValue(dataID, out dataOwner) && queryMatchID.SameQuery(dataOwner))
                    ReservedData.Remove(dataID);
            }
        }

        public bool QueryDataDirty(QueryMatchID queryMatchID)
        {
            if (DataUsedByQueryMatches.TryGetValue(queryMatchID, out var dataID))
            {
                return QueryDataDirty(dataID, queryMatchID);
            }
            return true;
        }

        bool QueryDataDirty(int dataID, QueryMatchID queryMatchID)
        {
            if (m_QueryDataDirtyStates.TryGetValue(dataID, out var dirtyStates))
            {
                if (dirtyStates.TryGetValue(queryMatchID, out var isDirty))
                {
                    if (isDirty)
                        dirtyStates[queryMatchID] = false;

                    return isDirty;
                }

                dirtyStates[queryMatchID] = false;
                return true;
            }
            else
            {
                dirtyStates = Pools.QueryDataDirtyStates.Get();
                dirtyStates.Clear();
                dirtyStates[queryMatchID] = false;
                m_QueryDataDirtyStates[dataID] = dirtyStates;
                return true;
            }
        }

        /// <summary>
        /// See if the value for a given data ID still meets a set of Conditions
        /// </summary>
        /// <param name="dataID">The id of the data value to check</param>
        /// <param name="conditions">The conditions to evaluate against</param>
        /// <param name="requirements">Trait requirements for meeting the condition</param>
        /// <param name="result">The Query result to fill out with updated values</param>
        /// <returns>True if the query data still matches, false otherwise</returns>
        public bool TryUpdateQueryMatchData(int dataID, ProxyConditions conditions, ProxyTraitRequirements requirements, QueryResult result)
        {
            // Check data still exists
            if (!(planeData.ValidIdValue(dataID) || referencePointData.ValidIdValue(dataID) || faceData.ValidIdValue(dataID) ||
                bodyData.ValidIdValue(dataID) || markerData.ValidIdValue(dataID) || synthesizedObjectData.ValidIdValue(dataID)))
                return false;

            if (requirements != null)
                if (!TryFillTraitRequirementsUpdate(dataID, requirements, result))
                    return false;

            GetTraitProvider(out MARSTraitDataProvider<Pose> poseTraitProvider);
            GetTraitProvider(out MARSTraitDataProvider<bool> tagTraitProvider);
            if (conditions.TryGetType(out ICondition<Pose>[] poseConditions))
            {
                foreach (var condition in poseConditions)
                {
                    if (!poseTraitProvider.TryGetTraitValue(dataID, condition.traitName, out var traitValue))
                        return false;

                    if (condition.PassesCondition(ref traitValue))
                        result.SetTrait(condition.traitName, this.ApplyOffsetToPose(traitValue));
                    else
                        return false;
                }
            }

            if (conditions.TryGetType(out ISemanticTagCondition[] semanticTagConditions))
            {
                foreach (var condition in semanticTagConditions)
                {
                    if (!tagTraitProvider.TryGetTraitValue(dataID, condition.traitName, out var traitValue))
                    {
                        if (condition.matchRule == SemanticTagMatchRule.Match)
                            return false;

                        continue; // an excluding match update made by lack of tag
                    }

                    if (condition.PassesCondition(ref traitValue) && condition.matchRule == SemanticTagMatchRule.Match)
                        result.SetTrait(condition.traitName, traitValue);
                    else
                        return false;
                }
            }

            // Update all condition types that we don't special-case in generated code
            return UpdateQueryMatchInternal(dataID, conditions, requirements, result);
        }

        internal bool DataAvailableForUse(int dataID, int queryID, Exclusivity exclusivity)
        {
            // Data should not be used again if this query is already using it
            HashSet<int> dataUsedByQuery;
            if (DataUsedByQueries.TryGetValue(queryID, out dataUsedByQuery) && dataUsedByQuery.Contains(dataID))
                return false;

            return exclusivity == Exclusivity.ReadOnly || !ReservedData.ContainsKey(dataID) &&
                (exclusivity == Exclusivity.Shared || !SharedDataUsersCounter.ContainsKey(dataID));
        }

        // a batch version of DataAvailableForUse that only has to lookup used data once for the batch
        internal void FilterAvailableData(HashSet<int> dataIDs, int queryID, Exclusivity exclusivity)
        {
            k_IDsToRemove.Clear();
            // Data should not be used again if this query is already using it
            HashSet<int> dataUsedByQuery;
            if (DataUsedByQueries.TryGetValue(queryID, out dataUsedByQuery))
            {
                dataIDs.ExceptWithNonAlloc(dataUsedByQuery);
            }

            var isReadOnly = exclusivity == Exclusivity.ReadOnly;
            var isShared = exclusivity == Exclusivity.Shared;
            foreach (var dataID in dataIDs)
            {
                if (isReadOnly || !ReservedData.ContainsKey(dataID) &&
                    (isShared || !SharedDataUsersCounter.ContainsKey(dataID)))
                {
                    continue;
                }

                k_IDsToRemove.Add(dataID);
            }

            dataIDs.ExceptWithNonAlloc(k_IDsToRemove);
        }

        void SetDirtyIfNeeded(int dataID)
        {
#if UNITY_EDITOR            // only used by database viewer, not available at runtime
            if (dataUpdating != null)
                dataUpdating();
#endif
            MarkDataAsChanged(dataID);
        }

        internal bool FindTraitCollections(ProxyConditions conditions, CachedTraitCollection cache)
        {
            if (cache.fulfilled)
                return true;

            cache.fulfilled = FindTraitsInternal(conditions, cache);
            return cache.fulfilled;
        }

        public bool RateConditionMatches<T>(ICondition<T>[] conditions, MARSTraitDataProvider<T> traitProvider,
            List<Dictionary<int, float>> preAllocatedRatingStorage)
        {
            if (conditions == null)
                return true;

            for (var i = 0; i < conditions.Length; i++)
            {
                var condition = conditions[i];
                Dictionary<int, T> traits;

                if (!traitProvider.TryGetAllTraitValues(condition.traitName, out traits))
                    return false;              // trait not found

                var ratings = preAllocatedRatingStorage[i];
                ratings.Clear();
                foreach (var kvp in traits)
                {
                    var value = kvp.Value;
                    var rating = condition.RateDataMatch(ref value);

                    // exclude all failing pieces of data from the results list
                    if (rating <= 0f)
                        continue;

                    var id = kvp.Key;
                    ratings.Add(id, rating);
                }

                if (ratings.Count == 0)        // trait found, but no matches
                    return false;
            }

            return true;
        }

        void RegisterTraitTypeProvider<T>(MARSTraitDataProvider<T> traitProvider)
        {
            var tType = typeof(T);
            if (TypeToFilterAction.ContainsKey(tType))
            {
                const string message = "There is already a registered trait data provider for type {0}, " +
                                       "not adding the new one";

                Debug.LogWarningFormat(message, tType.FullName);
            }

            // this mapping will allow us to later filter match sets based on the presence or absence of traits,
            // without having to directly refer to types
            TypeToFilterAction.Add(tType, traitProvider.FilterByTraitPresence);
        }

        static void FillRequirementType<T>(TraitRequirement requirement, int dataId,
            QueryResult result, MARSTraitDataProvider<T> provider)
        {
            if (requirement.Required)
            {
                // if we get an error with any of the dictionary access here, that means something
                // went wrong in the trait filtering stage, which should ensure that this
                // trait, with this type and data ID, is present in the database.
                var value = provider.dictionary[requirement.TraitName][dataId];
                result.SetTrait(requirement.TraitName, value);
            }
            else
            {
                if (!provider.dictionary.TryGetValue(requirement.TraitName, out var traitValues))
                    return;

                if(traitValues.TryGetValue(dataId, out var value))
                    result.SetTrait(requirement.TraitName, value);
            }
        }

        static bool TryUpdateRequirementType<T>(TraitRequirement requirement, int dataId,
            QueryResult result, MARSTraitDataProvider<T> provider)
        {
            if (requirement.Required)
            {
                if(provider.dictionary.TryGetValue(requirement.TraitName, out var traitValues))
                {
                    if (traitValues.TryGetValue(dataId, out var value))
                    {
                        result.SetTrait(requirement.TraitName, value);
                        return true;
                    }

                    return false;
                }

                return false;
            }
            else
            {
                if (provider.dictionary.TryGetValue(requirement.TraitName, out var traitValues))
                {
                    if(traitValues.TryGetValue(dataId, out var value))
                        result.SetTrait(requirement.TraitName, value);
                }

                return true;
            }
        }

        internal static void GetAllTraitsForId<T>(int dataId, MARSTraitDataProvider<T> traitCollection, Dictionary<string, T> results)
        {
            foreach (var trait in traitCollection.dictionary)
            {
                var traitDictionary = trait.Value;
                var traitName = trait.Key;

                if (traitDictionary.TryGetValue(dataId, out var value))
                {
                    if (results.ContainsKey(traitName))
                        results[traitName] = value;
                    else
                        results.Add(traitName, value);
                }
            }
        }

        internal void FillQueryResultRequirements(int dataId, ProxyTraitRequirements requirements, QueryResult result)
        {
            foreach (var requirement in requirements)
            {
                // We check Poses first because that is our most common use case and we have to offset the output
                if (requirement.Type == typeof(Pose))
                {
                    GetTraitProvider(out MARSTraitDataProvider<Pose> poseTraitProvider);
                    if (requirement.Required)
                    {
                        if(poseTraitProvider.dictionary.TryGetValue(requirement.TraitName, out var traitValues))
                        {
                            if (traitValues.TryGetValue(dataId, out var nonOffsetPose))
                                result.SetTrait(requirement.TraitName, this.ApplyOffsetToPose(nonOffsetPose));
                        }
                    }
                    else
                    {
                        if (!poseTraitProvider.dictionary.TryGetValue(requirement.TraitName, out var traitValues))
                            continue;

                        if(traitValues.TryGetValue(dataId, out var nonOffset))
                            result.SetTrait(requirement.TraitName, this.ApplyOffsetToPose(nonOffset));
                    }

                    continue;
                }

                TypeToRequirementFill[(MarsDataType) requirement.Type](requirement, dataId, result);
            }
        }

        internal bool TryFillTraitRequirementsUpdate(int dataId, ProxyTraitRequirements requirements, QueryResult result)
        {
            foreach (var requirement in requirements)
            {
                GetTraitProvider(out MARSTraitDataProvider<Pose> poseTraitProvider);
                // We check Poses first because that is our most common use case
                if (requirement.Type == typeof(Pose))
                {
                    if (requirement.Required)
                    {
                        if(poseTraitProvider.dictionary.TryGetValue(requirement.TraitName, out var traitValues))
                        {
                            if (traitValues.TryGetValue(dataId, out var nonOffsetPose))
                                result.SetTrait(requirement.TraitName, this.ApplyOffsetToPose(nonOffsetPose));
                            else
                                return false;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!poseTraitProvider.dictionary.TryGetValue(requirement.TraitName, out var traitValues))
                            continue;

                        if(traitValues.TryGetValue(dataId, out var nonOffset))
                            result.SetTrait(requirement.TraitName, this.ApplyOffsetToPose(nonOffset));
                    }

                    continue;
                }

                // find the type-specific requirement update action to use.
                // if a KeyNotFound exception happens here,
                // we didn't register a type handler for this when we initialized the system
                if (MarsDataType.TryGetFromType(requirement.Type, out var marsType))
                {
                    if (!TypeToRequirementUpdate[marsType](requirement, dataId, result))
                        return false;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        internal void StartUpdateBuffering()
        {
            StartBufferingInternal(this);
            // TEMPORARY FIX - disable pose update buffering to eliminate hitching
            //poseTraits.StartUpdateBuffering();
        }

        internal void StopUpdateBuffering()
        {
            StopBufferingInternal(this);
            //poseTraits.StopUpdateBuffering();
        }

        /// <inheritdoc />
        public void OnMarsUpdate()
        {
            // Eventually we'll want to delay running processing jobs even if there is some dirty data in a frame
            planeData.RunProcessingJobs();
            referencePointData.RunProcessingJobs();
            faceData.RunProcessingJobs();
            markerData.RunProcessingJobs();
        }

        /// <summary>
        /// (Obsolete) callback is no longer used
        /// </summary>
        public void OnBehaviorDisable() {}

        /// <summary>
        /// (Obsolete) callback is no longer used
        /// </summary>
        public void OnBehaviorDestroy() {}

        internal bool DataPassesAllConditions(ProxyConditions conditions, int dataId)
        {
            if (conditions.TryGetType(out ISemanticTagCondition[] semanticTagConditions))
            {
                GetTraitProvider(out MARSTraitDataProvider<bool> tagTraitProvider);

                foreach (var condition in semanticTagConditions)
                {
                    if (!tagTraitProvider.TryGetTraitValue(dataId, condition.traitName, out var traitValue))
                    {
                        if (condition.matchRule == SemanticTagMatchRule.Match)
                            return false;

                        continue;
                    }

                    if (condition.PassesCondition(ref traitValue) && condition.matchRule == SemanticTagMatchRule.Match)
                        continue;

                    return false;
                }
            }

            return DataPassesAllConditionsInternal(conditions, dataId);
        }

        static bool ConditionsPass<T>(MARSTraitDataProvider<T> traitProvider, ICondition<T>[] conditions, int dataId)
        {
            foreach (var condition in conditions)
            {
                var passed = traitProvider.TryGetTraitValue(dataId, condition.traitName, out var value) &&
                             condition.PassesCondition(ref value);

                if (!passed)
                    return false;
            }

            return true;
        }

        // All methods below here should be unused once code generation runs
        // ReSharper disable UnusedMember.Local
        // ReSharper disable UnusedParameter.Local
        void ClearTraits(object self) { }

        void StartBufferingInternal(object self) { }

        void StopBufferingInternal(object self) { }

        bool FindTraitsInternal(object conditions, object cache) { return false; }

        // ReSharper disable once UnusedMember.Global
        internal void GetTraitProvider<T>(out MARSTraitDataProvider<T> providerObject) { providerObject = default; }

        void InitializeTraitProviders(object setDirtyIfNeeded) { }

        void UnloadTraits(object self) { }

        void AddRequirementUpdateMethods(object self) { }

        [Obsolete("This method exists in order for MARS to compile before type-specific code is generated. Use the type-specific version of this method")]
        void FillRequirementsInternal(object self) { }

        bool UpdateQueryMatchInternal(int dataId, object conditions, object requirements, object result)
        {
            return false;
        }

        bool DataPassesAllConditionsInternal(object conditions, int dataId) { return false; }

        // ReSharper restore UnusedParameter.Local
        // ReSharper restore UnusedMember.Local
    }
}
