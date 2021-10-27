using Unity.MARS.Data;
using Unity.MARS.Data.Recorded;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Unity.MARS.Recording
{
    class FaceExpressionEventMarker : Marker, INotification, INotificationOptionProvider
    {
        const NotificationFlags k_Flags = NotificationFlags.Retroactive | NotificationFlags.TriggerInEditMode;

        [SerializeField]
        MRFaceExpression m_Expression;

        [SerializeField]
        float m_Coefficient;

        [SerializeField]
        bool m_Engaged;

        public PropertyName id { get; } = new PropertyName();

        public NotificationFlags flags => k_Flags;

        public MRFaceExpression Expression => m_Expression;

        public float Coefficient => m_Coefficient;

        public bool Engaged => m_Engaged;

        public void SetData(FaceExpressionDataEvent expressionEvent)
        {
            var expression = expressionEvent.Expression;
            var engaged = expressionEvent.Engaged;
            m_Expression = expression;
            m_Coefficient = expressionEvent.Coefficient;
            m_Engaged = engaged;
            var engagedString = engaged ? "Engaged" : "Disengaged";
            name = $"{expression} {engagedString}";
        }
    }
}
