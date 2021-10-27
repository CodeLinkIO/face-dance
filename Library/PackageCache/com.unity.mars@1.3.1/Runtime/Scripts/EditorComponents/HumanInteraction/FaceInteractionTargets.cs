using System;
using Unity.MARS.Data;
using Unity.MARS.Landmarks;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// Connects a set of landmark interaction targets to the landmarks from a FaceLandmarkAction as well as a base head
    /// target to the root face tracking transform.
    /// </summary>
    [ExecuteInEditMode]
    [MovedFrom("Unity.MARS")]
    public class FaceInteractionTargets : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        GameObject m_FaceLandmarksVisualPrefab;

        [SerializeField]
        FaceLandmarksAction m_FaceLandmarksAction;

        [SerializeField]
        GameObject m_FaceBaseInteractionTarget;
#pragma warning restore 649

        GameObject m_FaceLandmarksVisual;

        public FaceLandmarksAction faceLandmarksAction
        {
            get { return m_FaceLandmarksAction; }
            set
            {
                m_FaceLandmarksAction = value;
                LinkToFace();
            }
        }

        void OnEnable()
        {
            var visual = GetComponent<EntityVisual>();
            if (visual != null && visual.entity != null)
            {
                faceLandmarksAction = visual.entity.GetComponent<FaceLandmarksAction>();

                if (m_FaceBaseInteractionTarget != null)
                    m_FaceBaseInteractionTarget.AddComponent<RedirectSelection>().target = visual.entity.gameObject;
            }
        }

        void LinkToFace()
        {
            if (m_FaceLandmarksAction == null || m_FaceLandmarksVisualPrefab == null)
                return;

            if (m_FaceLandmarksVisual != null)
                UnityObjectUtils.Destroy(m_FaceLandmarksVisual);

            m_FaceLandmarksVisual = Instantiate(m_FaceLandmarksVisualPrefab, transform);
            var landmarkTargets = m_FaceLandmarksVisual.GetComponentsInChildren<FaceLandmarkInteractionTarget>(true);
            var landmarks = m_FaceLandmarksAction.landmarks;

            foreach (var target in landmarkTargets)
            {
                var landmark = landmarks.Find(x =>
                {
                    if (x.landmarkDefinition == null)
                        return false;

                    MRFaceLandmark faceLandmark;
                    if (Enum.TryParse(x.landmarkDefinition.name, true, out faceLandmark))
                        return faceLandmark == target.landmark;
                    else
                        return false;
                });
                if (landmark != default(LandmarkController))
                {
                    var landmarkTransform = landmark.transform;

                    target.AttachTarget = landmarkTransform;
                    target.gameObject.AddComponent<RedirectSelection>().target = landmarkTransform.gameObject;
                    target.gameObject.SetActive(true);

                    var targetRenderer = target.gameObject.GetComponent<Renderer>();
                    if (targetRenderer != null)
                        targetRenderer.enabled = false;
                }
                else
                {
                    target.gameObject.SetActive(false);
                }
            }
        }
    }
}
