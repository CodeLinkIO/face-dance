using UnityEditor;
using UnityEditor.MARS.Simulation;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unity.MARS.Rules.RulesEditor
{
    class ReplicatorRow : EntityRow
    {
        const string k_ReplicatorRowPath = k_Directory + "ReplicatorRow.uxml";

        const string k_RowFoldoutName = "rowFoldout";
        const string k_MatchCountEnum = "matchCountEnum";
        const string k_MaxInstancesName = "maxInstances";
        const string k_GroupDrillIn = "groupDrillIn";
        const string k_SimMatchCountName = "simMatchCount";
        const string k_ContentContainerName = "contentContainer";

        const string k_OnEveryObjectName = "On Every";
        const string k_OnOneObjectName = "On One";
        const string k_OnUpToObjectName = "On Up To ";

        const int k_ReplicateOnEveryMatchSetting = 0;
        const int k_ReplicateOneMatchSetting = 1;
        const int k_ReplicatorUpToDefaultMatchCount = 2;

        const string k_AddButtonReplicatorAnalyticsLabel = "Margin add button (Replicator row)";
        const string k_DeleteKeyAnalyticsLabel = "Delete rule with keyboard";
        const string k_AddKeyAnalyticsLabel = "Add content to Replicator with keyboard";
        const string k_SelectPreviousAnalyticsLabel = "Select previous with keyboard";
        const string k_SelectNextAnalyticsLabel = "Select next with keyboard";
        const string k_MatchCountDropdownChangedAnalyticsEvent = "Match count dropdown changed";
        const string k_MaxInstancesChangedAnalyticsEvent = "Replicator max instances changed";

        SerializedObject m_ReplicatorSerializedObject;
        SerializedProperty m_MaxInstancesProperty;

        EnumField m_MatchCountEnum;
        IntegerField m_MaxCountField;
        Button m_GroupDrillInButton;
        Label m_SimMatchCount;
        Foldout m_Foldout;

        internal Replicator BackingReplicator { get; }
        internal Replicator SimulatedReplicator { get; private set; }
        internal override Transform ContainerObject => BackingReplicator.transform;
        internal override GameObject BackingObject => BackingReplicator.gameObject;
        internal Proxy BackingProxy => Entity as Proxy;
        internal bool IsGroup { get; private set; }

        public ReplicatorRow(Replicator replicator)
        {
            BackingReplicator = replicator;

            CollectObjects();
            SetupUI();
        }

        protected sealed override void SetupUI()
        {
            var replicatorRowAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(k_ReplicatorRowPath);
            replicatorRowAsset.CloneTree(this);

            base.SetupUI();

            m_ContentContainer = this.Q<VisualElement>(k_ContentContainerName);

            m_Foldout = this.Q<Foldout>(k_RowFoldoutName);
            m_Foldout.RegisterValueChangedCallback(evt =>
            {
                var expanded = evt.newValue;
                m_ContentContainer.style.display = expanded ? DisplayStyle.Flex : DisplayStyle.None;
                if (expanded)
                    RulesModule.CollapsedNodes.Remove(BackingObject);
                else
                    RulesModule.CollapsedNodes.Add(BackingObject);

                RulesDrawer.BuildReplicatorsList();
            });

            m_Foldout.RegisterCallback<ExecuteCommandEvent>(RulesModule.PickObject);

            if (IsGroup)
            {
                m_Foldout.visible = false;
            }
            else
            {
                var expanded = !RulesModule.CollapsedNodes.Contains(BackingObject);
                m_Foldout.value = expanded;
                m_ContentContainer.style.display = expanded ? DisplayStyle.Flex : DisplayStyle.None;
            }

            m_MatchCountEnum = this.Q<EnumField>(k_MatchCountEnum);
            m_MatchCountEnum.Init(RulesModule.ReplicatorCountOption.Every);
            m_MatchCountEnum.RegisterCallback<ChangeEvent<System.Enum>>(OnChangeMatchCountDropdown);

            m_MaxCountField = this.Q<IntegerField>(k_MaxInstancesName);
            m_MaxCountField.RegisterValueChangedCallback(OnMaxInstanceChanged);

            m_MaxCountField.RegisterCallback<ExecuteCommandEvent>(RulesModule.PickObject);
            m_MaxCountField.RegisterCallback<FocusInEvent>(evt => RulesDrawer.IgnoreBuildReplicators(true));
            m_MaxCountField.RegisterCallback<FocusOutEvent>(evt => RulesDrawer.IgnoreBuildReplicators(false));

            SetupProxyPresetUI(m_Entity);

            m_GroupDrillInButton = this.Q<Button>(k_GroupDrillIn);
            m_GroupDrillInButton.clicked += () =>
            {
                var ruleSet = m_Entity.GetComponent<ProxyRuleSet>();
                RulesModule.RuleSetInstance = ruleSet;
                RulesDrawer.BuildReplicatorsList();
            };

            if (!IsGroup)
                m_GroupDrillInButton.style.display = DisplayStyle.None;

            m_SimMatchCount = this.Q<Label>(k_SimMatchCountName);

            SetupReplicatorRow();

            if (IsGroup)
                m_AddButtonHoverElement.SetEnabled(false);

            CreateAddContentButton();

            RegisterCallback<KeyDownEvent>(OnKeyDown);
        }

        static void OnKeyDown(KeyDownEvent evt)
        {
            if (evt.keyCode == KeyCode.Delete || evt.keyCode == KeyCode.Backspace)
            {
                RulesModule.DeleteSelectedRuleNode();

                EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                {
                    label = k_DeleteKeyAnalyticsLabel
                });
            }
            else if (evt.keyCode == KeyCode.Space)
            {
                RulesModule.AddNode(SelectedNode);

                EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                {
                    label = k_AddKeyAnalyticsLabel
                });
            }
            else if (evt.keyCode == KeyCode.UpArrow)
            {
                SelectPrevious();

                EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                {
                    label = k_SelectPreviousAnalyticsLabel
                });
            }
            else if (evt.keyCode == KeyCode.DownArrow)
            {
                SelectNext();

                EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                {
                    label = k_SelectNextAnalyticsLabel
                });
            }
        }

        internal override void Select()
        {
            if (m_Entity == null)
            {
                Debug.LogWarning("MARSEntity missing; rebuilding list.");
                RulesDrawer.BuildReplicatorsList();
                return;
            }

            base.Select(m_Entity, m_Entity.transform, BackingReplicator.gameObject);

            m_Foldout.value = true;
        }

        internal sealed override bool HasChanged(MARSEntity entity)
        {
            if (BackingReplicator == null || BackingReplicator != entity)
                return true;

            if (!IsGroup)
            {
                var proxyTransform = entity.transform.GetChild(0);
                if (proxyTransform != null)
                {
                    if (proxyTransform.childCount != m_ContentRows.Length)
                        return true;

                    for (int i = 0; i < proxyTransform.childCount; i++)
                    {
                        var contentRow = m_ContentRows[i];
                        var content = proxyTransform.GetChild(i);
                        if (contentRow.HasChanged(content))
                            return true;
                    }
                }
            }

            return false;
        }

        void CollectObjects()
        {
            if (SimulatedObjectsManager.instance == null)
                return;

            if (BackingReplicator == null)
                return;

            var replicatorTransform = BackingReplicator.transform;
            if (replicatorTransform.childCount == 0)
                return;

            var proxy = replicatorTransform.GetChild(0).GetComponent<Proxy>();
            m_Entity = proxy;
            IsGroup = false;

            if (proxy == null)
            {
                var group = replicatorTransform.GetChild(0).GetComponent<ProxyGroup>();
                if (group == null)
                {
                    Debug.LogError("Replicator child must be either Proxy or ProxyGroup.", replicatorTransform);
                    return;
                }

                m_Entity = group;
                IsGroup = true;
            }
        }

        void SetupReplicatorRow()
        {
            UpdateReplicator();

            m_NodeContainer.Bind(m_ReplicatorSerializedObject);

            UpdateCountOption();
            UpdateProxyField();

            if (!IsGroup)
            {
                var entityTransform = m_Entity.transform;
                m_ContentRows = new ContentRow[entityTransform.childCount];
                for (int i = 0; i < entityTransform.childCount; i++)
                {
                    Transform child = entityTransform.GetChild(i);

                    if (!ContentRow.IsApplicableToTransform(child))
                        continue;

                    var contentRow = new ContentRow(BackingReplicator.transform, child);
                    m_ContentContainer.Add(contentRow);
                    m_ContentRows[i] = contentRow;
                }
            }

            var simObject = SimulatedObjectsManager.instance.GetCopiedTransform(BackingReplicator.transform);
            if (simObject == null)
            {
                m_SimMatchCount.style.display = DisplayStyle.None;
                return;
            }

            SimulatedReplicator = simObject.GetComponent<Replicator>();

            UpdateSimMatchCount();
        }

        void UpdateReplicator()
        {
            m_ReplicatorSerializedObject = new SerializedObject(BackingReplicator);
            m_ReplicatorSerializedObject.Update();

            m_MaxInstancesProperty = m_ReplicatorSerializedObject.FindProperty("m_MaxInstances");
        }

        void UpdateCountOption()
        {
            RulesModule.ReplicatorCountOption countOption;
            switch (BackingReplicator.MaxInstances)
            {
                case 0:
                    countOption = RulesModule.ReplicatorCountOption.Every;
                    break;
                case 1:
                    countOption = RulesModule.ReplicatorCountOption.One;
                    break;
                default:
                    countOption = RulesModule.ReplicatorCountOption.UpTo;
                    break;
            }

            m_MatchCountEnum.value = countOption;
            UpdateMatchDisplay((int) countOption);
        }

        void UpdateMatchDisplay(int count)
        {
            m_MaxCountField.style.display =
                count > 1 // More than 1: up-to
                    ? DisplayStyle.Flex
                    : DisplayStyle.None;
        }

        void UpdateProxyField()
        {
            m_ProxyField.value = m_Entity;
        }

        void UpdateSimMatchCount()
        {
            m_SimMatchCount.text = SimulatedReplicator.matchCount.ToString();
        }

        void OnChangeMatchCountDropdown(ChangeEvent<System.Enum> evt)
        {
            if (m_ReplicatorSerializedObject == null)
                return;

            var count = k_ReplicateOnEveryMatchSetting;

            switch ((RulesModule.ReplicatorCountOption) evt.newValue)
            {
                case RulesModule.ReplicatorCountOption.Every:
                    count = k_ReplicateOnEveryMatchSetting;
                    BackingReplicator.name = k_OnEveryObjectName;
                    break;
                case RulesModule.ReplicatorCountOption.One:
                    count = k_ReplicateOneMatchSetting;
                    BackingReplicator.name = k_OnOneObjectName;
                    break;
                case RulesModule.ReplicatorCountOption.UpTo:
                    count = k_ReplicatorUpToDefaultMatchCount;
                    BackingReplicator.name = $"{k_OnUpToObjectName}{count}";
                    break;
            }

            m_MaxInstancesProperty.intValue = count;
            UpdateMatchDisplay(count);

            EditorEvents.RulesUiUsed.Send(new RuleUiArgs
            {
                label = k_MatchCountDropdownChangedAnalyticsEvent
            });

            m_ReplicatorSerializedObject.ApplyModifiedProperties();
        }

        void OnMaxInstanceChanged(ChangeEvent<int> evt)
        {
            var newCount = evt.newValue;
            if (newCount >= 1)
                return;

            BackingReplicator.name = $"{k_OnUpToObjectName}{newCount.ToString()}";

            EditorEvents.RulesUiUsed.Send(new RuleUiArgs
            {
                label = k_MaxInstancesChangedAnalyticsEvent
            });
        }

        protected override void OnAddButton()
        {
            RulesModule.AddContent(m_Entity.transform);

            EditorEvents.RulesUiUsed.Send(new RuleUiArgs
            {
                label = k_AddButtonReplicatorAnalyticsLabel
            });
        }
    }
}
