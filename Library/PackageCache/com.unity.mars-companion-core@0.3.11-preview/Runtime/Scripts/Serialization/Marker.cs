using System;
using System.Collections.Generic;
using Unity.RuntimeSceneSerialization;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [Serializable]
    class Marker : IFormatVersion
    {
        const int k_FormatVersion = 1;

        [SerializeField]
        int m_FormatVersion = k_FormatVersion;

        [SerializeField]
        string m_Name;

        [SerializeField]
        List<HotspotContainer> m_Hotspots = new List<HotspotContainer>();

        public string name { get { return m_Name; } }
        public List<HotspotContainer> hotspots { get => m_Hotspots; set => m_Hotspots = value; }

        public Marker() { }

        public Marker(string name)
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
