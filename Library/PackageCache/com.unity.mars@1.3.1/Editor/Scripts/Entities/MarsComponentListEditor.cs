using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.MARS;
using Unity.MARS.Attributes;
using Unity.MARS.Data;
using Unity.MARS.Query;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor.MARS.Simulation;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Scripting.APIUpdating;
using UnityObject = UnityEngine.Object;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Handles the drawing of a collection of MARSComponent editors in an inspector.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    internal sealed class MarsComponentListEditor : ComponentListEditor<MonoBehaviour>
    {
        static readonly List<Type> k_Types = new List<Type>();
        static readonly Dictionary<Type, MonoBehaviourComponentMenuAttribute> k_ComponentTypes
            = new Dictionary<Type, MonoBehaviourComponentMenuAttribute>();

        const string k_ResetGameObjectName = "ResetGameObject";
        const string k_ClipboardGameObjectName = "ClipboardGameObject";
        const string k_ConditionsMenuPrefix = "Condition/Other/";
        const string k_ActionsMenuPrefix = "Action/Other/";

        static UnityObject s_ClipboardContent;
        static GameObject s_ClipboardGameObject;

        GameObject m_ResetGameObject;
        List<MonoBehaviour> m_ConflictingBehaviors = new List<MonoBehaviour>();

        public event Action OnComponentPasted;

        static MarsComponentListEditor()
        {
            // Get all MonoBehaviour types with MonoBehaviourComponentMenuAttribute attribute
            typeof(MonoBehaviour).GetAssignableTypes(k_Types, type =>
                type.IsDefined(typeof(MonoBehaviourComponentMenuAttribute), false) && !type.IsAbstract);

            foreach (var type in k_Types)
            {
                k_ComponentTypes.Add(type, type.GetAttribute<MonoBehaviourComponentMenuAttribute>());
            }

            // Get all other MonoBehaviour types that should be in this list editor
            var conditionTypes = new List<Type>();
            typeof(ICondition).GetAssignableTypes(conditionTypes, type =>
                typeof(MonoBehaviour).IsAssignableFrom(type) &&
                !type.IsAbstract &&
                !type.GetCustomAttributes(typeof(ExcludeInMARSEditor), false).Any());

            foreach (var type in conditionTypes)
            {
                if (k_ComponentTypes.ContainsKey(type))
                    continue;

                k_ComponentTypes.Add(type,
                    new MonoBehaviourComponentMenuAttribute(type, k_ConditionsMenuPrefix + ObjectNames.NicifyVariableName(type.Name)));
            }

            var actionTypes = new List<Type>();
            typeof(IAction).GetAssignableTypes(actionTypes, type =>
                typeof(MonoBehaviour).IsAssignableFrom(type) &&
                !type.IsAbstract &&
                !type.GetCustomAttributes(typeof(ExcludeInMARSEditor), false).Any());

            foreach (var type in actionTypes)
            {
                if (k_ComponentTypes.ContainsKey(type))
                    continue;

                k_ComponentTypes.Add(type,
                    new MonoBehaviourComponentMenuAttribute(type, k_ActionsMenuPrefix + ObjectNames.NicifyVariableName(type.Name)));
            }
        }

        /// <summary>
        /// Is the object type supported in the <c>MarsComponentListEditor</c>
        /// based on type having the <c>MonoBehaviourComponentMenuAttribute</c>
        /// </summary>
        /// <param name="type">Type to check if supported</param>
        /// <returns><c>true</c> if the type is supported with a <c>MonoBehaviourComponentMenuAttribute</c> on the type.</returns>
        public static bool SupportsType(Type type)
        {
            return k_ComponentTypes.ContainsKey(type);
        }

        public MarsComponentListEditor(Editor editor)
            : base(editor)
        {
            Assert.IsNotNull(editor);
            m_BaseEditor = editor;
        }

        public override void Clear()
        {
            base.Clear();
            if (m_ResetGameObject != null)
                UnityObject.DestroyImmediate(m_ResetGameObject);
        }

        protected override void CreateEditor(UnityObject component, SerializedProperty property, bool forceExpand = false, int index = -1)
        {
            base.CreateEditor(component, property, forceExpand, index);

            // Hide everything except MARSEntities, which are the host of these editors
            if (component as MARSEntity == null)
                component.hideFlags |= HideFlags.HideInInspector;
        }

        protected override void AddComponentMenuButton()
        {
            var componentTabSelection = MarsInspectorSharedSettings.Instance.ComponentTabSelection;

            // Skip this button in the case of Forces, because they have their more complex button already and this button is redundant.
            if (componentTabSelection == k_ForcesTab)
                return;

            var tabIsAllOrSettings = componentTabSelection == k_AllTabs || componentTabSelection == k_SettingsTab;

            var addComponentText = "Add MARS Component...";
            if (!tabIsAllOrSettings)
            {
                switch (componentTabSelection)
                {
                    case k_ConditionsTab:
                        addComponentText = "Add Condition...";
                        break;
                    case k_ActionsTab:
                        addComponentText = "Add Action...";
                        break;
                    case k_ForcesTab:
                        addComponentText = "Add Force...";
                        break;
                }
            }

            if (GUILayout.Button(addComponentText, EditorStyles.miniButton))
            {
                var menu = new GenericMenu();
                var isGroup = (m_BaseEditor.target is ProxyGroup);

                foreach (var kvp in k_ComponentTypes)
                {
                    var type = kvp.Key;

                    if (isGroup && !(type.IsSubclassOf(typeof(Relation))))
                        continue;

                    if (!CanDrawSelectedOption(null, type, true))
                        continue;

                    // Check if this component cannot be added because another of its exclusive siblings is added
                    m_ConflictingBehaviors.Clear();
                    var componentClash = HasComponentClash(type, m_ComponentList, false, m_ConflictingBehaviors);

                    if (!componentClash)
                        componentClash = HasRequirementClash(type, m_ComponentList);
                    else if (m_ConflictingBehaviors.Count > 0)
                        m_ConflictingBehaviors.RemoveAll( alternate => HasRequirementClash(alternate.GetType(), m_ComponentList));

                    var menuItem = EditorGUIUtils.GetContent(kvp.Value.menuItem);

                    if (!tabIsAllOrSettings)
                    {
                        var modifiedMenuItem = new GUIContent(menuItem);
                        var text = modifiedMenuItem.text;
                        // If we're in a filtered tab, don't show the first-layer menu (Conditions, Actions, Forces),
                        // because it would be redundant with the tab itself.
                        modifiedMenuItem.text = text.Substring(text.IndexOf("/", StringComparison.Ordinal) + 1);
                        menuItem = modifiedMenuItem;
                    }

                    if (!componentClash)
                    {
                        menu.AddItem(menuItem, false, () => AddComponent(type));
                    }
                    else if (m_ConflictingBehaviors.Count > 0)
                    {
                        var conflictingComponent = m_ConflictingBehaviors[0];

                        var conflictingTypeName = conflictingComponent.GetType().Name;
                        if (k_ComponentTypes.ContainsKey(conflictingComponent.GetType()))
                        {
                            conflictingTypeName = k_ComponentTypes[conflictingComponent.GetType()].menuItem;
                            if (conflictingTypeName.Contains("/"))
                                conflictingTypeName = conflictingTypeName.Substring(conflictingTypeName.IndexOf("/", StringComparison.Ordinal) + 1);
                        }

                        var insertText = $"Replace/{conflictingTypeName} with";
                        var menuItemText = menuItem.text;
                        if (menuItemText.Contains("/"))
                        {
                            var lastIndex = menuItemText.IndexOf("/", StringComparison.Ordinal);
                            menuItemText = menuItemText.Insert(lastIndex, "/" + insertText);
                        }
                        else
                        {
                            menuItemText = insertText + "/" + menuItemText;
                        }

                        menu.AddItem(new GUIContent(menuItemText), false, () =>
                        {
                            Undo.DestroyObjectImmediate(conflictingComponent);
                            AddComponent(type);
                        });
                    }
                }

                menu.ShowAsContext();
            }
        }

        protected override void AddComponent(Type type)
        {
            m_SerializedObject.Update();
            var comp = CreateNewComponent(type);
            if (comp == null)
            {
                Debug.LogWarningFormat("Cant add new component {0} since it cannot be created", type);
                return;
            }
            SetComponentTabAccordingToAddedType(type);
            Undo.RegisterCreatedObjectUndo(comp, "Add Component");

            m_SerializedObject.ApplyModifiedProperties();

            // Forces the new Component to be expanded in the Inspector.
            m_ComponentProperty = m_SerializedObject.FindProperty("m_Components");
            for (var i = 0; i < m_ComponentList.components.Count; i++)
            {
                if (comp.Equals(m_ComponentList.components[i]))
                {
                    CreateEditor(comp, m_ComponentProperty.GetArrayElementAtIndex(i), true);
                    break;
                }
            }

            m_SerializedObject.Update();
            UpdateAllEntityEditors();

            EditorEvents.MarsComponentChange.Send(new ComponentChangeArgs(type, true));
        }

        static void UpdateAllEntityEditors()
        {
            foreach (var editor in Resources.FindObjectsOfTypeAll<MarsEntityEditor>())
            {
                editor.Invalidate();
            }
        }

        protected override void RemoveComponent(int id)
        {
            var componentToRemove = m_ComponentList.components[id];
            var simulated = componentToRemove as ISimulatable;
            var isSimulated = false;
            if (simulated != null)
            {
                var simulatedObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
                if (simulatedObjectsManager != null)
                {
                    var original = (Component)simulatedObjectsManager.GetOriginalSimulatable(simulated);
                    if (original != null)
                    {
                        isSimulated = true;
                        Undo.DestroyObjectImmediate(original);
                        Undo.IncrementCurrentGroup();
                    }
                }
            }

            // TODO - haven't figured out how to record MARS component removal for analytics
            m_RemoveList.Add(id);
            // Do not record undo on remove if this is simulated, because editor will crash on trying to redo if the gameobject has been destroyed
            RemoveComponents(!isSimulated);
            m_SerializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(m_ComponentList.self);
            UpdateAllEntityEditors();
        }

        protected override void ResetComponent(Type type, int id)
        {
            m_SerializedObject.Update();

            var property = m_ComponentProperty.GetArrayElementAtIndex(id);
            var component = property.objectReferenceValue;

            if (m_ResetGameObject == null)
                m_ResetGameObject = EditorUtility.CreateGameObjectWithHideFlags(k_ResetGameObjectName, HideFlags.HideAndDontSave);

            var resetContent = m_ResetGameObject.GetComponent(type);
            if (resetContent == null)
                resetContent = m_ResetGameObject.AddComponent(type);

            Undo.RecordObject(component, "Reset MARS Component Override");
            EditorUtility.CopySerializedIfDifferent(resetContent, component);
            var resetMethod = type.GetMethod("Reset", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (resetMethod != null)
                resetMethod.Invoke(component, null);

            m_SerializedObject.ApplyModifiedProperties();
            m_Editors[id].isDirty = true;
            EditorUtility.SetDirty(m_ComponentList.self);
        }

        protected override MonoBehaviour CreateNewComponent(Type type)
        {
            Assert.IsTrue(type.IsSubclassOf(typeof(MonoBehaviour)));

            var comp = m_BaseEditor.target as Component;
            Assert.IsNotNull(comp);
            var go = comp.gameObject;

            return (MonoBehaviour)go.AddComponent(type);
        }

        protected override void CopyComponent(int id)
        {
            m_SerializedObject.Update();

            var property = m_ComponentProperty.GetArrayElementAtIndex(id);
            var componentObj = property.objectReferenceValue;

            if (s_ClipboardGameObject == null)
            {
                s_ClipboardGameObject = GameObject.Find(k_ClipboardGameObjectName)
                    ?? EditorUtility.CreateGameObjectWithHideFlags(k_ClipboardGameObjectName, HideFlags.HideAndDontSave);
                s_ClipboardGameObject.SetActive(false);
            }

            if (s_ClipboardContent != null)
            {
                UnityObjectUtils.Destroy(s_ClipboardContent);
                s_ClipboardContent = null;
            }

            var component = componentObj as Component;
            Assert.IsNotNull(component);

            var compType = component.GetType();
            s_ClipboardContent = s_ClipboardGameObject.GetComponent(compType);

            if (s_ClipboardContent == null)
                s_ClipboardContent = s_ClipboardGameObject.AddComponent(compType);

            EditorUtility.CopySerializedIfDifferent(componentObj, s_ClipboardContent);
        }

        protected override void PasteComponent(int id)
        {
            m_SerializedObject.Update();

            var property = m_ComponentProperty.GetArrayElementAtIndex(id);
            var component = property.objectReferenceValue;

            Assert.IsNotNull(s_ClipboardContent);
            Assert.AreEqual(s_ClipboardContent.GetType(), component.GetType());

            Undo.RecordObject(component, "Paste Component");
            EditorUtility.CopySerializedIfDifferent(s_ClipboardContent, component);

            if (OnComponentPasted != null)
                OnComponentPasted();

            m_Editors[id].isDirty = true;
        }

        protected override bool CanPasteComponent(int id)
        {
            m_SerializedObject.Update();

            var property = m_ComponentProperty.GetArrayElementAtIndex(id);
            var component = property.objectReferenceValue;

            return s_ClipboardContent != null
                && s_ClipboardContent.GetType() == component.GetType();
        }

        protected override void OnUndoRedoPerformed()
        {
            base.OnUndoRedoPerformed();
            UpdateAllEntityEditors();
        }

        /// <summary>
        /// Checks if this component would have a clash from the DisallowMultipleComponent attribute
        /// with existing components in a a list
        /// </summary>
        /// <param name="type">The type of component we want to test against</param>
        /// <param name="componentList">The list of existing components to compare against</param>
        /// <param name="excludeSelf">Used with hierarchical checks - ignores a component if is a match for the top level type,  where a 'require component' won't actually need to add anything. </param>
        /// <<param name="conflictList">List to add to of found conflicting types (default is null)</param>
        /// <returns>True if the component has exclusive siblings, false otherwise</returns>
        static bool HasComponentClash(Type type, IComponentList<MonoBehaviour> componentList, bool excludeSelf = false, List<MonoBehaviour> conflictList = null)
        {
            k_Types.Clear();
            type.IsDefinedGetInheritedTypes<DisallowMultipleComponent>(k_Types);

            var typeCounter = 0;
            while (typeCounter < k_Types.Count)
            {
                var ct = k_Types[typeCounter];
                var componentInTypeChainMatchesParentTypeInList = componentList.components.Any(comp =>
                {
                    var compType = comp.GetType();
                    if (ct.IsAssignableFrom(compType))
                    {
                        if ((conflictList != null) && (compType != type) && (!ct.IsAssignableFrom(typeof(MARSEntity))))
                            conflictList.Add(comp);

                        return true;
                    }
                    return false;
                });

                if (componentInTypeChainMatchesParentTypeInList)
                    return !(excludeSelf && typeCounter == 0);

                typeCounter++;
            }

            return false;
        }

        /// <summary>
        /// Checks if this component would have a clash from one of its RequiredComponents being
        /// an exclusive sibling to another component already on the object
        /// </summary>
        /// <param name="type">The type of component to check for required components</param>
        /// <param name="componentList">The list of existing components to compare against</param>
        /// <returns>True if the component's required components have exclusive siblings, false otherwise</returns>
        static bool HasRequirementClash(Type type, IComponentList<MonoBehaviour> componentList)
        {
            k_Types.Clear();
            type.IsDefinedGetInheritedTypes<RequireComponent>(k_Types);
            if (k_Types.Count == 0)
                return false;

            var requiredComponent = type.GetAttribute<RequireComponent>(true);

            if (requiredComponent.m_Type0 != null)
            {
                if (HasComponentClash(requiredComponent.m_Type0, componentList, true) ||
                    HasRequirementClash(requiredComponent.m_Type0, componentList))
                    return true;
            }

            if (requiredComponent.m_Type1 != null)
            {
                if (HasComponentClash(requiredComponent.m_Type1, componentList, true) ||
                    HasRequirementClash(requiredComponent.m_Type1, componentList))
                    return true;
            }

            if (requiredComponent.m_Type2 != null)
            {
                if (HasComponentClash(requiredComponent.m_Type2, componentList, true) ||
                    HasRequirementClash(requiredComponent.m_Type2, componentList))
                    return true;
            }

            return false;
        }
    }
}
