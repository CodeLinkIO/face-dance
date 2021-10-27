using UnityEditor;
using UnityEngine;

namespace Unity.MARS.Rules.RulesEditor
{
    [CustomEditor(typeof(ProxyRuleSet))]
    class RulesetEditor : Editor
    {
        const string k_OpenAsWindowButtonText = "Open As Window";

        readonly GUIContent m_ShowContent = new GUIContent("Show in Hierarchy");
        readonly GUIContent m_HideContent = new GUIContent("Hide in Hierarchy");

        public override void OnInspectorGUI()
        {
            using (new GUILayout.HorizontalScope())
            {
                if (GUILayout.Button(k_OpenAsWindowButtonText))
                {
                    RulesModule.RuleSetInstance = (ProxyRuleSet)target;
                    RulesWindow.Init();
                }

                var rules = (ProxyRuleSet)target;
                var visible = RulesModule.AllChildrenVisible(rules.transform);
                if (GUILayout.Button(visible ? m_HideContent : m_ShowContent))
                    RulesModule.SetChildrenVisible(!visible, rules.transform);
            }
        }
    }
}
