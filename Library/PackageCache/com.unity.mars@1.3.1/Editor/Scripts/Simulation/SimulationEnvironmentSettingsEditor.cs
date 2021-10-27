using System.Linq;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace UnityEditor.MARS.Simulation.Rendering
{
    [CustomEditor(typeof(SimulationEnvironmentSettings))]
    class SimulationEnvironmentSettingsEditor : Editor
    {
        SimulationEnvironmentSettingsDrawer m_SimulationEnvironmentSettingsDrawer;

        void OnEnable()
        {
            m_SimulationEnvironmentSettingsDrawer = new SimulationEnvironmentSettingsDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            m_SimulationEnvironmentSettingsDrawer.InspectorGUI(serializedObject);
        }
    }

    class SimulationEnvironmentSettingsDrawer
    {
        const string k_TagManagerAssetPath = "ProjectSettings/TagManager.asset";
        const string k_RenameLayerMessage = "Renaming layer {0} to '{1}'";
        const string k_UnnamedName = "(Unnamed)";
        const string k_ReservedName = "{0} (Reserved)";
        const string k_NamedLayerName = "{0} - {1}";

        SerializedProperty m_SimulationEnvironmentLayerProperty;
        GUIContent[] m_LayersContent;

        internal SimulationEnvironmentSettingsDrawer(SerializedObject serializedObject)
        {
            m_SimulationEnvironmentLayerProperty =
                serializedObject.FindProperty("m_SimulationEnvironmentLayer");

            LayerContentsUpdate();
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            var layerIndex = m_SimulationEnvironmentLayerProperty.intValue;
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (new EditorGUI.DisabledScope(Application.isPlaying))
            {
                using (var change = new EditorGUI.ChangeCheckScope())
                {
                    var activeIndexOffset = layerIndex - SimulationConstants.FirstValidLayer;
                    var selectedIndex = activeIndexOffset;

                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.PrefixLabel(new GUIContent(m_SimulationEnvironmentLayerProperty.displayName,
                            m_SimulationEnvironmentLayerProperty.tooltip));

                        selectedIndex = EditorGUILayout.Popup(selectedIndex, m_LayersContent);
                    }

                    if (change.changed && selectedIndex != activeIndexOffset)
                    {
                        layerIndex = selectedIndex + SimulationConstants.FirstValidLayer;
                        m_SimulationEnvironmentLayerProperty.intValue = layerIndex;
                        serializedObject.ApplyModifiedProperties();

                        if (TryNameLayer(layerIndex))
                            LayerContentsUpdate();

                        if (ModuleLoaderCore.instance.ModulesAreLoaded)
                            ModuleLoaderCore.instance.ReloadModules();
                    }
                }
            }

            DrawLayerHelpBox(layerIndex);
        }

        void LayerContentsUpdate()
        {
            m_LayersContent = new GUIContent[SimulationConstants.ValidLayerCount];
            for (var i = 0; i < m_LayersContent.Length; i++)
            {
                m_LayersContent[i] = GetLayerIndexGUIContent(i + SimulationConstants.FirstValidLayer);
            }
        }

        static bool TryNameLayer(int layer)
        {
            const string targetLayerName = SimulationConstants.SimulationEnvironmentLayerName;
            var setName = string.IsNullOrEmpty(LayerMask.LayerToName(layer));

            if (SimulationConstants.ReservedLayers.Contains(layer))
                setName = false;

            var asset = AssetDatabase.LoadAllAssetsAtPath(k_TagManagerAssetPath);
            if (asset == null || asset.Length < 1)
                return false;

            var tagManager = new SerializedObject(asset[0]);
            var layersProp = tagManager.FindProperty("layers");

            var oldLayer = LayerMask.NameToLayer(targetLayerName);
            if (oldLayer > 0)
                layersProp.GetArrayElementAtIndex(oldLayer).stringValue = null;

            if (setName)
            {
                var layerArrayProp = layersProp.GetArrayElementAtIndex(layer);
                layerArrayProp.stringValue = targetLayerName;
                Debug.LogFormat(k_RenameLayerMessage, layer, targetLayerName);
            }

            tagManager.ApplyModifiedProperties();

            return true;
        }

        static void DrawLayerHelpBox(int layer)
        {
            if (layer < SimulationConstants.FirstValidLayer || layer > SimulationConstants.MaxLayerIndex)
            {
                EditorGUILayout.HelpBox(string.Format(SimulationEnvironmentSettings.LayerOutOfRangeError, layer,
                    SimulationConstants.FirstValidLayer, SimulationConstants.MaxLayerIndex,
                    SimulationConstants.DefaultEnvironmentLayerIndex), MessageType.Error);
            }

            if (SimulationConstants.ReservedLayers.Contains(layer))
            {
                EditorGUILayout.HelpBox(string.Format(SimulationEnvironmentSettings.LayerSetToReservedWarning, layer),
                    MessageType.Warning);
            }
        }

        static GUIContent GetLayerIndexGUIContent(int index)
        {
            var layerName = LayerMask.LayerToName(index);
            if (string.IsNullOrEmpty(layerName))
                layerName = k_UnnamedName;

            if (SimulationConstants.ReservedLayers.Contains(index))
                layerName = string.Format(k_ReservedName, layerName);

            var name = string.Format(k_NamedLayerName, index.ToString(), layerName);
            return new GUIContent(name);
        }
    }
}
