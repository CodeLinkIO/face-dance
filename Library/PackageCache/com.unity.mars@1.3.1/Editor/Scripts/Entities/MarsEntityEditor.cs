using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS.Authoring;
using Unity.MARS.Conditions;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Authoring;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Custom editor for all MARSEntity components
    /// </summary>
    [CanEditMultipleObjects]
    [CustomEditor(typeof(MARSEntity), true)]
    class MarsEntityEditor : Editor
    {
        static readonly string[] k_PropertiesToIgnore =
        {
            "m_PrefabParentObject",
            "m_PrefabInternal",
            "m_GameObject",
            "m_ObjectHideFlags",
            "m_EditorHideFlags",
            "m_Script",
            "m_EditorClassIdentifier",
            "m_PrefabInstance",
            "m_PrefabAsset"
        };

        const string k_MultiEditingWarning = "Multi-entity editing not supported in the inspector.\nYou can still use handles in the scene view.";
        const string k_NoConditionsAssignedWarning = "No conditions have been assigned to this entity, so it won't match any world data.\n" +
            "Use 'Add MARS Component -> Condition' below, or click the button to add a PlaneSize condition to make this Entity match a surface with a minimum size.";
        const string k_NoRelationWarning = "No relations have been assigned to this set.\n" +
            "Use 'Add MARS Component -> Relation' below, or click the button to add an Elevation relation.";
        const string k_SelectObjectLabel = "Select Object";
        const string k_SelectSimObject = "In Simulation";
        const string k_SelectSceneObject = "In Scene View";
        const string k_WizardAddElevation = "Add Elevation Relation";
        const string k_WizardAddPlaneSize = "Add PlaneSize Condition";
        const string k_EntityWizardAnalyticEventBase = "EntityWizard / ";
        const string k_NoConditions = k_EntityWizardAnalyticEventBase + "No Conditions";
        const string k_AddPlaneSizeCondition = k_EntityWizardAnalyticEventBase + "Add PlaneSizeCondition";
        const string k_NoRelation = k_EntityWizardAnalyticEventBase + "No Relation";
        const string k_AddElevationRelation = k_EntityWizardAnalyticEventBase + "Add Elevation Relation";
        const string k_ColorUndoLabel = "Modify Color";
        const float k_ColorOptionsButtonWidth = 24f;

        [SerializeField]
        public MonoBehaviourComponentList monoBehaviourComponent;

        [SerializeField]
        // ReSharper disable once NotAccessedField.Local
#pragma warning disable 0414
        SerializedObject m_SerializedComponents;
#pragma warning restore 0414

        static readonly GUIContent k_StopShowingEntityHints = new GUIContent("X", "Stop showing MARSEntity hints");
        static readonly GUIContent k_LearnMoreSetsButton = new GUIContent("?", "Learn more about MARS Sets");
        static readonly GUIContent k_LearnMoreConditionsButton = new GUIContent("?", "Learn more about MARS Conditions");
        static readonly GUIContent k_SetNewColorContent = new GUIContent("Set new color");
        static readonly GUIContent k_SetSimilarToParentContent = new GUIContent("Set similar to parent");
        static readonly GUIContent k_ApplySimilarToChildrenContent = new GUIContent("Apply similar to children");
        static readonly GUIContent k_ResetToDefaultContent = new GUIContent("Reset to default");

        GUIContent m_ColorOptionsButtonContent;
        MarsComponentListEditor m_ListEditor;
        MARSEntity m_SelectedEntity;
        Transform m_SelectedTransform;
        List<Condition> m_Conditions = new List<Condition>();
        List<Relation> m_Relations = new List<Relation>();
        SerializedProperty m_ColorProperty;
        GenericMenu m_ColorOptionMenu;
        List<MultiConditionBase> m_MultiConditions = new List<MultiConditionBase>();
        List<MultiRelationBase> m_MultiRelations = new List<MultiRelationBase>();

        public void OnEnable()
        {
            m_SelectedEntity = (MARSEntity)target;

            m_ColorProperty = serializedObject.FindProperty("m_Color");
            if (m_ColorProperty != null)
            {
                SetupColorOptionMenu();
                m_ColorOptionsButtonContent = new GUIContent(MarsUIResources.instance.Ellipisis, "Color options");
            }

            // HACK: This should not be null but it is when entering play mode with a simulation object selected
            if (!m_SelectedEntity)
                return;

            m_SelectedTransform = m_SelectedEntity.transform;
            RefreshComponentList();

            Undo.undoRedoPerformed += OnUndoRedoPerformed;
        }

        void OnDisable()
        {
            Undo.undoRedoPerformed -= OnUndoRedoPerformed;

            if (m_ListEditor != null)
                m_ListEditor.Clear();

            // Catches conditions being added since OnDisable is called when undo/redo is called
            // and when adding/removing/copying a condition component, even when inspector is closed.
            // May be null if Modules have not reloaded before code on inspector is called.
            ModuleLoaderCore.instance.GetModule<MarsEntityEditorModule>()?.UpdateConditionData();
        }

        void SetupColorOptionMenu()
        {
            m_ColorOptionMenu = new GenericMenu();
            m_ColorOptionMenu.AddItem(k_SetNewColorContent, false, SetNewColor);
            m_ColorOptionMenu.AddItem(k_SetSimilarToParentContent, false, SetSimilarToParent);
            m_ColorOptionMenu.AddItem(k_ApplySimilarToChildrenContent, false, ApplyHueToChildren);
            m_ColorOptionMenu.AddItem(k_ResetToDefaultContent, false, ResetColorToDefault);
        }

        void RefreshComponentList()
        {
            m_ListEditor = new MarsComponentListEditor(this);
            m_ListEditor.OnComponentPasted += ListEditorOnOnComponentPasted;

            monoBehaviourComponent = CreateInstance<MonoBehaviourComponentList>();
            foreach (var editorTarget in targets)
            {
                var entity = editorTarget as MARSEntity;
                if (entity == null)
                    continue;

                var components = entity.GetComponents<MonoBehaviour>()
                    .Where(w => w != null && MarsComponentListEditor.SupportsType(w.GetType())).ToList();

                monoBehaviourComponent.components.AddRange(components);
            }

            m_ListEditor.Init(monoBehaviourComponent, m_SerializedComponents = new SerializedObject(monoBehaviourComponent));
            m_SelectedEntity.GetComponents(m_Relations);
            m_SelectedEntity.GetComponents(m_MultiRelations);
            m_SelectedEntity.GetComponents(m_Conditions);
            m_SelectedEntity.GetComponents(m_MultiConditions);

            // Don't try to copy simulatables if in play mode or in main scene
            var simSceneModule = SimulationSceneModule.instance;
            if (EditorApplication.isPlayingOrWillChangePlaymode || simSceneModule == null
                || m_SelectedEntity.gameObject.scene != simSceneModule.ContentScene)
                return;

            // Copy any new components
            var simulatedObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            if (simulatedObjectsManager == null)
                return;

            foreach (var mb in monoBehaviourComponent.components)
            {
                var simulated = mb as ISimulatable;
                if (simulated == null)
                    continue;

                var original = simulatedObjectsManager.GetOriginalSimulatable(simulated);
                if (original == null)
                {
                    var originalEntity = (MARSEntity)simulatedObjectsManager.GetOriginalSimulatable(mb.GetComponent<MARSEntity>());
                    if (originalEntity != null)
                    {
                        var newComp = originalEntity.gameObject.AddComponent(simulated.GetType()) as ISimulatable;
                        simulatedObjectsManager.AddSimulatedCopy(simulated, newComp);
                        ApplySimulatedChangesToOriginal();
                    }
                }
            }
        }

        void ListEditorOnOnComponentPasted()
        {
            ApplySimulatedChangesToOriginal();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawColorEditor();

            if (serializedObject.isEditingMultipleObjects)
            {
                EditorGUILayout.HelpBox(k_MultiEditingWarning, MessageType.Info);
            }
            else
            {
                DrawSelectObjectButtons();
                MarsCompareTool.DrawControls(this);

                if (MarsHints.ShowEntitySetupHints)
                    DrawEntitySetupWizard();

                using (var check = new EditorGUI.ChangeCheckScope())
                {
                    m_ListEditor.OnGUI();
                    if (check.changed)
                    {
                        serializedObject.ApplyModifiedProperties();
                        ApplySimulatedChangesToOriginal();
                        m_SelectedEntity.GetComponents(m_Relations);
                        m_SelectedEntity.GetComponents(m_MultiRelations);
                        m_SelectedEntity.GetComponents(m_Conditions);
                        m_SelectedEntity.GetComponents(m_MultiConditions);
                    }
                }
            }
        }

        void DrawColorEditor()
        {
            if (m_ColorProperty == null)
                return;

            using (new EditorGUILayout.HorizontalScope())
            {
                using (var check = new EditorGUI.ChangeCheckScope())
                {
                    EditorGUILayout.PropertyField(m_ColorProperty, GUILayout.ExpandWidth(false));

                    if (check.changed)
                    {
                        serializedObject.ApplyModifiedProperties();
                        foreach (var selected in targets)
                        {
                            var editorColor = target as IHasEditorColor;
                            if (editorColor != null)
                            {
                                editorColor.colorIndex =
                                    -1; // Clear color index because it is now using a custom color.
                                EntityVisualsModule.instance.UpdateColor((MARSEntity) selected);
                            }
                        }
                    }
                }

                if (GUILayout.Button(m_ColorOptionsButtonContent, MarsEditorGUI.InternalEditorStyles.ButtonIcon, GUILayout.Width(k_ColorOptionsButtonWidth), GUILayout.Height(EditorGUIUtility.singleLineHeight)))
                {
                    m_ColorOptionMenu.ShowAsContext();
                }
            }
        }

        void SetNewColor()
        {
            Undo.RecordObjects(targets, k_ColorUndoLabel);
            foreach (var selected in targets)
            {
                var editorColor = selected as IHasEditorColor;
                if (editorColor != null)
                {
                    editorColor.SetNewColor(false, true);
                    EntityVisualsModule.instance.UpdateColor((MARSEntity) selected);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

        void ResetColorToDefault()
        {
            Undo.RecordObjects(targets, k_ColorUndoLabel);
            foreach (var selected in targets)
            {
                var editorColor = selected as IHasEditorColor;
                if (editorColor != null)
                {
                    editorColor.SetNewColor(false);
                    EntityVisualsModule.instance.UpdateColor((MARSEntity) selected);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

        void SetSimilarToParent()
        {
            Undo.RecordObjects(targets, k_ColorUndoLabel);
            foreach (var selected in targets)
            {
                var entity = (MARSEntity)selected;
                if (entity.transform.parent == null)
                    continue;

                var editorColor = selected as IHasEditorColor;
                if (editorColor != null)
                {
                    editorColor.SetNewColor(true);
                    EntityVisualsModule.instance.UpdateColor(entity);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

        void ApplyHueToChildren()
        {
            Undo.RecordObjects(targets, k_ColorUndoLabel);
            foreach (var selected in targets)
            {
                var editorColor = selected as IHasEditorColor;
                if (editorColor == null)
                    continue;

                var component = (Component)editorColor;
                foreach (var childEditorColor in component.GetComponentsInChildren<IHasEditorColor>())
                {
                    if (childEditorColor == editorColor)
                        continue;

                    Undo.RecordObject((Component)childEditorColor, k_ColorUndoLabel);

                    childEditorColor.SetNewColor(true);
                    var childEntity = childEditorColor as MARSEntity;
                    if (childEntity != null)
                        EntityVisualsModule.instance.UpdateColor(childEntity);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

        void OnUndoRedoPerformed()
        {
            foreach (var selected in targets)
            {
                var entity = selected as MARSEntity;
                foreach (var childEntity in entity.GetComponentsInChildren<MARSEntity>())
                {
                    if (childEntity is IHasEditorColor)
                    {
                        EntityVisualsModule.instance.UpdateColor(childEntity);
                    }
                }
            }
        }

        void DrawSelectObjectButtons()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                return;

            var simulatedObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            if (simulatedObjectsManager == null)
                return;

            var simObject = simulatedObjectsManager.GetCopiedTransform(m_SelectedTransform);
            var sceneObject = simulatedObjectsManager.GetOriginalTransform(m_SelectedTransform);

            if (simObject != null || sceneObject != null)
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    EditorGUILayout.PrefixLabel(k_SelectObjectLabel);

                    using (new EditorGUI.DisabledScope(simObject == null))
                    {
                        if (GUILayout.Button(k_SelectSimObject, MarsEditorGUI.Styles.MiniFontButton, GUILayout.ExpandWidth(true)))
                            Selection.activeTransform = simObject;
                    }

                    using (new EditorGUI.DisabledScope(sceneObject == null))
                    {
                        if (GUILayout.Button(k_SelectSceneObject, MarsEditorGUI.Styles.MiniFontButton, GUILayout.ExpandWidth(true)))
                            Selection.activeTransform = sceneObject;
                    }
                }
            }
        }

        void DrawEntitySetupWizard()
        {
            var drewWizard = true;

            if ((m_SelectedEntity as Replicator) != null)
            {
                drewWizard = false;
            }
            else if ((m_SelectedEntity as ProxyGroup) != null)
            {
                if (m_Relations.Count < 1 && m_MultiRelations.Count < 1)
                {
                    MarsEditorUtils.HintBox(true, k_NoRelationWarning, k_NoRelation,
                        k_LearnMoreSetsButton, MarsHelpURLs.ProxyGroupHelpURL, k_StopShowingEntityHints,
                        () => {
                            MarsHints.ShowEntitySetupHints = false;
                        });

                    if (GUILayout.Button(k_WizardAddElevation))
                    {
                        Undo.AddComponent<ElevationRelation>(m_SelectedEntity.gameObject);
                        EditorEvents.UiComponentUsed.Send(new UiComponentArgs { label = k_AddElevationRelation });
                    }
                }
            }
            else if (m_Conditions.Count < 1 && m_MultiConditions.Count < 1)
            {
                MarsEditorUtils.HintBox(true, k_NoConditionsAssignedWarning, k_NoConditions,
                    k_LearnMoreConditionsButton, MarsHelpURLs.ProxyConditionsHelpURL, k_StopShowingEntityHints, () =>
                    {
                        MarsHints.ShowEntitySetupHints = false;
                    });

                if (GUILayout.Button(k_WizardAddPlaneSize))
                {
                    Undo.AddComponent<PlaneSizeCondition>(m_SelectedTransform.gameObject);
                    EditorEvents.UiComponentUsed.Send(new UiComponentArgs { label = k_AddPlaneSizeCondition });
                    EntityVisualsModule.instance.InvalidateVisual(m_SelectedEntity);
                }
            }
            else
            {
                drewWizard = false;
            }

            if (drewWizard)
                EditorGUILayout.Separator();
        }

        public void EditorOnSceneGUI(SceneView sceneView)
        {
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                if (sceneView == SceneView.lastActiveSceneView)
                {
                    m_ListEditor.OnSceneGUI();
                    if (check.changed)
                    {
                        ApplySimulatedChangesToOriginal();
                    }
                }
            }
        }

        void ApplySimulatedChangesToOriginal()
        {
            // Don't apply changes to original if already in the editor scene
            var simSceneModule = SimulationSceneModule.instance;
            if (simSceneModule == null || m_SelectedEntity.gameObject.scene != simSceneModule.ContentScene)
                return;

            // Copy serialized properties from all the MonoBehaviours that this editor is editing
            var simulatedObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            if (simulatedObjectsManager == null)
                return;

            foreach (var mb in monoBehaviourComponent.components)
            {
                var simulated = mb as ISimulatable;
                if (simulated == null)
                    continue;

                var original = simulatedObjectsManager.GetOriginalSimulatable(simulated);
                if (original == null)
                    continue;

                // Check if the object is destroyed
                var originalMono = original as MonoBehaviour;
                if (originalMono == null)
                {
                    simulatedObjectsManager.DirtySimulatableScene();
                    continue;
                }

                var originalSerialized = new SerializedObject(originalMono);
                var simulatableSerialized = new SerializedObject(simulated as MonoBehaviour);

                var propertyIterator = simulatableSerialized.GetIterator();
                var enterChildren = true;
                while (NextUserProperty(propertyIterator, enterChildren))
                {
                    enterChildren = true;
                    // If the property is referencing a simulation object, want to get the reference to the original version.
                    if (propertyIterator.propertyType == SerializedPropertyType.ObjectReference &&
                        propertyIterator.objectReferenceValue != null)
                    {
                        var referenceInstanceId = propertyIterator.objectReferenceInstanceIDValue;
                        var reference = EditorUtility.InstanceIDToObject(referenceInstanceId);
                        var originalRef = simulatedObjectsManager.GetOriginalObject(reference);
                        if (originalRef != null)
                        {
                            originalSerialized.FindProperty(propertyIterator.propertyPath).objectReferenceInstanceIDValue = originalRef.GetInstanceID();
                            enterChildren = false; //Don't copy the file id and path id
                            continue; // Don't copy this property because it is a reference and not a prefab
                        }
                    }

                    // For all other serialized properties copy them if they are different
                    originalSerialized.CopyFromSerializedPropertyIfDifferent(propertyIterator);
                }

                originalSerialized.ApplyModifiedProperties();
                originalSerialized.Dispose();
                simulatableSerialized.Dispose();
            }
        }

        static bool NextUserProperty(SerializedProperty propertyIterator, bool enterChildren)
        {
            if (!propertyIterator.Next(enterChildren))
                return false;

            var userProperty = true;
            do
            {
                userProperty = true;
                foreach (var ignoreString in k_PropertiesToIgnore)
                {
                    if (propertyIterator.propertyPath.Contains(ignoreString))
                    {
                        userProperty = false;
                        if (!propertyIterator.Next(false)) // Skip children of ignored property
                            return false; // Return false if there is no next property

                        break;
                    }
                }
            }
            while (!userProperty);

            return true;
        }

        /// <summary>
        /// Invalidates the visuals for the entity and re-syncs the values in the editor.
        /// </summary>
        public void Invalidate()
        {
            EntityVisualsModule.instance.InvalidateVisual(m_SelectedEntity);
            OnDisable();

            var simulatedObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            foreach (var mb in monoBehaviourComponent.components)
            {
                if (simulatedObjectsManager == null)
                    continue;

                // Early out if object was destroyed
                if (mb == null)
                {
                    simulatedObjectsManager.DirtySimulatableScene();
                    break;
                }

                var simulatable = mb as ISimulatable;
                if (simulatable == null)
                    continue;

                if (SimulatedObjectsManager.IsSimulatedObject(mb.gameObject))
                {
                    // If object is simulated we need to check the original version still exists.
                    var original = simulatedObjectsManager.GetOriginalSimulatable(simulatable);
                    if (original != null)
                    {
                        // Check if the object is destroyed
                        var originalMono = original as MonoBehaviour;
                        if (originalMono == null)
                        {
                            simulatedObjectsManager.DirtySimulatableScene();
                            break;
                        }
                    }
                }
                else
                {
                    // If object is original(scene) we need to check the simulated version still exists.
                    var simulated = simulatedObjectsManager.GetCopiedSimulatable(simulatable);
                    if (simulated != null)
                    {
                        // Check if the object is destroyed
                        var simulatedMono = simulated as MonoBehaviour;
                        if (simulatedMono == null)
                        {
                            simulatedObjectsManager.DirtySimulatableScene();
                            break;
                        }
                    }
                }
            }

            OnEnable();
            Repaint();
        }
    }
}
