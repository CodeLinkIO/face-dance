using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation;
using UnityEngine;
using UnityEngine.TestTools;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Tests
{
    class ContentHierarchyCacheTests
    {
        class TestModule : ScriptableObject { }

        Transform m_Parent1;
        Transform m_Parent2;

        Transform m_Parent1Copy;
        Transform m_Parent2Copy;

        TestModule m_Module;
        ContentHierarchyPanel m_ContentHierarchyPanel;
        SinglePanelWindow m_HierarchyWindow;

        Object[] m_PreviousSelection;

        [UnitySetUp]
        public IEnumerator Setup()
        {
            MARSSession.TestMode = true;

            ResetScene();

            m_Module = ScriptableObject.CreateInstance<TestModule>();
            // Setup 2 parents with 1 child each
            m_Parent1 = new GameObject { name = "Parent 1" }.transform;
            var child1 = new GameObject{ name = "Child 1" }.transform;
            child1.SetParent(m_Parent1);

            m_Parent2 = new GameObject{ name = "Parent 2" }.transform;
            var child2 = new GameObject{ name = "Child 2" }.transform;
            child2.SetParent(m_Parent2);

            // Setup MARS entities and session
            m_Parent1.gameObject.AddComponent<Proxy>();
            m_Parent2.gameObject.AddComponent<Proxy>();

            MARSSession.EnsureSessionInActiveScene();

            var moduleLoader = ModuleLoaderCore.instance;
            moduleLoader.GetModule<SimulationSceneModule>().RegisterSimulationUser(m_Module);
            moduleLoader.GetModule<SceneWatchdogModule>().ScenePoll();

            // Open simulation view and hierarchy panel in a window
            EditorWindow.GetWindow<SimulationView>();
            m_ContentHierarchyPanel = ScriptableObject.CreateInstance<ContentHierarchyPanel>();
            m_HierarchyWindow = ScriptableObject.CreateInstance<SinglePanelWindow>();
            m_HierarchyWindow.InitWindow(m_ContentHierarchyPanel);
            m_HierarchyWindow.Show();

            // Change to synthetic type environment
            SimulationSettings.instance.EnvironmentMode = EnvironmentMode.Synthetic;

            // Load an environment
            moduleLoader.GetModule<MARSEnvironmentManager>().RefreshEnvironment();
            var querySimModule = moduleLoader.GetModule<QuerySimulationModule>();
            querySimModule.SimulateOneShot();
            while (querySimModule.simulating)
                yield return null;

            GetCopies();

            // Expand root (parent of parent 1)
            m_ContentHierarchyPanel.HierarchyTreeView.SetExpanded(m_Parent1Copy.parent.gameObject.GetInstanceID(), true);

            // Expand parent 1, collapse parent 2
            m_ContentHierarchyPanel.HierarchyTreeView.SetExpanded(m_Parent1Copy.gameObject.GetInstanceID(), true);
            m_ContentHierarchyPanel.HierarchyTreeView.SetExpanded(m_Parent2Copy.gameObject.GetInstanceID(), false);

            // Select parent2, deselect everything else
            var newSelection = new List<UnityObject>();
            newSelection.Add(m_Parent2Copy.gameObject);
            m_PreviousSelection = Selection.objects;
            Selection.objects = newSelection.ToArray();
        }

        static void ResetScene()
        {
            ModuleLoaderCore.instance.UnloadModules();

            var gameObjects = UnityObject.FindObjectsOfType<GameObject>();
            foreach (var go in gameObjects)
            {
                if (go == null)
                    continue;

                if (go.GetComponent<MARSEntity>())
                {
                    // If part of a prefab destroy the prefab root
                    UnityObject.DestroyImmediate(PrefabUtility.IsPartOfAnyPrefab(go) ?
                        PrefabUtility.GetOutermostPrefabInstanceRoot(go) : go);
                }
            }

            ModuleLoaderCore.instance.LoadModules();
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            MARSSession.TestMode = false;

            // Clear selection to suppress errors due to refreshing inspectors
            Selection.objects = m_PreviousSelection;
            yield return null;

            // This will also destroy the panel since it does not have a parent multi panel view
            m_HierarchyWindow.Close();
            UnityObjectUtils.Destroy(m_Module);

            ResetScene();
        }

        void CheckStateWasRestored()
        {
            GetCopies();

            Assert.True(
                m_ContentHierarchyPanel.HierarchyTreeView.IsExpanded(m_Parent1Copy.gameObject.GetInstanceID()),
                "Expanded transform not expanded anymore.");

            Assert.False(
                m_ContentHierarchyPanel.HierarchyTreeView.IsExpanded(m_Parent2Copy.gameObject.GetInstanceID()),
                "Collapsed transform not collapsed anymore.");

            Assert.True(
                m_ContentHierarchyPanel.HierarchyTreeView.IsSelected(m_Parent2Copy.gameObject.GetInstanceID()),
                "Selected object not selected in hierarchy anymore.");

            Assert.True(
                Selection.Contains(m_Parent2Copy.gameObject),
                "Selected object not selected anymore.");

            Assert.False(
                m_ContentHierarchyPanel.HierarchyTreeView.IsSelected(m_Parent1Copy.gameObject.GetInstanceID()),
                "Unselected transform not unselected anymore.");
        }

        void GetCopies()
        {
            var simObjectManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            m_Parent1Copy = simObjectManager.GetCopiedTransform(m_Parent1);
            m_Parent2Copy = simObjectManager.GetCopiedTransform(m_Parent2);

            Assert.True(m_Parent1Copy != null && m_Parent2Copy != null,
                "Test objects were not copied to the simulation.");
        }

        [UnityTest]
        public IEnumerator SimulateOneShot()
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var querySimModule = moduleLoader.GetModule<QuerySimulationModule>();
            querySimModule.SimulateOneShot();
            while (querySimModule.simulating)
                yield return null;

            CheckStateWasRestored();
        }

        [UnityTest]
        public IEnumerator CycleEnvironment()
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var envManager = moduleLoader.GetModule<MARSEnvironmentManager>();

            envManager.ForceSetupNextEnvironment(true);
            yield return null;
            envManager.ForceSetupNextEnvironment(true);
            yield return null;
            envManager.ForceSetupNextEnvironment(true);

            var querySimModule = moduleLoader.GetModule<QuerySimulationModule>();
            querySimModule.SimulateOneShot();
            while (querySimModule.simulating)
                yield return null;

            CheckStateWasRestored();
        }

        [UnityTest]
        public IEnumerator SimulateOneShotForceDirtyScene()
        {
            var moduleLoader = ModuleLoaderCore.instance;
            moduleLoader.GetModule<SimulatedObjectsManager>().DirtySimulatableScene();
            var querySimModule = moduleLoader.GetModule<QuerySimulationModule>();
            querySimModule.SimulateOneShot();
            while (querySimModule.simulating)
                yield return null;

            CheckStateWasRestored();
        }

        [UnityTest]
        public IEnumerator ReloadModules()
        {
            m_ContentHierarchyPanel.CacheState();
            var moduleLoader = ModuleLoaderCore.instance;
            moduleLoader.ReloadModules();

            // Wait a frame for lazy operations like updating selection
            yield return null;

            moduleLoader.GetModule<SimulationSceneModule>().RegisterSimulationUser(m_Module);
            moduleLoader.GetModule<MARSEnvironmentManager>().RefreshEnvironment();
            var querySimModule = moduleLoader.GetModule<QuerySimulationModule>();
            querySimModule.SimulateOneShot();
            while (querySimModule.simulating)
                yield return null;

            CheckStateWasRestored();
        }
    }
}
