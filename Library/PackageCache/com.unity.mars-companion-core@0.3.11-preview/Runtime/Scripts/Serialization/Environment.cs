using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.RuntimeSceneSerialization;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [Serializable]
    class Environment : IFormatVersion
    {
        const int k_FormatVersion = 1;

        [SerializeField]
        int m_FormatVersion = k_FormatVersion;

        [SerializeField]
        float m_Height;

        [SerializeField]
        List<Vector3> m_Vertices = new List<Vector3>();

        [SerializeField]
        List<MRPlane> m_Planes = new List<MRPlane>();

        [SerializeField]
        MeshCapture m_MeshCapture = new MeshCapture();

        public float height { get { return m_Height; } }
        public List<Vector3> vertices { get { return m_Vertices; } }
        public List<MRPlane> planes { get { return m_Planes; } }

        public MeshCapture MeshCapture { get { return m_MeshCapture; } }

        public Environment() { }

        public Environment(float height) { m_Height = height; }

        public void CheckFormatVersion()
        {
            if (m_FormatVersion != k_FormatVersion)
                throw new FormatException($"Serialization format mismatch. Expected {k_FormatVersion} but was {m_FormatVersion}.");
        }
    }
}
