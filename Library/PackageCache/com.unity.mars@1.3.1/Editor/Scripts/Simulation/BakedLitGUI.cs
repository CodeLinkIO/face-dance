#if !INCLUDE_RENDER_PIPELINES_UNIVERSAL
using System;

namespace UnityEditor.MARS.Rendering
{
    // Copied from BakedLitGUI.cs
    static class BakedLitGUI
    {
        public struct BakedLitProperties
        {
            // Surface Input Props
            public MaterialProperty bumpMapProp;

            public BakedLitProperties(MaterialProperty[] properties)
            {
                // Surface Input Props
                bumpMapProp = BaseShaderGUI.FindProperty("_BumpMap", properties, false);
            }
        }

        public static void Inputs(BakedLitProperties properties, MaterialEditor materialEditor)
        {
            BaseShaderGUI.DrawNormalArea(materialEditor, properties.bumpMapProp);
        }
    }
}
#endif
