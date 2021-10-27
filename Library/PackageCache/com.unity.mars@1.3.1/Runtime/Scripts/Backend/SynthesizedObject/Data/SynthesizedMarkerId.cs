using System;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Data
{
    [HelpURL(DocumentationConstants.SynthesizedMarkerIdDocs)]
    internal class SynthesizedMarkerId : SynthesizedTrait<string>
    {
        static MaterialPropertyBlock s_MatPropBlock;
        static readonly int k_MainTex = Shader.PropertyToID("_MainTex");

#pragma warning disable 649
        [SerializeField]
        string m_MarkerGuid;

        [SerializeField]
        Texture2D m_SyntheticMarkerTexture;
#pragma warning restore 649

        [SerializeField]
        MeshRenderer m_MarkerRenderer;

#if UNITY_EDITOR
        UnityEditor.SerializedObject m_MarkerRendererSerializedObjectTransform;
        UnityEditor.SerializedProperty m_MarkerRendererTransformLocalScaleProperty;
#endif

        public override string TraitName => TraitNames.MarkerId;
        public override bool UpdateWithTransform => false;

        public Texture2D Texture => m_SyntheticMarkerTexture;

        public override string GetTraitData()
        {
            return m_MarkerGuid;
        }

        internal void Initialize(Material syntheticMarkerMaterial)
        {
            m_MarkerGuid = Guid.Empty.ToString();
            m_MarkerRenderer = GetComponent<MeshRenderer>();
            m_MarkerRenderer.sharedMaterial = syntheticMarkerMaterial;

            InitializeSerializedObjectTransformProperty();
        }

        void InitializeSerializedObjectTransformProperty()
        {
#if UNITY_EDITOR
            m_MarkerRendererSerializedObjectTransform =
                new UnityEditor.SerializedObject(transform);
            m_MarkerRendererTransformLocalScaleProperty =
                m_MarkerRendererSerializedObjectTransform.FindProperty("m_LocalScale");
#endif
        }

        internal void ApplyPropBlockTextureOnSyntheticMarker()
        {
            if (s_MatPropBlock == null)
                s_MatPropBlock = new MaterialPropertyBlock();

            ValidateMarkerRenderer();
            m_MarkerRenderer.GetPropertyBlock(s_MatPropBlock);
            s_MatPropBlock.SetTexture(k_MainTex,
                m_SyntheticMarkerTexture != null ? m_SyntheticMarkerTexture : Texture2D.grayTexture);
            m_MarkerRenderer.SetPropertyBlock(s_MatPropBlock);
        }

        internal void UpdateMarkerSize(Vector2 markerSize)
        {
#if UNITY_EDITOR
            if (!ValidateMarkerRenderer())
                return;

            // We do the transform scale modification in order to trigger a SimulatedObject refresh
            // to be able to update the Bounds of the synthetic marker in the MARS Database
            m_MarkerRendererSerializedObjectTransform.Update();
            m_MarkerRendererTransformLocalScaleProperty.vector3Value = new Vector3(markerSize.x, 0.01f, markerSize.y);
            m_MarkerRendererSerializedObjectTransform.ApplyModifiedProperties();
#endif
        }

        internal void UpdateMarkerSizeWithLocalScale()
        {
            Vector3 initialScale = transform.localScale;
            UpdateMarkerSize(new Vector2(initialScale.x, initialScale.z));
        }

        bool ValidateMarkerRenderer()
        {
#if UNITY_EDITOR
            if (m_MarkerRenderer == null)
            {
                m_MarkerRenderer = GetComponent<MeshRenderer>();
                var stillNull = m_MarkerRenderer == null;
                if(stillNull)
                    Debug.LogError("Marker Renderer has not been assigned");

                return stillNull;
            }

            if (m_MarkerRendererTransformLocalScaleProperty == null)
                InitializeSerializedObjectTransformProperty();
#endif

            return true;
        }
    }
}
