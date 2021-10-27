using System;
using System.Collections.Generic;
using Unity.MARS;
using Unity.MARS.Conditions;
using Unity.MARS.Query;
using Unity.XRTools.Utils;
using UnityEditor.XRTools.Utils;
using UnityEngine;

namespace UnityEditor.MARS
{
    class MarsUIResources : EditorScriptableSettings<MarsUIResources>
    {
        /// <summary>
        /// The filepath of the editor folder for MARS
        /// </summary>
        public const string EditorFolderPath = "Packages/com.unity.mars/Editor/";

#pragma warning disable 649
        [SerializeField]
        Texture2D m_NextEnvironmentIcon;

        [SerializeField]
        Texture2D m_PreviousEnvironmentIcon;

        [SerializeField]
        Texture2D m_StopIcon;

        [SerializeField]
        Texture2D m_WarningTexture;

        [Header("Create Icons")]

        [SerializeField]
        DarkLightIconPair m_CreationPanelDefaultIcon;

        [SerializeField]
        DarkLightIconPair m_ProxyObject;

        [SerializeField]
        DarkLightIconPair m_Set;

        [SerializeField]
        DarkLightIconPair m_Replicator;

        [SerializeField]
        DarkLightIconPair m_SyntheticObject;

        [Header("Tool Icons")]

        [SerializeField]
        DarkLightIconPair m_CreateTool;

        [SerializeField]
        DarkLightIconPair m_CompareTool;

        [Header("Condition Icons")]

        [SerializeField]
        ConditionIconData m_ElevationIcons;

        [SerializeField]
        ConditionIconData m_ProximityIcons;

        [SerializeField]
        ConditionIconData m_SizeIcons;

        [Header("Hierarchy Icons")]

        [SerializeField]
        ClientIconData m_FaceIcons;

        [SerializeField]
        ClientIconData m_MarkerIcons;

        [SerializeField]
        ClientIconData m_ContextIcons;

        [SerializeField]
        ClientIconData m_SetIcons;

        [SerializeField]
        Texture2D m_SimulationViewIcon;

        [SerializeField]
        Texture2D m_CanEditIcon;

        [SerializeField]
        Texture2D m_CanNotEditIcon;

        [Header("Editor GUI")]

        [SerializeField]
        Texture2D m_ToolbarBackground;

        [SerializeField]
        Texture2D m_ToolbarBackground2X;

        [SerializeField]
        Texture2D m_ToolbarBackgroundPro;

        [SerializeField]
        Texture2D m_ToolbarBackgroundPro2X;

        [SerializeField]
        Texture2D m_ToolbarButton;

        [SerializeField]
        Texture2D m_ToolbarButton2X;

        [SerializeField]
        Texture2D m_ToolbarDropdown;

        [SerializeField]
        Texture2D m_ToolbarDropdownPro;

        [SerializeField]
        DarkLightIconPair m_Ellipsis;

        [Header("Simulation")]
        [SerializeField]
        SimulationIconData m_SimulationIconData;

        [Header("Bodies")]
        [SerializeField]
        BodyIconData m_BodyIconData;

        [Header("Snapping GUI")]

        [SerializeField]
        DarkLightIconPair m_OrientToSurface;

        [SerializeField]
        DarkLightIconPair m_PivotSnapping;

        [SerializeField]
        DarkLightIconPair m_XUp;

        [SerializeField]
        DarkLightIconPair m_XDown;

        [SerializeField]
        DarkLightIconPair m_YUp;

        [SerializeField]
        DarkLightIconPair m_YDown;

        [SerializeField]
        DarkLightIconPair m_ZUp;

        [SerializeField]
        DarkLightIconPair m_ZDown;

        [Header("Forces")]

        [SerializeField]
        ForcesIconData m_ForcesIconData;

        public ForcesIconData ForcesIconData => m_ForcesIconData;

#pragma warning restore 649

