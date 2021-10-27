using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Providers
{
    [AddComponentMenu("")]
    [ProviderSelectionOptions(ProviderPriorities.StubProviderPriority)]
    class StubPointCloudProvider : StubProvider, IProvidesPointCloud
    {
#pragma warning disable 67
        public event Action<Dictionary<MarsTrackableId, PointCloudData>> PointCloudUpdated;
#pragma warning restore 67

        public override void ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesPointCloud>(obj);
        }

        public Dictionary<MarsTrackableId, PointCloudData> GetPoints() { return default; }

        public void StopDetectingPoints() { }

        public void StartDetectingPoints() { }
    }
}
