using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS.Rules.RulesEditor
{
    class RulesWindow : EditorWindow, ISerializationCallbackReceiver
    {
        const string k_RulesWindowName = "Proxy Rule Set";

        internal static Action GUIDispatch;

        static readonly Vector2 k_MinSize = new Vector2(450, 200);

        [SerializeField]
        List<GameObject> m_ExpandedNodes = new List<GameObject>();

        [SerializeField]
        ProxyRuleSet m_SerializedActiveRuleSet;

        [MenuItem(MenuConstants.MenuPrefix + k_RulesWindowName, priority = MenuConstants.RulesWindowPriority)]
        public static void Init()
        {
            var win = GetWindow<RulesWindow>();
            win.titleContent = new GUIContent(k_RulesWindowName);
        }

        void OnEnable()
        {
            minSize = k_MinSize;

            if (m_SerializedActiveRuleSet != null)
                RulesModule.RuleSetInstance = m_SerializedActiveRuleSet;

            RulesDrawer.Init(rootVisualElement);

            EditorEvents.WindowUsed.Send(new UiComponentArgs { label = k_RulesWindowName, active = true});
        }

        void OnDisable()
        {
            EditorEvents.WindowUsed.Send(new UiComponentArgs { label = k_RulesWindowName, active = false});
        }

        void OnGUI()
        {
            if (!MARSEntitlements.instance.EntitlementsCheckGUI(position.width))
                return;

            if (Event.current.commandName == "ObjectSelectorClosed" && !RulesModule.WasPicked)
                RulesModule.PickedObject = EditorGUIUtility.GetObjectPickerObject();

            RulesDrawer.OnGUI();

            if (GUIDispatch != null)
            {
                GUIDispatch();
                GUIDispatch = null;
            }
            
            m_SerializedActiveRuleSet = RulesModule.RuleSetInstanceExisting;
        }

        public void OnBeforeSerialize()
        {
            var expandedNodes = RulesModule.CollapsedNodes;
            m_ExpandedNodes.Clear();
            foreach (var node in expandedNodes)
            {
                m_ExpandedNodes.Add(node);
            }
        }

        public void OnAfterDeserialize()
        {
            var expandedNodes = RulesModule.CollapsedNodes;
            expandedNodes.Clear();
            foreach (var node in m_ExpandedNodes)
            {
                expandedNodes.Add(node);
            }
        }
    }
}
