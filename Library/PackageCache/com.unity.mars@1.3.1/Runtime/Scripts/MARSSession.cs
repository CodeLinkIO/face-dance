using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using Unity.MARS.MARSUtils;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

#if INCLUDE_AR_FOUNDATION
using UnityEngine.XR.ARFoundation;
#endif

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

#if INCLUDE_AR_FOUNDATION_4_OR_NEWER
using CameraFacingDirection = Unity.MARS.Data.CameraFacingDirection;
#endif

namespace Unity.MARS
{
    /// <summary>
    /// Represents the runtime behavior of MARS.  One of these must be in any scene with MARS content for it to function properly
    /// </summary>
    [HelpURL(DocumentationConstants.SessionDocs)]
    [AddComponentMenu("")]
    public class MARSSession : MonoBehaviour, IUsesFunctionalityInjection
    {
        class Subscriber : IUsesMarkerTracking, IUsesFaceTracking, IUsesCameraTexture
        {
            IProvidesMarkerTracking IFunctionalitySubscriber<IProvidesMarkerTracking>.provider { get; set; }

            IProvidesFaceTracking IFunctionalitySubscriber<IProvidesFaceTracking>.provider { get; set; }

            IProvidesCameraTexture IFunctionalitySubscriber<IProvidesCameraTexture>.provider { get; set; }
        }

        public const string NotEntitledMessage =
            "No MARS subscription found for the current user. Users must purchase a subscription from the online store.";
        public const string LicensingUrl = "https://www.unity.com/mars";
        public const string NotEntitledMessageWithUrl = NotEntitledMessage + " Please go to " + LicensingUrl;

        const string k_ObjectName = "MARS Session";
        const string k_CameraName = "Main Camera";
        const string k_CameraTag = "MainCamera";
        const string k_UserName = "MARS User";
        const string k_PlayModeErrorFormat = "{0} There are likely errors above due to late setup of functionality " +
            "islands.  You should ensure proper scene setup by by going to Create > MARS > Session";

        internal const string EntitlementsFailedMessage = "MARS features are disabled in Play mode. " + NotEntitledMessageWithUrl;
        internal const string TokenExpiredMessage =
            "MARS token issue: Please refresh your Unity Hub login by logging out and back in again";

        const float k_DefaultNearPlane = 0.03f;
        const float k_MaxNearPlane = 0.1f;

        static readonly Type[] k_CameraComponents = { typeof(Camera) };

#pragma warning disable 649
        /// <summary>
        /// Features that the scene requires
        /// </summary>
        [SerializeField]
        Capabilities m_Requirements;

        /// <summary>
        /// Optional functionality island for this scene
        /// </summary>
        [SerializeField]
        FunctionalityIsland m_Island;

        [SerializeField]
        MarsMarkerLibrary m_MarkerLibrary;
#pragma warning restore 649

        [HideInInspector]
        [SerializeField]
        MARSCamera m_CameraReference;

        [HideInInspector]
        [SerializeField]
        Transform m_UserReference;

        [SerializeField]
        [Tooltip("Sets the requested number of faces to track when face tracking is available. -1 for Platform Maximum.")]
        int m_RequestedMaximumFaceCount = -1;

        readonly Subscriber m_Subscriber = new Subscriber();

        internal MARSCamera cameraReference => m_CameraReference;

        /// <summary>
        /// Currently active MARS session singleton instance
        /// </summary>
        public static MARSSession Instance { get; private set; }
        internal static bool TestMode { get; set; }

        /// <summary>
        /// Active functionality island for the MARS session
        /// </summary>
        public FunctionalityIsland island => m_Island;
        /// <summary>
        /// Functionality requirements for the MARS session
        /// </summary>
        public Capabilities requirements => m_Requirements;

#if UNITY_EDITOR
        /// <summary>
        /// Active marker library for the MARS session
        /// </summary>
        public MarsMarkerLibrary MarkerLibrary => m_MarkerLibrary;
#endif

        /// <summary>
        /// The maximum number of tracked faces requested by this session
        /// </summary>
        public int RequestedMaximumFaceCount => m_RequestedMaximumFaceCount;

