using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    /// <summary>Possible responses to receiving a scene evaluation request</summary>
    [MovedFrom("Unity.MARS")]
    public enum MarsSceneEvaluationRequestResponse : byte
    {
        /// <summary>
        /// The response did not result in scene evaluation being queued, because interval evaluation mode is active
        /// </summary>
        NotQueued,
        /// <summary>
        /// There was already a scene evaluation queued before the request was received
        /// </summary>
        AlreadyQueued,
        /// <summary>
        /// A new scene evaluation was queued, and will begin executing after the minimum interval between evaluations has elapsed
        /// </summary>
        QueuedAfterCooldown,
        /// <summary>
        /// A new scene evaluation was queued, and will begin executing next frame
        /// </summary>
        QueuedImmediately
    }
}
