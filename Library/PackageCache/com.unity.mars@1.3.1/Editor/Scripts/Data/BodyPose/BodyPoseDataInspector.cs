using System;
using Unity.MARS.Actions;
using UnityEditor;
using UnityEngine;

namespace Unity.MARS.Data
{
    [CustomEditor(typeof(BodyPoseData))]
    class BodyPoseDataInspector : Editor
    {
        const string k_RevertButtonLabel = "Revert";
        const string k_ApplyButtonLabel = "Apply";

        const string k_ChangesTitle = "Muscle data has been modified";
        const string k_ChangesMsg = "Would you like to save the changes?";
        const string k_ChangesPopupOk = "Ok";
        const string k_ChangesPopupCancel = "Cancel";

        const float k_MinMuscleVal = -1;
        const float k_MaxMuscleVal = 1;

        const string k_BodyPoseMusclesGuid = "m_MusclesData";
        const string k_BodyPoseRelevantMusclesGuid = "m_MuscleRelevantData";
        const string k_BodyPoseBoneOrientationsGuid = "m_BoneOrientations";
        const string k_RelevantBonesDataGuid = "m_RelevantBonesData";

        const string k_TrackCenterLineId = "m_TrackCenterLine";
        const string k_TrackRightArmId = "m_TrackRightArm";
        const string k_TrackLeftArmId = "m_TrackLeftArm";
        const string k_TrackRightLegId = "m_TrackRightLeg";
        const string k_TrackLeftLegId = "m_TrackLeftLeg";

        const int k_PreviewPoseWidth = 300;
        const int k_PreviewPoseHeight = 300;
        const int k_MuscleLabelWidth = 170;
        const int k_MuscleFloatSliderWidth = 95;
        const int k_SpaceBetweenControls = 10;
        const int k_RelevantBonesAreaHeight = 90;
        const int k_MuscleSettingsAreaHeight = 300;

        static readonly GUIContent k_RelevantBonesFoldoutContent = new GUIContent("Body areas included in pose",
            "Activate / deactivate body areas to selectively ignore body parts in poses" +
            " (eg. When tracking a seated pose, we don't care how the arms are positioned, so we only activate the legs)");

        static readonly GUIContent k_CenterlineContent = new GUIContent("Centerline",
            "Takes into account body centerline: head, neck, upper chest, chest, spine and hips");
        static readonly GUIContent k_RightArmContent = new GUIContent("Right arm",
            "Takes into account Right arm: right shoulder, right upper arm and right lower arm");
        static readonly GUIContent k_LeftArmContent = new GUIContent("Left arm",
            "Takes into account Left arm: left shoulder, left upper arm and left lower arm");
        static readonly GUIContent k_RightLegContent = new GUIContent("Right leg",
            "Takes into account Right leg: right upper leg and right lower leg");
        static readonly GUIContent k_LeftLegContent = new GUIContent("Left leg",
            "Takes into account Left leg: left upper leg and left lower leg");

        static bool s_SaveDialogDisplayed;

        Editor m_BodyPosePreviewEditor;
        Animator m_PreviewBodyPose;

        Vector2 m_MuscleDataScrollPos;

        bool m_DisplayRelevantBones;
        Rect m_RelevantBonesAreaRect = Rect.zero;
        Rect m_MuscleSettingsAreaRect = Rect.zero;

        BodyPoseData m_BodyPoseDataTargetToTweak;
        SerializedObject m_SerializedObjToTweak;
        SerializedProperty m_MuscleDataPropToTweak;
        SerializedProperty m_RelevantMusclesPropToTweak;
        SerializedProperty m_BonesOrientationsPropToTweak;
        SerializedProperty m_RelevantBonesPropToTweak;

        SerializedProperty m_TrackCenterLinePropToTweak;
        SerializedProperty m_TrackRightArmPropToTweak;
        SerializedProperty m_TrackLeftArmPropToTweak;
        SerializedProperty m_TrackRightLegPropToTweak;
        SerializedProperty m_TrackLeftLegPropToTweak;

        SerializedProperty m_OriginalMuscleDataProp;
        SerializedProperty m_OriginalRelevantMusclesProp;
        SerializedProperty m_OriginalBonesOrientations;
        SerializedProperty m_OriginalRelevantBonesDataProp;

