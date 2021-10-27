using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Providers
{
    [AddComponentMenu("")]
    [ProviderSelectionOptions(ProviderPriorities.StubProviderPriority)]
    class StubPlanesProvider : StubProvider, IProvidesPlaneFinding
    {
#pragma warning disable 67
        public event Action<MRPlane> planeAdded;
        public event Action<MRPlane> planeUpdated;
        public event Action<MRPlane> planeRemoved;
#pragma warning restore 67

        public override void ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesPlaneFinding>(obj);
        }

        public void GetPlanes(List<MRPlane> planes) { }

        public void StopDetectingPlanes() { }

        public void StartDetectingPlanes() { }
    }
}
