using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// When added to a synthesized object, adds a trackable reference point to its representation in the database
    /// </summary>
    [RequireComponent(typeof(SynthesizedPose))]
    [MovedFrom("Unity.MARS.Data")]
    public class SynthesizedReferencePoint : SynthesizedTrackable<MRReferencePoint>, IUsesCameraOffset
    {
        static readonly TraitDefinition[] k_ProvidedTraits = { TraitDefinitions.Point };

        SynthesizedPose m_PoseSource;

        MRReferencePoint m_ReferencePoint = new MRReferencePoint(new Pose(), MARSTrackingState.Tracking);

        public override string TraitName { get { return TraitNames.Point; } }

        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        public override void Initialize()
        {
            m_PoseSource = GetComponent<SynthesizedPose>();
        }

        public override MRReferencePoint GetData()
        {
            m_ReferencePoint.pose = m_PoseSource.GetTraitData();
            return m_ReferencePoint;
        }
    }
}
