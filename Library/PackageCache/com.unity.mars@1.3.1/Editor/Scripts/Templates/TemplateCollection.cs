using System;
using UnityEditor.MARS.Simulation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Contains a collection of scenes that can be loaded through the MARS template selection window.
    /// </summary>
    [CreateAssetMenu(fileName = "Templates", menuName = "MARS/Template Collection")]
    [MovedFrom("Unity.MARS")]
    public class TemplateCollection : ScriptableObject
    {
#pragma warning disable 649
        [SerializeField]
        [Tooltip("Available scene templates")]
        TemplateData[] m_Templates;
#pragma warning restore 649

        /// <summary>
        /// Available scene templates
        /// </summary>
        public TemplateData[] templates { get { return m_Templates; } }
    }

    /// <summary>
    /// Data for a MARS scene template in the <c>TemplatesWindow</c>
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public struct TemplateData
    {
        /// <summary>
        /// Name of the template
        /// </summary>
        public string name;
        /// <summary>
        /// Scene asset
        /// </summary>
        public SceneAsset scene;
        /// <summary>
        /// Icon for template selection in the GUI
        /// </summary>
        public Texture2D icon;
        /// <summary>
        /// Environment mode the template uses
        /// </summary>
        public EnvironmentMode environmentMode;
    }
}
