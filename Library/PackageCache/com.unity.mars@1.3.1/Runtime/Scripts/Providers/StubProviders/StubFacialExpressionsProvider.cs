using System;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Providers
{
    [AddComponentMenu("")]
    [ProviderSelectionOptions(ProviderPriorities.StubProviderPriority)]
    class StubFacialExpressionsProvider : StubProvider, IProvidesFacialExpressions
    {
        public override void ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesFacialExpressions>(obj);
        }

        public void SubscribeToExpression(MRFaceExpression expression, Action<float> engaged, Action<float> disengaged) { }

        public void UnsubscribeToExpression(MRFaceExpression expression, Action<float> engaged, Action<float> disengaged) { }
    }
}
