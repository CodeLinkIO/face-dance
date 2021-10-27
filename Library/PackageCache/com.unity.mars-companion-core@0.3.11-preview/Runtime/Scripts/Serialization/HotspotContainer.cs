using System;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [Serializable]
    class HotspotContainer
    {
        [SerializeField]
        float m_X;

        [SerializeField]
        float m_Y;

        [SerializeField]
        string m_Name;

        public float x { get { return m_X; } }
        public float y { get { return m_Y; } }
        public string name { get { return m_Name; } }

        public HotspotContainer() { }

        public HotspotContainer(Vector2 vector, String name)
        {
            m_X = vector.x;
            m_Y = vector.y;
            m_Name = name;
        }

        public static implicit operator Vector2(HotspotContainer vector) { return new Vector2(vector.x, vector.y); }
    }
}
