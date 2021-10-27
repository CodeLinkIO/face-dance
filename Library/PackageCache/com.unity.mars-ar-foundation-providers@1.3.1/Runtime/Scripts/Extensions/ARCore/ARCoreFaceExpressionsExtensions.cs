#if !UNITY_EDITOR && UNITY_ANDROID
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.Data.ARFoundation
{
    static class ARCoreFaceExpressionsExtensions
    {
        static readonly ARCoreBothEyebrowsRaiseExpression k_BothBrowsRaise;
        static readonly ARCoreSmileExpression k_Smile;
        static readonly ARCoreMouthOpenExpression k_MouthOpen = new ARCoreMouthOpenExpression();
        static readonly ARCoreLeftLipCornerRaiseExpression k_LeftLipCornerRaise = new ARCoreLeftLipCornerRaiseExpression();
        static readonly ARCoreRightLipCornerRaiseExpression k_RightLipCornerRaise = new ARCoreRightLipCornerRaiseExpression();
        static readonly ARCoreLeftEyeCloseExpression k_LeftEyeClose = new ARCoreLeftEyeCloseExpression();
        static readonly ARCoreRightEyeCloseExpression k_RightEyeClose = new ARCoreRightEyeCloseExpression();
        static readonly ARCoreLeftEyebrowRaiseExpression k_LeftBrowRaise = new ARCoreLeftEyebrowRaiseExpression();
        static readonly ARCoreRightEyebrowRaiseExpression k_RightBrowRaise = new ARCoreRightEyebrowRaiseExpression();

        static readonly Dictionary<MRFaceExpression, ARCoreFaceExpression> k_Expressions = new Dictionary<MRFaceExpression, ARCoreFaceExpression>();

        static ARCoreFaceExpressionsExtensions()
        {
            k_BothBrowsRaise = new ARCoreBothEyebrowsRaiseExpression(k_LeftBrowRaise, k_RightBrowRaise);
            k_Smile = new ARCoreSmileExpression(k_LeftLipCornerRaise, k_RightLipCornerRaise);

            k_Expressions.Add(MRFaceExpression.LeftEyeClose, k_LeftEyeClose);
            k_Expressions.Add(MRFaceExpression.RightEyeClose, k_RightEyeClose);
            k_Expressions.Add(MRFaceExpression.LeftEyebrowRaise, k_LeftBrowRaise);
            k_Expressions.Add(MRFaceExpression.RightEyebrowRaise, k_RightBrowRaise);
            k_Expressions.Add(MRFaceExpression.BothEyebrowsRaise, k_BothBrowsRaise);
            k_Expressions.Add(MRFaceExpression.LeftLipCornerRaise, k_LeftLipCornerRaise);
            k_Expressions.Add(MRFaceExpression.RightLipCornerRaise, k_RightLipCornerRaise);
            k_Expressions.Add(MRFaceExpression.Smile, k_Smile);
            k_Expressions.Add(MRFaceExpression.MouthOpen, k_MouthOpen);
        }

        internal static void CalculateExpressions(this ARFoundationFace arFoundationFace, Vector3[] landmarks)
        {
            var expressions = arFoundationFace.Expressions;
            expressions[MRFaceExpression.LeftEyeClose] = k_LeftEyeClose.Update(landmarks);
            expressions[MRFaceExpression.RightEyeClose] = k_RightEyeClose.Update(landmarks);
            expressions[MRFaceExpression.LeftEyebrowRaise] = k_LeftBrowRaise.Update(landmarks);
            expressions[MRFaceExpression.RightEyebrowRaise] = k_RightBrowRaise.Update(landmarks);
            expressions[MRFaceExpression.BothEyebrowsRaise] = k_BothBrowsRaise.Update(landmarks);
            expressions[MRFaceExpression.LeftLipCornerRaise] = k_LeftLipCornerRaise.Update(landmarks);
            expressions[MRFaceExpression.RightLipCornerRaise] = k_RightLipCornerRaise.Update(landmarks);
            expressions[MRFaceExpression.Smile] = k_Smile.Update(landmarks);
            expressions[MRFaceExpression.MouthOpen] = k_MouthOpen.Update(landmarks);
        }

        public static void SubscribeToExpression(MRFaceExpression name, Action<float> engaged, Action<float> disengaged)
        {
            if (k_Expressions.TryGetValue(name, out var expression))
            {
                if (engaged != null)
                    expression.Engaged += engaged;

                if (disengaged != null)
                    expression.Disengaged += disengaged;
            }
        }

        public static void UnsubscribeToExpression(MRFaceExpression name, Action<float> engaged, Action<float> disengaged)
        {
            if (k_Expressions.TryGetValue(name, out var expression))
            {
                if (engaged != null)
                    expression.Engaged -= engaged;

                if (disengaged != null)
                    expression.Disengaged -= disengaged;
            }
        }
    }
}
#endif
