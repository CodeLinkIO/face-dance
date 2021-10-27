using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Face expression event data type
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public enum MRFaceExpression
    {
        /// <summary>Left eye close</summary>
        LeftEyeClose,
        /// <summary>Right eye close</summary>
        RightEyeClose,
        /// <summary>Left eyebrow raise</summary>
        LeftEyebrowRaise,
        /// <summary>Right eyebrow raise</summary>
        RightEyebrowRaise,
        /// <summary>Both eye raise</summary>
        BothEyebrowsRaise,
        /// <summary>Left lip corner raise</summary>
        LeftLipCornerRaise,
        /// <summary>Right lip corner raise</summary>
        RightLipCornerRaise,
        /// <summary>Mouth smile</summary>
        Smile,
        /// <summary>Mouth open</summary>
        MouthOpen
    }

    /// <summary>
    /// Use to compare <c>MRFaceExpression</c> types
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class MRFaceExpressionComparer : IEqualityComparer<MRFaceExpression>
    {
        /// <inheritdoc />
        public bool Equals(MRFaceExpression x, MRFaceExpression y)
        {
            return x == y;
        }

        /// <inheritdoc />
        public int GetHashCode(MRFaceExpression obj)
        {
            return (int)obj;
        }
    }
}
