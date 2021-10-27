using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Settings
{
    /// <summary>
    /// Memory management options for the MARS database.
    /// </summary>
    [ScriptableSettingsPath(MARSCore.SettingsFolder)]
    [MovedFrom("Unity.MARS.Data")]
    public class MARSMemoryOptions : ScriptableSettings<MARSMemoryOptions>
    {
#if UNITY_EDITOR
        internal static class Defaults
        {
            public const int QueryDataCapacity = 6;

            public const int RatingDictionaryCapacity = 12;
            public const int MatchIdHashSetCapacity = 12;
            public const int MatchIdHashSetPreAllocationCount = 24;
            public const int ResultDictionaryCapacity = 1;
            public const int DataUseTrackingCapacity = 12;
            public const int DataDirtyStatesCapacity = 1;
            public const int DataDirtyStatesPreAllocationCount = 24;
            public const int TraitDictionaryListCapacity = 1;
        }
#endif

        internal const int ResizeHeadroom = 16;
        internal const int RemovalBufferSize = 192;
        internal const int SortBufferSize = 256;

        [SerializeField]
        [HideInInspector]
        // this variable is actually used by the inspector.
#pragma warning disable CS0414
        int m_Multiplier = 4;
#pragma warning restore CS0414

        /// <summary>
        /// The starting capacity of all collections used to store per-query match data
        /// </summary>
        [Tooltip("The starting capacity of all collections used to store per-query match data")]
        public int QueryDataCapacity = 24;

        /// <summary>
        /// The starting capacity of the Dictionary instances used for match ratings
        /// </summary>
        [Tooltip("The starting capacity of the Dictionary instances used for match ratings")]
        public int RatingDictionaryCapacity = 48;

        /// <summary>
        /// The starting capacity of the HashSet instances used for match set intersection
        /// </summary>
        [Tooltip("The starting capacity of the HashSet instances used for match set intersection")]
        public int MatchIdHashSetCapacity = 48;
        /// <summary>
        /// How many match set instances to pre-allocate when the database loads
        /// </summary>
        [Tooltip("How many match set instances to pre-allocate when the database loads")]
        public int MatchIdHashSetPreAllocationCount = 96;

        /// <summary>
        /// The starting capacity of the Dictionary instances used in QueryResult
        /// </summary>
        [Tooltip("The starting capacity of the Dictionary instances used in QueryResults")]
        public int ResultDictionaryCapacity = 4;

        /// <summary>
        /// The starting capacity of all collections in the database used to track data ownership
        /// </summary>
        [Tooltip("The starting capacity of all collections in the database used to track data ownership")]
        public int DataUseTrackingCapacity = 48;

        /// <summary>
        /// The starting capacity of the Dictionary instances that track data dirty states
        /// </summary>
        [Tooltip("The starting capacity of the Dictionary instances that track data dirty states")]
        public int DataDirtyStatesCapacity = 4;
        /// <summary>
        /// How many 'dirty state tracking' collection to allocate when the database loads
        /// </summary>
        [Tooltip("How many 'dirty state tracking' collection to allocate when the database loads")]
        public int DataDirtyStatesPreAllocationCount = 96;

        /// <summary>
        /// The starting capacity of the Lists of trait value collections used at the start of the pipeline
        /// </summary>
        [Tooltip("The starting capacity of the Lists of trait value collections used at the start of the pipeline")]
        public int TraitDictionaryListCapacity = 4;

        /// <summary>
        /// The number of slots in the Set member data to pre-allocate for every slot in the Set data
        /// </summary>
        [Tooltip("The number of slots in the Set member data to pre-allocate for every slot in the Set data")]
        public int SetMemberCapacityMultiplier = 3;
    }
}
