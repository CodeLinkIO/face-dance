using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS.Attributes;
using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Landmarks
{
    [HelpURL(DocumentationConstants.FaceLandmarksActionDocs)]
    [MonoBehaviourComponentMenu(typeof(FaceLandmarksAction), "Action/Face Landmarks")]
    [MovedFrom("Unity.MARS")]
    public class FaceLandmarksAction : MonoBehaviour, IUsesCameraOffset, IUsesMARSTrackableData<IMRFace>, ICalculateLandmarks, ISpawnable
    {
        Dictionary<MRFaceLandmark, Pose> m_AssignedFaceLandmarkPoses;
        Dictionary<MRFaceLandmark, Pose> m_FallbackLandmarkPoses;
        IMRFace m_AssignedFace;

        internal List<LandmarkController> landmarks => GetComponentsInChildren<LandmarkController>().ToList();

        /// <inheritdoc />
        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        public List<LandmarkDefinition> AvailableLandmarkDefinitions
        {
            get { return s_Definitions; }
        }

        static List<LandmarkDefinition> s_Definitions;

        static FaceLandmarksAction()
        {
            // Initialize the definitions to be all the MRFaceLandmark enum values with output type of pose
            s_Definitions = Enum.GetNames(typeof(MRFaceLandmark)).ToList().ConvertAll(name => new LandmarkDefinition(name, typeof(LandmarkOutputPose)));
        }

        void OnDisable()
        {
            m_AssignedFace = null;
            m_AssignedFaceLandmarkPoses = null;
        }

        /// <inheritdoc />
        public void SetupLandmark(ILandmarkController landmark)
        {
            var faceLandmark = landmark.landmarkDefinition.GetEnumName<MRFaceLandmark>();

            if (m_FallbackLandmarkPoses == null)
                m_FallbackLandmarkPoses = MARSFallbackFaceLandmarks.instance.GetFallbackFaceLandmarkPoses();

            var initialPose = m_FallbackLandmarkPoses[faceLandmark];
            initialPose.position *= MARSSession.GetWorldScale();
            var landmarkTransform = ((Component)(landmark)).transform;
            landmarkTransform.SetLocalPose(initialPose);
            var landmarkPose = landmark.output as LandmarkOutputPose;
            if (landmarkPose != null)
                landmarkPose.currentPose = landmarkTransform.GetWorldPose();
        }

        /// <inheritdoc />
        public Action<ILandmarkController> GetLandmarkCalculation(LandmarkDefinition definition)
        {
            var faceLandmark = definition.GetEnumName<MRFaceLandmark>();
            return (landmark) => UpdateFaceLandmark(landmark, faceLandmark);
        }

        void UpdateFaceLandmark(ILandmarkController landmark, MRFaceLandmark landmarkType)
        {
            // TODO: Investigate why we get calls to OnMatchLoss continuously after tracking loss
            if (m_AssignedFace == null)
                return;

            if (m_FallbackLandmarkPoses == null)
                m_FallbackLandmarkPoses = MARSFallbackFaceLandmarks.instance.GetFallbackFaceLandmarkPoses();

            Pose pose;
            if (m_AssignedFaceLandmarkPoses == null || !m_AssignedFaceLandmarkPoses.TryGetValue(landmarkType, out pose))
                pose = m_AssignedFace.pose.ApplyOffsetTo(m_FallbackLandmarkPoses[landmarkType]);

            var landmarkPose = landmark.output as LandmarkOutputPose;
            if (landmarkPose != null)
                landmarkPose.currentPose = this.ApplyOffsetToPose(pose);
        }

        protected void OnMatchDataChanged(QueryResult queryResult)
        {
            m_AssignedFace = queryResult.ResolveValue(this);

            if (m_AssignedFace == null)
            {
                Debug.LogError("Assigned face is null", gameObject);
            }
            else if (m_AssignedFace.id != MarsTrackableId.InvalidId)
            {
                m_AssignedFaceLandmarkPoses = m_AssignedFace.LandmarkPoses;
            }
        }

        protected void OnMatchDataLost(QueryResult queryResult)
        {
            m_AssignedFace = null;
            m_AssignedFaceLandmarkPoses = null;
        }

        /// <inheritdoc />
        public event Action<ICalculateLandmarks> dataChanged;

        /// <inheritdoc />
        public void OnMatchAcquire(QueryResult queryResult)
        {
            OnMatchDataChanged(queryResult);
            if (dataChanged != null)
                dataChanged(this);
        }

        /// <inheritdoc />
        public void OnMatchUpdate(QueryResult queryResult)
        {
            OnMatchDataChanged(queryResult);
            if (dataChanged != null)
                dataChanged(this);
        }

        /// <inheritdoc />
        public void OnMatchLoss(QueryResult queryResult)
        {
            OnMatchDataLost(queryResult);
            if (dataChanged != null)
                dataChanged(this);
        }
    }
}
