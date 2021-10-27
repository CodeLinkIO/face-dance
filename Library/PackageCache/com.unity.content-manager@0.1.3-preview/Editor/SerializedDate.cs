using System;
using UnityEngine;

namespace Unity.ContentManager
{
    /// <summary>
    /// A slimmed-down version of DateTime used only for serialization and ease of editing.
    /// </summary>
    [Serializable]
    struct SerializedDate
    {
#pragma warning disable 649
        [SerializeField]
        long m_Ticks;
#pragma warning restore 649

        public DateTime ToDateTime { get { return new DateTime(m_Ticks); } }
    }
}
