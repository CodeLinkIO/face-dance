using Unity.MARS;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor.MARS.Simulation;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UnityEditor.MARS
{
    /// <summary>
    /// ObjectCreationData for a Synthetic Body preset
    /// </summary>
    public class SyntheticBodyObjectCreationData : ObjectCreationData
    {
        const string k_SimulatedBodiesParentName = "Simulated Bodies";
        const string k_CreatedBodyObjName = "Synthetic Body Root";

#pragma warning disable 649
        [SerializeField]
        GameObject m_SyntheticBodyMesh;

        [SerializeField]
        TimelineAsset m_InitialAnimationTimelineAsset;
#pragma warning restore 649

        /// <summary>
        /// Create a Synthetic Body preset object
        /// </summary>
        /// <param name="createdObj">The created object</param>
        /// <param name="parentTransform">A parent transform to use for object creation (can be null)</param>
        /// <returns>True if the object was created successfully</returns>
        public override bool CreateGameObject(out GameObject createdObj, Transform parentTransform)
        {
            MARSSession.EnsureRuntimeState();

            createdObj = null;

            var activeView =  SimulationView.ActiveSimulationView as SimulationView;
            if (activeView != null)
                activeView.EnvironmentSceneActive = true;

            Tools.current = Tool.Move;

            var syntheticBodyParentTransform = GetOrGenerateUniqueParent(k_SimulatedBodiesParentName);
            if (syntheticBodyParentTransform == null)
            {
                Debug.LogWarning("Unable to create synthetic body parent");
                return false;
            }

            createdObj = CreateSyntheticBody();
            var createdBodyTransform = createdObj.transform;
            createdBodyTransform.parent = syntheticBodyParentTransform;

            createdBodyTransform.localPosition = Vector3.zero;
            createdBodyTransform.localRotation = Quaternion.identity;
            createdBodyTransform.localScale = Vector3.one;

            createdObj.name = GameObjectUtility.GetUniqueNameForSibling(syntheticBodyParentTransform, k_CreatedBodyObjName);

            Undo.RegisterCreatedObjectUndo(createdObj, $"Create {createdObj.name}");
            Selection.activeGameObject = createdObj;

            var simObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            if (simObjectsManager != null)
                simObjectsManager.DirtySimulatableScene();

            return true;
        }

        GameObject CreateSyntheticBody()
        {
            // We have to create a root for each synthetic body, else is not possible to move it while animated
            var bodyRoot = new GameObject();
            bodyRoot.transform.position = Vector3.zero;

            var createdBody = Instantiate(m_SyntheticBodyMesh, Vector3.zero, Quaternion.identity, bodyRoot.transform);
            createdBody.name = "Synthetic Body";
            createdBody.SetActive(false);

            var bodyPlayableDirector = createdBody.AddComponent<PlayableDirector>();
            bodyPlayableDirector.playableAsset = m_InitialAnimationTimelineAsset;
            bodyPlayableDirector.extrapolationMode = DirectorWrapMode.Loop;

            foreach (var playableAssetOutput in bodyPlayableDirector.playableAsset.outputs)
            {
                bodyPlayableDirector.SetGenericBinding(
                    playableAssetOutput.sourceObject, createdBody.GetComponent<Animator>());
            }

            createdBody.AddComponent<SimulatedObject>();
            createdBody.AddComponent<SynthesizedManualPose>();
            createdBody.AddComponent<SynthesizedBody>();

            createdBody.AddComponent<IgnoreForEnvironmentPersistence>();
            createdBody.AddComponent<SimulatedPlayable>();

            createdBody.SetActive(true);

            // Without delay, the non-instant framing gets lost in the object creation hiccup.
            EditorApplication.delayCall += () =>
            {
                SimulationView.ActiveSimulationView.Frame(BoundsUtils.GetBounds(createdBody.transform), false);
                bodyPlayableDirector.Play();
            };

            bodyRoot.SetLayerRecursively(SimulationConstants.SimulatedEnvironmentLayerIndex);
            return bodyRoot;
        }
    }
}
