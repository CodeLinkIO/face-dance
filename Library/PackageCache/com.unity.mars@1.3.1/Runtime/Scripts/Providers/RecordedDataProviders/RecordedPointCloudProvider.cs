using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.MARS.Data;
using Unity.MARS.Data.Recorded;
using Unity.MARS.Providers;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Playables;

namespace Unity.MARS.Recording.Providers
{
    [ProviderSelectionOptions(ProviderPriorities.RecordedProviderPriority, disallowAutoCreation:true)]
    public class RecordedPointCloudProvider : MonoBehaviour, IRecordedDataProvider, IProvidesPointCloud, INotificationReceiver
    {
        const int k_InitialCapacity = 256;

        bool m_Paused;

        readonly List<PointCloudEventMarker> m_BufferedPointCloudEvents = new List<PointCloudEventMarker>();

        /// <inheritdoc />
        public event Action<Dictionary<MarsTrackableId, PointCloudData>> PointCloudUpdated;

        readonly Dictionary<MarsTrackableId, PointCloudData> m_Data = new Dictionary<MarsTrackableId, PointCloudData>();

        NativeArray<ulong> m_Identifiers;
        NativeArray<Vector3> m_Positions;
        NativeArray<float> m_ConfidenceValues;

        /// <inheritdoc />
        void IFunctionalityProvider.LoadProvider()
        {
            m_Identifiers = new NativeArray<ulong>(k_InitialCapacity, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            m_Positions = new NativeArray<Vector3>(k_InitialCapacity, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            m_ConfidenceValues = new NativeArray<float>(k_InitialCapacity, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
        }

        /// <inheritdoc />
        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesPointCloud>(obj);
        }

        /// <inheritdoc />
        void IFunctionalityProvider.UnloadProvider()
        {
            if (m_Identifiers.IsCreated)
                m_Identifiers.Dispose();

            if (m_Positions.IsCreated)
                m_Positions.Dispose();

            if(m_ConfidenceValues.IsCreated)
                m_ConfidenceValues.Dispose();
        }

        /// <inheritdoc />
        public void ClearData()
        {
            m_Data.Clear();
            m_BufferedPointCloudEvents.Clear();
        }

        /// <inheritdoc />
        public void OnNotify(Playable origin, INotification notification, object context)
        {
            var pointCloudEvent = notification as PointCloudEventMarker;
            if (pointCloudEvent == null)
                return;

            if (m_Paused)
                m_BufferedPointCloudEvents.Add(pointCloudEvent);
            else
                ProcessPointCloudEvent(pointCloudEvent);
        }

        void ProcessPointCloudEvent(PointCloudEventMarker pointCloudEvent)
        {
            var idCount = 0;
            var positionCount = 0;
            var confidenceValueCount = 0;
            foreach (var pointCloud in pointCloudEvent.Data)
            {
                var identifiers = pointCloud.Identifiers;
                if (identifiers != null)
                    idCount += identifiers.Length;

                var positions = pointCloud.Positions;
                if (positions != null)
                    positionCount += positions.Length;

                var confidenceValues = pointCloud.ConfidenceValues;
                if (confidenceValues != null)
                    confidenceValueCount += confidenceValues.Length;
            }

            NativeArrayUtils.EnsureCapacity(ref m_Identifiers, idCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            NativeArrayUtils.EnsureCapacity(ref m_Positions, idCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            NativeArrayUtils.EnsureCapacity(ref m_ConfidenceValues, idCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

            idCount = 0;
            positionCount = 0;
            confidenceValueCount = 0;
            m_Data.Clear();
            foreach (var pointCloud in pointCloudEvent.Data)
            {
                var data = new PointCloudData();
                var positions = pointCloud.Positions;
                if  (positions == null)
                    continue;

                var length = positions.Length;
                for (var i = 0; i < length; i++)
                {
                    m_Positions[i + positionCount] = positions[i];
                }

                data.Positions = new NativeSlice<Vector3>(m_Positions, positionCount, length);
                positionCount += length;

                var identifiers = pointCloud.Identifiers;
                if (identifiers != null && identifiers.Length == length)
                {
                    for (var i = 0; i < length; i++)
                    {
                        m_Identifiers[i + idCount] = identifiers[i];
                    }

                    data.Identifiers = new NativeSlice<ulong>(m_Identifiers, idCount, length);
                    idCount += length;
                }

                var confidenceValues = pointCloud.ConfidenceValues;
                if (confidenceValues != null && confidenceValues.Length == length)
                {
                    for (var i = 0; i < length; i++)
                    {
                        m_ConfidenceValues[i + confidenceValueCount] = confidenceValues[i];
                    }

                    data.ConfidenceValues = new NativeSlice<float>(m_ConfidenceValues, confidenceValueCount, length);
                    confidenceValueCount += length;
                }

                m_Data[pointCloud.Id] = data;
            }

            PointCloudUpdated?.Invoke(GetPoints());
        }

        /// <inheritdoc />
        public Dictionary<MarsTrackableId, PointCloudData> GetPoints() { return m_Data; }

        /// <inheritdoc />
        public void StopDetectingPoints() { m_Paused = true; }

        /// <inheritdoc />
        public void StartDetectingPoints()
        {
            m_Paused = false;
            foreach (var pointCloudEvent in m_BufferedPointCloudEvents)
            {
                ProcessPointCloudEvent(pointCloudEvent);
            }

            m_BufferedPointCloudEvents.Clear();
        }
    }
}
