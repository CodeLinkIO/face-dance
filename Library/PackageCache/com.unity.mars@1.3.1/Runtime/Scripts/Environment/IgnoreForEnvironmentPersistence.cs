using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Changes to this game object will be ignored when checking for modifications to the simulation environment.
    /// This can be used for animated or otherwise changing
    /// objects in a simulation environment, eg. a moving fan or a dog walking around the environment.
    /// </summary>
    [HelpURL(DocumentationConstants.IgnoreForEnvironmentPersistenceDocs)]
    [ExecuteInEditMode]
    class IgnoreForEnvironmentPersistence : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("If enabled, all children of this GameObject will be ignored when checking for changes to the simulation environment.")]
        bool m_IgnoreChildrenAlso = false;

        internal void SetDontSaveFlags()
        {
            gameObject.hideFlags = HideFlags.DontSave;

            if (m_IgnoreChildrenAlso)
            {
                var childrenTransforms = gameObject.GetComponentsInChildren<Transform>();
                foreach (var child in childrenTransforms)
                {
                    child.gameObject.hideFlags = HideFlags.DontSave;
                }
            }
        }

        internal void RestoreHideFlags()
        {
            gameObject.hideFlags = HideFlags.None;

            if (m_IgnoreChildrenAlso)
            {
                var childrenTransforms = gameObject.GetComponentsInChildren<Transform>();
                foreach (var child in childrenTransforms)
                {
                    child.gameObject.hideFlags = HideFlags.None;
                }
            }
        }
    }
}
