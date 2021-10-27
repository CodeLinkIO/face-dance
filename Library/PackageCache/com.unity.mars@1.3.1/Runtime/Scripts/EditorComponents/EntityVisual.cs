using System.Collections.Generic;
using Unity.MARS.Query;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    [ExecuteInEditMode]
    [MovedFrom("Unity.MARS")]
    public class EntityVisual : MonoBehaviour
    {
        const float k_InteractionColorFactor = 0.5f;
        const float k_EdgeColorMultiplier = 1.2f; // Goes between 1-2 and is applied to the edges.
        static readonly Color k_InteractionColor = Color.white;
        static readonly int k_MainTex = Shader.PropertyToID("_MainTex");

#pragma warning disable 649
        [SerializeField]
        [HideInInspector]
        MARSEntity m_Entity;

        [SerializeField]
        List<Transform> m_ScalableTransforms = new List<Transform>();

        [SerializeField]
        List<GameObject> m_DeactivateWhenTracking = new List<GameObject>();

#pragma warning restore 649

        static int s_ColorNameID;
        static int s_EdgeColorNameID;
        static MaterialPropertyBlock s_MatPropBlock;

        protected List<Renderer> m_Renderers = new List<Renderer>();
        IHasEditorColor m_ColorData;
        InteractionTarget.InteractionState m_InteractionState;

        readonly List<Material> m_ClonedMaterials = new List<Material>();

        public InteractionTarget InteractionTarget { get; private set; }
        public MARSEntity entity { get { return m_Entity; } set { m_Entity = value; } }

        void Awake()
        {
            s_MatPropBlock = new MaterialPropertyBlock();
            s_ColorNameID = Shader.PropertyToID("_Color");
            s_EdgeColorNameID = Shader.PropertyToID("_EdgeColor");
        }

        void OnEnable()
        {
            if (entity == null)
                return;

            var redirect = GetComponent<RedirectSelection>();
            if (redirect == null)
                redirect = gameObject.AddComponent<RedirectSelection>();

            redirect.target = entity.gameObject;

            SetupRenderers();

            InteractionTarget = GetComponent<InteractionTarget>();
            if (InteractionTarget != null)
                InteractionTarget.interactionStateChanged += UpdateInteractionTargetState;
        }

        void OnDisable()
        {
            if (InteractionTarget != null)
                InteractionTarget.interactionStateChanged -= UpdateInteractionTargetState;
        }

        void OnDestroy()
        {
            foreach (var material in m_ClonedMaterials)
            {
                UnityObjectUtils.Destroy(material);
            }
        }

        void SetupRenderers()
        {
            gameObject.GetComponentsInChildren(m_Renderers);
            m_ColorData = m_Entity.GetComponent<IHasEditorColor>();
            ApplyColors();
        }

        internal void ApplyColors()
        {
            if (m_ColorData == null)
                return;

            foreach (var renderComponent in m_Renderers)
            {
                if (renderComponent == null || renderComponent.sharedMaterial == null)
                    continue;

                var newColor = renderComponent.sharedMaterial.color * m_ColorData.color;
                if (m_InteractionState != InteractionTarget.InteractionState.None)
                {
                    newColor = Color.Lerp(newColor, k_InteractionColor, k_InteractionColorFactor);
                }

                var spriteRenderer = renderComponent as SpriteRenderer;

                if (spriteRenderer != null)
                {
                    spriteRenderer.color = newColor;
                }
                else
                {
                    if (s_MatPropBlock == null)
                        s_MatPropBlock = new MaterialPropertyBlock();

                    renderComponent.GetPropertyBlock(s_MatPropBlock);
                    s_MatPropBlock.SetColor(s_ColorNameID, newColor);
                    var edgeColor = GetWhiterColor(newColor);
                    s_MatPropBlock.SetColor(s_EdgeColorNameID, edgeColor);
                    renderComponent.SetPropertyBlock(s_MatPropBlock);
                }
            }
        }

        static Color GetWhiterColor(Color baseColor)
        {
            var whiterR = Mathf.Clamp01(baseColor.r * k_EdgeColorMultiplier);
            var whiterG = Mathf.Clamp01(baseColor.g * k_EdgeColorMultiplier);
            var whiterB = Mathf.Clamp01(baseColor.b * k_EdgeColorMultiplier);
            var whiterA = Mathf.Clamp01(baseColor.a * k_EdgeColorMultiplier);
            return new Color(whiterR, whiterG, whiterB, whiterA);
        }

        public void SetScale(Vector3 scale)
        {
            foreach (var transformComponent in m_ScalableTransforms)
                transformComponent.localScale = scale;
        }

        public void SetTextureForImageMarker(Texture2D tex, bool tintTexture)
        {
            var textureTintColor = Color.white;
            for (var i = 0; i < m_Renderers.Count; i++)
            {
                if (tintTexture)
                {
                    textureTintColor = m_Renderers[i].sharedMaterial.color * m_ColorData.color;
                    if (m_InteractionState != InteractionTarget.InteractionState.None)
                        textureTintColor = Color.Lerp(textureTintColor, k_InteractionColor, k_InteractionColorFactor);
                }

                var scalableTransformWithMesh = m_Renderers[i] as MeshRenderer;
                if (scalableTransformWithMesh != null && m_Renderers[i].GetInstanceID() == scalableTransformWithMesh.GetInstanceID())
                {
                    m_Renderers[i].GetPropertyBlock(s_MatPropBlock);
                    s_MatPropBlock.SetTexture(k_MainTex, tex != null ? tex : Texture2D.whiteTexture);
                    s_MatPropBlock.SetColor(s_ColorNameID, textureTintColor);
                    m_Renderers[i].SetPropertyBlock(s_MatPropBlock);
                }
            }
        }

        public void UpdateForQueryState(QueryState queryState)
        {
            var isTracking = queryState == QueryState.Tracking;
            foreach (Transform child in transform)
            {
                // When the entity is running (simulation or playmode), gameobjects should only be active if the
                // query state is tracking. Some objects are always deactivated, even if tracking
                if (m_DeactivateWhenTracking.Contains(child.gameObject))
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(isTracking);
            }
        }

        protected virtual void UpdateInteractionTargetState(InteractionTarget.InteractionState newState)
        {
            m_InteractionState = newState;
            ApplyColors();
        }
    }
}
