using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    static class HandleUtility
    {
        /// <summary>
        /// The default material used when creating mesh handles.
        /// </summary>
        public static readonly Material defaultMaterial = new Material(Shader.Find("Hidden/MARS/Handles/UnlitColor"));

#if !UNITY_EDITOR
        const float k_DpiRatio = 1f / 96f; //96 is the default dpi on pc

        internal static float pixelsPerPoint => Screen.dpi * k_DpiRatio;
#else
        internal static float pixelsPerPoint => UnityEditor.EditorGUIUtility.pixelsPerPoint;
#endif

        const float k_HandleSize = 80.0f;

        public static float GetHandleSize(Vector3 position)
        {
            Camera cam = GetActiveCamera();
            if (cam)
            {
                Transform tr = cam.transform;
                Vector3 camPos = tr.position;
                float distance = Vector3.Dot(position - camPos, tr.TransformDirection(new Vector3(0, 0, 1)));
                Vector3 screenPos = cam.WorldToScreenPoint(camPos + tr.TransformDirection(new Vector3(0, 0, distance)));
                Vector3 screenPos2 = cam.WorldToScreenPoint(camPos + tr.TransformDirection(new Vector3(1, 0, distance)));
                float screenDist = (screenPos - screenPos2).magnitude;
                var result = (k_HandleSize / Mathf.Max(screenDist, 0.0001f));
                result *= pixelsPerPoint;

                return result;
            }

            return 20.0f;
        }

        public static Vector3 GetHandleSizeVector(Vector3 position)
        {
            float size = GetHandleSize(position);
            return new Vector3(size, size, size);
        }

        static Camera GetActiveCamera()
        {
            var cam = Camera.current;
            if (cam != null)
                return cam;

            return Camera.main;
        }

        public static Vector3 ProjectScreenPositionOnHandle(InteractiveHandle handle, Vector2 screenPosition, Camera camera)
        {
            if (handle == null || camera == null)
                return Vector3.zero;

            var plane = handle.GetProjectionPlane(camera.transform.position);
            var ray = camera.ScreenPointToRay(screenPosition);

            float hitDistance;
            if (!plane.Raycast(ray, out hitDistance))
            {
                return handle.transform.position;
            }

            return ray.origin + ray.direction * hitDistance;
        }

        public static Vector3 ProjectWorldPositionOnHandle(InteractiveHandle handle, Vector3 position)
        {
            if (handle == null)
                return Vector3.zero;

            return handle.GetProjectionPlane(position).ClosestPointOnPlane(position);
        }
    }
}
