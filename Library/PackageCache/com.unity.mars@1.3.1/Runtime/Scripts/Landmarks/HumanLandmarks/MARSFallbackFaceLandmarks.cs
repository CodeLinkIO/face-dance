using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Landmarks
{
    /// <summary>
    /// Fallback data for unavailable face landmark poses
    /// This class should remain public in case face providers need access to it
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class MARSFallbackFaceLandmarks : ScriptableSettings<MARSFallbackFaceLandmarks>
    {
#pragma warning disable 649
        [SerializeField]
        FallbackFace m_FallbackFacePrefab;
#pragma warning restore 649

        List<Transform> m_PreviousLandmarkTransforms;
        Dictionary<MRFaceLandmark, Pose> m_FallbackFaceLandmarkPoses;

        public Dictionary<MRFaceLandmark, Pose> GetFallbackFaceLandmarkPoses()
        {
            var landmarkTransforms = m_FallbackFacePrefab.landmarkTransforms;
            if (m_FallbackFaceLandmarkPoses == null)
            {
                m_FallbackFaceLandmarkPoses = new Dictionary<MRFaceLandmark, Pose>(new MRFaceLandmarkComparer());
                for (var i = 0; i < landmarkTransforms.Count; ++i)
                {
                    var landmarkTransform = landmarkTransforms[i];
                    m_FallbackFaceLandmarkPoses[(MRFaceLandmark)i]
                        = new Pose(landmarkTransform.localPosition, landmarkTransform.rotation);
                }
            }

            if (m_PreviousLandmarkTransforms != null && m_PreviousLandmarkTransforms.Count != 0)
            {
                for (var i = 0; i < landmarkTransforms.Count; ++i)
                {
                    var landmarkTrans = landmarkTransforms[i];
                    if (landmarkTrans != m_PreviousLandmarkTransforms[i] || landmarkTrans.hasChanged)
                    {
                        m_FallbackFaceLandmarkPoses[(MRFaceLandmark)i]
                            = new Pose(landmarkTrans.localPosition, landmarkTrans.rotation);
                        landmarkTrans.hasChanged = false;
                    }
                }
            }

            m_PreviousLandmarkTransforms = landmarkTransforms;
            return m_FallbackFaceLandmarkPoses;
        }
    }
}