        IProvidesFunctionalityInjection IFunctionalitySubscriber<IProvidesFunctionalityInjection>.provider { get; set; }

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<MARSSession> k_Sessions = new List<MARSSession>();
        static readonly List<Camera> k_Cameras = new List<Camera>();
        static readonly List<GameObject> k_RootGameObjects = new List<GameObject>();

        void Awake()
        {
            k_Sessions.Clear();
            if (TestMode)
                GameObjectUtils.GetComponentsInActiveScene(k_Sessions);
            else
                GameObjectUtils.GetComponentsInAllScenes(k_Sessions);

            var sessionCount = k_Sessions.Count;
            Assert.AreEqual(sessionCount, 1, "More than one MARSSession active");
            if (sessionCount != 1)
                Debug.LogError("More than one MARSSession in the scene or a scene with an active MARSSession was loaded while an existing MARSSesion was active. MARS will not function properly");
            else
            {
                CheckCapabilities();
                Instance = this;
                var moduleLoaderCore = ModuleLoaderCore.instance;
                if (Application.isPlaying)
                {
                    moduleLoaderCore.ReloadModules();
                    MarsRuntimeUtils.TryGetActiveCamera = TryGetSessionCamera;
                }

                moduleLoaderCore.OnBehaviorAwake();
                this.InjectFunctionalitySingle(m_Subscriber);
                if (m_Subscriber.HasProvider<IProvidesMarkerTracking>())
                {
                    m_Subscriber.SetActiveMarkerLibrary(m_MarkerLibrary);
                    m_Subscriber.StartTrackingMarkers();
                }
            }
        }

        void OnEnable()
        {
#if UNITY_EDITOR
            if (Application.isPlaying && !EditorOnlyDelegates.IsEntitled(false))
                Debug.LogWarning(EntitlementsFailedMessage);
#endif
            ModuleLoaderCore.instance.OnBehaviorEnable();
        }

        IEnumerator Start()
        {
            ModuleLoaderCore.instance.OnBehaviorStart();

            yield return null;
            if (m_Subscriber.HasProvider<IProvidesCameraTexture>())
            {
                var requiredCameraFacing = m_Requirements.RequiredCameraFacing;
                var cameraFacing = m_Subscriber.GetCameraFacingDirection();
                while (cameraFacing != requiredCameraFacing)
                {
                    yield return null;
                    cameraFacing = m_Subscriber.GetCameraFacingDirection();
                }
            }

            if (m_Subscriber.HasProvider<IProvidesFaceTracking>())
            {
                var requested = m_RequestedMaximumFaceCount;
                var supportedMax = m_Subscriber.GetSupportedFaceCount();
                if (requested < 0 || requested > supportedMax)
                {
                    requested = supportedMax;
                }

                m_Subscriber.SetRequestedMaximumFaceCount(requested);
            }
        }

        void Update() { ModuleLoaderCore.instance.OnBehaviorUpdate(); }

        void OnDisable() { ModuleLoaderCore.instance.OnBehaviorDisable(); }

        // We don't need to set the instance pointer to null here, as destroying the object will make the instance null inherently
        void OnDestroy()
        {
            var moduleLoaderCore = ModuleLoaderCore.instance;
            moduleLoaderCore.OnBehaviorDestroy();

            if (m_Subscriber.HasProvider<IProvidesMarkerTracking>())
            {
                m_Subscriber.StopTrackingMarkers();
                m_Subscriber.SetActiveMarkerLibrary(null);
            }

            if (Application.isPlaying)
            {
                MarsRuntimeUtils.TryGetActiveCamera = null;
                moduleLoaderCore.UnloadModules();
            }
        }

