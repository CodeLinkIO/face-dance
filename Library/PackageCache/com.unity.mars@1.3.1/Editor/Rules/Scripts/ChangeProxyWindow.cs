using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS.Rules.RulesEditor
{
    class ChangeProxyWindow : MarsEditorGUI.MarsPopupWindow
    {
        static readonly Vector2 k_PopupSize = new Vector2(280, 250);

        readonly MARSEntity m_Entity;

        public ChangeProxyWindow(MARSEntity entity)
        {
            m_Entity = entity;
        }

        protected override void Draw()
        {
            MarsObjectCreationPanel.DrawSection(
                MarsObjectCreationSettings.instance.ObjectCreationButtonSections[0],
                false, go =>
                {
                    RulesModule.ReplaceGameObject(go, m_Entity.transform);
                    editorWindow.Close();
                });

            if (!(m_Entity is Proxy proxy))
                return;

            GUILayout.Space(12);

            // Nested groups are not currently supported
            if (m_Entity && m_Entity.GetComponentInParent<ProxyGroup>())
                return;

            const int buttonHeight = 24;
            if (GUILayout.Button("Convert to Group", GUILayout.Height(buttonHeight)))
            {
                RulesModule.ConvertProxyToGroup(proxy);
                editorWindow.Close();
            }
        }

        public override Vector2 GetWindowSize()
        {
            return k_PopupSize;
        }
    }
}
