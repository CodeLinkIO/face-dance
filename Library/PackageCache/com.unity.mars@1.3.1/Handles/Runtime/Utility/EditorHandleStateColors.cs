using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    [AddComponentMenu("")]
    sealed class EditorHandleStateColors : HandleStateColors
    {
        internal static readonly Color editorDefaultDisableColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);

        internal const string wrongContextWarning = "An EditorHandleStateColors is present in a runtime context. This component is only valid in the editor and won't do anything at runtime. Use a HandleStateColors instead for proper result.";
        internal static readonly Color wrongContextColor = Color.magenta;

        public enum IdleColor
        {
            KeepMaterialColor,
            Axis_X,
            Axis_Y,
            Axis_Z,
            Axis_Center,
        }

        [SerializeField]
        IdleColor m_IdleColor = IdleColor.KeepMaterialColor;

        bool m_WrongContextLogged = false;

        bool inEditorContext => !(context is RuntimeHandleContext);

        /// <summary>
        /// The target color used to resolve which preference should be used for the idle color
        /// </summary>
        public IdleColor targetIdleColor
        {
            get => m_IdleColor;
            set
            {
                if (m_IdleColor == value)
                    return;

                m_IdleColor = value;
                UpdateIdleColor();
            }
        }

        /// <summary>
        /// The color used when the handle is idle. Setting this value in the editor won't do anything.
        /// </summary>
        public override Color idleColor
        {
            get
            {
#if UNITY_EDITOR
                if (inEditorContext)
                {
                    switch (m_IdleColor)
                    {
                        case IdleColor.Axis_X:
                            return UnityEditor.Handles.xAxisColor;
                        case IdleColor.Axis_Y:
                            return UnityEditor.Handles.yAxisColor;
                        case IdleColor.Axis_Z:
                            return UnityEditor.Handles.zAxisColor;
                        case IdleColor.Axis_Center:
                            return UnityEditor.Handles.centerColor;
                        default:
                            return base.idleColor;
                    }
                }
#endif

                LogWrongContextWarning();
                return wrongContextColor;
            }
        }

        /// <summary>
        /// The color used when the handle is hovered. Setting this value in the editor won't do anything.
        /// </summary>
        public override Color hoverColor
        {
            get
            {
#if UNITY_EDITOR
                if (inEditorContext)
                    return UnityEditor.Handles.preselectionColor;
#endif

                LogWrongContextWarning();
                return wrongContextColor;
            }
        }

        /// <summary>
        /// The color used when the handle is dragged. Setting this value in the editor won't do anything.
        /// </summary>
        public override Color dragColor
        {
            get
            {
#if UNITY_EDITOR
                if (inEditorContext)
                    return UnityEditor.Handles.selectedColor;
#endif

                LogWrongContextWarning();
                return wrongContextColor;
            }
        }

        /// <summary>
        /// The color used when another handle is dragged. Setting this value in the editor won't do anything.
        /// </summary>
        public override Color disableColor
        {
            get
            {
#if UNITY_EDITOR
                if (inEditorContext)
                    return editorDefaultDisableColor;
#endif

                LogWrongContextWarning();
                return wrongContextColor;
            }
        }

        void LogWrongContextWarning()
        {
            if (!m_WrongContextLogged)
            {
                Debug.LogWarning(wrongContextWarning, gameObject);
                m_WrongContextLogged = true;
            }
        }
    }
}
