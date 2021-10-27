using System.Collections.Generic;
using Unity.MARS.Landmarks;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    [ExecuteInEditMode]
    [MovedFrom("Unity.MARS")]
    public class PlaneDataVisual : MonoBehaviour, IDataVisual
    {
        const float k_InteractionColorFactor = 1f;
        const float k_HoverPulseSpeed = 66f;
        const float k_SelectPulseSpeed = 80f;
        const float k_AlphaMaxSelected = 0.75f;
        const float k_AlphaMaxUnselected = 0.8f;
        const float k_AlphaMinSelected = 0.7f;
        const float k_AlphaMinUnselected = 0.65f;
        const float k_PreMultiplyFactor = 0.65f;

        static readonly Color k_InteractionColor = Color.cyan * k_PreMultiplyFactor;
        static readonly Color k_SelectionColor = Color.Lerp(Color.yellow, Color.red, 0.2f) * k_PreMultiplyFactor;

        static int s_ColorNameID;
        static int s_PulseSpeedNameID;
        static int[] s_AlphaMinMaxID = new int[2];

        static MaterialPropertyBlock s_MatPropBlock;

#pragma warning disable 649
        [SerializeField]
        InteractionTarget m_InteractionTarget;

        [SerializeField]
        LineRenderer m_Outline;

        [SerializeField]
        LandmarkOutputPolygon m_SurfacePolygon;
#pragma warning restore 649

        Color m_ColorOverride;
        List<Renderer> m_Renderers = new List<Renderer>();
        InteractionTarget.InteractionState m_InteractionState;
        float m_OutlineStartWidth;
        bool m_ShowRating;
        bool m_BestMatch;

        static Gradient s_RatingGradient;

        static Gradient RatingGradient
        {
            get
            {
                if (s_RatingGradient == null)
                {
                    var module = ModuleLoaderCore.instance.GetModule<DataVisualsModule>();
                    if (module != null)
                        s_RatingGradient = module.RatingGradient;
                }

                return s_RatingGradient;

            }
        }

        void Awake()
        {
            if (s_MatPropBlock == null)
                InitStaticMaterialValues();
        }

        static void InitStaticMaterialValues()
        {
            s_MatPropBlock = new MaterialPropertyBlock();
            s_ColorNameID = Shader.PropertyToID("_Color");
            s_PulseSpeedNameID = Shader.PropertyToID("_PulseSpeed");
            s_AlphaMinMaxID[0] = Shader.PropertyToID("_PulseMinAlpha");
            s_AlphaMinMaxID[1] = Shader.PropertyToID("_PulseMaxAlpha");
        }

        void OnEnable()
        {
            if (m_InteractionTarget != null)
                m_InteractionTarget.interactionStateChanged += UpdateInteractionTargetState;

            if (m_SurfacePolygon != null)
                m_SurfacePolygon.dataChanged += UpdateOutline;

            if (m_Outline != null)
                m_OutlineStartWidth = m_Outline.widthMultiplier;

            SetupRenderers();
        }
        void SetupRenderers()
        {
            gameObject.GetComponentsInChildren(m_Renderers);
            ApplyColors();
        }

        void OnDisable()
        {
            if (m_InteractionTarget != null)
                m_InteractionTarget.interactionStateChanged -= UpdateInteractionTargetState;

            if (m_SurfacePolygon != null)
                m_SurfacePolygon.dataChanged -= UpdateOutline;
        }

        void UpdateOutline(ICalculateLandmarks calculateLandmarks)
        {
            m_Outline.widthMultiplier = m_OutlineStartWidth * MARSSession.GetWorldScale();
            m_Outline.positionCount = m_SurfacePolygon.localVertices.Count;
            m_Outline.SetPositions(m_SurfacePolygon.localVertices.ToArray());
        }

        void ApplyColors()
        {
            foreach (var renderComponent in m_Renderers)
            {
                if (renderComponent == null)
                    continue;

                var sharedMaterial = renderComponent.sharedMaterial;
                var newColor = sharedMaterial.HasProperty(s_ColorNameID) ? sharedMaterial.color : Color.white;
                var pulseSpeed = 0f;
                var alphaMax = 0f;
                var alphaMin = 0f;

                if (m_InteractionState != InteractionTarget.InteractionState.None)
                {
                    var selected = m_InteractionState == InteractionTarget.InteractionState.Selected;
                    newColor = Color.Lerp(newColor,
                        selected ? k_SelectionColor : k_InteractionColor,
                        k_InteractionColorFactor);
                    pulseSpeed = selected ? k_SelectPulseSpeed : k_HoverPulseSpeed;
                    alphaMax = selected ? k_AlphaMaxSelected : k_AlphaMaxUnselected;
                    alphaMin = selected ? k_AlphaMinSelected : k_AlphaMinUnselected;

                }
                else if (m_ShowRating)
                {
                    newColor = m_ColorOverride;
                    alphaMin = k_AlphaMaxUnselected;
                    alphaMax = m_BestMatch ? k_AlphaMaxSelected : k_AlphaMaxUnselected;
                }

                if (renderComponent.sharedMaterial != null && s_MatPropBlock != null)
                {
                    s_MatPropBlock.SetColor(s_ColorNameID, newColor);
                    s_MatPropBlock.SetFloat(s_PulseSpeedNameID, pulseSpeed);
                    s_MatPropBlock.SetFloat(s_AlphaMinMaxID[0], alphaMin);
                    s_MatPropBlock.SetFloat(s_AlphaMinMaxID[1], alphaMax);

                    renderComponent.SetPropertyBlock(s_MatPropBlock);
                }
            }
        }

        void UpdateInteractionTargetState(InteractionTarget.InteractionState state)
        {
            m_InteractionState = state;
            ApplyColors();
        }

        public void ShowRating(float rating)
        {
            m_ShowRating = true;
            m_ColorOverride = RatingGradient.Evaluate(rating) * k_PreMultiplyFactor;
            m_BestMatch = rating >= 1.0f;

            ApplyColors();
        }

        public void ClearRating()
        {
            m_BestMatch = false;
            m_ShowRating = false;
            m_ColorOverride = Color.white * k_PreMultiplyFactor;
            ApplyColors();
        }
    }
}
