using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Unity.MARS.Actions;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.Experimental.SceneManagement;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Data
{
    class BodyTrackingModule : IModuleAssetCallbacks
    {
        const string k_SavePosePanelTitle = "Save Body Pose Data";
        const string k_SavePosePanelDefaultName = "Body Pose";
        const string k_SavePosePanelExtension = "asset";

        const string k_CreatePoseToolLabel = "Body Pose";
        const string k_SaveSelectedPoseButton = "Save";
        const string k_ResetPoseButton = "Reset";
        const string k_TPoseButton = "T Pose";
        const string k_LoadExternalPose = "Load";

        const float k_WindowWidth = 200;
        const float k_WindowHeight = 63;
        const float k_WindowOffsetFromEdges = 10;
        const float k_ToolbarHeight = 20;

        const string k_TabIndexMemberName = "m_TabIndex";
        const int k_MuscleTabIndex = 1;

        static readonly Type k_AvatarEditorType = Type.GetType("UnityEditor.AvatarEditor, UnityEditor");
        static readonly MethodInfo k_SwitchToEditModeMethod = k_AvatarEditorType.GetMethod("SwitchToEditMode", BindingFlags.Instance | BindingFlags.NonPublic);
        static readonly FieldInfo k_TabIndexField = k_AvatarEditorType.GetField(k_TabIndexMemberName, BindingFlags.Instance | BindingFlags.NonPublic);
        static readonly Type k_ObjectSelectorType = Type.GetType("UnityEditor.ObjectSelector, UnityEditor");
        static readonly PropertyInfo k_FirstInspectedEditorProperty = typeof(Editor).GetProperty("firstInspectedEditor", BindingFlags.Instance | BindingFlags.NonPublic);
        static readonly PropertyInfo k_AvatarSubEditorProperty = k_AvatarEditorType.GetProperty("editor", BindingFlags.NonPublic | BindingFlags.Instance);

        static bool s_OpenAvatarInMuscleSettingsTab;
        static Animator s_AnimatorInAvatarEditorMode;
        static Editor s_LastOpenedAvatarEditor;
        static bool s_EditorIsInAvatarMuscleEditorMode;
        static Animator s_LastFoundAnimator;

        bool m_DrewPoseUtilLastLayout;
        BodyPoseData m_ExternalBodyData;
        EditorSlowTask m_FindAvatarEditor;
        double m_PollingInterval = 1.5d;
        int m_ObjectSelectorControlId;

        // These are indices in the muscle data array that somehow are related either to finger, eyes or to toes movement,
        // which are not tracked by iOS.
        static readonly int[] k_NonRelevantMuscleIndices =
        {
            15, 16, 17, 18, // eyes
            19, 20, // Jaw
            26, 27, 28, 34, 35, 36, // toes
            44, 45, 53, 54, // Wrist 44, 45 (left), 53, 54 (right)
            55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, // fingers
            75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94  // fingers
        };

        public void LoadModule()
        {
            SceneView.duringSceneGui += OnSceneGUI;
            EditorApplication.update += Update;

            m_FindAvatarEditor = new EditorSlowTask(() =>
            {
                CacheAvatarEditor();
                CacheEditorIsInAvatarMuscleEditorMode();
            }, m_PollingInterval);
        }

        public void UnloadModule()
        {
            SceneView.duringSceneGui -= OnSceneGUI;
            EditorApplication.update -= Update;

            m_FindAvatarEditor = null;
        }

        void Update()
        {
            m_FindAvatarEditor?.Update();
        }

        internal static void OpenAvatarEditor(Avatar avatarToModify, bool openMuscleSettingsTab)
        {
            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                return;

            s_OpenAvatarInMuscleSettingsTab = openMuscleSettingsTab;

            // If we leave the inspector locked, the avatar editor won't display
            ActiveEditorTracker.sharedTracker.isLocked = false;

            // Loading the avatar inspector takes some number of frames, so single delay isn't enough.
            // Hence we check every frame until it's ready, and then unsubscribe.
            Selection.activeObject = avatarToModify;
            EditorApplication.update += OpenAvatarEditorWhenReady;
        }

        static void CacheAvatarEditor()
        {
            var editors = Resources.FindObjectsOfTypeAll(k_AvatarEditorType);

            if (editors.Length == 0)
            {
                s_LastOpenedAvatarEditor = null;
                return;
            }

            foreach (var editor in editors)
            {
                if (editor == null)
                    continue;

                // This property is always false on an invalid (not on screen) editor, so we continue until finding a valid one.
                // This fixes an error where AvatarEditor will sometimes not be displayed because it is targeting an invalid Editor.
                var firstInspectedEditor = (bool) k_FirstInspectedEditorProperty.GetValue(editor);
                if (!firstInspectedEditor)
                    continue;

                s_LastOpenedAvatarEditor = (Editor) editor;
                return;
            }
        }

        static void OpenAvatarEditorWhenReady()
        {
            CacheAvatarEditor();
            if (!s_LastOpenedAvatarEditor)
                return;

            // Case where user has changes on the scene and hits save and also has environment changes.
            // We need to wait and trigger the environment saving to correctly continue loading the avatar
            // editor, else it doesnt work correctly.
            var environmentManagerInstance = MARSEnvironmentManager.instance;
            if (environmentManagerInstance.HasSaveableEnvironmentPrefabInstanceOverrides())
            {
                environmentManagerInstance.TrySaveEnvironmentModificationsDialog(false);
                return;
            }

            // Invoking the tab setting method after the edit mode method doesn't work.
            if (s_OpenAvatarInMuscleSettingsTab)
            {
                k_AvatarEditorType.InvokeMember(k_TabIndexMemberName,
                    BindingFlags.Instance | BindingFlags.SetField | BindingFlags.NonPublic,
                    Type.DefaultBinder, s_LastOpenedAvatarEditor, new System.Object[] {k_MuscleTabIndex});
            }

            k_SwitchToEditModeMethod.Invoke(s_LastOpenedAvatarEditor, null);

            // Focus on any skinned mesh renderer since focusing on the root fills the scene view with the rig
            var bodySkinnedRenderers = Resources.FindObjectsOfTypeAll<SkinnedMeshRenderer>();
            if (bodySkinnedRenderers.Length > 0)
                SceneView.lastActiveSceneView.Frame(BoundsUtils.GetBounds(bodySkinnedRenderers[0].transform));

            var selection = Selection.activeGameObject;
            var selectedAnimator = selection.GetComponent<Animator>();
            if (selectedAnimator != null)
                s_AnimatorInAvatarEditorMode = selectedAnimator;
            else
                Debug.LogError("Selection in Avatar Editor must have an Animator.");

            EditorApplication.update -= OpenAvatarEditorWhenReady;
        }

        void OnSceneGUI(SceneView sceneView)
        {
            if (!ShouldDrawBodyPoseUtilityWindow(sceneView))
                return;

            s_LastFoundAnimator = FindHumanAnimatorObj();

            if (s_LastFoundAnimator == null)
                return;

            // We don't want to show the window if the avatar isn't visible.
            // Specifically, we avoid changing the pose of the landmarks rig (Default Body Rig)
            if (!HasDisabledSkinnedMeshRenderer())
                return;

            Handles.BeginGUI();

            var winPos = new Rect(sceneView.position.width - k_WindowWidth - k_WindowOffsetFromEdges,
                sceneView.position.height - k_WindowHeight - k_WindowOffsetFromEdges - k_ToolbarHeight,
                k_WindowWidth, k_WindowHeight);

            using (new GUILayout.AreaScope(winPos, string.Empty, "Box"))
            {
                GUILayout.Label( k_CreatePoseToolLabel);

                using (new EditorGUI.DisabledScope(!s_LastFoundAnimator.isHuman))
                {
                    using (new GUILayout.HorizontalScope())
                    {
                        m_ExternalBodyData = EditorGUIUtils.ObjectFieldWithControlIdCheck(
                            m_ExternalBodyData, ref m_ObjectSelectorControlId, GUILayout.Width(135),
                            GUILayout.Height(17));

                        using (new EditorGUI.DisabledScope(m_ExternalBodyData == null))
                        {
                            if (GUILayout.Button(k_LoadExternalPose, GUILayout.Width(40), GUILayout.Height(17)))
                                LoadBodyPose(s_LastFoundAnimator, m_ExternalBodyData);
                        }
                    }

                    using (new GUILayout.HorizontalScope())
                    {
                        if (GUILayout.Button(k_ResetPoseButton, GUILayout.Width(62)))
                            LoadBodyPose(s_LastFoundAnimator);

                        if (GUILayout.Button(k_TPoseButton, GUILayout.Width(62)))
                            LoadBodyPose(s_LastFoundAnimator, MarsBodySettings.instance.TPoseBodyData, true);

                        if (GUILayout.Button(k_SaveSelectedPoseButton, GUILayout.Width(65)))
                            GenerateSerializedDataFromAvatar(s_LastFoundAnimator);
                    }
                }
            }

            EditorGUIUtils.EatMouseInput(winPos, "BodyPoseUtility");

            Handles.EndGUI();
        }

        static void StopTimelineIfNecessary()
        {
            if (s_LastFoundAnimator == null)
                return;

            var director = s_LastFoundAnimator.GetComponent<PlayableDirector>();
            if (director == null)
                return;

            director.Stop();
        }

        static bool HasDisabledSkinnedMeshRenderer()
        {
            var renderer = s_LastFoundAnimator.GetComponentInChildren<SkinnedMeshRenderer>();
            if (renderer == null || !renderer.enabled)
                return false;

            return true;
        }

        bool ShouldDrawBodyPoseUtilityWindow(SceneView sceneView)
        {
            // Return cached value to not change layout during repaint
            if (Event.current.type != EventType.Layout)
                return m_DrewPoseUtilLastLayout;

            m_DrewPoseUtilLastLayout = false;

            if (sceneView != SceneView.lastActiveSceneView)
                return false;

            if (s_LastOpenedAvatarEditor != null)
            {
                var tabIndex = (int) k_TabIndexField.GetValue(s_LastOpenedAvatarEditor);
                if (tabIndex != k_MuscleTabIndex)
                    return false;
            }

            var foundAnimatorObj = FindHumanAnimatorObj();
            if (foundAnimatorObj == null)
                return false;

            m_DrewPoseUtilLastLayout = true;
            return true;
        }

        // Finds a human animator for the selectedTransform. If we are in AvatarEditorMode it always returns the
        // initial human animator when opening the AvatarEditor; otherwise it returns the animator for the
        // selection or any children of the selected gameobject
        Animator FindHumanAnimatorObj()
        {
            // If we are in the muscle tab of the Avatar Editor we always display the Body Pose Utility window.
            if (s_EditorIsInAvatarMuscleEditorMode)
            {
                if (s_AnimatorInAvatarEditorMode == null)
                {
                    // No need to check all scenes, since the Avatar Configuration workflow sets up its single scene.
                    foreach (var root in SceneManager.GetActiveScene().GetRootGameObjects())
                    {
                        var animator = root.GetComponent<Animator>();
                        if (animator && animator.isHuman)
                        {
                            s_AnimatorInAvatarEditorMode = animator;
                            SceneView.RepaintAll();
                        }
                    }
                }

                return s_AnimatorInAvatarEditorMode;
            }

            var selectedTransform = Selection.activeTransform;

            // Case when we click object field and the object picker appears (and we lose focus of the selected body).
            // In this case we return the last avatar and keep the util window open.
            var getObjectPickerControlID = EditorGUIUtility.GetObjectPickerControlID();
            if (s_LastFoundAnimator != null && EditorWindow.focusedWindow != null
                && EditorWindow.focusedWindow.GetType() == k_ObjectSelectorType && getObjectPickerControlID == m_ObjectSelectorControlId)
            {
                return s_LastFoundAnimator;
            }

            if (selectedTransform == null)
                return null;

            var selectedAnimator = selectedTransform.GetComponentInParent<Animator>();
            if (selectedAnimator != null && selectedAnimator.isHuman)
                return selectedAnimator;

            return null;
        }

        static void CacheEditorIsInAvatarMuscleEditorMode()
        {
            s_EditorIsInAvatarMuscleEditorMode = false;

            if (s_LastOpenedAvatarEditor == null)
                return;

            var editor = k_AvatarSubEditorProperty.GetValue(s_LastOpenedAvatarEditor);

            if (editor == null)
                return;

            s_EditorIsInAvatarMuscleEditorMode = true;
        }

        /// <summary>
        /// Puts objToApplyPoseTo into the selected pose, or resets the pose if bodyData is null.
        /// </summary>
        /// <param name="objToApplyPoseTo">The humanoid animator to pose</param>
        /// <param name="bodyData">(Optional) The pose to use. If null, animator will take on the default 'reset' pose</param>
        /// <param name="overrideRelevantMuscles">If true, all muscles will be posed, including those marked non-relevant (eg. lacking platform tracking support).</param>
        internal static void LoadBodyPose(Animator objToApplyPoseTo, BodyPoseData bodyData = null, bool overrideRelevantMuscles = false)
        {
            StopTimelineIfNecessary();

            var animTransform = objToApplyPoseTo.transform;
            // if we don't set the transform to 0,0,0 then loading pose will offset the body from the transform root
            var originalPos = animTransform.localPosition;
            var originalRot = animTransform.localRotation;
            animTransform.localRotation = Quaternion.identity;
            animTransform.localPosition = Vector3.zero;

            var avatar = objToApplyPoseTo.avatar;
            if (!avatar.isHuman)
            {
                Debug.LogError("LoadBodyPose can only be used on humanoid avatars.");
                return;
            }

            var humanPoseHandler = new HumanPoseHandler(avatar, animTransform);
            var humanPose = new HumanPose();
            humanPoseHandler.GetHumanPose(ref humanPose);

            if (bodyData == null)
            {
                for (var i = 0; i < humanPose.muscles.Length; i++)
                    humanPose.muscles[i] = 0;
            }
            else
            {
                humanPose.bodyRotation = Quaternion.identity;

                for (var i = 0; i < bodyData.Muscles.Length; i++)
                {
                    if (overrideRelevantMuscles || bodyData.MuscleRelevantData[i]) // Only set muscles with relevant data
                        humanPose.muscles[i] = bodyData.Muscles[i];
                }
            }

            humanPoseHandler.SetHumanPose(ref humanPose);

            animTransform.localRotation = originalRot;
            animTransform.localPosition = originalPos;
        }

        internal static void GenerateSerializedDataFromAvatar(Animator objToGetDataFrom)
        {
            var pathToSaveData = EditorUtility.SaveFilePanelInProject(k_SavePosePanelTitle, k_SavePosePanelDefaultName,
                k_SavePosePanelExtension, string.Empty);

            if (pathToSaveData == string.Empty)
                return;

            var poseName = Path.GetFileNameWithoutExtension(pathToSaveData);

            var originalBodyPoseData = GenerateBodyPoseDataFromAvatar(objToGetDataFrom, poseName);

            // We have to load the pose on a unique body matching pose rig (Found in MarsBodySettings) so we can use
            // any avatar for matching poses. This is because sometimes avatar transforms are not aligned correctly to Y-UP
            var poseMatchingBodyRig = UnityObject.Instantiate(MarsBodySettings.instance.DefaultPoseMatchingBodyRig.gameObject).GetComponent<Animator>();
            LoadBodyPose(poseMatchingBodyRig, originalBodyPoseData);

            var poseDataToSave = GenerateBodyPoseDataFromAvatar(poseMatchingBodyRig, poseName);

            AssetDatabase.CreateAsset(poseDataToSave, pathToSaveData);
            AssetDatabase.SaveAssets();

            AssetDatabase.Refresh();

            var createdAsset = AssetDatabase.LoadAssetAtPath<BodyPoseData>(pathToSaveData);
            Selection.activeObject = createdAsset;

            UnityObject.DestroyImmediate(poseMatchingBodyRig.gameObject);
        }

        static BodyPoseData GenerateBodyPoseDataFromAvatar(Animator objToGetDataFrom, string poseName)
        {
            var anim = objToGetDataFrom;
            var humanPoseHandler = new HumanPoseHandler(anim.avatar, objToGetDataFrom.transform);

            var humanPose = new HumanPose
            {
                bodyPosition = new Vector3(0, 0, 0),
                bodyRotation = Quaternion.identity
            };

            humanPoseHandler.GetHumanPose(ref humanPose);

            var relevantMuscles = new List<bool>();
            for (var i = 0; i < humanPose.muscles.Length; i++)
            {
                relevantMuscles.Add(true);
            }

            for (var i = 0; i < k_NonRelevantMuscleIndices.Length; i++)
            {
                relevantMuscles[k_NonRelevantMuscleIndices[i]] = false;
            }

            var bodyPoseData = ScriptableObject.CreateInstance<BodyPoseData>();

            var bonesOrientations = BodyExpressionAction.GenerateBoneOrientations(anim);

            var relevantBonesForPoseMatch = new bool[bonesOrientations.Length];
            for (var i = 0; i < relevantBonesForPoseMatch.Length; i++)
            {
                relevantBonesForPoseMatch[i] = true;
            }

            bodyPoseData.Init(poseName, PruneMuscleValues(humanPose.muscles), relevantMuscles.ToArray(),
                bonesOrientations, relevantBonesForPoseMatch);

            return bodyPoseData;
        }

        static float[] PruneMuscleValues(float[] muscles, float min = -1, float max = 1)
        {
            var prunedValues = new float[muscles.Length];
            for (var i = 0; i < muscles.Length; i++)
            {
                prunedValues[i] = Mathf.Clamp(muscles[i], min, max);
            }

            return prunedValues;
        }

        void IModuleAssetCallbacks.OnWillCreateAsset(string path) { }

        string[] IModuleAssetCallbacks.OnWillSaveAssets(string[] paths)
        {
            // Deleting bodies from environments while they are loaded causes console errors.
            // Tear down the environment ahead of time to suppress them
            var stage = PrefabStageUtility.GetCurrentPrefabStage();
            if (stage == null)
                return paths;

#if UNITY_2020_1_OR_NEWER
            var assetPath = stage.assetPath;
#else
            var assetPath = stage.prefabAssetPath;
#endif

            if (!paths.Contains(assetPath))
                return paths;

            var environmentManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
            if (environmentManager.SavingEnvironment)
                return paths;

            environmentManager.TearDownEnvironmentNotCancelable();

            // Wait for prefab instances to update
            EditorApplication.delayCall += () =>
            {
                environmentManager.RefreshEnvironment();
            };

            return paths;
        }

        AssetDeleteResult IModuleAssetCallbacks.OnWillDeleteAsset(string path, RemoveAssetOptions options)
        {
            return AssetDeleteResult.DidNotDelete;
        }
    }
}
