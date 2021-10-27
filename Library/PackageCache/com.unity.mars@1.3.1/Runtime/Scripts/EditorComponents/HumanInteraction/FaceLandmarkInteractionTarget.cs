using Unity.MARS.Data;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// An interaction target that specifies a particular face landmark that it is associated with.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class FaceLandmarkInteractionTarget : InteractionTarget
    {
#pragma warning disable 649
        [SerializeField]
        MRFaceLandmark m_Landmark;
#pragma warning restore 649

        Renderer m_Renderer;

        /// <summary>
        /// The landmark of the face that this interaction target corresponds to.
        /// </summary>
        public MRFaceLandmark landmark
        {
            get { return m_Landmark; }
        }

        protected override void OnEnable()
        {
            m_Renderer = GetComponentInChildren<Renderer>();
        }
        protected override void OnStateChanged()
        {
            base.OnStateChanged();

            // Face landmark interaction targets will additionally disable renderers when they are not being hovered because
            // their location is assumed by the features on the base face mesh
            if (m_Renderer != null)
                m_Renderer.enabled = m_State == InteractionState.Hovered;
        }
    }
}