        /// <summary>
        /// Ensures that a MARS Scene has all required components and configuration
        /// </summary>
        /// <param name="overrideUserRef">Override the creation of a new user prefab with an exiting one</param>
        public static void EnsureRuntimeState(Transform overrideUserRef = null)
        {
            // Make sure we have a MARS Session
            if (Instance == null)
                Instance = GameObjectUtils.ExhaustiveComponentSearch<MARSSession>(null);

            if (MARSSceneModule.instance.BlockEnsureSession)
                return;

            // Early out if nothing needs to change, otherwise we add an unnecessary undo group
            if (SessionConfigured(Instance))
                return;

            using (var undoBlock = new UndoBlock("Ensure MARS Runtime State"))
            {
                if (Instance == null)
                {
                    CreateSession(undoBlock);
                    DirtySimulatableSceneIfNeeded();
                }
                else
                {
                    undoBlock.RecordObject(Instance.gameObject);
                }

                if (!TestMode)
                    EnsureSessionConfigured(Instance, undoBlock, overrideUserRef);
            }
        }

        static MARSSession CreateSession(UndoBlock undoBlock, bool marsBehaviorsInScene = true)
        {
            const string sessionNotPresentMessage = "MARS Session not present in the scene - creating one now.";
            if (marsBehaviorsInScene)
                LogRuntimeIssue(sessionNotPresentMessage);
            else if (!TestMode)
                Debug.Log(sessionNotPresentMessage);

            GameObject sessionObject = null;
            Camera cameraRef = null;
            k_Cameras.Clear();
            GameObjectUtils.GetComponentsInActiveScene(k_Cameras);
            if (k_Cameras.Count > 0)
            {
                cameraRef = k_Cameras[0];
                foreach (var camera in k_Cameras)
                {
                    if (camera.CompareTag(k_CameraTag))
                    {
                        cameraRef = camera;
                        break;
                    }
                }
            }

            if (cameraRef != null && cameraRef.transform.parent != null)
            {
                sessionObject = cameraRef.transform.parent.gameObject;
                var addToParentMessage = "Adding MARS Session component to immediate parent of main camera.";
#if INCLUDE_AR_FOUNDATION
                var arSessionOrigin = cameraRef.GetComponentInParent<ARSessionOrigin>();
                if (arSessionOrigin != null)
                {
                    sessionObject = arSessionOrigin.gameObject;
                    addToParentMessage = "Adding MARS Session component to AR Session Origin game object.";
                }
#endif

                Debug.Log(addToParentMessage);
                undoBlock.RecordObject(sessionObject);
#if UNITY_EDITOR
                EditorGUIUtility.PingObject(sessionObject);
#endif
            }

            if (sessionObject == null)
            {
                sessionObject = new GameObject(k_ObjectName);
                sessionObject.transform.SetAsFirstSibling();
                undoBlock.RegisterCreatedObject(sessionObject);
            }

            var sessionTrans = sessionObject.transform;
            if (cameraRef == null)
                cameraRef = CreateCamera(sessionTrans, undoBlock);

            var cameraObj = cameraRef.gameObject;
            var marsCameraRef = cameraObj.GetComponent<MARSCamera>();
            if (!marsCameraRef)
            {
                Debug.Log("Adding MARS Camera component to main camera.");

                // TODO: configure near plane
                marsCameraRef = undoBlock.AddComponent<MARSCamera>(cameraObj);
            }

            var session = undoBlock.AddComponent<MARSSession>(sessionObject);
            Instance = session;
            session.m_CameraReference = marsCameraRef;

            return session;
        }

        static Camera CreateCamera(Transform sessionTransform, UndoBlock undoBlock)
        {
            Debug.LogWarning("Scene does not have a main camera.  Adding one to the scene.");
            var newCamera = new GameObject(k_CameraName, k_CameraComponents) { tag = k_CameraTag };
            var cameraRef = newCamera.GetComponent<Camera>();
            cameraRef.nearClipPlane = k_DefaultNearPlane * sessionTransform.localScale.x;
            newCamera.transform.parent = sessionTransform;
            undoBlock.RegisterCreatedObject(newCamera);
            return cameraRef;
        }

        static bool SessionConfigured(MARSSession session)
        {
            if (session == null)
                return false;

            var sessionObject = session.gameObject;
            var sessionTransform = session.transform;
            var sessionCamera = session.m_CameraReference;
            var cameraTransform = sessionCamera.transform;
            return sessionCamera != null && sessionCamera.gameObject.activeInHierarchy && cameraTransform != sessionTransform &&
                cameraTransform.IsChildOf(sessionTransform) && session.m_UserReference != null && sessionObject.activeInHierarchy;
        }

