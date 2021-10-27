using System;
using Unity.RuntimeSceneSerialization;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [Serializable]
    class Prefab : IFormatVersion
    {
        const int k_FormatVersion = 1;

        [SerializeField]
        int m_FormatVersion = k_FormatVersion;

        // ReSharper disable NotAccessedField.Local
        [SerializeField]
        string m_Name;
        // ReSharper restore NotAccessedField.Local

        public Prefab() { }

        public Prefab(string name)
        {
            m_Name = name;
        }

        public void CheckFormatVersion()
        {
            if (m_FormatVersion != k_FormatVersion)
                throw new FormatException($"Serialization format mismatch. Expected {k_FormatVersion} but was {m_FormatVersion}.");
        }
    }
}
