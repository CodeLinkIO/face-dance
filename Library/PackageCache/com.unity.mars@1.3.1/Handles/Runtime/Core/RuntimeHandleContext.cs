using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    abstract class RuntimeHandleContext : HandleContext
    {
        protected RuntimeHandleContext() : this(null)
        {
        }

        protected RuntimeHandleContext(Camera camera) : base(camera)
        {
            Camera.onPreRender += OnPreRender;
            Camera.onPostRender += OnPostRender;
        }

        public sealed override void Dispose()
        {
            base.Dispose();
            Camera.onPreRender -= OnPreRender;
            Camera.onPostRender -= OnPostRender;
        }

        public sealed override GameObject CreateHandle(GameObject prefab)
        {
            return base.CreateHandle(prefab);
        }

        public sealed override bool DestroyHandle(GameObject handle)
        {
            return base.DestroyHandle(handle);
        }

        void OnPreRender(Camera cam)
        {
            if (cam == camera)
                SendPreRender(cam);
        }

        void OnPostRender(Camera cam)
        {
            if (cam == camera)
                SendPostRender(cam);
        }
    }
}