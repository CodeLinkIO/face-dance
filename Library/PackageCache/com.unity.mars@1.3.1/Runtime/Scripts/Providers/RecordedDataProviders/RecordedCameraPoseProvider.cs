using System;
using Unity.MARS.Data;
using Unity.MARS.Data.Recorded;
using Unity.MARS.Providers;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Recording.Providers
{
    [ProviderSelectionOptions(ProviderPriorities.RecordedProviderPriority, disallowAutoCreation:true)]
    public class RecordedCameraPoseProvider : MonoBehaviour, IProvidesCameraPose, ISteppableRecordedDataProvider
    {
#pragma warning disable 67
        /// <inheritdoc />
        public event Action<Pose> poseUpdated;
        /// <inheritdoc />
        public event Action<MRCameraTrackingState> trackingStateChanged;
#pragma warning restore 67

        /// <inheritdoc />
        void IFunctionalityProvider.LoadProvider() { }

        /// <inheritdoc />
        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesCameraPose>(obj);
        }

        /// <inheritdoc />
        void IFunctionalityProvider.UnloadProvider() { }

        /// <inheritdoc />
        public Pose GetCameraPose() { return transform.GetLocalPose(); }

        /// <inheritdoc />
        public void ClearData() { }

        /// <inheritdoc />
        public void StepRecordedData()
        {
            if (poseUpdated != null)
                poseUpdated(GetCameraPose());
        }
    }
}
