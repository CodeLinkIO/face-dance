using System;
using Unity.MARS.Authoring;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// (Obsolete) Used to create a game object in the editor and with a button
    /// </summary>
    [Serializable]
    [Obsolete("Unity.MARS.ObjectCreationButtonData has been deprecated. Use UnityEditor.MARS.ObjectCreationData instead (UnityUpgradable) -> UnityEditor.MARS.ObjectCreationData", false)]
    public abstract class ObjectCreationButtonData : ScriptableObject
    {
        /// <summary>
        /// (Obsolete) Scene context that the object creation takes place in
        /// </summary>
        public enum CreateInContext
        {
            /// <summary>
            /// (Obsolete) Creation takes place in the main editor scene
            /// </summary>
            Scene,
            /// <summary>
            /// (Obsolete) Creation takes place in the synthetic (environment) simulation scene
            /// </summary>
            SyntheticSimulation
        }

        /// <summary>
        /// Name of the object being created
        /// </summary>
        [SerializeField]
        [Tooltip("Name of the object being created")]
        protected string m_ButtonName = "Name not set";

        /// <summary>
        /// Icon used for the object creation button
        /// </summary>
        [SerializeField]
        [Tooltip("Icon used for the object creation button")]
        protected DarkLightIconPair m_Icon;

        /// <summary>
        /// Tooltip for the object creation button
        /// </summary>
        [SerializeField]
        [Tooltip("Tooltip for the object creation button")]
        protected string m_Tooltip;

        [SerializeField]
        [Tooltip("Scene context that the object will be created in")]
        CreateInContext m_CreateInContext = CreateInContext.Scene;

        /// <summary>
        /// Scene context that the object will be created in
        /// </summary>
        public CreateInContext CreateInContextSelection => m_CreateInContext;

        /// <summary>
        /// Name of the object being created
        /// </summary>
        [Obsolete("ButtonName has been deprecated. Use ObjectName property instead (UnityUpgradable) -> ObjectName", false)]
        public string ButtonName => m_ButtonName;

        /// <summary>
        /// Object creation button GUI content
        /// </summary>
        public GUIContent ObjectGUIContent { get; private set; }

        internal void UpdateObjectGUIContent()
        {
            ObjectGUIContent.image = m_Icon.Icon;
            ObjectGUIContent.text = m_ButtonName;
            ObjectGUIContent.tooltip = m_Tooltip;
        }

        /// <summary>
        /// Object creation button GUI content
        /// </summary>
        /// <returns>Button GUI content</returns>
        [Obsolete("CreationButtonContent() has been deprecated.", false)]
        public GUIContent CreationButtonContent() { return ObjectGUIContent; }

        /// <summary>
        /// Create a game object from the creation data
        /// </summary>
        /// <returns><c>true</c> if the object was created</returns>
        [Obsolete("CreateGameObject() has been deprecated, please use CreateGameObject(out GameObject  createdObject, Transform parentTransform) instead",false)]
        public abstract bool CreateGameObject();

        /// <summary>
        /// Create an empty game object with a unique name at the parent transform with world scale applied
        /// </summary>
        /// <param name="objName">Name of the object to apply unique version</param>
        /// <returns>Newly created game object</returns>
        [Obsolete("GenerateInitialGameObject(string objName) has been deprecated, please use GenerateInitialGameObject(string objName, Transform parent)", false)]
        protected static GameObject GenerateInitialGameObject(string objName)
        {
            var go = new GameObject(GameObjectUtility.GetUniqueNameForSibling(null, objName));
            MarsWorldScaleModule.ScaleChildren(go.transform);

            foreach (var colorComponent in go.GetComponentsInChildren<IHasEditorColor>())
            {
                colorComponent.SetNewColor(true, true);
            }

            return go;
        }
    }
}
