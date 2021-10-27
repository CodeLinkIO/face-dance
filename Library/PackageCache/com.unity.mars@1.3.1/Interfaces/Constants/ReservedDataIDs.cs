using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    [MovedFrom("Unity.MARS")]
    public enum ReservedDataIDs
    {
        /// <summary> Data ID representing an invalid value </summary>
        Invalid = 0,
        /// <summary> Data ID representing first dynamically allocated id </summary>
        FirstDataId = 1,
        /// <summary> Data ID representing first system reserved id </summary>
        FirstSystemId = -1000,
        /// <summary> Data ID representing the environment immediately surrounding the user / device </summary>
        ImmediateEnvironment,
        /// <summary> Data ID representing the local user/device </summary>
        LocalUser,
        /// <summary> Data ID representing no choice being made </summary>
        Unset = -1,
    }
}
