using Unity.MARS;
using Unity.MARS.Behaviors;
using Unity.MARS.Visualizers;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace UnityEditor.MARS
{
    class PlanesVisualizerObjectCreationData : ObjectCreationData
    {
        private const string k_PlanePrefabPropertyName = "m_PlanePrefab";

        #pragma warning disable 649
        [SerializeField]
        GameObject m_PlanePrefab;
        #pragma warning restore 649

        public override bool CreateGameObject(out GameObject createdObj, Transform parentTransform = null)
        {
            MARSSession.EnsureRuntimeState();

            createdObj = GenerateInitialGameObject(m_ObjectName, parentTransform);

            var planeVisualizer = createdObj.AddComponent<MARSPlaneVisualizer>();
            var planeVisualizerSerializedObj = new SerializedObject(planeVisualizer);
            var planePrefabProperty = planeVisualizerSerializedObj.FindProperty(k_PlanePrefabPropertyName);
            planePrefabProperty.objectReferenceValue = m_PlanePrefab;
            planeVisualizerSerializedObj.ApplyModifiedPropertiesWithoutUndo();

            Undo.RegisterCreatedObjectUndo(createdObj, $"Create {createdObj.name}");
            Selection.activeGameObject = createdObj;

            var simObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            simObjectsManager?.DirtySimulatableScene();

            return true;
        }
    }
}
