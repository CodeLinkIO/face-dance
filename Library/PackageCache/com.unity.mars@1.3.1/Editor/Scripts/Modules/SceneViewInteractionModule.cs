using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS;
using Unity.MARS.Authoring;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityObject = UnityEngine.Object;

namespace UnityEditor.MARS.Authoring
{
    /// <summary>
    /// Module that handles mouse hovering and selecting interaction targets.
    /// When selected, it shows a button to open the create menu.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class SceneViewInteractionModule : IModule
    {
        static readonly RaycastHit[] k_RaycastHits = new RaycastHit[k_RaycastHitCount];

        const float k_ToolbarHeight = 20f;
        const int k_RaycastHitCount = 32;

        InteractionTarget m_CurrentHoverTarget;
        InteractionTarget m_PreviousHoverTarget;
        RaycastHit m_CurrentRaycastHit;
        Vector3 m_LastSimClickPosition;
        int m_MaxSelectionCount = -1; //-1 indicates no max
        readonly List<InteractionTarget> m_CurrentSelection = new List<InteractionTarget>();
        readonly HashSet<object> m_InteractionUsers = new HashSet<object>();

        /// <summary>
        /// The interaction target that is currently hovered
        /// </summary>
        public InteractionTarget CurrentHoverTarget => m_CurrentHoverTarget;

        /// <summary>
        /// All of the interaction targets currently selected
        /// </summary>
        public List<InteractionTarget> CurrentSelection => m_CurrentSelection;

        /// <summary>
        /// Event when a new target starts being hovered
        /// </summary>
        public event Action<InteractionTarget> HoverBegin;

        /// <summary>
        /// Event during a hover interaction that includes the raycast hit on the target
        /// </summary>
        public event Action<InteractionTarget, RaycastHit> HoverUpdate;

        /// <summary>
        /// Event when a target is no longer being hovered
        /// </summary>
        public event Action<InteractionTarget> HoverEnd;

        /// <summary>
        /// Event when the target selection has changed
        /// </summary>
        public event Action<List<InteractionTarget>> SelectionChanged;

        /// <summary>
        /// The last place where the user clicked in the scene.
        /// </summary>
        public Vector3 LastSimViewClickPosition => m_LastSimClickPosition;

        /// <summary>
        /// The max amount of things that can be selected at once
        /// </summary>
        public int SelectionLimit
        {
            get { return m_MaxSelectionCount; }
            set
            {
                m_MaxSelectionCount = value;
                if (m_MaxSelectionCount >= 0)
                {
                    while (m_CurrentSelection.Count > m_MaxSelectionCount)
                    {
                        var lastIndex = m_CurrentSelection.Count - 1;
                        var removedTarget = m_CurrentSelection[lastIndex];
                        m_CurrentSelection.RemoveAt(lastIndex);
                        if (removedTarget != null)
                            removedTarget.SetSelected(false);
                    }
                }
            }
        }

        bool InteractionEnabled => m_InteractionUsers.Count > 0;

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            SceneView.duringSceneGui += OnSceneGUI;
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            SceneView.duringSceneGui -= OnSceneGUI;

            if (m_CurrentHoverTarget != null)
                EndHover(m_CurrentHoverTarget);
        }

        /// <summary>
        /// Add or remove an object that needs scene view interaction. If there is at least one user requesting interaction, it will be enabled.
        /// </summary>
        /// <param name="user">The object that is using scene view interaction, used to avoid duplicate requests.</param>
        /// <param name="enable">Whether the object needs interaction enabled or not.</param>
        public void RequestInteraction(object user, bool enable)
        {
            if (enable && !m_InteractionUsers.Contains(user))
            {
                m_InteractionUsers.Add(user);
            }
            else if (!enable && m_InteractionUsers.Contains(user))
            {
                m_InteractionUsers.Remove(user);
            }
        }

        void OnSceneGUI(SceneView sceneView)
        {
            SceneViewHoverHandling(sceneView);
            ClickHandling();
        }

        void SceneViewHoverHandling(SceneView currentSceneView)
        {
            var currentEvent = Event.current;

            if (InteractionEnabled && !currentEvent.alt && EditorWindow.mouseOverWindow is SceneView)
            {
                if (EditorWindow.mouseOverWindow == currentSceneView)
                    RaycastInteractionTargets(currentSceneView.camera, HandleUtility.GUIPointToWorldRay(currentEvent.mousePosition));
            }
            else
                m_CurrentHoverTarget = null;

            CheckHoverChanges();
        }

        /// <summary>
        /// Clears selection before adding current interaction target
        /// </summary>
        public void SingleSelection()
        {
            ClearTargetSelection();
            AddToSelection();
        }

        /// <summary>
        /// Gets current hover target then adds the current interaction target
        /// </summary>
        public void AddToSelection()
        {
            if (m_CurrentHoverTarget != null)
                SelectCurrentHover();

            if (SelectionChanged != null)
                SelectionChanged(m_CurrentSelection);
        }

        void ClearTargetSelection()
        {
            if (m_CurrentSelection.Count == 0)
                return;

            foreach (var interactionTarget in m_CurrentSelection)
            {
                interactionTarget.SetSelected(false);
            }

            m_CurrentSelection.Clear();
        }

