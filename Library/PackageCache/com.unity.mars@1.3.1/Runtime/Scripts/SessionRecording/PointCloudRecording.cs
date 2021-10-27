using System.Collections.Generic;
using Unity.MARS.Recording.Providers;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

namespace Unity.MARS.Data.Recorded
{
    [MovedFrom("Unity.MARS")]
    public class PointCloudRecording : DataRecording
    {
        const string k_ProviderName = "Recorded Point Cloud Provider";

        [SerializeField]
        SignalTrack m_SignalTrack;

        public SignalTrack SignalTrack { set { m_SignalTrack = value; } }

        public override void SetupDataProviders(PlayableDirector director, List<IFunctionalityProvider> providers)
        {
            var providerObj = GameObjectUtils.Create(k_ProviderName);
            var pointCloudProvider = providerObj.AddComponent<RecordedPointCloudProvider>();
            providers.Add(pointCloudProvider);
            director.SetGenericBinding(m_SignalTrack, providerObj);
        }
    }
}
