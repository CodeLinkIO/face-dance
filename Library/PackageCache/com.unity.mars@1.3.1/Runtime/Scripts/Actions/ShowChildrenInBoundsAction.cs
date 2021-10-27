using System.Collections.Generic;
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
    /// Enables any child objects that are within the planar bounds of the proxy.
    /// </summary>
    [ComponentTooltip("Enables any child objects that are within the planar bounds of the proxy.")]
    [DisallowMultipleComponent]
    [MonoBehaviourComponentMenu(typeof(ShowChildrenInBoundsAction), "Action/Show Objects In Bounds")]
    [MovedFrom("Unity.MARS")]
    public class ShowChildrenInBoundsAction : MonoBehaviour, IMatchVisibilityHandler, IUsesMARSTrackableData<MRPlane>, IUsesCameraOffset, IRequiresTraits
    {
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Pose, TraitDefinitions.Bounds2D };

        readonly List<Transform> m_Children = new List<Transform>();
        readonly List<bool> m_CurrentChildStates = new List<bool>();

        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<bool> k_NewChildStates = new List<bool>();

        /// <summary>
        /// Shows and hides child objects based on if they are inside the tracked AR data's bounds
        /// </summary>
        /// <param name="newState">The current state of the parent object</param>
        /// <param name="queryResult">Query data associated with the state change</param>
        /// <param name="objectsToActivate">A list containing objects that should be activated</param>
        /// <param name="objectsToDeactivate">A list containing objects which should be set to inactive</param>
        void IMatchVisibilityHandler.FilterVisibleObjects(QueryState newState, QueryResult queryResult, List<GameObject> objectsToActivate, List<GameObject> objectsToDeactivate)
        {
            switch (newState)
            {
                case QueryState.Unknown:
                    // Cache the child list here, as this object responds to update
                    m_Children.Clear();
                    m_CurrentChildStates.Clear();
                    foreach (Transform child in transform)
                    {
                        m_Children.Add(child);
                        m_CurrentChildStates.Add(false);
                        objectsToDeactivate.Add(child.gameObject);
                    }

                    break;
                case QueryState.Tracking:
                    if (queryResult == null)
                        return;

                    k_NewChildStates.Clear();

                    var cameraScale = this.GetCameraScale();
                    var invCameraScale = cameraScale;
                    if (invCameraScale > 0.0f)
                        invCameraScale = 1.0f / invCameraScale;

                    // If we didn't have an associated plane, try to retrieve another source of bounds
                    Pose pose;
                    Vector2 bounds;
                    var mrPlane = queryResult.ResolveValue(this);
                    if (mrPlane.id == MarsTrackableId.InvalidId)
                    {
                        queryResult.TryGetTrait(TraitNames.Bounds2D, out bounds);
                        queryResult.TryGetTrait(TraitNames.Pose, out pose);
                    }
                    else
                    {
                        pose = this.ApplyOffsetToPose(mrPlane.pose);
                        bounds = mrPlane.extents * 0.5f;
                    }

                    var invRotation = Quaternion.Inverse(pose.rotation);

                    // Do a bounds check for trivial rejection

                    var position = pose.position;
                    var center = mrPlane.center * cameraScale;

                    var childCount = m_Children.Count;
                    for (var i = childCount - 1; i >= 0; i--)
                    {
                        var child = m_Children[i];

                        if (child != null)
                        {
                            var childPos = invRotation * (child.position - position) * invCameraScale;
                            var inRange = Mathf.Abs(childPos.x - center.x) < bounds.x && Mathf.Abs(childPos.z - center.z) < bounds.y;
                            k_NewChildStates.Insert(0, inRange);
                        }
                        else
                        {
                            m_Children.RemoveAt(i);
                            m_CurrentChildStates.RemoveAt(i);
                        }
                    }

                    childCount = m_Children.Count;

                    // If there is extent data, we use that to refine the rejection further
                    var vertices = mrPlane.vertices;
                    if (vertices != null && vertices.Count > 2)
                    {
                        for (var i = 0; i < childCount; i++)
                        {
                            if (!k_NewChildStates[i])
                                continue;

                            var childPos = invRotation * (m_Children[i].position - position) * invCameraScale;
                            k_NewChildStates[i] = GeometryUtils.PointInPolygon(childPos, vertices);
                        }
                    }

                    for (var i = 0; i < childCount; i++)
                    {
                        var childState = k_NewChildStates[i];
                        if (childState == m_CurrentChildStates[i])
                            continue;

                        m_CurrentChildStates[i] = childState;
                        if (childState)
                            objectsToActivate.Add(m_Children[i].gameObject);
                        else
                            objectsToDeactivate.Add(m_Children[i].gameObject);
                    }

                    break;
                case QueryState.Resuming:
                case QueryState.Unavailable:
                    for (var i = 0; i < m_Children.Count; i++)
                    {
                        if (!m_CurrentChildStates[i])
                            continue;

                        m_CurrentChildStates[i] = false;
                        objectsToDeactivate.Add(m_Children[i].gameObject);
                    }

                    break;
            }
        }

        /// <inheritdoc />
        public TraitRequirement[] GetRequiredTraits()
        {
            return k_RequiredTraits;
        }
    }
}
