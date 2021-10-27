using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Providers.Synthetic
{
#if UNITY_EDITOR
    [ProviderSelectionOptions(ProviderPriorities.SimulatedProviderPriority)]
    public class SimulatedBodyTrackingProvider : SimulatedDataTrackingProvider<SynthesizedBody, IMarsBody>,
        IProvidesMarsBodyTracking, IProvidesTraits<Pose>, IProvidesTraits<bool>, IUsesMARSTrackableData<IMarsBody>
    {
        static readonly TraitDefinition[] k_ProvidedTraits =
        {
            TraitDefinitions.Body,
            TraitDefinitions.Pose
        };

#pragma warning disable 67
        public event Action<IMarsBody> BodyAdded;
        public event Action<IMarsBody> BodyUpdated;
        public event Action<IMarsBody> BodyRemoved;
#pragma warning restore 67

        public TraitDefinition[] GetProvidedTraits()
        {
            return k_ProvidedTraits;
        }

        void IFunctionalityProvider.LoadProvider()
        {
        }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesMarsBodyTracking>(obj);
        }

        void IFunctionalityProvider.UnloadProvider()
        {
        }

        public void GetBodies(List<IMarsBody> bodies)
        {
            foreach (var synthBody in m_DiscoveredTrackables)
            {
                bodies.Add(synthBody.GetData());
            }
        }

        protected override MARSTrackingState GetTrackingState(SynthesizedBody synthesizedTrackable, Camera marsCamera)
        {
            // *** ADD IMPLEMENTATION OF VISIBILITY CHECKING HERE ***
            var body = synthesizedTrackable.GetData();
            return body.id == MarsTrackableId.InvalidId ? MARSTrackingState.Unknown : MARSTrackingState.Tracking;
        }

        protected override void AddTrackableData(SynthesizedBody synthesizedTrackable, MARSTrackingState trackingState)
        {
            var body = synthesizedTrackable.GetData();
            var dataId = this.AddOrUpdateData(body);
            this.AddOrUpdateTrait(dataId, TraitNames.Body, true);
            this.AddOrUpdateTrait(dataId, TraitNames.Pose, body.pose);

            foreach (var synthTag in synthesizedTrackable.GetComponents<SynthesizedSemanticTag>())
            {
                if (!synthTag.isActiveAndEnabled)
                    continue;

                this.AddOrUpdateTrait(dataId, synthTag.TraitName, synthTag.GetTraitData());
            }

            BodyAdded?.Invoke(body);
        }

        protected override void UpdateTrackableData(SynthesizedBody synthesizedTrackable, MARSTrackingState trackingState)
        {
            var body = synthesizedTrackable.GetData();
            var dataId = this.AddOrUpdateData(body);
            this.AddOrUpdateTrait(dataId, TraitNames.Pose, body.pose);
            BodyUpdated?.Invoke(body);
        }

        protected override void RemoveTrackableData(SynthesizedBody synthesizedTrackable)
        {
            var body = synthesizedTrackable.GetData();
            var dataId = this.RemoveData(body);
            this.RemoveTrait<bool>(dataId, TraitNames.Body);
            this.RemoveTrait<Pose>(dataId, TraitNames.Pose);
            foreach (var synthTag in synthesizedTrackable.GetComponents<SynthesizedSemanticTag>())
            {
                this.RemoveTrait<bool>(dataId, synthTag.TraitName);
            }

            BodyRemoved?.Invoke(body);
        }
    }
#else
    public class SimulatedBodyTrackingProvider : SimulatedDataTrackingProvider<SynthesizedBody, IMarsBody> { }
#endif
}
