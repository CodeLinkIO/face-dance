using Unity.MARS.Data;
using Unity.MARS.Data.ARFoundation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Data.ARFoundation
{
    [MovedFrom("Unity.MARS.Providers")]
    public static class ARCoreFaceEditorUtils
    {
        public static void ARCoreLandmarkIndicesFields(int[] landmarkIndices)
        {
            EditorGUILayout.LabelField("ARCore Landmark Triangle Indices", EditorStyles.boldLabel);
            for (var i = 0; i < landmarkIndices.Length; ++i)
            {
                var landmark = (ARCoreFaceMeshLandmark)i;
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

        /// <summary>
        /// Custom editor for fields representing the distance ranges by which we calculate expressions
        /// </summary>
        /// <param name="reverseStatesProperty">The reverse states property</param>
        /// <param name="minimumsProperty">The maximum distance values property</param>
        /// <param name="maximumsProperty">The minimum distance values property</param>
        public static void ExpressionDistanceRangeFields(SerializedProperty reverseStatesProperty,
            SerializedProperty minimumsProperty, SerializedProperty maximumsProperty)
        {
            if (!minimumsProperty.isArray && !maximumsProperty.isArray)
            {
                EditorGUILayout.HelpBox("The min and max properties must be arrays", MessageType.Error);
                return;
            }

            const float minimumRange = 0.001f;
            const float minimumDistance = 0.001f;
            const float maximumDistance = 0.1f;

            EditorGUILayout.LabelField("Facial Expression Landmark Distance Ranges", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("These ranges describe distances between landmarks. We use these distances to calculate expressions.\n" +
                                    "At minimum distance, coefficient is 0.  At maximum distance, coefficient is 1.\n" +
                                    "Some expressions (like eye close) have a smaller max, which means they work on inverse distance", MessageType.Info);

            for (var i = 0; i < minimumsProperty.arraySize; ++i)
            {
                var minElement = minimumsProperty.GetArrayElementAtIndex(i);
                var maxElement = maximumsProperty.GetArrayElementAtIndex(i);
                var reverseStateElement = reverseStatesProperty.GetArrayElementAtIndex(i);

                var label = ((MRFaceExpression)i).ToString();
                EditorGUILayout.LabelField(label, EditorStyles.boldLabel);

                using (var check = new EditorGUI.ChangeCheckScope())
                {
                    var reverse = EditorGUILayout.Toggle("Reverse", reverseStateElement.boolValue);

                    float min;
                    float max;
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        min = EditorGUILayout.DelayedFloatField("Minimum", minElement.floatValue);
                        max = EditorGUILayout.DelayedFloatField("Maximum", maxElement.floatValue);
                    }

                    if (reverse)
                        EditorGUILayout.MinMaxSlider("Range", ref max, ref min, minimumDistance, maximumDistance);
                    else
                        EditorGUILayout.MinMaxSlider("Range", ref min, ref max, minimumDistance, maximumDistance);

                    if (check.changed)
                    {
                        var range = Mathf.Abs(max - min);
                        if (range < minimumRange)
                        {
                            Debug.LogWarningFormat("{0} has a range of {1}, below the minimum of {2}", label, range.ToString("F4"), minimumRange);
                            continue;
                        }

                        reverseStateElement.boolValue = reverse;
                        if (reverse ? max < min : min < max)
                        {
                            minElement.floatValue = Mathf.Clamp01(min);
                            maxElement.floatValue = Mathf.Clamp01(max);
                        }
                    }
                }
            }
        }
    }
}
