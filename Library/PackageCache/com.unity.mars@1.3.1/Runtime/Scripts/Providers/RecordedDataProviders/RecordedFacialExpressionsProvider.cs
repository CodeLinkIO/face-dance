using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.Recorded;
using Unity.MARS.Providers;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Playables;

namespace Unity.MARS.Recording.Providers
{
    [AddComponentMenu("")]
    [ProviderSelectionOptions(ProviderPriorities.RecordedProviderPriority, disallowAutoCreation:true)]
    class RecordedFacialExpressionsProvider : MonoBehaviour, IRecordedDataProvider, IProvidesFacialExpressions, INotificationReceiver
    {
        class ExpressionActions
        {
            public event Action<float> Engaged;
            public event Action<float> Disengaged;

            public void Clear()
            {
                Engaged = null;
                Disengaged = null;
            }

            public void InvokeEngaged(float coefficient) { Engaged?.Invoke(coefficient); }

            public void InvokeDisengaged(float coefficient) { Disengaged?.Invoke(coefficient); }
        }

        readonly Dictionary<MRFaceExpression, ExpressionActions> m_ExpressionActionsMap = new Dictionary<MRFaceExpression, ExpressionActions>();

        MRFaceExpression[] m_ExpressionEnumValues;

        void IFunctionalityProvider.LoadProvider() { }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesFacialExpressions>(obj);
        }

        void IFunctionalityProvider.UnloadProvider() { }

        public void SetupFromRecording(FacialExpressionsRecording recording)
        {
            m_ExpressionEnumValues = recording.ExpressionEnumValues;

            m_ExpressionActionsMap.Clear();
            foreach (var expression in m_ExpressionEnumValues)
            {
                m_ExpressionActionsMap[expression] = new ExpressionActions();
            }
        }

        public void ClearData() { }

        void OnDisable()
        {
            foreach (var expression in m_ExpressionEnumValues)
            {
                m_ExpressionActionsMap[expression].Clear();
            }
        }

        public void SubscribeToExpression(MRFaceExpression expression, Action<float> engaged, Action<float> disengaged)
        {
            var expressionActions = m_ExpressionActionsMap[expression];
            expressionActions.Engaged += engaged;
            expressionActions.Disengaged += disengaged;
        }

        public void UnsubscribeToExpression(MRFaceExpression expression, Action<float> engaged, Action<float> disengaged)
        {
            var expressionActions = m_ExpressionActionsMap[expression];
            expressionActions.Engaged -= engaged;
            expressionActions.Disengaged -= disengaged;
        }

        public void OnNotify(Playable origin, INotification notification, object context)
        {
            var expressionEvent = notification as FaceExpressionEventMarker;
            if (expressionEvent == null)
                return;

            var expressionActions = m_ExpressionActionsMap[expressionEvent.Expression];
            var coefficient = expressionEvent.Coefficient;
            if (expressionEvent.Engaged)
                expressionActions.InvokeEngaged(coefficient);
            else
                expressionActions.InvokeDisengaged(coefficient);
        }
    }
}
