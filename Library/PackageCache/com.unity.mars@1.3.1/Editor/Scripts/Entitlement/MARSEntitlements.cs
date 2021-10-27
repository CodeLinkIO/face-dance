using Unity.MARS.MARSUtils;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS
{
    [InitializeOnLoad]
    class MARSEntitlements : EditorScriptableSettings<MARSEntitlements>
    {
        class Styles
        {
            public const string k_Title = "Mixed & Augmented Reality Studio";
            public const string k_TitleNarrow = "Mixed & Augmented\nReality Studio";
            public const string k_ButtonText = "Purchase Subscription";

            public const int MessageWidth = 270;
            public const int MessageWidthNarrow = 200;
            public const int WidthBreakpoint = 350;

            public static readonly GUIStyle TitleStyle;
            public static readonly GUIStyle SubscriptionMessageStyle;
            public static readonly GUIStyle DetailedErrorMessageStyle;
            public static readonly GUIStyle ButtonStyle;

            static Styles()
            {
                SubscriptionMessageStyle = new GUIStyle(EditorStyles.label)
                {
                    fontSize = 14,
                    alignment = TextAnchor.MiddleCenter,
                    wordWrap = true
                };

                DetailedErrorMessageStyle = new GUIStyle(EditorStyles.label)
                {
                    fontSize = 12,
                    fontStyle = FontStyle.Bold,
                    alignment = TextAnchor.MiddleCenter,
                    wordWrap = true
                };

                TitleStyle = new GUIStyle(SubscriptionMessageStyle)
                {
                    fontStyle = FontStyle.Bold
                };

                ButtonStyle = new GUIStyle("button")
                {
                    fixedHeight = 24,
                    fixedWidth = 170
                };
            }
        }

        static MARSEntitlements()
        {
            EditorOnlyDelegates.IsEntitled = ((valueIfWaiting) => instance.IsEntitled(valueIfWaiting));
        }

        [SerializeField]
        bool m_NotEntitled = false;

        public bool IsEntitled(bool valueIfWaiting = true)
        {
            if (m_NotEntitled)
                return false;
            return EntitlementUtils.IsEntitled(valueIfWaiting);
        }

        public bool EntitlementsCheckGUI(float viewWidth)
        {
            if (IsEntitled())
                return true;

            var displayNarrow = viewWidth < Styles.WidthBreakpoint;

            using (new GUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();

                using (new GUILayout.VerticalScope())
                {
                    GUILayout.FlexibleSpace();

                    GUILayout.Label(displayNarrow ? Styles.k_TitleNarrow : Styles.k_Title, Styles.TitleStyle);
                    GUILayout.Space(EditorGUIUtility.singleLineHeight);

                    using (new GUILayout.HorizontalScope())
                    {
                        GUILayout.FlexibleSpace();

                        GUILayout.Label(
                            MARSSession.NotEntitledMessage, Styles.SubscriptionMessageStyle,
                            GUILayout.Width(displayNarrow ? Styles.MessageWidthNarrow : Styles.MessageWidth));

                        GUILayout.FlexibleSpace();
                    }

                    if (EntitlementUtils.EntitlementTokenExpired)
                    {
                        GUILayout.Space(EditorGUIUtility.singleLineHeight);
                        using (new GUILayout.HorizontalScope())
                        {
                            GUILayout.FlexibleSpace();
                            GUILayout.Label(MARSSession.TokenExpiredMessage,
                                Styles.DetailedErrorMessageStyle,
                                GUILayout.Width(displayNarrow ? Styles.MessageWidthNarrow : Styles.MessageWidth));
                            GUILayout.FlexibleSpace();
                        }
                    }

                    GUILayout.Space(EditorGUIUtility.singleLineHeight);

                    using (new GUILayout.HorizontalScope())
                    {
                        GUILayout.FlexibleSpace();

                        if (GUILayout.Button(Styles.k_ButtonText, Styles.ButtonStyle))
                            Application.OpenURL(MARSSession.LicensingUrl);

                        GUILayout.FlexibleSpace();
                    }

                    GUILayout.FlexibleSpace();
                }

                GUILayout.FlexibleSpace();
            }

            return false;
        }
    }
}
