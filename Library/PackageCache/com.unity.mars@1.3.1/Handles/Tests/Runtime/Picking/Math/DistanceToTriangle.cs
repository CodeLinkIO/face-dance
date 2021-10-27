using NUnit.Framework;
using UnityEngine;

namespace Unity.MARS.MARSHandles.Tests.Math
{
    static class DistanceToTriangle
    {
        [Test]
        public static void InTriangle()
        {
            Assert.AreEqual(0, GetDistanceToTriangle(new Vector2(0.2f, 0.2f)));
        }

        [Test]
        public static void OnTriangle()
        {
            Assert.AreEqual(0, GetDistanceToTriangle(new Vector2(0f, 0.5f)));
        }

        [Test]
        public static void OnVertex()
        {
            Assert.AreEqual(0, GetDistanceToTriangle(new Vector2(0f, 0f)));
        }

        [Test]
        public static void OutsideTriangle()
        {
            Assert.AreEqual(0.707106769f, GetDistanceToTriangle(new Vector2(1f, 1f)));
        }

        static float GetDistanceToTriangle(Vector2 point)
        {
            return MathUtility.DistanceToTriangle(point, new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0));
        }
    }
}