using Unity.MARS.Landmarks;
using UnityEditor;
using UnityEditor.MARS.Data;

namespace Unity.MARS
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(FallbackFace))]
    class FallbackFaceEditor : Editor
    {
        FallbackFace m_FallbackFace;

        void OnEnable()
        {
            m_FallbackFace = (FallbackFace)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            FaceEditorUtils.LandmarkTransformFields(target, m_FallbackFace.landmarkTransforms);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
