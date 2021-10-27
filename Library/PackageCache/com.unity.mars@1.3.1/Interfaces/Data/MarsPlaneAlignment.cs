using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    [MovedFrom("Unity.MARS")]
    public enum MarsPlaneAlignment
    {
        None = 0,
        /// <summary>
        ///   <para>Plane has horizontal alignment and is facing upward</para>
        /// </summary>
        HorizontalUp = 1,
        /// <summary>
        ///   <para>Plane has vertical alignment.</para>
        /// </summary>
        Vertical = 2,
        /// <summary>
        ///   <para>Plane is not aligned along cardinal (X, Y or Z) axis.</para>
        /// </summary>
        NonAxis = 4,
        /// <summary>
        ///   <para>Plane has horizontal alignment and is facing downward</para>
        /// </summary>
        HorizontalDown = 8,
    }
}
