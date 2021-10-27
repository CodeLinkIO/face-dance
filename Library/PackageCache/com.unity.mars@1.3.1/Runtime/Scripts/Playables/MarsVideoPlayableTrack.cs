using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

namespace Unity.MARS.Data.Recorded
{
    [Serializable]
    [TrackClipType(typeof(MarsVideoPlayableAsset))]
    [MovedFrom("Unity.MARS.Recording")]
    public class MarsVideoPlayableTrack : TrackAsset
    {
    }
}
