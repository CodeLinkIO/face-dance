using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// Create the data for a pose trait
    /// When added to a synthesized object, adds a pose that is manually specified via script
    /// to its representation in the database
    /// </summary>
    [HelpURL(DocumentationConstants.SynthesizedManualPoseDocs)]
    [MovedFrom("Unity.MARS.Data")]
    public class SynthesizedManualPose : SynthesizedTrait<Pose>, IUsesCameraOffset
    {
        /// <summary>
        /// The trait which will be added to the associated SynthesizedObject
        /// </summary>
        public override string TraitName { get { return TraitNames.Pose; } }

        /// <summary>
        /// Whether the pose data should update with this object's Transform
        /// </summary>
        public override bool UpdateWithTransform { get { return true; } }

        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        /// <summary>
        /// The position of the synthesized pose
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// The rotation of the synthesized pose
        /// </summary>
        public Quaternion Rotation { get; set; }

        /// <summary>
        /// Get the trait data for this synthesized pose
        /// </summary>
        /// <returns>The trait data</returns>
        public override Pose GetTraitData()
        {
            return this.ApplyInverseOffsetToPose(new Pose(Position, Rotation));
        }
    }
}
