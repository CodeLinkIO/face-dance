using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Unity.MARS.MARSHandles.Tests
{
    sealed class ContextToHandleEvents
    {
        public enum EventType
        {
            HoverBegin,
            HoverUpdate,
            HoverEnd,
            DragBegin,
            DragUpdate,
            DragEnd,
        }

        struct Event
        {
            public EventType type { get; }
            public InteractiveHandle target { get; }

            public Event(EventType type, InteractiveHandle target)
            {
                this.type = type;
                this.target = target;
            }
        }

        sealed class FakeHandle : InteractiveHandle
        {
            readonly Queue<Event> m_EventQueue = new Queue<Event>();
            public bool recordEvents = false;

            public override Plane GetProjectionPlane(Vector3 camPosition)
            {
                return default;
            }

            public void AssertReceivedEvents(Event evt)
            {
                AssertReceivedEvents(new[] { evt });
            }

            public void AssertReceivedEvents(Event[] expected)
            {
                Assert.That(m_EventQueue.Count, Is.EqualTo(expected.Length), "Not the expected events count");

                foreach (var evt in expected)
                {
                    var result = m_EventQueue.Dequeue();
                    Assert.That(result.type, Is.EqualTo(evt.type));
                    Assert.That(result.target, Is.EqualTo(evt.target));
                }
            }
            
            protected override void DragBegin(InteractiveHandle target, DragBeginInfo info)
            {
                if (recordEvents)
                    m_EventQueue.Enqueue(new Event(EventType.DragBegin, target));
            }

            protected override void DragEnd(InteractiveHandle target, DragEndInfo info)
            {
                if (recordEvents)
                    m_EventQueue.Enqueue(new Event(EventType.DragEnd, target));
            }

            protected override void DragUpdate(InteractiveHandle target, DragUpdateInfo info)
            {
                if (recordEvents)
                    m_EventQueue.Enqueue(new Event(EventType.DragUpdate, target));
            }

            protected override void HoverBegin(InteractiveHandle target, HoverBeginInfo info)
            {
                if (recordEvents)
                    m_EventQueue.Enqueue(new Event(EventType.HoverBegin, target));
            }

            protected override void HoverEnd(InteractiveHandle target, HoverEndInfo info)
            {
                if (recordEvents)
                    m_EventQueue.Enqueue(new Event(EventType.HoverEnd, target));
            }

            protected override void HoverUpdate(InteractiveHandle target, HoverUpdateInfo info)
            {
                if (recordEvents)
                    m_EventQueue.Enqueue(new Event(EventType.HoverUpdate, target));
            }
        }

        GameObject m_HandleTemplate;
        FakeContext m_Context;
        FakeHandle m_MainHandle;
        FakeHandle m_OtherHandle;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            m_HandleTemplate = new GameObject("[Fake Handle Template]");
            m_HandleTemplate.AddComponent<FakeHandle>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Object.DestroyImmediate(m_HandleTemplate);
        }

        [SetUp]
        public void SetUp()
        {
            m_Context = new FakeContext();
            m_MainHandle = m_Context.CreateHandle(m_HandleTemplate).GetComponent<FakeHandle>();
            m_OtherHandle = m_Context.CreateHandle(m_HandleTemplate).GetComponent<FakeHandle>();
        }

        [TearDown]
        public void TearDown()
        {
            m_Context.Dispose();
        }

        [Test]
        public void ContextSetHoverWithSameHandle_NoEventIsReceived()
        {
            m_Context.SetHover(m_MainHandle);
            StartRecordingEvents();

            m_Context.SetHover(m_MainHandle);
            AssertNoEventsReceived();
        }

        [Test]
        public void ContextSetHoverWithANewHandle_HandlesReceivesProperHoverBeginEvent()
        {
            StartRecordingEvents();
            m_Context.SetHover(m_MainHandle);
            
            AssertReceivedProperEvent(EventType.HoverBegin);
        }

        [Test]
        public void ContextUpdateWhileNotDrag_HandlesReceivesProperHoverUpdateEvent()
        {
            m_Context.SetHover(m_MainHandle);
            StartRecordingEvents();

            m_Context.Update();
            AssertReceivedProperEvent(EventType.HoverUpdate);
        }

        [Test]
        public void ContextSetHoverToNull_HandlesReceivesProperHoverEndEvent()
        {
            m_Context.SetHover(m_MainHandle);
            StartRecordingEvents();

            m_Context.SetHover(null);
            AssertReceivedProperEvent(EventType.HoverEnd);
        }

        [Test]
        public void ContextSetHoverToDifferentHandle_HandlesReceivesProperHoverEndEvent()
        {
            m_Context.SetHover(m_MainHandle);
            StartRecordingEvents();

            m_Context.SetHover(m_OtherHandle);

            m_MainHandle.AssertReceivedEvents(new[]
            {
                new Event(EventType.HoverEnd, m_MainHandle),
                new Event(EventType.HoverBegin, m_OtherHandle), 
            });

            m_OtherHandle.AssertReceivedEvents(new[]
            {
                new Event(EventType.HoverEnd, m_MainHandle),
                new Event(EventType.HoverBegin, m_OtherHandle), 
            });
        }

        [Test]
        public void ContextStartDrag_HandlesReceivesProperDragBeginEvent()
        {
            m_Context.SetHover(m_MainHandle);
            StartRecordingEvents();

            m_Context.DoDragStart();
            AssertReceivedProperEvent(EventType.DragBegin);
        }

        [Test]
        public void ContextStartDragTwiceWithoutStop_HandlesDoesntReceiveSecondEvent()
        {
            m_Context.SetHover(m_MainHandle);
            m_Context.DoDragStart();
            StartRecordingEvents();

            m_Context.DoDragStart();
            AssertNoEventsReceived();
        }

        [Test]
        public void ContextUpdateDrag_HandlesReceivesProperDragUpdateEvent()
        {
            m_Context.SetHover(m_MainHandle);
            m_Context.DoDragStart();
            StartRecordingEvents();
            
            m_Context.Update();
            AssertReceivedProperEvent(EventType.DragUpdate);
        }

        [Test]
        public void ContextStopDrag_HandlesReceivesProperDragEndEvent()
        {
            m_Context.SetHover(m_MainHandle);
            m_Context.DoDragStart();
            m_Context.Update();
            StartRecordingEvents();

            m_Context.DoDragStop();
            AssertReceivedProperEvent(EventType.DragEnd);
        }

        [Test]
        public void ContextStopDragTwiceWithoutStart_HandlesDoesntReceiveSecondEvent()
        {
            m_Context.SetHover(m_MainHandle);
            m_Context.DoDragStart();
            m_Context.Update();
            m_Context.DoDragStop();
            StartRecordingEvents();

            m_Context.DoDragStop();
            AssertNoEventsReceived();
        }

        void AssertReceivedProperEvent(EventType type)
        {
            m_MainHandle.AssertReceivedEvents(new[]
            {
                new Event(type, m_MainHandle),
            });

            m_OtherHandle.AssertReceivedEvents(new[]
            {
                new Event(type, m_MainHandle),
            });
        }

        void AssertNoEventsReceived()
        {
            m_MainHandle.AssertReceivedEvents(new Event[0]);
            m_OtherHandle.AssertReceivedEvents(new Event[0]);
        }

        void StartRecordingEvents()
        {
            m_MainHandle.recordEvents = true;
            m_OtherHandle.recordEvents = true;
        }
    }
}
