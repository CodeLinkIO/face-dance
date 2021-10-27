using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// Create the data for a pose trait
    /// When added to a synthesized object, adds a pose in the form of the GameObject's world position
    /// to its representation in the database
    /// </summary>
    [HelpURL(DocumentationConstants.SynthesizedPoseDocs)]
    [MovedFrom("Unity.MARS.Data")]
    public class SynthesizedPose : SynthesizedTrait<Pose>, IUsesCameraOffset
    {
        public override string TraitName { get { return TraitNames.Pose; } }
        public override bool UpdateWithTransform { get { return true; } }

        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        public override Pose GetTraitData()
        {
            var thisTransform = transform;
            return this.ApplyInverseOffsetToPose(new Pose(thisTransform.position, thisTransform.rotation));
        }
    }
}
