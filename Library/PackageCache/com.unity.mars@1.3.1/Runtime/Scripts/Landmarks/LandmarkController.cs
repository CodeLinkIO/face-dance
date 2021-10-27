using System;
using Unity.MARS.Attributes;
using Unity.MARS.Simulation;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Scripting.APIUpdating;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Unity.MARS.Landmarks
{
    [Serializable]
    [Event(typeof(LandmarkEvent))]
    [MovedFrom("Unity.MARS")]
    public class LandmarkEvent : UnityEvent<LandmarkController> { }

    /// <summary>
    /// Component that handles getting the calculation for a landmark definition from a source and updating the output.
    /// This component references the source, output, and an optional extra settings component, and uses those components to decide when to recalculate.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class LandmarkController : MonoBehaviour, ILandmarkController, ISimulatable
    {
        [SerializeField]
        string m_LandmarkDefinitionName;

        [SerializeField]
        Component m_Settings;

        [SerializeField]
        Component m_Output;

        [SerializeField]
        Component m_Source;

        [SerializeField]
        bool m_UpdateOnDataChange = true;

        [SerializeField]
        LandmarkEvent m_OnLandmarkUpdated = new LandmarkEvent();

        bool m_NeedsInitialUpdate;
        Action<LandmarkController> m_CalculateAction;
        LandmarkDefinition m_Definition;

        public ILandmarkSettings settings
        {
            get { return m_Settings as ILandmarkSettings; }
            set { m_Settings = value as Component; }
        }

        public ILandmarkOutput output
        {
            get { return m_Output as ILandmarkOutput; }
            set { m_Output = value as Component; }
        }

        public LandmarkDefinition landmarkDefinition
        {
            get
            {
                if (m_Definition == null)
                {
                    var sourceInterface = source;
                    m_Definition = sourceInterface == null ? null : sourceInterface.AvailableLandmarkDefinitions.Find(x => string.Equals(x.name, m_LandmarkDefinitionName));
                }

                return m_Definition;
            }
            set
            {
                m_Definition = value;
                m_LandmarkDefinitionName = value.name;
                CreateSettingsFromDefinition();
                TrySetupLandmark();
            }
        }

        public ICalculateLandmarks source
        {
            get
            {
                return m_Source as ICalculateLandmarks;
            }
            set
            {
                m_Source = value as Component;
                TrySetupLandmark();
            }
        }

        public event Action<LandmarkController> updated;

        public void SetOutputType(Type outputType)
        {
            if (m_Output != null && m_Output.GetType() != outputType)
            {
                if (m_Output.gameObject == gameObject)
                    UnityObjectUtils.Destroy(m_Output); // Only destroy the landmark output if it is on this gameobject

                m_Output = null;
            }

            if (m_Output == null)
            {
#if UNITY_EDITOR
                output = (ILandmarkOutput)Undo.AddComponent(gameObject, outputType);
#else
                output = (ILandmarkOutput)gameObject.AddComponent(outputType);
#endif
            }
        }

        public void UpdateLandmark()
        {
            if (m_CalculateAction != null)
                m_CalculateAction(this);
            else
                return;

            if (output != null)
                output.UpdateOutput();
            else
                return;

            if (updated != null)
                updated(this);

            m_OnLandmarkUpdated.Invoke(this);
        }

        void SourceDataChanged(ICalculateLandmarks dataSource)
        {
            if (source != dataSource) // The source that is firing this event is no longer this landmark's source
            {
                dataSource.dataChanged -= SourceDataChanged;
            }
            else
            {
                if (m_UpdateOnDataChange || m_NeedsInitialUpdate)
                {
                    UpdateLandmark();
                    m_NeedsInitialUpdate = false;
                }
            }
        }

        void SettingsDataChanged(ILandmarkSettings dataSettings)
        {
            if (settings != dataSettings) // The settings component that is firing this event is no longer this landmark's settings
            {
                dataSettings.dataChanged -= SettingsDataChanged;
            }
            else
            {
                if (m_UpdateOnDataChange || m_NeedsInitialUpdate)
                {
                    UpdateLandmark();
                    m_NeedsInitialUpdate = false;
                }
            }
        }

        void OnValidate()
        {
            // Validate that the assigned components implement the interfaces that are required
            m_Source = UnityObjectUtils.ConvertUnityObjectToType<ICalculateLandmarks>(m_Source) as Component;
            m_Output = UnityObjectUtils.ConvertUnityObjectToType<ILandmarkOutput>(m_Output) as Component;
            m_Settings = UnityObjectUtils.ConvertUnityObjectToType<ILandmarkSettings>(m_Settings) as Component;
        }

        void CreateSettingsFromDefinition()
        {
            if (m_Settings != null && m_Settings.GetType() != landmarkDefinition.settingsType)
            {
                if (m_Settings.gameObject == gameObject)
                    UnityObjectUtils.Destroy(m_Settings); // Only destroy the landmark settings if it is on this gameobject

                m_Settings = null;
            }

            if (landmarkDefinition.settingsType != null && m_Settings == null)
            {
#if UNITY_EDITOR
                settings = Undo.AddComponent(gameObject, landmarkDefinition.settingsType) as ILandmarkSettings;
#else
                settings = gameObject.AddComponent(landmarkDefinition.settingsType) as ILandmarkSettings;
#endif
            }
        }

        void TrySetupLandmark()
        {
            if (source != null && !string.IsNullOrEmpty(m_LandmarkDefinitionName))
                source.SetupLandmark(this);
        }

        void OnEnable()
        {
            m_NeedsInitialUpdate = true;
            if (source != null)
            {
                m_CalculateAction = source.GetLandmarkCalculation(landmarkDefinition);
                source.dataChanged += SourceDataChanged;
            }

            if (settings != null)
                settings.dataChanged += SettingsDataChanged;
        }

        void OnDisable()
        {
            if (source != null)
                source.dataChanged -= SourceDataChanged;

            if (settings != null)
                settings.dataChanged += SettingsDataChanged;
        }
    }

    [MovedFrom("Unity.MARS")]
    public static class CreateLandmarkMethods
    {
        public static LandmarkController CreateLandmarkAsChild(this ICalculateLandmarks source, LandmarkDefinition definition, Type landmarkDataType)
        {
            var landmarkName = definition.name;
#if UNITY_EDITOR
            landmarkName = ObjectNames.NicifyVariableName(landmarkName);
#endif
            var landmarkController = new GameObject(landmarkName).AddComponent<LandmarkController>();
            if (landmarkController == null)
            {
                Debug.LogError(
                    "Error instantiating landmark. Unable to create the landmark "
                    + definition.name);
                return null;
            }

            Transform parent = null;
            var sourceAsComponent = (source as Component);
            if (sourceAsComponent != null)
                parent = sourceAsComponent.transform;

            if (definition.settingsType != null)
                landmarkController.settings = landmarkController.gameObject.AddComponent(definition.settingsType) as ILandmarkSettings;

            landmarkController.output = (ILandmarkOutput) landmarkController.gameObject.AddComponent(landmarkDataType);

            landmarkController.transform.SetParent(parent, false);
            landmarkController.landmarkDefinition = definition;
            landmarkController.source = source;
#if UNITY_EDITOR
            Undo.RegisterCreatedObjectUndo(landmarkController.gameObject, "Create Landmark");
#endif
            return landmarkController;
        }
    }
}
