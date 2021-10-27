#if ARSUBSYSTEMS_2_1_OR_NEWER
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using Unity.Collections;
using Unity.XRTools.ModuleLoader;
using Unity.MARS.Data;
using Unity.MARS.Providers;
using UnityEditor;

namespace Unity.MARS.XRSubsystem
{
    /// <summary>
    /// Image marker subsystem implementation for MARS XR Subsystems.
    /// </summary>
    public sealed class ImageMarkerSubsystem : XRImageTrackingSubsystem, IMarsXRSubsystem
    {
        internal const string Id = "MARS-ImageTracking";

        IMarsXRSubscriber m_FunctionalitySubscriber;

        public IMarsXRSubscriber FunctionalitySubscriber
        {
            get
            {
#if ARSUBSYSTEMS_4_OR_NEWER && UNITY_2020_2_OR_NEWER
                if (m_FunctionalitySubscriber == null)
                    m_FunctionalitySubscriber = provider as IMarsXRSubscriber;
#endif

                return m_FunctionalitySubscriber;
            }
        }

#if !(ARSUBSYSTEMS_4_OR_NEWER && UNITY_2020_2_OR_NEWER)
#if ARSUBSYSTEMS_3_OR_NEWER
        protected override Provider CreateProvider() => CreateMarsProvider();
#else
        protected override IProvider CreateProvider() => CreateMarsProvider();
#endif

