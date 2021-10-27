using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// Creates the data for a plane alignment trait
    /// When added to a synthesized object, adds an alignment based on the game object's rotation
    /// </summary>
    [HelpURL(DocumentationConstants.SynthesizedAlignmentDocs)]
    [MovedFrom("Unity.MARS.Data")]
    public class SynthesizedAlignment : SynthesizedTrait<int>
    {
        const float k_VerticalRange = 0.996f;
        const float k_HorizontalRange = 0.087f;

        public override string TraitName { get { return TraitNames.Alignment; } }
        public override bool UpdateWithTransform { get { return false; } }

        public override int GetTraitData()
        {
            var up = transform.up.y;
            var absUp = Mathf.Abs(up);

            if (absUp > k_VerticalRange)
            {
                return up > 0 ? (int) MarsPlaneAlignment.HorizontalUp : (int) MarsPlaneAlignment.HorizontalDown;
            }
            if (absUp < k_HorizontalRange)
            {
                return (int)MarsPlaneAlignment.Vertical;
            }
            return (int)MarsPlaneAlignment.NonAxis;
        }
    }
}
