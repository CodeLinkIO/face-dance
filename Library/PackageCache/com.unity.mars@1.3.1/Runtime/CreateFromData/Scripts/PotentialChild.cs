using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// A potential member in a proxy group that is being created.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class PotentialChild
    {
        /// <summary>
        /// Data used when creating the proxy
        /// </summary>
        public CreateProxyFromData createProxyFromData;

        /// <summary>
        /// The source object for the child being created
        /// </summary>
        public Proxy sourceObject;
    }
}
