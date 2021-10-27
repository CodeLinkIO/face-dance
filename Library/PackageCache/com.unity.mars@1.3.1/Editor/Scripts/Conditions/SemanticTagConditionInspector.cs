using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.MARS;
using Unity.MARS.Attributes;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using Unity.MARS.Query;
using UnityEditor.IMGUI.Controls;
using UnityEditor.MARS.Authoring;
using UnityEngine;

namespace UnityEditor.MARS
{
    [ComponentEditor(typeof(SemanticTagCondition))]
    class SemanticTagConditionInspector : ComponentInspector
    {
        const int k_KnownTagsButtonWidth = 20;

        SerializedPropertyData m_TraitNameProperty;
        SerializedPropertyData m_MatchRuleProperty;

        public override void OnEnable()
        {
            base.OnEnable();
            m_TraitNameProperty = serializedObject.FindSerializedPropertyData("m_TraitName");
            m_MatchRuleProperty = serializedObject.FindSerializedPropertyData("m_MatchRule");
        }

        void DoTraitNameChanged()
        {
            serializedObject.ApplyModifiedProperties();
            var marsSession = MARSSession.Instance;
            if (marsSession != null)
                marsSession.CheckCapabilities();

            isDirty = true;
        }

        public override void OnInspectorGUI()
        {
            if (isDirty)
                CleanUp();

            serializedObject.Update();

            Rect dropdownButtonRect;

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    EditorGUIUtils.PropertyField(m_TraitNameProperty);
                    dropdownButtonRect = GUILayoutUtility.GetRect(k_KnownTagsButtonWidth, k_KnownTagsButtonWidth);
                }

                if (check.changed)
                {
                    DoTraitNameChanged();
                }
            }

            dropdownButtonRect.width = k_KnownTagsButtonWidth;
            const int dropdownButtonVerticalPadding = 1;
            dropdownButtonRect.y += dropdownButtonVerticalPadding;
            if (EditorGUI.DropdownButton(dropdownButtonRect, GUIContent.none, FocusType.Passive))
            {
                var dropdown = new KnownTraitsDropdown(null,
                    serializedObject.targetObject as SemanticTagCondition, DoTraitNameChanged);

                dropdown.Show(dropdownButtonRect);
            }

            EditorGUIUtils.PropertyField(m_MatchRuleProperty);

            MarsCompareTool.DrawComponentControls(target as SemanticTagCondition);

            serializedObject.ApplyModifiedProperties();
        }
    }

    internal class KnownTraitsDropdown : AdvancedDropdown
    {
        SemanticTagCondition m_SemanticTagCondition;
        Action m_DoTraitNameChanged;

        public KnownTraitsDropdown(AdvancedDropdownState state, SemanticTagCondition condition, Action doTraitNameChanged) : base(state)
        {
            m_SemanticTagCondition = condition;
            m_DoTraitNameChanged = doTraitNameChanged;
            minimumSize = new Vector2(150, 200);
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            var root = new AdvancedDropdownItem("Known Traits");
            var traitsRoot = new AdvancedDropdownItem("Trait");
            var semanticsRoot = new AdvancedDropdownItem("Semantic Tag");
            root.AddChild(traitsRoot);
            root.AddChild(semanticsRoot);

            var knownTraits = new List<TraitDefinition>();

            var marsSession = MARSSession.Instance;
            if (marsSession != null && marsSession.requirements != null)
            {
                var requiredNames = marsSession.requirements.TraitRequirements;
                knownTraits.AddRange(requiredNames.Select(k => k.Definition));
            }

            var defaultTraitNames = typeof(TraitDefinitions)
                .GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy )
                .Select(k => k.GetValue(null) as TraitDefinition)
                .Where(k => (k!=null));
            knownTraits.AddRange(defaultTraitNames);

            var finalList = knownTraits
                .Distinct()
                .OrderBy(k => !IsSemanticTrait(k))
                .ThenBy(k => k.TraitName)
                .ToList();

            foreach (var tagInfo in finalList)
            {
                var displayName = tagInfo.TraitName;
                var tagName = tagInfo.TraitName;

                var item = new KnownTraitDropdownItem(displayName, () =>
                {
                    var st = m_SemanticTagCondition;
                    Undo.RecordObject(st, "Set trait name");
                    st.SetTraitName(tagName);
                    m_DoTraitNameChanged();
                });

                if (!IsSemanticTrait(tagInfo))
                {
                    item.name += " (" + tagInfo.Type.Name + ")";
                    traitsRoot.AddChild(item);
                }
                else
                {
                    semanticsRoot.AddChild(item);
                }
            }

            return root;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            (item as KnownTraitDropdownItem)?.Callback();
        }

        class KnownTraitDropdownItem : AdvancedDropdownItem
        {
            public readonly Action Callback;

            public KnownTraitDropdownItem(string name, Action callback) : base(name)
            {
                Callback = callback;
            }
        }

        static bool IsSemanticTrait(TraitDefinition traitDefinition)
        {
            return (typeof(bool) == traitDefinition.Type) ;
        }
    }
}
