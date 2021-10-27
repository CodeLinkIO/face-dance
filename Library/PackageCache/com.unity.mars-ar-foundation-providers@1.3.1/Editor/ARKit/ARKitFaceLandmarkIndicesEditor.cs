using Unity.MARS.Data.ARFoundation;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Data.ARFoundation
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ARKitLandmarkMeshIndices))]
    [MovedFrom("Unity.MARS.Providers")]
    public class ARKitFaceLandmarkIndicesEditor : Editor
    {
        ARKitLandmarkMeshIndices m_LandmarkTriangleIndices;

        void OnEnable()
        {
            m_LandmarkTriangleIndices = (ARKitLandmarkMeshIndices)target;
        }

        public override void OnInspectorGUI()
        {
            ARKitFaceEditorUtils.ARKitLandmarkIndicesFields(m_LandmarkTriangleIndices.landmarkTriangleIndices);
        }
    }
}
