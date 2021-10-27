using Unity.MARS;
using Unity.MARS.Actions;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using Unity.MARS.Forces;
using Unity.MARS.MARSUtils;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace UnityEditor.MARS.Forces.EditorExtensions
{
    static class ForcesMenuItemsRegions
    {
#if UNITY_EDITOR

        static ForceIconInfo[] s_ForceButtons = null;
        static bool s_IsShowingForces = false;

        const string k_AlignmentForcePrefix = "GameObject/MARS/Forces/";
        const string k_ProxyForcePrefix = "GameObject/MARS/Forces/";
        const string k_ForceDefaultGameObjectName = "ProxyForcesObject";
        const string k_ForceButtonAlignToCamera = "Align to Camera";
        const string k_ForceButtonAlignToOther = "Align to Other Proxy";
        const string k_ForceButtonRegionOccupied = "Occupied Region";
        const string k_ForceButtonRegionEmpty = "Padding Region";
        const string k_ForceButtonToSurfaceHorizontal = "Snap to Horizontal Surfaces";
        const string k_ForceButtonToSurfaceVertical = "Snap to Vertical Surfaces";
        const string k_ForceButtonToEdgeHorizontal = "Snap to Horizontal Edges";
        const string k_ForceButtonToEdgeVertical = "Snap to Vertical Edges";
        const string k_ForceButtonToPlanarRegion = "Snap to Plane 2D";
        const string k_ForceMainCameraError = k_ForceButtonAlignToCamera + ": No valid camera in the scene, please create one, or use " + k_ForceButtonAlignToOther;
        const int k_ForceMenuPriority = 15;
        const int k_ForceMenuAlignPriority = 14;
        const float k_DefaultCreationScale = 0.25f;
        static readonly GUIContent k_AddForcesButtonContent = new GUIContent("Add Force...", "Add a Proxy Force to this object.");
        static readonly GUIContent k_StepManyButtonContent = new GUIContent("Converge Forces", "");
        static readonly GUIContent k_StepOneButtonContent = new GUIContent("Step Forces", "");

        class ForceIconInfo
        {
            public DarkLightIconPair Texture { get; set; }
            public string Title { get; set; }
            public string Tooltip { get; set; }
            public System.Action<MenuCommand> Callback { get; set; }

            public ForceIconInfo(string _title, DarkLightIconPair _tex, string _tooltip, System.Action<MenuCommand> _act)
            {
                Texture = _tex;
                Title = _title;
                Tooltip = _tooltip;
                Callback = _act;
            }
        }


        [UnityEditor.MenuItem(k_AlignmentForcePrefix + k_ForceButtonRegionOccupied, false, k_ForceMenuPriority)]
        static void EditorCreateSubRegion_Occupied(MenuCommand command)
        {
            var region = AddOccupancyRegion(false, command);
            region.regionTransform.localPosition = Vector3.up * (k_DefaultCreationScale * 0.5f);
            AfterConfiguredComponent(region.regionTransform);

            EditorEnsureProxyConfigurationOnGameobject(region.gameObject);
        }

        [UnityEditor.MenuItem(k_AlignmentForcePrefix + k_ForceButtonRegionEmpty, false, k_ForceMenuPriority)]
        static void EditorCreateSubRegion_Empty(MenuCommand command)
        {
            var region = AddOccupancyRegion(true, command);
            region.regionTransform.localPosition = Vector3.up * (k_DefaultCreationScale * 0.5f);
            AfterConfiguredComponent(region.regionTransform);

            EditorEnsureProxyConfigurationOnGameobject(region.gameObject);
        }

        [UnityEditor.MenuItem(k_AlignmentForcePrefix + k_ForceButtonToSurfaceHorizontal, false, k_ForceMenuPriority)]
        static void EditorCreateSubRegion_Touching_Surface(MenuCommand command)
        {
            var region = AddTowardsRegion(MarsPlaneAlignment.HorizontalUp, false, command);
            region.regionTransform.localScale = new Vector3(k_DefaultCreationScale, 0.1f * k_DefaultCreationScale, k_DefaultCreationScale);
            AfterConfiguredComponent(region.regionTransform);
            EditorEnsureProxyConfigurationOnGameobject(region.gameObject);
        }

        [UnityEditor.MenuItem(k_AlignmentForcePrefix + k_ForceButtonToSurfaceVertical, false, k_ForceMenuPriority)]
        static void EditorCreateSubRegion_Touching_Wall(MenuCommand command)
        {
            var region = AddTowardsRegion(MarsPlaneAlignment.Vertical, false, command);
            region.regionTransform.localScale = new Vector3(k_DefaultCreationScale, k_DefaultCreationScale, 0.1f * k_DefaultCreationScale);
            region.regionTransform.localPosition = Vector3.up * (k_DefaultCreationScale * 0.5f);
            AfterConfiguredComponent(region.regionTransform);
            EditorEnsureProxyConfigurationOnGameobject(region.gameObject);
        }

        [UnityEditor.MenuItem(k_AlignmentForcePrefix + k_ForceButtonToEdgeHorizontal, false, k_ForceMenuPriority)]
        static void EditorCreateSubRegion_Touching_Edge_Horizontal(MenuCommand command)
        {
            var region = AddTowardsRegion(MarsPlaneAlignment.HorizontalUp, true, command);
            region.regionTransform.localScale = new Vector3(k_DefaultCreationScale, 0.1f * k_DefaultCreationScale, 0.1f * k_DefaultCreationScale);
            region.regionTransform.localPosition = ( Vector3.forward ) * (k_DefaultCreationScale * 0.5f);
            AfterConfiguredComponent(region.regionTransform);
            EditorEnsureProxyConfigurationOnGameobject(region.gameObject);
        }


        [UnityEditor.MenuItem(k_AlignmentForcePrefix + k_ForceButtonToEdgeVertical, false, k_ForceMenuPriority)]
        static void EditorCreateSubRegion_Touching_Edge_Vertical(MenuCommand command)
        {
            var region = AddTowardsRegion(MarsPlaneAlignment.Vertical, true, command);
            region.regionTransform.localScale = new Vector3(0.1f * k_DefaultCreationScale, k_DefaultCreationScale, 0.1f * k_DefaultCreationScale);
            region.regionTransform.localPosition = ( Vector3.right ) * (k_DefaultCreationScale * 0.5f);
            AfterConfiguredComponent(region.regionTransform);
            EditorEnsureProxyConfigurationOnGameobject(region.gameObject);
        }


        [UnityEditor.MenuItem(k_AlignmentForcePrefix + k_ForceButtonToPlanarRegion, false, k_ForceMenuPriority)]
        static void EditorCreateSubRegion_Planar(MenuCommand command)
        {
            var selection = CurrentEditorSelection(command);
            var forces = EnsureProxyForcesOnGameobject(ref selection);
            if (!forces.GetComponent<ProxyRegionForcePlane2D>())
            {
                var plane = Undo.AddComponent<ProxyRegionForcePlane2D>(forces.gameObject);
                plane.KeepMatchPlane = true;
                plane.UpdateFromSources();
                AfterConfiguredComponent(plane);
            }
            EditorEnsureProxyConfigurationOnGameobject(forces.gameObject);
        }

        static void EditorTryApplyMaterial(GameObject gm, Material mat)
        {
            if (mat)
                gm.GetComponent<MeshRenderer>().sharedMaterial = mat;
            else
                gm.GetComponent<MeshRenderer>().enabled = false;
        }

        public static Proxy EditorEnsureProxyOnThisOrParents(GameObject gm)
        {
            ProxyForcesFieldSolverModule session = null;
            ProxyForcesFieldSolverModule.EnsureInstance(gm, ref session);

            MARSSession.EnsureRuntimeState();

            var ans = gm.GetComponent<Proxy>();
            if (ans) return ans;
            ans = gm.GetComponentInParent<Proxy>();
            if (ans) return ans;

            return Undo.AddComponent<Proxy>(gm);
        }

        static void EditorEnsureProxyConfigurationOnGameobject(GameObject gameObject)
        {
            var proxy = gameObject.GetComponent<Proxy>();
            if (!proxy) return;

            var ips = proxy.GetComponent<IsPlaneCondition>();
            if (!ips)
            {
                var pc = proxy.GetComponent<PlaneSizeCondition>();
                if (!pc)
                {
                    Undo.AddComponent<IsPlaneCondition>(proxy.gameObject);
                }
            }

            var ta = proxy.GetComponent<TransformAction>();
            if (!ta)
            {
                var setPoseAction = Undo.AddComponent<SetPoseAction>(proxy.gameObject);
                ChangeProperty(ta, nameof(SetPoseAction.FollowMatchUpdates),false);
            }
            else if (ta is SetPoseAction)
            {
                ChangeProperty(ta, nameof(SetPoseAction.FollowMatchUpdates), false);
            }
            else if (ta is SetAlignedPoseAction)
            {
                ChangeProperty(ta, nameof(SetAlignedPoseAction.FollowMatchUpdates), false);
            }
        }

        static void ChangeProperty<T>(UnityObject changedObject, string propertyName, System.Action<SerializedProperty> doChange)
        {
            var serializedObject = new SerializedObject(changedObject);
            var property = serializedObject.FindProperty(propertyName);
            Debug.Assert(property != null);
            Debug.Assert(property.propertyType.ToString() == typeof(T).Name);
            doChange(property);
            serializedObject.ApplyModifiedProperties();
        }

        static void ChangeProperty(UnityObject changedObject, string propertyName, bool toValue)
        {
            ChangeProperty<bool>(changedObject, propertyName, (propertySetter) =>
            {
                propertySetter.boolValue = toValue;
            });
        }

        static void AfterConfiguredComponent(Component component)
        {
            EditorUtility.SetDirty(component);
        }

        static void EditorEnsureAlignmentCondition(Proxy proxy, MarsPlaneAlignment alignment)
        {
            var ac = proxy.GetComponent<AlignmentCondition>();
            if (ac) return;

            ac = Undo.AddComponent<AlignmentCondition>(proxy.gameObject);
            ac.alignment = alignment;
            AfterConfiguredComponent(ac);
        }

        public static ProxyForces EnsureProxyForcesOnGameobject(ref GameObject gameObject)
        {
            if (!gameObject)
            {
                gameObject = new GameObject();
                gameObject.name = k_ForceDefaultGameObjectName;
            }

            EditorEnsureProxyConfigurationOnGameobject(gameObject);

            var vc = gameObject.GetComponent<ProxyForces>();
            if (vc) return vc;

            vc = Undo.AddComponent<ProxyForces>(gameObject);
            return vc;
        }

        static GameObject CurrentEditorSelection(MenuCommand command)
        {
            var target = command.context;
            if (!target)
            {
                // if context is null, might have been from the gameobject menu
                var activeObject = UnityEditor.Selection.activeObject;
                if (activeObject)
                {
                    target = (activeObject as GameObject);
                    if (!target)
                    {
                        var comp = (activeObject as Component);
                        if (comp)
                        {
                            target = comp.gameObject;
                        }
                    }
                }
            }
            if (target is GameObject)
                return ((GameObject)target);

            if (target is Component)
                return ((Component)target).gameObject;

            return null;
        }

        static Transform EditorAddPlacementTransform(ref GameObject selection, string regionName, Material mat)
        {
            if (!selection)
            {
                selection = new GameObject();
                selection.name = k_ForceDefaultGameObjectName;
                Undo.RegisterCreatedObjectUndo(selection, k_ForceDefaultGameObjectName);
            }
            var newOb = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newOb.name = "Region " + regionName;
            newOb.transform.parent = selection.transform;
            newOb.transform.localPosition = Vector3.zero;
            newOb.transform.localRotation = Quaternion.identity;
            newOb.transform.localScale = Vector3.one * k_DefaultCreationScale;
            newOb.gameObject.GetComponent<Collider>().enabled = false;
            EditorTryApplyMaterial(newOb, mat);
            Undo.RegisterCreatedObjectUndo(newOb, newOb.name);
            return newOb.transform;
        }

        static ProxyRegionForceOccupancy AddOccupancyRegion(bool isEmpty, MenuCommand command)
        {
            var forcesPref = ForcesPreferences.instance;
            var selection = CurrentEditorSelection(command);
            var placement = EditorAddPlacementTransform( ref selection,
                isEmpty ? "Empty" : "Occupied",
                isEmpty ? forcesPref.ProxyForceRegionEmpty: forcesPref.ProxyForceRegionOccupied );
            var rf = Undo.AddComponent<ProxyRegionForceOccupancy>(selection);
            rf.regionTransform = placement.transform;
            rf.isPadding = isEmpty;
            AfterConfiguredComponent(rf);
            return rf;
        }

        static ProxyRegionForceTowards AddTowardsRegion(MarsPlaneAlignment alignment, bool isEdge, MenuCommand command)
        {
            var selection = CurrentEditorSelection(command);
            var placement = EditorAddPlacementTransform( ref selection,
                "towards " + alignment.ToString(),
                ForcesPreferences.instance.ProxyForceRegionTouching );
            var rf = Undo.AddComponent<ProxyRegionForceTowards>(selection);
            rf.regionTransform = placement.transform;
            rf.towardsAlignment = alignment;
            rf.towardsEdgeOnly = isEdge;
            AfterConfiguredComponent(rf);
            return rf;
        }

        public static bool DrawForcesInInspectorForMainProxy(UnityObject targetObject, bool alwaysShow=false)
        {
            if (!alwaysShow)
            {
                if (GUILayout.Button(k_AddForcesButtonContent, MarsEditorGUI.Styles.MiniFontButton))
                {
                    s_IsShowingForces = !s_IsShowingForces;
                }

                if (!s_IsShowingForces)
                    return false;
            }

            if (s_ForceButtons == null)
            {
                var icons = MarsUIResources.instance.ForcesIconData;
                var defTooltip = "";
                s_ForceButtons = new ForceIconInfo[]
                {
                    new ForceIconInfo(k_ForceButtonAlignToCamera, icons.AlignToCamera, defTooltip, EditorCreateAlignmentTo_ToCameraProxy),
                    new ForceIconInfo(k_ForceButtonAlignToOther, icons.AlignToProxy, defTooltip,EditorCreateAlignmentTo_OtherProxy),
                    new ForceIconInfo(k_ForceButtonRegionOccupied, icons.OccupyNormal, defTooltip, EditorCreateSubRegion_Occupied),
                    new ForceIconInfo(k_ForceButtonRegionEmpty, icons.OccupyPadding, defTooltip,EditorCreateSubRegion_Empty),
                    new ForceIconInfo(k_ForceButtonToSurfaceHorizontal, icons.SnapToSurfaceHorizontal, defTooltip, EditorCreateSubRegion_Touching_Surface),
                    new ForceIconInfo(k_ForceButtonToSurfaceVertical, icons.SnapToSurfaceVertical, defTooltip, EditorCreateSubRegion_Touching_Wall),
                    new ForceIconInfo(k_ForceButtonToEdgeHorizontal, icons.SnapToEdgeHorizontal, defTooltip, EditorCreateSubRegion_Touching_Edge_Horizontal),
                    new ForceIconInfo(k_ForceButtonToEdgeVertical, icons.SnapToEdgeVertical, defTooltip, EditorCreateSubRegion_Touching_Edge_Vertical),
                    new ForceIconInfo(k_ForceButtonToPlanarRegion, icons.SnapToSurfaceHorizontal, defTooltip, EditorCreateSubRegion_Planar),
                };
            }

            var availableWidth = EditorGUIUtility.currentViewWidth;// .currentViewWidth;
            EditorGUILayout.HorizontalScope hscope = null;
            int itemIndex = 0;
            var didButton = false;
            foreach (var fi in s_ForceButtons)
            {
                if (hscope == null)
                {
                    hscope = new EditorGUILayout.HorizontalScope();
                }

                var copyOfFi = fi;
                var defaultIconSize = 65;

                var textSize = (availableWidth - (defaultIconSize * 2)) / 2;
                if (GUILayout.Button(fi.Texture.Dark,
                    GUILayout.Height(defaultIconSize),
                    GUILayout.Width(defaultIconSize)))
                {
                    didButton = true;
                    s_IsShowingForces = false;
                    MenuCommand command = new MenuCommand(targetObject);
                    copyOfFi.Callback(command);
                }
                GUILayout.Label(fi.Title, MarsEditorGUI.Styles.LeftAlignedWrapLabel, GUILayout.Width(textSize));

                if (itemIndex % 2 == 1)
                {
                    hscope.Dispose();
                    hscope = null;
                }
                itemIndex++;
            }
            if (hscope != null)
            {
                hscope.Dispose();
                hscope = null;
            }

            return didButton;
        }

        [UnityEditor.MenuItem(k_ProxyForcePrefix + k_ForceButtonAlignToOther, false, k_ForceMenuAlignPriority)]
        static void EditorCreateAlignmentTo_OtherProxy(MenuCommand command)
        {
            var selection = CurrentEditorSelection(command);
            var proxy = ForcesMenuItemsRegions.EnsureProxyForcesOnGameobject(ref selection);

            var aligner = Undo.AddComponent<ProxyAlignmentForce>(proxy.gameObject);
            aligner.targetRelation = ProxyAlignmentForceType.SceneInitialRelativePose;
            AfterConfiguredComponent(aligner);
        }

        static ProxyForces EditorEnsureCameraProxy()
        {
            var cam =  MarsRuntimeUtils.GetSessionAssociatedCamera(true);

            if (cam == null)
                return null;

            var proxy = cam.GetComponent<ProxyForces>();
            if (proxy)
                return proxy;

            proxy = cam.GetComponentInChildren<ProxyForces>();
            if (proxy)
                return proxy;

            var gm = new GameObject { name = "MainCameraProxy" };
            gm.transform.parent = cam.transform;
            gm.transform.localPosition = Vector3.zero;
            gm.transform.localRotation = Quaternion.identity;
            gm.transform.localScale = Vector3.one;
            Undo.RegisterCreatedObjectUndo(gm, gm.name);
            proxy = Undo.AddComponent<ProxyForces>(gm);
            proxy.allowedMotion = ProxyForceMotionType.NotForced;
            proxy.continuousSolve = true;
            AfterConfiguredComponent(proxy);

            return proxy;
        }

        [UnityEditor.MenuItem(k_ProxyForcePrefix + k_ForceButtonAlignToCamera, false, k_ForceMenuAlignPriority)]
        static void EditorCreateAlignmentTo_ToCameraProxy(MenuCommand command)
        {
            var camProxy = EditorEnsureCameraProxy();
            if (!camProxy)
            {
                Debug.LogError(k_ForceMainCameraError);
                return;
            }

            var selection = CurrentEditorSelection(command);
            var forces = EnsureProxyForcesOnGameobject(ref selection);

            UnityEditor.Undo.RecordObject(forces.gameObject, "Adding Camera Alignment");
            var aligner = Undo.AddComponent<ProxyAlignmentForce>(forces.gameObject);
            aligner.targetRelation = ProxyAlignmentForceType.CenterInFrontOfAndFace;
            aligner.targetProxy = camProxy;
            AfterConfiguredComponent(aligner);
        }

#endif
    }

}
