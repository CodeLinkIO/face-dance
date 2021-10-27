using System;
using Unity.MARS.Providers;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Called every frame during cloud data transfer with progress information
    /// </summary>
    /// <param name="upload">0-1 value indicating upload progress</param>
    /// <param name="download">0-1 value indicating download progress</param>
    [MovedFrom("Unity.MARS")]
    [Obsolete(IUsesCloudDataStorageMethods.ObsoleteMessage)]
    public delegate void ProgressCallback(float upload, float download);
}
