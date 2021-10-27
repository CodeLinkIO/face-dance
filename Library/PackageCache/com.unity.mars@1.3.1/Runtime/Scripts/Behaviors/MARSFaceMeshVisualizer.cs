using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Visualizers
{
    [MovedFrom("Unity.MARS.Behaviors")]
    public class MARSFaceMeshVisualizer : MonoBehaviour, IUsesFaceTracking, IUsesCameraOffset
    {
#if UNITY_EDITOR || true
#pragma warning disable 649
        [SerializeField]
        GameObject m_FaceMeshPrefab;
#pragma warning restore 649

        [SerializeField]
        [Tooltip("Face mesh factor scale. This depends on the face mesh prefab, " +
                 "and what percentage it covers of the totality of landmarks.")]
        float m_ScaleFactor = 0.9f;

        IProvidesFaceTracking IFunctionalitySubscriber<IProvidesFaceTracking>.provider { get; set; }
        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        MeshRenderer m_FaceMeshRenderer;

        // original face's unscaled size (use for dynamic scaling)
        Vector3 m_OriginalUnscaledSize = Vector3.one;
        // frame by frame scale
        Vector3 m_DynamicScale = Vector3.one;

        void OnEnable()
        {
            this.SubscribeFaceAdded(FaceAdded);
            this.SubscribeFaceUpdated(FaceUpdated);
            this.SubscribeFaceRemoved(FaceRemoved);
        }

        void OnDisable()
        {
            this.UnsubscribeFaceAdded(FaceAdded);
            this.UnsubscribeFaceUpdated(FaceUpdated);
            this.UnsubscribeFaceRemoved(FaceRemoved);
        }

        void FaceAdded(IMRFace face)
        {
            Debug.Assert(m_FaceMeshRenderer == null);

            // spawn face mesh
            var faceGO = Instantiate(m_FaceMeshPrefab);
            faceGO.hideFlags = HideFlags.DontSave;
            m_FaceMeshRenderer = faceGO.GetComponent<MeshRenderer>();

            // get initial size and scale
            var scaledSize = m_FaceMeshRenderer.bounds.size;
            var initialScale = m_FaceMeshRenderer.transform.localScale;

            // calculate unscaled size
            m_OriginalUnscaledSize.x = initialScale.x > 0 ? scaledSize.x / initialScale.x : scaledSize.x;
            m_OriginalUnscaledSize.y = initialScale.y > 0 ? scaledSize.y / initialScale.y : scaledSize.y;
            m_OriginalUnscaledSize.z = initialScale.z > 0 ? scaledSize.z / initialScale.z : scaledSize.z;

            FaceUpdated(face);
        }

        void FaceUpdated(IMRFace face)
        {
            Debug.Assert(m_FaceMeshRenderer != null);

            m_FaceMeshRenderer.transform.SetPositionAndRotation(face.pose.position, face.pose.rotation);

            // get current face's desired size (based on landmarks)
            var targetSize = face.GetBounds().size;

            // dynamic scale (not keeping aspect ratio)
            m_DynamicScale.x = m_OriginalUnscaledSize.x > 0 ? targetSize.x / m_OriginalUnscaledSize.x : targetSize.x;
            m_DynamicScale.y = m_OriginalUnscaledSize.y > 0 ? targetSize.y / m_OriginalUnscaledSize.y : targetSize.y;
            m_DynamicScale.z = m_OriginalUnscaledSize.z > 0 ? targetSize.z / m_OriginalUnscaledSize.z : targetSize.z;

            // get average scale from the axis (to keep aspect ratio)
            var averageScale = (m_DynamicScale.x + m_DynamicScale.y + m_DynamicScale.z) / 3;
            m_DynamicScale.Set(averageScale, averageScale, averageScale);

            // apply dynamic scale and scale factor
            m_FaceMeshRenderer.transform.localScale = m_DynamicScale * m_ScaleFactor;
        }

        void FaceRemoved(IMRFace face)
        {
            // destroy face mesh
            if (m_FaceMeshRenderer != null)
                UnityObjectUtils.Destroy(m_FaceMeshRenderer.gameObject);

            // reset reference
            m_FaceMeshRenderer = null;
        }
#endif
    }
}
