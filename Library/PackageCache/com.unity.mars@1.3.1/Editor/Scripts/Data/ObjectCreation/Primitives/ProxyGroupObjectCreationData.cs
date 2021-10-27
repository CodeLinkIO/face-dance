using Unity.MARS;
using Unity.MARS.Actions;
using Unity.MARS.Conditions;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace UnityEditor.MARS
{
    class ProxyGroupObjectCreationData : ObjectCreationData
    {
        public override bool CreateGameObject(out GameObject createdObj, Transform parentTransform = null)
        {
            MARSSession.EnsureRuntimeState();

            createdObj = GenerateInitialGameObject(m_ObjectName, parentTransform);

            createdObj.AddComponent<ProxyGroup>();

            var child1 = new GameObject("Child 1");
            child1.AddComponent<Proxy>();
            child1.AddComponent<ShowChildrenOnTrackingAction>();
            child1.AddComponent<HasPoseCondition>();
            child1.AddComponent<SetPoseAction>();
            child1.transform.parent = createdObj.transform;

            var child2 = new GameObject("Child 2");
            child2.AddComponent<Proxy>();
            child2.AddComponent<HasPoseCondition>();
            child2.AddComponent<ShowChildrenOnTrackingAction>();
            child2.AddComponent<SetPoseAction>();
            child2.transform.parent = createdObj.transform;

            Undo.RegisterCreatedObjectUndo(createdObj, $"Create {createdObj.name}");
            Selection.activeGameObject = createdObj;

            var simObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            simObjectsManager?.DirtySimulatableScene();

            return true;
        }
    }
}