        SerializedProperty m_OrigTrackCenterLineProp;
        SerializedProperty m_OrigTrackRightArmProp;
        SerializedProperty m_OrigTrackLeftArmProp;
        SerializedProperty m_OrigTrackRightLegProp;
        SerializedProperty m_OrigTrackLeftLegProp;

        void OnEnable()
        {
            s_SaveDialogDisplayed = false;

            Undo.undoRedoPerformed += OnUndoRedoPerformed;

            CreateInitialCopyOfSerializedObject();

            // Obj to tweak properties
            m_MuscleDataPropToTweak = m_SerializedObjToTweak.FindProperty(k_BodyPoseMusclesGuid);
            m_RelevantMusclesPropToTweak = m_SerializedObjToTweak.FindProperty(k_BodyPoseRelevantMusclesGuid);
            m_BonesOrientationsPropToTweak = m_SerializedObjToTweak.FindProperty(k_BodyPoseBoneOrientationsGuid);
            m_RelevantBonesPropToTweak = m_SerializedObjToTweak.FindProperty(k_RelevantBonesDataGuid);

            m_TrackCenterLinePropToTweak = m_SerializedObjToTweak.FindProperty(k_TrackCenterLineId);
            m_TrackRightArmPropToTweak = m_SerializedObjToTweak.FindProperty(k_TrackRightArmId);
            m_TrackLeftArmPropToTweak  = m_SerializedObjToTweak.FindProperty(k_TrackLeftArmId);
            m_TrackRightLegPropToTweak = m_SerializedObjToTweak.FindProperty(k_TrackRightLegId);
            m_TrackLeftLegPropToTweak = m_SerializedObjToTweak.FindProperty(k_TrackLeftLegId);

            // Original obj properties
            m_OriginalMuscleDataProp = serializedObject.FindProperty(k_BodyPoseMusclesGuid);
            m_OriginalRelevantMusclesProp = serializedObject.FindProperty(k_BodyPoseRelevantMusclesGuid);
            m_OriginalBonesOrientations = serializedObject.FindProperty(k_BodyPoseBoneOrientationsGuid);
            m_OriginalRelevantBonesDataProp = serializedObject.FindProperty(k_RelevantBonesDataGuid);

            m_OrigTrackCenterLineProp = serializedObject.FindProperty(k_TrackCenterLineId);
            m_OrigTrackRightArmProp = serializedObject.FindProperty(k_TrackRightArmId);
            m_OrigTrackLeftArmProp = serializedObject.FindProperty(k_TrackLeftArmId);
            m_OrigTrackRightLegProp = serializedObject.FindProperty(k_TrackRightLegId);
            m_OrigTrackLeftLegProp  = serializedObject.FindProperty(k_TrackLeftLegId);

            m_PreviewBodyPose = MarsBodySettings.instance.DefaultPreviewBody;

            UpdateBodyPoseDataForPreviewAvatar();
        }

        void CreateInitialCopyOfSerializedObject()
        {
            var targetObj = (BodyPoseData) target;
            m_BodyPoseDataTargetToTweak = CreateInstance<BodyPoseData>();
            m_BodyPoseDataTargetToTweak.Init(string.Empty, (float[]) targetObj.Muscles.Clone(),
                (bool[]) targetObj.MuscleRelevantData.Clone(), (Vector3[]) targetObj.BonesOrientations.Clone(),
                (bool[]) targetObj.RelevantBoneData.Clone(),targetObj.TrackCenterLine, targetObj.TrackRightArm,
                targetObj.TrackLeftArm, targetObj.TrackRightLeg, targetObj.TrackLeftLeg);

            m_SerializedObjToTweak = new SerializedObject(m_BodyPoseDataTargetToTweak);
        }

        void OnDisable()
        {
            if (DataChanged() && !s_SaveDialogDisplayed)
            {
                if (EditorUtility.DisplayDialog(k_ChangesTitle, k_ChangesMsg, k_ChangesPopupOk, k_ChangesPopupCancel))
                    ApplyChanges();

                s_SaveDialogDisplayed = true;
            }

            Undo.undoRedoPerformed -= OnUndoRedoPerformed;

            BodyTrackingModule.LoadBodyPose(m_PreviewBodyPose, MarsBodySettings.instance.TPoseBodyData);
        }

