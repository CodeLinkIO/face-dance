using System;
using Unity.MARS.Behaviors;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Rules.RulesEditor
{
    class ProxyActionsDropdown : AdvancedDropdown
    {
        const string k_ProxyActionsLabel = "Proxy Actions";
        const string k_MaterialLabel = "Build Surface";
        const string k_SpawnObjectLabel = "Spawn Object";

        internal ProxyActionsDropdown(AdvancedDropdownState state) : base(state)
        {
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            var root = new AdvancedDropdownItem(k_ProxyActionsLabel);

            root.AddChild(new ActionsDropdownItem(k_SpawnObjectLabel, () =>
            {
                RulesModule.Pick<GameObject>(obj =>
                {
                    if (obj == null)
                        return;

                    var go = UnityObject.Instantiate(obj);
                    Undo.RegisterCreatedObjectUndo(go, $"Add content: {go.name}");

                    RulesModule.NewObject = go.transform;
                });
            }));

            root.AddChild(new ActionsDropdownItem(k_MaterialLabel, () =>
            {
                RulesModule.Pick<Material>(mat =>
                {
                    if (mat == null)
                        return;

                    var buildSurfaceObject = RulesModule.CreateBuildSurfaceObject(mat);
                    RulesModule.NewObject = buildSurfaceObject.transform;
                });
            }));

            return root;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            (item as ActionsDropdownItem)?.Callback();
        }
    }

    class ProxyGroupActionsDropdown : AdvancedDropdown
    {
        const string k_GroupActionsLabel = "Group Action";

        const string k_NotImplementedErrorMessage = "Not implemented.";

        internal ProxyGroupActionsDropdown(AdvancedDropdownState state) : base(state)
        {
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            var root = new AdvancedDropdownItem(k_GroupActionsLabel);

            root.AddChild(new ActionsDropdownItem(
                k_GroupActionsLabel, () =>
                    Debug.LogError(k_NotImplementedErrorMessage)));

            return root;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            (item as ActionsDropdownItem)?.Callback();
        }
    }

    class ContentActionsDropdown : AdvancedDropdown
    {
        const string k_ContentActionsLabel = "Content Actions";
        const string k_RandomizeTransformLabel = "Randomize Transform";
        const string k_ApplyForcesLabel = "Apply Forces";
        const string k_ScatterLabel = "Scatter";

        internal ContentActionsDropdown(AdvancedDropdownState state) : base(state)
        {
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            var root = new AdvancedDropdownItem(k_ContentActionsLabel);

            root.AddChild(new ActionsDropdownItem(
                k_ApplyForcesLabel, CreateActionObject<ApplyForces>));
            root.AddChild(new ActionsDropdownItem(
                k_RandomizeTransformLabel, CreateActionObject<RandomizeTransform>));
            root.AddChild(new ActionsDropdownItem(
                k_ScatterLabel, CreateActionObject<Scatter>));

            return root;
        }

        static void CreateActionObject<T>() where T : ContentAction
        {
            var g = new GameObject(typeof(T).Name);
            Undo.RegisterCreatedObjectUndo(g, $"Add {g.name} action");
            g.AddComponent<T>();
                    g.transform.parent = RulesModule.NewObjectParent;
                    g.transform.hideFlags = HideFlags.HideInInspector;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            (item as ActionsDropdownItem)?.Callback();
        }
    }

    class ActionsDropdownItem : AdvancedDropdownItem
    {
        internal static Action ActionCreated;

        public readonly Action Callback;

        public ActionsDropdownItem(string name, Action callback) : base(name)
        {
            Callback += callback;
            Callback += ActionCreated;
        }
    }
}
