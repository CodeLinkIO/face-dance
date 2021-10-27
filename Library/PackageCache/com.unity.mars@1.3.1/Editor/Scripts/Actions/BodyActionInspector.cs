using Unity.MARS;
using Unity.MARS.Actions;
using Unity.MARS.Attributes;
using Unity.MARS.Data;
using UnityEngine;

using UnityObject = UnityEngine.Object;

namespace UnityEditor.MARS
{
    [ComponentEditor(typeof(MatchBodyPoseAction))]
    class BodyActionInspector : ComponentInspector
    {
        class Styles
        {
            internal const int editBindingsLabelOffset = 5;
            internal const int editBindingsButtonBottomPadding = 8;

            internal const string editBindingsLabel = "Edit Bindings";

            internal readonly GUIContent defaultBodyRigButtonContent;
            internal readonly GUIContent customBodyRigButtonContent;
            internal readonly GUIContent scaleToMatchHeightContent;
            internal readonly GUIContent resetOnLossContent;
            internal readonly GUIContent animatorContent;
            internal readonly GUIContent editBindingsContent;

            public Styles()
            {
                defaultBodyRigButtonContent = new GUIContent("Transparent Default",
                    "Creates a new default body rig as a child of this Proxy, and assigns it to match the tracked body.");
                customBodyRigButtonContent = new GUIContent("Custom Avatar",
                    "Select a humanoid avatar to match to the tracked body.");
                scaleToMatchHeightContent = new GUIContent("Scale To Match Height",
                    "Scales the body to match the actual height of the person");
                resetOnLossContent = new GUIContent("Reset On Tracking Loss",
                    "When enabled, the object's pose and scale will be reset if the data for it is lost");
                animatorContent = new GUIContent("Animator", "Animator which the body proxy will match");
                editBindingsContent = new GUIContent(MarsUIResources.instance.BodyIconData.AvatarIcon.Icon, "Edits the current assigned avatar pose that is referenced in the Animator field");
            }
        }

        static Styles s_Styles;
        static Styles styles => s_Styles ?? (s_Styles = new Styles());

        const string k_NoAnimatorMessage = "An animator needs to be assigned to match a synthetic body in the simulation view";
        const string k_DefaultBodyRigGameObjectName = "Default Body Rig";

        const string k_AnimatorPropertyGuid = "m_Animator";
        const string k_ScaleToMatchHeightPropertyGuid = "m_ScaleToMatchHeight";
        const string k_ResetOnLossPropertyGuid = "m_ResetOnLoss";

        MatchBodyPoseAction m_MatchBodyPoseAction;
        SerializedProperty m_AnimatorProperty;
        SerializedProperty m_ScaleToMatchHeightProperty;
        SerializedProperty m_ResetOnLossProperty;

        public override void OnEnable()
        {
            m_MatchBodyPoseAction = (MatchBodyPoseAction) target;

            m_AnimatorProperty = serializedObject.FindProperty(k_AnimatorPropertyGuid);
            m_ScaleToMatchHeightProperty = serializedObject.FindProperty(k_ScaleToMatchHeightPropertyGuid);
            m_ResetOnLossProperty = serializedObject.FindProperty(k_ResetOnLossPropertyGuid);

            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            HandlePicker();

            serializedObject.Update();

            GUILayout.Space(8);

            using (var changeCheck = new EditorGUI.ChangeCheckScope())
            {
                using (new GUILayout.HorizontalScope()) {

                    GUILayout.Label("Body Rig", MarsEditorGUI.Styles.ResetLabelMarginStyle, GUILayout.Width(EditorGUIUtility.labelWidth));

                    using (new EditorGUI.DisabledGroupScope(m_AnimatorProperty.objectReferenceValue != null))
                    {
                        if (GUILayout.Button(styles.defaultBodyRigButtonContent, MarsEditorGUI.Styles.ResetButtonMarginStyle,
                            GUILayout.MaxWidth((EditorGUIUtility.currentViewWidth - MarsEditorGUI.MarsStyles.LabelOffsetHalfBindingsButtonWidth) / 2)))
                        {
                            var defaultBodyRig = GameObject.Instantiate(
                                MarsBodySettings.instance.DefaultLandmarksBodyRig, m_MatchBodyPoseAction.transform).GetComponent<Animator>();
                            defaultBodyRig.gameObject.name = k_DefaultBodyRigGameObjectName;

                            Undo.RegisterCreatedObjectUndo(defaultBodyRig, "Create default body rig");

                            m_AnimatorProperty.objectReferenceValue = defaultBodyRig.GetComponent<Animator>();
                        }
                    }

                    GUILayout.Space(4);

                    if (GUILayout.Button(styles.customBodyRigButtonContent, MarsEditorGUI.Styles.ResetButtonMarginStyle,
                        GUILayout.MaxWidth((EditorGUIUtility.currentViewWidth - MarsEditorGUI.MarsStyles.LabelOffsetHalfBindingsButtonWidth) / 2)))
                    {
                        var controlId = GUIUtility.GetControlID(FocusType.Passive);
                        EditorGUIUtility.ShowObjectPicker<Avatar>(null, false, string.Empty, controlId);
                    }
                }

                GUILayout.Space(2);

                EditorGUILayout.PropertyField(m_AnimatorProperty, styles.animatorContent);

                using (new EditorGUI.DisabledScope(m_AnimatorProperty.objectReferenceValue == null))
                {
                    using (new GUILayout.HorizontalScope())
                    {
                        GUILayout.Space(EditorGUIUtility.labelWidth);

                        if (GUILayout.Button(styles.editBindingsContent, MarsEditorGUI.Styles.IconButtonStyle,
                            GUILayout.Width(MarsEditorGUI.MarsStyles.EditBindingsButtonWidth), GUILayout.Height(MarsEditorGUI.MarsStyles.EditBindingsButtonHeight)))
                        {
                            var referencedAnimator = (Animator) m_AnimatorProperty.objectReferenceValue;
                            BodyTrackingModule.OpenAvatarEditor(referencedAnimator.avatar,
                                false);
                        }

                        using (new GUILayout.VerticalScope())
                        {
                            GUILayout.Space(Styles.editBindingsLabelOffset);
                            GUILayout.Label(Styles.editBindingsLabel);
                        }
                    }
                }

                GUILayout.Space(Styles.editBindingsButtonBottomPadding);

                EditorGUILayout.PropertyField(m_ScaleToMatchHeightProperty, styles.scaleToMatchHeightContent);
                EditorGUILayout.PropertyField(m_ResetOnLossProperty, styles.resetOnLossContent);

                if (changeCheck.changed)
                {
                    serializedObject.ApplyModifiedProperties();
                }
            }

            if (m_AnimatorProperty.objectReferenceValue == null)
                EditorGUILayout.HelpBox(k_NoAnimatorMessage, MessageType.Warning);
        }

        void HandlePicker()
        {
            if (Event.current.commandName != "ObjectSelectorClosed" || Event.current.type != EventType.Layout)
                return;

            var pickedObject = EditorGUIUtility.GetObjectPickerObject();
            if (pickedObject == null || pickedObject.GetType() != typeof(Avatar))
                return;

            var path = AssetDatabase.GetAssetPath(pickedObject);
            var prefab = AssetDatabase.LoadMainAssetAtPath(path) as GameObject;
            var instance = UnityObject.Instantiate(prefab, ((MatchBodyPoseAction) target).transform);
            m_AnimatorProperty.objectReferenceValue = instance;
            serializedObject.ApplyModifiedProperties();
            Undo.RegisterCreatedObjectUndo(instance, "Create Custom Avatar");
        }
    }
}