        bool DataChanged()
        {
            for (var i = 0; i < m_MuscleDataPropToTweak.arraySize; i++)
            {
                var muscleVal = m_MuscleDataPropToTweak.GetArrayElementAtIndex(i).floatValue;
                var originalMuscleVal = m_OriginalMuscleDataProp.GetArrayElementAtIndex(i).floatValue;

                if (!Mathf.Approximately(muscleVal, originalMuscleVal))
                    return true;
            }

            for (var i = 0; i < m_RelevantBonesPropToTweak.arraySize; i++)
            {
                var relevantBonesValI = m_RelevantBonesPropToTweak.GetArrayElementAtIndex(i).boolValue;
                var originalRelevantBonesValI = m_OriginalRelevantBonesDataProp.GetArrayElementAtIndex(i).boolValue;

                if (relevantBonesValI != originalRelevantBonesValI)
                    return true;
            }

            return false;
        }

        public override void OnInspectorGUI()
        {
            m_SerializedObjToTweak.Update();

            PreviewBodyPoseGUI();

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                DrawRelevantBonesGUI();

                if (Event.current.type == EventType.Repaint)
                {
                    var prevRect = GUILayoutUtility.GetLastRect();
                    m_MuscleSettingsAreaRect = new Rect(prevRect.x,
                        prevRect.y + prevRect.height + k_SpaceBetweenControls,
                        prevRect.width, k_MuscleSettingsAreaHeight);
                }

                GUI.Box(m_MuscleSettingsAreaRect, string.Empty);
                GUILayout.Space(k_SpaceBetweenControls);

                using (var scrollView = new EditorGUILayout.ScrollViewScope(m_MuscleDataScrollPos,
                    GUILayout.Width(m_MuscleSettingsAreaRect.width), GUILayout.Height(k_MuscleSettingsAreaHeight)))
                {
                    m_MuscleDataScrollPos = scrollView.scrollPosition;

                    for (var i = 0; i < m_MuscleDataPropToTweak.arraySize; i++)
                    {
                        //                    using (var check = new EditorGUI.ChangeCheckScope())
                        //                    {
                        var musclePropertyIndex = m_MuscleDataPropToTweak.GetArrayElementAtIndex(i);
                        var relevantPropertyIndex = m_RelevantMusclesPropToTweak.GetArrayElementAtIndex(i);

                        if (relevantPropertyIndex.boolValue)
                            DrawMuscleDataGUI(musclePropertyIndex, i);
                        //                    }
                    }

                    if (check.changed)
                    {
                        m_SerializedObjToTweak.ApplyModifiedProperties();

                        UpdateBodyPoseDataForPreviewAvatar();
                        RepaintBodyPosePreviewWindow();
                    }
                }
            }

            using (new GUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();
                if (GUILayout.Button(k_RevertButtonLabel))
                    RevertChanges();

                if (GUILayout.Button(k_ApplyButtonLabel))
                    ApplyChanges();
            }
        }

        void DrawMuscleDataGUI(SerializedProperty musclePropIndex, int index)
        {
            using (new GUILayout.HorizontalScope())
            {
                GUILayout.Label(HumanTrait.MuscleName[index], GUILayout.Width(k_MuscleLabelWidth));

                musclePropIndex.floatValue = GUILayout.HorizontalSlider(musclePropIndex.floatValue,
                    k_MinMuscleVal, k_MaxMuscleVal);

                var floatValue = EditorGUILayout.FloatField(musclePropIndex.floatValue, GUILayout.Width(k_MuscleFloatSliderWidth));
                musclePropIndex.floatValue = Mathf.Clamp(floatValue, k_MinMuscleVal, k_MaxMuscleVal);
            }
        }

