#if !UNITY_EDITOR && UNITY_IOS && INCLUDE_ARKIT_FACE_PLUGIN
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARKit;

namespace Unity.MARS.Data.ARFoundation
{
    abstract class ARKitFaceExpression : IFacialExpression
    {
        string m_BlendshapeLocation;

        protected float m_Coefficient;
        protected bool m_Engaged;
        protected float m_EventCooldownInSeconds;
        protected float m_LastDisengageEvent;

        protected float m_LastEngageEvent;
        protected MRFaceExpression m_Name;

        protected float m_PreviousCoefficient;

        protected float m_SmoothingFilter;
        protected float m_Threshold;

        public MRFaceExpression Name { get { return m_Name; } }

        public float Coefficient { get { return m_Coefficient; } }

        public float Threshold { get { return m_Threshold; } set { m_Threshold = Mathf.Clamp01(value); } }

        // For the basic use case of 1:1 relation between ARKit blendshape and MRFaceExpression,
        // provide the ARKit blendshape name here & GetCoefficient will be handled for you
        public ARKitFaceExpression(MRFaceExpression name, string blendshapeLocation = null)
        {
            m_Name = name;
            var index = (int)name;
            var settings = ARKitFacialExpressionSettings.instance;
            m_Threshold = settings.thresholds[index];
            m_SmoothingFilter = settings.expressionChangeSmoothingFilter;
            m_EventCooldownInSeconds = settings.eventCooldownInSeconds;
            m_BlendshapeLocation = blendshapeLocation;
        }

        public event Action<float> Engaged;
        public event Action<float> Disengaged;

        public virtual float GetCoefficient(Dictionary<string, float> blendshapes) { return blendshapes[m_BlendshapeLocation]; }

        public float Update(Dictionary<string, float> blendshapes)
        {
            var time = Time.time;

            m_Coefficient = Mathf.Lerp(m_PreviousCoefficient, GetCoefficient(blendshapes), m_SmoothingFilter);

            if (m_Coefficient > m_Threshold && !m_Engaged)
            {
                m_Engaged = true;
                if (Engaged != null && Time.time - m_LastEngageEvent > m_EventCooldownInSeconds)
                {
                    m_LastEngageEvent = Time.time;
                    Engaged(m_Coefficient);
                }
            }
            else if (m_Coefficient < m_Threshold && m_Engaged) DisengageIfAppropriate(time);

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

    class ARKitMouthOpenExpression : ARKitFaceExpression
    {
        public ARKitMouthOpenExpression() : base(MRFaceExpression.MouthOpen) { }

        public override float GetCoefficient(Dictionary<string, float> blendshapes)
        {
            var jawOpen = blendshapes[ARKitBlendShapeLocation.JawOpen.ToString()];
            var mouthClose = blendshapes[ARKitBlendShapeLocation.MouthClose.ToString()];

            return Mathf.Clamp01(jawOpen - mouthClose);
        }
    }

    class ARKitLeftEyebrowRaiseExpression : ARKitFaceExpression
    {
        public ARKitLeftEyebrowRaiseExpression() : base(MRFaceExpression.LeftEyebrowRaise) { }

        public override float GetCoefficient(Dictionary<string, float> blendshapes)
        {
            var browInnerUp = blendshapes[ARKitBlendShapeLocation.BrowInnerUp.ToString()];
            var browOuterUpLeft = blendshapes[ARKitBlendShapeLocation.BrowOuterUpLeft.ToString()];
            return (browInnerUp + browOuterUpLeft) * 0.5f;
        }
    }

    class ARKitRightEyebrowRaiseExpression : ARKitFaceExpression
    {
        public ARKitRightEyebrowRaiseExpression() : base(MRFaceExpression.RightEyebrowRaise) { }

        public override float GetCoefficient(Dictionary<string, float> blendshapes)
        {
            var browInnerUp = blendshapes[ARKitBlendShapeLocation.BrowInnerUp.ToString()];
            var browOuterUpRight = blendshapes[ARKitBlendShapeLocation.BrowOuterUpRight.ToString()];
            return (browInnerUp + browOuterUpRight) * 0.5f;
        }
    }

    class ARKitBothEyebrowsRaiseExpression : ARKitFaceExpression
    {
        readonly ARKitLeftEyebrowRaiseExpression m_LeftBrow;
        readonly ARKitRightEyebrowRaiseExpression m_RightBrow;

        public ARKitBothEyebrowsRaiseExpression(ARKitLeftEyebrowRaiseExpression left, ARKitRightEyebrowRaiseExpression right)
            : base(MRFaceExpression.BothEyebrowsRaise)
        {
            m_LeftBrow = left;
            m_RightBrow = right;
        }

        public override float GetCoefficient(Dictionary<string, float> blendshapes)
        {
            const float raiseMinimum = 0.2f;
            var left = m_LeftBrow.Coefficient;
            var right = m_RightBrow.Coefficient;
            if (left < raiseMinimum || right < raiseMinimum)
                return 0f;

            return Mathf.Clamp01((left + right) * 0.5f);
        }
    }

    class ARKitLeftEyeCloseExpression : ARKitFaceExpression
    {
        public ARKitLeftEyeCloseExpression() :
            base(MRFaceExpression.LeftEyeClose, ARKitBlendShapeLocation.EyeBlinkLeft.ToString()) { }
    }

    class ARKitRightEyeCloseExpression : ARKitFaceExpression
    {
        public ARKitRightEyeCloseExpression() :
            base(MRFaceExpression.RightEyeClose, ARKitBlendShapeLocation.EyeBlinkRight.ToString()) { }
    }

    class ARKitLeftLipCornerRaiseExpression : ARKitFaceExpression
    {
        public ARKitLeftLipCornerRaiseExpression() :
            base(MRFaceExpression.LeftLipCornerRaise, ARKitBlendShapeLocation.MouthSmileLeft.ToString()) { }
    }

    class ARKitRightLipCornerRaiseExpression : ARKitFaceExpression
    {
        public ARKitRightLipCornerRaiseExpression() :
            base(MRFaceExpression.RightLipCornerRaise, ARKitBlendShapeLocation.MouthSmileRight.ToString()) { }
    }

    class ARKitSmileExpression : ARKitFaceExpression
    {
        public ARKitSmileExpression()
            : base(MRFaceExpression.Smile) { }

        public override float GetCoefficient(Dictionary<string, float> blendshapes)
        {
            var mouthSmileLeft = blendshapes[ARKitBlendShapeLocation.MouthSmileLeft.ToString()];
            var mouthSmileRight = blendshapes[ARKitBlendShapeLocation.MouthSmileRight.ToString()];
            return (mouthSmileLeft + mouthSmileRight) * 0.5f;
        }
    }
}
#endif
