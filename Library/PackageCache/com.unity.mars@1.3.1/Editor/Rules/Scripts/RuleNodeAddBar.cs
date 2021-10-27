using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unity.MARS.Rules.RulesEditor
{
    class RuleNodeAddBar : VisualElement
    {
        const string k_UndoFormat = "move '{0}'";

        const int k_HitBoxHeight = 12;
        const int k_VisualHeight = 4;

        const int k_MidHitBoxY = k_HitBoxHeight / 2 - k_VisualHeight / 2;
        const int k_Offset = k_HitBoxHeight / 2;
        const int k_Radius = k_VisualHeight / 2;

        readonly Color k_AddBarColor = new Color(1, 0.792f, 0.475f); // Match `.ruleNode:hover` color

        const string k_AddBarAnalyticsLabel = "Add bar";

        static VisualElement s_RootVisualElement;
        static List<RuleNodeAddBar> s_AddBars = new List<RuleNodeAddBar>();
        static RuleNodeAddBar s_PrevBar;

        RuleNode m_DraggedRow;
        Transform m_DragDropParent;
        int m_DragDropSiblingIndex;
        bool m_IsLastAddBarForRule = true;

        VisualElement m_AddBarVisual;
        RuleNode m_TargetRuleNode;

        internal static List<(VisualElement addBarLocation, RuleNode)> AddBarLocations { get; } = new List<(VisualElement, RuleNode)>();

        RuleNodeAddBar(RuleNode ruleNode, float width)
        {
            m_TargetRuleNode = ruleNode;

            m_AddBarVisual = new VisualElement();
            m_AddBarVisual.style.width = width;
            m_AddBarVisual.style.height = k_VisualHeight;
            m_AddBarVisual.style.top = k_MidHitBoxY;

            m_AddBarVisual.style.borderTopLeftRadius = k_Radius;
            m_AddBarVisual.style.borderTopRightRadius = k_Radius;
            m_AddBarVisual.style.borderBottomLeftRadius = k_Radius;
            m_AddBarVisual.style.borderBottomRightRadius = k_Radius;

            m_AddBarVisual.style.position = Position.Absolute; // Don't affect layout

            RegisterCallback<DragEnterEvent>(OnDragEnter);
            RegisterCallback<DragUpdatedEvent>(OnDragUpdated);
            RegisterCallback<DragPerformEvent>(OnDragAndDropPerformed);

            RegisterCallback<MouseOverEvent>(OnMouseOver);
            RegisterCallback<MouseOutEvent>(OnMouseOut);
            RegisterCallback<MouseDownEvent>(OnMouseDown);

            Add(m_AddBarVisual);
            style.width = width;
            style.height = k_HitBoxHeight;
        }

        internal static void CreateAddBarsAtLocations(VisualElement root)
        {
            s_RootVisualElement = root;
            foreach (var (sourceVisualElement, ruleNode) in AddBarLocations)
            {
                if (ruleNode is ContentRow contentRow)
                {
                    if (!contentRow.ContentSupportsActions)
                        continue;
                }

                sourceVisualElement.RegisterCallback((GeometryChangedEvent evt, RuleNode node) =>
                {
                    var worldBound = ((VisualElement) evt.target).worldBound;
                    var width = worldBound.width;

                    var addBar = new RuleNodeAddBar(node, width);
                    root.Add(addBar);
                    s_AddBars.Add(addBar);

                    if (!(node is ReplicatorRow) && s_PrevBar != null)
                        s_PrevBar.m_IsLastAddBarForRule = false;

                    s_PrevBar = addBar;

                    addBar.style.position = Position.Absolute;
                    addBar.style.left = worldBound.x - root.worldBound.x;
                    addBar.style.top = worldBound.y - root.worldBound.y - k_Offset;
                }, ruleNode);
            }
        }

        internal static void ClearAll()
        {
            foreach (var addBar in s_AddBars)
            {
                if (s_RootVisualElement.Contains(addBar))
                    s_RootVisualElement.Remove(addBar);
            }

            s_AddBars.Clear();
        }

        void OnMouseOver(MouseOverEvent evt)
        {
            m_AddBarVisual.style.backgroundColor = k_AddBarColor;
            RuleNode.HoveredAddBarNode = m_TargetRuleNode;
        }

        void OnMouseOut(MouseOutEvent evt)
        {
            m_AddBarVisual.style.backgroundColor = Color.clear;
            RuleNode.HoveredAddBarNode = null;
        }

        void OnMouseDown(MouseDownEvent evt)
        {
            if (evt.button == 0)
            {
                EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                {
                    label = k_AddBarAnalyticsLabel
                });

                RulesModule.AddNode(m_TargetRuleNode);
            }
        }

        void OnDragEnter(DragEnterEvent evt)
        {
            m_DraggedRow = DragAndDrop.GetGenericData(RuleNode.DragDataTitle) as RuleNode;
        }

        void OnDragUpdated(DragUpdatedEvent evt)
        {
            var valid = SetupDragDropParentIfValid();

            DragAndDrop.visualMode =
                valid ? DragAndDropVisualMode.Move : DragAndDropVisualMode.Rejected;
        }

        void OnDragAndDropPerformed(DragPerformEvent evt)
        {
            Undo.SetTransformParent(m_DraggedRow.BackingObject.transform, m_DragDropParent, string.Format(k_UndoFormat, m_DraggedRow.BackingObject.name));
            m_DraggedRow.BackingObject.transform.SetSiblingIndex(m_DragDropSiblingIndex);
            RulesDrawer.BuildReplicatorsList();
        }

        bool SetupDragDropParentIfValid()
        {
            m_DragDropParent = null;

            if (m_DraggedRow == null)
                return false;

            m_DragDropSiblingIndex = m_TargetRuleNode.BackingObject.transform.GetSiblingIndex();

            if (m_DraggedRow is ReplicatorRow && m_IsLastAddBarForRule)
            {
                m_DragDropParent = RulesModule.RuleSetInstance.transform;
                return true;
            }

            switch (m_TargetRuleNode)
            {
                case ReplicatorRow row:
                    if (!(m_DraggedRow is ContentRow))
                        return false;

                    var targetReplicatorRow = row;
                    if (targetReplicatorRow.IsGroup)
                        return false;

                    m_DragDropParent = targetReplicatorRow.BackingProxy.transform;
                    return true;

                case ContentRow _:
                    switch (m_DraggedRow)
                    {
                        case ActionRow _:
                            m_DragDropParent = m_TargetRuleNode.BackingObject.transform;
                            return true;
                        case ContentRow _:
                            m_DragDropParent = m_TargetRuleNode.ContainerObject;
                            return true;
                        default:
                            return false;
                    }

                case ActionRow _:
                    if (!(m_DraggedRow is ActionRow))
                        return false;

                    m_DragDropParent = m_TargetRuleNode.BackingObject.transform.parent;
                    return true;
            }

            return false;
        }
    }
}
