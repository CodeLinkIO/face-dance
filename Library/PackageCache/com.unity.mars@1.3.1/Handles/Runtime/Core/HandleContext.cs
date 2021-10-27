using System;
using System.Collections.Generic;
using Unity.MARS.MARSHandles.Picking;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Unity.MARS.MARSHandles
{
    abstract partial class HandleContext : IHandleContext, IDisposable
    {
        static readonly List<HandleContext> s_Contexts = new List<HandleContext>();
        static readonly List<Renderer> s_RendererBuffer = new List<Renderer>();
        static readonly List<HandleBehaviour> s_BehaviourQueryBuffer = new List<HandleBehaviour>();

        readonly List<GameObject> m_RawHandles = new List<GameObject>();
        readonly List<InteractiveHandle> m_InteractiveHandles = new List<InteractiveHandle>();
        readonly List<HandleBehaviour> m_HandleBehaviours = new List<HandleBehaviour>();

        Camera m_Camera;

        public Camera camera
        {
            get { return m_Camera; }
            set { m_Camera = value; }
        }

        protected IReadOnlyList<GameObject> handles
        {
            get { return m_RawHandles; }
        }

        protected HandleContext() : this(null) {}

        protected HandleContext(Camera camera)
        {
            m_Camera = camera;
            s_Contexts.Add(this);
        }

        public virtual void Dispose()
        {
            s_Contexts.Remove(this);
        }

        public static HandleContext GetContext(GameObject handle)
        {
            foreach (var context in s_Contexts)
            {
                if (context != null
                    && context.m_RawHandles.Contains(handle.transform.root.gameObject))
                    return context;
            }

            return null;
        }

        public GameObject CreateHandle(DefaultHandle handle)
        {
            return CreateHandle(DefaultHandles.GetPrefab(handle));
        }

        public virtual GameObject CreateHandle(GameObject prefab)
        {
            if (prefab == null)
                throw new ArgumentNullException(nameof(prefab));

            var obj = Object.Instantiate(prefab);
            m_RawHandles.Add(obj);
            SetupObject(obj.transform);
            return obj;
        }

        public virtual bool DestroyHandle(GameObject handle)
        {
            if (handle == null)
                throw new ArgumentNullException(nameof(handle));

            if (m_RawHandles.Remove(handle))
            {
                Object.DestroyImmediate(handle);
                return true;
            }

            return false;
        }

        protected void SendPreRender(Camera camera)
        {
            foreach (var behaviour in m_HandleBehaviours)
            {
                behaviour.DoPreRender(camera);
            }
        }

        protected void SendPostRender(Camera camera)
        {
            foreach (var behaviour in m_HandleBehaviours)
            {
                behaviour.DoPostRender(camera);
            }
        }

        internal List<HandleBehaviour> GetHandleBehaviours()
        {
            return m_HandleBehaviours;
        }

        internal void RegisterHandleBehaviour(HandleBehaviour behaviour)
        {
            m_HandleBehaviours.Add(behaviour);

            var interactiveHandle = behaviour as InteractiveHandle;
            if (interactiveHandle != null)
                m_InteractiveHandles.Add(interactiveHandle);
        }

        internal void UnregisterHandleBehaviour(HandleBehaviour behaviour)
        {
            m_HandleBehaviours.Remove(behaviour);

            var interactiveHandle = behaviour as InteractiveHandle;
            if (interactiveHandle != null)
                m_InteractiveHandles.Remove(interactiveHandle);
        }

        protected InteractiveHandle GetHandle(IPickingTarget pickingTarget)
        {
            MonoBehaviour behaviour = pickingTarget as MonoBehaviour;
            if (behaviour == null)
                return null;

            return behaviour.GetComponentInParent<InteractiveHandle>();
        }

        void SetupObject(Transform transform)
        {
            var go = transform.gameObject;

            InstantiateMaterials(go);
            SetContextOnBehaviours(go);

            for (int i = 0, count = transform.childCount; i < count; ++i)
            {
                SetupObject(transform.GetChild(i));
            }
        }

        void InstantiateMaterials(GameObject go)
        {
            go.GetComponents(s_RendererBuffer);
            foreach (var renderer in s_RendererBuffer)
            {
                var materials = renderer.sharedMaterials;
                for (int i = 0, count = materials.Length; i < count; ++i)
                {
                    var material = materials[i];
                    if (material == null)
                        continue;

                    materials[i] = new Material(material) { hideFlags = HideFlags.HideAndDontSave };
                }

                renderer.sharedMaterials = materials;
            }
        }

        void SetContextOnBehaviours(GameObject gameObject)
        {
            gameObject.GetComponents(s_BehaviourQueryBuffer);
            foreach (var behaviour in s_BehaviourQueryBuffer)
            {
                behaviour.context = this;
            }
        }
    }
}
