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
    public class CameraPoseRecording : DataRecording
    {
        const string k_ProviderName = "Recorded Camera Provider";

        [SerializeField]
        AnimationTrack m_AnimationTrack;

        public AnimationTrack AnimationTrack
        {
            set { m_AnimationTrack = value; }
        }

        /// <inheritdoc />
        public override void SetupDataProviders(PlayableDirector director, List<IFunctionalityProvider> providers)
        {
            var providerObj = GameObjectUtils.Create(k_ProviderName);
            var animator = providerObj.AddComponent<Animator>();
            director.SetGenericBinding(m_AnimationTrack, animator);
            providers.Add(providerObj.AddComponent<RecordedCameraPoseProvider>());
        }
    }
}
