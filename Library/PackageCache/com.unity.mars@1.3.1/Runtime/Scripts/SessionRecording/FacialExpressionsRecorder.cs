using System.Collections.Generic;
using Unity.MARS.Providers;
using Unity.MARS.Recording;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Records facial expression data
    /// </summary>
    [MovedFrom("Unity.MARS.Recording")]
    public class FacialExpressionsRecorder : DataRecorder, IUsesFacialExpressions
    {
        class FaceExpressionSubscriber
        {
            public FacialExpressionsRecorder Recorder;
            public MRFaceExpression Expression;

            public void OnExpressionEngaged(float coefficient) { Recorder.OnExpressionEngaged(Expression, coefficient); }

            public void OnExpressionDisengaged(float coefficient) { Recorder.OnExpressionDisengaged(Expression, coefficient); }
        }

        readonly List<FaceExpressionDataEvent> m_FaceExpressionEvents = new List<FaceExpressionDataEvent>();
        readonly List<FaceExpressionSubscriber> m_FaceExpressionSubscribers = new List<FaceExpressionSubscriber>();

        MRFaceExpression[] m_ExpressionEnumValues;
        bool m_HasProvider;

        IProvidesFacialExpressions IFunctionalitySubscriber<IProvidesFacialExpressions>.provider { get; set; }

        /// <summary>
        /// Try to add recorded facial expression data to a Timeline and create a facial expressions recording object that
        /// references this recorded data
        /// </summary>
        /// <param name="timeline">The Timeline that holds recorded data</param>
        /// <param name="newAssets">List to be filled out with newly created Assets other than the Data Recording.
        /// This method adds none.</param>
        /// <returns>The facial expressions recording object, or null if creation fails</returns>
        public override DataRecording TryCreateDataRecording(TimelineAsset timeline, List<Object> newAssets)
        {
            if (!m_HasProvider)
            {
                Debug.LogWarning("Failed to create facial expressions recording. No facial expressions provider available.");
                return null;
            }

            var signalTrack = timeline.CreateTrack<SignalTrack>(null, "Facial Expression Events");
            foreach (var expressionEvent in m_FaceExpressionEvents)
            {
                var marker = signalTrack.CreateMarker<FaceExpressionEventMarker>(expressionEvent.Time);
                marker.SetData(expressionEvent);
            }

            var recording = FacialExpressionsRecording.Create(signalTrack, m_ExpressionEnumValues);
            recording.hideFlags = HideFlags.NotEditable;
            return recording;
        }

        protected override void Setup()
        {
            m_HasProvider = this.HasProvider();
            if (!m_HasProvider)
                return;

            m_ExpressionEnumValues = EnumValues<MRFaceExpression>.Values;
            foreach (var expression in m_ExpressionEnumValues)
            {
                var expressionSubscriber = new FaceExpressionSubscriber
                {
                    Recorder = this,
                    Expression = expression
                };

                m_FaceExpressionSubscribers.Add(expressionSubscriber);
                this.SubscribeToExpression(expression, expressionSubscriber.OnExpressionEngaged, expressionSubscriber.OnExpressionDisengaged);
            }
        }

        protected override void TearDown()
        {
            if (!m_HasProvider)
                return;

            foreach (var expressionSubscriber in m_FaceExpressionSubscribers)
            {
                var expression = expressionSubscriber.Expression;
                this.UnsubscribeToExpression(expression, expressionSubscriber.OnExpressionEngaged, expressionSubscriber.OnExpressionDisengaged);
            }

            m_FaceExpressionSubscribers.Clear();
        }

        void OnExpressionEngaged(MRFaceExpression expression, float coefficient)
        {
            m_FaceExpressionEvents.Add(new FaceExpressionDataEvent
            {
                Time = GetCurrentTime(),
                Expression = expression,
                Coefficient = coefficient,
                Engaged = true
            });
        }

        void OnExpressionDisengaged(MRFaceExpression expression, float coefficient)
        {
            m_FaceExpressionEvents.Add(new FaceExpressionDataEvent
            {
                Time = GetCurrentTime(),
                Expression = expression,
                Coefficient = coefficient,
                Engaged = false
            });
        }

        double GetCurrentTime()
        {
            var appendedDataTimestamp = DataRecorderUtils.TryGetAppendedDataTimestamp();
            return appendedDataTimestamp ?? TimeFromStart;
        }
    }
}
