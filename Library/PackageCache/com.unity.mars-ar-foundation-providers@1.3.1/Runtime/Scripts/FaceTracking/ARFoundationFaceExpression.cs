using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.ARFoundation
{
    [MovedFrom("Unity.MARS.Providers")]
    public abstract class ARFoundationFaceExpression : IFacialExpression
    {
        protected readonly MRFaceExpression m_Name;

        protected float m_Threshold;
        protected float m_Coefficient;

        protected float m_LastEngageEvent;
        protected float m_LastDisengageEvent;

        protected float m_PreviousCoefficient;
        protected bool m_Engaged;

        protected float m_SmoothingFilter;
        protected float m_EventCooldownInSeconds;

        public event Action<float> Engaged;
        public event Action<float> Disengaged;

        public MRFaceExpression Name { get { return m_Name; } }
        public float Coefficient { get { return m_Coefficient; } }
        public float Threshold
        {
            get { return m_Threshold; }
            set { m_Threshold = Mathf.Clamp01(value); }
        }

        protected ARFoundationFaceExpression(MRFaceExpression name)
        {
            m_Name = name;
            var index = (int)name;
            var settings = ARFoundationFaceExpressionSettings.instance;
            m_Threshold = settings.thresholds[index];
            m_SmoothingFilter = settings.expressionChangeSmoothingFilter;
            m_EventCooldownInSeconds = settings.eventCooldownInSeconds;
        }

        internal abstract float GetRawCoefficient(ARFoundationFace arFoundationFace);

        internal float Update(ARFoundationFace arFoundationFace)
        {
            var time = Time.time;

            m_Coefficient = Mathf.Lerp(m_PreviousCoefficient, GetRawCoefficient(arFoundationFace), m_SmoothingFilter);

            if (m_Coefficient > m_Threshold && !m_Engaged)
            {
                m_Engaged = true;
                if (Engaged != null && time - m_LastEngageEvent > m_EventCooldownInSeconds)
                {
                    m_LastEngageEvent = time;
                    Engaged(m_Coefficient);
                }
            }
            else if (m_Coefficient < m_Threshold && m_Engaged)
            {
                DisengageIfAppropriate(time);
            }

            m_PreviousCoefficient = m_Coefficient;
            return m_Coefficient;
        }

        void DisengageIfAppropriate(float time)
        {
            m_Engaged = false;
            if (Disengaged != null && time - m_LastDisengageEvent > m_EventCooldownInSeconds)
            {
                m_LastDisengageEvent = time;
                Disengaged(m_Coefficient);
            }
        }
    }

    [MovedFrom("Unity.MARS.Providers")]
    public class ARFoundationRightEyeCloseExpression : ARFoundationFaceExpression
    {
        public ARFoundationRightEyeCloseExpression() : base(MRFaceExpression.RightEyeClose) {}

        internal override float GetRawCoefficient(ARFoundationFace arFoundationFace)
        {
            return arFoundationFace.Expressions[MRFaceExpression.RightEyeClose];
        }
    }

    [MovedFrom("Unity.MARS.Providers")]
    public class ARFoundationLeftEyeCloseExpression : ARFoundationFaceExpression
    {
        public ARFoundationLeftEyeCloseExpression() : base(MRFaceExpression.LeftEyeClose) {}

        internal override float GetRawCoefficient(ARFoundationFace arFoundationFace)
        {
            return arFoundationFace.Expressions[MRFaceExpression.LeftEyeClose];
        }
    }

    [MovedFrom("Unity.MARS.Providers")]
    public class ARFoundationRightEyebrowRaiseExpression : ARFoundationFaceExpression
    {
        public ARFoundationRightEyebrowRaiseExpression() : base(MRFaceExpression.RightEyebrowRaise) {}

        internal override float GetRawCoefficient(ARFoundationFace arFoundationFace)
        {
            return arFoundationFace.Expressions[MRFaceExpression.RightEyebrowRaise];
        }
    }

    [MovedFrom("Unity.MARS.Providers")]
    public class ARFoundationLeftEyebrowRaiseExpression : ARFoundationFaceExpression
    {
        public ARFoundationLeftEyebrowRaiseExpression() : base(MRFaceExpression.LeftEyebrowRaise) {}

        internal override float GetRawCoefficient(ARFoundationFace arFoundationFace)
        {
            return arFoundationFace.Expressions[MRFaceExpression.LeftEyebrowRaise];
        }
    }

    [MovedFrom("Unity.MARS.Providers")]
    public class ARFoundationBothEyebrowsRaiseExpression : ARFoundationFaceExpression
    {
        public ARFoundationBothEyebrowsRaiseExpression() : base(MRFaceExpression.BothEyebrowsRaise) {}

        internal override float GetRawCoefficient(ARFoundationFace arFoundationFace)
        {
            const float raiseMinimum = 0.20f;
            var left = arFoundationFace.Expressions[MRFaceExpression.LeftEyebrowRaise];
            var right = arFoundationFace.Expressions[MRFaceExpression.RightEyebrowRaise];
            if (left < raiseMinimum || right < raiseMinimum)
                return 0f;

            return Mathf.Clamp01((left + right) * 0.5f) * 1.2f - raiseMinimum;
        }
    }

    [MovedFrom("Unity.MARS.Providers")]
    public class ARFoundationSmileRightExpression : ARFoundationFaceExpression
    {
        public ARFoundationSmileRightExpression() : base(MRFaceExpression.RightLipCornerRaise) {}

        internal override float GetRawCoefficient(ARFoundationFace arFoundationFace)
        {
            return arFoundationFace.Expressions[MRFaceExpression.RightLipCornerRaise];
        }
    }

    [MovedFrom("Unity.MARS.Providers")]
    public class ARFoundationSmileLeftExpression : ARFoundationFaceExpression
    {
        public ARFoundationSmileLeftExpression() : base(MRFaceExpression.LeftLipCornerRaise) {}

        internal override float GetRawCoefficient(ARFoundationFace arFoundationFace)
        {
            return arFoundationFace.Expressions[MRFaceExpression.LeftLipCornerRaise];
        }
    }

    [MovedFrom("Unity.MARS.Providers")]
    public class ARFoundationSmileExpression : ARFoundationFaceExpression
    {
        public ARFoundationSmileExpression() : base(MRFaceExpression.Smile) { }

        internal override float GetRawCoefficient(ARFoundationFace arFoundationFace)
        {
            const float smileMinimum = 0.15f;
            var left = arFoundationFace.Expressions[MRFaceExpression.LeftLipCornerRaise];
            var right = arFoundationFace.Expressions[MRFaceExpression.RightLipCornerRaise];

            // if both corners aren't at least slightly raised, no smile.
            if (left < smileMinimum || right < smileMinimum)
                return 0f;

            return Mathf.Clamp01((left + right) * 0.5f) * 1.2f - smileMinimum;
        }
    }

    [MovedFrom("Unity.MARS.Providers")]
    public class ARFoundationMouthOpenExpression : ARFoundationFaceExpression
    {
        public ARFoundationMouthOpenExpression() : base(MRFaceExpression.MouthOpen) {}

        internal override float GetRawCoefficient(ARFoundationFace arFoundationFace)
        {
            return arFoundationFace.Expressions[MRFaceExpression.MouthOpen];
        }
    }
}
