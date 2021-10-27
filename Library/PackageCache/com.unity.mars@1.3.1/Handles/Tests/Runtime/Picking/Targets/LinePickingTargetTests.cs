using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.MARSHandles.Picking;
using UnityEngine;
using UnityEngine.TestTools.Constraints;
using Is = NUnit.Framework.Is;

namespace Unity.MARS.MARSHandles.Tests.Picking
{
    internal sealed class LinePickingTargetTests
    {
        LinePickingTarget m_Target;

        public sealed class TestCase
        {
            public readonly Vector3[] points;

            public TestCase(Vector3[] points)
            {
                this.points = points;
            }

            public override string ToString()
            {
                return string.Format("{0} Point{1}", points.Length, points.Length > 1 ? "s" : "");
            }
        }

        static IEnumerable<TestCase> testCases
        {
            get
            {
                yield return new TestCase(new [] { Vector3.zero });
                yield return new TestCase(new [] { Vector3.zero, new Vector3(0, 0, 1) });
                yield return new TestCase(new [] { Vector3.zero, new Vector3(0, 0, 1), new Vector3(0, 1, 1) });
            }
        }

        [SetUp]
        public void SetUp()
        {
            m_Target = new GameObject("Target").AddComponent<LinePickingTarget>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(m_Target.gameObject);
        }


        [Test]
        [TestCaseSource(nameof(testCases))]
        public void CheckPickingData_IsValid(TestCase testCase)
        {
            m_Target.points = testCase.points;
            var pickingData = m_Target.GetPickingData();

            Assert.IsTrue(pickingData.valid);
        }

        [Test]
        [TestCaseSource(nameof(testCases))]
        public void CheckPickingData_ValidTRS(TestCase testCase)
        {
            m_Target.points = testCase.points;
            var pickingData = m_Target.GetPickingData();
            Assume.That(pickingData.valid);

            Assert.IsTrue(pickingData.matrix.ValidTRS());
        }

        [Test]
        [TestCaseSource(nameof(testCases))]
        public void CheckMesh_OnlyOneSubMesh(TestCase testCase)
        {
            m_Target.points = testCase.points;
            var pickingData = m_Target.GetPickingData();
            Assume.That(pickingData.valid);

            Assert.AreEqual(pickingData.mesh.subMeshCount, 1);
        }

        [Test]
        [TestCaseSource(nameof(testCases))]
        public void CheckTopology_OnePointIsPointTopology_MoreIsLineStripTopology(TestCase testCase)
        {
            m_Target.points = testCase.points;
            var pickingData = m_Target.GetPickingData();
            Assume.That(pickingData.valid);

            Assert.AreEqual(
                testCase.points.Length > 1 ? MeshTopology.LineStrip : MeshTopology.Points,
                pickingData.mesh.GetTopology(0));
        }

        [Test]
        [TestCaseSource(nameof(testCases))]
        public void CheckIndices_IsEqualToNumberOfPoints(TestCase testCase)
        {
            m_Target.points = testCase.points;
            var pickingData = m_Target.GetPickingData();
            Assume.That(pickingData.valid);
            var indices = pickingData.mesh.GetIndices(0);

            Assume.That(indices != null);

            Assert.AreEqual(indices.Length, testCase.points.Length);
        }

        [Test]
        [TestCaseSource(nameof(testCases))]
        public void CheckVertices_AreSameAsGivenValue(TestCase testCase)
        {
            m_Target.points = testCase.points;
            var pickingData = m_Target.GetPickingData();
            Assume.That(pickingData.valid);
            var vertices = pickingData.mesh.vertices;

            Assert.AreEqual(vertices.Length, testCase.points.Length);
            for (int i = 0; i < vertices.Length; ++i)
            {
                Assert.AreEqual(testCase.points[i], vertices[i]);
            }
        }

        [Test]
        [TestCaseSource(nameof(testCases))]
        public void GetPickingMesh_DoesntAllocate(TestCase testCase)
        {
            m_Target.points = testCase.points;

            Assert.That(TestScope, Is.Not.AllocatingGCMemory());

            void TestScope()
            {
                m_Target.GetPickingData();
            }
        }
    }
}
