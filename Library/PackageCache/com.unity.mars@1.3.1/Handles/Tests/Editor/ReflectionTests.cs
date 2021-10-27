using NUnit.Framework;

namespace Unity.MARS.HandlesEditor
{
    sealed class ReflectionTests
    {
        [Test]
        public void ValidateExists_Tools_InvalidateHandlePosition()
        {
            Assert.IsTrue(ToolsUtility.TestAccess.invalidateHandlePositionExists);
        }
    }
}
