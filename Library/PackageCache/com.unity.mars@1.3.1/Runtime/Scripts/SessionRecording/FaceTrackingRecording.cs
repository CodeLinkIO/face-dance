using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.Recorded;
using Unity.MARS.Recording.Providers;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Unity.MARS.Recording
{
    class FaceTrackingRecording : DataRecording
    {
        const string k_ProviderName = "Recorded Face Tracking Provider";

        [SerializeField]
        SignalTrack m_SignalTrack;

        [SerializeField]
        int m_MaxFaceCount;

        [SerializeField]
        MRFaceLandmark[] m_LandmarkEnumValues;

        [SerializeField]
        MRFaceExpression[] m_ExpressionEnumValues;

        public int MaxFaceCount => m_MaxFaceCount;

        public MRFaceLandmark[] LandmarkEnumValues => m_LandmarkEnumValues;

        public MRFaceExpression[] ExpressionEnumValues => m_ExpressionEnumValues;

        public static FaceTrackingRecording Create(SignalTrack faceEventsTrack, int maxFaceCount,
            MRFaceLandmark[] landmarkEnumValues, MRFaceExpression[] expressionEnumValues)
        {
            var recording = CreateInstance<FaceTrackingRecording>();
            recording.m_SignalTrack = faceEventsTrack;
            recording.m_MaxFaceCount = maxFaceCount;
            var landmarkEnumValuesCopy = new MRFaceLandmark[landmarkEnumValues.Length];
            landmarkEnumValues.CopyTo(landmarkEnumValuesCopy, 0);
            recording.m_LandmarkEnumValues = landmarkEnumValuesCopy;
            var expressionEnumValuesCopy = new MRFaceExpression[expressionEnumValues.Length];
            expressionEnumValues.CopyTo(expressionEnumValuesCopy, 0);
            recording.m_ExpressionEnumValues = expressionEnumValuesCopy;
            return recording;
        }

        public override void SetupDataProviders(PlayableDirector director, List<IFunctionalityProvider> providers)
        {
            var providerObj = GameObjectUtils.Create(k_ProviderName);
            var faceTrackingProvider = providerObj.AddComponent<RecordedFaceTrackingProvider>();
            faceTrackingProvider.SetupFromRecording(this);
            providers.Add(faceTrackingProvider);
            director.SetGenericBinding(m_SignalTrack, providerObj);
        }
    }
}
