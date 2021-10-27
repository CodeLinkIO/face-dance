using UnityEngine;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// An interaction target that specifies a particular body landmark that it is associated with.
    /// </summary>
    public class BodyLandmarkInteractionTarget : InteractionTarget
    {
        Renderer m_Renderer;

        /// <summary>
        /// Called by Unity when the object is enabled
        /// </summary>
        protected override void OnEnable()
        {
            m_Renderer = GetComponentInChildren<Renderer>();
            m_Renderer.enabled = false;
        }

        /// <summary>
        /// Called by MARS when the interaction state changes
        /// </summary>
        protected override void OnStateChanged()
        {
            base.OnStateChanged();
            // Body landmark interaction targets will additionally disable renderers when they are not being hovered because
            // their location is assumed by the features on the body mesh
            if (m_Renderer != null)
                m_Renderer.enabled = m_State == InteractionState.Hovered;
        }
    }
}
