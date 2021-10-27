using System;
using System.Collections.Generic;
using UnityEngine;

#if INCLUDE_RENDER_PIPELINES_UNIVERSAL
using UnityEditor.Rendering.Universal.ShaderGUI;
#endif

namespace UnityEditor.MARS.Rendering
{
    // Adapted from `UnityEditor.Rendering.Universal.ShaderGUI.ParticlesUnlitShader`
    class MarsParticleMaterialInspector : BaseShaderGUI
    {
        public enum LegacyBlendMode
        {
            Opaque,
            Cutout,
            Fade,   // Old school alpha-blending mode, fresnel does not affect amount of transparency
            Transparent, // Physically plausible transparency mode, implemented as alpha pre-multiply
            Additive,
            Subtractive,
            Modulate
        }

        BakedLitGUI.BakedLitProperties shadingModelProperties;
        ParticleGUI.ParticleProperties particleProps;

        // List of renderers using this material in the scene, used for validating vertex streams
        List<ParticleSystemRenderer> m_RenderersUsingThisMaterial = new List<ParticleSystemRenderer>();

        public override void FindProperties(MaterialProperty[] properties)
        {
            base.FindProperties(properties);
            shadingModelProperties = new BakedLitGUI.BakedLitProperties(properties);
            particleProps = new ParticleGUI.ParticleProperties(properties);
        }

        public override void MaterialChanged(Material material)
        {
            if (material == null)
                throw new ArgumentNullException("material");

            if (m_FirstTimeApply)
                SyncWithLegacyValues(material);

            SetMaterialKeywords(material, null, ParticleGUI.SetMaterialKeywords);
            SetLegacyAndDefaultShaderKeywords(material);
        }

        public override void DrawSurfaceOptions(Material material)
        {
            // Detect any changes to the material
            EditorGUI.BeginChangeCheck();
            {
                base.DrawSurfaceOptions(material);
                DoPopup(ParticleGUI.Styles.colorMode, particleProps.colorMode, Enum.GetNames(typeof(ParticleGUI.ColorMode)));
            }
            if (EditorGUI.EndChangeCheck())
            {
                foreach (var obj in blendModeProp.targets)
                    MaterialChanged((Material)obj);
            }
        }

        public override void DrawSurfaceInputs(Material material)
        {
            base.DrawSurfaceInputs(material);
            BakedLitGUI.Inputs(shadingModelProperties, materialEditor);
            DrawEmissionProperties(material, true);

            SetLegacyAndDefaultShaderValues(material);
        }

        public override void DrawAdvancedOptions(Material material)
        {
            EditorGUI.BeginChangeCheck();
            {
                materialEditor.ShaderProperty(particleProps.flipbookMode, ParticleGUI.Styles.flipbookMode);
                ParticleGUI.FadingOptions(material, materialEditor, particleProps);
                ParticleGUI.DoVertexStreamsArea(material, m_RenderersUsingThisMaterial);
            }
            base.DrawAdvancedOptions(material);
        }

        public override void AssignNewShaderToMaterial(Material material, Shader oldShader, Shader newShader)
        {
            if (material == null)
                throw new ArgumentNullException("material");

            base.AssignNewShaderToMaterial(material, oldShader, newShader);

            m_FirstTimeApply = true;
            MaterialChanged(material);
        }

        public override void OnOpenGUI(Material material, MaterialEditor materialEditor)
        {
            CacheRenderersUsingThisMaterial(material);
            base.OnOpenGUI(material, materialEditor);
        }

        void CacheRenderersUsingThisMaterial(Material material)
        {
            m_RenderersUsingThisMaterial.Clear();

            ParticleSystemRenderer[] renderers = UnityEngine.Object.FindObjectsOfType(typeof(ParticleSystemRenderer)) as ParticleSystemRenderer[];
            foreach (ParticleSystemRenderer renderer in renderers)
            {
                if (renderer.sharedMaterial == material)
                    m_RenderersUsingThisMaterial.Add(renderer);
            }
        }

        void SyncWithLegacyValues(Material material)
        {
            material.SetColor("_BaseColor", material.GetColor("_Color"));
            material.SetTexture("_BaseMap", material.GetTexture("_MainTex"));

            material.SetFloat("_FlipbookBlending", material.GetFloat("_FlipbookMode"));

            var modeValue = material.GetFloat("_Mode");
            if (modeValue >= 0)
            {
                // Blend op is not supported on all hardware and shader APIs
                material.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.Add);

                var legacyMode = (LegacyBlendMode)material.GetFloat("_Mode");
                switch (legacyMode)
                {
                    case LegacyBlendMode.Opaque:
                        material.SetFloat("_Surface", (float)SurfaceType.Opaque);
                        material.SetFloat("_AlphaClip", 0);
                        break;
                    case LegacyBlendMode.Cutout:
                        material.SetFloat("_Surface", (float)SurfaceType.Opaque);
                        material.SetFloat("_AlphaClip", 1);
                        break;
                    case LegacyBlendMode.Fade: // Old school alpha-blending mode, fresnel does not affect amount of transparency
                        material.SetFloat("_Surface", (float)SurfaceType.Transparent);
                        material.SetFloat("_Blend", (float)BlendMode.Alpha);
                        material.SetFloat("_AlphaClip", 0);
                        break;
                    case LegacyBlendMode.Transparent: // Physically plausible transparency mode, implemented as alpha pre-multiply
                        material.SetFloat("_Surface", (float)SurfaceType.Transparent);
                        material.SetFloat("_Blend", (float)BlendMode.Premultiply);
                        material.SetFloat("_AlphaClip", 0);
                        break;
                    case LegacyBlendMode.Additive:
                        material.SetFloat("_Surface", (float)SurfaceType.Transparent);
                        material.SetFloat("_Blend", (float)BlendMode.Additive);
                        material.SetFloat("_AlphaClip", 0);
                        break;
                    case LegacyBlendMode.Subtractive:
                        material.SetFloat("_Surface", (float)SurfaceType.Transparent);
                        material.SetFloat("_Blend", (float)BlendMode.Additive);
                        material.SetFloat("_AlphaClip", 0);
                        break;
                    case LegacyBlendMode.Modulate:
                        material.SetFloat("_Surface", (float)SurfaceType.Transparent);
                        material.SetFloat("_Blend", (float)BlendMode.Multiply);
                        material.SetFloat("_AlphaClip", 0);
                        break;
                }

                // This is distructive but there is not one to one conversions for all modes
                material.SetFloat("_Mode", -1);
            }
        }

        static void SetLegacyAndDefaultShaderValues(Material material)
        {
            material.SetColor("_Color", material.GetColor("_BaseColor"));
            material.SetTexture("_MainTex", material.GetTexture("_BaseMap"));
        }

        static void SetLegacyAndDefaultShaderKeywords(Material material)
        {
            SurfaceType surfaceType = (SurfaceType)material.GetFloat("_Surface");
            BlendMode blendMode = (BlendMode)material.GetFloat("_Blend");
            if (surfaceType != SurfaceType.Opaque && (blendMode == BlendMode.Alpha || blendMode == BlendMode.Additive))
                material.EnableKeyword("_ALPHABLEND_ON");
            else
                material.DisableKeyword("_ALPHABLEND_ON");

            if (material.IsKeywordEnabled("_DISTORTION_ON"))
                material.EnableKeyword("EFFECT_BUMP");
            else
                material.DisableKeyword("EFFECT_BUMP");
        }
    }
}
