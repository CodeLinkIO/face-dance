using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Landmarks
{
    [MovedFrom("Unity.MARS")]
    public class FallbackFace : MonoBehaviour
    {
        [SerializeField]
        List<Transform> m_LandmarkTransforms = new List<Transform>();

        internal List<Transform> landmarkTransforms { get { return m_LandmarkTransforms; } }

        void Reset()
        {
            m_LandmarkTransforms.Clear();
            foreach (var landmark in EnumValues<MRFaceLandmark>.Values)
            {
                var landmarkName = landmark.ToString();
                var landmarkTrans = transform.Find(landmarkName);
                m_LandmarkTransforms.Add(landmarkTrans);
            }
        }
    }
}
