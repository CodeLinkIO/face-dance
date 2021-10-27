using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS.Attributes;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using Object = UnityEngine.Object;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Component List that can store the MonoBehaviours of an object.
    /// </summary>
    [Serializable]
    [MovedFrom(true, "Unity.MARS", "Unity.MARS")]
    internal class MonoBehaviourComponentList : ScriptableObject, IComponentList<MonoBehaviour>
    {
        [SerializeField]
        [Tooltip("A list of all components.")]
        List<MonoBehaviour> m_Components = new List<MonoBehaviour>();
        public List<MonoBehaviour> components { get { return m_Components; } }

        public bool isDirty { get; set; }
        public Object self { get { return this; } }

        public bool HasComponents(Type type)
        {
            foreach (var component in components)
            {
                if (component.GetType() == type)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Rebuilds the list of attached MonoBehaviours.
        /// </summary>
        /// <param name="go">The GameObject the MonoBehaviours are attached too.</param>
        public void ResetComponentsList<TComponentMenuAttribute>(GameObject go) where TComponentMenuAttribute : ComponentMenuAttribute
        {
            m_Components = go.GetComponents<MonoBehaviour>()
                .Where(w => w.GetType().IsDefined(typeof(TComponentMenuAttribute), false)).ToList();
        }

    }
}
