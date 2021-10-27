#if UNITY_IOS && !UNITY_EDITOR && INCLUDE_ARKIT_FACE_PLUGIN
using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine.XR.ARKit;
using UnityEngine.XR.ARSubsystems;

namespace Unity.MARS.Data.ARFoundation
{
    static class ARKitFaceExpressionsExtensions
    {
        static readonly ARKitBothEyebrowsRaiseExpression k_BothBrowsRaise;
        static readonly ARKitMouthOpenExpression k_MouthOpen = new ARKitMouthOpenExpression();
        static readonly ARKitSmileExpression k_Smile = new ARKitSmileExpression();
        static readonly ARKitLeftLipCornerRaiseExpression k_LeftLipCornerRaise = new ARKitLeftLipCornerRaiseExpression();
        static readonly ARKitRightLipCornerRaiseExpression k_RightLipCornerRaise = new ARKitRightLipCornerRaiseExpression();
        static readonly ARKitLeftEyeCloseExpression k_LeftEyeClose = new ARKitLeftEyeCloseExpression();
        static readonly ARKitRightEyeCloseExpression k_RightEyeClose = new ARKitRightEyeCloseExpression();
        static readonly ARKitLeftEyebrowRaiseExpression k_LeftBrowRaise = new ARKitLeftEyebrowRaiseExpression();
        static readonly ARKitRightEyebrowRaiseExpression k_RightBrowRaise = new ARKitRightEyebrowRaiseExpression();

        static readonly Dictionary<string, float> k_BlendShapes = new Dictionary<string, float>();
        static readonly Dictionary<MRFaceExpression, ARKitFaceExpression> k_Expressions = new Dictionary<MRFaceExpression, ARKitFaceExpression>();

        static ARKitFaceExpressionsExtensions()
        {
            k_BothBrowsRaise = new ARKitBothEyebrowsRaiseExpression(k_LeftBrowRaise, k_RightBrowRaise);

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

        internal static void CalculateExpressions(this ARFoundationFace arFoundationFace, XRFaceSubsystem xrFaceSubsystem, TrackableId faceId)
        {
            GetFaceBlendShapes(xrFaceSubsystem, faceId, k_BlendShapes);

            var expressions = arFoundationFace.Expressions;
            expressions[MRFaceExpression.LeftEyeClose] = k_LeftEyeClose.Update(k_BlendShapes);
            expressions[MRFaceExpression.RightEyeClose] = k_RightEyeClose.Update(k_BlendShapes);
            expressions[MRFaceExpression.LeftEyebrowRaise] = k_LeftBrowRaise.Update(k_BlendShapes);
            expressions[MRFaceExpression.RightEyebrowRaise] = k_RightBrowRaise.Update(k_BlendShapes);
            expressions[MRFaceExpression.BothEyebrowsRaise] = k_BothBrowsRaise.Update(k_BlendShapes);
            expressions[MRFaceExpression.LeftLipCornerRaise] = k_LeftLipCornerRaise.Update(k_BlendShapes);
            expressions[MRFaceExpression.RightLipCornerRaise] = k_RightLipCornerRaise.Update(k_BlendShapes);
            expressions[MRFaceExpression.Smile] = k_Smile.Update(k_BlendShapes);
            expressions[MRFaceExpression.MouthOpen] = k_MouthOpen.Update(k_BlendShapes);
        }

        static void GetFaceBlendShapes(XRFaceSubsystem xrFaceSubsystem, TrackableId faceId, Dictionary<string, float> blendshapes)
        {
            var arKitFaceSubsystem = (ARKitFaceSubsystem)xrFaceSubsystem;
            blendshapes.Clear();

            using (var blendShapeCoefficients = arKitFaceSubsystem.GetBlendShapeCoefficients(faceId, Allocator.Temp))
            {
                foreach (var featureCoefficient in blendShapeCoefficients)
                {
                    blendshapes[featureCoefficient.blendShapeLocation.ToString()] = featureCoefficient.coefficient;
                }
            }
        }

        internal static void SubscribeToExpression(MRFaceExpression name, Action<float> engaged, Action<float> disengaged)
        {
            if (k_Expressions.TryGetValue(name, out var expression))
            {
                if (engaged != null)
                    expression.Engaged += engaged;

                if (disengaged != null)
                    expression.Disengaged += disengaged;
            }
        }

        internal static void UnsubscribeToExpression(MRFaceExpression name, Action<float> engaged, Action<float> disengaged)
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
