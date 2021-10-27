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
    class FacialExpressionsRecording : DataRecording
    {
        const string k_ProviderName = "Recorded Facial Expressions Provider";

        [SerializeField]
        SignalTrack m_SignalTrack;

        [SerializeField]
        MRFaceExpression[] m_ExpressionEnumValues;

        public MRFaceExpression[] ExpressionEnumValues => m_ExpressionEnumValues;

        public static FacialExpressionsRecording Create(SignalTrack faceExpressionEventsTrack, MRFaceExpression[] expressionEnumValues)
        {
            var recording = CreateInstance<FacialExpressionsRecording>();
            recording.m_SignalTrack = faceExpressionEventsTrack;
            var expressionEnumValuesCopy = new MRFaceExpression[expressionEnumValues.Length];
            expressionEnumValues.CopyTo(expressionEnumValuesCopy, 0);
            recording.m_ExpressionEnumValues = expressionEnumValuesCopy;
            return recording;
        }

        public override void SetupDataProviders(PlayableDirector director, List<IFunctionalityProvider> providers)
        {
            var providerObj = GameObjectUtils.Create(k_ProviderName);
            var facialExpressionsProvider = providerObj.AddComponent<RecordedFacialExpressionsProvider>();
            facialExpressionsProvider.SetupFromRecording(this);
            providers.Add(facialExpressionsProvider);
            director.SetGenericBinding(m_SignalTrack, providerObj);
        }
    }
}
