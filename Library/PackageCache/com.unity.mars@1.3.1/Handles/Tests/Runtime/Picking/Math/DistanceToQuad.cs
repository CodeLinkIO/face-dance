using NUnit.Framework;
using UnityEngine;

namespace Unity.MARS.MARSHandles.Tests.Math
{
    static class DistanceToQuad
    {
        [Test]
        public static void Convex_InQuad()
        {
            Assert.AreEqual(0f, GetDistanceToQuadConvex(new Vector2(0.5f, 0.5f)));
        }

        [Test]
        public static void Convex_OnQuad()
        {
            Assert.AreEqual(0f, GetDistanceToQuadConvex(new Vector2(0, 0.5f)));
        }

        [Test]
        public static void Convex_OutsideQuad()
        {
            Assert.AreEqual(1f, GetDistanceToQuadConvex(new Vector2(-1, 0.5f)));
        }

        static float GetDistanceToQuadConvex(Vector2 point)
        {
            return MathUtility.DistanceToQuad(point, new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0));
        }

        [Test]
        public static void Concave_InQuad()
        {
            Assert.AreEqual(0f, GetDistanceToQuadConcave(new Vector2(0.05f, 0.05f)));
        }

        [Test]
        public static void Concave_OnQuad()
        {
            Assert.AreEqual(0f, GetDistanceToQuadConcave(new Vector2(0, 0.5f)));
        }

        [Test]
        public static void Concave_OutsideQuad()
        {
            Assert.AreEqual(0.441726118f, GetDistanceToQuadConcave(new Vector2(0.5f, 0.5f)));
        }

        [Test]
        public static void Orientation_EdgeCase()
        {
            Assert.AreEqual(0.0f, MathUtility.DistanceToQuad(new Vector2(0, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1)));
        }

        static float GetDistanceToQuadConcave(Vector2 point)
        {
            return MathUtility.DistanceToQuad(point, new Vector2(0, 0), new Vector2(0, 1), new Vector2(0.1f, 0.1f), new Vector2(1, 0));
        }
    }
}