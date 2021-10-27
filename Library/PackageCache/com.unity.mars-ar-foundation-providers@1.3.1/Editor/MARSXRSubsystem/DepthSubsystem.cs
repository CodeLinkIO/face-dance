#if ARSUBSYSTEMS_2_1_OR_NEWER
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace Unity.MARS.XRSubsystem
{
    /// <summary>
    /// Depth subsystem implementation for MARS XR Subsystems.
    /// </summary>
    public sealed class DepthSubsystem : XRDepthSubsystem, IMarsXRSubsystem
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
        protected override IDepthApi GetInterface() => CreateMarsProvider();
#endif

        MARSXRProvider CreateMarsProvider()
        {
            var marsProvider = new MARSXRProvider();
            m_FunctionalitySubscriber = marsProvider;
            return marsProvider;
        }
#endif

#if ARSUBSYSTEMS_3_OR_NEWER
        class MARSXRProvider : Provider, IMarsXRSubscriber, IUsesPointCloud
#else
        class MARSXRProvider : IDepthApi, IMarsXRSubscriber, IUsesPointCloud
#endif
        {
            Dictionary<MarsTrackableId, PointCloudData> m_PointClouds;
            readonly List<MarsTrackableId> m_PreviousIds = new List<MarsTrackableId>();

            const int k_DefaultConversionBufferCapacity = 8;
            XRPointCloud[] m_ConversionBuffer = new XRPointCloud[k_DefaultConversionBufferCapacity];

            IProvidesPointCloud IFunctionalitySubscriber<IProvidesPointCloud>.provider { get; set; }

            void PointCloudUpdated(Dictionary<MarsTrackableId, PointCloudData> data) { m_PointClouds = data; }

            public void SubscribeToEvents() { this.SubscribePointCloudUpdated(PointCloudUpdated); }

            public void UnsubscribeFromEvents() { this.UnsubscribePointCloudUpdated(PointCloudUpdated); }

            public override TrackableChanges<XRPointCloud> GetChanges(XRPointCloud defaultPointCloud,
                Allocator allocator)
            {
                var pointClouds = m_PointClouds;

                var added = pointClouds.Keys.Except(m_PreviousIds);
                var updated = pointClouds.Keys.Intersect(m_PreviousIds);
                var removed = m_PreviousIds.Except(pointClouds.Keys);
                var numAdded = added.Count();
                var numUpdated = updated.Count();
                var numRemoved = removed.Count();

                var changes = new TrackableChanges<XRPointCloud>(numAdded, numUpdated, numRemoved, allocator);
                if (numAdded > 0)
                {
                    Utils.EnsureCapacity(ref m_ConversionBuffer, numAdded);
                    var i = 0;
                    foreach (var pointCloud in added)
                    {
                        m_ConversionBuffer[i++] = new XRPointCloud(new TrackableId(pointCloud.subId1, pointCloud.subId2),
                            Pose.identity, TrackingState.Tracking, IntPtr.Zero);
                    }

                    NativeArray<XRPointCloud>.Copy(m_ConversionBuffer, changes.added, numAdded);
                }

                if (numUpdated > 0)
                {
                    Utils.EnsureCapacity(ref m_ConversionBuffer, numUpdated);
                    var i = 0;
                    foreach (var pointCloud in updated)
                    {
                        m_ConversionBuffer[i++] = new XRPointCloud(new TrackableId(pointCloud.subId1, pointCloud.subId2),
                            Pose.identity, TrackingState.Tracking, IntPtr.Zero);
                    }

                    NativeArray<XRPointCloud>.Copy(m_ConversionBuffer, changes.updated, numUpdated);
                }

                if (numRemoved > 0)
                {
                    var removedArray = removed.Select(id => new TrackableId(id.subId1, id.subId2)).ToArray();
                    changes.removed.CopyFrom(removedArray);
                }

                m_PreviousIds.Clear();
                m_PreviousIds.AddRange(pointClouds.Keys);

                return changes;
            }

            public override XRPointCloudData GetPointCloudData(TrackableId trackableId, Allocator allocator)
            {
                var id = new MarsTrackableId(trackableId.subId1, trackableId.subId2);
                if (m_PointClouds.TryGetValue(id, out var pointCloud))
                {
                    var result = new XRPointCloudData();
                    if (pointCloud.Identifiers.HasValue)
                    {
                        result.identifiers = new NativeArray<ulong>(pointCloud.Identifiers.Value.Length, allocator);
                        pointCloud.Identifiers.Value.CopyTo(result.identifiers);
                    }

                    if (pointCloud.Positions.HasValue)
                    {
                        result.positions = new NativeArray<Vector3>(pointCloud.Positions.Value.Length, allocator);
                        pointCloud.Positions.Value.CopyTo(result.positions);
                    }

                    if (pointCloud.ConfidenceValues.HasValue)
                    {
                        result.confidenceValues =
                            new NativeArray<float>(pointCloud.ConfidenceValues.Value.Length, allocator);
                        pointCloud.ConfidenceValues.Value.CopyTo(result.confidenceValues);
                    }

                    return result;
                }

                return default;
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
            XRDepthSubsystemDescriptor.RegisterDescriptor(new XRDepthSubsystemDescriptor.Cinfo
            {
                id = "MARS-Depth",
#if ARSUBSYSTEMS_4_OR_NEWER && UNITY_2020_2_OR_NEWER
                providerType = typeof(DepthSubsystem.MARSXRProvider),
                subsystemTypeOverride = typeof(DepthSubsystem),
#else
                implementationType = typeof(DepthSubsystem),
#endif
                supportsFeaturePoints = true,
                supportsConfidence = true,
                supportsUniqueIds = true,
            });
        }
    }
}
#endif
