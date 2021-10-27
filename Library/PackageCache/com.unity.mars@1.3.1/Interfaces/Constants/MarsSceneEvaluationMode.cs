using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    /// <summary>Options for when to evaluate the scene</summary>
    [MovedFrom("Unity.MARS")]
    public enum MarsSceneEvaluationMode : byte
    {
        /// <summary>Don't evaluate until a request to do so is received</summary>
        WaitForRequest,
        /// <summary>Evaluate the scene regularly regardless of evaluation requests</summary>
        EvaluateOnInterval
    }
}
