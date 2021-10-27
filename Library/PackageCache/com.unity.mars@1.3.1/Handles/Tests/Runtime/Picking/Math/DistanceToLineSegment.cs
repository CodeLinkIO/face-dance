using NUnit.Framework;
using UnityEngine;

namespace Unity.MARS.MARSHandles.Tests.Math
{
    static class DistanceToLineSegment
    {
        [Test]
        public static void OnLine()
        {
            Assert.AreEqual(0, DistancePointToLine2D(new Vector2(0, 1)));
        }

        [Test]
        public static void OffLine()
        {
            Assert.AreEqual(1, DistancePointToLine2D(new Vector2(1, 1)));
        }

        static float DistancePointToLine2D(Vector2 point)
        {
            return MathUtility.DistanceToLine(point, new Vector2(0, 0), new Vector2(0, 2));
        }
    }
}