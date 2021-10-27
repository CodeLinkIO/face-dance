using System;
using UnityEngine;
using Object = System.Object;

namespace Unity.MARS.MARSHandles.Tests
{
    sealed class DummyHandleTemplate : IDisposable
    {
        public class Handle : InteractiveHandle
        {
            public override Plane GetProjectionPlane(Vector3 camPosition)
            {
                return default;
            }
        }

        public enum Template
        {
            BasicInteractiveHandle,
        }

        public readonly GameObject gameObject;
        readonly InteractiveHandle m_Template;

        public static implicit operator InteractiveHandle(DummyHandleTemplate dummy)
        {
            return dummy.m_Template;
        }

        public DummyHandleTemplate(Template template)
        {
            switch (template)
            {
                case Template.BasicInteractiveHandle:
                    m_Template = CreateBasicTemplate();
                    break;
            }

            gameObject = m_Template.gameObject;
        }

        public void Dispose()
        {
            UnityEngine.Object.DestroyImmediate(m_Template.gameObject);
        }

        static InteractiveHandle CreateBasicTemplate()
        {
            GameObject template = new GameObject("Template") {hideFlags = HideFlags.HideAndDontSave};
            template.AddComponent<MeshRenderer>().material = new Material(Shader.Find("Hidden/MARS/Handles/UnlitColor"));
            template.AddComponent<MeshFilter>().sharedMesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
            var handle = template.AddComponent<Handle>();
            return handle;
        }
    }
}
