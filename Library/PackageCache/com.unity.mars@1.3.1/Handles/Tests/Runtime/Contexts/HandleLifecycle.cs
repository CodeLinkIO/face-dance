using System;
using NUnit.Framework;

namespace Unity.MARS.MARSHandles.Tests.Contexts
{
    interface ITestContext
    {
        int handleCount { get; }
    }

    abstract class HandleLifecycleTests<TContext> where TContext : HandleContext, ITestContext, new()
    {
        protected readonly TContext context = new TContext();

        [Test]
        public void CreateHandle_CopyOfTheGivenTemplateIsCreated()
        {
            using (var template = new DummyHandleTemplate(DummyHandleTemplate.Template.BasicInteractiveHandle))
            {
                Assume.That(context.handleCount == 0);

                var handle = context.CreateHandle(template.gameObject);
                Assert.IsNotNull(handle);
                Assert.IsNotNull(handle.GetComponent<DummyHandleTemplate.Handle>());
                Assert.AreEqual(context.handleCount, 1);

                context.DestroyHandle(handle);
            }
        }

        [Test]
        public void DestroyHandle_HandleIsDestroyed()
        {
            using (var template = new DummyHandleTemplate(DummyHandleTemplate.Template.BasicInteractiveHandle))
            {
                var handle = context.CreateHandle(template.gameObject);
                Assume.That(handle != null);
                Assume.That(context.handleCount == 1);

                context.DestroyHandle(handle);
                Assert.IsTrue(handle == null);
                Assert.AreEqual(context.handleCount, 0);
            }
        }

        [Test]
        public void CreateHandle_NullArgument_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(Create);

            void Create()
            {
                context.CreateHandle(null);
            }
        }

        [Test]
        public void DestroyHandle_NullArgument_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(Destroy);

            void Destroy()
            {
                context.DestroyHandle(null);
            }
        }
    }
}