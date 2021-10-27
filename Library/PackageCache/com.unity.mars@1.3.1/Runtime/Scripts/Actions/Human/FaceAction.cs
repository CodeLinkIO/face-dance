using Unity.MARS.Attributes;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Actions
{
    /// <summary>
    /// Applies the position of a real world face to a target gameobject.
    /// </summary>
	[HelpURL(DocumentationConstants.FaceActionDocs)]
    [RequireComponent(typeof(IsFaceCondition))]
    [RequireComponent(typeof(Proxy))]
    [MonoBehaviourComponentMenu(typeof(FaceAction), "Action/Face Action")]
    [MovedFrom("Unity.MARS")]
    public class FaceAction : MonoBehaviour, IMatchAcquireHandler, IMatchUpdateHandler, IMatchLossHandler,
        IUsesFaceTracking, IUsesMARSTrackableData<IMRFace>, IRequiresTraits
    {
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Pose };

#pragma warning disable 649
        [SerializeField]
        Transform m_FaceAnchorOverride;

        [SerializeField]
        MeshFilter m_FaceMesh;
#pragma warning restore 649

        bool m_RunInEditModeDirty;
        Pose m_StartPose;

        IMRFace m_AssignedFace;

        Transform FaceAnchor { get { return m_FaceAnchorOverride == null ? transform : m_FaceAnchorOverride; } }

        IProvidesFaceTracking IFunctionalitySubscriber<IProvidesFaceTracking>.provider { get; set; }

        /// <inheritdoc />
        public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

        /// <inheritdoc />
        public void OnMatchAcquire(QueryResult queryResult)
        {
            m_RunInEditModeDirty = true;
            m_StartPose = FaceAnchor.transform.GetWorldPose();

            m_AssignedFace = queryResult.ResolveValue(this);
            var assignedFaceMesh = m_AssignedFace.Mesh;
            if (m_FaceMesh && assignedFaceMesh != null)
                m_FaceMesh.sharedMesh = assignedFaceMesh;

            TryUpdatePose(queryResult);
        }

        /// <inheritdoc />
        public void OnMatchUpdate(QueryResult queryResult) { TryUpdatePose(queryResult); }

        /// <inheritdoc />
        public void OnMatchLoss(QueryResult queryResult)
        {
            if (!FaceAnchor)
                return;

            if (m_RunInEditModeDirty)
            {
                FaceAnchor.transform.SetWorldPose(m_StartPose);
            }
        }

        void TryUpdatePose(QueryResult queryResult)
        {
            if (queryResult.TryGetTrait(TraitNames.Pose, out Pose pose))
                FaceAnchor.transform.SetLocalPose(pose);
        }
    }
}
