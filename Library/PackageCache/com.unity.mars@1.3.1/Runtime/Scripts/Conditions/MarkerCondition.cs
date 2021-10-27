using System;
using Unity.MARS.Attributes;
using Unity.MARS.MARSUtils;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Represents a situation that depends on the existence of a specific marker
    /// </summary>
    [HelpURL(DocumentationConstants.MarkerConditionDocs)]
    [DisallowMultipleComponent]
    [ComponentTooltip("Requires the object to be an image marker with a particular Guid.")]
    [MonoBehaviourComponentMenu(typeof(MarkerCondition), "Condition/Image Marker")]
    [MovedFrom("Unity.MARS")]
    public class MarkerCondition : Condition<string>
    {
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.MarkerId };

#pragma warning disable 649
        [SerializeField]
        string m_MarkerGuid;
#pragma warning restore 649

        /// <summary>
        /// The guid to match against
        /// </summary>
        public string MarkerGuid { get => m_MarkerGuid; set => m_MarkerGuid = value; }

        /// <inheritdoc />
        public override TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

        /// <inheritdoc />
        public override float RateDataMatch(ref string data)
        {
            return m_MarkerGuid.Equals(data) ? 1.0f : 0.0f;
        }

#if UNITY_EDITOR
        /// <inheritdoc />
        public override void OnValidate()
        {
            base.OnValidate();
            var scene = gameObject.scene;
            if (!scene.IsValid() || !scene.isLoaded)
                return;

            var session = MarsRuntimeUtils.GetMarsSessionInScene(scene);
            if (session == null)
                return;

            ValidateMarkerGuid(session);
        }

        internal void ValidateMarkerGuid(MARSSession session)
        {
            if (!string.IsNullOrEmpty(m_MarkerGuid))
                return;

            var markerLibrary = session.MarkerLibrary;
            if (markerLibrary == null)
                return;

            if (markerLibrary.Count == 0)
                return;

            m_MarkerGuid = markerLibrary[0].MarkerId.ToString();
        }
#endif
    }
}
