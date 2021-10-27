using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.MARS;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace UnityEditor.MARS.Tests
{
    class SimulationEnvironmentModeSettingsTests
    {
        class TestSimulationUser : ScriptableObject {}

        [Serializable]
        class TestSimulationEnvironmentModeSettings : SimulationEnvironmentModeSettings
        {
            internal SimulationModeSelection TestDefaultSimulationMode;
            internal int TestActiveEnvironmentIndex;
            internal GUIContent[] TestEnvironmentSwitchingContents;
            internal string TestEnvironmentModeName;
            internal bool TestIsFramingEnabled;

            public override string EnvironmentModeName => TestEnvironmentModeName;

            public override SimulationModeSelection DefaultSimulationMode => TestDefaultSimulationMode;
            public override bool IsFramingEnabled => TestIsFramingEnabled;
            public override bool IsMovementEnabled => true;
            public override bool HasEnvironmentSwitching => true;
            public override GUIContent[] EnvironmentSwitchingContents => TestEnvironmentSwitchingContents;
            public override int ActiveEnvironmentIndex => TestActiveEnvironmentIndex;

            public override void SetActiveEnvironment(int index)
            {
                TestActiveEnvironmentIndex = index;
            }

            public override void FindEnvironmentCandidates()
            {
                TestEnvironmentSwitchingContents = new []
                {
                    new GUIContent("Test 0"),
                    new GUIContent("Test 1"),
                    new GUIContent("Test 2")
                };
            }

            public override void OpenSimulationEnvironment()
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.name = $"{EnvironmentModeName}_{ActiveEnvironmentIndex}";

                var envManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
                go.transform.SetParent(envManager.EnvironmentParent.transform, true);
            }
        }

        TestSimulationUser m_TestSimulationUser;
        SimulationEnvironmentModeSettings m_CachedEnvironmentModeSettings;
        EnvironmentMode m_CachedEnvironmentMode;

        MARSEnvironmentManager m_EnvironmentManager;
        QuerySimulationModule m_QuerySimulationModule;

        Dictionary<string, SimulationEnvironmentModeSettings> m_TestModeSettings = new Dictionary<string, SimulationEnvironmentModeSettings>();

        [OneTimeSetUp]
        public void Setup()
        {
            MARSSession.TestMode = true;
            QuerySimulationModule.TestMode = true;
            m_TestSimulationUser = ScriptableObject.CreateInstance<TestSimulationUser>();
            MARSSession.EnsureSessionInActiveScene();

            var moduleLoader = ModuleLoaderCore.instance;
            moduleLoader.GetModule<SimulationSceneModule>().RegisterSimulationUser(m_TestSimulationUser);
            moduleLoader.GetModule<SceneWatchdogModule>().ScenePoll();

            EditorWindow.GetWindow<SimulationView>(); // Tests will fail if a Simulation isn't open.

            m_EnvironmentManager = moduleLoader.GetModule<MARSEnvironmentManager>();
            m_CachedEnvironmentModeSettings = m_EnvironmentManager.CustomModeSettings;
            m_CachedEnvironmentMode = SimulationSettings.instance.EnvironmentMode;

            m_TestModeSettings.Clear();
            var testModeA = ScriptableObject.CreateInstance<TestSimulationEnvironmentModeSettings>();
            testModeA.TestDefaultSimulationMode = SimulationModeSelection.TemporalMode;
            testModeA.TestIsFramingEnabled = false;
            testModeA.TestEnvironmentModeName = "TestSimulationEnvironmentModeSettings_testModeA";
            m_TestModeSettings.Add(testModeA.EnvironmentModeName, testModeA);

            var testModeB = ScriptableObject.CreateInstance<TestSimulationEnvironmentModeSettings>();
            testModeB.TestDefaultSimulationMode = SimulationModeSelection.SingleFrameMode;
            testModeA.TestIsFramingEnabled = true;
            testModeB.TestEnvironmentModeName = "TestSimulationEnvironmentModeSettings_testModeB";
            m_TestModeSettings.Add(testModeB.EnvironmentModeName, testModeB);

            ResetScene();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var moduleLoader = ModuleLoaderCore.instance;
            moduleLoader.GetModule<SimulationSceneModule>().UnregisterSimulationUser(m_TestSimulationUser);

            UnityObjectUtils.Destroy(m_TestSimulationUser);
            foreach (var testModeSetting in m_TestModeSettings)
            {
                UnityObjectUtils.Destroy(testModeSetting.Value);
            }
            m_TestModeSettings.Clear();

            MARSSession.TestMode = false;
            QuerySimulationModule.TestMode = false;
            ResetScene();
            m_EnvironmentManager.TrySetModeAndRestartSimulation(m_CachedEnvironmentMode);
        }

        void ResetScene()
        {
            ModuleLoaderCore.instance.UnloadModules();
            ModuleLoaderCore.instance.LoadModules();

            m_EnvironmentManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
            m_QuerySimulationModule = ModuleLoaderCore.instance.GetModule<QuerySimulationModule>();

            if (m_EnvironmentManager == null)
                return;

            SetEnvironmentModeSettings(m_CachedEnvironmentModeSettings);
        }

        void SetEnvironmentModeSettings(SimulationEnvironmentModeSettings settings)
        {
            m_EnvironmentManager.CustomModeSettings = settings;
            m_EnvironmentManager.UpdateSimulatedEnvironmentCandidates();
        }

        void CheckTestSetup()
        {
            Assert.True(m_EnvironmentManager != null, "`MARSEnvironmentManager` failed to load and is Null.");
        }

        SimulationEnvironmentModeSettings GetModeSettings(string name)
        {
            Assert.True(m_TestModeSettings.TryGetValue(name, out var settings));
            return settings;
        }

        static bool FindTestGameObject(MARSEnvironmentManager envManager, string name)
        {
            var root = envManager.EnvironmentParent;
            Assert.True(root != null);
            for (var i = 0; i < root.transform.childCount; i++)
            {
                var child = root.transform.GetChild(i);
                if (child.name == name)
                    return true;
            }

            return false;
        }

        SimulationEnvironmentModeSettings GetCustomEnvironmentModeSettingsApplied(string name)
        {
            var settings = GetModeSettings(name);
            CheckTestSetup();
            SetEnvironmentModeSettings(settings);
            Assert.True(m_EnvironmentManager.HasCustomModeSettings);
            Assert.True(m_EnvironmentManager.CustomModeSettings == settings,
                $"Custom Mode Settings not set to the correct object `{nameof(settings)}`.");

            Assert.True(MARSEnvironmentManager.ModeTypes.Select(s => s.text == settings.EnvironmentModeName) != null,
                "Name of custom mode not available in `MARSEnvironmentManager.ModeTypes`");

            return settings;
        }

        [TestCase("TestSimulationEnvironmentModeSettings_testModeA")]
        [TestCase("TestSimulationEnvironmentModeSettings_testModeB")]
        public void CustomEnvironmentModeSettingsApplied(string name)
        {
            Assert.NotNull(GetCustomEnvironmentModeSettingsApplied(name));
            m_QuerySimulationModule.SimulateOneShot(); // Simulating after setting up the environment resets the simulation mode selection
        }

        [Test]
        public void CustomEnvironmentModeSettingsNull()
        {
            CheckTestSetup();
            SetEnvironmentModeSettings(null);
            Assert.False(m_EnvironmentManager.HasCustomModeSettings);
            Assert.True(m_EnvironmentManager.CustomModeSettings == null,
                "Custom Mode Settings not set to 'Null'.");
            Assert.True(MARSEnvironmentManager.ModeTypes.Select(s => s.text == MARSEnvironmentManager.NoModeSettingsName) != null,
                "Name of custom mode not set to 'MARSEnvironmentManager.NoModeSettingsName'");

            m_QuerySimulationModule.SimulateOneShot();
        }

        [TestCase("TestSimulationEnvironmentModeSettings_testModeA")]
        [TestCase("TestSimulationEnvironmentModeSettings_testModeB")]
        public void CustomEnvironmentModeAvailable(string name)
        {
            var settings = GetCustomEnvironmentModeSettingsApplied(name);
            var modeContext = MARSEnvironmentManager.ModeTypes.FirstOrDefault(s => s.text == settings.EnvironmentModeName);
            var modeIndex = Array.IndexOf(MARSEnvironmentManager.ModeTypes, modeContext);
            Assert.True(modeIndex == (int)EnvironmentMode.Custom, "EnvironmentMode.Custom is not at the correct index to be selectable.");
            m_QuerySimulationModule.SimulateOneShot();

            SetEnvironmentModeSettings(null);
            Assert.False(m_EnvironmentManager.HasCustomModeSettings);
            Assert.False(MARSEnvironmentManager.ModeTypes.FirstOrDefault(f => f.text.Contains("Custom")) != null,
                "Has Custom EnvironmentMode when none should be present.");

            m_QuerySimulationModule.SimulateOneShot();
        }

        [TestCase("TestSimulationEnvironmentModeSettings_testModeA")]
        [TestCase("TestSimulationEnvironmentModeSettings_testModeB")]
        public void EnvironmentModeSwitching(string name)
        {
            var settings = GetModeSettings(name);
            CheckTestSetup();
            SetEnvironmentModeSettings(settings);
            m_EnvironmentManager.TrySetModeAndRestartSimulation(EnvironmentMode.Custom);
            Assert.True(SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Custom);
            var envObjectName = $"{settings.EnvironmentModeName}_{settings.ActiveEnvironmentIndex}";
            Assert.True(FindTestGameObject(m_EnvironmentManager, envObjectName));
            m_QuerySimulationModule.SimulateOneShot();

            SetEnvironmentModeSettings(null);
            m_EnvironmentManager.TrySetModeAndRestartSimulation(EnvironmentMode.Synthetic);
            Assert.True(FindTestGameObject(m_EnvironmentManager, envObjectName) == false);
            m_QuerySimulationModule.SimulateOneShot();
        }

        [TestCase("TestSimulationEnvironmentModeSettings_testModeA")]
        [TestCase("TestSimulationEnvironmentModeSettings_testModeB")]
        public void CustomEnvironmentModeActive(string name)
        {
            var settings = GetCustomEnvironmentModeSettingsApplied(name);
            m_EnvironmentManager.TrySetModeAndRestartSimulation(EnvironmentMode.Custom);
            Assert.True(SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Custom);

            Assert.True(m_EnvironmentManager.IsFramingEnabled == settings.IsFramingEnabled);
            Assert.True(m_EnvironmentManager.IsMovementEnabled == settings.IsMovementEnabled);
            Assert.True(m_QuerySimulationModule.NextSimModeSelection == settings.DefaultSimulationMode);
            m_QuerySimulationModule.SimulateOneShot();
        }

        [TestCase("TestSimulationEnvironmentModeSettings_testModeA")]
        [TestCase("TestSimulationEnvironmentModeSettings_testModeB")]
        public void ActiveEnvironmentSwitching(string name)
        {
            var settings = GetCustomEnvironmentModeSettingsApplied(name);
            m_EnvironmentManager.TrySetModeAndRestartSimulation(EnvironmentMode.Custom);
            Assert.True(SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Custom);
            m_QuerySimulationModule.SimulateOneShot();
            if (!settings.HasEnvironmentSwitching)
                return;

            settings.SetActiveEnvironment(0);
            for (var i = 0; i < settings.EnvironmentSwitchingContents.Length; i++)
            {
                m_EnvironmentManager.ForceSetupNextEnvironment(true);
                var envObjectName = $"{settings.EnvironmentModeName}_{settings.ActiveEnvironmentIndex}";
                Assert.True(FindTestGameObject(m_EnvironmentManager, envObjectName));
            }
        }
    }
}
