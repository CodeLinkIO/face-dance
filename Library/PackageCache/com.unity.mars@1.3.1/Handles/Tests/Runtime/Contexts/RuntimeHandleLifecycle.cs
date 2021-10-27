namespace Unity.MARS.MARSHandles.Tests.Contexts
{
    sealed class RuntimeDummyContext : RuntimeHandleContext, ITestContext
    {
        public int handleCount
        {
            get { return handles.Count; }
        }
    }

    sealed class RuntimeHandleLifecycleTests : HandleLifecycleTests<RuntimeDummyContext>
    {
    }
}