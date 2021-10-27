using System;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// Creates data for an MRMarker
    /// When added to a synthesized object, adds a trackable MRMarker to the database.
    /// When added to a simulated object, its data will be provided to the database by the simulated marker provider.
    /// </summary>
    [RequireComponent(typeof(SynthesizedPose))]
    [RequireComponent(typeof(SynthesizedBounds2D))]
    [RequireComponent(typeof(SynthesizedMarkerId))]
    [HelpURL(DocumentationConstants.SynthesizedMarkerDocs)]
    [MovedFrom("Unity.MARS.Data")]
    public class SynthesizedMarker : SynthesizedTrackable<MRMarker>
    {
        static readonly TraitDefinition[] k_ProvidedTraits = { TraitDefinitions.Marker, TraitDefinitions.TrackingState };

        MRMarker m_Marker;
        SynthesizedPose m_PoseSource;
        SynthesizedBounds2D m_ExtentsSource;
        SynthesizedMarkerId m_IdSource;

        internal int dataID { get; set; }

        /// <summary>
        /// The trait name provided by this SynthesizedTrait
        /// </summary>
        public override string TraitName => TraitNames.Marker;

        internal Vector2 Extents => m_ExtentsSource != null ? m_ExtentsSource.GetTraitData() : default;

        /// <summary>
        /// Called by Unity when the object is enabled
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();

            if (m_ExtentsSource == null)
                m_ExtentsSource = GetComponent<SynthesizedBounds2D>();
        }

        /// <summary>
        /// Called by MARS when the SynthesizedObject is initialized
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            if (MarsTrackableId.InvalidId == m_Marker.id)
                m_Marker.id = MarsTrackableId.Create();

            m_IdSource = GetComponent<SynthesizedMarkerId>();
            m_PoseSource = GetComponent<SynthesizedPose>();
            m_ExtentsSource = GetComponent<SynthesizedBounds2D>();

            if (!Guid.TryParse(m_IdSource.GetTraitData(), out var guid))
            {
                Debug.LogWarning($"The Synthesized Marker guid on '{name}' is missing or improperly formed.  " +
                                 "Image Marker Proxies may not match in simulation.");
                guid = Guid.Empty;
            }

            m_Marker.markerId = guid;
            m_Marker.texture = m_IdSource.Texture;

            GetData();

            // We cannot guarantee that the synthetic marker has been set so use the renderer scale as initial size
            m_IdSource.UpdateMarkerSizeWithLocalScale();
        }

        /// <summary>
        /// Get the MRMarker data for this SynthesizedMarker
        /// </summary>
        /// <returns>The MRMarker data</returns>
        public override MRMarker GetData()
        {
            m_Marker.pose = m_PoseSource.GetTraitData();
            m_Marker.extents = m_ExtentsSource.GetTraitData();
            // synth markers default to tracking so that they always work in the content scene & instant sim.
            // for play mode / temporal sim, it's up to the provider to modify the tracking state after this.
            m_Marker.trackingState = MARSTrackingState.Tracking;
            return m_Marker;
        }
    }
}
