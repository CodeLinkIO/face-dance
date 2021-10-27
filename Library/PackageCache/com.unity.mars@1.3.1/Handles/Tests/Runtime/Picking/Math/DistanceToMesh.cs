using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.MARSHandles.Picking;
using UnityEngine;

namespace Unity.MARS.MARSHandles.Tests.HandleUtility
{
    sealed class DistanceToMesh : PickingTests
    {
        public class TestCase
        {
            public readonly Vector3 offset;
            public readonly float targetDist;
            readonly string m_Name;
            readonly Func<Mesh> m_MeshCreator;

            public TestCase(string name, Func<Mesh> meshCreator, float targetDist, Vector3 offset = default(Vector3))
            {
                this.m_MeshCreator = meshCreator;
                this.targetDist = targetDist;
                this.offset = offset;
                this.m_Name = name;
            }

            public Mesh Create()
            {
                return m_MeshCreator.Invoke();
            }

            public override string ToString()
            {
                return m_Name;
            }
        }

        static readonly TestCase[] s_TestCases =
        {
            new TestCase("Point Mesh [Cursor: On Mesh]", CreatePointMesh, 0f),
            new TestCase("Point Mesh [Cursor: Off Mesh]", CreatePointMesh, 25f, new Vector3(0, 1, 0)),

            new TestCase("Line Mesh [Cursor: On Mesh]", CreateLineMesh, 0f),
            new TestCase("Line Mesh [Cursor: Off Mesh]", CreateLineMesh, 25f, new Vector3(0, 1, 0)),

            new TestCase("Line Strip Mesh [Cursor: On Mesh]", CreateLineStripMesh, 0f),
            new TestCase("Line Strip Mesh [Cursor: Off Mesh]", CreateLineStripMesh, 25f, new Vector3(0, 1, 0)),

            new TestCase("Triangle Mesh [Cursor: On Mesh]", CreateTriangleMesh, 0f),
            new TestCase("Triangle Mesh [Cursor: Off Mesh]", CreateTriangleMesh, 25f, new Vector3(0, 2, 0)),

            new TestCase("Quad Mesh [Cursor: On Mesh]", CreateQuadMesh, 0f),
            new TestCase("Quad Mesh [Cursor: Off Mesh]", CreateQuadMesh, 25f, new Vector3(0, 2, 0)),
        };

        [Test]
        public void DistanceTo([ValueSource("s_TestCases")] TestCase test)
        {
            Mesh mesh = test.Create();

            Assert.AreEqual(test.targetDist, ScreenDistanceUtility.DistanceToMesh(
                screenCenter,
                camera,
                Matrix4x4.Translate(objectPos + test.offset),
                mesh));

            UnityEngine.Object.DestroyImmediate(mesh);
        }

        static Mesh CreatePointMesh()
        {
            Mesh mesh = new Mesh();
            mesh.SetVertices(new List<Vector3> {new Vector3(0, 0, 0)});
            mesh.SetIndices(new []{0}, MeshTopology.Points, 0);
            return mesh;
        }

        static Mesh CreateLineMesh()
        {
            Mesh mesh = new Mesh();
            mesh.SetVertices(new List<Vector3> { new Vector2(-10, 0), new Vector3(10, 0) });
            mesh.SetIndices(new[] { 0, 1 }, MeshTopology.Lines, 0);
            return mesh;
        }

        static Mesh CreateLineStripMesh()
        {
            Mesh mesh = new Mesh();
            mesh.SetVertices(new List<Vector3> { new Vector2(-10, 0), new Vector3(10, 0) });
            mesh.SetIndices(new[] { 0, 1 }, MeshTopology.LineStrip, 0);
            return mesh;
        }

        static Mesh CreateTriangleMesh()
        {
            Mesh mesh = new Mesh();
            mesh.SetVertices(new List<Vector3>
            {
                new Vector3(-1, -1, 0),
                new Vector3(0, 1, 0),
                new Vector3(1, -1, 0)
            });
            mesh.SetIndices(new[] { 0, 1, 2 }, MeshTopology.Triangles, 0);
            return mesh;
        }

        static Mesh CreateQuadMesh()
        {
            Mesh mesh = new Mesh();
            mesh.SetVertices(new List<Vector3>
            {
                new Vector3(-1, -1, 0),
                new Vector3(-1, 1, 0),
                new Vector3(1, 1, 0),
                new Vector3(1, -1, 0)
            });
            mesh.SetIndices(new[] { 0, 1, 2, 3}, MeshTopology.Quads, 0);
            return mesh;
        }
    }
}
