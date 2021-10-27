using UnityEngine;
using UnityEngine.Assertions;
using Unity.MARS.MARSHandles.Picking;
using UnityEditor;

namespace Unity.MARS.HandlesEditor
{
    class EditorWindowContext : EditorHandleContext
    {
        const float k_PickingDistance = 15.0f;
        readonly InteractionState m_State;
        static PickingHit s_Hit;

        /// <summary>
        ///
        /// </summary>
        /// <param name="window"></param>
        /// <param name="anchors">Anchors defined as percentage between 0 and 1</param>
        public EditorWindowContext()
        {
            m_State = new InteractionState(this);
        }

        public void OnGUI(EditorWindow window)
        {
            OnGUI(window, window.position);
        }

        public void OnGUI(EditorWindow window, Rect rect)
        {
            OnGUI(window, rect, Event.current);
        }

        internal void OnGUI(EditorWindow window, Rect rect, Event evt)
        {
            if (window == null)
                return;

            Assert.IsNotNull(window, "Cannot draw a Editor Window Context with a null window.");
            Assert.IsNotNull(evt, "IMGUIController.OnGUI cannot be called outside an OnGUI method");

            camera = Camera.current;

            var id = GUIUtility.GetControlID(FocusType.Passive);
            switch (evt.GetTypeForControl(id))
            {
                case EventType.Layout:
                    ScreenPickingUtility.GetHovered(
                        handles,
                        GetMousePosition(evt, rect),
                        camera,
                        k_PickingDistance,
                        out s_Hit);

                    HandleUtility.AddControl(id, s_Hit.distance);
                    break;

                case EventType.MouseMove:
                    //Verify that no unity control is currently considered nearest.
                    //We also set hovered if nearest control is 0 because the unity picking distance might not be the same as this context.
                    if (HandleUtility.nearestControl == id || HandleUtility.nearestControl == 0)
                        m_State.SetHovered(GetHandle(s_Hit.target));
                    else
                        m_State.SetHovered(null);

                    if (m_State.activeHandle)
                    {
                        m_State.Update(MARSHandles.HandleUtility.ProjectScreenPositionOnHandle(
                            m_State.activeHandle,
                            GetMousePosition(evt, rect),
                            camera));

                        window.Repaint();
                    }
                    break;

                case EventType.MouseDown:
                    if (evt.button != 0)
                        break;

                    if (m_State.StartDrag(MARSHandles.HandleUtility.ProjectScreenPositionOnHandle(
                        m_State.activeHandle,
                        GetMousePosition(evt, rect),
                        camera)))
                    {
                        GUIUtility.hotControl = id;
                        evt.Use();
                    }
                    break;

                case EventType.MouseUp:
                    if (m_State.StopDrag())
                    {
                        GUIUtility.hotControl = 0;
                        evt.Use();
                    }
                    break;

                case EventType.MouseDrag:
                    if (GUIUtility.hotControl == id)
                    {
                        m_State.Update(MARSHandles.HandleUtility.ProjectScreenPositionOnHandle(
                            m_State.activeHandle,
                            GetMousePosition(evt, rect),
                            camera));

                        ToolsUtility.InvalidateHandlePosition();
                        evt.Use();
                    }
                    break;

                case EventType.Repaint:
                    Repaint(rect);
                    break;
            }
        }

        protected virtual void Repaint(Rect rect)
        {
            RenderHandles(rect, camera);
        }

        protected virtual Vector2 GetMousePosition(Event evt, Rect rect)
        {
            var pos = EditorGUIUtility.PointsToPixels(evt.mousePosition);
            rect = EditorGUIUtility.PointsToPixels(rect);
            pos.y = rect.height - pos.y; //GUI's (0,0) is top left, Camera is bottom left
            return pos;
        }
    }
}
