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
    public class SimulatedMarkerProvider : SimulatedTrackablesProvider<MRMarker>, IProvidesMarkerTracking, IProvidesTraits<bool>, IProvidesTraits<int>,
        IProvidesTraits<Pose>, IProvidesTraits<Vector2>, IProvidesTraits<string>, IUsesMARSTrackableData<MRMarker>
    {
        static readonly TraitDefinition[] k_ProvidedTraits =
        {
            TraitDefinitions.Marker,
            TraitDefinitions.Pose,
            TraitDefinitions.Bounds2D,
            TraitDefinitions.MarkerId,
            TraitDefinitions.TrackingState
        };

// Suppresses the warning "The event 'event' is never used", because it is not an issue if the marker provider events are not used
#pragma warning disable 67
        public event Action<MRMarker> markerAdded;
        public event Action<MRMarker> markerUpdated;
        public event Action<MRMarker> markerRemoved;
#pragma warning restore 67

        public TraitDefinition[] GetProvidedTraits() { return k_ProvidedTraits; }

        void IFunctionalityProvider.LoadProvider() { }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesMarkerTracking>(obj);
        }

        void IFunctionalityProvider.UnloadProvider() { }

        public bool SetActiveMarkerLibrary(IMRMarkerLibrary activeLibrary) { return true; }
        public void StopTrackingMarkers() { }
        public void StartTrackingMarkers() { }

        public void GetMarkers(List<MRMarker> markers)
        {
            foreach (var pair in m_SimulatedTrackables)
            {
                markers.AddRange(pair.Value);
            }
        }

        protected override void AddObjectTrackables(SimulatedObject simulatedObject)
        {
            var objectMarkers = new List<MRMarker>();
            foreach (var synthesizedMarker in simulatedObject.GetComponentsInChildren<SynthesizedMarker>())
            {
                if (!synthesizedMarker.isActiveAndEnabled)
                    continue;

                synthesizedMarker.Initialize();
                var marker = synthesizedMarker.GetData();

                if (marker.id == MarsTrackableId.InvalidId)
                    continue;

                objectMarkers.Add(marker);
                var dataId = this.AddOrUpdateData(marker);
                synthesizedMarker.dataID = dataId;
                this.AddOrUpdateTrait(dataId, TraitNames.Marker, true);
                this.AddOrUpdateTrait(dataId, TraitNames.MarkerId, marker.markerId.ToString());
                this.AddOrUpdateTrait(dataId, TraitNames.Pose, marker.pose);
                this.AddOrUpdateTrait(dataId, TraitNames.Bounds2D, marker.extents);
                this.AddOrUpdateTrait(dataId, TraitNames.TrackingState, (int) marker.trackingState);

                foreach (var synthTag in synthesizedMarker.GetComponents<SynthesizedSemanticTag>())
                {
                    if (!synthTag.isActiveAndEnabled)
                        continue;

                    this.AddOrUpdateTrait(dataId, synthTag.TraitName, synthTag.GetTraitData());
                }

                markerAdded?.Invoke(marker);
            }

            if (objectMarkers.Count > 0)
                m_SimulatedTrackables[simulatedObject] = objectMarkers;
        }

        protected override void UpdateObjectTrackables(SimulatedObject simulatedObject)
        {
            m_SimulatedTrackables[simulatedObject].Clear();

            foreach (var synthesizedMarker in simulatedObject.GetComponentsInChildren<SynthesizedMarker>())
            {
                var marker = synthesizedMarker.GetData();
                var dataId = this.AddOrUpdateData(marker);
                this.AddOrUpdateTrait(dataId, TraitNames.Pose, marker.pose);
                this.AddOrUpdateTrait(dataId, TraitNames.Bounds2D, marker.extents);
                this.AddOrUpdateTrait(dataId, TraitNames.TrackingState,  (int) marker.trackingState);
                markerUpdated?.Invoke(marker);
                m_SimulatedTrackables[simulatedObject].Add(marker);
            }
        }

        protected override void RemoveTrackable(MRMarker trackable)
        {
            var dataId = this.RemoveData(trackable);
            this.RemoveTrait<bool>(dataId, TraitNames.Marker);
            this.RemoveTrait<string>(dataId, TraitNames.MarkerId);
            this.RemoveTrait<Vector2>(dataId, TraitNames.Bounds2D);
            this.RemoveTrait<Pose>(dataId, TraitNames.Pose);
            this.RemoveTrait<int>(dataId, TraitNames.TrackingState);
            markerRemoved?.Invoke(trackable);
        }
    }
#else
    public class SimulatedMarkerProvider : MonoBehaviour { }
#endif
}
