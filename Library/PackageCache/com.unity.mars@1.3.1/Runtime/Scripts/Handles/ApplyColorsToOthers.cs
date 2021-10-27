using System.Collections.Generic;
using UnityEngine;
using Unity.MARS.MARSHandles;

namespace Unity.MARS
{
    [RequireComponent(typeof(Renderer))]
    [RequireComponent(typeof(InteractiveHandle))]
    [AddComponentMenu("")]
    [ExecuteInEditMode]
    class ApplyColorsToOthers : HandleBehaviour
    {
        Renderer m_ThisRenderer;

        [SerializeField]
        List<Renderer> m_Renderers = new List<Renderer>();

        InteractiveHandle m_Handle;

        void Awake()
        {
            m_ThisRenderer = GetComponent<Renderer>();
            m_Handle = GetComponent<InteractiveHandle>();
        }

        void SyncColor()
        {
            if (m_ThisRenderer == null)
                return;

            foreach (var r in m_Renderers)
            {
                if (r != null)
                    r.sharedMaterial.color = m_ThisRenderer.sharedMaterial.color;
            }
        }

        protected override void DragBegin(InteractiveHandle target, DragBeginInfo info)
        {
            if (target != m_Handle)
                return;

            SyncColor();
        }

        protected override void DragEnd(InteractiveHandle target, DragEndInfo info)
        {
            if (target != m_Handle)
                return;

            SyncColor();
        }

        protected override void HoverBegin(InteractiveHandle target, HoverBeginInfo info)
        {
            if (target != m_Handle)
                return;

            SyncColor();
        }

        protected override void HoverEnd(InteractiveHandle target, HoverEndInfo info)
        {
            if (target != m_Handle)
                return;

            SyncColor();
        }
    }
}
