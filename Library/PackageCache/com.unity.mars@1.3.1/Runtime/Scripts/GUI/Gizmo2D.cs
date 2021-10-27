using System;
using Unity.MARS.MARSUtils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    [ExecuteAlways]
    [RequireComponent(typeof(SpriteRenderer))]
    [MovedFrom("Unity.MARS")]
    public class Gizmo2D : MonoBehaviour
    {
        const float k_ScaleByDistance = 0.05f;

        SpriteRenderer m_SpriteRenderer;
        float m_SpriteAlpha;

        void OnEnable()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_SpriteAlpha = m_SpriteRenderer.color.a;
        }

        void OnWillRenderObject()
        {
            UpdateForCamera(Camera.current);
        }

        void UpdateForCamera(Camera viewCamera)
        {
            if (viewCamera == null)
                return;

#if UNITY_EDITOR
            var spriteColor = m_SpriteRenderer.color;

            if (EditorOnlyDelegates.IsGizmosCamera != null && EditorOnlyDelegates.IsGizmosCamera(viewCamera))
            {
                spriteColor.a = m_SpriteAlpha;
            }
            else
            {
                spriteColor.a = 0f;
            }

            m_SpriteRenderer.color = spriteColor;
#endif

            var cameraTransform = viewCamera.transform;
            var forward = cameraTransform.forward;
            transform.rotation = Quaternion.LookRotation(forward, cameraTransform.up);

            // Set world scale of transform based on view distance for constant screen-space size
            var delta = cameraTransform.position - transform.position;
            var distanceScale = delta.magnitude;
            var newScale = distanceScale * k_ScaleByDistance * Vector3.one;

            if (transform.parent != null)
            {
                var parentScale = transform.parent.localScale;
                var inverseParentScale = new Vector3(1.0f / parentScale.x, 1.0f / parentScale.y, 1.0f / parentScale.z);
                newScale.Scale(inverseParentScale);
            }

            transform.localScale = newScale;
        }
    }
}
