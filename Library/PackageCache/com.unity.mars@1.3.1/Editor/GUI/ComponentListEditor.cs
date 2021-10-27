using System;
using System.Collections.Generic;
using Unity.MARS;
using Unity.MARS.Attributes;
using Unity.MARS.Data;
using Unity.MARS.Forces;
using Unity.MARS.Query;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Handles the drawing of a collection of component editors in an inspector.
    /// </summary>
    /// <typeparam name="TObject">Type of component object the editor is used to inspect.</typeparam>
    // Derived from EffectListEditor from PostProcessingStack
    public abstract class ComponentListEditor<TObject> where TObject : Object
    {
        static readonly string k_ProxyFilter = "Filter";
        static readonly string[] k_ProxyComponentsStrings = {"All","Conditions", "Actions", "Forces", "Settings"};
        static string[] k_ProxyFilterStrings = { "All", k_ProxyFilter };
        static readonly string k_DownArrowPostFix = " ▾";

        /// <summary>
        /// Index of the "All Tabs" tab
        /// </summary>
        protected const int k_AllTabs = 0;
        /// <summary>
        /// Index of the "Conditions" tab
        /// </summary>
        protected const int k_ConditionsTab = 1;
        /// <summary>
        /// Index of the "Actions" tab
        /// </summary>
        protected const int k_ActionsTab = 2;
        /// <summary>
        /// Index of the "Forces" tab
        /// </summary>
        protected const int k_ForcesTab = 3;
        /// <summary>
        /// Index of the "Settings" tab
        /// </summary>
        protected const int k_SettingsTab = 4;

        const int k_MinWidthForAllTabs = 360;

        /// <summary>
        /// Dictionary of component type to their editor type.
        /// </summary>
        static readonly Dictionary<Type, Type> k_EditorTypes = new Dictionary<Type, Type>();

        /// <summary>
        /// Parent Editor.
        /// </summary>
        protected Editor m_BaseEditor;
        /// <summary>
        /// The component list collection the editor inspects.
        /// </summary>
        protected IComponentList<TObject> m_ComponentList;
        /// <summary>
        /// A SerializedObject representing the object or objects being inspected.
        /// </summary>
        protected SerializedObject m_SerializedObject;
        /// <summary>
        /// The serialized property of the component list.
        /// </summary>
        protected SerializedProperty m_ComponentProperty;
        /// <summary>
        /// List of all the editors for the component list.
        /// </summary>
        protected List<ComponentInspector> m_Editors;
        /// <summary>
        /// Collection of indies representing the items to be removed for the inspector.
        /// </summary>
        protected List<int> m_RemoveList = new List<int>();

        MarsInspectorSharedSettings m_MarsInspectorSharedSettings;

        /// <summary>
        /// Called before the component inspector draws
        /// </summary>
        public Action<ComponentInspector> beforeDrawComponentInspector { get; set; }
        /// <summary>
        /// Called after the component inspector draws
        /// </summary>
        public Action<ComponentInspector> afterDrawComponentInspector { get; set; }

        bool targetRequiresProxyMenu => (m_BaseEditor.target is Proxy);

        static ComponentListEditor()
        {
            // Gets the list of all available stack-able components
            var editorTypes = TypeCache.GetTypesWithAttribute<ComponentEditorAttribute>();

            // Map them to their corresponding component type
            foreach (var editorType in editorTypes)
            {
                if (editorType.IsAbstract)
                    continue;

                if (!typeof(ComponentInspector).IsAssignableFrom(editorType))
                    continue;

                var attribute = editorType.GetAttribute<ComponentEditorAttribute>();
                var componentType = attribute.ComponentType;
                if (k_EditorTypes.ContainsKey(componentType))
                    Debug.LogError(string.Format("k_EditorTypes already has type {0}", componentType));

                k_EditorTypes.Add(componentType, editorType);
            }

            // Add inherited types after so that any custom inspectors take priority
            foreach (var editorType in editorTypes)
            {
                var attribute = editorType.GetAttribute<ComponentEditorAttribute>();
                if (!attribute.EditorForChildClasses)
                    continue;

                var componentType = attribute.ComponentType;
                var assignableTypes = TypeCache.GetTypesDerivedFrom(componentType);
                foreach (var assignableType in assignableTypes)
                {
                    if (assignableType.IsAbstract)
                        continue;

                    if (!k_EditorTypes.ContainsKey(assignableType))
                        k_EditorTypes.Add(assignableType, editorType);
                }
            }
        }

        /// <summary>
        /// Creates a new instance to be used inside an existing <see cref="Editor"/>.
        /// </summary>
        /// <param name="editor">Parent editor of the object that contains the component list.</param>
        protected ComponentListEditor(Editor editor)
        {
            Assert.IsNotNull(editor);
            m_BaseEditor = editor;
        }

        /// <summary>
        /// Used to initialize the editor on <paramref name="serializedObject"/>, and set up editors for each component in <paramref name="components"/>.
        /// </summary>
        /// <param name="components"></param>
        /// <param name="serializedObject"></param>
        public void Init(IComponentList<TObject> components, SerializedObject serializedObject)
        {
            Assert.IsNotNull(components);
            Assert.IsNotNull(serializedObject);

            m_MarsInspectorSharedSettings = MarsInspectorSharedSettings.Instance;
            m_ComponentList = components;
            m_SerializedObject = serializedObject;
            m_ComponentProperty = serializedObject.FindProperty("m_Components");
            Assert.IsNotNull(m_ComponentProperty);

            m_Editors = new List<ComponentInspector>();

            // Create editors for existing settings
            for (var i = 0; i < m_ComponentList.components.Count; i++)
                CreateEditor(m_ComponentList.components[i], m_ComponentProperty.GetArrayElementAtIndex(i));

            // Keep track of undo/redo to redraw the inspector when that happens
            Undo.undoRedoPerformed += OnUndoRedoPerformed;
        }

        void ComponentFilterContextMenu()
        {
            var menu = new GenericMenu();
            for (var i = 1; i < k_ProxyComponentsStrings.Length; i++)
            {
                var filterIndex = i;
                var content = EditorGUIUtils.GetContent(k_ProxyComponentsStrings[filterIndex]);
                menu.AddItem(content, false, () =>
                {
                    m_MarsInspectorSharedSettings.ComponentTabSelection = filterIndex;
                });
            }

            menu.ShowAsContext();
        }

        /// <summary>
        /// Draws the component editors in an inspector.
        /// </summary>
        public void OnGUI()
        {
            if (m_ComponentList == null)
                return;

            if (m_ComponentList.isDirty)
            {
                RefreshEditors();
                m_ComponentList.isDirty = false;
            }

            var isEditable = !UnityEditor.VersionControl.Provider.isActive
                || AssetDatabase.IsOpenForEdit(m_ComponentList.self, StatusQueryOptions.UseCachedIfPossible);

            if (!targetRequiresProxyMenu)
            {
                m_MarsInspectorSharedSettings.ComponentTabSelection = 0;
            }

            using (new EditorGUI.DisabledScope(!isEditable))
            {
                EditorGUILayout.LabelField(EditorGUIUtils.GetContent("Components"), EditorStyles.boldLabel);

                var availableWidth = EditorGUIUtility.currentViewWidth;
                var isWideEnoughForAllTabs = availableWidth > k_MinWidthForAllTabs;
                if (isWideEnoughForAllTabs && targetRequiresProxyMenu)
                {
                    m_MarsInspectorSharedSettings.ComponentTabSelection
                        = GUILayout.Toolbar(m_MarsInspectorSharedSettings.ComponentTabSelection, k_ProxyComponentsStrings);
                }
                else if (targetRequiresProxyMenu)
                {
                    var tabIndex = m_MarsInspectorSharedSettings.ComponentTabSelection;
                    var shortIndex = (tabIndex == 0) ? 0 : 1;
                    k_ProxyFilterStrings[1] = ((tabIndex == 0) ? k_ProxyFilter : k_ProxyComponentsStrings[tabIndex]) + k_DownArrowPostFix;
                    using (var check = new EditorGUI.ChangeCheckScope())
                    {
                        var selectedShortIndex = GUILayout.Toolbar(shortIndex, k_ProxyFilterStrings);
                        if (shortIndex != selectedShortIndex)
                        {
                            if (selectedShortIndex == 0)
                                m_MarsInspectorSharedSettings.ComponentTabSelection = 0;
                            else
                                ComponentFilterContextMenu();
                        }
                        else if (check.changed)
                        {
                            ComponentFilterContextMenu();
                        }
                    }
                }

                if (targetRequiresProxyMenu && (MarsInspectorSharedSettings.Instance.ComponentTabSelection == k_ForcesTab))
                {
                    Forces.EditorExtensions.ForcesMenuItemsRegions.DrawForcesInInspectorForMainProxy(m_BaseEditor.target);
                }

                // Override list
                for (var i = 0; i < m_Editors.Count; i++)
                {
                    var editor = m_Editors[i];

                    if (editor.activeProperty.serializedObject.targetObject == null)
                        continue;

                    if (CanDrawSelectedOption(editor.target))
                    {
                        var title = string.Format("{0}|{1}", editor.GetDisplayTitle(), editor.GetToolTip());
                        var id = i; // Needed for closure capture below

                        EditorGUILayout.Space(-2f);
                        EditorGUIUtils.DrawSplitter();
                        
                        var displayContent = EditorGUIUtils.DrawHeader(
                            title,
                            editor.baseProperty,
                            editor.activeProperty,
                            () => ResetComponent(editor.target.GetType(), id),
                            () => RemoveComponent(id),
                            () => CopyComponent(id),
                            () => PasteComponent(id),
                            CanPasteComponent(id),
                            editor.HasDisplayProperties(),
                            () => LoadComponentInspectorURL(editor.target) 
                        );

                        if (displayContent)
                        {
                            if (beforeDrawComponentInspector != null)
                                beforeDrawComponentInspector(editor);

                            using (new EditorGUI.DisabledScope(!editor.activeProperty.boolValue))
                            {
                                editor.OnInternalInspectorGUI();
                            }

                            if (afterDrawComponentInspector != null)
                                afterDrawComponentInspector(editor);
                        }
                    }
                }

                if (targetRequiresProxyMenu || (m_BaseEditor.target is ProxyGroup))
                {
                    if (m_Editors.Count > 0)
                    {
                        EditorGUIUtils.DrawSplitter();
                        EditorGUILayout.Space();
                    }
                    AddComponentMenuButton();
                    EditorGUILayout.Space();
                }
            }
        }

        void LoadComponentInspectorURL(UnityEngine.Object target)
        {
            var helpURL = Help.GetHelpURLForObject(target);
            
            // Turns out every Unity Editor 'target' has docs help, so instead we check if it point us to the manual; if it does, then we don't have docs for it
            var hasDocs = !helpURL.StartsWith(DocumentationConstants.OfficialUnityManual);
            if(hasDocs)
                Help.ShowHelpForObject(target);
            else
                Help.BrowseURL(DocumentationConstants.MarsAPI);
        }

        /// <summary>
        /// Reports if the target type can be drawn
        /// </summary>
        /// <param name="targetToDraw">Target object to draw</param>
        /// <param name="typeToDraw">Target type to draw</param>
        /// <param name="filteringMenu">Filter the option in the settings tab</param>
        /// <returns><c>true</c> if should be drawn</returns>
        protected static bool CanDrawSelectedOption(Object targetToDraw, Type typeToDraw = null, bool filteringMenu = false)
        {
            if (typeToDraw == null)
            {
                typeToDraw = targetToDraw.GetType();
            }

            switch (MarsInspectorSharedSettings.Instance.ComponentTabSelection)
            {
                case k_AllTabs:
                    return true;
                case k_ConditionsTab:
                    return typeof(ConditionBase).IsAssignableFrom(typeToDraw) &&
                           !typeof(ProxyForces).IsAssignableFrom(typeToDraw);
                case k_ActionsTab:
                    return typeof(IAction).IsAssignableFrom(typeToDraw);
                case k_ForcesTab:
                    return typeof(IProxyAlignmentForceSource).IsAssignableFrom(typeToDraw) ||
                           typeof(IProxyRegionForceSource).IsAssignableFrom(typeToDraw) ||
                           typeof(ProxyForces).IsAssignableFrom(typeToDraw);
                case k_SettingsTab:
                    // The Settings tab filter should show only the MARSEntity component, but using the 'Add MARS Component'
                    // button from that tab should allow any type to be added, since there are no settings-only components to add.
                    return filteringMenu || typeof(MARSEntity).IsAssignableFrom(typeToDraw);
            }

            return false;
        }

        /// <summary>
        /// Switches the component tab to that of the given type
        /// </summary>
        /// <param name="type">Type of component</param>
        protected void SetComponentTabAccordingToAddedType(Type type)
        {
            if (MarsInspectorSharedSettings.Instance.ComponentTabSelection == k_AllTabs)
                return;

            if (typeof(ConditionBase).IsAssignableFrom(type))
            {
                MarsInspectorSharedSettings.Instance.ComponentTabSelection = k_ConditionsTab;
                return;
            }

            if (typeof(IAction).IsAssignableFrom(type))
            {
                MarsInspectorSharedSettings.Instance.ComponentTabSelection = k_ActionsTab;
                return;
            }

            if (typeof(Proxy).IsAssignableFrom(type))
            {
                MarsInspectorSharedSettings.Instance.ComponentTabSelection = k_SettingsTab;
                return;
            }

            MarsInspectorSharedSettings.Instance.ComponentTabSelection = k_AllTabs;
        }

        /// <summary>
        /// Draws the component editors scene gui.
        /// </summary>
        public virtual void OnSceneGUI()
        {
            if (m_ComponentList == null)
                return;

            var isEditable = !UnityEditor.VersionControl.Provider.isActive
                || AssetDatabase.IsOpenForEdit(m_ComponentList.self, StatusQueryOptions.UseCachedIfPossible);

            if (isEditable)
            {
                for (var i = 0; i < m_Editors.Count; i++)
                {
                    var editor = m_Editors[i];

                    if (editor.activeProperty.boolValue)
                        editor.OnSceneGUI();
                }

            }
        }

        /// <summary>
        /// Disables the component editors and clears them from the list editor
        /// </summary>
        public virtual void Clear()
        {
            if (m_Editors == null)
                return; // Hasn't been initialized yet

            foreach (var editor in m_Editors)
                editor.OnDisable();

            m_Editors.Clear();

            // ReSharper disable once DelegateSubtraction
            Undo.undoRedoPerformed -= OnUndoRedoPerformed;
        }

        /// <summary>
        /// Creates a new editor for a component and stores it in the m_Editors list.
        /// </summary>
        /// <param name="component">Component that the new editor is inspecting.</param>
        /// <param name="property">Serialized Property representing the Component being inspected.</param>
        /// <param name="forceExpanded">Force the base property to be expanded in the inspector.</param>
        /// <param name="index">Index in m_Editors where this new editor is stored. Values less than 0 add a new editor
        /// to m_Editors.</param>
        protected virtual void CreateEditor(Object component, SerializedProperty property, bool forceExpanded = false, int index = -1)
        {
            var settingsType = component.GetType();
            ComponentInspector editor;

            if (!k_EditorTypes.TryGetValue(settingsType, out var editorType))
            {
                editor = Activator.CreateInstance<ComponentInspector>();
            }
            else
            {
                editor = (ComponentInspector)Activator.CreateInstance(editorType);
            }

            editor.Init(component, m_BaseEditor);
            editor.baseProperty = property.Copy();

            if (forceExpanded)
                editor.baseProperty.isExpanded = true;

            if (index < 0)
                m_Editors.Add(editor);
            else
                m_Editors[index] = editor;
        }

        /// <summary>
        /// Draws the Menu Button for adding a component to the component list.
        /// </summary>
        protected abstract void AddComponentMenuButton();

        /// <summary>
        /// Adds a component to the settings list from the inspector
        /// </summary>
        /// <param name="type">Type of component to add.</param>
        protected abstract void AddComponent(Type type);

        /// <summary>
        /// Removes a component from the settings list and tells the inspector to clean up the component editor.
        /// </summary>
        /// <param name="id">Index of the component in the setting list.</param>
        protected abstract void RemoveComponent(int id);

        /// <summary>
        /// Resets a component with the components default values.
        /// </summary>
        /// <param name="type">Type of component being reset.</param>
        /// <param name="id">Index of the component in the setting list.</param>
        protected abstract void ResetComponent(Type type, int id);

        /// <summary>
        /// Creates a new component and returns the new object.
        /// </summary>
        /// <param name="type">Type of object to create.</param>
        /// <returns>Returns the newly create object.</returns>
        protected abstract TObject CreateNewComponent(Type type);

        /// <summary>
        /// Copies the components values so they can be pasted on another component of that type.
        /// </summary>
        /// <param name="id">Index of the component in the setting list.</param>
        protected abstract void CopyComponent(int id);

        /// <summary>
        /// Pastes the values of a component over another component.
        /// </summary>
        /// <param name="id">Index of the component in the setting list.</param>
        protected abstract void PasteComponent(int id);

        /// <summary>
        /// Can the copied component be pasted to the component at the `id` index.
        /// </summary>
        /// <param name="id">Index of the component in the setting list.</param>
        /// <returns>True if the contents of the copy can be pasted on this component.</returns>
        protected abstract bool CanPasteComponent(int id);

        /// <summary>
        /// Operations to perform on the editor to keep the values in sync when an undo/redo is performed.
        /// </summary>
        protected virtual void OnUndoRedoPerformed()
        {
            m_ComponentList.isDirty = true;

            // Catch for if you have an inspector open when you start running tests,
            // and for if you undo adding a component that creates a ComponentListEditor.
            if (m_SerializedObject == null || m_SerializedObject.targetObject == null)
                return;

            // Dumb hack to make sure the serialized object is up to date on undo (else there will be
            // a state mismatch when this class is used in a GameObject inspector).
            m_SerializedObject.Update();
            m_SerializedObject.ApplyModifiedProperties();

            foreach (var editor in m_Editors)
            {
                editor.isDirty = true;
            }

            // Seems like there's an issue with the inspector not repainting after some undo events
            // This will take care of that
            m_BaseEditor.Repaint();
        }

        /// <summary>
        /// Removes the components waiting to be removed in the remove list.
        /// </summary>
        /// <param name="withUndo">Is the remove undoable</param>
        protected void RemoveComponents(bool withUndo = true)
        {
            if (m_RemoveList.Count == 0)
                return;
            for (var i = m_RemoveList.Count - 1; i >= 0; i--)
            {
                var id = m_RemoveList[i];
                var skipEditor = id >= m_Editors.Count;

                // Hack to keep foldout state on the next element...
                var nextFoldoutState = false;
                if (!skipEditor)
                {
                    if (id < m_Editors.Count - 1)
                        nextFoldoutState = m_Editors[id + 1].baseProperty.isExpanded;

                    if (m_Editors[id] != null)
                        m_Editors[id].OnDisable();
                    m_Editors.RemoveAt(id);
                }

                m_SerializedObject.Update();

                var property = m_ComponentProperty.GetArrayElementAtIndex(id);
                var component = property.objectReferenceValue;

                // Un-assign it (should be null already but serialization does funky things
                property.objectReferenceValue = null;

                // ...and remove the array index itself from the list
                m_ComponentProperty.DeleteArrayElementAtIndex(id);

                // Finally refresh editor reference to the serialized settings list
                for (var j = 0; j < m_Editors.Count; j++)
                {
                    m_Editors[j].baseProperty = m_ComponentProperty.GetArrayElementAtIndex(j).Copy();
                    m_Editors[j].isDirty = true;
                }

                if (!skipEditor)
                {
                    if (id < m_Editors.Count)
                        m_Editors[id].baseProperty.isExpanded = nextFoldoutState;
                }

                m_SerializedObject.ApplyModifiedProperties();

                // Destroy the setting object after ApplyModifiedProperties(). If we do it before, redo
                // actions will be in the wrong order and the reference to the setting object in the
                // list will be lost.
                if (component != null)
                {
                    if (withUndo)
                        Undo.DestroyObjectImmediate(component);
                    else
                        UnityObjectUtils.Destroy(component);
                }
            }

            m_RemoveList.Clear();
        }

        /// <summary>
        /// Clears & recreate all editors - used when the components have been modified outside of
        /// the editor (user scripts, inspector reset etc).
        /// </summary>
        void RefreshEditors()
        {
            RemoveComponents();

            // Disable all editors first
            foreach (var editor in m_Editors)
                editor.OnDisable();

            // Remove them
            m_Editors.Clear();

            // Recreate editors for existing settings, if any
            for (var i = 0; i < m_ComponentList.components.Count; i++)
            {
                if (m_ComponentList.components[i] == null || m_ComponentProperty.GetArrayElementAtIndex(i) == null)
                {
                    m_RemoveList.Add(i);
                    continue;
                }
                CreateEditor(m_ComponentList.components[i], m_ComponentProperty.GetArrayElementAtIndex(i));
            }
        }
    }
}
