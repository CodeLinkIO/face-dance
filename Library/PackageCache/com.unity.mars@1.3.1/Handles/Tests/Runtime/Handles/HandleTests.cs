using NUnit.Framework;
using Unity.MARS.MARSHandles.Tests.Contexts;
using UnityEngine;

namespace Unity.MARS.MARSHandles.Tests
{
    sealed class HandleTests
    {
        sealed class DummyHandleBehaviour : HandleBehaviour
        {
            public int createdByContextEventCount { get; private set; } = 0;

            protected override void OnCreatedByContext()
            {
                ++createdByContextEventCount;
            }
        }

        sealed class DummyHandle : InteractiveHandle
        {
            public override Plane GetProjectionPlane(Vector3 camPosition)
            {
                return default;
            }
        }

        GameObject m_Prefab;
        DummyHandle m_RootHandle;
        DummyHandleBehaviour m_ChildBehaviour;
        DummyHandle m_GrandchildHandle;
        DummyHandleBehaviour m_GreatGrandchildBehaviour;
        RuntimeDummyContext m_Context;

        [SetUp]
        public void SetUp()
        {
            m_Prefab = new GameObject("Root", typeof(DummyHandle));

            var child = new GameObject("Child", typeof(DummyHandleBehaviour)).transform;
            child.SetParent(m_Prefab.transform);

            var grandChild = new GameObject("Grandchild", typeof(DummyHandle)).transform;
            grandChild.SetParent(child);
            
            var greatGrandChild = new GameObject("Great Grandchild", typeof(DummyHandleBehaviour)).transform;
            greatGrandChild.SetParent(grandChild);

            m_Context = new RuntimeDummyContext();
            var instance = m_Context.CreateHandle(m_Prefab);

            m_RootHandle = instance.GetComponent<DummyHandle>();
            m_ChildBehaviour = instance.transform.Find("Child").GetComponent<DummyHandleBehaviour>();
            m_GrandchildHandle = m_ChildBehaviour.transform.Find("Grandchild").GetComponent<DummyHandle>();
            m_GreatGrandchildBehaviour = m_GrandchildHandle.transform.Find("Great Grandchild").GetComponent<DummyHandleBehaviour>();
        }

        [TearDown]
        public void TearDown()
        {
            m_Context.DestroyHandle(m_RootHandle.gameObject);
            m_Context.Dispose();
            Object.DestroyImmediate(m_RootHandle);
        }

        [Test]
        public void ChildBehaviour_OwnerIsRootHandle()
        {
            Assert.That(m_ChildBehaviour.ownerHandle, Is.EqualTo(m_RootHandle));
        }

        [Test]
        public void GrandChildBehaviour_OwnerIsGrandChildHandle()
        {
            Assert.That(m_GreatGrandchildBehaviour.ownerHandle, Is.EqualTo(m_GrandchildHandle));
        }

        [Test]
        public void MoveChildBehaviourTransformToUnderChildBehaviour_OwnerHandleIsChangedToRootHandle()
        {
            Assume.That(m_GreatGrandchildBehaviour.ownerHandle, Is.EqualTo(m_GrandchildHandle));
            m_GreatGrandchildBehaviour.transform.SetParent(m_ChildBehaviour.transform);

            Assert.That(m_GreatGrandchildBehaviour.ownerHandle, Is.EqualTo(m_RootHandle));
        }

        [Test]
        public void Handle_OwnerHandleIsItself()
        {
            Assume.That(m_RootHandle.ownerHandle, Is.EqualTo(m_RootHandle));
            Assume.That(m_GrandchildHandle.ownerHandle, Is.EqualTo(m_GrandchildHandle));
        }

        [Test]
        public void HandleBehaviour_Created_RegisteredOnceToContext()
        {
            Assert.That(m_Context.GetHandleBehaviours().Count, Is.EqualTo(4));
        }

