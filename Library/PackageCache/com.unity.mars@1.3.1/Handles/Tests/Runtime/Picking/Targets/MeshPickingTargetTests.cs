using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.MARSHandles.Picking;
using UnityEngine;
using UnityEngine.TestTools.Constraints;
using Is = NUnit.Framework.Is;

namespace Unity.MARS.MARSHandles.Tests.Picking
{
    internal sealed class MeshPickingTargetTests
    {
        MeshPickingTarget m_Target;
        Mesh m_Mesh;

        public class MeshData
        {
            public readonly Vector3[] vertices;
            public readonly int[] indices;
            public readonly MeshTopology topology;

            public MeshData(MeshTopology topology, int[] indices, Vector3[] vertices)
            {
                this.topology = topology;
                this.indices = indices;
                this.vertices = vertices;
            }

            public override string ToString()
            {
                return string.Format("[topology={0}]", topology);
            }
        }

        static IEnumerable<MeshData> s_MeshCases
        {
            get
            {
                yield return new MeshData(
                    MeshTopology.Triangles,
                    new []{ 0, 1, 2},
                    new[] { Vector3.zero, Vector3.up, Vector3.right });
                yield return new MeshData(
                    MeshTopology.Quads,
                    new[] { 0, 1, 2, 3 },
                    new[] { Vector3.zero, Vector3.up, Vector3.up + Vector3.right, Vector3.right });
                yield return new MeshData(
                    MeshTopology.LineStrip,
                    new[] { 0, 1, 2 },
                    new[] { Vector3.zero, Vector3.up, Vector3.right });
                yield return new MeshData(
                    MeshTopology.Lines,
                    new[] { 0, 1, 1, 2 },
                    new[] { Vector3.zero, Vector3.up, Vector3.right });
                yield return new MeshData(
                    MeshTopology.Points,
                    new[] { 0, 1, 2 },
                    new[] { Vector3.zero, Vector3.up, Vector3.right });
            }
        }

        [SetUp]
        public void SetUp()
        {
            m_Target = new GameObject("Target").AddComponent<MeshPickingTarget>();
            m_Mesh = new Mesh();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(m_Target.gameObject);
            Object.DestroyImmediate(m_Mesh);
        }

        [Test]
        public void NullMesh_ReturnsInvalidPickingMesh()
        {
            m_Target.collisionMesh = null;
            var pickingData = m_Target.GetPickingData();

            Assert.IsFalse(pickingData.valid);
        }

        [Test]
        public void CheckTopology_IsSameAsGivenMesh(
            [ValueSource(nameof(s_MeshCases))] MeshData data)
        {
            PopulateMesh(data);
            m_Target.collisionMesh = m_Mesh;

            var pickingData = m_Target.GetPickingData();
            Assume.That(pickingData.valid);

            Assert.AreEqual(data.topology, pickingData.mesh.GetTopology(0));
        }

        [Test]
        public void CheckIndices_SameAsGivenMesh(
            [ValueSource(nameof(s_MeshCases))] MeshData data)
        {
            PopulateMesh(data);
            m_Target.collisionMesh = m_Mesh;

            var pickingData = m_Target.GetPickingData();
            Assume.That(pickingData.valid);

            Assert.AreEqual(data.indices, pickingData.mesh.GetIndices(0));
        }

        [Test]
        public void CheckVertices_SameAsGivenMesh(
            [ValueSource(nameof(s_MeshCases))] MeshData data)
        {
            PopulateMesh(data);
            m_Target.collisionMesh = m_Mesh;

            var pickingData = m_Target.GetPickingData();
            Assume.That(pickingData.valid);

            Assert.AreEqual(data.vertices, pickingData.mesh.vertices);
        }

        [Test]
        public void GetPickingMesh_DoesntAllocate(
            [ValueSource(nameof(s_MeshCases))] MeshData data)
        {
            PopulateMesh(data);
            m_Target.collisionMesh = m_Mesh;

            Assert.That(TestScope, Is.Not.AllocatingGCMemory());

            void TestScope()
            {
                m_Target.GetPickingData();
            }
        }

        void PopulateMesh(MeshData data)
        {
            m_Mesh.vertices = data.vertices;
            m_Mesh.SetIndices(data.indices, data.topology, 0);
        }
    }
}
