using System;
using UnityEngine;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Set of icons for GUI that switches between the professional skin and personal skin
    /// versions based on the current GUI skin.
    /// </summary>
    [Serializable]
    public struct DarkLightIconPair
    {
#pragma warning disable 649
        [SerializeField]
        [Tooltip("Icon for the professional skin")]
        Texture2D m_Dark;

        [SerializeField]
        [Tooltip("Icon for the personal skin")]
        Texture2D m_Light;
#pragma warning restore 649

        /// <summary>
        /// Icon for the professional skin
        /// </summary>
        public Texture2D Dark => m_Dark;
        /// <summary>
        /// Icon for the personal skin
        /// </summary>
        public Texture2D Light => m_Light;

        /// <summary>
        /// Icon for the currently active GUI skin
        /// </summary>
        public Texture2D Icon => EditorGUIUtility.isProSkin ? m_Dark : m_Light;
    }
}