        static void EnsureSessionConfigured(MARSSession session, UndoBlock undoBlock, Transform overrideUserRef = null)
        {
            var sessionObject = session.gameObject;
            var sessionTransform = session.transform;
            var changed = false;

            // Make sure we have a properly configured MARS Camera
            if (!TestMode && session.m_CameraReference == null)
            {
                var marsCameraRef = GameObjectUtils.ExhaustiveComponentSearch<MARSCamera>(sessionObject);

                // If we can't find a MARS camera, get the main camera and create one on that
                if (marsCameraRef == null)
                {
                    LogRuntimeIssue("MARSCamera not present in the scene.  Adding one to the main camera.");

                    var createdNewCamera = false;
                    var cameraRef = GameObjectUtils.ExhaustiveTaggedComponentSearch<Camera>(sessionObject, k_CameraTag);
                    if (cameraRef == null)
                    {
                        cameraRef = CreateCamera(sessionTransform, undoBlock);
                        createdNewCamera = true;
                    }

                    marsCameraRef = undoBlock.AddComponent<MARSCamera>(cameraRef.gameObject);

                    if (!createdNewCamera)
                    {
                        var nearPlane = cameraRef.nearClipPlane;
                        var cameraParent = cameraRef.transform.parent;
                        if (cameraParent == null)
                            cameraParent = sessionTransform;

                        var worldScale = cameraParent.localScale.x;
                        var scaledMaxNearPlane = k_MaxNearPlane * worldScale;
                        if (nearPlane > scaledMaxNearPlane)
                        {
                            LogRuntimeIssue("Camera near clip plane is greater than the recommended distance. " +
                                $"Setting near plane from {nearPlane} to {scaledMaxNearPlane}.");

                            undoBlock.RecordObject(cameraRef);
                            cameraRef.nearClipPlane = scaledMaxNearPlane;
                        }
                    }
                }

                session.m_CameraReference = marsCameraRef;
                changed = true;
            }

            const string correctBrokenSessionMessage = "If you have not customized the MARSSession game object, just delete " +
                "the object and go to Create > MARS > Session.";

            var cameraTrans = session.m_CameraReference.transform;
            if (!TestMode && cameraTrans.GetComponentInParent<MARSSession>() == null)
            {
                const string cameraParentRequirementMessage = "MARSCamera must have a MARSSession object in its list of parents.";
                var canReparent = true;
#if INCLUDE_AR_FOUNDATION
                if (cameraTrans.GetComponentInParent<ARSessionOrigin>() != null)
                {
                    canReparent = false;
                    Debug.LogError($"{cameraParentRequirementMessage} Please make sure the MARSSession component " +
                        $"is on the same game object as the ARSessionOrigin. {correctBrokenSessionMessage}");
                }
#endif
                if (canReparent)
                {
                    LogRuntimeIssue($"{cameraParentRequirementMessage} Re-parenting.");
                    var cameraParent = cameraTrans.parent;
                    if (cameraParent)
                    {
                        sessionTransform.position = cameraParent.position;
                        sessionTransform.rotation = cameraParent.rotation;
                        sessionTransform.localScale = cameraParent.localScale;
                    }

                    undoBlock.SetTransformParent(cameraTrans, sessionTransform);
                    changed = true;
                }
            }

            // Look for the user object, if it's not in the scene, make a new one
            var userRef = session.m_UserReference;
            if (!TestMode && userRef == null)
            {
                userRef = session.m_CameraReference.transform.Find(k_UserName);
                if (userRef == null)
                {
                    if (overrideUserRef == null)
                        userRef = GameObjectUtils.Instantiate(MARSRuntimePrefabs.instance.UserPrefab).transform;
                    else
                        userRef = overrideUserRef;

                    userRef.name = k_UserName;
                    userRef.parent = session.m_CameraReference.transform;
                    userRef.localPosition = Vector3.zero;
                    userRef.localRotation = Quaternion.identity;
                    userRef.localScale = Vector3.one;
                    undoBlock.RegisterCreatedObject(userRef.gameObject);
                }

                session.m_UserReference = userRef;
                changed = true;
            }

            // One more bizarre scenario to catch - the MARS Session and Camera being *one* object.
            // We can't just delete the MARS Session since the user might have other scripts there, so we just throw up a warning telling them to fix things manually
            if (!TestMode && session.m_CameraReference.transform == sessionTransform)
            {
                Debug.LogError("The MARS Session should be a parent of the MARSCamera, *NOT* the same object!  " +
                    $"Please correct this in your scene! {correctBrokenSessionMessage}");
            }

            if (sessionObject.activeInHierarchy == false)
            {
                LogRuntimeIssue("There is a MARS Session object in your scene that is *not* active.  Running your scene with an inactive MARS Session will cause problems.");
                sessionObject.SetActive(true);
                changed = true;
            }

            var cameraObject = session.cameraReference.gameObject;
            if (cameraObject.activeInHierarchy == false)
            {
                LogRuntimeIssue("There is a MARS Camera GameObject in your scene that is *not* active.  " +
                    "Re-enabling here, as running your scene with an inactive MARS Camera would cause problems.");

                cameraObject.SetActive(true);
                changed = true;
            }

            if (changed)
                DirtySimulatableSceneIfNeeded();
        }

