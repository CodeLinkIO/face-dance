using Unity.MARS;
using Unity.MARS.Actions;
using Unity.MARS.Conditions;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace UnityEditor.MARS
{
    /// <summary>
    /// ObjectCreationData for a Body preset
    /// </summary>
    public class BodyObjectCreationData : ObjectCreationData
    {
        /// <summary>
        /// Create a Body preset object
        /// </summary>
        /// <param name="createdObj">The created object</param>
        /// <param name="parentTransform">A parent transform to use for object creation (can be null)</param>
        /// <returns>True if the object was created successfully</returns>
        public override bool CreateGameObject(out GameObject createdObj, Transform parentTransform)
        {
            MARSSession.EnsureRuntimeState();

            createdObj = GenerateInitialGameObject(m_ObjectName, parentTransform);

            createdObj.AddComponent<Proxy>();
            createdObj.AddComponent<IsBodyCondition>();
            var bodyAction = createdObj.AddComponent<MatchBodyPoseAction>();

            var defaultBodyRig = Instantiate(
                MarsBodySettings.instance.DefaultLandmarksBodyRig.gameObject, createdObj.transform).GetComponent<Animator>();
            defaultBodyRig.gameObject.name = "Default Body Rig";
            defaultBodyRig.transform.localScale = Vector3.one * MarsWorldScaleModule.GetWorldScale();

            var bodyActionSerializedObj = new SerializedObject(bodyAction);
            var animatorProperty = bodyActionSerializedObj.FindProperty("m_Animator");
            animatorProperty.objectReferenceValue = defaultBodyRig;
            bodyActionSerializedObj.ApplyModifiedProperties();

            Undo.RegisterCreatedObjectUndo(createdObj, $"Create {createdObj.name}");
            Selection.activeGameObject = createdObj;

            var simObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            if (simObjectsManager != null)
                simObjectsManager.DirtySimulatableScene();

            SceneView.RepaintAll();

            return true;
        }
    }
}
