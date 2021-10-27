#if ARFOUNDATION_2_1_OR_NEWER
using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Random = UnityEngine.Random;

namespace Unity.MARS.Providers.ARFoundation
{
    [ProviderSelectionOptions(excludedPlatforms: new []{
        RuntimePlatform.WindowsEditor,
        RuntimePlatform.OSXEditor,
        RuntimePlatform.LinuxEditor,
        RuntimePlatform.WindowsPlayer,
        RuntimePlatform.OSXPlayer,
        RuntimePlatform.LinuxPlayer
    })]
    class ARFoundationPointCloudProvider : IProvidesPointCloud
    {
#if UNITY_EDITOR
        const int k_NumPoints = 100;
        const float k_PointCloudSize = 5;
#endif

        ARPointCloudManager m_ARPointCloudManager;
        ARPointCloudManager m_NewARPointCloudManager;

        readonly Dictionary<MarsTrackableId, PointCloudData> m_Data = new Dictionary<MarsTrackableId, PointCloudData>();

        NativeArray<ulong> m_Identifiers;
        NativeArray<Vector3> m_Positions;
        NativeArray<float> m_ConfidenceValues;

        public event Action<Dictionary<MarsTrackableId, PointCloudData>> PointCloudUpdated;

        public void StopDetectingPoints()
        {
            if (m_ARPointCloudManager && m_ARPointCloudManager.subsystem != null)
                m_ARPointCloudManager.subsystem.Stop();
        }

        public void StartDetectingPoints()
        {
            if (m_ARPointCloudManager && m_ARPointCloudManager.subsystem != null)
                m_ARPointCloudManager.subsystem.Start();
        }

        void IFunctionalityProvider.LoadProvider()
        {
            ARFoundationSessionProvider.RequireARSession();
            var currentSession = ARFoundationSessionProvider.currentSession;
            if (currentSession)
            {
                m_ARPointCloudManager = UnityEngine.Object.FindObjectOfType<ARPointCloudManager>();
                if (!m_ARPointCloudManager)
                {
                    m_ARPointCloudManager = currentSession.gameObject.AddComponent<ARPointCloudManager>();
                    m_ARPointCloudManager.hideFlags = HideFlags.DontSave;
                    m_NewARPointCloudManager = m_ARPointCloudManager;
                }

                m_ARPointCloudManager.pointCloudsChanged += ARPointCloudManagerOnPointCloudsChanged;
            }

#if UNITY_EDITOR
            var data = new PointCloudData();
            m_Identifiers = new NativeArray<ulong>(k_NumPoints, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            m_Positions = new NativeArray<Vector3>(k_NumPoints, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            m_ConfidenceValues = new NativeArray<float>(k_NumPoints, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            for (var i = 0; i < k_NumPoints; i++)
            {
                m_Identifiers[i] = (ulong)i;
                m_Positions[i] = Random.insideUnitSphere * k_PointCloudSize;
                m_ConfidenceValues[i] = Random.Range(0, 1);
            }

            data.Identifiers = new NativeSlice<ulong>(m_Identifiers);
            data.Positions = new NativeSlice<Vector3>(m_Positions);
            data.ConfidenceValues = new NativeSlice<float>(m_ConfidenceValues);
            m_Data[MarsTrackableId.Create()] = data;

            EditorApplication.delayCall += () =>
            {
                if (PointCloudUpdated != null)
                    PointCloudUpdated(GetPoints());
            };
#endif
        }

        void ARPointCloudManagerOnPointCloudsChanged(ARPointCloudChangedEventArgs pointCloudEvent)
        {
            UpdatePoints();
            if (PointCloudUpdated != null)
                PointCloudUpdated(GetPoints());
        }

        void IFunctionalityProvider.UnloadProvider()
        {
            m_ARPointCloudManager.pointCloudsChanged -= ARPointCloudManagerOnPointCloudsChanged;
            if (m_NewARPointCloudManager)
                UnityObjectUtils.Destroy(m_NewARPointCloudManager);

            ARFoundationSessionProvider.TearDownARSession();

            if (m_Identifiers.IsCreated)
                m_Identifiers.Dispose();

            if (m_Positions.IsCreated)
                m_Positions.Dispose();

            if(m_ConfidenceValues.IsCreated)
                m_ConfidenceValues.Dispose();
        }

        public Dictionary<MarsTrackableId, PointCloudData> GetPoints()
        {
            return m_Data;
        }

        void UpdatePoints()
        {
            if (m_ARPointCloudManager == null)
                return;

            var trackables = m_ARPointCloudManager.trackables;
            m_Data.Clear();
            foreach (var pointCloud in trackables)
            {
                var data = new PointCloudData
                {
                    Identifiers = pointCloud.identifiers,
                    Positions = pointCloud.positions,
                    ConfidenceValues = pointCloud.confidenceValues
                };

                var id = pointCloud.trackableId;
                var marsTrackableId = new MarsTrackableId(id.subId1, id.subId2);
                m_Data[marsTrackableId] = data;
            }
        }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesPointCloud>(obj);
        }
    }
}
#endif
