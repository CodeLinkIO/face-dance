using Unity.MARS.Settings;
using UnityEngine;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;

namespace Unity.MARS.Forces
{
    [ModuleOrder(ModuleOrders.ForcesFieldSolverLoadOrder)]
    [ScriptableSettingsPath(MARSCore.SettingsFolder)]
    class ProxyForcesFieldSolverModule : ScriptableSettings<ProxyForcesFieldSolverModule>, IModuleBehaviorCallbacks
    {
        ProxyForcesFieldSolver m_MainFieldSolver = new ProxyForcesFieldSolver();

#pragma warning disable 649
        [SerializeField]
        bool m_ShowForcesInSceneView;
#pragma warning restore 649

        internal ProxyForcesFieldSolver mainFieldSolver => m_MainFieldSolver;

        public void ResetMainGroup()
        {
            mainFieldSolver.Clear();
        }

        public static ProxyForcesFieldSolverModule EnsureInstance(GameObject from, ref ProxyForcesFieldSolverModule ptr)
        {
            if (ptr)
            {
                return ptr;
            }
            ptr = ProxyForcesFieldSolverModule.instance;
            return ptr;
        }

        void IModuleBehaviorCallbacks.OnBehaviorAwake()
        {
            ResetMainGroup();
        }

        void IModuleBehaviorCallbacks.OnBehaviorEnable()
        {
        }

        void IModuleBehaviorCallbacks.OnBehaviorStart()
        {
        }

        void IModuleBehaviorCallbacks.OnBehaviorUpdate()
        {
            mainFieldSolver.ShowForcesAsLines = this.m_ShowForcesInSceneView;
        }

        void IModuleBehaviorCallbacks.OnBehaviorDisable()
        {
        }

        void IModuleBehaviorCallbacks.OnBehaviorDestroy()
        {
            mainFieldSolver.Dispose();
        }

        void IModule.LoadModule()
        {
            ResetMainGroup();
        }

        void IModule.UnloadModule()
        {
            ResetMainGroup();
            mainFieldSolver.Dispose();
        }
    }
}
