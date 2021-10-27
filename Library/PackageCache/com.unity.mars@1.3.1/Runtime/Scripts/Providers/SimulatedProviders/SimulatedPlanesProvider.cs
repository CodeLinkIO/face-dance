using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers.Synthetic
{
#if UNITY_EDITOR
    [AddComponentMenu("")]
    [ProviderSelectionOptions(ProviderPriorities.SimulatedProviderPriority)]
    [MovedFrom("Unity.MARS.Providers")]
    public class SimulatedPlanesProvider : SimulatedTrackablesProvider<MRPlane>, IProvidesPlaneFinding, IProvidesTraits<Pose>,
        IProvidesTraits<Vector2>, IProvidesTraits<int>, IProvidesTraits<bool>, IUsesMARSTrackableData<MRPlane>
    {
        static readonly TraitDefinition[] k_ProvidedTraits =
        {
            TraitDefinitions.Plane,
            TraitDefinitions.Pose,
            TraitDefinitions.Bounds2D,
            TraitDefinitions.Alignment
        };

// Suppresses the warning "The event 'event' is never used", because it is not an issue if the planes provider events are not used
#pragma warning disable 67
        public event Action<MRPlane> planeAdded;
        public event Action<MRPlane> planeUpdated;
        public event Action<MRPlane> planeRemoved;
#pragma warning restore 67

        public TraitDefinition[] GetProvidedTraits() { return k_ProvidedTraits; }

        void IFunctionalityProvider.LoadProvider() { }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesPlaneFinding>(obj);
        }

        void IFunctionalityProvider.UnloadProvider() { }

        public void GetPlanes(List<MRPlane> planes)
        {
            foreach (var pair in m_SimulatedTrackables)
            {
                planes.AddRange(pair.Value);
            }
        }

        public void StopDetectingPlanes() { }
        public void StartDetectingPlanes() { }

        protected override void AddObjectTrackables(SimulatedObject simulatedObject)
        {
            var objectPlanes = new List<MRPlane>();
            foreach (var synthPlane in simulatedObject.GetComponentsInChildren<SynthesizedPlane>())
            {
                if (!synthPlane.isActiveAndEnabled)
                    continue;

                synthPlane.Initialize();
                var plane = synthPlane.GetData();

                if (plane.id == MarsTrackableId.InvalidId)
                    continue;

                objectPlanes.Add(plane);
                var dataId = this.AddOrUpdateData(plane);
                synthPlane.dataID = dataId;
                this.AddOrUpdateTrait(dataId, TraitNames.Plane, true);
                this.AddOrUpdateTrait(dataId, TraitNames.Alignment, (int)plane.alignment);
                this.AddOrUpdateTrait(dataId, TraitNames.Pose, plane.pose);
                this.AddOrUpdateTrait(dataId, TraitNames.Bounds2D, plane.extents);

                foreach (var synthTag in synthPlane.GetComponents<SynthesizedSemanticTag>())
                {
                    if (!synthTag.isActiveAndEnabled)
                        continue;

                    this.AddOrUpdateTrait(dataId, synthTag.TraitName, synthTag.GetTraitData());
                }

                planeAdded?.Invoke(plane);
            }

            if (objectPlanes.Count > 0)
                m_SimulatedTrackables[simulatedObject] = objectPlanes;
        }

        protected override void UpdateObjectTrackables(SimulatedObject simulatedObject)
        {
            m_SimulatedTrackables[simulatedObject].Clear();

            foreach (var synthPlane in simulatedObject.GetComponentsInChildren<SynthesizedPlane>())
            {
                var plane = synthPlane.GetData();
                var dataId = this.AddOrUpdateData(plane);
                this.AddOrUpdateTrait(dataId, TraitNames.Pose, plane.pose);
                this.AddOrUpdateTrait(dataId, TraitNames.Bounds2D, plane.extents);
                planeUpdated?.Invoke(plane);
                m_SimulatedTrackables[simulatedObject].Add(plane);
            }
        }

        protected override void RemoveTrackable(MRPlane trackable)
        {
            var dataId = this.RemoveData(trackable);
            this.RemoveTrait<bool>(dataId, TraitNames.Plane);
            this.RemoveTrait<int>(dataId, TraitNames.Alignment);
            this.RemoveTrait<Vector2>(dataId, TraitNames.Bounds2D);
            this.RemoveTrait<Pose>(dataId, TraitNames.Pose);
            planeRemoved?.Invoke(trackable);
        }
    }
#else
    public class SimulatedPlanesProvider : MonoBehaviour { }
#endif
}
