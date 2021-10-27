using Unity.MARS;
using Unity.MARS.Behaviors;
using Unity.MARS.Visualizers;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace UnityEditor.MARS
{
    class PointCloudVisualizerObjectCreationData : ObjectCreationData
    {
        #pragma warning disable 649
        [SerializeField]
        Material m_PointCloudMaterial;
        #pragma warning restore 649

        public override bool CreateGameObject(out GameObject createdObj, Transform parentTransform = null)
        {
            MARSSession.EnsureRuntimeState();

            createdObj = GenerateInitialGameObject(m_ObjectName, parentTransform);

            createdObj.AddComponent<MARSPointCloudVisualizer>();
            //MeshFilter and MeshRenderer get added by default by (MARSPointCloudVisualizer)
            var createdVisualizerMeshRenderer = createdObj.GetComponent<MeshRenderer>();
            createdVisualizerMeshRenderer.sharedMaterial = m_PointCloudMaterial;
            createdVisualizerMeshRenderer.renderingLayerMask = uint.MaxValue; // All layers

            Undo.RegisterCreatedObjectUndo(createdObj, $"Create {createdObj.name}");
            Selection.activeGameObject = createdObj;

            var simObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            simObjectsManager?.DirtySimulatableScene();

            return true;
        }
    }
}
