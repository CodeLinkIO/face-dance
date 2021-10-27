using System;
using Unity.MARS.Authoring;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Simulation;
using UnityEngine;
using UnityEngine.Serialization;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Used to create a game object in the editor and with a button
    /// </summary>
    [Serializable]
    public abstract partial class ObjectCreationData : ScriptableObject
    {
        /// <summary>
        /// Scene context that the object creation takes place in
        /// </summary>
        public enum CreateInContext
        {
            /// <summary>
            /// Creation takes place in the main editor scene
            /// </summary>
            Scene,
            /// <summary>
            /// Creation takes place in the synthetic (environment) simulation scene
            /// </summary>
            SyntheticSimulation
        }

        /// <summary>
        /// Name of the object being created
        /// </summary>
        [FormerlySerializedAs("m_ButtonName")]
        [SerializeField]
        [Tooltip("Name of the object being created")]
        protected string m_ObjectName = "Name not set";

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

        /// <summary>
        /// Scene context that the object will be created in
        /// </summary>
        [SerializeField]
        [Tooltip("Scene context that the object will be created in")]
        CreateInContext m_CreateInContext = CreateInContext.Scene;

        GUIContent m_ObjectGUIContent;

        /// <summary>
        /// Name of the object being created
        /// </summary>
        public string ObjectName => m_ObjectName;

        /// <summary>
        /// Scene context that the object will be created in
        /// </summary>
        public CreateInContext CreateInContextSelection => m_CreateInContext;

        /// <summary>
        /// Object creation button GUI content
        /// </summary>
        public GUIContent ObjectGUIContent
        {
            get
            {
                if(m_ObjectGUIContent == null)
                    UpdateObjectGUIContent();
                return m_ObjectGUIContent;
            }

            private set => m_ObjectGUIContent = value;
        }

        internal void UpdateObjectGUIContent()
        {
            if (m_ObjectGUIContent == null)
            {
                m_ObjectGUIContent = new GUIContent(m_ObjectName, m_Icon.Icon, m_Tooltip);
            }
            else
            {
                m_ObjectGUIContent.image = m_Icon.Icon;
                m_ObjectGUIContent.text = m_ObjectName;
                m_ObjectGUIContent.tooltip = m_Tooltip;
            }
        }

        /// <summary>
        /// Create a game object from the creation data
        /// </summary>
        /// <param name="createdObj">Newly created game object</param>
        /// <param name="parentTransform">Parent transform for the newly created game object</param>
        /// <returns><c>true</c> if the object was created</returns>
        public abstract bool CreateGameObject(out GameObject createdObj, Transform parentTransform);

        /// <summary>
        /// Create an empty game object with a unique name at the parent transform with world scale applied
        /// </summary>
        /// <param name="objName">Name of the object to apply unique version</param>
        /// <param name="parent">Parent transform for the newly created game object</param>
        /// <returns>Newly created game object</returns>
        protected GameObject GenerateInitialGameObject(string objName, Transform parent)
        {
            var go = new GameObject(GameObjectUtility.GetUniqueNameForSibling(parent, objName));
            MarsWorldScaleModule.ScaleChildren(go.transform);

            GameObjectUtility.SetParentAndAlign(go, parent != null ? parent.gameObject : null);

            foreach (var colorComponent in go.GetComponentsInChildren<IHasEditorColor>())
            {
                colorComponent.SetNewColor(true, true);
            }

            return go;
        }

        /// <summary>
        /// Get or create a new GameObject whose Transform be used as the parent for creating objects
        /// </summary>
        /// <param name="transformName">The name to search for, or to be used for the new GameObject</param>
        /// <returns>The new or existing Transform</returns>
        protected static Transform GetOrGenerateUniqueParent(string transformName)
        {
            var environmentManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
            var syntheticEnvironmentPrefabInstanceRoot = environmentManager.CurrentLoadedPrefabInstanceEnvironment;
            if (syntheticEnvironmentPrefabInstanceRoot == null)
                return null;

            var resultParent = syntheticEnvironmentPrefabInstanceRoot.transform.Find(transformName);
            if (resultParent == null)
            {
                resultParent = new GameObject(transformName).transform;

                Undo.RegisterCreatedObjectUndo(resultParent.gameObject, $"Create {resultParent.name}");

                resultParent.gameObject.layer = SimulationConstants.SimulatedEnvironmentLayerIndex;
            }

            resultParent.parent = syntheticEnvironmentPrefabInstanceRoot.transform;

            // Zero out the transform group in case the mars session is not zeroed out
            resultParent.localPosition = Vector3.zero;
            resultParent.localRotation = Quaternion.identity;
            resultParent.localScale = Vector3.one;

            return resultParent;
        }
    }
}
