using UnityEngine;
using Unity.MARS.MARSHandles;

namespace Unity.MARS
{
    [ExecuteInEditMode]
    [AddComponentMenu("")]
    [RequireComponent(typeof(LineRenderer))]
    sealed class ScaleLineWidthWithCameraDistance : HandleBehaviour
    {
        LineRenderer m_LineRenderer;

        protected override void PreRender(Camera camera)
        {
            base.PreRender(camera);
            if (m_LineRenderer == null)
                m_LineRenderer = GetComponent<LineRenderer>();

            var vertexCount = m_LineRenderer.positionCount;
            if (vertexCount < 2)
                return;

            // Set points along the width curve using the distance of each vertex. This causes the line to be a constant width on screen.
            var curve = m_LineRenderer.widthCurve;
            for (var i = 0; i <= vertexCount; i++)
            {
                var v = transform.TransformPoint(m_LineRenderer.GetPosition(i % vertexCount));
                var pointScale = HandleUtility.GetHandleSize(v);
                var key = new Keyframe((float)i / vertexCount, pointScale);
                if (curve.keys.Length <= i)
                    curve.AddKey(key);
                else
                    curve.MoveKey(i, key);
            }

            m_LineRenderer.widthCurve = curve;
        }
    }
}
