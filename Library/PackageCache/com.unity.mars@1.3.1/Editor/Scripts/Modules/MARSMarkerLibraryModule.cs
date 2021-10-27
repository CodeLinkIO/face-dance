using System;
using System.Collections.Generic;
using Unity.XRTools.ModuleLoader;
using Unity.MARS.Data;
using UnityEditor;
using UnityEngine;
#if UNITY_2021_2_OR_NEWER
using UnityEditor.SceneManagement;
#else
using UnityEditor.Experimental.SceneManagement;
#endif
using UnityEditor.MARS.Simulation;

namespace Unity.MARS
{
    class MARSMarkerLibraryModule : IModule
    {
        static readonly GUIContent k_SelectFromActiveLibrary = new GUIContent("Select from Active Library");

        readonly Dictionary<Guid, MarsMarkerLibrary> m_MarkerIDToLibrary = new Dictionary<Guid, MarsMarkerLibrary>();
        readonly Dictionary<int, Guid> m_GUIContentIDToMarkerID = new Dictionary<int, Guid>();
        readonly Dictionary<Guid, int> m_MarkerIDToGUIContentID = new Dictionary<Guid, int>();

        MarsMarkerLibrary[] m_MarkerLibraries;
        GUIContent[] m_MarkerDefinitionsContent;

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<SynthesizedMarkerId> k_SyntheticMarkers = new List<SynthesizedMarkerId>();

        void IModule.LoadModule()
        {
            UpdateMarkerDataFromLibraries();

            ImageMarkerEditorUtils.ImageMarkerSizeUpdate += OnUpdatedSyntheticImageMarkerSize;

            EditorApplication.update += EditorUpdate;
        }

        void IModule.UnloadModule()
        {
            m_MarkerIDToLibrary.Clear();
            m_GUIContentIDToMarkerID.Clear();
            m_MarkerIDToGUIContentID.Clear();

            ImageMarkerEditorUtils.ImageMarkerSizeUpdate -= OnUpdatedSyntheticImageMarkerSize;

            EditorApplication.update -= EditorUpdate;
        }

        void EditorUpdate()
        {
            UpdateSyntheticMarkersMaterials();
        }

        void UpdateSyntheticMarkersMaterials()
        {
            var loadedEnv = MARSEnvironmentManager.instance.CurrentLoadedPrefabInstanceEnvironment;
            if (loadedEnv != null)
            {
                k_SyntheticMarkers.Clear();
                loadedEnv.GetComponentsInChildren(k_SyntheticMarkers);
                foreach (var marker in k_SyntheticMarkers)
                {
                    marker.ApplyPropBlockTextureOnSyntheticMarker();
                }
            }

            var loadedPrefabStage = PrefabStageUtility.GetCurrentPrefabStage();
            if (loadedPrefabStage == null)
                return;

            k_SyntheticMarkers.Clear();
            loadedPrefabStage.prefabContentsRoot.GetComponentsInChildren(k_SyntheticMarkers);
            for (var i = 0; i < k_SyntheticMarkers.Count; i++)
            {
                if (k_SyntheticMarkers[i] == null)
                {
                    k_SyntheticMarkers.RemoveAt(i);
                    i--;
                    continue;
                }

                k_SyntheticMarkers[i].ApplyPropBlockTextureOnSyntheticMarker();
            }
        }

        static void OnUpdatedSyntheticImageMarkerSize(string markerID, Vector2 newSize)
        {
            var simulationEnvironmentRoot = SimulationSceneModule.instance.EnvironmentRoot;
            if (!simulationEnvironmentRoot)
                return;

            k_SyntheticMarkers.Clear();
            simulationEnvironmentRoot.GetComponentsInChildren(k_SyntheticMarkers);
            foreach (var syntheticMarker in k_SyntheticMarkers)
            {
                if (syntheticMarker.GetTraitData() == markerID)
                    syntheticMarker.UpdateMarkerSize(newSize);
            }
        }

        public void UpdateMarkerDataFromLibraries()
        {
            m_MarkerIDToLibrary.Clear();
            m_GUIContentIDToMarkerID.Clear();
            m_MarkerIDToGUIContentID.Clear();

            m_MarkerLibraries = Resources.FindObjectsOfTypeAll(typeof(MarsMarkerLibrary)) as MarsMarkerLibrary[];
            if (m_MarkerLibraries == null || m_MarkerLibraries.Length == 0)
                return;

            MarsMarkerLibrary activeLibrary = null;
            var marsSession = MARSSession.Instance;
            if (marsSession != null && marsSession.MarkerLibrary != null)
                activeLibrary = marsSession.MarkerLibrary;

            var activeFound = false;
            foreach (var markerLibrary in m_MarkerLibraries)
            {
                if (markerLibrary == null)
                    continue;

                var isActive = activeLibrary == markerLibrary;
                if (isActive)
                {
                    m_MarkerDefinitionsContent = new GUIContent[markerLibrary.Count + 1];
                    m_MarkerDefinitionsContent[0] = k_SelectFromActiveLibrary;
                    activeFound = true;
                }

                for (var i = 0; i < markerLibrary.Count; i++)
                {
                    var markerDefinition = markerLibrary[i];
                    m_MarkerIDToLibrary[markerDefinition.MarkerId] = markerLibrary;

                    if (!isActive)
                        continue;

                    m_MarkerDefinitionsContent[i + 1] = new GUIContent(markerDefinition.Label, markerDefinition.Texture,
                        markerDefinition.Texture == null ?
                            $"Marker Definition with Marker ID {markerDefinition.MarkerId}" :
                            $"Marker Definition with texture {AssetDatabase.GetAssetPath(markerDefinition.Texture)}");
                    m_GUIContentIDToMarkerID[i + 1] = markerDefinition.MarkerId;
                    m_MarkerIDToGUIContentID[markerDefinition.MarkerId] = i + 1;
                }
            }

            if (!activeFound)
            {
                m_MarkerDefinitionsContent = new GUIContent[1];
                m_MarkerDefinitionsContent[0] = k_SelectFromActiveLibrary;
            }
        }
    }
}
