using System.Collections;
using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEditor.MARS.Simulation;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace Unity.MARS.Tests
{
    class EnvironmentManagerTests
    {
        [UnityTest]
        public IEnumerator RefreshEnvironmentWithSimulationObjectSelected()
        {
            var environmentManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
            var environmentParent = environmentManager.EnvironmentParent;
            Selection.activeObject = environmentParent;

            yield return null;

            SimulationSceneModule.isAssemblyReloading = true;
            environmentManager.RefreshEnvironment();
            foreach (var editor in Resources.FindObjectsOfTypeAll<Editor>())
            {
                Assert.IsNotNull(editor.target);
            }

            SimulationSceneModule.isAssemblyReloading = false;
        }
    }
}
