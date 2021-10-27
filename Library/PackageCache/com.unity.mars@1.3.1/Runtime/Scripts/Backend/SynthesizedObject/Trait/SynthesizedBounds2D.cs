using Unity.MARS.Providers;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// Creates the data for a 2D bounds trait
    /// When added to a synthesized object, adds extents based on the object's scale to its representation in the database
    /// </summary>
    [HelpURL(DocumentationConstants.SynthesizedBounds2DDocs)]
    [MovedFrom("Unity.MARS.Data")]
    public class SynthesizedBounds2D : SynthesizedTrait<Vector2>, IUsesCameraOffset
    {
        [SerializeField]
        [HideInInspector]
        Vector2 m_BaseBounds = Vector2.one;

        public override string TraitName { get { return TraitNames.Bounds2D; } }

        public override bool UpdateWithTransform { get { return true; } }

        public Vector2 baseBounds
        {
            get { return m_BaseBounds; }
            set { m_BaseBounds = value; }
        }

        public IProvidesCameraOffset provider { get; set; }

        public override Vector2 GetTraitData()
        {
            // Should use the "real world" scale of the transform, which is the "virtual world" scale divided by the camera scale.
            var realScale = transform.lossyScale / this.GetCameraScale();
            return new Vector2(baseBounds.x * realScale.x, baseBounds.y * realScale.z);
        }
    }
}
