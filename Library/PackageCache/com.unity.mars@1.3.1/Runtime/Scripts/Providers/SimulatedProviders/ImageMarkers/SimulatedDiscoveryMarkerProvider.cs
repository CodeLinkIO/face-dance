using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.MARSUtils;
using Unity.MARS.Query;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.MARS.Providers.Synthetic
{
#if UNITY_EDITOR
    [AddComponentMenu("")]
    [ProviderSelectionOptions(ProviderPriorities.SimulatedProviderPriority)]
    public class SimulatedDiscoveryMarkerProvider : MonoBehaviour, IProvidesMarkerTracking, IUsesMARSTrackableData<MRMarker>, IUsesFunctionalityInjection,
        IProvidesTraits<bool>, IProvidesTraits<int>, IProvidesTraits<Pose>, IProvidesTraits<Vector2>, IProvidesTraits<string>, IUsesSlowTasks
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

        [SerializeField]
        float m_TrackingUpdateInterval = 0.1f;

        Scene m_EnvironmentScene;
        PhysicsScene m_EnvironmentPhysicsScene;

        readonly HashSet<SynthesizedMarker> m_SynthMarkers = new HashSet<SynthesizedMarker>();
        readonly HashSet<MarsTrackableId> m_DiscoveredTrackables = new HashSet<MarsTrackableId>();

        static readonly RaycastHit[] k_RayHits = new RaycastHit[16];
        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before/after use
        static readonly List<SimulatedObject> k_SimulatedObjects = new List<SimulatedObject>();
        static readonly List<SynthesizedSemanticTag> k_TempSynthTags = new List<SynthesizedSemanticTag>();

        IProvidesSlowTasks IFunctionalitySubscriber<IProvidesSlowTasks>.provider { get; set; }
        IProvidesFunctionalityInjection IFunctionalitySubscriber<IProvidesFunctionalityInjection>.provider { get; set; }

        public TraitDefinition[] GetProvidedTraits() { return k_ProvidedTraits; }

        void IFunctionalityProvider.LoadProvider() { }
        void IFunctionalityProvider.UnloadProvider() { }
        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesMarkerTracking>(obj);
        }

        void OnEnable()
        {
            StartTrackingMarkers();
            EditorOnlyEvents.onEnvironmentSetup += SetupTrackingForEnvironment;
            if (Application.isPlaying)
                return;

            // In edit mode simulation the environment is set up before providers are enabled
            SetupTrackingForEnvironment();
        }

        void OnDisable()
        {
            EditorOnlyEvents.onEnvironmentSetup -= SetupTrackingForEnvironment;

            StopTrackingMarkers();
            RemoveAllTrackables();
        }

        // ignore library setting for now, just track any markers we find in the environment
        public bool SetActiveMarkerLibrary(IMRMarkerLibrary activeLibrary) { return true; }

        public void StopTrackingMarkers()
        {
            this.RemoveMarsTimeSlowTask(UpdateTracking);
        }

        public void StartTrackingMarkers()
        {
            this.AddMarsTimeSlowTask(UpdateTracking, m_TrackingUpdateInterval);
        }

        public void GetMarkers(List<MRMarker> markers)
        {
            foreach (var synthMarker in m_SynthMarkers)
            {
                markers.Add(synthMarker.GetData());
            }
        }

        void SetupTrackingForEnvironment()
        {
            m_EnvironmentScene = EditorOnlyDelegates.GetSimulatedEnvironmentScene();
            if (!m_EnvironmentScene.IsValid())
                return;

            m_EnvironmentPhysicsScene = m_EnvironmentScene.GetPhysicsScene();

            m_SynthMarkers.Clear();
            k_SimulatedObjects.Clear();
            GameObjectUtils.GetComponentsInScene(m_EnvironmentScene, k_SimulatedObjects);
            foreach (var simulatedObject in k_SimulatedObjects)
            {
                var synthesizedMarker = simulatedObject.GetComponent<SynthesizedMarker>();
                if (synthesizedMarker == null || !synthesizedMarker.isActiveAndEnabled)
                    continue;

                synthesizedMarker.Initialize();
                m_SynthMarkers.Add(synthesizedMarker);
                this.InjectFunctionalitySingle(simulatedObject);
                simulatedObject.StartRunInEditMode();
            }

            k_SimulatedObjects.Clear();
        }

        void RemoveTrackable(MRMarker trackable)
        {
            var dataId = this.RemoveData(trackable);
            this.RemoveTrait<bool>(dataId, TraitNames.Marker);
            this.RemoveTrait<string>(dataId, TraitNames.MarkerId);
            this.RemoveTrait<Vector2>(dataId, TraitNames.Bounds2D);
            this.RemoveTrait<Pose>(dataId, TraitNames.Pose);
            this.RemoveTrait<int>(dataId, TraitNames.TrackingState);
            markerRemoved?.Invoke(trackable);
        }

        void UpdateTracking()
        {
            if (!m_EnvironmentScene.IsValid() || !m_EnvironmentPhysicsScene.IsValid())
                return;

            var marsCamera = MarsRuntimeUtils.GetActiveCamera(true);
            if (marsCamera == null)
                return;

            foreach (var synthesizedBody in m_SynthMarkers)
            {
                UpdateTracking(synthesizedBody, marsCamera);
            }
        }

        void AddMarkerData(SynthesizedMarker synthMarker, ref MRMarker marker, MARSTrackingState trackingState)
        {
            var dataId = UpdateMarkerData(ref marker, trackingState);
            synthMarker.dataID = dataId;

            // add every trait that won't change in here - semantic tags and marker id in this case
            this.AddOrUpdateTrait(dataId, TraitNames.Marker, true);
            this.AddOrUpdateTrait(dataId, TraitNames.MarkerId, marker.markerId.ToString());

            k_TempSynthTags.Clear();
            synthMarker.GetComponents(k_TempSynthTags);
            foreach (var synthTag in k_TempSynthTags)
            {
                if (!synthTag.isActiveAndEnabled)
                    continue;

                this.AddOrUpdateTrait(dataId, synthTag.TraitName, synthTag.GetTraitData());
            }
        }

        // update any dynamic properties of the marker and return data id
        int UpdateMarkerData(ref MRMarker marker, MARSTrackingState trackingState)
        {
            marker.trackingState = trackingState;
            var dataId = this.AddOrUpdateData(marker);

            // while real-world image markers aren't likely to change size, supporting it in sim is convenient
            this.AddOrUpdateTrait(dataId, TraitNames.Bounds2D, marker.extents);
            this.AddOrUpdateTrait(dataId, TraitNames.TrackingState, (int) trackingState);
            //  stop updating poses once tracking is lost
            if(trackingState != MARSTrackingState.Unknown)
                this.AddOrUpdateTrait(dataId, TraitNames.Pose, marker.pose);

            return dataId;
        }

        void UpdateTracking(SynthesizedMarker synthesizedMarker, Camera marsCamera)
        {
            if (!synthesizedMarker.isActiveAndEnabled)
                return;

            var marker = synthesizedMarker.GetData();
            if (marker.id == MarsTrackableId.InvalidId)
                return;

            // synth markers always report 'Tracking', here we calculate the tracking state for the mars camera
            var trackingState = GetTrackingState(synthesizedMarker, marsCamera);

            var previouslyFound = m_DiscoveredTrackables.Contains(marker.id);
            var tracking = trackingState != MARSTrackingState.Unknown;
            // don't add any data to the database until the first time the camera sees the marker well enough to track.
            if (!previouslyFound)
            {
                if (!tracking)
                    return;

                m_DiscoveredTrackables.Add(marker.id);
                AddMarkerData(synthesizedMarker, ref marker, trackingState);
                markerAdded?.Invoke(marker);
            }
            else
            {
                UpdateMarkerData(ref marker, trackingState);
                markerUpdated?.Invoke(marker);
            }
        }

        /// <summary>
        /// Tells us how the viewing angle of the camera to the image's surface normal affects tracking as a 0-1 number
        /// </summary>
        static float GetImageAlignmentQuality(Vector3 selfUp, Vector3 camForward)
        {
            const float ideal = -1f;
            // 0 = 90 degrees, view angle slightly over 90 degrees can still track in some situations
            const float max = 0.1f;
            const float rangeSize = -(ideal - max);

            var dot = Vector3.Dot(camForward, selfUp);
            // extreme viewing angles (> 100 degrees) cause the marker to become impossible to track
            if (dot > max)
                return 0f;

            var diff = -(ideal - dot);
            var portion = diff / rangeSize;

            const float minimumQualityModifier = 0.2f;
            return Mathf.Lerp(1f, minimumQualityModifier, portion);
        }

        /// <summary>
        /// How directly is the camera looking at the marker's position, and how does that affect tracking as a 0-1 number?
        /// </summary>
        static float GetLookDirectionQuality(Vector3 markerPosition, Vector3 camPosition, Vector3 camForward)
        {
            var camToMarkerDirection = Vector3.Normalize(markerPosition - camPosition);
            var dot = Vector3.Dot(Vector3.Normalize(camForward), camToMarkerDirection);

            const float min = 0.6f;
            const float ideal = 1f;
            const float rangeSize = ideal - min;
            var diff = ideal - dot;
            var portion = diff / rangeSize;
            return Mathf.Lerp(ideal, min, portion);
        }

        // combine all marker tracking heuristics into one result
        static SimulatedMarkerTrackingResult GetMarsCameraTrackingQuality(SynthesizedMarker marker, Camera cam)
        {
            var markerTrans = marker.transform;
            var markerPos = markerTrans.position;
            var markerUp = markerTrans.up;

            // tolerance > 1 allows tracking loss to happen when most of the marker goes out, not just the center
            const float relaxedTolerance = 1.1f;
            // if the marker is outside the camera frustum, the device can't see/track it anymore
            if (!SimulatedTrackingUtils.PointInFrustum(cam, markerPos, relaxedTolerance))
                return new SimulatedMarkerTrackingResult(0f, TrackingFailureCause.OutOfFrustum);

            var camTrans = cam.transform;
            var camPos = camTrans.position;
            var camForward = camTrans.forward;

            var distance = Vector3.Distance(camPos, markerPos);
            var distanceQuality = GetDistanceQuality(marker.Extents, distance);
            // markers that are too far away can't be tracked
            if (distanceQuality <= 0f)
                return new SimulatedMarkerTrackingResult(0f, TrackingFailureCause.OutOfRange);

            // assume marker isn't occluded by environment in the case where the physics scene is not available
            var occluded = false;
            var hitCount = 0;
#if UNITY_EDITOR
            var simScene = EditorOnlyDelegates.GetSimulatedEnvironmentScene();
            if (simScene.IsValid())
            {
                var physicScene = simScene.GetPhysicsScene();
                if (physicScene.IsValid())
                    occluded = TestPointOcclusion(physicScene, camPos, markerPos, out hitCount);
            }
#endif
            if (occluded)
                return new SimulatedMarkerTrackingResult(0f, TrackingFailureCause.Occluded, k_RayHits[0].point, hitCount);

            var alignmentQuality = GetImageAlignmentQuality(markerUp, camForward);
            // this is important to consider in combination with the surface viewing angle test,
            // because the camera's forward can be aligned with the marker's normal without actually looking at the marker
            var lookDirQuality = GetLookDirectionQuality(markerPos, camPos, camForward);

            return new SimulatedMarkerTrackingResult(alignmentQuality * lookDirQuality * distanceQuality);
        }

        /// <summary>
        /// Given the marker size and the camera distance, return a 0-1 number indicating how that affects tracking
        /// </summary>
        static float GetDistanceQuality(Vector2 bounds2d, float distance)
        {
            // the reference size assumes that a marker that has an average side length of 10cm will begin tracking at 2.5m.
            const float referenceSize = 0.1f;
            const float referenceDistance = 2.5f;
            var boundsVariance = (bounds2d.x + bounds2d.y) * 0.5f / referenceSize;
            var maxRange = boundsVariance * referenceDistance;
            if (distance > maxRange)
                return 0f;

            const float perfectTrackingRangePortion = 0.4f;
            var perfectRange = maxRange * perfectTrackingRangePortion;
            if (distance < perfectRange)
                return 1f;

            // quality modifier is a function of how far between perfect and failure ranges the distance is
            var portion = 1f - (distance - perfectRange) / (maxRange - perfectRange);

            const float minQualityModifier = 0.5f;
            return Mathf.Lerp(minQualityModifier,1f,portion);
        }

        static bool TestPointOcclusion(PhysicsScene physicsScene, Vector3 camPosition, Vector3 lookPosition, out int hitCount)
        {
            return TestPointOcclusion(physicsScene, k_RayHits, camPosition, lookPosition, true, out hitCount);
        }

        static bool TestPointOcclusion(PhysicsScene physicsScene, RaycastHit[] hits, Vector3 camPosition, Vector3 lookPosition, bool ignoreClose, out int hitCount)
        {
            var direction = lookPosition - camPosition;
            var distance = Vector3.Distance(camPosition, lookPosition);
            hitCount  = physicsScene.Raycast(camPosition, direction, hits, distance);

            // without ignoring collisions very close to the marker, such as surfaces it is on or
            // the marker renderer itself, the raycast test can make the marker can appear occluded when it is not
            if (!ignoreClose)
                return hitCount > 0;

            var ignoredCount = 0;
            for (var i = 0; i < hitCount; i++)
            {
                // we want to ignore collisions within 0.05m
                const float ignoreHitSqrMagnitude = 0.05f * 0.05f;
                if (Vector3.SqrMagnitude(lookPosition - hits[i].point) < ignoreHitSqrMagnitude)
                    ignoredCount++;
            }

            hitCount -= ignoredCount;
            return hitCount > 0;
        }

        static MARSTrackingState GetTrackingState(SynthesizedMarker marker, Camera marsCam)
        {
            var result = GetMarsCameraTrackingQuality(marker, marsCam);
            return GetTrackingState(result.Quality);
        }

        static MARSTrackingState GetTrackingState(float trackingQuality)
        {
            const float trackingLossThreshold = 0.1f;
            if (trackingQuality <= trackingLossThreshold)
                return MARSTrackingState.Unknown;

            const float limitedTrackingThreshold = 0.3f;
            return trackingQuality <= limitedTrackingThreshold ? MARSTrackingState.Limited : MARSTrackingState.Tracking;
        }

        void RemoveAllTrackables()
        {
            foreach (var synthMarker in m_SynthMarkers)
            {
                if (synthMarker == null)
                    continue;

                var mrMarker = synthMarker.GetData();
                if (!m_DiscoveredTrackables.Contains(mrMarker.id))
                    continue;

                RemoveTrackable(mrMarker);
                m_DiscoveredTrackables.Remove(mrMarker.id);
            }

            m_SynthMarkers.Clear();
        }

        void OnDrawGizmos()
        {
#if UNITY_EDITOR
            if (!MarsDebugSettings.SimDiscoveryImageMarkerDebug || m_SynthMarkers.Count == 0)
                return;

            // leaving blank frames helps with visual intelligibility of the debug data while moving the camera
            const int drawingFrameInterval = 6;
            if (Time.frameCount % drawingFrameInterval != 0)
                return;

            var marsCam = MarsRuntimeUtils.GetActiveCamera();
            var camTrans = marsCam.transform;
            var camPosition = camTrans.position;
            // draw camera forward, as a visual reference for the  tracking lines
            Debug.DrawLine(camPosition, camPosition + camTrans.forward, Color.cyan, 0.1f);

            foreach (var marker in m_SynthMarkers)
            {
                var trackingResult = GetMarsCameraTrackingQuality(marker, marsCam);
                DrawMarkerTrackingDebugLine(marker.transform, camTrans, trackingResult);
            }
#endif
        }

        static void DrawMarkerTrackingDebugLine(Transform markerTransform, Transform cameraTransform, SimulatedMarkerTrackingResult trackingResult)
        {
#if UNITY_EDITOR
            var camPos = cameraTransform.position;
            var markerPos = markerTransform.position;
            const float qualityLineDuration = 0.5f;

            switch (trackingResult.FailureCause)
            {
                case TrackingFailureCause.None:
                    Debug.DrawLine(camPos, markerPos, Color.Lerp(Color.red, Color.green, trackingResult.Quality), qualityLineDuration);
                    break;
                case TrackingFailureCause.OutOfFrustum:
                    Debug.DrawLine(camPos, markerPos, Color.black, qualityLineDuration);
                    break;
                case TrackingFailureCause.OutOfRange:
                    Debug.DrawLine(camPos, markerPos, Color.gray, qualityLineDuration);
                    break;
                case TrackingFailureCause.Occluded:
                    Debug.DrawLine(camPos, trackingResult.FirstOcclusionPoint, Color.magenta, qualityLineDuration);
                    break;
            }
#endif
        }
    }
#else
    public class SimulatedDiscoveryMarkerProvider : MonoBehaviour { }
#endif
}
