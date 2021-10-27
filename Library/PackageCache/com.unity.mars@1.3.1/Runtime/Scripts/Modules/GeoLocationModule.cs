using System;
using System.Linq;
using Unity.MARS.Data;
using Unity.MARS.MARSUtils;
using Unity.MARS.Query;
using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace Unity.MARS.Providers
{
    [ScriptableSettingsPath(MARSCore.UserSettingsFolder)]
    [ModuleOrder(ModuleOrders.GeoLocationLoadOrder)]
    [MovedFrom("Unity.MARS")]
    public class GeoLocationModule : ScriptableSettings<GeoLocationModule>,
        IModuleDependency<MARSDatabase>, IModuleDependency<SlowTaskModule>, IModuleBuildCallbacks
    {
        public const float MaxLatitude = 90f;
        public const float MaxLongitude = 180f;

        // default simulated coordinates is San Francisco, USA
        const float k_DefaultLatitude = 37.7749f;
        const float k_DefaultLongitude = -122.4194f;

        const string k_UseLocationScriptingDefine = "UNITY_MARS_USE_LOCATION";

        [SerializeField]
        [Tooltip("Automatically start the Location Service on startup")]
        bool m_AutoStartLocationService = false;

        [SerializeField]
        GeographicCoordinate m_CurrentLocation;

#pragma warning disable 414
        [SerializeField]
        [Tooltip("Desired accuracy of the location service, in meters")]
        float m_DesiredAccuracy = 100f;

        [SerializeField]
        [Tooltip("Distance before a location updated event occurs")]
        float m_UpdateDistance = 25f;

        [SerializeField]
        [Tooltip("When enabled, the location service will continue to poll for updates after acquiring initial location")]
        bool m_ContinuousUpdates;

        [SerializeField] [Tooltip("How often to check for updates to geo location (in seconds)")]
        int m_UpdateInterval = 15;

        [SerializeField] [Tooltip("How long to wait for the location service to initialize before giving up")]
        int m_InitializationTimeout = 20;

        int m_InitializationTimeCounter;

        MARSDatabase m_Database;
        SlowTaskModule m_SlowTaskModule;
#pragma warning restore 414

#if UNITY_EDITOR
        bool m_PlayerDefineSet;
#endif

        public event Action<GeographicCoordinate> GeoLocationChanged;

        internal bool autoStartLocationService { get { return m_AutoStartLocationService; } }

        /// <summary>
        /// When enabled, the location service will continue to poll for updates after acquiring initial location
        /// </summary>
        public bool continuousUpdates
        {
            get { return m_ContinuousUpdates; }
            set { m_ContinuousUpdates = value; }
        }

        /// <inheritdoc />
        void IModuleDependency<MARSDatabase>.ConnectDependency(MARSDatabase dependency)
        {
            m_Database = dependency;
        }

        /// <inheritdoc />
        void IModuleDependency<SlowTaskModule>.ConnectDependency(SlowTaskModule dependency)
        {
            m_SlowTaskModule = dependency;
        }

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            // setup our static functionality injection for IUsesGeoLocation implementors
            IUsesGeoLocationMethods.TryGetGeoLocationAction = TryGetGeoLocation;
            IUsesGeoLocationMethods.TryStartServiceFunction = TryStartService;
            IUsesGeoLocationMethods.SubscribeGeoLocationChangedAction = SubscribeGeoLocationChanged;
            IUsesGeoLocationMethods.UnsubscribeGeoLocationChangedAction = UnsubscribeGeoLocationChanged;

            if (m_CurrentLocation.latitude == default && m_CurrentLocation.longitude == default)
                m_CurrentLocation = new Vector2(k_DefaultLatitude, k_DefaultLongitude);

            // since this is the only environment trait provider so far,  we add this environment semantic tag
            // to the reserved data ID here.  In the future it may / should live in a more central place.
            m_Database.GetTraitProvider(out MARSTraitDataProvider<bool> tagTraitProvider);
            tagTraitProvider?.AddOrUpdateTrait((int)ReservedDataIDs.ImmediateEnvironment, TraitNames.Environment, true);
#if UNITY_EDITOR
            if (m_AutoStartLocationService)
                AddOrUpdateLocationTrait();
#else
            if (m_AutoStartLocationService)
                TryStartService();
            else
                Debug.Log("MARS GeoLocation is not configured to request location service permission for this project."
                    + " See 'GeoLocationModule' asset.");
#endif
        }

        void SubscribeGeoLocationChanged(Action<GeographicCoordinate> action)
        {
            GeoLocationChanged += action;
        }

        void UnsubscribeGeoLocationChanged(Action<GeographicCoordinate> action)
        {
            GeoLocationChanged -= action;
        }

        internal void AddOrUpdateLocationTrait()
        {
            m_Database.GetTraitProvider(out MARSTraitDataProvider<Vector2> vector2TraitProvider);
            vector2TraitProvider?.AddOrUpdateTrait((int)ReservedDataIDs.ImmediateEnvironment, TraitNames.Geolocation, m_CurrentLocation);
            GeoLocationChanged?.Invoke(m_CurrentLocation);
        }

        /// <summary>
        /// Given a GeographicCoordinate, immediately update the GeoLocationModule and MARS database with it
        /// </summary>
        public void SetCurrentLocationAndUpdateTrait(GeographicCoordinate location)
        {
            m_CurrentLocation = location;
            AddOrUpdateLocationTrait();
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            m_InitializationTimeCounter = 0;

#if UNITY_MARS_USE_LOCATION
            switch (Input.location.status)
            {
                case LocationServiceStatus.Initializing:
                    m_SlowTaskModule.RemoveSlowTask(ServiceStartTask);
                    break;
                case LocationServiceStatus.Running:
                    if (m_ContinuousUpdates)
                        m_SlowTaskModule.RemoveSlowTask(UpdateLocationTask);
                    break;
            }
#endif
        }

        void UpdateLocationTask()
        {
#if UNITY_MARS_USE_LOCATION
            if (Input.location.status != LocationServiceStatus.Running)
                return;

            var location = Input.location.lastData;
            if (location.latitude != m_CurrentLocation.latitude ||
                location.longitude != m_CurrentLocation.longitude)
            {
                m_CurrentLocation = location;
                AddOrUpdateLocationTrait();
            }
#endif
        }

        void ServiceStartTask()
        {
#if UNITY_MARS_USE_LOCATION
            var service = Input.location;
            switch(service.status)
            {
                case LocationServiceStatus.Stopped:
                {
                    if (Input.location.isEnabledByUser)
                        Input.location.Start(m_DesiredAccuracy, m_UpdateDistance);
                    else
                    {
                        Debug.Log("Location service not enabled by user");
                        m_SlowTaskModule.RemoveSlowTask(ServiceStartTask);
                    }
                    break;
                }
                case LocationServiceStatus.Failed:
                {
                    if (MarsDebugSettings.GeoLocationModuleLogging)
                    {
                        if(!service.isEnabledByUser)
                            Debug.LogWarning("Location service start failed - user has location disabled");
                        else
                            Debug.LogWarning("Location service start failed - unknown reason");
                    }
                    m_SlowTaskModule.RemoveSlowTask(ServiceStartTask);
                    break;
                }
                case LocationServiceStatus.Initializing:
                {
                    if (m_InitializationTimeCounter > 0)
                    {
                        m_InitializationTimeCounter--;
                    }
                    else
                    {
                        if (MarsDebugSettings.GeoLocationModuleLogging)
                            Debug.LogWarningFormat("Location service start timed out after {0} seconds", m_InitializationTimeout);

                        m_SlowTaskModule.RemoveSlowTask(ServiceStartTask);
                    }
                    break;
                }
                case LocationServiceStatus.Running:
                {
                    m_SlowTaskModule.RemoveSlowTask(ServiceStartTask);
                    if(m_ContinuousUpdates)
                        m_SlowTaskModule.AddSlowTask(UpdateLocationTask, m_UpdateInterval);

                    m_CurrentLocation = Input.location.lastData;
                    AddOrUpdateLocationTrait();

                    // since GPS has significant power overhead, unless we've explicitly asked for continuous updates,
                    // stop the service once we've ascertained location.  It can be restarted later if needed.
                    if (!m_ContinuousUpdates)
                        Input.location.Stop();

                    break;
                }
            }
#endif
        }

        public bool TryStartService()
        {
#if UNITY_MARS_USE_LOCATION
            // On Android we have to request permission; iOS will prompt user for permission when we call
            // LocationService.Start()
#if UNITY_ANDROID
            if (!Input.location.isEnabledByUser)
                UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.FineLocation);
#endif
            m_InitializationTimeCounter = m_InitializationTimeout;

            var status = Input.location.status;
            if (status == LocationServiceStatus.Running || status == LocationServiceStatus.Initializing)
                return false;

            m_SlowTaskModule.AddSlowTask(ServiceStartTask, 1f);
            AddOrUpdateLocationTrait();
#endif
            return true;
        }

        public bool TryGetGeoLocation(out GeographicCoordinate coordinate)
        {
#if UNITY_EDITOR
            coordinate = m_CurrentLocation;
            return true;
#elif UNITY_MARS_USE_LOCATION
            if (Input.location.status == LocationServiceStatus.Running)
            {
                coordinate = Input.location.lastData;
                m_CurrentLocation = coordinate;
                return true;
            }

            coordinate = GeographicCoordinate.Invalid;
            return false;
#else
            coordinate = default;
            return false;
#endif
        }

