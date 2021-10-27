using Unity.MARS.Settings;
using Unity.XRTools.Utils;
using UnityEngine;
using System;

#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
#endif

namespace Unity.MARS.Simulation
{
    /// <summary>
    /// Settings for simulation environments objects in a the simulation scene
    /// </summary>
    [ScriptableSettingsPath(MARSCore.SettingsFolder)]
    public class SimulationEnvironmentSettings : ScriptableSettings<SimulationEnvironmentSettings>
    {
        internal const string LayerOutOfRangeError = "Simulation Environment Layer {0} is out of the range, Can only use " +
            " layers {1} through {2}! Setting to default layer {3}.";

        internal const string LayerSetToReservedWarning = "Layer {0} is a reserved layer and " +
            "should be changed. Some functionality may not be available or you may have collisions with other systems.";

        const string k_LayerAssignedInfo = "Using layer {0} for simulation environment";

#pragma warning disable 649
        [SerializeField]
        [Tooltip("Layer used for object in the simulation environment")]
        int m_SimulationEnvironmentLayer;
#pragma warning restore 649

        /// <summary>
        /// The layer index value used for GameObjects in the simulation environment.
        /// This is used when setting `gameObject.layer` to that of the simulation environment.
        /// </summary>
        internal int SimulationEnvironmentLayerIndex => m_SimulationEnvironmentLayer;

#if UNITY_EDITOR
        void OnValidate()
        {
            if (m_SimulationEnvironmentLayer < SimulationConstants.FirstValidLayer || m_SimulationEnvironmentLayer > SimulationConstants.MaxLayerIndex)
            {
                var layer = FindEmptyLayer();
                if (layer >= SimulationConstants.FirstValidLayer && layer <= SimulationConstants.MaxLayerIndex)
                    m_SimulationEnvironmentLayer = layer;
                else
                    m_SimulationEnvironmentLayer = SimulationConstants.DefaultEnvironmentLayerIndex;

                if (LayerMask.LayerToName(m_SimulationEnvironmentLayer) != SimulationConstants.SimulationEnvironmentLayerName)
                    SetLayerName(m_SimulationEnvironmentLayer, SimulationConstants.SimulationEnvironmentLayerName);

                DebugUtils.Log(string.Format(k_LayerAssignedInfo, layer));
            }

            if (SimulationConstants.ReservedLayers.Contains(m_SimulationEnvironmentLayer))
            {
                Debug.LogWarningFormat(LayerSetToReservedWarning, m_SimulationEnvironmentLayer);
            }
        }

        static int FindEmptyLayer()
        {
            var count = new int[SimulationConstants.AllLayerCount];
            foreach (var go in FindObjectsOfType<GameObject>())
            {
                count[go.layer]++;
            }

            for (var i = SimulationConstants.MaxLayerIndex; i >= SimulationConstants.FirstValidLayer; i--)
            {
                if (count[i] == 0 && !SimulationConstants.ReservedLayers.Contains(i))
                    return i;
            }

            return 0;
        }

        static void SetLayerName(int layer, string name)
        {
            var asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
            if (asset == null || asset.Length == 0)
                return;

            var so = new SerializedObject(asset[0]);
            var layers = so.FindProperty("layers");
            if (layers == null)
                return;

            layers.GetArrayElementAtIndex(layer).stringValue = name;
            so.ApplyModifiedProperties();
            so.Update();
        }
#endif
    }
}
