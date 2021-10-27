using System.Collections.Generic;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.MARS.Simulation;
using UnityEngine;
using UnityEngine.UIElements;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Rules.RulesEditor
{
    abstract class RuleNode : BindableElement
    {
        static class Styles
        {
            internal static readonly GUIContent AddNewRuleContent = new GUIContent("Add new Rule");
            internal static readonly GUIContent SelectSimulatedObjectsContent = new GUIContent("Select simulated objects");
            internal static readonly GUIContent MoveUpContent = new GUIContent("Move Up");
            internal static readonly GUIContent MoveDownContent = new GUIContent("Move Down");
            internal static readonly GUIContent DeleteContent = new GUIContent("Delete");

            internal const string NoProxyFormat = "No Proxy found containing {0}";
            internal const string AddContentFormat = "Add Content to '{0}'";
            internal const string AddActionFormat = "Add Action to '{0}'";
        }

        internal const string DragDataTitle = "RuleNode";

        protected const string k_Directory = "Packages/com.unity.mars/Editor/Rules/Scripts/";
        const string k_RuleNodeStylePath = k_Directory + "RuleNode.uss";

        const string k_RuleNodeContainerName = "ruleNodeContainer";
        const string k_AddBarLocationName = "addBarLocation";
        const string k_AddButtonTemplateName = "AddButton";
        const string k_AddButtonHoverElementName = "addButtonHoverElement";
        const string k_AddButtonName = "addButton";

        const string k_DragTitle = "RuleView";

        const string k_ContextMenuAnalyticsLabel = "Context Menu / ";
        const string k_AddRuleAnalyticsLabel = k_ContextMenuAnalyticsLabel + "Add new rule";
        const string k_AddContentToProxyAnalyticsLabel = k_ContextMenuAnalyticsLabel + "Add content to proxy";
        const string k_AddActionToContentButtonAnalyticsLabel = k_ContextMenuAnalyticsLabel + "Add action to content";
        const string k_SelectSimulatedObjectsAnalyticsLabel = k_ContextMenuAnalyticsLabel + "Select simulated objects";
        const string k_SelectSimulatedGroupAnalyticsLabel = k_ContextMenuAnalyticsLabel + "Select simulated group objects";
        const string k_MoveUpAnalyticsLabel = k_ContextMenuAnalyticsLabel + "Move Up";
        const string k_MoveDownAnalyticsLabel = k_ContextMenuAnalyticsLabel + "Move Down";
        const string k_DeleteAnalyticsLabel = k_ContextMenuAnalyticsLabel + "Delete";

        internal static RuleNode SelectedNode;
        internal static RuleNode HoveredAddBarNode;
        internal static RuleNode LastCreatedRuleNode;

        protected VisualElement m_NodeContainer;
        protected VisualElement m_AddButtonHoverElement;
        Button m_AddButton;

        bool m_GotMouseDown;
        RuleNode m_NextNode;
        RuleNode m_PreviousNode;

        RuleNode NextNode
        {
            get { return m_NextNode; }
            set
            {
                value.m_PreviousNode = this;
                m_NextNode = value;
            }
        }

        internal virtual Transform ContainerObject { get { return null; } }
        internal virtual GameObject BackingObject { get { return null; } }

        protected RuleNode()
        {
            if (LastCreatedRuleNode != null)
                LastCreatedRuleNode.NextNode = this;

            LastCreatedRuleNode = this;

            var ruleNodeStyleAsset = AssetDatabase.LoadAssetAtPath<StyleSheet>(k_RuleNodeStylePath);
            styleSheets.Add(ruleNodeStyleAsset);
        }

        protected virtual void SetupUI()
        {
            m_NodeContainer = this.Q<VisualElement>(k_RuleNodeContainerName);

            m_NodeContainer.RegisterCallback<MouseDownEvent>(OnMouseDown);
            m_NodeContainer.RegisterCallback<MouseMoveEvent>(OnMouseMove);
            m_NodeContainer.RegisterCallback<MouseUpEvent>(OnMouseUp);

            var addBarLocation = this.Q<VisualElement>(k_AddBarLocationName);
            if (addBarLocation != null)
                RuleNodeAddBar.AddBarLocations.Add((addBarLocation, this));

            var addButtonTemplate = this.Q<TemplateContainer>(k_AddButtonTemplateName);
            if (addButtonTemplate != null)
            {
                m_AddButtonHoverElement = addButtonTemplate.Q<VisualElement>(k_AddButtonHoverElementName);
                m_AddButton = addButtonTemplate.Q<Button>(k_AddButtonName);

                m_AddButtonHoverElement.RegisterCallback((MouseOverEvent evt, Button addButton) =>
                {
                    addButton.style.display = DisplayStyle.Flex;
                }, m_AddButton);

                m_AddButtonHoverElement.RegisterCallback((MouseOutEvent evt, Button addButton) =>
                {
                    addButton.style.display = DisplayStyle.None;
                }, m_AddButton);

                m_AddButton.clicked += OnAddButton;
            }
        }

        void OnMouseDown(MouseDownEvent e)
        {
            if (e.button == 0)
                m_GotMouseDown = true;
            if (e.button == 1)
                DisplayContextMenu(e.originalMousePosition);
        }

        void OnMouseMove(MouseMoveEvent e)
        {
            if (m_GotMouseDown && e.button == 0)
            {
                StartDrag();
                m_GotMouseDown = false;
            }
        }

        void OnMouseUp(MouseUpEvent e)
        {
            if (m_GotMouseDown && e.button == 0)
            {
                m_GotMouseDown = false;
                Select();
            }
        }

        void StartDrag()
        {
            // DragAndDrop.StartDrag prints an error if the current event is not a drag
            var eventType = Event.current.type;
            if (!(eventType == EventType.MouseDown || eventType == EventType.MouseDrag))
                return;

            DragAndDrop.PrepareStartDrag();

            // ReSharper disable once CoVariantArrayConversion
            DragAndDrop.objectReferences = new [] {BackingObject};
            DragAndDrop.SetGenericData(DragDataTitle, this);
            DragAndDrop.visualMode = DragAndDropVisualMode.Move;
            DragAndDrop.StartDrag(k_DragTitle);
        }

        void DisplayContextMenu(Vector2 mousePosition)
        {
            var menu = new GenericMenu();
            var backingTransform = BackingObject.transform;

            if (this is ReplicatorRow || this is ProxyRow || this is ContentRow)
            {
                Transform proxyTransform = null;

                switch (this)
                {
                    case ReplicatorRow _:
                        menu.AddItem(Styles.AddNewRuleContent, false, () =>
                        {
                            RulesModule.DoAddRule();

                            EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                            {
                                label = k_AddRuleAnalyticsLabel
                            });
                        });

                        proxyTransform = ((ReplicatorRow) this).Entity.transform;

                        break;
                    case ProxyRow _:
                        proxyTransform = ((ProxyRow) this).ContainerObject;
                        break;
                    case ContentRow _:
                    {
                        var container = ((ContentRow) this).ContainerObject;
                        var proxy = container.GetComponent<Proxy>();
                        if (proxy != null)
                        {
                            proxyTransform = proxy.transform;
                        }
                        else
                        {
                            proxy = container.GetComponentInParent<Proxy>();
                            if (proxy != null)
                            {
                                proxyTransform = proxy.transform;
                            }
                            else
                            {
                                Debug.LogErrorFormat(BackingObject, Styles.NoProxyFormat, name);
                                return;
                            }
                        }

                        break;
                    }
                }

                if (proxyTransform == null)
                {
                    Debug.LogError("Could not find Proxy");
                    return;
                }

                menu.AddItem(new GUIContent(string.Format(Styles.AddContentFormat, proxyTransform.name)), false, () =>
                {
                    EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                    {
                        label = k_AddContentToProxyAnalyticsLabel
                    });

                    RulesModule.AddContent(proxyTransform, mousePosition);
                });

                if (this is ReplicatorRow || this is ProxyRow)
                {
                    menu.AddSeparator(string.Empty);

                    var simulatedObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
                    if (simulatedObjectsManager == null)
                    {
                        menu.AddDisabledItem(Styles.SelectSimulatedObjectsContent);
                    }
                    else
                    {
                        if (this is ReplicatorRow)
                        {
                            var replicatorRow = (ReplicatorRow) this;
                            if (replicatorRow.SimulatedReplicator == null)
                            {
                                menu.AddDisabledItem(Styles.SelectSimulatedObjectsContent);
                            }
                            else
                            {
                                menu.AddItem(Styles.SelectSimulatedObjectsContent, false, () =>
                                {
                                    SelectSimulatedReplicatorChildren();

                                    EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                                    {
                                        label = k_SelectSimulatedObjectsAnalyticsLabel
                                    });
                                });
                            }

                        }
                        else if (this is ProxyRow)
                        {
                            var sceneObject = ((ProxyRow) this).BackingObject.transform;
                            var simulatedProxy = simulatedObjectsManager.GetCopiedTransform(sceneObject);

                            if (simulatedProxy == null)
                            {
                                menu.AddDisabledItem(Styles.SelectSimulatedObjectsContent);
                            }
                            else
                            {
                                menu.AddItem(Styles.SelectSimulatedObjectsContent, false, () =>
                                {
                                    SelectSimulatedGroupChildren();

                                    EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                                    {
                                        label = k_SelectSimulatedGroupAnalyticsLabel
                                    });
                                });
                            }
                        }
                    }
                }
            }

            if (this is ContentRow || this is ActionRow)
            {
                var contentTransform = this is ContentRow ? BackingObject.transform : ContainerObject;
                var contentName = contentTransform.name;
                var contentSupportsActions = true;
                if (this is ContentRow)
                {
                    if (!((ContentRow) this).ContentSupportsActions)
                    {
                        contentSupportsActions = false;
                    }
                }

                if (contentSupportsActions)
                {
                    menu.AddItem(new GUIContent(string.Format(Styles.AddActionFormat, contentName)), false,
                        () =>
                        {
                            RulesModule.AddAction(contentTransform, mousePosition);

                            EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                            {
                                label = k_AddActionToContentButtonAnalyticsLabel
                            });
                        });
                }
            }

            menu.AddSeparator(string.Empty);

            var siblingIndex = backingTransform.GetSiblingIndex();
            if (siblingIndex > 0)
            {
                menu.AddItem(Styles.MoveUpContent, false, () =>
                {
                    backingTransform.SetSiblingIndex(siblingIndex - 1);
                    RulesDrawer.BuildReplicatorsList();

                    EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                    {
                        label = k_MoveUpAnalyticsLabel
                    });
                });
            }
            else
            {
                menu.AddDisabledItem(Styles.MoveUpContent);
            }

            var backingParent = backingTransform.parent;
            if (backingParent == null || siblingIndex == backingParent.childCount - 1)
            {
                menu.AddDisabledItem(Styles.MoveDownContent);
            }
            else
            {
                menu.AddItem(Styles.MoveDownContent, false, () =>
                {
                    backingTransform.SetSiblingIndex(siblingIndex + 1);
                    RulesDrawer.BuildReplicatorsList();

                    EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                    {
                        label = k_MoveDownAnalyticsLabel
                    });
                });
            }

            menu.AddItem(Styles.DeleteContent, false, () =>
            {
                Undo.DestroyObjectImmediate(BackingObject);
                RulesDrawer.BuildReplicatorsList();

                EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                {
                    label = k_DeleteAnalyticsLabel
                });
            });

            menu.ShowAsContext();
        }

        void SelectSimulatedReplicatorChildren()
        {
            var replicatorRow = (ReplicatorRow) this;
            var sceneObject = replicatorRow.BackingReplicator.transform;
            var simulatedObject = replicatorRow.SimulatedReplicator.transform;

            var simulatedMatches = CollectionPool<List<GameObject>, GameObject>.GetCollection();
            foreach (var proxy in simulatedObject.GetComponentsInChildren<Proxy>())
            {
                foreach (Transform child in proxy.transform)
                {
                    if (child.gameObject.activeInHierarchy)
                    {
                        simulatedMatches.Add(child.gameObject);
                    }
                }
            }

            RulesModule.FrameObject(sceneObject);

            // ReSharper disable once CoVariantArrayConversion
            Selection.objects = simulatedMatches.ToArray();
            CollectionPool<List<GameObject>, GameObject>.RecycleCollection(simulatedMatches);
        }

        void SelectSimulatedGroupChildren()
        {
            var simulatedObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            var sceneObject = ((ProxyRow) this).BackingObject.transform;
            var simulatedProxy = simulatedObjectsManager.GetCopiedTransform(sceneObject);
            var group = sceneObject.GetComponentInParent<ProxyGroup>();
            var sceneProxy = sceneObject.GetComponent<Proxy>();

            group.RepopulateChildList();
            var idx = group.IndexOfChild(sceneProxy);

            var simulatedMatches = CollectionPool<List<GameObject>, GameObject>.GetCollection();
            var parentReplicator = simulatedProxy.GetComponentInParent<Replicator>();
            foreach (var simGrp in parentReplicator.GetComponentsInChildren<ProxyGroup>())
            {
                var groupChildren = CollectionPool<List<Proxy>, Proxy>.GetCollection();
                simGrp.GetChildList(groupChildren);

                foreach (Transform child in groupChildren[idx].transform)
                {
                    if (child.gameObject.activeInHierarchy)
                    {
                        simulatedMatches.Add(child.gameObject);
                    }
                }

                CollectionPool<List<Proxy>, Proxy>.RecycleCollection(groupChildren);
            }

            RulesModule.FrameObject(sceneObject);

            // ReSharper disable once CoVariantArrayConversion
            Selection.objects = simulatedMatches.ToArray();
            CollectionPool<List<GameObject>, GameObject>.RecycleCollection(simulatedMatches);
        }

        protected void Select(UnityObject obj, Transform viewObject, GameObject selectedRuleNode)
        {
            SelectedNode = this;

            if (obj.GetType() == typeof(Transform))
                Selection.activeTransform = (Transform) obj;
            else
                RulesModule.SetSelectedComponent(obj);

            RulesModule.DisplayElementSelected(m_NodeContainer);
            RulesModule.SelectedRuleNode = selectedRuleNode;
            RulesModule.FrameObject(viewObject);

            EditorGUIUtility.PingObject(obj);
        }

        internal static void SelectPrevious()
        {
            SelectedNode.m_PreviousNode?.Select();
        }

        internal static void SelectNext()
        {
            SelectedNode.NextNode?.Select();
        }

        internal virtual void Select() { }

        protected virtual void OnAddButton() { }
    }
}
