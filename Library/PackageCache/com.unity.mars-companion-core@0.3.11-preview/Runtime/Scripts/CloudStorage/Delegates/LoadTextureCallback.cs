using UnityEngine;

namespace Unity.MARS.Companion.CloudStorage
{
    /// <summary>
    /// Response callback for for async texture load operations
    /// </summary>
    /// <param name="success">True if the request succeeded</param>
    /// <param name="responseCode">The HTTP response code</param>
    /// <param name="texture">The response payload as a Texture2D, or null if the response failed or the payload is not a valid image</param>
    /// <param name="payload">The raw response payload as a byte[], or the error string as a byte[]</param>
    public delegate void LoadTextureCallback(bool success, long responseCode, Texture2D texture, byte[] payload);
}
