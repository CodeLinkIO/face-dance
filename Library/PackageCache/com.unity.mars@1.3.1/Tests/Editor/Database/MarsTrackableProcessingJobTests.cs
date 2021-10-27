#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using Random = UnityEngine.Random;

namespace Unity.MARS.Data.Tests
{
    class MarsTrackableProcessingJobTests
    {
        const int k_PlaneCount = 10;

        MARSTrackableDataProvider<MRPlane> m_PlaneDataProvider = new MARSTrackableDataProvider<MRPlane>();

        MRPlane[] m_ProvidedPlanes = new MRPlane[k_PlaneCount];
        List<KeyValuePair<int, MRPlane>> m_SortedPlanes;

        [OneTimeSetUp]
        public void Setup()
        {
            for (int i = 0; i < k_PlaneCount; i++)
            {
                var pose = new Pose(Random.insideUnitSphere * 5f + Random.onUnitSphere, Quaternion.identity);
                var plane = new MRPlane
                {
                    id = MarsTrackableId.Create(),
                    extents = new Vector2(Random.value + 1f, Random.value + 1f),
                    pose = pose
                };
                m_ProvidedPlanes[i] = plane;
            }
        }

        [SetUp]
        public void SetupEach()
        {
            m_SortedPlanes = null;
            m_PlaneDataProvider = new MARSTrackableDataProvider<MRPlane>();
            foreach(var plane in m_ProvidedPlanes)
                m_PlaneDataProvider.AddOrUpdateData(plane);
        }

        [Test]
        public void RegisteringProcessingJob_ReturnsList()
        {
            Assert.IsNull(m_SortedPlanes);
            m_SortedPlanes = m_PlaneDataProvider.RegisterProcessingJob(ProcessingJobType.ElevationSorting);
            Assert.IsNotNull(m_SortedPlanes);
        }

        [Test]
        public void UnregisteringProcessingJob_ReturnsNegativeIfNotPreviouslyRegistered()
        {
            Assert.AreEqual(-1, m_PlaneDataProvider.UnregisterProcessingJob(ProcessingJobType.ElevationSorting));
        }

        [Test]
        public void UnregisteringProcessingJob_ReturnsZeroIfWasLastSubscriber()
        {
            m_PlaneDataProvider.RegisterProcessingJob(ProcessingJobType.ElevationSorting);
            Assert.Zero(m_PlaneDataProvider.UnregisterProcessingJob(ProcessingJobType.ElevationSorting));
        }

        [Test]
        public void UnregisteringProcessingJob_ReturnsFalseIfOthersStillSubscribed()
        {
            // fake like two different reasoning APIs registered for this job
            m_PlaneDataProvider.RegisterProcessingJob(ProcessingJobType.ElevationSorting);
            m_PlaneDataProvider.RegisterProcessingJob(ProcessingJobType.ElevationSorting);
            Assert.AreEqual(1, m_PlaneDataProvider.UnregisterProcessingJob(ProcessingJobType.ElevationSorting));
        }

        [Test]
        public void RunningJobsFillsProcessedList()
        {
            m_SortedPlanes = m_PlaneDataProvider.RegisterProcessingJob(ProcessingJobType.ElevationSorting);
            Assert.Zero(m_SortedPlanes.Count);
            m_PlaneDataProvider.RunProcessingJobs();
            Assert.AreEqual(k_PlaneCount, m_SortedPlanes.Count);
        }

        [Test]
        public void ElevationSortingJob_SortsProcessedListByElevation()
        {
            m_SortedPlanes = m_PlaneDataProvider.RegisterProcessingJob(ProcessingJobType.ElevationSorting);
            m_PlaneDataProvider.RunProcessingJobs();
            Assert.AreEqual(k_PlaneCount, m_SortedPlanes.Count);

            float previous = Single.MinValue;
            foreach (var data in m_SortedPlanes)
            {
                var elevation = data.Value.pose.position.y;
                Assert.GreaterOrEqual(elevation, previous);
                previous = elevation;
            }
        }

    }
}
#endif