        void SelectCurrentHover()
        {
            var hoveredProxy = m_CurrentHoverTarget.GetComponentInParent<Proxy>();
            if (hoveredProxy != null)
            {
                AddOrRemoveTargetFromModuleSelection(m_CurrentHoverTarget);
            }
            else
            {
                var hoveredEntityVisual = m_CurrentHoverTarget.GetComponentInParent<EntityVisual>();
                if (hoveredEntityVisual != null)
                {
                    AddGameObjectToEditorSelection(hoveredEntityVisual.entity.gameObject);
                }
            }
        }

        void AddOrRemoveTargetFromModuleSelection(InteractionTarget target)
        {
            if (!m_CurrentSelection.Contains(target))
            {
                if (m_MaxSelectionCount == 0)
                    return;

                if (m_MaxSelectionCount > 0 && m_CurrentSelection.Count >= m_MaxSelectionCount)
                {
                    var targetToDeselect = m_CurrentSelection[0];
                    targetToDeselect.SetSelected(false);
                    m_CurrentSelection.RemoveAt(0);
                }

                m_CurrentSelection.Add(target);
                target.SetSelected(true);
            }
            else
            {
                m_CurrentSelection.Remove(target);
                target.SetSelected(false);
            }
        }

        static void AddGameObjectToEditorSelection(GameObject gameObject)
        {
            if (!Event.current.shift)
            {
                Selection.SetActiveObjectWithContext(gameObject, gameObject);
            }
            else
            {
                var selection = Selection.objects.ToList();
                selection.Add(gameObject);
                Selection.objects = selection.ToArray();
            }
        }

        /// <summary>
        /// Handle the click behavior in when using an interaction target
        /// </summary>
        public void ClickHandling()
        {
            var evt = Event.current;
            if (!InteractionEnabled || evt.alt || evt.mousePosition.y < k_ToolbarHeight)
                return;

            var id = GUIUtility.GetControlID(nameof(SceneViewInteractionModule).GetHashCode(), FocusType.Passive);
            switch (evt.GetTypeForControl(id))
            {
                case EventType.MouseDown:
                    if (evt.button != 0)
                        break;

                    if (m_CurrentHoverTarget != null)
                    {
                        GUIUtility.hotControl = id;
                        evt.Use();
                    }
                    else if (!evt.shift)
                    {
                        ClearTargetSelection();
                        if (SelectionChanged != null)
                            SelectionChanged(m_CurrentSelection);
                    }

                    break;
                case EventType.MouseUp:
                    if (GUIUtility.hotControl != id)
                        break;
                    if (evt.button == 0 && evt.clickCount == 1)
                    {
                        m_LastSimClickPosition = m_CurrentRaycastHit.point;

                        if (evt.shift)
                            AddToSelection();
                        else
                            SingleSelection();

                        if (m_CurrentHoverTarget != null)
                        {
                            evt.Use();
                            GUIUtility.hotControl = 0;
                        }
                    }
                    break;
            }

            // Remove anything in selection that is now null
            m_CurrentSelection.RemoveAll(x => x == null);
        }

        void CheckHoverChanges()
        {
            if (m_CurrentHoverTarget != m_PreviousHoverTarget)
            {
                if (m_PreviousHoverTarget != null)
                    EndHover(m_PreviousHoverTarget);

                m_PreviousHoverTarget = m_CurrentHoverTarget;

                if (m_PreviousHoverTarget != null)
                    StartHover(m_PreviousHoverTarget);
            }

            if (m_CurrentHoverTarget != null)
            {
                UpdateHover(m_PreviousHoverTarget, m_CurrentRaycastHit);
            }
        }

        void RaycastInteractionTargets(Camera raycastCamera, Ray ray)
        {
            var farClip = raycastCamera.farClipPlane;
            var closestDistance = farClip;
            var physicsScene = raycastCamera.scene.IsValid()
                ? raycastCamera.scene.GetPhysicsScene()
                : Physics.defaultPhysicsScene;

            m_CurrentHoverTarget = null;
            m_CurrentRaycastHit = new RaycastHit();
            var hitCount = physicsScene.Raycast(ray.origin, ray.direction, k_RaycastHits, farClip);
            for (var i = 0; i < hitCount; i++)
            {
                var hit = k_RaycastHits[i];
                var target = hit.collider.GetComponentInParent<InteractionTarget>();
                if (target != null
                    && target.UseInteractionTarget
                    && hit.distance < closestDistance)
                {
                    m_CurrentHoverTarget = target;
                    m_CurrentRaycastHit = hit;
                    closestDistance = hit.distance;
                }
            }
        }

        void StartHover(InteractionTarget target)
        {
            target.SetHovered(true);
            if (HoverBegin != null)
                HoverBegin(target);
        }

        void UpdateHover(InteractionTarget target, RaycastHit hit)
        {
            if (HoverUpdate != null)
                HoverUpdate(target, hit);

        }
        void EndHover(InteractionTarget target)
        {
            target.SetHovered(false);
            if (HoverEnd != null)
                HoverEnd(target);
        }
    }
}
