using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.Recorded;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Playables;

namespace Unity.MARS.Recording.Providers
{
    [AddComponentMenu("")]
    [ProviderSelectionOptions(ProviderPriorities.RecordedProviderPriority, disallowAutoCreation:true)]
    class RecordedFaceTrackingProvider : RecordedTrackablesProvider, IProvidesFaceTracking,
        IUsesMARSTrackableData<IMRFace>, IProvidesTraits<bool>, IProvidesTraits<Pose>, INotificationReceiver
    {
        class RecordedFace : IMRFace
        {
            public MarsTrackableId id { get; set; }

            public Pose pose { get; set; }

            public Mesh Mesh { get; set; }

            public Dictionary<MRFaceLandmark, Pose> LandmarkPoses { get; } = new Dictionary<MRFaceLandmark, Pose>();

            public Dictionary<MRFaceExpression, float> Expressions { get; } = new Dictionary<MRFaceExpression, float>();
        }

        static readonly TraitDefinition[] k_ProvidedTraits =
        {
            TraitDefinitions.Face,
            TraitDefinitions.Pose
        };

        readonly Dictionary<MarsTrackableId, RecordedFace> m_Faces = new Dictionary<MarsTrackableId, RecordedFace>();

        MRFaceLandmark[] m_LandmarkEnumValues;
        MRFaceExpression[] m_ExpressionEnumValues;

        int m_MaxFaceCount;

        public event Action<IMRFace> FaceAdded;
        public event Action<IMRFace> FaceUpdated;
        public event Action<IMRFace> FaceRemoved;

        public TraitDefinition[] GetProvidedTraits() { return k_ProvidedTraits; }

        void IFunctionalityProvider.LoadProvider() { }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesFaceTracking>(obj);
        }

        void IFunctionalityProvider.UnloadProvider() { }

        public void SetupFromRecording(FaceTrackingRecording recording)
        {
            m_MaxFaceCount = recording.MaxFaceCount;
            m_LandmarkEnumValues = recording.LandmarkEnumValues;
            m_ExpressionEnumValues = recording.ExpressionEnumValues;
        }

        public override void ClearData()
        {
            foreach (var kvp in m_Faces)
            {
                RemoveFaceData(kvp.Value);
            }

            m_Faces.Clear();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            ClearData();
        }

        public int GetMaxFaceCount() { return m_MaxFaceCount; }

        public int RequestedMaximumFaceCount
        {
            get => m_MaxFaceCount;
            set {}
        }

        public int CurrentMaximumFaceCount => m_MaxFaceCount;

        public int SupportedFaceCount => m_MaxFaceCount;

        public void GetFaces(List<IMRFace> faces)
        {
            foreach (var kvp in m_Faces)
            {
                faces.Add(kvp.Value);
            }
        }

        public void OnNotify(Playable origin, INotification notification, object context)
        {
            var faceEvent = notification as FaceEventMarker;
            if (faceEvent == null)
                return;

            var faceData = faceEvent.FaceData;
            switch (faceEvent.EventType)
            {
                case TrackableEventType.Added:
                    AddFaceFromSerializedData(faceData);
                    break;
                case TrackableEventType.Updated:
                    UpdateFaceFromSerializedData(faceData);
                    break;
                case TrackableEventType.Removed:
                    RemoveFaceFromSerializedData(faceData);
                    break;
            }
        }

        void AddFaceFromSerializedData(SerializedFaceData faceData)
        {
            var playbackID = GetPlaybackID(faceData.ID);
            var face = new RecordedFace { id = playbackID };
            UpdateRecordedFaceFromData(face, faceData);
            m_Faces[playbackID] = face;
            var id = this.AddOrUpdateData(face);
            this.AddOrUpdateTrait(id, TraitNames.Face, true);
            this.AddOrUpdateTrait(id, TraitNames.Pose, face.pose);
            FaceAdded?.Invoke(face);
        }

        void UpdateFaceFromSerializedData(SerializedFaceData faceData)
        {
            var playbackID = GetPlaybackID(faceData.ID);
            var face = m_Faces[playbackID];
            UpdateRecordedFaceFromData(face, faceData);
            var id = this.AddOrUpdateData(face);
            this.AddOrUpdateTrait(id, TraitNames.Pose, face.pose);
            FaceUpdated?.Invoke(face);
        }

        void RemoveFaceFromSerializedData(SerializedFaceData faceData)
        {
            var playbackID = GetPlaybackID(faceData.ID);
            var face = m_Faces[playbackID];
            m_Faces.Remove(playbackID);
            RemoveFaceData(face);
        }

        void RemoveFaceData(IMRFace face)
        {
            var id = this.RemoveData(face);
            this.RemoveTrait<bool>(id, TraitNames.Face);
            this.RemoveTrait<Pose>(id, TraitNames.Pose);
            FaceRemoved?.Invoke(face);
        }

        void UpdateRecordedFaceFromData(RecordedFace recordedFace, SerializedFaceData faceData)
        {
            recordedFace.pose = faceData.Pose;
            recordedFace.Mesh = faceData.Mesh;

            var recordedLandmarkPoses = recordedFace.LandmarkPoses;
            recordedLandmarkPoses.Clear();
            var dataLandmarkPoses = faceData.LandmarkPoses;
            for (var i = 0; i < m_LandmarkEnumValues.Length; i++)
            {
                recordedLandmarkPoses[m_LandmarkEnumValues[i]] = dataLandmarkPoses[i];
            }

            var recordedExpressionValues = recordedFace.Expressions;
            recordedExpressionValues.Clear();
            var dataExpressionValues = faceData.ExpressionValues;
            for (var i = 0; i < m_ExpressionEnumValues.Length; i++)
            {
                recordedExpressionValues[m_ExpressionEnumValues[i]] = dataExpressionValues[i];
            }
        }
    }
}
