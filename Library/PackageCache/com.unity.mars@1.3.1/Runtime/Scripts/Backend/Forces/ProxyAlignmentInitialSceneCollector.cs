using System;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Forces
{
    /// <summary>
    /// As a scene starts, this class loops over all ProxyAlignmentForces which have been created
    /// but have not been Enabled/Awakened yet, so that they can get their initial
    /// poses and authored relative alignment before things start moving around,
    /// even if they start disabled.
    /// </summary>
    internal class ProxyAlignmentInitialSceneCollector : IModuleBehaviorCallbacks
    {
        [RuntimeInitializeOnLoadMethod]
        static void OnRuntimeMethodLoad()
        {
            ProxyAlignmentForce.DoSceneInitAlignment();
        }

        void IModule.LoadModule() { OnRuntimeMethodLoad(); }
        void IModule.UnloadModule() { }
        void IModuleBehaviorCallbacks.OnBehaviorAwake() { OnRuntimeMethodLoad(); }
        void IModuleBehaviorCallbacks.OnBehaviorEnable() { }
        void IModuleBehaviorCallbacks.OnBehaviorStart() { }
        void IModuleBehaviorCallbacks.OnBehaviorUpdate() { }
        void IModuleBehaviorCallbacks.OnBehaviorDisable() { }
        void IModuleBehaviorCallbacks.OnBehaviorDestroy() { }
    }
}
