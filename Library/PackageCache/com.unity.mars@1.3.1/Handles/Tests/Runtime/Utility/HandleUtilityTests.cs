using NUnit.Framework;

namespace Unity.MARS.MARSHandles.Tests
{
    sealed class HandleUtilityTests
    {

        [Test]
        public void PixelsPerPoint_IsExpectedValue()
        {
#if UNITY_EDITOR
            Assert.That(MARSHandles.HandleUtility.pixelsPerPoint, Is.EqualTo(UnityEditor.EditorGUIUtility.pixelsPerPoint));
#else
            Assert.That(MARSHandles.HandleUtility.pixelsPerPoint, Is.EqualTo(Screen.dpi / 96f));
#endif
        }
    }
}
