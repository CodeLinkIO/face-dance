using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.MARS.Attributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Scripting.APIUpdating;
using Object = UnityEngine.Object;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Inspector for a single component inspector that can be drawn in a component list editor.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class ComponentInspector
    {
        /// <summary>
        /// The component being inspected.
        /// </summary>
        public Object target { get; protected set; }

        /// <summary>
        /// A SerializedObject representing the object or objects being inspected.
        /// </summary>
        public SerializedObject serializedObject { get; private set; }

        /// <summary>
        /// The serialized property that represents this component in the component list.
        /// </summary>
        public SerializedProperty baseProperty;

        /// <summary>
        /// The property that represents if the component is active.
        /// </summary>
        public SerializedProperty activeProperty;

        /// <summary>
        /// Has the serialization of the object changed in a way the inspector needs to be reconstructed.
        /// </summary>
        public bool isDirty;

        /// <summary>
        /// Parent unity editor of the object that contains the component list.
        /// </summary>
        Editor m_Inspector;

        /// <summary>
        /// Collection of all the serialized parameters on a component.
        /// </summary>
        List<SerializedPropertyData> m_Parameters;

        readonly Dictionary<FieldInfo, EventInspectorData> m_EventInspectorData
            = new Dictionary<FieldInfo, EventInspectorData>();

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<FieldInfo> k_Fields = new List<FieldInfo>();

        /// <summary>
        /// Calls repaint on the parent editor.
        /// </summary>
        public virtual void Repaint()
        {
            m_Inspector.Repaint();
        }

        /// <summary>
        /// Cleans up the component editor.
        /// </summary>
        protected virtual void CleanUp()
        {
            isDirty = false;
        }

        /// <summary>
        /// Parent unity editor of the object that contains the component list.
        /// </summary>
        public Editor EditorInspector => m_Inspector;

        /// <summary>
        /// Initializes the component editor. Called after creation.
        /// </summary>
        /// <param name="targetObject">The component being inspected.</param>
        /// <param name="inspector">Parent Unity editor of the object that contains the component list.</param>
        public virtual void Init(Object targetObject, Editor inspector)
        {
            target = targetObject;
            m_Inspector = inspector;
            serializedObject = new SerializedObject(targetObject);
            activeProperty = serializedObject.FindProperty("active");

            if (activeProperty == null)
                activeProperty = serializedObject.FindProperty("m_Enabled");

            OnEnable();
        }

        /// <summary>
        /// This method is called when the object is created. Called after Init.
        /// </summary>
        public virtual void OnEnable()
        {
            k_Fields.Clear();
            EventInspectorUtils.GetEvents(target.GetType(), k_Fields);
            foreach (var field in k_Fields)
            {
                m_EventInspectorData[field] = new EventInspectorData();
            }

            EventInspectorUtils.SyncEventDrawers(serializedObject, m_EventInspectorData);
            Undo.undoRedoPerformed += SyncEventDrawers;
            m_Parameters = new List<SerializedPropertyData>();
            GetParameters();
            isDirty = false;

            foreach (var parameter in m_Parameters)
            {
                if (typeof(UnityEventBase).IsAssignableFrom(parameter.Type))
                    parameter.AddAttribute(new HideInInspector());
            }
        }

        /// <summary>
        /// This method is called when the scriptable object goes out of scope.
        /// </summary>
        public virtual void OnDisable()
        {
            Undo.undoRedoPerformed -= SyncEventDrawers;
        }

        /// <summary>
        /// Handles the extra logic for drawing the inspector inside a component list editor.
        /// </summary>
        public virtual void OnInternalInspectorGUI()
        {
            serializedObject.Update();
            OnInspectorGUI();
            EditorGUILayout.Space();
            serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// This method is called to draw the inspector GUI
        /// </summary>
        public virtual void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if(m_EventInspectorData.Count > 0)
                EventInspectorUtils.OnEventDrawerGUI(serializedObject, m_EventInspectorData);
        }

        /// <summary>
        /// Draws the parameters with the default parameter property drawer in the inspector.
        /// </summary>
        public void DrawDefaultInspector()
        {
            if (isDirty)
                CleanUp();

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                foreach (var parameter in m_Parameters)
                    EditorGUIUtils.PropertyField(parameter, false, false);

                if (check.changed)
                {
                    serializedObject.ApplyModifiedProperties();
                    isDirty = true;
                }
            }
        }

        /// <summary>
        /// This method is called when drawing in the scene view.
        /// </summary>
        public virtual void OnSceneGUI() { }

        /// <summary>
        /// Gets the serialized parameters of the component.
        /// </summary>
        /// <param name="inChildren">Get the child properties of a property.</param>
        public void GetParameters(bool inChildren = true)
        {
            var type = target.GetType();
            while (type != null)
            {
                var fields = type
                    .GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(t => t.Name != "enabled")
                    .Where(t =>
                        (t.IsPublic && t.GetCustomAttributes(typeof(NonSerializedAttribute), false).Length == 0)
                        || (t.GetCustomAttributes(typeof(SerializeField), false).Length > 0)
                    )
                    .ToList();

                foreach (var field in fields)
                {
                    var property = serializedObject.FindProperty(field.Name);
                    // Serialized fields with unsupported types will not have SerializedProperties
                    if (property == null)
                        continue;

                    var attributes = field.GetCustomAttributes(false).Cast<Attribute>().ToArray();
                    var parameter = new SerializedPropertyData(property, field.FieldType, attributes);
                    m_Parameters.Add(parameter);
                }

                type = inChildren ? type.BaseType : null;
            }
        }

        /// <summary>
        /// Gets the displayable name for the title.
        /// </summary>
        /// <returns>The displayable name</returns>
        public virtual string GetDisplayTitle()
        {
            return ObjectNames.NicifyVariableName(target.GetType().Name);
        }

        /// <summary>
        /// Get the tooltip on the component from the <c>ComponentTooltipAttribute</c>
        /// </summary>
        /// <returns>Returns the tooltip on the component if there is one otherwise it returns an empty string.</returns>
        public virtual string GetToolTip()
        {
            var tooltip = target.GetType().GetCustomAttribute(typeof(ComponentTooltipAttribute)) as ComponentTooltipAttribute;
            return tooltip != null ? tooltip.tooltip : string.Empty;
        }

        /// <summary>
        /// Does the component have properties to display.
        /// </summary>
        /// <returns>True if has properties to display</returns>
        public virtual bool HasDisplayProperties()
        {
            if (m_Parameters == null)
            {
                Debug.LogErrorFormat("{0}: parameters not initialized -- component inspector OnEnable likely needs a base.Enable().", GetType().Name);
                return false;
            }

            return !(m_Parameters.Count == 0 && m_EventInspectorData.Count == 0);
        }

        void SyncEventDrawers()
        {
            EventInspectorUtils.SyncEventDrawers(serializedObject, m_EventInspectorData);
            Repaint();
        }

    }
}