        /// <summary>
        /// Ensures that the active scene has a MARS Session
        /// </summary>
        /// <returns>Thew newly created MARSSession, or null if a session previously exists</returns>
        public static MARSSession EnsureSessionInActiveScene()
        {
            var session = GameObjectUtils.GetComponentInActiveScene<MARSSession>();
            if (SessionConfigured(session))
                return null;

            using (var undoBlock = new UndoBlock("Ensure Session in Active Scene", TestMode))
            {
                if (!session)
                {
                    var marsBehaviorsInScene = MarsRuntimeUtils.HasMarsBehaviors(SceneManager.GetActiveScene());
                    session = CreateSession(undoBlock, marsBehaviorsInScene);

                    var userRef = GameObjectUtils.Instantiate(MARSRuntimePrefabs.instance.UserPrefab).transform;
                    userRef.name = k_UserName;
                    userRef.parent = session.m_CameraReference.transform;
                    userRef.localPosition = Vector3.zero;
                    userRef.localRotation = Quaternion.identity;
                    userRef.localScale = Vector3.one;
                    undoBlock.RegisterCreatedObject(userRef.gameObject);
                    session.m_UserReference = userRef;

                    DirtySimulatableSceneIfNeeded();
                    return session;
                }

                EnsureSessionConfigured(session, undoBlock);
            }

            return null;
        }

        static void LogRuntimeIssue(object message)
        {
            if (!TestMode)
            {
                if (Application.isPlaying)
                    Debug.LogError(string.Format(k_PlayModeErrorFormat, message));
                else
                    Debug.LogWarning(message);
            }
        }

        static void DirtySimulatableSceneIfNeeded()
        {
#if UNITY_EDITOR
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                return;

            EditorOnlyDelegates.DirtySimulatableScene?.Invoke();
#endif
        }

#if UNITY_EDITOR
        void OnValidate()
        {
            if (m_MarkerLibrary == null)
                return;

            foreach (var condition in FindObjectsOfType<MarkerCondition>())
            {
                condition.ValidateMarkerGuid(this);
            }
        }
#endif

