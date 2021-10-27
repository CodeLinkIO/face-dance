using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    sealed class ComponentCache
    {
        interface IComponentCollection
        {
            void Recreate(GameObject root);
        }

        class ComponentCollection<T> : IComponentCollection  where T : class
        {
            T[] m_Components;

            public IReadOnlyList<T> Get()
            {
                return m_Components;
            }

            public ComponentCollection(GameObject root)
            {
                Recreate(root);
            }

            public void Recreate(GameObject root)
            {
                //Note: As of the time of writing this, the template version of GetComponentsInChildren doesn't seem to work with interfaces
                if (typeof(T).IsInterface)
                {
                    var rawComponents = root.GetComponentsInChildren(typeof(T), true);
                    m_Components = new T[rawComponents.Length];
                    for (var i = 0; i < rawComponents.Length; i++)
                    {
                        m_Components[i] = rawComponents[i] as T;
                    }
                }
                else
                {
                    m_Components = root.GetComponentsInChildren<T>(true);
                }
            }
        }

        readonly Dictionary<Type, IComponentCollection> m_Collections = new Dictionary<Type, IComponentCollection>();
        readonly GameObject m_Root;

        public ComponentCache(GameObject root)
        {
            m_Root = root;
        }

        public void CacheComponents<T>() where T : class
        {
            IComponentCollection rawCollection;
            if (m_Collections.TryGetValue(typeof(T), out rawCollection))
            {
                rawCollection.Recreate(m_Root);
            }
            else
            {
                AddNewCache<T>();
            }
        }

        public IReadOnlyList<T> GetCache<T>() where T : class
        {
            IComponentCollection rawCollection;
            if (!m_Collections.TryGetValue(typeof(T), out rawCollection))
            {
                rawCollection = AddNewCache<T>();
            }

            return ((ComponentCollection<T>)rawCollection).Get();
        }

        ComponentCollection<T> AddNewCache<T>() where T : class
        {
            var collection = new ComponentCollection<T>(m_Root);
            m_Collections.Add(typeof(T), collection);
            return collection;
        }
    }
}