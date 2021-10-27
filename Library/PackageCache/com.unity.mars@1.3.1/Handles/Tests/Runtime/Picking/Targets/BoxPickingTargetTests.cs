using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.MARSHandles.Picking;
using UnityEngine;
using UnityEngine.TestTools.Constraints;
using Is = NUnit.Framework.Is;

namespace Unity.MARS.MARSHandles.Tests.Picking
{
    internal sealed class BoxPickingTargetTests
    {
        BoxPickingTarget m_Target;

        static readonly int[] s_Indices =
        {
            0, 1, 2, 3,
            0, 1, 5, 4,
            4, 5, 6, 7,
            6, 7, 3, 2,
            0, 4, 7, 3,
            1, 5, 6, 2,
        };

        static IEnumerable<Vector3> offsetCases
        {
            get
            {
                yield return Vector3.zero;
                yield return Vector3.up;
            }
        }

        static IEnumerable<Vector3> sizeCases
        {
            get
            {
                yield return new Vector3(1, 1, 1);
                yield return new Vector3(2, 2, 2);
                yield return new Vector3(5, 1, 1);
                yield return new Vector3(0, 1, 5);
            }
        }

        [SetUp]
        public void SetUp()
        {
            m_Target = new GameObject("Target").AddComponent<BoxPickingTarget>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(m_Target.gameObject);
        }

        [Test]
        public void CheckMesh_OnlyOneSubMesh(
            [ValueSource(nameof(offsetCases))] Vector3 offset,
            [ValueSource(nameof(sizeCases))] Vector3 size)
        {
            m_Target.Set(offset, size);
            var pickingData = m_Target.GetPickingData();
            Assume.That(pickingData.valid);

            Assert.AreEqual(1, pickingData.mesh.subMeshCount);
        }

        [Test]
        public void CheckTopology_IsQuad(
            [ValueSource(nameof(offsetCases))] Vector3 offset,
            [ValueSource(nameof(sizeCases))] Vector3 size)
        {
            m_Target.Set(offset, size);
            var pickingData = m_Target.GetPickingData();
            Assume.That(pickingData.valid);
            var topology = pickingData.mesh.GetTopology(0);

            Assert.AreEqual(MeshTopology.Quads, topology);
        }

        [Test]
        public void CheckIndices_RightAmountAndRightOrder(
            [ValueSource(nameof(offsetCases))] Vector3 offset,
            [ValueSource(nameof(sizeCases))] Vector3 size)
        {
            m_Target.Set(offset, size);
            var pickingData = m_Target.GetPickingData();
            Assume.That(pickingData.valid);
            var indices = pickingData.mesh.GetIndices(0);

            Assert.AreEqual(indices.Length, s_Indices.Length);
            for (int i = 0; i < indices.Length; ++i)
            {
                Assert.AreEqual(s_Indices[i], indices[i]);
            }
        }

        [Test]
        public void CheckVertices_AreValidWithSizeAndOffset(
            [ValueSource(nameof(offsetCases))] Vector3 offset,
            [ValueSource(nameof(sizeCases))] Vector3 size)
        {
            m_Target.Set(offset, size);
            var extents = size / 2.0f;

            var pickingData = m_Target.GetPickingData();
            Assume.That(pickingData.valid);
            var vertices = pickingData.mesh.vertices;

            Assert.AreEqual(8, vertices.Length);
            Assert.AreEqual(offset + new Vector3(-extents.x, -extents.y, extents.z), vertices[0]);
            Assert.AreEqual(offset + new Vector3(-extents.x, extents.y, extents.z), vertices[1]);
            Assert.AreEqual(offset + new Vector3(extents.x, extents.y, extents.z), vertices[2]);
            Assert.AreEqual(offset + new Vector3(extents.x, -extents.y, extents.z), vertices[3]);
            Assert.AreEqual(offset + new Vector3(-extents.x, -extents.y, -extents.z), vertices[4]);
            Assert.AreEqual(offset + new Vector3(-extents.x, extents.y, -extents.z), vertices[5]);
            Assert.AreEqual(offset + new Vector3(extents.x, extents.y, -extents.z), vertices[6]);
            Assert.AreEqual(offset + new Vector3(extents.x, -extents.y, -extents.z), vertices[7]);
        }

        [Test]
        public void GetPickingMesh_DoesntAllocate()
        {
            m_Target.Set(Vector3.zero, Vector3.one);
            
            Assert.That(TestScope, Is.Not.AllocatingGCMemory());
            
            void TestScope()
            {
                m_Target.GetPickingData();
            }
        }
    }
}