        Dictionary<Type, ConditionIconData> m_Icons;

        public DarkLightIconPair CreateToolIcon => m_CreateTool;
        public DarkLightIconPair CompareToolIcon => m_CompareTool;
        public Texture2D OrientToSurfaceIcon => m_OrientToSurface.Icon;
        public Texture2D PivotSnappingIcon => m_PivotSnapping.Icon;
        public Texture2D XUpIcon => m_XUp.Icon;
        public Texture2D XDownIcon => m_XDown.Icon;
        public Texture2D YUpIcon => m_YUp.Icon;
        public Texture2D YDownIcon => m_YDown.Icon;
        public Texture2D ZUpIcon => m_ZUp.Icon;
        public Texture2D ZDownIcon => m_ZDown.Icon;

        public Texture2D ToolbarBackground => EditorGUIUtility.isProSkin ? m_ToolbarBackgroundPro : m_ToolbarBackground;

        public Texture2D ToolbarBackground2X => EditorGUIUtility.isProSkin ? m_ToolbarBackgroundPro2X : m_ToolbarBackground2X;

        public Texture2D ToolbarButton => m_ToolbarButton;
        public Texture2D ToolbarButton2X => m_ToolbarButton2X;

        public Texture2D ToolbarDropdown => EditorGUIUtility.isProSkin ? m_ToolbarDropdownPro : m_ToolbarDropdown;

        public Texture2D Ellipisis => m_Ellipsis.Icon;

        public Texture2D NextEnvironmentIcon => m_NextEnvironmentIcon;
        public Texture2D PreviousEnvironmentIcon => m_PreviousEnvironmentIcon;
        public Texture2D StopIcon => m_StopIcon;
        public Texture2D WarningTexture => m_WarningTexture;
        public Texture2D CreationPanelDefaultIcon => m_CreationPanelDefaultIcon.Icon;
        public Texture2D RealWorldObjectIcon => m_ProxyObject.Icon;
        public Texture2D SetIcon => m_Set.Icon;
        public Texture2D ReplicatorIcon => m_Replicator.Icon;
        public Texture2D SyntheticObjectIcon => m_SyntheticObject.Icon;
        public Texture2D SimulationViewIcon => m_SimulationViewIcon;
        public Texture2D CanEditIcon => m_CanEditIcon;
        public Texture2D CanNotEditIcon => m_CanNotEditIcon;

        public DarkLightIconPair CreationPanelDefaultIconPair => m_CreationPanelDefaultIcon;
        public DarkLightIconPair ProxyObjectIconPair => m_ProxyObject;
        public DarkLightIconPair SetIconPair => m_Set;
        public DarkLightIconPair ReplicatorIconPair => m_Replicator;
        public DarkLightIconPair SyntheticObjectIconPair => m_SyntheticObject;
        public DarkLightIconPair MarkerIconsTrackingPair => m_MarkerIcons.Tracking;
        public DarkLightIconPair FaceIconsTrackingPair => m_FaceIcons.Tracking;

        public SimulationIconData SimulationIconData => m_SimulationIconData;

        public BodyIconData BodyIconData => m_BodyIconData;

        public Dictionary<Type, ConditionIconData> ConditionIcons =>
            m_Icons ?? (m_Icons = new Dictionary<Type, ConditionIconData>
            {
                { typeof(ElevationRelation), m_ElevationIcons },
                { typeof(DistanceRelation), m_ProximityIcons },
                { typeof(PlaneSizeCondition), m_SizeIcons },
            });

