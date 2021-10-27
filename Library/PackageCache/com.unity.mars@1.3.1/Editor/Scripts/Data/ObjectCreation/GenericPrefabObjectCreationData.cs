using Unity.MARS;
using Unity.MARS.Authoring;
using UnityEngine;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Used to create a game object from a prefab in the editor and with a button
    /// </summary>
    public class GenericPrefabObjectCreationData : ObjectCreationData
    {
#pragma warning disable 649
        [SerializeField]
        [Tooltip("Prefab to instantiate")]
        GameObject m_Prefab;
#pragma warning restore 649

        /// <summary>
        /// Create a game object from the prefab creation data
        /// </summary>
        /// <param name="createdObj">Prefab to instantiate.</param>
        /// <param name="parentTransform">Parent transform of the newly created prefab.</param>
        /// <returns><c>true</c> If the prefab was created.</returns>
        public override bool CreateGameObject(out GameObject createdObj, Transform parentTransform)
        {
            if (m_Prefab == null)
            {
                createdObj  = null;
                return false;
            }

            MARSSession.EnsureRuntimeState();

            var objName = GameObjectUtility.GetUniqueNameForSibling(null, m_ObjectName);
            createdObj = Instantiate(m_Prefab);
            MarsWorldScaleModule.ScaleChildren(createdObj.transform);

            foreach (var colorComponent in createdObj.GetComponentsInChildren<IHasEditorColor>())
            {
                colorComponent.SetNewColor(true, true);
            }

            createdObj.name = objName;
            Undo.RegisterCreatedObjectUndo(createdObj, $"Create {objName}");
            Selection.activeGameObject = createdObj;
            return true;
        }
    }
}
