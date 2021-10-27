using Unity.MARS.Data.ARFoundation;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Data.ARFoundation
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ARCoreLandmarkMeshIndices))]
    [MovedFrom("Unity.MARS.Providers")]
    public class ARCoreFaceLandmarkIndicesEditor : Editor
    {
        ARCoreLandmarkMeshIndices m_LandmarkTriangleIndices;

        void OnEnable()
        {
            m_LandmarkTriangleIndices = (ARCoreLandmarkMeshIndices)target;
        }

        public override void OnInspectorGUI()
        {
            ARCoreFaceEditorUtils.ARCoreLandmarkIndicesFields(m_LandmarkTriangleIndices.landmarkTriangleIndices);
        }
    }
}