        public Texture2D GetIconForGameObject(GameObject gameObject)
        {
            if (!gameObject.activeInHierarchy)
                return null;

            var realWorldObject = gameObject.GetComponent<Proxy>();
            var set = gameObject.GetComponent<ProxyGroup>();
            QueryState queryState;
            ClientIconData iconData;

            if (realWorldObject)
            {
                queryState = realWorldObject.queryState;
                iconData = gameObject.GetComponent<IsFaceCondition>() != null ? m_FaceIcons : m_ContextIcons;
            }
            else if (set)
            {
                queryState = set.queryState;
                iconData = m_SetIcons;
            }
            else
            {
                return null;
            }

            switch (queryState)
            {
                case QueryState.Unknown:
                case QueryState.Querying:
                case QueryState.Resuming:
                    return iconData.Seeking.Icon;
                case QueryState.Tracking:
                case QueryState.Acquiring:
                    return iconData.Tracking.Icon;
                default:
                    return iconData.Unavailable.Icon;
            }
        }
    }

    [Serializable]
    class ConditionIconData
    {
#pragma warning disable 649
        [SerializeField]
        DarkLightIconPair m_Inactive;

        [SerializeField]
        DarkLightIconPair m_Active;
#pragma warning restore 649


        public DarkLightIconPair Inactive => m_Inactive;
        public DarkLightIconPair Active => m_Active;
    }

    [Serializable]
    class ForcesIconData
    {
#pragma warning disable 649
        [SerializeField]
        DarkLightIconPair m_AlignToCamera;
        [SerializeField]
        DarkLightIconPair m_AlignToProxy;
        [SerializeField]
        DarkLightIconPair m_OccupyNormal;
        [SerializeField]
        DarkLightIconPair m_OccupyPadding;
        [SerializeField]
        DarkLightIconPair m_SnapToSurfaceVertical;
        [SerializeField]
        DarkLightIconPair m_SnapToSurfaceHorizontal;
        [SerializeField]
        DarkLightIconPair m_SnapToEdgeVertical;
        [SerializeField]
        DarkLightIconPair m_SnapToEdgeHorizontal;
#pragma warning restore 649

        public DarkLightIconPair AlignToCamera => m_AlignToCamera;
        public DarkLightIconPair AlignToProxy => m_AlignToProxy;
        public DarkLightIconPair OccupyNormal => m_OccupyNormal;
        public DarkLightIconPair OccupyPadding => m_OccupyPadding;
        public DarkLightIconPair SnapToSurfaceVertical => m_SnapToSurfaceVertical;
        public DarkLightIconPair SnapToSurfaceHorizontal => m_SnapToSurfaceHorizontal;
        public DarkLightIconPair SnapToEdgeVertical => m_SnapToEdgeVertical;
        public DarkLightIconPair SnapToEdgeHorizontal => m_SnapToEdgeHorizontal;
    }

    [Serializable]
    class ClientIconData
    {
#pragma warning disable 649
        [SerializeField]
        DarkLightIconPair m_Seeking;

        [SerializeField]
        DarkLightIconPair m_Tracking;

        [SerializeField]
        DarkLightIconPair m_Unavailable;
#pragma warning restore 649

        public DarkLightIconPair Seeking => m_Seeking;
        public DarkLightIconPair Tracking => m_Tracking;
        public DarkLightIconPair Unavailable => m_Unavailable;
    }

    [Serializable]
    internal class SimulationIconData
    {
#pragma warning disable 649
        [SerializeField]
        DarkLightIconPair m_CameraControls;
#pragma warning restore 649

        internal DarkLightIconPair CameraControls => m_CameraControls;
    }

    [Serializable]
    internal class BodyIconData
    {
#pragma warning disable 649
        [SerializeField]
        DarkLightIconPair m_AvatarIcon;

        [SerializeField]
        DarkLightIconPair m_BodyPoseIcon;

        [SerializeField]
        DarkLightIconPair m_OpenTimelineIcon;
#pragma warning restore 649

        internal DarkLightIconPair BodyPoseIcon => m_BodyPoseIcon;
        internal DarkLightIconPair AvatarIcon => m_AvatarIcon;
        internal DarkLightIconPair OpenTimelineIcon => m_OpenTimelineIcon;

    }
}
