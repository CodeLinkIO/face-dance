using Unity.MARS;
using Unity.MARS.Actions;
using Unity.MARS.Conditions;
using Unity.MARS.Landmarks;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Authoring;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace UnityEditor.MARS
{
    class FaceMaskObjectCreationData : ObjectCreationData
    {
        const string k_FaceMeshPropertyName = "m_FaceMesh";
        const string k_DepthMaskGameObjName = "Depth Mask";

        #pragma warning disable 649
        [SerializeField]
        Mesh m_DepthMaskMesh;

        [SerializeField]
        Material m_DepthMaskMaterial;
        #pragma warning restore 649

        public override bool CreateGameObject(out GameObject createdObj, Transform parentTransform = null)
        {
            MARSSession.EnsureRuntimeState();

            createdObj = GenerateInitialGameObject(m_ObjectName, parentTransform);

            createdObj.AddComponent<Proxy>();
            createdObj.AddComponent<ShowChildrenOnTrackingAction>();

            createdObj.AddComponent<IsFaceCondition>();
            var landmarksAction = createdObj.AddComponent<FaceLandmarksAction>();

            var allLandmarkDefinitions = landmarksAction.AvailableLandmarkDefinitions;
            foreach (var def in allLandmarkDefinitions)
            {
                landmarksAction.CreateLandmarkAsChild(def, def.outputTypes[0]);
            }

            var entityVisualsModule = ModuleLoaderCore.instance.GetModule<EntityVisualsModule>();
            var marsEntity = landmarksAction.GetComponentInParent<MARSEntity>();
            if (entityVisualsModule != null && marsEntity != null)
            {
                entityVisualsModule.InvalidateVisual(marsEntity);
            }

            var depthMaskGO = new GameObject(k_DepthMaskGameObjName);
            depthMaskGO.AddComponent<MeshFilter>().sharedMesh = m_DepthMaskMesh;
            depthMaskGO.transform.localScale = Vector3.one * MarsWorldScaleModule.GetWorldScale();

            var depthFaceMaskRenderer = depthMaskGO.AddComponent<MeshRenderer>();
            depthFaceMaskRenderer.sharedMaterial = m_DepthMaskMaterial;
            depthFaceMaskRenderer.renderingLayerMask = uint.MaxValue; //All layers

            depthMaskGO.transform.parent = createdObj.transform;

            var faceAction = createdObj.AddComponent<FaceAction>();
            var serializedFaceActionObj = new SerializedObject(faceAction);
            var faceMeshProperty = serializedFaceActionObj.FindProperty(k_FaceMeshPropertyName);
            faceMeshProperty.objectReferenceValue = depthMaskGO;
            serializedFaceActionObj.ApplyModifiedPropertiesWithoutUndo();

            createdObj.AddComponent<FaceExpressionAction>();

            Undo.RegisterCreatedObjectUndo(createdObj, $"Create {createdObj.name}");
            Selection.activeGameObject = createdObj;

            var simObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            simObjectsManager?.DirtySimulatableScene();

            return true;
        }
    }
}
