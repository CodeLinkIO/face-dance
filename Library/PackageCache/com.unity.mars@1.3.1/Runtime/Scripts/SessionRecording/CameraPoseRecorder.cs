using System;
using System.Collections.Generic;
using Unity.MARS.MARSUtils;
using Unity.MARS.Providers;
using Unity.MARS.Recording;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;
#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Data recorder for camera tracking
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class CameraPoseRecorder : DataRecorder, IUsesCameraPose, IUsesSlowTasks
    {
        List<PoseEvent> m_PoseEvents = new List<PoseEvent>();

        Action m_RecordCameraTask;
        float m_PoseRecordInterval;
        Pose m_LastPose;
        bool m_LastPoseUnchanged;

        /// <summary>
        /// List of camera tracking events
        /// </summary>
        public List<PoseEvent> PoseEvents { get { return m_PoseEvents; } set { m_PoseEvents = value; } }

        IProvidesCameraPose IFunctionalitySubscriber<IProvidesCameraPose>.provider { get; set; }
        IProvidesSlowTasks IFunctionalitySubscriber<IProvidesSlowTasks>.provider { get; set; }

        /// <summary>
        /// Initialize a new CameraPoseRecorder
        /// </summary>
        public CameraPoseRecorder()
        {
            m_RecordCameraTask = RecordCurrentCameraPose;
            m_PoseRecordInterval = SessionRecordingSettings.instance.CameraPoseInterval;
        }

        /// <summary>
        /// Create a new camera pose track on the provided timeline
        /// </summary>
        /// <param name="timeline">The timeline to which the track will be added</param>
        /// <param name="newAssets">A list to which new assets can be added. This method adds an AnimationClip.</param>
        /// <returns>The camera pose recording</returns>
        /// <exception cref="InvalidOperationException">Thrown if the camera pose recording contains less than 2 events</exception>
        public override DataRecording TryCreateDataRecording(TimelineAsset timeline, List<UnityObject> newAssets)
        {
            var eventsCount = m_PoseEvents.Count;
            if (eventsCount < 2)
                throw new InvalidOperationException("There must be at least 2 pose events to create a camera pose recording");

            var xPosCurve = new AnimationCurve();
            var yPosCurve = new AnimationCurve();
            var zPosCurve = new AnimationCurve();
            var xRotCurve = new AnimationCurve();
            var yRotCurve = new AnimationCurve();
            var zRotCurve = new AnimationCurve();
            var wRotCurve = new AnimationCurve();

            for (var i = 0; i < eventsCount; i++)
            {
                var poseEvent = m_PoseEvents[i];
                var time = poseEvent.time;
                var position = poseEvent.pose.position;
                var rotation = poseEvent.pose.rotation;
                xPosCurve.AddKey(new Keyframe(time, position.x));
                yPosCurve.AddKey(new Keyframe(time, position.y));
                zPosCurve.AddKey(new Keyframe(time, position.z));
                xRotCurve.AddKey(new Keyframe(time, rotation.x));
                yRotCurve.AddKey(new Keyframe(time, rotation.y));
                zRotCurve.AddKey(new Keyframe(time, rotation.z));
                wRotCurve.AddKey(new Keyframe(time, rotation.w));
            }

            // Start smoothing at event 2 to avoid extrapolation errors
            for (var i = 2; i < eventsCount; i++)
            {
                xPosCurve.SmoothTangents(i, 0);
                yPosCurve.SmoothTangents(i, 0);
                zPosCurve.SmoothTangents(i, 0);
                xRotCurve.SmoothTangents(i, 0);
                yRotCurve.SmoothTangents(i, 0);
                zRotCurve.SmoothTangents(i, 0);
            }

            const string xPosPropertyName = "localPosition.x";
            const string yPosPropertyName = "localPosition.y";
            const string zPosPropertyName = "localPosition.z";
            const string xRotPropertyName = "localRotation.x";
            const string yRotPropertyName = "localRotation.y";
            const string zRotPropertyName = "localRotation.z";
            const string wRotPropertyName = "localRotation.w";
            var transformType = typeof(Transform);
            var animationClip = new AnimationClip { name = "Camera Pose" };
            animationClip.SetCurve("", transformType, xPosPropertyName, xPosCurve);
            animationClip.SetCurve("", transformType, yPosPropertyName, yPosCurve);
            animationClip.SetCurve("", transformType, zPosPropertyName, zPosCurve);
            animationClip.SetCurve("", transformType, xRotPropertyName, xRotCurve);
            animationClip.SetCurve("", transformType, yRotPropertyName, yRotCurve);
            animationClip.SetCurve("", transformType, zRotPropertyName, zRotCurve);
            animationClip.SetCurve("", transformType, wRotPropertyName, wRotCurve);
            newAssets.Add(animationClip);

#if UNITY_EDITOR
            AnimationUtility.SetEditorCurve(animationClip, EditorCurveBinding.FloatCurve("", transformType, xPosPropertyName), xPosCurve);
            AnimationUtility.SetEditorCurve(animationClip, EditorCurveBinding.FloatCurve("", transformType, yPosPropertyName), yPosCurve);
            AnimationUtility.SetEditorCurve(animationClip, EditorCurveBinding.FloatCurve("", transformType, zPosPropertyName), zPosCurve);
            AnimationUtility.SetEditorCurve(animationClip, EditorCurveBinding.FloatCurve("", transformType, xRotPropertyName), xRotCurve);
            AnimationUtility.SetEditorCurve(animationClip, EditorCurveBinding.FloatCurve("", transformType, yRotPropertyName), yRotCurve);
            AnimationUtility.SetEditorCurve(animationClip, EditorCurveBinding.FloatCurve("", transformType, zRotPropertyName), zRotCurve);
            AnimationUtility.SetEditorCurve(animationClip, EditorCurveBinding.FloatCurve("", transformType, wRotPropertyName), wRotCurve);
#endif

            var animationTrack = timeline.CreateTrack<AnimationTrack>(null, "Camera Pose");
            var timelineClip = animationTrack.CreateClip(animationClip);
            var animationPlayable = (AnimationPlayableAsset)timelineClip.asset;
            animationPlayable.removeStartOffset = false;

            // Getting duration causes the track to update extrapolation times.
            // We want to make sure these are up-to-date before saving the Timeline Asset.
            var duration = animationTrack.duration;

            var recording = ScriptableObject.CreateInstance<CameraPoseRecording>();
            recording.hideFlags = HideFlags.NotEditable;
            recording.AnimationTrack = animationTrack;
            return recording;
        }

        protected override void Setup()
        {
            this.AddSlowTask(m_RecordCameraTask, m_PoseRecordInterval);
            m_LastPose = this.GetPose();
            m_LastPoseUnchanged = false;
            m_PoseEvents.Clear();
            m_PoseEvents.Add(new PoseEvent
            {
                time = 0f,
                pose = m_LastPose
            });
        }

        protected override void TearDown() { this.RemoveSlowTask(m_RecordCameraTask); }

        protected override void FinalizeRecording()
        {
            m_PoseEvents.Add(new PoseEvent
            {
                time = TimeFromStart,
                pose = this.GetPose()
            });
        }

        void RecordCurrentCameraPose()
        {
            var currentPose = this.GetPose();
            if (currentPose == m_LastPose)
            {
                // No need to continually record the same pose
                m_LastPoseUnchanged = true;
                return;
            }

            var currentTime = TimeFromStart;
            if (m_LastPoseUnchanged)
            {
                // Pose that was not changing has now changed, so we need to record an event for the end of the elapsed time
                m_LastPoseUnchanged = false;
                m_PoseEvents.Add(new PoseEvent
                {
                    time = currentTime - m_PoseRecordInterval,
                    pose = m_LastPose
                });
            }

            m_PoseEvents.Add(new PoseEvent
            {
                time = currentTime,
                pose = currentPose
            });

            m_LastPose = currentPose;
        }
    }
}
