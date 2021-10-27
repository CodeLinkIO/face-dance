using Unity.MARS;
using Unity.MARS.Actions;
using Unity.MARS.Conditions;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace UnityEditor.MARS
{
    class ElevatedSurfaceObjectObjectCreationData : ObjectCreationData
    {
        public override bool CreateGameObject(out GameObject createdObj, Transform parentTransform = null)
        {
            MARSSession.EnsureRuntimeState();

            createdObj = GenerateInitialGameObject(m_ObjectName, parentTransform);
            createdObj.AddComponent<Proxy>();
            createdObj.AddComponent<ShowChildrenOnTrackingAction>();
            createdObj.AddComponent<SetPoseAction>();
            createdObj.AddComponent<HeightAboveFloorCondition>();
            createdObj.AddComponent<IsPlaneCondition>();

            Undo.RegisterCreatedObjectUndo(createdObj, $"Create {createdObj.name}");
            Selection.activeGameObject = createdObj;

            var simObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            simObjectsManager?.DirtySimulatableScene();

            return true;
        }
    }
}
