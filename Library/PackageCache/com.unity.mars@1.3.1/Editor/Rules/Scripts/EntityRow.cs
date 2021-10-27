using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unity.MARS.Rules.RulesEditor
{
    class EntityRow : RuleNode
    {
        const string k_ProxyPresetName = "proxyPreset";
        const string k_PickProxyPresetName = "pickProxyPreset";
        const string k_EditGroupContent = "Edit Group";
        const string k_ReplacementProxyName = "New Proxy";

        const string k_ChangeProxyFieldAnalyticsEvent = "Change Proxy via object field";
        const string k_EditGroupButtonAnalyticsLabel = "Edit Group button";
        const string k_ReplaceDeletedProxyAnalyticsLabel = "Replacing deleted Proxy with new blank Proxy";
        const string k_UnableToReplaceDeletedProxyErrorAnalyticsLabel = "ERROR: Unable to replace deleted Proxy";

        protected MARSEntity m_Entity;
        protected VisualElement m_ContentContainer;
        protected ContentRow[] m_ContentRows;

        protected ObjectField m_ProxyField;
        Button m_PickProxyPresetButton;

        internal MARSEntity Entity => m_Entity;

        internal virtual bool HasChanged(MARSEntity entity)
        {
            return Entity == null || Entity != entity;
        }

        protected void SetupProxyPresetUI(MARSEntity entity)
        {
            m_ProxyField = this.Q<ObjectField>(k_ProxyPresetName);
            m_ProxyField.objectType = typeof(Proxy);
            m_ProxyField.RegisterValueChangedCallback(OnChangeProxy);

            m_ProxyField.RegisterCallback<ExecuteCommandEvent>(RulesModule.PickObject);

            var selector = m_ProxyField.Q<VisualElement>(className: ObjectField.selectorUssClassName);
            selector.style.display = DisplayStyle.None;

            m_PickProxyPresetButton = this.Q<Button>(k_PickProxyPresetName);
            m_PickProxyPresetButton.clicked += () =>
            {
                var mouse = Event.current.mousePosition;
                RulesModule.DoPickProxyPresetButton(entity, new Rect(mouse.x, mouse.y, 0, 0));
            };

            m_PickProxyPresetButton.RegisterCallback<ExecuteCommandEvent>(RulesModule.PickObject);
        }

        protected void CreateAddContentButton()
        {
            if (m_Entity is ProxyGroup)
            {
                var groupButton = new Button{text = k_EditGroupContent};
                groupButton.style.width = 160;
                groupButton.style.marginLeft = 30;
                groupButton.clicked += () =>
                {
                    EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                    {
                        label = k_EditGroupButtonAnalyticsLabel
                    });

                    var ruleset = m_Entity.GetComponent<ProxyRuleSet>();
                    Selection.activeGameObject = m_Entity.gameObject;
                    RulesModule.RuleSetInstance = ruleset;
                    RulesDrawer.BuildReplicatorsList();
                };
                m_ContentContainer.Add(groupButton);
            }
        }

        void OnChangeProxy(ChangeEvent<Object> evt)
        {
            // Container would be null if the replicator/row was deleted, which invokes this OnChange event.
            if (ContainerObject == null)
                return;

            var newProxy = (Proxy) evt.newValue;

            // Having no value in the Proxy is a malformed state, because Replicators can't exist without a Proxy child,
            // and a ReplicatorRow represents the Replicator+Proxy combo. Therefore, if the user clears out the Proxy field
            // (select the object field and hit 'delete'), we insert a new blank Proxy.
            if (newProxy == null)
            {
                MarsObjectCreationResources.instance.ProxyObjectPreset.CreateGameObject(
                    out var createdGameObject, ContainerObject);

                if (createdGameObject != null)
                {
                    createdGameObject.name = k_ReplacementProxyName;
                    newProxy = createdGameObject.GetComponent<Proxy>();

                    EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                    {
                        label = k_ReplaceDeletedProxyAnalyticsLabel
                    });
                }
                else
                {
                    Debug.LogError("Attempted to set no Proxy for this rule, and was unable to generate a new blank Proxy. " +
                                   "This could happen because the MarsObjectCreationResources asset is misconfigured.");

                    EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                    {
                        label = k_UnableToReplaceDeletedProxyErrorAnalyticsLabel
                    });

                    return;
                }
            }

            RulesModule.ReplaceGameObject(newProxy.gameObject, ((Proxy) evt.previousValue).transform);

            EditorEvents.RulesUiUsed.Send(new RuleUiArgs
            {
                label = k_ChangeProxyFieldAnalyticsEvent
            });
        }
    }
}