        /// <summary>
        /// Check the capabilities required in the MARS session
        /// </summary>
        /// <returns><c>True</c> if changed in the scene</returns>
        public bool CheckCapabilities()
        {
            if (m_Requirements == null)
                m_Requirements = new Capabilities();

            var gatheredTraitRequirements = new HashSet<TraitRequirement>();

            // Calculate scene requirements and complexity. In play mode check all loaded scenes, otherwise only check the active scene.
            var modified = false;
            var faceRequirements = false;
            if (Application.isPlaying)
            {
                var loadedSceneCount = SceneManager.sceneCount;
                for (var i = 0; i < loadedSceneCount; i++)
                {
                    GatherSceneRequirements(SceneManager.GetSceneAt(i), gatheredTraitRequirements, ref faceRequirements);
                }
            }
            else
            {
                GatherSceneRequirements(SceneManager.GetActiveScene(), gatheredTraitRequirements, ref faceRequirements);
            }

            var traitRequirements = m_Requirements.TraitRequirements;
            if (!gatheredTraitRequirements.SetEquals(traitRequirements))
            {
                modified = true;
                traitRequirements.Clear();
                // this is where all requirements for the scene actually get added to the Capabilities
                traitRequirements.UnionWith(gatheredTraitRequirements);
            }

            if (!faceRequirements && Application.isPlaying)
            {
                // Check any non-MonoBehaviour objects that might be included as part of the MARS scene at runtime
                var sceneModule = ModuleLoaderCore.instance.GetModule<MARSSceneModule>();
                if (sceneModule != null)
                {
                    foreach (var sceneObject in sceneModule.CustomRuntimeSceneObjects)
                    {
                        if (sceneObject is IUsesFaceTracking || sceneObject is IUsesFacialExpressions)
                        {
                            faceRequirements = true;
                            break;
                        }
                    }
                }
            }

            var requiredCameraFacing = faceRequirements ? CameraFacingDirection.User : CameraFacingDirection.World;
            if (m_Requirements.RequiredCameraFacing != requiredCameraFacing)
            {
                modified = true;
                m_Requirements.RequiredCameraFacing = requiredCameraFacing;
            }

#if UNITY_EDITOR
            if (modified && !Application.isPlaying)
                EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
#endif

            return modified;
        }

        static void GatherSceneRequirements(Scene scene, HashSet<TraitRequirement> traitRequirements, ref bool faceRequirements)
        {
            k_RootGameObjects.Clear();
            scene.GetRootGameObjects(k_RootGameObjects);
            foreach (var rootGameObject in k_RootGameObjects)
            {
                var requiringComponents = rootGameObject.GetComponentsInChildren<IRequiresTraits>(true);

                var hostedConditionRequirements = rootGameObject.GetComponentsInChildren<IComponentHost<ICondition>>(true)
                    .SelectMany(host => host.HostedComponents).Cast<IRequiresTraits>();

                foreach (var requirer in requiringComponents.Union(hostedConditionRequirements))
                {
                    // this can happen if a requirer is destroyed
                    if (requirer == null)
                        continue;

                    foreach (var requirement in requirer.GetRequiredTraits())
                    {
                        // this can happen if a tag condition's trait name isn't filled in
                        var traitName = requirement.TraitName;
                        if (!string.IsNullOrEmpty(traitName))
                        {
                            traitRequirements.Add(requirement);
                            faceRequirements |= traitName == TraitNames.Face;
                        }
                    }
                }
            }

            if (!faceRequirements)
            {
                foreach (var rootGameObject in k_RootGameObjects)
                {
                    if (rootGameObject.GetComponentInChildren<IUsesFaceTracking>() != null ||
                        rootGameObject.GetComponentInChildren<IUsesFacialExpressions>() != null)
                    {
                        faceRequirements = true;
                        break;
                    }

#if INCLUDE_AR_FOUNDATION
                    if (rootGameObject.GetComponentInChildren<ARFaceManager>() != null)
                    {
                        faceRequirements = true;
                        break;
                    }
#endif
                }
            }
        }

        /// <summary>
        /// Get the scale of the session object, or return 1 if it doesn't exist
        /// Used only for authoring systems that need World Scale when no Camera Offset Provider exists
        /// </summary>
        /// <returns></returns>
        internal static float GetWorldScale()
        {
            if (Instance == null)
                return 1f;

            return Instance.transform.localScale.x;
        }

        internal Camera TryGetSessionCamera()
        {
            return m_CameraReference != null ? m_CameraReference.MarsCamera : null;
        }

        /// <summary>
        /// Search all loaded scenes for MARSSession objects and set the first one to the Instance property, if any exist
        /// </summary>
        public static void FindExistingInstance()
        {
            var sceneCount = SceneManager.sceneCount;
            for (var i = 0; i < sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                if(!scene.isLoaded)
                    continue;

                var session = GameObjectUtils.GetComponentInScene<MARSSession>(scene);
                if (session != null)
                {
                    Instance = session;
                    break;
                }
            }
        }
    }
}
