using System.Collections.Generic;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// Object that contains a list of predefined colors and parameters to generate more colors.
    /// </summary>
    [CreateAssetMenu(fileName = "ColorPreset", menuName = "MARS/ColorPreset")]
    [MovedFrom("Unity.MARS")]
    public class ColorPreset : ScriptableObject
    {
        const float k_CycleIncrement = 0.618033988749895f; // approx (1/Golden ratio), used because it reduces overlap when cycling through values 0 to 1

        // Saturation and value will use 2 different prime multiples of the cycle increment so they cycle at different rates
        const float k_SaturationCycleIncrement = k_CycleIncrement * 7f;
        const float k_ValueCycleIncrement = k_CycleIncrement * 5f;

#pragma warning disable 649

        [SerializeField]
        [Tooltip("These colors will be used first when choosing a color in a new scene.")]
        List<Color> m_PredefinedColors = new List<Color>();

        [SerializeField]
        [Range(0f, 1f)]
        float m_MinSaturation = 0.5f;

        [SerializeField]
        [Range(0f, 1f)]
        float m_MaxSaturation = 1f;

        [SerializeField]
        [Range(0f, 1f)]
        float m_MinValue = 0.5f;

        [SerializeField]
        [Range(0f, 1f)]
        float m_MaxValue = 1f;

#pragma warning restore 649

        /// <summary>
        /// Gets the color for a given index. This will choose from the predefined list or generate a color based on the index.
        /// </summary>
        /// <param name="colorIndex"> The index into the list of predefined colors. If greater than the list length, it will be the index into the procedural color generation.</param>
        /// <returns> A new color from this preset.</returns>
        public Color GetColor(int colorIndex)
        {
            var predefinedColorsCount = m_PredefinedColors.Count;
            if (colorIndex < predefinedColorsCount)
                return m_PredefinedColors[colorIndex];

            // If there is not enough predefined colors, generate the values by cycling through colors
            var hue = 0f;
            var saturation = 0f;
            var value = 0f;

            // Set the initial HSV based on the last predefined color in the list
            if (predefinedColorsCount > 0)
                Color.RGBToHSV(m_PredefinedColors[predefinedColorsCount - 1], out hue, out saturation, out value);

            // The hue will be incremented based on the index and cycle from 0 to 1
            var generatedColorIndex = colorIndex - predefinedColorsCount + 1;
            hue += k_CycleIncrement * generatedColorIndex;
            hue %= 1f;

            // For saturation and value, use a different cycle increment so that they do not cycle at the same rate as each other
            saturation += k_SaturationCycleIncrement * generatedColorIndex;
            value += k_ValueCycleIncrement * generatedColorIndex;

            saturation %= 1f;
            value %= 1f;

            // Remap the saturation and value to their specified ranges
            saturation = Mathf.Lerp(m_MinSaturation, m_MaxSaturation, saturation);
            value = Mathf.Lerp(m_MinValue, m_MaxValue, value);

            var color = Color.HSVToRGB(hue, saturation, value);
            return color;
        }

        /// <summary>
        /// Generate a saturation (HSV) in the defined range
        /// </summary>
        /// <param name="index">Index into the sequence</param>
        /// <returns>Saturation value from 0 to 1</returns>
        public float GetNewSaturation(int index)
        {
            return Mathf.Lerp(m_MinSaturation, m_MaxSaturation, (k_CycleIncrement * index) % 1f);
        }

        /// <summary>
        /// Generate a value (HSV) in the defined color range
        /// </summary>
        /// <param name="index">Index into the sequence</param>
        /// <returns>Value from 0 to 1</returns>
        public float GetNewValue(int index)
        {
            return Mathf.Lerp(m_MinValue, m_MaxValue, (k_CycleIncrement * index) % 1f);
        }

        [ContextMenu("Reset Colors In Current Scene")]
        void ResetAllMARSColorsInCurrentScene()
        {
            var components = new List<Component>();
            var colors = new List<IHasEditorColor>();

            GameObjectUtils.GetComponentsInScene(SceneManager.GetActiveScene(), components);
            foreach (var sceneComponent in components)
            {
                var color = sceneComponent as IHasEditorColor;
                if (color != null)
                {
                    color.colorIndex = -1;
                    colors.Add(color);
                }
            }

            foreach (var color in colors)
                color.SetNewColor(true);

#if UNITY_EDITOR
            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
#endif
        }
    }
}
