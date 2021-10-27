using System;
using System.Collections.Generic;
using System.Text;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace Unity.XRTools.ModuleLoader
{
    /// <summary>
    /// Module responsible for managing Functionality Islands
    /// </summary>
    [ImmortalModule]
    [ScriptableSettingsPath(ModuleLoaderCore.SettingsPath)]
    public class FunctionalityInjectionModule : ScriptableSettings<FunctionalityInjectionModule>, IModuleBehaviorCallbacks
    {
        const string k_DefaultIslandPath = ModuleLoaderCore.ModuleLoaderAssetsFolder + "/Default Island.asset";

#pragma warning disable 649
        [SerializeField]
        FunctionalityIsland m_DefaultIsland;
#pragma warning restore 649

        bool m_Loaded;

        readonly HashSet<FunctionalityIsland> m_Islands = new HashSet<FunctionalityIsland>();

        /// <summary>
        /// Currently loaded functionality islands
        /// </summary>
        public HashSet<FunctionalityIsland> islands { get { return m_Islands; } }

        /// <summary>
        /// The default functionality island
        /// </summary>
        public FunctionalityIsland defaultIsland { get { return m_DefaultIsland; } }

        /// <summary>
        /// The active functionality island
        /// </summary>
        public FunctionalityIsland activeIsland { get; private set; }

        /// <summary>
        /// Invoked when the active island changes
        /// </summary>
        public event Action<FunctionalityIsland> activeIslandChanged;

        // We have to set up islands before the other modules get loaded so they can use FI
        internal void PreLoad()
        {
            if (!m_DefaultIsland)
            {
#if UNITY_EDITOR
                DebugUtils.Log("You must set up a default functionality island. One has been created for you.");
                m_DefaultIsland = CreateInstance<FunctionalityIsland>();
                AssetDatabase.CreateAsset(m_DefaultIsland, k_DefaultIslandPath);
                EditorUtility.SetDirty(this);
                if (!Application.isBatchMode)
                    AssetDatabase.SaveAssets();
#else
                Debug.LogError("You must set up a default functionality island.");
                return;
#endif
            }

            m_DefaultIsland.Setup();
            m_Islands.Add(m_DefaultIsland);
            activeIsland = m_DefaultIsland;
        }

        /// <summary>
        /// Called after all modules have been instantiated and dependencies are connected
        /// </summary>
        void IModule.LoadModule()
        {
            m_Loaded = true;
        }

        /// <summary>
        /// Called before system shuts down
        /// </summary>
        void IModule.UnloadModule()
        {
            foreach (var island in m_Islands)
            {
                if (island)
                    island.Unload();
                else
                    Debug.LogError("Encountered a null island during Unload--this should only happen if you recently deleted a Functionality Island asset");
            }

            activeIsland = null;
            m_Islands.Clear();
            m_Loaded = false;
        }

        /// <summary>
        /// Set up a Functionality Island and add it to the list of islands
        /// This must be done before the FunctionalityInjectionModule is loaded
        /// The recommended pattern is to implement IModuleDependency&lt;FunctionalityInjectionModule&gt; and add the
        /// island in ConnectDependency. If a hard dependency is not possible, ensure your module has a load order
        /// which is earlier than FunctionalityInjectionModule and add the island in LoadModule
        /// </summary>
        /// <param name="island">The functionality island to add to the list of islands</param>
        public void AddIsland(FunctionalityIsland island)
        {
            // Do not add the default island, as it will be added automatically
            if (island == m_DefaultIsland)
                return;

            Assert.IsFalse(m_Loaded, "It is too late to add a functionality island. All modules are loaded");
            Assert.IsNotNull(island, "Trying to add an island that is null");
            var wasAdded = m_Islands.Add(island);
            Assert.IsTrue(wasAdded, "Island has already been added");

            island.Setup();
        }

        /// <summary>
        /// Set the active island
        /// </summary>
        /// <param name="island">The island to set as the active island; it must have already been added</param>
        public void SetActiveIsland(FunctionalityIsland island)
        {
            Assert.IsTrue(m_Islands.Contains(island), string.Format("Cannot set active island to {0}. It is not in the list of islands", island));
            activeIsland = island;

            if (activeIslandChanged != null)
                activeIslandChanged(island);
        }

        /// <summary>
        /// Return a string describing the current state of this module, including which islands are loaded,
        /// which island is active, and what providers have been added to each island.
        /// </summary>
        /// <returns>A string describing the current state of this module</returns>
        public string PrintStatus()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("Active Island: {0}\nCurrent Islands ({1}):\n", activeIsland.name, m_Islands.Count));
            foreach (var island in m_Islands)
            {
                sb.Append(island.PrintStatus());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Called by ModuleCallbacksBehaviour Awake as early as possible (using a very low Script Execution Order)
        /// </summary>
        void IModuleBehaviorCallbacks.OnBehaviorAwake() {}

        /// <summary>
        /// Called by ModuleCallbacksBehaviour OnEnable as early as possible (using a very low Script Execution Order)
        /// </summary>
        void IModuleBehaviorCallbacks.OnBehaviorEnable() {}

        /// <summary>
        /// Called by ModuleCallbacksBehaviour Start as early as possible (using a very low Script Execution Order)
        /// </summary>
        void IModuleBehaviorCallbacks.OnBehaviorStart() {}

        /// <summary>
        /// Called by ModuleCallbacksBehaviour Update as early as possible (using a very low Script Execution Order)
        /// </summary>
        void IModuleBehaviorCallbacks.OnBehaviorUpdate() {}

        /// <summary>
        /// Called by ModuleCallbacksBehaviour OnDisable as early as possible (using a very low Script Execution Order)
        /// </summary>
        void IModuleBehaviorCallbacks.OnBehaviorDisable() {}

        /// <summary>
        /// Called by ModuleCallbacksBehaviour OnDestroy as early as possible (using a very low Script Execution Order)
        /// </summary>
        void IModuleBehaviorCallbacks.OnBehaviorDestroy()
        {
            foreach (var island in m_Islands)
            {
                island.OnBehaviorDestroy();
            }
        }
    }
}
