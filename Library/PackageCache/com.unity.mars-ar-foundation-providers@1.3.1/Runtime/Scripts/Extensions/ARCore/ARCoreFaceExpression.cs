#if !UNITY_EDITOR && UNITY_ANDROID
using System;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Data.ARFoundation
{
    abstract class ARCoreFaceExpression : IFacialExpression
    {
        protected float m_Coefficient;
        protected bool m_Engaged;
        protected float m_EventCooldownInSeconds;
        protected float m_LastDisengageEvent;

        protected float m_LastEngageEvent;
        protected MRFaceExpression m_Name;

        protected float m_PreviousCoefficient;

        protected float m_SmoothingFilter;
        protected float m_Threshold;

        public MRFaceExpression Name => m_Name;

        public float maxDistance { get; private set; }
        public float minDistance { get; private set; }

        public float Coefficient => m_Coefficient;

        public float Threshold
        {
            get => m_Threshold;
            set => m_Threshold = Mathf.Clamp01(value);
        }

        protected ARCoreFaceExpression(MRFaceExpression name)
        {
            m_Name = name;
            var index = (int)name;
            var settings = ARCoreFacialExpressionSettings.instance;
            m_Threshold = settings.thresholds[index];
            maxDistance = settings.expressionDistanceMaximums[index];
            minDistance = settings.expressionDistanceMinimums[index];

            m_SmoothingFilter = settings.expressionChangeSmoothingFilter;
            m_EventCooldownInSeconds = settings.eventCooldownInSeconds;
        }

        public event Action<float> Engaged;
        public event Action<float> Disengaged;

        public abstract float GetCoefficient(Vector3[] landmarks);

        public float Update(Vector3[] landmarks)
        {
            var time = Time.time;

            m_Coefficient = Mathf.Lerp(m_PreviousCoefficient, GetCoefficient(landmarks), m_SmoothingFilter);

            if (m_Coefficient > m_Threshold && !m_Engaged)
            {
                m_Engaged = true;
                if (Engaged != null && Time.time - m_LastEngageEvent > m_EventCooldownInSeconds)
                {
                    m_LastEngageEvent = Time.time;
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

    class ARCoreMouthOpenExpression : ARCoreFaceExpression
    {
        public ARCoreMouthOpenExpression() : base(MRFaceExpression.MouthOpen) { }

        public override float GetCoefficient(Vector3[] landmarks)
        {
            var upperLipLeft = landmarks[(int)ARCoreFaceMeshLandmark.UpperLipLeft];
            var upperLipRight = landmarks[(int)ARCoreFaceMeshLandmark.UpperLipRight];
            var upperLipAverage = (upperLipLeft + upperLipRight) * 0.5f;

            var lowerLipLeft = landmarks[(int)ARCoreFaceMeshLandmark.LowerLipLeft];
            var lowerLipRight = landmarks[(int)ARCoreFaceMeshLandmark.LowerLipRight];
            var lowerLipAverage = (lowerLipLeft + lowerLipRight) * 0.5f;
            return CoefficientUtils.FromDistance(upperLipAverage, lowerLipAverage, minDistance, maxDistance);
        }
    }

    class ARCoreLeftEyebrowRaiseExpression : ARCoreFaceExpression
    {
        public ARCoreLeftEyebrowRaiseExpression() : base(MRFaceExpression.LeftEyebrowRaise) { }

        public override float GetCoefficient(Vector3[] landmarks)
        {
            return ARCoreFaceExpressionUtils.EyebrowRaiseCoefficient(landmarks, ARCoreFaceMeshLandmark.LeftEyebrowOuter,
                ARCoreFaceMeshLandmark.LeftEyebrowInner, ARCoreFaceMeshLandmark.LeftEyeOuter, minDistance, maxDistance);
        }
    }

    class ARCoreRightEyebrowRaiseExpression : ARCoreFaceExpression
    {
        public ARCoreRightEyebrowRaiseExpression() : base(MRFaceExpression.RightEyebrowRaise) { }

        public override float GetCoefficient(Vector3[] landmarks)
        {
            return ARCoreFaceExpressionUtils.EyebrowRaiseCoefficient(landmarks, ARCoreFaceMeshLandmark.RightEyebrowOuter,
                ARCoreFaceMeshLandmark.RightEyebrowInner, ARCoreFaceMeshLandmark.RightEyeOuter, minDistance, maxDistance);
        }
    }

    class ARCoreBothEyebrowsRaiseExpression : ARCoreFaceExpression
    {
        readonly ARCoreLeftEyebrowRaiseExpression m_LeftBrow;
        readonly ARCoreRightEyebrowRaiseExpression m_RightBrow;

        public ARCoreBothEyebrowsRaiseExpression(ARCoreLeftEyebrowRaiseExpression left, ARCoreRightEyebrowRaiseExpression right)
            : base(MRFaceExpression.BothEyebrowsRaise)
        {
            m_LeftBrow = left;
            m_RightBrow = right;
        }

        public override float GetCoefficient(Vector3[] landmarks)
        {
            const float raiseMinimum = 0.2f;
            var left = m_LeftBrow.Coefficient;
            var right = m_RightBrow.Coefficient;
            if (left < raiseMinimum || right < raiseMinimum)
            {
                return 0f;
            }

            return Mathf.Clamp01((left + right) * 0.5f);
        }
    }

    class ARCoreLeftEyeCloseExpression : ARCoreFaceExpression
    {
        public ARCoreLeftEyeCloseExpression() : base(MRFaceExpression.LeftEyeClose) { }

        public override float GetCoefficient(Vector3[] landmarks)
        {
            // Low eye mesh accuracy across face types. Return eye not-closed
            return 0f;
        }
    }

    class ARCoreRightEyeCloseExpression : ARCoreFaceExpression
    {
        public ARCoreRightEyeCloseExpression() : base(MRFaceExpression.RightEyeClose) { }

        public override float GetCoefficient(Vector3[] landmarks)
        {
            // Low eye mesh accuracy across face types. Return eye not-closed
            return 0f;
        }
    }

    class ARCoreLeftLipCornerRaiseExpression : ARCoreFaceExpression
    {
        public ARCoreLeftLipCornerRaiseExpression() : base(MRFaceExpression.LeftLipCornerRaise) { }

        public override float GetCoefficient(Vector3[] landmarks)
        {
            return ARCoreFaceExpressionUtils.LipCornerCoefficient(landmarks, ARCoreFaceMeshLandmark.LeftLipCorner, minDistance, maxDistance);
        }
    }

    class ARCoreRightLipCornerRaiseExpression : ARCoreFaceExpression
    {
        public ARCoreRightLipCornerRaiseExpression() : base(MRFaceExpression.RightLipCornerRaise) { }

        public override float GetCoefficient(Vector3[] landmarks)
        {
            return ARCoreFaceExpressionUtils.LipCornerCoefficient(landmarks, ARCoreFaceMeshLandmark.RightLipCorner, minDistance, maxDistance);
        }
    }

    class ARCoreSmileExpression : ARCoreFaceExpression
    {
        readonly ARCoreLeftLipCornerRaiseExpression m_LeftCorner;
        readonly ARCoreRightLipCornerRaiseExpression m_RightCorner;

        public ARCoreSmileExpression(ARCoreLeftLipCornerRaiseExpression left, ARCoreRightLipCornerRaiseExpression right)
            : base(MRFaceExpression.Smile)
        {
            m_LeftCorner = left;
            m_RightCorner = right;
        }

        public override float GetCoefficient(Vector3[] landmarks)
        {
            const float smileMinimum = 0.15f;
            var left = m_LeftCorner.Coefficient;
            var right = m_RightCorner.Coefficient;

            // if both corners aren't at least slightly raised, no smile.
            if (left < smileMinimum || right < smileMinimum)
                return 0f;

            return (left + right) * 0.5f;
        }
    }
}
#endif
