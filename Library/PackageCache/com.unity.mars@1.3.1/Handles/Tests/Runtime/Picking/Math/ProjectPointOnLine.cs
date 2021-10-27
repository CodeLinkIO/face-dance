using NUnit.Framework;
using UnityEngine;

namespace Unity.MARS.MARSHandles.Tests.Math
{
    static class ProjectPointOnLine
    {
        static readonly Vector3 k_LineA = new Vector3(0, 0, 0);
        static readonly Vector3 k_LineB = new Vector3(0, 2, 0);

        [Test]
        public static void OnLine()
        {
            Assert.AreEqual(new Vector3(0, 1, 0), MathUtility.ProjectPointLine(new Vector3(0, 1, 0), k_LineA, k_LineB));
        }

        [Test]
        public static void OffLine()
        {
            Assert.AreEqual(new Vector3(0, 1, 0), MathUtility.ProjectPointLine(new Vector3(1, 1, 0), k_LineA, k_LineB));
        }
    }
}