using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// Represents an up axis preference for object placement
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public enum AxisEnum
    {
        /// <summary>No preference</summary>
        None = -1,
        /// <summary>X up</summary>
        XUp = 0,
        /// <summary>X down</summary>
        XDown,
        /// <summary>Y up</summary>
        YUp,
        /// <summary>Y down</summary>
        YDown,
        /// <summary>Z up</summary>
        ZUp,
        /// <summary>Z down</summary>
        ZDown,
        /// <summary>Custom placement axis</summary>
        Custom
    }

    /// <summary>
    /// Overrides for the drag and drop behavior from the <c>ScenePlacementModule</c> when placing the object in a scene.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class PlacementOverride : MonoBehaviour
    {
        /// <summary>
        /// Optional boolean value that can override a value or have no effect
        /// </summary>
        public enum BooleanOverride
        {
            /// <summary>No override</summary>
            None,
            /// <summary>Override true</summary>
            True,
            /// <summary>Override false</summary>
            False
        }

        [SerializeField]
        [Tooltip("Override ScenePlacementModule for snapping to pivot")]
        BooleanOverride m_SnapToPivotOverride = BooleanOverride.None;

        [SerializeField]
        [Tooltip("Override ScenePlacementModule for orienting to surface")]
        BooleanOverride m_OrientToSurfaceOverride = BooleanOverride.None;

        [SerializeField]
        [Tooltip("Override ScenePlacementModule for up orientation")]
        AxisEnum m_AxisOverride = AxisEnum.YUp;

        [SerializeField]
        [Tooltip("Custom axis used for AxisOverride.Custom")]
        Vector3 m_CustomAxisOverride = Vector3.up;

        [SerializeField]
        [HideInInspector]
        Vector3 m_CustomAxisOverrideNormalized = Vector3.up;

        /// <summary>
        /// If not set to None, objects will use the snap to pivot override.
        /// </summary>
        public bool useSnapToPivotOverride => m_SnapToPivotOverride != BooleanOverride.None;

        /// <summary>
        /// If not set to None, objects placed on this target will always use the specified setting for snapping to the pivot
        /// </summary>
        public bool snapToPivotOverride => m_SnapToPivotOverride == BooleanOverride.True;

        /// <summary>
        /// If not set to None, objects will use the orient to surface override.
        /// </summary>
        public bool useOrientToSurfaceOverride => m_OrientToSurfaceOverride != BooleanOverride.None;

        /// <summary>
        /// If not set to None, objects placed on this target will always use the specified setting for orienting to the surface
        /// </summary>
        public bool orientToSurfaceOverride => m_OrientToSurfaceOverride == BooleanOverride.True;

        /// <summary>
        /// If not set to None, objects will use the axis override for placement.
        /// </summary>
        public bool useAxisOverride => m_AxisOverride != AxisEnum.None;

        /// <summary>
        /// Override to the up axis of the object when placing <c>ScenePlacementModule</c>
        /// </summary>
        public AxisEnum axisOverride => m_AxisOverride;

        /// <summary>
        /// If there is an axis override, then this will contain that value, otherwise it will be null
        /// </summary>
        public Vector3 axisOverrideVector
        {
            get
            {
                var axis = Vector3.zero;
                switch (m_AxisOverride)
                {
                    case AxisEnum.XUp:
                        axis = Vector3.right;
                        break;
                    case AxisEnum.XDown:
                        axis = Vector3.left;
                        break;
                    case AxisEnum.YUp:
                        axis = Vector3.up;
                        break;
                    case AxisEnum.YDown:
                        axis = Vector3.down;
                        break;
                    case AxisEnum.ZUp:
                        axis = Vector3.forward;
                        break;
                    case AxisEnum.ZDown:
                        axis = Vector3.back;
                        break;
                    case AxisEnum.Custom:
                        axis = m_CustomAxisOverrideNormalized;
                        break;
                }

                return axis;
            }
        }

        void OnValidate()
        {
            if (m_CustomAxisOverride == Vector3.zero)
            {
                m_CustomAxisOverride = Vector3.up;
                m_CustomAxisOverrideNormalized = Vector3.up;
                Debug.LogWarning("Custom Axis Override cannot be Zero! Must specify a direction.");
            }
            else
                m_CustomAxisOverrideNormalized = Vector3.Normalize(m_CustomAxisOverride);
        }
    }
}
