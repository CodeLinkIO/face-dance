using System;
using Unity.MARS;
using Unity.MARS.Settings;
using Unity.XRTools.Utils;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityObject = UnityEngine.Object;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Settings and button data used for a object creation button in the GUI
    /// </summary>
    [ScriptableSettingsPath(MARSCore.UserSettingsFolder)]
    [MovedFrom("Unity.MARS")]
    public class MarsObjectCreationSettings : EditorScriptableSettings<MarsObjectCreationSettings>
    {
        [Serializable]
        internal class ObjectCreationButtonSection
        {
            [SerializeField]
            string m_Name;

            [SerializeField]
            ObjectCreationData[] m_Buttons;

            [SerializeField]
            bool m_Expanded;

            public string Name => m_Name;

            public ObjectCreationData[] Buttons => m_Buttons;

            public bool Expanded
            {
                get => m_Expanded;
                set => m_Expanded = value;
            }

            public ObjectCreationButtonSection()
            {
                m_Name = "New Group";
                m_Expanded = true;
            }

            public ObjectCreationButtonSection(string name, bool expanded, ObjectCreationData[] buttons)
            {
                m_Name = name;
                m_Buttons = buttons;
                m_Expanded = expanded;
            }
        }

        [SerializeField]
        ObjectCreationButtonSection[] m_ObjectCreationButtonSections;

        internal ObjectCreationButtonSection[] ObjectCreationButtonSections => m_ObjectCreationButtonSections;

        /// <inheritdoc />
        protected override void OnLoaded()
        {
            base.OnLoaded();
            if (m_ObjectCreationButtonSections == null || m_ObjectCreationButtonSections.Length < 1)
            {
                ResetToDefault();
            }

            foreach (var creationButtonSection in ObjectCreationButtonSections)
            {
                foreach (var objCreationButton in creationButtonSection.Buttons)
                {
                    if(objCreationButton != null)
                        objCreationButton.UpdateObjectGUIContent();
                }
            }
        }

        void Reset()
        {
            ResetToDefault();

            s_Instance = this;
        }

        void ResetToDefault()
        {
            m_ObjectCreationButtonSections = new[]
            {
                new ObjectCreationButtonSection("Presets", true, new[]
                {
                    MarsObjectCreationResources.instance.HorizontalPlanePreset,
                    MarsObjectCreationResources.instance.VerticalPlanePreset,
                    MarsObjectCreationResources.instance.BodyPreset,
                    MarsObjectCreationResources.instance.FaceMaskPreset,
                    MarsObjectCreationResources.instance.ImageMarkerPreset,
                    MarsObjectCreationResources.instance.FloorObjectPreset,
                    MarsObjectCreationResources.instance.ElevatedSurfacePreset
                }),
                new ObjectCreationButtonSection("Primitives", true, new[]
                {
                    MarsObjectCreationResources.instance.ProxyObjectPreset,
                    MarsObjectCreationResources.instance.ProxyGroupPreset,
                    MarsObjectCreationResources.instance.ReplicatorPreset,
                    MarsObjectCreationResources.instance.SyntheticObjectPreset
                }),
                new ObjectCreationButtonSection("Visualizers", true, new[]
                {
                    MarsObjectCreationResources.instance.PlaneVisualsPreset,
                    MarsObjectCreationResources.instance.PointCloudVisualsPreset,
                    MarsObjectCreationResources.instance.FaceLandmarkVisualsPreset,
                    MarsObjectCreationResources.instance.LightEstimationVisualsPreset
                }),
                new ObjectCreationButtonSection("Simulated", true, new[]
                {
                    MarsObjectCreationResources.instance.SyntheticImageMarkerPreset,
                    MarsObjectCreationResources.instance.SyntheticBodyPreset
                })
            };
        }

        void OnValidate()
        {
            if (m_ObjectCreationButtonSections == null || m_ObjectCreationButtonSections.Length < 1)
            {
                ResetToDefault();
            }
        }
    }
}
