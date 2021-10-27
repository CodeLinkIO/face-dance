#if ARSUBSYSTEMS_2_1_OR_NEWER
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using Unity.Collections;
using Unity.XRTools.ModuleLoader;
using Unity.MARS.Data;
using System;
using Unity.Jobs;
using System.Collections.Generic;
using Unity.MARS.Providers;

namespace Unity.MARS.XRSubsystem
{
    /// <summary>
    /// Plane subsystem implementation for MARS XR Subsystems.
    /// </summary>
    public sealed class PlaneSubsystem : XRPlaneSubsystem, IMarsXRSubsystem
    {
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
        class MARSXRProvider : Provider, IMarsXRSubscriber, IUsesPlaneFinding
#else
        class MARSXRProvider : IProvider, IMarsXRSubscriber, IUsesPlaneFinding
#endif
        {
            readonly Dictionary<MarsTrackableId, MRPlane> m_AddedPlanes = new Dictionary<MarsTrackableId, MRPlane>();
            readonly Dictionary<MarsTrackableId, MRPlane> m_UpdatedPlanes = new Dictionary<MarsTrackableId, MRPlane>();
            readonly HashSet<MarsTrackableId> m_RemovedPlanes = new HashSet<MarsTrackableId>();
            readonly Dictionary<TrackableId, MRPlane> m_Planes = new Dictionary<TrackableId, MRPlane>();

            const int k_DefaultConversionBufferCapacity = 8;
            BoundedPlane[] m_ConversionBuffer = new BoundedPlane[k_DefaultConversionBufferCapacity];
            TrackableId[] m_IdConversionBuffer = new TrackableId[k_DefaultConversionBufferCapacity];

            IProvidesPlaneFinding IFunctionalitySubscriber<IProvidesPlaneFinding>.provider { get; set; }

#if ARSUBSYSTEMS_4_OR_NEWER
            public override PlaneDetectionMode currentPlaneDetectionMode =>
                PlaneDetectionMode.Horizontal | PlaneDetectionMode.Vertical;

            public override PlaneDetectionMode requestedPlaneDetectionMode { get; set; }
#endif

            void PlaneAdded(MRPlane plane)
            {
                m_AddedPlanes.Add(plane.id, plane);
                m_Planes.Add(new TrackableId(plane.id.subId1, plane.id.subId2), plane);
            }

            void PlaneUpdated(MRPlane plane)
            {
                if (m_AddedPlanes.ContainsKey(plane.id))
                    m_AddedPlanes[plane.id] = plane;
                else
                    m_UpdatedPlanes[plane.id] = plane;
                m_Planes[new TrackableId(plane.id.subId1, plane.id.subId2)] = plane;
            }

            void PlaneRemoved(MRPlane plane)
            {
                if (!m_AddedPlanes.Remove(plane.id))
                {
                    m_UpdatedPlanes.Remove(plane.id);
                    m_RemovedPlanes.Add(plane.id);
                }

                m_Planes.Remove(new TrackableId(plane.id.subId1, plane.id.subId2));
            }

            public void SubscribeToEvents()
            {
                this.SubscribePlaneAdded(PlaneAdded);
                this.SubscribePlaneUpdated(PlaneUpdated);
                this.SubscribePlaneRemoved(PlaneRemoved);
            }

            public void UnsubscribeFromEvents()
            {
                this.UnsubscribePlaneAdded(PlaneAdded);
                this.UnsubscribePlaneUpdated(PlaneUpdated);
                this.UnsubscribePlaneRemoved(PlaneRemoved);
            }

            public override void Destroy() { }

            public override void Start() { }

            public override void Stop() { }

            public override TrackableChanges<BoundedPlane> GetChanges(BoundedPlane defaultPlane, Allocator allocator)
            {
                var changes = new TrackableChanges<BoundedPlane>(m_AddedPlanes.Count, m_UpdatedPlanes.Count, m_RemovedPlanes.Count, allocator);
                var numAddedPlanes = m_AddedPlanes.Count;
                if (numAddedPlanes > 0)
                {
                    Utils.EnsureCapacity(ref m_ConversionBuffer, numAddedPlanes);
                    var i = 0;
                    foreach (var plane in m_AddedPlanes.Values)
                        m_ConversionBuffer[i++] = BoundedPlaneFromMRPlane(plane);
                    NativeArray<BoundedPlane>.Copy(m_ConversionBuffer, changes.added, numAddedPlanes);
                    m_AddedPlanes.Clear();
                }

                var numUpdatedPlanes = m_UpdatedPlanes.Count;
                if (numUpdatedPlanes > 0)
                {
                    Utils.EnsureCapacity(ref m_ConversionBuffer, numUpdatedPlanes);
                    var i = 0;
                    foreach (var plane in m_UpdatedPlanes.Values)
                        m_ConversionBuffer[i++] = BoundedPlaneFromMRPlane(plane);
                    NativeArray<BoundedPlane>.Copy(m_ConversionBuffer, changes.updated, numUpdatedPlanes);
                    m_UpdatedPlanes.Clear();
                }

                var numRemovedPlanes = m_RemovedPlanes.Count;
                if (numRemovedPlanes > 0)
                {
                    Utils.EnsureCapacity(ref m_IdConversionBuffer, numRemovedPlanes);
                    var i = 0;
                    foreach (var id in m_RemovedPlanes)
                        m_IdConversionBuffer[i++] = new TrackableId(id.subId1, id.subId2);
                    NativeArray<TrackableId>.Copy(m_IdConversionBuffer, changes.removed, numRemovedPlanes);
                    m_RemovedPlanes.Clear();
                }

                return changes;
            }

            public override void GetBoundary(TrackableId trackableId, Allocator allocator,
                ref NativeArray<Vector2> boundary)
            {
                if (m_Planes.TryGetValue(trackableId, out var plane))
                {
                    CreateOrResizeNativeArrayIfNecessary(plane.vertices.Count, allocator, ref boundary);
                    var verticesIn = new NativeArray<Vector3>(plane.vertices.ToArray(), allocator);
                    new CopyBoundaryJob
                    {
                        verticesIn = verticesIn,
                        verticesOut = boundary
                    }.Schedule(plane.vertices.Count, 1).Complete();

                    verticesIn.Dispose();
                }
            }

            struct CopyBoundaryJob : IJobParallelFor
            {
                [ReadOnly]
                public NativeArray<Vector3> verticesIn;

                [WriteOnly]
                public NativeArray<Vector2> verticesOut;

                public void Execute(int index) { verticesOut[index] = new Vector2(verticesIn[index].x, verticesIn[index].z); }
            }
        }

