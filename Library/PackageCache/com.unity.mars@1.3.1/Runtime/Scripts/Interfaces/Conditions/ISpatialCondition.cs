using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    [MovedFrom("Unity.MARS")]
    public interface ISpatialCondition
    {
#if UNITY_EDITOR
        void ScaleParameters(float scale);
#endif
    }
}
