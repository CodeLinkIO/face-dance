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
    [AddComponentMenu("")]
    [ProviderSelectionOptions(ProviderPriorities.SimulatedProviderPriority)]
    public class SimulatedBodySnapshotProvider : SimulatedTrackablesProvider<IMarsBody>, IProvidesMarsBodyTracking,
        IProvidesTraits<Pose>, IProvidesTraits<bool>, IUsesMARSTrackableData<IMarsBody>
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
            foreach (var pair in m_SimulatedTrackables)
            {
                bodies.AddRange(pair.Value);
            }
        }

        protected override void AddObjectTrackables(SimulatedObject simulatedObject)
        {
            var simObjectBodies = new List<IMarsBody>();
            foreach (var synthBody in simulatedObject.GetComponentsInChildren<SynthesizedBody>())
            {
                if (!synthBody.isActiveAndEnabled)
                    continue;

                synthBody.Initialize();
                var body = synthBody.GetData();
                if (body.id == MarsTrackableId.InvalidId)
                    continue;

                simObjectBodies.Add(body);
                var dataId = this.AddOrUpdateData(body);
                this.AddOrUpdateTrait(dataId, TraitNames.Body, true);
                this.AddOrUpdateTrait(dataId, TraitNames.Pose, body.pose);

                foreach (var synthTag in synthBody.GetComponents<SynthesizedSemanticTag>())
                {
                    if (!synthTag.isActiveAndEnabled)
                        continue;

                    this.AddOrUpdateTrait(dataId, synthTag.TraitName, synthTag.GetTraitData());
                }

                BodyAdded?.Invoke(body);
            }

            if (simObjectBodies.Count > 0)
                m_SimulatedTrackables[simulatedObject] = simObjectBodies;
        }

        protected override void UpdateObjectTrackables(SimulatedObject simulatedObject)
        {
            m_SimulatedTrackables[simulatedObject].Clear();

            foreach (var synthBody in simulatedObject.GetComponentsInChildren<SynthesizedBody>())
            {
                var body = synthBody.GetData();
                var dataId = this.AddOrUpdateData(body);
                this.AddOrUpdateTrait(dataId, TraitNames.Pose, body.pose);
                BodyUpdated?.Invoke(body);
                m_SimulatedTrackables[simulatedObject].Add(body);
            }
        }

        protected override void RemoveTrackable(IMarsBody trackable)
        {
            var dataId = this.RemoveData(trackable);
            this.RemoveTrait<bool>(dataId, TraitNames.Body);
            this.RemoveTrait<Pose>(dataId, TraitNames.Pose);
            BodyRemoved?.Invoke(trackable);
        }
    }
#else
    public class SimulatedBodySnapshotProvider : MonoBehaviour { }
#endif
}
