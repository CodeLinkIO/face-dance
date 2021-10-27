using Unity.MARS.Data;
using Unity.MARS.Data.ARFoundation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Data.ARFoundation
{
    [MovedFrom("Unity.MARS.Providers")]
    public static class ARKitFaceEditorUtils
    {
        public static void ARKitLandmarkIndicesFields(int[] landmarkIndices)
        {
            EditorGUILayout.LabelField("ARKit Landmark Triangle Indices", EditorStyles.boldLabel);
            for (var i = 0; i < landmarkIndices.Length; ++i)
            {
                var landmark = (ARKitFaceMeshLandmark)i;
                EditorGUILayout.IntField(landmark.ToString(), landmarkIndices[i]);
            }
        }

        /// <summary>
        /// Custom editor for fields representing the coefficient values at which facial expression events fire
        /// </summary>
        /// <param name="property">The threshold values property</param>
        public static void ExpressionThresholdFields(SerializedProperty property)
        {
            if (!property.isArray)
            {
                EditorGUILayout.HelpBox("This property must be an array", MessageType.Error);
                return;
            }

            const float minimumThreshold = 0.2f;
            EditorGUILayout.LabelField("Facial Expression Event Thresholds", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("These are the coefficient values at which events for their associated expressions happen", MessageType.Info);

            for (var i = 0; i < property.arraySize; ++i)
            {
                var element = property.GetArrayElementAtIndex(i);
                using (var check = new EditorGUI.ChangeCheckScope())
                {
                    var threshold = EditorGUILayout.Slider(((MRFaceExpression)i).ToString(), element.floatValue, minimumThreshold, 1f);
                    if (check.changed)
                        element.floatValue = Mathf.Clamp01(threshold);
                }
            }
        }
    }
}
