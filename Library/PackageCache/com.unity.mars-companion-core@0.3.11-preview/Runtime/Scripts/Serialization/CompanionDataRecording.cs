using System;
using Unity.RuntimeSceneSerialization;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [Serializable]
    class CompanionDataRecording : IFormatVersion
    {
        const int k_FormatVersion = 2;

        [SerializeField]
        int m_FormatVersion = k_FormatVersion;

        [SerializeField]
        float m_FOVRadians;

        [SerializeField]
        float m_ZRotation;

        [SerializeField]
        bool m_HasVideo;

        [SerializeField]
        bool m_HasCameraPath;

        [SerializeField]
        bool m_HasPlaneData;

        [SerializeField]
        bool m_HasPointCloud;

        public float fovRadians { get { return m_FOVRadians; } }

        public float zRotation { get { return m_ZRotation; } }

        public bool HasVideo { get { return m_HasVideo; } }

        public bool HasCameraPath { get { return m_HasCameraPath; } }

        public bool HasPlaneData { get { return m_HasPlaneData; } }

        public bool HasPointCloud { get { return m_HasPointCloud; } }

        public CompanionDataRecording() { }

        public CompanionDataRecording(float fovRadians, float zRotation, bool hasVideo, bool hasCameraPath, bool hasPlaneData, bool hasPointCloud)
        {
            m_FOVRadians = fovRadians;
            m_ZRotation = zRotation;
            m_HasVideo = hasVideo;
            m_HasCameraPath = hasCameraPath;
            m_HasPlaneData = hasPlaneData;
            m_HasPointCloud = hasPointCloud;
        }

        public void CheckFormatVersion()
        {
            if (m_FormatVersion != k_FormatVersion)
                throw new FormatException($"Serialization format mismatch. Expected {k_FormatVersion} but was {m_FormatVersion}.");
        }
    }
}
