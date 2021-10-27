using Unity.MARS.Behaviors;
using Unity.MARS.Visualizers;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEditor;

namespace Unity.MARS
{
    [CustomEditor(typeof(MARSLightEstimationVisualizer))]
    class MarsLightEstimationVisualizerInspector : Editor
    {
        MARSLightEstimationVisualizer m_InspectedTarget;

        const string k_IncorrectLightTypeNextToVisualizerMsg =
            "This visualizer component only works with directional lights.";

        void OnEnable() { m_InspectedTarget = (MARSLightEstimationVisualizer) target; }

        public override void OnInspectorGUI()
        {
            var inspectedLightComponent = m_InspectedTarget.GetComponent<Light>();
            if (inspectedLightComponent != null && inspectedLightComponent.type != LightType.Directional)
            {
                EditorGUILayout.HelpBox(k_IncorrectLightTypeNextToVisualizerMsg, MessageType.Warning);

                if (GUILayout.Button("Change to Directional Light"))
                {
                    using (var undoBlock = new UndoBlock("Change light type"))
                    {
                        undoBlock.RecordObject(inspectedLightComponent);
                        inspectedLightComponent.type = LightType.Directional;
                    }
                }
            }

            //Show default UI from Monobehavior
            base.OnInspectorGUI();
        }
    }
}
