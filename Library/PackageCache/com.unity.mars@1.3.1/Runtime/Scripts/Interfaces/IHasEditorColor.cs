using System.Collections.Generic;
using Unity.MARS.Settings;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// Interface that allows an object to have a color associated with it in the editor.
    /// Extension methods can set the initial color and index from the current ColorPreset.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IHasEditorColor
    {
        /// <summary>
        /// The color used to identify this object
        /// </summary>
        Color color { get; set; }

        /// <summary>
        /// The index in the color list that this color is using. If the color has been modified, it should be -1.
        /// </summary>
        int colorIndex { get; set; }
    }

    /// <summary>
    /// Methods for classes that implement IHasEditorColor
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public static class HasEditorColorMethods
    {
        /// <summary>
        /// If the color is set to the default color, then it will choose a new color.
        /// </summary>
        /// <param name="editorColor">This object (extension method)</param>
        public static void SetNewColorIfDefault(this IHasEditorColor editorColor)
        {
            if (editorColor.color == default)
                SetNewColor(editorColor, true);
        }

        /// <summary>
        /// Sets a new color for this object
        /// </summary>
        /// <param name="editorColor">This object (extension method)</param>
        /// <param name="inheritHue"> If enabled, the color will use the same hue as any parent with the HasEditorColor interface.</param>
        /// <param name="forceNew">If enabled, the color will use a new color index, even if it is already the highest index in the scene</param>
        public static void SetNewColor(this IHasEditorColor editorColor, bool inheritHue, bool forceNew = false)
        {
            var currentColorList = MARSRuntimePrefabs.instance.entityColors;

            SetColorIndexFromCurrentScene(editorColor, forceNew);
            editorColor.color = currentColorList.GetColor(editorColor.colorIndex);

            if (inheritHue)
                SetSimilarToParent(editorColor);
        }

        /// <summary>
        /// Sets the color to have a similar hue to parent color, if there is a parent.
        /// </summary>
        /// <param name="editorColor">The editor color to set</param>
        /// <param name="hueSimilarity">How similar the hue should be to the parent, where 1 is exactly the same and 0 is the unaffected original hue.</param>
        static void SetSimilarToParent(IHasEditorColor editorColor, float hueSimilarity = 0.9f)
        {
            // Inherit hue from parent if there is one that has a color
            var component = editorColor as Component;

            if (component == null)
                return;

            var parent = component.gameObject.transform.parent;

            if (parent == null)
                return;

            var parentColor = parent.GetComponentInParent<IHasEditorColor>();
            if (parentColor == null)
                return;

            var colorPreset = MARSRuntimePrefabs.instance.entityColors;

            Color.RGBToHSV(parentColor.color, out var parentHue, out _, out _);
            Color.RGBToHSV(editorColor.color, out var newHue, out _, out _);

            // New hue is combination of new hue and parent hue
            newHue = Mathf.Lerp(newHue, parentHue, hueSimilarity);

            editorColor.color = Color.HSVToRGB(newHue, colorPreset.GetNewSaturation(editorColor.colorIndex), colorPreset.GetNewValue(editorColor.colorIndex));
        }

        public static void ApplyHueToChildren(this IHasEditorColor editorColor, float hueSimilarity = 0.9f)
        {
            var component = (Component)editorColor;
            foreach (var childEditorColor in component.GetComponentsInChildren<IHasEditorColor>())
            {
                if (childEditorColor == editorColor)
                    continue;

                SetSimilarToParent(childEditorColor);
            }
        }

        /// <summary>
        /// To ensure a unique color index even after some objects have been added/deleted,
        /// we use an index one larger than the largest index in the current scene
        /// </summary>
        /// <param name="editorColor">The editor color index to set</param>
        /// <param name="forceNew">If enabled, the index will be incremented even if it is already the highest in the scene.</param>
        static void SetColorIndexFromCurrentScene(IHasEditorColor editorColor, bool forceNew)
        {
            var currentColorComponent = editorColor as MonoBehaviour;
            var componentsInScene = new List<MonoBehaviour>();

            if (currentColorComponent == null)
                return;

            var gameObjectScene = currentColorComponent.gameObject.scene;
            if (gameObjectScene.isLoaded)
                GameObjectUtils.GetComponentsInScene(gameObjectScene, componentsInScene);

            var index = 0;
            foreach (var component in componentsInScene)
            {
                var otherEditorColor = component as IHasEditorColor;

                if (otherEditorColor != null && otherEditorColor.colorIndex >= index)
                {
                    // To force a new index, increment even if this color is already the highest index
                    if (otherEditorColor != editorColor || forceNew)
                    {
                        index = otherEditorColor.colorIndex + 1;
                    }
                }
            }

            editorColor.colorIndex = index;
        }
    }
}