        void DrawRelevantBonesGUI()
        {
            m_DisplayRelevantBones = EditorGUILayout.Foldout(m_DisplayRelevantBones, k_RelevantBonesFoldoutContent, true);
            if (Event.current.type == EventType.Repaint)
            {
                var prevRect = GUILayoutUtility.GetLastRect();
                m_RelevantBonesAreaRect = new Rect(prevRect.x, prevRect.y + prevRect.height,
                    prevRect.width, k_RelevantBonesAreaHeight);
            }

            if (m_DisplayRelevantBones)
            {
                GUILayout.Space(k_RelevantBonesAreaHeight);
                using (new GUILayout.AreaScope(m_RelevantBonesAreaRect, String.Empty, GUI.skin.box))
                {
                    // Centerline
                    m_TrackCenterLinePropToTweak.boolValue = GUILayout.Toggle(m_TrackCenterLinePropToTweak.boolValue, k_CenterlineContent);
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.Head).boolValue = m_TrackCenterLinePropToTweak.boolValue;
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.Neck).boolValue = m_TrackCenterLinePropToTweak.boolValue;
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.UpperChest).boolValue = m_TrackCenterLinePropToTweak.boolValue;
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.Chest).boolValue = m_TrackCenterLinePropToTweak.boolValue;
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.Spine).boolValue = m_TrackCenterLinePropToTweak.boolValue;
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.Hips).boolValue = m_TrackCenterLinePropToTweak.boolValue;

                    // Right arm
                    m_TrackRightArmPropToTweak.boolValue = GUILayout.Toggle(m_TrackRightArmPropToTweak.boolValue, k_RightArmContent);
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.RightShoulder).boolValue = m_TrackRightArmPropToTweak.boolValue;
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.RightUpperArm).boolValue = m_TrackRightArmPropToTweak.boolValue;
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.RightLowerArm).boolValue = m_TrackRightArmPropToTweak.boolValue;

                    // Left Arm
                    m_TrackLeftArmPropToTweak.boolValue = GUILayout.Toggle(m_TrackLeftArmPropToTweak.boolValue, k_LeftArmContent);
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.LeftShoulder).boolValue = m_TrackLeftArmPropToTweak.boolValue;
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.LeftUpperArm).boolValue = m_TrackLeftArmPropToTweak.boolValue;
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.LeftLowerArm).boolValue = m_TrackLeftArmPropToTweak.boolValue;

                    // Right Leg
                    m_TrackRightLegPropToTweak.boolValue = GUILayout.Toggle(m_TrackRightLegPropToTweak.boolValue, k_RightLegContent);
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.RightUpperLeg).boolValue = m_TrackRightLegPropToTweak.boolValue;
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.RightLowerLeg).boolValue = m_TrackRightLegPropToTweak.boolValue;

                    // Left Leg
                    m_TrackLeftLegPropToTweak.boolValue = GUILayout.Toggle(m_TrackLeftLegPropToTweak.boolValue, k_LeftLegContent);
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.LeftUpperLeg).boolValue = m_TrackLeftLegPropToTweak.boolValue;
                    m_RelevantBonesPropToTweak.GetArrayElementAtIndex((int) BodyData.LeftLowerLeg).boolValue = m_TrackLeftLegPropToTweak.boolValue;
                }
            }
        }

        void ApplyChanges()
        {
            CopyBodyPoseDataValues(m_MuscleDataPropToTweak, m_OriginalMuscleDataProp,
                m_RelevantMusclesPropToTweak, m_OriginalRelevantMusclesProp,
                m_BonesOrientationsPropToTweak, m_OriginalBonesOrientations,
                m_RelevantBonesPropToTweak, m_OriginalRelevantBonesDataProp,

                 m_TrackCenterLinePropToTweak, m_OrigTrackCenterLineProp,
                 m_TrackRightArmPropToTweak, m_OrigTrackRightArmProp,
                 m_TrackLeftArmPropToTweak, m_OrigTrackLeftArmProp,
                 m_TrackRightLegPropToTweak, m_OrigTrackRightLegProp,
                 m_TrackLeftLegPropToTweak, m_OrigTrackLeftLegProp,
                serializedObject);
        }

        void RevertChanges()
        {
            CopyBodyPoseDataValues(m_OriginalMuscleDataProp, m_MuscleDataPropToTweak,
                m_OriginalRelevantMusclesProp, m_RelevantMusclesPropToTweak,
                m_OriginalBonesOrientations, m_BonesOrientationsPropToTweak,
                m_OriginalRelevantBonesDataProp, m_RelevantBonesPropToTweak,

                m_OrigTrackCenterLineProp, m_TrackCenterLinePropToTweak,
                m_OrigTrackRightArmProp, m_TrackRightArmPropToTweak,
                m_OrigTrackLeftArmProp, m_TrackLeftArmPropToTweak,
                m_OrigTrackRightLegProp, m_TrackRightLegPropToTweak,
                m_OrigTrackLeftLegProp, m_TrackLeftLegPropToTweak,
                m_SerializedObjToTweak);

            UpdateBodyPoseDataForPreviewAvatar();
            RepaintBodyPosePreviewWindow();
        }

        void CopyBodyPoseDataValues(SerializedProperty srcMuscle, SerializedProperty destMuscle,
            SerializedProperty srcRelevant, SerializedProperty destRelevant,
            SerializedProperty srcBoneOrientations, SerializedProperty destBoneOrientations,
            SerializedProperty srcRelevantBonesData, SerializedProperty destRelevantBonesData,

            SerializedProperty srcIgnoreCenterLine, SerializedProperty destIgnoreCenterLine,
            SerializedProperty srcIgnoreRightArm, SerializedProperty destIgnoreRightArm,
            SerializedProperty srcIgnoreLeftArm, SerializedProperty destIgnoreLeftArm,
            SerializedProperty srcIgnoreRightLeg, SerializedProperty destIgnoreRightLeg,
            SerializedProperty srcIgnoreLeftLeg, SerializedProperty destIgnoreLeftLeg,

            SerializedObject destSerializedObj)
        {
            if (destSerializedObj.targetObject == null)
                return;

            destSerializedObj.Update();
            for (var i = 0; i < destMuscle.arraySize; i++)
            {
                destMuscle.GetArrayElementAtIndex(i).floatValue = srcMuscle.GetArrayElementAtIndex(i).floatValue;
                destRelevant.GetArrayElementAtIndex(i).boolValue = srcRelevant.GetArrayElementAtIndex(i).boolValue;
            }

            for (var i = 0; i < destBoneOrientations.arraySize; i++)
            {
                destBoneOrientations.GetArrayElementAtIndex(i).vector3Value = srcBoneOrientations.GetArrayElementAtIndex(i).vector3Value;
            }

            for (var i = 0; i < srcRelevantBonesData.arraySize; i++)
            {
                destRelevantBonesData.GetArrayElementAtIndex(i).boolValue = srcRelevantBonesData.GetArrayElementAtIndex(i).boolValue;
            }

            destIgnoreCenterLine.boolValue = srcIgnoreCenterLine.boolValue;
            destIgnoreRightArm.boolValue = srcIgnoreRightArm.boolValue;
            destIgnoreLeftArm.boolValue = srcIgnoreLeftArm.boolValue;
            destIgnoreRightLeg.boolValue = srcIgnoreRightLeg.boolValue;
            destIgnoreLeftLeg.boolValue = srcIgnoreLeftLeg.boolValue;

            destSerializedObj.ApplyModifiedProperties();
        }

        void PreviewBodyPoseGUI()
        {
            if (m_PreviewBodyPose != null)
            {
                if (m_BodyPosePreviewEditor == null)
                    m_BodyPosePreviewEditor = CreateEditor(m_PreviewBodyPose.gameObject);

                m_BodyPosePreviewEditor.OnInteractivePreviewGUI(
                    GUILayoutUtility.GetRect(k_PreviewPoseWidth, k_PreviewPoseHeight), EditorStyles.whiteLabel);

                return;
            }

            Debug.LogError("No body pose found; check MarsBodySettings and assign a body.");
        }

        void UpdateBodyPoseDataForPreviewAvatar()
        {
            var anim = m_PreviewBodyPose.GetComponent<Animator>();
            HumanPoseHandler humanPoseHandler = new HumanPoseHandler(anim.avatar, m_PreviewBodyPose.transform);
            HumanPose humanPose = new HumanPose();
            humanPoseHandler.GetHumanPose(ref humanPose);
            for (var i = 0; i < humanPose.muscles.Length; i++)
                humanPose.muscles[i] = m_MuscleDataPropToTweak.GetArrayElementAtIndex(i).floatValue;

            humanPoseHandler.SetHumanPose(ref humanPose);

            Vector3[] updatedBoneOrientations = BodyExpressionAction.GenerateBoneOrientations(anim);
            for (var i = 0; i < updatedBoneOrientations.Length; i++)
            {
                m_BonesOrientationsPropToTweak.GetArrayElementAtIndex(i).vector3Value = updatedBoneOrientations[i];
            }

            m_SerializedObjToTweak.ApplyModifiedProperties();
        }

        void RepaintBodyPosePreviewWindow()
        {
            DestroyImmediate(m_BodyPosePreviewEditor);
            m_BodyPosePreviewEditor = CreateEditor(m_PreviewBodyPose.gameObject);
        }

        void OnUndoRedoPerformed()
        {
            m_SerializedObjToTweak.Update();
            UpdateBodyPoseDataForPreviewAvatar();
            RepaintBodyPosePreviewWindow();
        }
    }
}
