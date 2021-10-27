using Unity.MARS.Attributes;
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
    /// An action that scales child content by the bounds of its matching AR Object
    /// </summary>
    [HelpURL(DocumentationConstants.StretchToExtentsActionDocs)]
    [ComponentTooltip("Scales children to fit the bounds of their parent Real World Object.")]
    [MonoBehaviourComponentMenu(typeof(StretchToExtentsAction), "Action/Stretch to Extents")]
    [MovedFrom("Unity.MARS")]
    public class StretchToExtentsAction : TransformAction, ISpawnable, IUsesCameraOffset, IRequiresTraits
    {
        static readonly Quaternion k_RotateQuarter = Quaternion.Euler(0.0f, 90.0f, 0.0f);

        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Pose, TraitDefinitions.Bounds2D };

        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        /// <summary>
        /// The modes of operation this stretch action can operate in
        /// </summary>
        enum PlanarStretchMode
        {
            /// <summary> Scale the content by the smallest axis of the match data </summary>
            Uniform = 0,
            /// <summary> Scale each axis of the content separately by the axes of the match data </summary>
            NonUniform,
            /// <summary> A non-uniform scale where the X axis gets scaled by the largest axis of the bounds </summary>
            AlignLongSideToX
        }

        enum VerticalStretchMode
        {
            /// <summary> Vertical scale of the content is set to one </summary>
            None,
            /// <summary> Vertical scale of the content is set to the smallest axis of the match data </summary>
            Minimum,
            /// <summary> Vertical scale of the content is set to the average of both axes of match data </summary>
            Average
        }

        [SerializeField]
        [Tooltip("How content should be scaled to match the extents of an AR Object ")]
        PlanarStretchMode m_PlanarStretch = PlanarStretchMode.Uniform;

        [SerializeField]
        [Tooltip("How content should be scaled vertically to match the extents of an AR Object ")]
        VerticalStretchMode m_VerticalStretch = VerticalStretchMode.None;

        [SerializeField]
        [Tooltip("The default size of the proxy, that will be used to scale down the effect from the bounds.")]
        Vector2 m_BaseScale = Vector2.one;


        void OnValidate()
        {
            transform.localPosition = Vector3.zero;
        }

        void OnEnable()
        {
            transform.localPosition = Vector3.zero;
        }

        /// <inheritdoc />
        public void OnMatchAcquire(QueryResult queryResult)
        {
            UpdateScale(queryResult);
        }

        /// <inheritdoc />
        public void OnMatchUpdate(QueryResult queryResult)
        {
            UpdateScale(queryResult);
        }

        void UpdateScale(QueryResult queryResult)
        {
            if (!queryResult.TryGetTrait(TraitNames.Bounds2D, out Vector2 bounds) || !queryResult.TryGetTrait(TraitNames.Pose, out Pose newPose))
                return;

            var planeScale = this.GetCameraScale();
            bounds *= planeScale;

            var smallestBounds = Mathf.Min(bounds.x, bounds.y);
            var newScale = transform.localScale;

            switch (m_PlanarStretch)
            {
                case PlanarStretchMode.Uniform:
                    newScale.x = smallestBounds;
                    newScale.z = smallestBounds;
                    break;
                case PlanarStretchMode.NonUniform:
                    newScale.x = bounds.x;
                    newScale.z = bounds.y;
                    break;
                case PlanarStretchMode.AlignLongSideToX:
                    if (bounds.x < bounds.y)
                    {
                        newPose.rotation *= k_RotateQuarter;
                        newScale.x = bounds.y;
                        newScale.z = bounds.x;
                    }
                    else
                    {
                        newScale.x = bounds.x;
                        newScale.z = bounds.y;
                    }
                    break;
            }

            newScale.x /= m_BaseScale.x;
            newScale.y /= m_BaseScale.y;

            switch (m_VerticalStretch)
            {
                case VerticalStretchMode.Minimum:
                    newScale.y = smallestBounds;
                    break;
                case VerticalStretchMode.Average:
                    newScale.y = (bounds.x + bounds.y) * 0.5f;
                    break;
            }

            transform.localScale = newScale;
            transform.SetWorldPose(newPose);
        }

        /// <inheritdoc />
        public TraitRequirement[] GetRequiredTraits()
        {
            return k_RequiredTraits;
        }
    }
}
