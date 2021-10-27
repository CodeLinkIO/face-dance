using Unity.MARS;
using Unity.MARS.Actions;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace UnityEditor.MARS
{
    class VerticalPlaneObjectCreationData : ObjectCreationData
    {
        public override bool CreateGameObject(out GameObject createdObj, Transform parentTransform = null)
        {
            MARSSession.EnsureRuntimeState();

            createdObj = GenerateInitialGameObject(m_ObjectName, parentTransform);

            createdObj.AddComponent<Proxy>();
            createdObj.AddComponent<IsPlaneCondition>();
            createdObj.AddComponent<AlignmentCondition>().alignment = MarsPlaneAlignment.Vertical;

            createdObj.AddComponent<SetPoseAction>().AlignWithWorldUp = SetPoseAction.AlignMode.Z;
            createdObj.AddComponent<ShowChildrenOnTrackingAction>();

            createdObj.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));

            Undo.RegisterCreatedObjectUndo(createdObj, $"Create {createdObj.name}");
            Selection.activeGameObject = createdObj;

            var simObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            simObjectsManager?.DirtySimulatableScene();

            return true;
        }
    }
}
