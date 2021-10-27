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
    [MovedFrom("Unity.MARS.Recording")]
    public class PlaneFindingRecording : DataRecording
    {
        const string k_ProviderName = "Recorded Planes Provider";

        [SerializeField]
        SignalTrack m_SignalTrack;

        public SignalTrack SignalTrack { set { m_SignalTrack = value; } }

        public override void SetupDataProviders(PlayableDirector director, List<IFunctionalityProvider> providers)
        {
            var providerObj = GameObjectUtils.Create(k_ProviderName);
            var planesProvider = providerObj.AddComponent<RecordedPlanesProvider>();
            providers.Add(planesProvider);
            director.SetGenericBinding(m_SignalTrack, providerObj);
        }
    }
}