#if UNITY_EDITOR
        /// <inheritdoc />
        void IModuleBuildCallbacks.OnPreprocessBuild()
        {
            m_PlayerDefineSet = false;
            foreach (var buildScene in EditorBuildSettings.scenes)
            {
                var sceneOpened = false;
                var scenePath = buildScene.path;
                // Check if scene is already open
                var scene = SceneManager.GetSceneByPath(scenePath);

                // If not loaded, load scene additively (to be closed later)
                if (!scene.IsValid())
                {
                    sceneOpened = true;
                    scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Additive);
                }

                var session = GameObjectUtils.GetComponentInScene<MARSSession>(scene);
                if (session != null)
                {
                    var requiredTraits = session.requirements.TraitRequirements;
                    foreach (var requiredTrait in requiredTraits)
                    {
                        if (requiredTrait.TraitName == TraitNames.Geolocation)
                        {
                            if (sceneOpened)
                                EditorSceneManager.CloseScene(scene, true);

                            var buildTargetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
                            var scriptingDefines = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup).Split(';').ToList();

                            // Add to beginning so Remove in OnPostprocessBuild will remove the one we added
                            scriptingDefines.Insert(0, k_UseLocationScriptingDefine);
                            PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, string.Join(";", scriptingDefines.ToArray()));
                            m_PlayerDefineSet = true;
                            return;
                        }
                    }
                }

                if (sceneOpened)
                    EditorSceneManager.CloseScene(scene, true);
            }
        }

        /// <inheritdoc />
        void IModuleBuildCallbacks.OnProcessScene(Scene scene) { }

        /// <inheritdoc />
        void IModuleBuildCallbacks.OnPostprocessBuild()
        {
            if (m_PlayerDefineSet)
            {
                m_PlayerDefineSet = false;

                var buildTargetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
                var scriptingDefines = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup).Split(';').ToList();

                scriptingDefines.Remove(k_UseLocationScriptingDefine);
                PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, string.Join(";", scriptingDefines.ToArray()));
            }
        }
#endif
    }
}
