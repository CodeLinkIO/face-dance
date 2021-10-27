using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    abstract partial class HandleContext
    {
        /// <summary>
        /// Keeps track of the states of interaction (Hovering + Dragging) and sends the Hover/Drag events at the right moments
        /// </summary>
        public sealed class InteractionState
        {
            public enum State
            {
                Idle,
                Hovering,
                Dragging,
            }

            InteractiveHandle m_HoverHandle;
            InteractiveHandle m_ActiveHandle;
            Vector3 m_StartDragPosition;
            Vector3 m_LastFramePosition;
            State m_State = State.Idle;
            readonly HandleContext m_Context;
            static readonly List<HandleBehaviour> s_BehavioursSnapshot = new List<HandleBehaviour>(32);

            public InteractionState(HandleContext context)
            {
                m_Context = context;
            }

            public State state { get { return m_State; } }

            public InteractiveHandle activeHandle
            {
                get { return m_ActiveHandle; }
            }

            public bool isDragging
            {
                get { return m_State == State.Dragging; }
            }

            public void SetHovered(InteractiveHandle handle)
            {
                if (m_ActiveHandle == handle)
                    return;

                m_HoverHandle = handle;
                if (m_State != State.Dragging)
                {
                    if (m_ActiveHandle)
                    {
                        var eventData = new HoverEndInfo();
                        foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
                        {
                            if (behaviour == null)
                                continue;

                            behaviour.DoHoverEnd(m_ActiveHandle, eventData);
                        }
                    }

                    m_ActiveHandle = handle; //If we are dragging, we keep the current active engaged as Hovering and Dragging
                    m_State = m_ActiveHandle != null ? State.Hovering : State.Idle;

                    if (m_ActiveHandle)
                    {
                        var eventData = new HoverBeginInfo();
                        foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
                        {
                            if (behaviour == null)
                                continue;

                            behaviour.DoHoverBegin(m_ActiveHandle, eventData);
                        }
                    }

                }
            }

            public bool StartDrag(Vector3 hitPos)
            {
                if (m_State != State.Hovering)
                    return false;

                m_StartDragPosition = hitPos;
                m_LastFramePosition = hitPos;
                m_State = State.Dragging;

                var eventData = new DragBeginInfo(new DragTranslation(
                    m_StartDragPosition,
                    m_StartDragPosition,
                    Vector3.zero));

                foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
                {
                    if (behaviour == null)
                        continue;

                    behaviour.DoDragBegin(m_ActiveHandle, eventData);
                }

                return true;
            }

            public bool StopDrag()
            {
                if (m_State != State.Dragging)
                    return false;

                var eventData = new DragEndInfo(new DragTranslation(
                    m_StartDragPosition,
                    m_LastFramePosition,
                    Vector3.zero));

                foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
                {
                    if (behaviour == null)
                        continue;

                    behaviour.DoDragEnd(m_ActiveHandle, eventData);
                }

                m_State = State.Hovering;
                if (m_HoverHandle != m_ActiveHandle)
                    SetHovered(m_HoverHandle);
                return true;
            }

            public void Update(Vector3 hitPos)
            {
                switch (m_State)
                {
                    case State.Hovering:
                    {
                        var eventData = new HoverUpdateInfo();
                        foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
                        {
                            if (behaviour == null)
                                continue;

                            behaviour.DoHoverUpdate(m_ActiveHandle, eventData);
                        }

                        break;
                    }

                    case State.Dragging:
                    {
                        var eventData = new DragUpdateInfo(new DragTranslation(
                            m_StartDragPosition,
                            hitPos,
                            hitPos - m_LastFramePosition));

                        foreach (var behaviour in TakeSnapshot(m_Context.GetHandleBehaviours()))
                        {
                            if (behaviour == null)
                                continue;

                            behaviour.DoDragUpdate(m_ActiveHandle, eventData);
                        }

                        break;
                    }
                }
            }

            static List<HandleBehaviour> TakeSnapshot(List<HandleBehaviour> original)
            {
                s_BehavioursSnapshot.Clear();
                s_BehavioursSnapshot.AddRange(original);
                return s_BehavioursSnapshot;
            }
        }
    }
}