        MARSXRProvider CreateMarsProvider()
        {
            var marsProvider = new MARSXRProvider();
            m_FunctionalitySubscriber = marsProvider;
            return marsProvider;
        }
#endif

#if ARSUBSYSTEMS_3_OR_NEWER
        class MARSXRProvider : Provider, IMarsXRSubscriber, IUsesMarkerTracking
#else
        class MARSXRProvider : IProvider, IMarsXRSubscriber, IUsesMarkerTracking
#endif
        {
            readonly List<MRMarker> m_Added = new List<MRMarker>();
            readonly Dictionary<MarsTrackableId, MRMarker> m_Updated = new Dictionary<MarsTrackableId, MRMarker>();
            readonly HashSet<MarsTrackableId> m_Removed = new HashSet<MarsTrackableId>();

            const int k_DefaultConversionBufferCapacity = 8;
            XRTrackedImage[] m_ConversionBuffer = new XRTrackedImage[k_DefaultConversionBufferCapacity];
            TrackableId[] m_IdConversionBuffer = new TrackableId[k_DefaultConversionBufferCapacity];

#if ARSUBSYSTEMS_3_OR_NEWER
            int m_MaxMovingImages;
#endif

            // A map of texture asset guids to image marker library member guids
            readonly Dictionary<Guid, Guid> m_MarkerGuids = new Dictionary<Guid, Guid>();

            IProvidesMarkerTracking IFunctionalitySubscriber<IProvidesMarkerTracking>.provider { get; set; }

            void MarkerAdded(MRMarker marker) { m_Added.Add(marker); }

            void MarkerUpdated(MRMarker marker) { m_Updated[marker.id] = marker; }

            void MarkerRemoved(MRMarker marker) { m_Removed.Add(marker.id); }

            public void SubscribeToEvents()
            {
                this.SubscribeMarkerAdded(MarkerAdded);
                this.SubscribeMarkerUpdated(MarkerUpdated);
                this.SubscribeMarkerRemoved(MarkerRemoved);
            }

            public void UnsubscribeFromEvents()
            {
                this.UnsubscribeMarkerAdded(MarkerAdded);
                this.UnsubscribeMarkerUpdated(MarkerUpdated);
                this.UnsubscribeMarkerRemoved(MarkerRemoved);
            }

            public override void Destroy() { }

#if UNITY_2020_2_OR_NEWER
            public override void Start() { }

            public override void Stop() { }
#endif

            public override TrackableChanges<XRTrackedImage> GetChanges(XRTrackedImage defaultTrackedImage, Allocator allocator)
            {
                TrackableChanges<XRTrackedImage> changes;
                var numAddedMarkers = m_Added.Count;
                if (numAddedMarkers > 0)
                {
                    Utils.EnsureCapacity(ref m_ConversionBuffer, numAddedMarkers);
                    for (var i = 0; i < numAddedMarkers; i++)
                    {
                        var added = m_Added[i];

                        // if the same trackable ID is present more than once in a frame, the ARF validation utility
                        // will throw an error in the editor and dev builds.  Because subsystem tracking doesn't update every frame,
                        // it's possible to get the same marker in both.  Use the most recent version as an add if this happens.
                        if (m_Updated.TryGetValue(added.id, out var updatedValue))
                        {
                            m_Added[i] = updatedValue;
                            m_Updated.Remove(added.id);
                        }
                    }

                    // create this after in case any have been removed from the updated collection
                    changes = new TrackableChanges<XRTrackedImage>(m_Added.Count, m_Updated.Count, m_Removed.Count, allocator);

                    for (var i = 0; i < numAddedMarkers; i++)
                    {
                        m_ConversionBuffer[i] = TrackedImageFromMRMarker(m_Added[i]);
                    }

                    NativeArray<XRTrackedImage>.Copy(m_ConversionBuffer, changes.added, numAddedMarkers);
                    m_Added.Clear();
                }
                else
                {
                    changes = new TrackableChanges<XRTrackedImage>(m_Added.Count, m_Updated.Count, m_Removed.Count, allocator);
                }

                var numUpdatedMarkers = m_Updated.Count;
                if (numUpdatedMarkers > 0)
                {
                    Utils.EnsureCapacity(ref m_ConversionBuffer, numUpdatedMarkers);
                    var i = 0;
                    foreach (var updatedMarker in m_Updated.Values)
                    {
                        m_ConversionBuffer[i++] = TrackedImageFromMRMarker(updatedMarker);
                    }

                    NativeArray<XRTrackedImage>.Copy(m_ConversionBuffer, changes.updated, numUpdatedMarkers);
                    m_Updated.Clear();
                }

                var numRemovedMarkers = m_Removed.Count;
                if (numRemovedMarkers > 0)
                {
                    Utils.EnsureCapacity(ref m_IdConversionBuffer, numRemovedMarkers);
                    var i = 0;
                    foreach (var id in m_Removed)
                    {
                        m_IdConversionBuffer[i++] = new TrackableId(id.subId1, id.subId2);
                    }

                    NativeArray<TrackableId>.Copy(m_IdConversionBuffer, changes.removed, numRemovedMarkers);
                    m_Removed.Clear();
                }

                return changes;
            }

            XRTrackedImage TrackedImageFromMRMarker(MRMarker mrMarker)
            {
                Guid guid;
                var path = AssetDatabase.GetAssetPath(mrMarker.texture);
                var textureGuid = Guid.Parse(AssetDatabase.AssetPathToGUID(path));
                m_MarkerGuids.TryGetValue(textureGuid, out guid);
                return new XRTrackedImage(new TrackableId(mrMarker.id.subId1, mrMarker.id.subId2),
                    guid,
                    mrMarker.pose,
                    mrMarker.extents,
                    ToArfTrackingState(mrMarker.trackingState),
                    IntPtr.Zero);
            }

#if ARSUBSYSTEMS_3_OR_NEWER
            class RuntimeLibrary : RuntimeReferenceImageLibrary
            {
                XRReferenceImageLibrary m_Library;

                public override int count => m_Library.count;

                public RuntimeLibrary(XRReferenceImageLibrary library) { m_Library = library; }

                protected override XRReferenceImage GetReferenceImageAt(int index) { return m_Library[index]; }
            }

            public override RuntimeReferenceImageLibrary CreateRuntimeLibrary(XRReferenceImageLibrary serializedLibrary) { return new RuntimeLibrary(serializedLibrary); }

#if ARSUBSYSTEMS_4_OR_NEWER
            public override int requestedMaxNumberOfMovingImages { get => m_MaxMovingImages; set => m_MaxMovingImages = value; }

            public override int currentMaxNumberOfMovingImages => m_MaxMovingImages;
#else
            // it's necessary to implement this, or the system will think tracking moving images is not supported
            public override int maxNumberOfMovingImages { set => m_MaxMovingImages = value; }
#endif

#endif

#if ARSUBSYSTEMS_3_OR_NEWER
            public override RuntimeReferenceImageLibrary imageLibrary
#else
            public override XRReferenceImageLibrary imageLibrary
#endif
            {
                set
                {
                    var library = value;
                    if (library != null)
                    {
                        for (var i = 0; i < library.count; i++)
                        {
                            var marker = library[i];
                            m_MarkerGuids.Add(marker.textureGuid, marker.guid);
                        }
                    }
                    else
                        m_MarkerGuids.Clear();
                }
            }
        }

        static TrackingState ToArfTrackingState(MARSTrackingState state)
        {
            switch (state)
            {
                case MARSTrackingState.Unknown: return TrackingState.None;
                case MARSTrackingState.Limited: return TrackingState.Limited;
                case MARSTrackingState.Tracking: return TrackingState.Tracking;
                default: return TrackingState.None;
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
            XRImageTrackingSubsystemDescriptor.Create(new XRImageTrackingSubsystemDescriptor.Cinfo
            {
                id = Id,
                supportsMovingImages = true,
#if ARSUBSYSTEMS_3_OR_NEWER
                // Mutable library is marked as unsupported because we haven't verified that
                // MARS image tracking in general will work properly with runtime-modified libraries.
                supportsMutableLibrary = false,

                // the mars simulation provider for images can track at any size
                requiresPhysicalImageDimensions = false,
#endif

#if ARSUBSYSTEMS_4_OR_NEWER && UNITY_2020_2_OR_NEWER
                providerType = typeof(MARSXRProvider),
                subsystemTypeOverride = typeof(ImageMarkerSubsystem),
#else
                subsystemImplementationType = typeof(ImageMarkerSubsystem),
#endif
            });
        }
    }
}
#endif
