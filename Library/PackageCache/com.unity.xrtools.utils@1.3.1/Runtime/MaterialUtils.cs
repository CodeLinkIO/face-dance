using System;
using System.Globalization;
using UnityEngine;
using UnityObject = UnityEngine.Object;

#if !UNITY_2019_2_OR_NEWER || INCLUDE_UGUI
using UnityEngine.UI;
#endif

namespace Unity.XRTools.Utils
{
    /// <summary>
    /// Runtime Material utilities
    /// </summary>
    public static class MaterialUtils
    {
        public enum BlendMode
        {
            Opaque,
            Cutout,
            Fade,
            Transparent
        }

        static int k_ModeId = Shader.PropertyToID("_Mode");
        static int k_SrcBlendId = Shader.PropertyToID("_SrcBlend");
        static int k_DstBlendId = Shader.PropertyToID("_DstBlend");
        static int k_ZWriteId = Shader.PropertyToID("_ZWrite");

        /// <summary>
        /// Get a material clone; IMPORTANT: Make sure to call UnityObjectUtils.Destroy() on this material when done!
        /// </summary>
        /// <param name="renderer">Renderer that will have its material clone and replaced</param>
        /// <returns>Cloned material</returns>
        public static Material GetMaterialClone(Renderer renderer)
        {
            // The following is equivalent to renderer.material, but gets rid of the error messages in edit mode
            return renderer.material = UnityObject.Instantiate(renderer.sharedMaterial);
        }

#if !UNITY_2019_2_OR_NEWER || INCLUDE_UGUI
        /// <summary>
        /// Get a material clone; IMPORTANT: Make sure to call UnityObjectUtils.Destroy() on this material when done!
        /// </summary>
        /// <param name="graphic">Graphic that will have its material cloned and replaced</param>
        /// <returns>Cloned material</returns>
        public static Material GetMaterialClone(Graphic graphic)
        {
            // The following is equivalent to graphic.material, but gets rid of the error messages in edit mode
            return graphic.material = UnityObject.Instantiate(graphic.material);
        }
#endif

        /// <summary>
        /// Clone all materials within a renderer; IMPORTANT: Make sure to call UnityObjectUtils.Destroy() on this material when done!
        /// </summary>
        /// <param name="renderer">Renderer that will have its materials cloned and replaced</param>
        /// <returns>Cloned materials</returns>
        public static Material[] CloneMaterials(Renderer renderer)
        {
            var sharedMaterials = renderer.sharedMaterials;
            for (var i = 0; i < sharedMaterials.Length; i++)
            {
                sharedMaterials[i] = UnityObject.Instantiate(sharedMaterials[i]);
            }

            renderer.sharedMaterials = sharedMaterials;
            return sharedMaterials;
        }

        /// <summary>
        /// Convert a formatted hex string to a Color
        /// </summary>
        /// <param name="hex">The formatted string, with an optional 0x or # prefix</param>
        /// <returns>The color value represented by the formatted string</returns>
        public static Color HexToColor(string hex)
        {
            hex = hex.Replace("0x", "").Replace("#", "");
            var r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
            var g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
            var b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
            var a = hex.Length == 8 ? byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber) : (byte)255;

            return new Color32(r, g, b, a);
        }

        /// <summary>
        /// Shift the hue of a color by a given amount
        /// </summary>
        /// <param name="color">The input color</param>
        /// <param name="shift">The amount of shift</param>
        /// <returns>The output color</returns>
        public static Color HueShift(Color color, float shift)
        {
            Vector3 hsv;
            Color.RGBToHSV(color, out hsv.x, out hsv.y, out hsv.z);
            hsv.x = Mathf.Repeat(hsv.x + shift, 1f);
            return Color.HSVToRGB(hsv.x, hsv.y, hsv.z);
        }

        /// <summary>
        /// Add a material to this renderer's shared materials
        /// </summary>
        /// <param name="renderer">The renderer on which to add the material</param>
        /// <param name="material">The material to be added</param>
        public static void AddMaterial(this Renderer renderer, Material material)
        {
            var materials = renderer.sharedMaterials;
            var length = materials.Length;
            var newMaterials = new Material[length + 1];
            Array.Copy(materials, newMaterials, length);
            newMaterials[length] = material;
            renderer.sharedMaterials = newMaterials;
        }

        /// <summary>
        /// Set the render mode on the standard shader material.
        /// Adapted from StandardShaderGUI.SetupMaterialWithBlendMode
        /// </summary>
        /// <param name="standardShaderMaterial">The material to apply the rendering mode to.</param>
        /// <param name="blendMode">The material rendering mode (opaque, cutout, fade, transparent)</param>
        public static void SetRenderMode(Material standardShaderMaterial, BlendMode blendMode)
        {
            switch (blendMode)
            {
                case BlendMode.Opaque:
                    standardShaderMaterial.SetOverrideTag("RenderType", "Opaque");
                    standardShaderMaterial.SetFloat(k_ModeId, 0);
                    standardShaderMaterial.SetInt(k_SrcBlendId, (int)UnityEngine.Rendering.BlendMode.One);
                    standardShaderMaterial.SetInt(k_DstBlendId, (int)UnityEngine.Rendering.BlendMode.Zero);
                    standardShaderMaterial.SetInt(k_ZWriteId, 1);
                    standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                    standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                    standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    standardShaderMaterial.renderQueue = -1;
                    break;
                case BlendMode.Cutout:
                    standardShaderMaterial.SetOverrideTag("RenderType", "Cutout");
                    standardShaderMaterial.SetFloat(k_ModeId, 1);
                    standardShaderMaterial.SetInt(k_SrcBlendId, (int)UnityEngine.Rendering.BlendMode.One);
                    standardShaderMaterial.SetInt(k_DstBlendId, (int)UnityEngine.Rendering.BlendMode.Zero);
                    standardShaderMaterial.SetInt(k_ZWriteId, 1);
                    standardShaderMaterial.EnableKeyword("_ALPHATEST_ON");
                    standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                    standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    standardShaderMaterial.renderQueue = 2450;
                    break;
                case BlendMode.Fade:
                    standardShaderMaterial.SetOverrideTag("RenderType", "Fade");
                    standardShaderMaterial.SetFloat(k_ModeId, 2);
                    standardShaderMaterial.SetInt(k_SrcBlendId, (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    standardShaderMaterial.SetInt(k_DstBlendId, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    standardShaderMaterial.SetInt(k_ZWriteId, 0);
                    standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                    standardShaderMaterial.EnableKeyword("_ALPHABLEND_ON");
                    standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    standardShaderMaterial.renderQueue = 3000;
                    break;
                case BlendMode.Transparent:
                    standardShaderMaterial.SetOverrideTag("RenderType", "Transparent");
                    standardShaderMaterial.SetFloat(k_ModeId, 3);
                    standardShaderMaterial.SetInt(k_SrcBlendId, (int)UnityEngine.Rendering.BlendMode.One);
                    standardShaderMaterial.SetInt(k_DstBlendId, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    standardShaderMaterial.SetInt(k_ZWriteId, 0);
                    standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                    standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                    standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                    standardShaderMaterial.renderQueue = 3000;
                    break;
            }
        }
    }
}
