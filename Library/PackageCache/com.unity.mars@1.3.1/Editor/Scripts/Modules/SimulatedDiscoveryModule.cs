using System.Collections.Generic;
using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Fakes discovery of scene data for simulations
    /// </summary>
    [ModuleOrder(ModuleOrders.SimDiscoveryLoadOrder)]
    class SimulatedDiscoveryModule : IModuleDependency<MARSEnvironmentManager>
    {
        MARSEnvironmentManager m_EnvironmentManager;

        bool m_EnvironmentPrepared;

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        // Reference type collections must also be cleared after use
        static readonly List<MeshRenderer> k_EnvironmentMeshes = new List<MeshRenderer>();

        void IModuleDependency<MARSEnvironmentManager>.ConnectDependency(MARSEnvironmentManager dependency) { m_EnvironmentManager = dependency; }

        void IModule.LoadModule()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode && !MARSSceneModule.simulatedDiscoveryInPlayMode)
                return;

            MARSEnvironmentManager.onEnvironmentSetup += OnEnvironmentSetup;
            QuerySimulationModule.BeforeSimulationSetup += OnBeforeSimulationSetup;

            if (m_EnvironmentManager.EnvironmentSetup)
                OnEnvironmentSetup();
        }

        void IModule.UnloadModule()
        {
            MARSEnvironmentManager.onEnvironmentSetup -= OnEnvironmentSetup;
            QuerySimulationModule.BeforeSimulationSetup -= OnBeforeSimulationSetup;

            m_EnvironmentPrepared = false;
        }

        void OnBeforeSimulationSetup()
        {
            if (SimulationSettings.instance.EnvironmentMode != EnvironmentMode.Synthetic)
                return;

            if (QuerySimulationModule.instance.simulatingTemporal)
                PrepareEnvironment();
        }

        void OnEnvironmentSetup()
        {
            m_EnvironmentPrepared = false;
            if (SimulationSettings.instance.EnvironmentMode != EnvironmentMode.Synthetic)
                return;

            var playing = EditorApplication.isPlayingOrWillChangePlaymode;
            if (playing || QuerySimulationModule.instance.simulatingTemporal)
                PrepareEnvironment();
        }

        void PrepareEnvironment()
        {
            // if this environment has already been prepared, when opened or on a previous start, we're good
            if (m_EnvironmentPrepared)
                return;

            EnsureMeshColliders(m_EnvironmentManager.EnvironmentParent);
            m_EnvironmentPrepared = true;
        }

        static void EnsureMeshColliders(GameObject root)
        {
            // k_EnvironmentMeshes is cleared by GetComponentsInChildren
            root.GetComponentsInChildren(k_EnvironmentMeshes);
            foreach (var mesh in k_EnvironmentMeshes)
            {
                if (mesh.GetComponentInParent<GeneratedPlanesRoot>())
                    continue;

                var meshObject = mesh.gameObject;

                if (mesh.GetComponent<MeshCollider>() != null)
                    continue;

                meshObject.hideFlags = HideFlags.DontSave;
                meshObject.AddComponent<MeshCollider>();
            }

            k_EnvironmentMeshes.Clear();
        }
    }
}