        static BoundedPlane BoundedPlaneFromMRPlane(MRPlane mrPlane)
        {
            var id = new TrackableId(mrPlane.id.subId1, mrPlane.id.subId2);
            PlaneAlignment alignment;
            switch (mrPlane.alignment)
            {
                case MarsPlaneAlignment.HorizontalUp:
                    alignment = PlaneAlignment.HorizontalUp;
                    break;
                case MarsPlaneAlignment.HorizontalDown:
                    alignment = PlaneAlignment.HorizontalDown;
                    break;
                case MarsPlaneAlignment.Vertical:
                    alignment = PlaneAlignment.Vertical;
                    break;
                case MarsPlaneAlignment.NonAxis:
                    alignment = PlaneAlignment.NotAxisAligned;
                    break;
                default:
                    alignment = PlaneAlignment.None;
                    break;
            }

            var bp = new BoundedPlane(id,
                TrackableId.invalidId,
                mrPlane.pose,
                mrPlane.center,
                mrPlane.extents,
                alignment,
                TrackingState.Tracking,
#if ARSUBSYSTEMS_3_OR_NEWER
                IntPtr.Zero,
                PlaneClassification.None);
#else
                IntPtr.Zero);
#endif
            return bp;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
            XRPlaneSubsystemDescriptor.Create(new XRPlaneSubsystemDescriptor.Cinfo
            {
                id = "MARS-Plane",
#if ARSUBSYSTEMS_4_OR_NEWER && UNITY_2020_2_OR_NEWER
                providerType = typeof(PlaneSubsystem.MARSXRProvider),
                subsystemTypeOverride = typeof(PlaneSubsystem),
#else
                subsystemImplementationType = typeof(PlaneSubsystem),
#endif
                supportsHorizontalPlaneDetection = true,
                supportsVerticalPlaneDetection = true,
                supportsArbitraryPlaneDetection = true,
                supportsBoundaryVertices = true,
#if ARSUBSYSTEMS_3_OR_NEWER
                supportsClassification = false,
#endif
            });
        }
    }
}
#endif
