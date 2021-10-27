using System;
using Unity.MARS.Attributes;
using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Actions
{
    [Serializable]
    [HelpURL(DocumentationConstants.FaceExpressionActionDocs)]
    [Event(typeof(FaceExpressionEvent))]
    [MovedFrom("Unity.MARS")]
    public class FaceExpressionEvent : UnityEvent<float> { }

    // TODO: Require face trait!
    [MonoBehaviourComponentMenu(typeof(FaceExpressionAction), "Action/Face Expressions")]
    [MovedFrom("Unity.MARS")]
    public class FaceExpressionAction : MonoBehaviour, IUsesFacialExpressions, IMatchAcquireHandler, IMatchLossHandler
    {
        [SerializeField]
        FaceExpressionEvent m_LeftEyeClose = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_LeftEyeOpen = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_RightEyeClose = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_RightEyeOpen = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_LeftEyebrowRaise = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_LeftEyebrowLower = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_RightEyebrowRaise = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_RightEyebrowLower = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_BothEyebrowsRaise = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_BothEyebrowsLower = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_LeftLipCornerRaise = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_LeftLipCornerLower = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_RightLipCornerRaise = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_RightLipCornerLower = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_SmileEngaged = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_SmileDisengaged = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_MouthOpen = new FaceExpressionEvent();
        [SerializeField]
        FaceExpressionEvent m_MouthClosed = new FaceExpressionEvent();

        /// <inheritdoc />
        public IProvidesFacialExpressions provider { get; set; }

        /// <inheritdoc />
        public void OnMatchAcquire(QueryResult queryResult)
        {
            provider.SubscribeToExpression(MRFaceExpression.LeftEyeClose, ec => m_LeftEyeClose.Invoke(ec), ec => m_LeftEyeOpen.Invoke(ec));
            provider.SubscribeToExpression(MRFaceExpression.RightEyeClose, ec => m_RightEyeClose.Invoke(ec), ec => m_RightEyeOpen.Invoke(ec));
            provider.SubscribeToExpression(MRFaceExpression.LeftEyebrowRaise, ec => m_LeftEyebrowRaise.Invoke(ec), ec => m_LeftEyebrowLower.Invoke(ec));
            provider.SubscribeToExpression(MRFaceExpression.RightEyebrowRaise, ec => m_RightEyebrowRaise.Invoke(ec), ec => m_RightEyebrowLower.Invoke(ec));
            provider.SubscribeToExpression(MRFaceExpression.BothEyebrowsRaise, ec => m_BothEyebrowsRaise.Invoke(ec), ec => m_BothEyebrowsLower.Invoke(ec));
            provider.SubscribeToExpression(MRFaceExpression.LeftLipCornerRaise, ec => m_LeftLipCornerRaise.Invoke(ec), ec => m_LeftLipCornerLower.Invoke(ec));
            provider.SubscribeToExpression(MRFaceExpression.RightLipCornerRaise, ec => m_RightLipCornerRaise.Invoke(ec), ec => m_RightLipCornerLower.Invoke(ec));
            provider.SubscribeToExpression(MRFaceExpression.Smile, ec => m_SmileEngaged.Invoke(ec), ec => m_SmileDisengaged.Invoke(ec));
            provider.SubscribeToExpression(MRFaceExpression.MouthOpen, ec => m_MouthOpen.Invoke(ec), ec => m_MouthClosed.Invoke(ec));
        }

        /// <inheritdoc />
        public void OnMatchLoss(QueryResult queryResult)
        {
            provider.UnsubscribeToExpression(MRFaceExpression.LeftEyeClose, ec => m_LeftEyeClose.Invoke(ec), ec => m_LeftEyeOpen.Invoke(ec));
            provider.UnsubscribeToExpression(MRFaceExpression.RightEyeClose, ec => m_RightEyeClose.Invoke(ec), ec => m_RightEyeOpen.Invoke(ec));
            provider.UnsubscribeToExpression(MRFaceExpression.LeftEyebrowRaise, ec => m_LeftEyebrowRaise.Invoke(ec), ec => m_LeftEyebrowLower.Invoke(ec));
            provider.UnsubscribeToExpression(MRFaceExpression.RightEyebrowRaise, ec => m_RightEyebrowRaise.Invoke(ec), ec => m_RightEyebrowLower.Invoke(ec));
            provider.UnsubscribeToExpression(MRFaceExpression.BothEyebrowsRaise, ec => m_BothEyebrowsRaise.Invoke(ec), ec => m_BothEyebrowsLower.Invoke(ec));
            provider.UnsubscribeToExpression(MRFaceExpression.LeftLipCornerRaise, ec => m_LeftLipCornerRaise.Invoke(ec), ec => m_LeftLipCornerLower.Invoke(ec));
            provider.UnsubscribeToExpression(MRFaceExpression.RightLipCornerRaise, ec => m_RightLipCornerRaise.Invoke(ec), ec => m_RightLipCornerLower.Invoke(ec));
            provider.UnsubscribeToExpression(MRFaceExpression.Smile, ec => m_SmileEngaged.Invoke(ec), ec => m_SmileDisengaged.Invoke(ec));
            provider.UnsubscribeToExpression(MRFaceExpression.MouthOpen, ec => m_MouthOpen.Invoke(ec), ec => m_MouthClosed.Invoke(ec));
        }
    }
}
