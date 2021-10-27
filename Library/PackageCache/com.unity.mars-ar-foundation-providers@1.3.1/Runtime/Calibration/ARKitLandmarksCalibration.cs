using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Unity.MARS.Data.ARFoundation
{
    [MovedFrom("Unity.MARS.Providers")]
    public class ARKitLandmarksCalibration : MonoBehaviour
    {
        List<GameObject> m_LandmarkSpheres = new List<GameObject>();
        Dictionary<ARKitFaceMeshLandmark, int> m_LandmarkTriangleIndices = new Dictionary<ARKitFaceMeshLandmark, int>();

        void Awake()
        {
            Debug.Log("Calibrating ARKit face provider landmarks");
            foreach (Transform child in gameObject.transform)
            {
                m_LandmarkSpheres.Add(child.gameObject);
            }

            PickMeshIndices();

        }

        public void SaveLandmarks()
        {
#if UNITY_EDITOR
            var indices = ARKitLandmarkMeshIndices.instance;
            indices.hideFlags = HideFlags.NotEditable;
            EditorUtility.SetDirty(indices);
#endif
            Debug.Log("Saved settings for ARKit Facial Landmarks");
        }

        void PickMeshIndices()
        {
            for (var i = 0; i < m_LandmarkSpheres.Count; i++)
            {
                var point = m_LandmarkSpheres[i];
                var rayOrigin = point.transform.position + Vector3.forward;

                RaycastHit hit;
                if (Physics.Raycast(rayOrigin, Vector3.back, out hit))
                {
                    Debug.DrawLine(point.transform.position, hit.point, UnityEngine.Random.ColorHSV(), 300f);

                    m_LandmarkTriangleIndices.Add(
                        (ARKitFaceMeshLandmark)Enum.Parse(typeof(ARKitFaceMeshLandmark), point.name), hit.triangleIndex);

                    Debug.Log("Hit triangle index for " + point.name + " : " + hit.triangleIndex + " on " + hit.collider);
                }
                else
                {
                    Debug.LogWarning("No intersection found for landmark point " + point.name + ", please recalibrate");
                }
            }

            // only save to the settings if nothing seems wrong
            if (EnsureNoDuplicateIndices())
            {
                var count = m_LandmarkTriangleIndices.Count;
                var landmarkIndices = new int[count];
                for (var i = 0; i < count; i++)
                {
                    landmarkIndices[i] = m_LandmarkTriangleIndices[(ARKitFaceMeshLandmark)i];
                }

                ARKitLandmarkMeshIndices.instance.landmarkTriangleIndices = landmarkIndices;
            }
        }

        // make sure we don't pick the same triangles for different landmarks
        bool EnsureNoDuplicateIndices()
        {
            var count = m_LandmarkTriangleIndices.Count;
            for (var i = 0; i < count; i++)
            {
                var landmark = (ARKitFaceMeshLandmark)i;
                var triangleIndex = m_LandmarkTriangleIndices[landmark];
                foreach (var kvp in m_LandmarkTriangleIndices)
                {
                    if (kvp.Key != landmark && kvp.Value == triangleIndex)
                    {
                        Debug.LogWarning(string.Format("Landmarks {0} and {1} have the same triangle index.", landmark, kvp.Key));
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
