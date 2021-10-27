#if ARSUBSYSTEMS_2_1_OR_NEWER
using System.Collections.Generic;
using Unity.Collections;
using Unity.MARS.Data;
using Unity.MARS.MARSUtils;
using Unity.MARS.Providers;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace Unity.MARS.XRSubsystem
{
    /// <summary>
    /// Raycast implementation for MARS XR Subsystems.
    /// </summary>
    public sealed class RaycastSubsystem : XRRaycastSubsystem, IMarsXRSubsystem
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

        // Hit testing in simulation doesn't currently work (https://jira.unity3d.com/browse/MARS-561)
        // so rather than using IUsesMRHitTesting we track and raycast against simulated planes
        // ourselves.
#if ARSUBSYSTEMS_3_OR_NEWER
        class MARSXRProvider : Provider, IMarsXRSubscriber, IUsesPlaneFinding
#else
        class MARSXRProvider : IProvider, IMarsXRSubscriber, IUsesPlaneFinding
#endif
        {
            Dictionary<MarsTrackableId, MRPlane> m_Planes = new Dictionary<MarsTrackableId, MRPlane>();

            // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
            static readonly List<XRRaycastHit> k_Hits = new List<XRRaycastHit>();

            IProvidesPlaneFinding IFunctionalitySubscriber<IProvidesPlaneFinding>.provider { get; set; }

            void PlaneAdded(MRPlane plane)
            {
                m_Planes[plane.id] = plane;
            }

            void PlaneUpdated(MRPlane plane)
            {
                m_Planes[plane.id] = plane;
            }

            void PlaneRemoved(MRPlane plane)
            {
                m_Planes.Remove(plane.id);
            }

            public override NativeArray<XRRaycastHit> Raycast(XRRaycastHit defaultRaycastHit, Ray ray,
                TrackableType trackableTypeMask, Allocator allocator)
            {
                k_Hits.Clear();
                foreach (var marsPlane in m_Planes.Values)
                {
                    var plane = new Plane(marsPlane.pose.up, marsPlane.pose.position);
                    if (plane.Raycast(ray, out var distance))
                    {
                        var worldSpacePoint = ray.GetPoint(distance);
                        var planeSpacePoint =
                            Quaternion.Inverse(marsPlane.pose.rotation) * (worldSpacePoint - marsPlane.pose.position);

                        var hitType = trackableTypeMask & TrackableType.PlaneWithinInfinity;

                        if (marsPlane.vertices != null &&
                            trackableTypeMask.HasFlag(TrackableType.PlaneWithinPolygon) &&
                            GeometryUtils.PointInPolygon(planeSpacePoint, marsPlane.vertices))
                        {
                            hitType |= TrackableType.PlaneWithinPolygon;
                        }

                        if (trackableTypeMask.HasFlag(TrackableType.PlaneWithinBounds) &&
                            PointInExtents(planeSpacePoint, marsPlane.extents))
                        {
                            hitType |= TrackableType.PlaneWithinBounds;
                        }

                        if (hitType != 0)
                        {
                            k_Hits.Add(new XRRaycastHit
                            {
                                trackableId = new TrackableId(marsPlane.id.subId1, marsPlane.id.subId2),
                                pose = new Pose(worldSpacePoint, marsPlane.pose.rotation),
                                distance = distance,
                                hitType = hitType
                            });
                        }
                    }
                }

                if (k_Hits.Count > 1)
                    k_Hits.Sort((a, b) => a.distance.CompareTo(b.distance));

                return new NativeArray<XRRaycastHit>(k_Hits.ToArray(), allocator);
            }

            public override NativeArray<XRRaycastHit> Raycast(XRRaycastHit defaultRaycastHit, Vector2 screenPoint,
                TrackableType trackableTypeMask, Allocator allocator)
            {
                // ARF normalizes to the Screen dimensions, so convert back to pixels.
                screenPoint.x *= Screen.width;
                screenPoint.y *= Screen.height;

                var camera = MarsRuntimeUtils.GetActiveCamera(true);
                var ray = camera.ScreenPointToRay(screenPoint);
                return Raycast(defaultRaycastHit, ray, trackableTypeMask, allocator);
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
                m_Planes.Clear();
            }

            // Is point within extents in the X-Z plane?
            static bool PointInExtents(Vector3 p, Vector2 extents)
            {
                return Mathf.Abs(p.x) <= extents.x && Mathf.Abs(p.z) <= extents.y;
            }
        }


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
            XRRaycastSubsystemDescriptor.RegisterDescriptor(new XRRaycastSubsystemDescriptor.Cinfo
            {
                id = "MARS-Raycast",
#if ARSUBSYSTEMS_4_OR_NEWER && UNITY_2020_2_OR_NEWER
                providerType = typeof(RaycastSubsystem.MARSXRProvider),
                subsystemTypeOverride = typeof(RaycastSubsystem),
#else
                subsystemImplementationType = typeof(RaycastSubsystem),
#endif
                supportsViewportBasedRaycast = true,
                supportsWorldBasedRaycast = true,
                supportedTrackableTypes = TrackableType.Planes,
            });
        }
    }
}
#endif