        [Test]
        public void HandleBehaviour_CreatedDisableAndReenable_RegisteredOnceToContext()
        {
            Assume.That(m_Context.GetHandleBehaviours().Count, Is.EqualTo(4));
            m_RootHandle.enabled = false;
            m_ChildBehaviour.enabled = false;
            m_GrandchildHandle.enabled = false;
            m_GreatGrandchildBehaviour.enabled = false;

            Assert.That(m_Context.GetHandleBehaviours().Count, Is.EqualTo(0));
            m_RootHandle.enabled = true;
            m_ChildBehaviour.enabled = true;
            m_GrandchildHandle.enabled = true;
            m_GreatGrandchildBehaviour.enabled = true;
            Assert.That(m_Context.GetHandleBehaviours().Count, Is.EqualTo(4));
        }

        [Test]
        public void HandleBehaviour_DisabledAtCreation_OnEnableIsRegistered()
        {
            Assume.That(m_Context.GetHandleBehaviours().Count, Is.EqualTo(4));

            m_Prefab.SetActive(false);
            var handle = m_Context.CreateHandle(m_Prefab);
            Assert.That(m_Context.GetHandleBehaviours().Count, Is.EqualTo(4));

            handle.SetActive(true);
            Assert.That(m_Context.GetHandleBehaviours().Count, Is.EqualTo(8));

            m_Context.DestroyHandle(handle);
        }

        [Test]
        public void HandleBehaviour_AddComponent_RegisteredOnceToContext()
        {
            Assume.That(m_Context.GetHandleBehaviours().Count, Is.EqualTo(4));

            m_RootHandle.gameObject.AddComponent<DummyHandleBehaviour>();
            Assert.That(m_Context.GetHandleBehaviours().Count, Is.EqualTo(5));
        }

        [Test]
        public void HandleBehaviour_ReceivesOnCreatedFromContext()
        {
            ValidateBehavioursOnCreatedEvent(true, m_RootHandle.gameObject);
        }

        [Test]
        public void HandleBehaviour_DisableBeforeCreation_OnEnable_ReceivesOnCreatedFromContext()
        {
            m_Prefab.SetActive(false);
            var handle = m_Context.CreateHandle(m_Prefab);

            ValidateBehavioursOnCreatedEvent(false, handle);
            handle.SetActive(true);
            ValidateBehavioursOnCreatedEvent(true, handle);

            m_Context.DestroyHandle(handle);
        }

        [Test]
        public void HandleBehaviour_ReceivesOnCreatedFromContext_DisableAndReenable_DoesNotReceiveItAgain()
        {
            ValidateBehavioursOnCreatedEvent(true, m_RootHandle.gameObject, assume: true);
            m_RootHandle.gameObject.SetActive(false);
            ValidateBehavioursOnCreatedEvent(true, m_RootHandle.gameObject);

            m_RootHandle.gameObject.SetActive(true);
            ValidateBehavioursOnCreatedEvent(true, m_RootHandle.gameObject);
        }

        [Test]
        public void HandleBehaviour_AddComponent_ReceivesOnCreatedFromContext()
        {
            ValidateBehavioursOnCreatedEvent(true, m_RootHandle.gameObject, assume: true);

            var behaviour = m_RootHandle.gameObject.AddComponent<DummyHandleBehaviour>();
            Assert.That(behaviour.createdByContextEventCount, Is.EqualTo(1));
        }

        static void ValidateBehavioursOnCreatedEvent(bool shouldBeReceived, GameObject obj, bool assume = false)
        {
            foreach (var handleBehaviour in obj.GetComponentsInChildren<DummyHandleBehaviour>(true))
            {
                if (!assume)
                    Assert.That(handleBehaviour.createdByContextEventCount, Is.EqualTo(shouldBeReceived ? 1 : 0));
                else
                    Assume.That(handleBehaviour.createdByContextEventCount, Is.EqualTo(shouldBeReceived ? 1 : 0));
            }
        }
    }
}