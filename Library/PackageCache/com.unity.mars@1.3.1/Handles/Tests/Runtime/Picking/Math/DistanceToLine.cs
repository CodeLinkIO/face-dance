using NUnit.Framework;
using UnityEngine;

namespace Unity.MARS.MARSHandles.Tests.Math
{
    static class DistanceToLine
    {
        [Test]
        public static void OnLine()
        {
            Assert.AreEqual(0, DistancePointToLine(new Vector3(0, 1, 0)));
        }

        [Test]
        public static void OffLine()
        {
            Assert.AreEqual(1, DistancePointToLine(new Vector3(1, 1, 0)));
        }

        static float DistancePointToLine(Vector3 point)
        {
            return MathUtility.DistanceToLine(point, new Vector3(0, 0, 0), new Vector3(0, 2, 0));
        }
    }
}