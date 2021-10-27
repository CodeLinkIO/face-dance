using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.XRTools.Utils;
using Unity.XRTools.Utils.GUI;
using Unity.XRTools.Utils.Internal;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;

#if UNITY_2019_2_OR_NEWER
using UnityEditor;
#endif

namespace Unity.XRTools.ModuleLoader
{
    /// <summary>
    /// Contains a collection of functionality providers which can be used to inject functionality on functionality
    /// subscribers. Injecting functionality involves calling ConnectSubscriber on providers indicated by
    /// IFunctionalitySubscriber&lt;&gt; with the subscriber as an argument, allowing the provider to set itself on
    /// the subscriber's provider property which can then be accessed via extension methods defined alongside the
    /// subscriber interface
    /// </summary>
    [CreateAssetMenu(fileName = "Island", menuName = "ModuleLoader/Functionality Island")]
    public class FunctionalityIsland : ScriptableObject, IProvidesFunctionalityInjection
    {
        /// <summary>
        /// Used for serializing preferred default provider types which should be chosen if more than one class
        /// implements the same provider interface
        /// </summary>
        [Serializable]
        public class DefaultProvider
        {
#pragma warning disable 649
            [SerializeField]
            string m_ProviderTypeName;

            [SerializeField]
            string m_DefaultProviderTypeName;

            [SerializeField]
            GameObject m_DefaultProviderPrefab;
#pragma warning restore 649

            Type m_ProviderType;
            Type m_DefaultProviderType;

            /// <summary>
            /// FullName of the provider interface type
            /// </summary>
            public string providerTypeName { get { return m_ProviderTypeName; } }

            /// <summary>
            /// FullName of the desired type which implements the provider interface
            /// </summary>
            public string defaultProviderTypeName { get { return m_DefaultProviderTypeName; } }

            /// <summary>
            /// Prefab reference to be instantiated when loading a provider of the given type
            /// </summary>
            public GameObject defaultProviderPrefab { get { return m_DefaultProviderPrefab; } }

            /// <summary>
            /// Find a type which matches the name specified by the provider type name string and cache the result;
            /// Return the cached result if it exists
            /// </summary>
            public Type providerType
            {
                get
                {
                    if (m_ProviderType != null)
                        return m_ProviderType;

                    m_ProviderType = ReflectionUtils.FindType(t => t.FullName == m_ProviderTypeName);
                    return m_ProviderType;
                }
                internal set
                {
                    m_ProviderType = value;
                }
            }

            /// <summary>
            /// Find a type which matches the name specified by the default provider type name string and cache the result;
            /// Return the cached result if it exists
            /// </summary>
            public Type defaultProviderType
            {
                get
                {
                    if (m_DefaultProviderType != null)
                        return m_DefaultProviderType;

                    m_DefaultProviderType = ReflectionUtils.FindType(t => t.FullName == m_DefaultProviderTypeName);
                    return m_DefaultProviderType;
                }
                internal set
                {
                    m_DefaultProviderType = value;
                }
            }
        }

        [Serializable]
        internal class PlatformOverride
        {
#pragma warning disable 649
            [FlagsProperty]
            [SerializeField]
            ModuleLoaderCore.OverridePlatforms m_Platforms;

            [FlagsProperty]
            [SerializeField]
            ModuleLoaderCore.OverrideModes m_Modes;

            [SerializeField]
            DefaultProvider[] m_DefaultProviders;
#pragma warning restore 649

            public ModuleLoaderCore.OverridePlatforms platforms { get { return m_Platforms; } }
            public ModuleLoaderCore.OverrideModes modes { get { return m_Modes; } }
            public DefaultProvider[] defaultProviders { get { return m_DefaultProviders; } }
        }

        /// <summary>
        /// Profiler label for SetupDefaultProviders
        /// </summary>
        public const string SetupDefaultProvidersProfilerLabel = "FunctionalityIsland.SetupDefaultProviders()";

        /// <summary>
        /// Profiler label for RequireProviders
        /// </summary>
        public const string RequireProvidersProfilerLabel = "FunctionalityIsland.RequireProviders()";

        /// <summary>
        /// Profiler label for InjectFunctionality
        /// </summary>
        public const string InjectFunctionalityProfilerLabel = "FunctionalityIsland.InjectFunctionality()";

        const string k_EqualPriorityMessage = "Multiple providers with equal priority found for {0}. Using {1}, but could also use {2}.\n" +
            "You can resolve this issue by adding the desired provider as a default in {3}";

        static readonly ProviderSelectionOptionsAttribute k_DefaultProviderSelectionOptions = new ProviderSelectionOptionsAttribute();

        static readonly Dictionary<string, Type> k_ProviderTypes = new Dictionary<string, Type>();
        static readonly Dictionary<Type, ProviderSelectionOptionsAttribute> k_PreferredProviders = new Dictionary<Type, ProviderSelectionOptionsAttribute>();
        static readonly Dictionary<Type, List<Type>> k_ProviderToProviderInterfaces = new Dictionary <Type, List<Type>>();

        [SerializeField]
        DefaultProvider[] m_DefaultProviders = new DefaultProvider[0];

        [SerializeField]
        PlatformOverride[] m_PlatformOverrides = new PlatformOverride[0];

        DefaultProvider[] m_EffectiveDefaultProviders;

        // Allows us to check whether the island is included in the list of islands in the FI module
        bool m_Setup;

        readonly Dictionary<Type, IFunctionalityProvider> m_Providers = new Dictionary<Type, IFunctionalityProvider>();
        readonly HashSet<IFunctionalityProvider> m_UniqueProviders = new HashSet<IFunctionalityProvider>();

        /// <summary>
        /// Dictionary of provider instances which are currently loaded on this island, keyed by the provider interface type
        /// </summary>
        public Dictionary<Type, IFunctionalityProvider> providers { get { return m_Providers; } }

        /// <summary>
        /// Set of unique providers--the providers dictionary may contain a provider object in more than one slot
        /// </summary>
        public HashSet<IFunctionalityProvider> uniqueProviders { get { return m_UniqueProviders; } }

        /// <summary>
        /// Array of DefaultProviders specified by this island
        /// </summary>
        public DefaultProvider[] defaultProviders { get { return m_DefaultProviders; } }

#if UNITY_EDITOR
        internal bool foldoutState { get; set; }
#endif

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly HashSet<Type> k_UniqueTypes = new HashSet<Type>();
        static readonly List<Type> k_SubscriberInterfaces = new List<Type>();
        static readonly List<Type> k_AllImplementors = new List<Type>();
        static readonly List<Type> k_Implementors = new List<Type>();
        static readonly HashSet<string> k_DuplicateProviderTypes = new HashSet<string>();
        static readonly HashSet<ModuleLoaderCore.OverridePlatforms> k_DuplicatePlatforms = new HashSet<ModuleLoaderCore.OverridePlatforms>();
        static readonly Dictionary<GameObject, GameObject> k_NewProviderPrefabInstances = new Dictionary<GameObject, GameObject>();
        static readonly List<Type> k_Types = new List<Type>();
        static readonly List<string> k_TypeNames = new List<string>();
        static readonly List<IFunctionalitySubscriber> k_Subscribers = new List<IFunctionalitySubscriber>();

        static FunctionalityIsland()
        {
#if UNITY_2019_2_OR_NEWER && UNITY_EDITOR
            foreach (var type in TypeCache.GetTypesDerivedFrom<IFunctionalityProvider>())
            {
                k_ProviderTypes[type.FullName] = type;
                var providerInterfaces = new List<Type>();
                k_ProviderToProviderInterfaces[type] = providerInterfaces;
                foreach (var providerInterface in type.GetInterfaces())
                {
                    if (providerInterface == typeof(IFunctionalityProvider))
                        continue;

                    if (typeof(IFunctionalityProvider).IsAssignableFrom(providerInterface))
                        providerInterfaces.Add(providerInterface);
                }
            }

            foreach (var type in TypeCache.GetTypesWithAttribute<ProviderSelectionOptionsAttribute>())
            {
                k_PreferredProviders[type] = type.GetAttribute<ProviderSelectionOptionsAttribute>();
            }
#else
            ReflectionUtils.ForEachType(type =>
            {
                if (!typeof(IFunctionalityProvider).IsAssignableFrom(type))
                    return;

                k_ProviderTypes[type.FullName] = type;
                var providerInterfaces = new List<Type>();
                k_ProviderToProviderInterfaces[type] = providerInterfaces;
                foreach (var providerInterface in type.GetInterfaces())
                {
                    if (providerInterface == typeof(IFunctionalityProvider))
                        continue;

                    if (typeof(IFunctionalityProvider).IsAssignableFrom(providerInterface))
                        providerInterfaces.Add(providerInterface);
                }

                var attributes = type.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    var priority = attribute as ProviderSelectionOptionsAttribute;
                    if (priority != null)
                    {
                        k_PreferredProviders[type] = priority;
                    }
                }
            });
#endif
        }

        static void GetDefaultProviderTypesBatch(DefaultProvider[] providers)
        {
            k_TypeNames.Clear();
            k_Types.Clear();

            foreach (var row in providers)
            {
                k_TypeNames.Add(row.defaultProviderTypeName);
            }

            FindTypesByFullNameBatch(k_TypeNames, k_Types);

            for(var i = 0; i < k_Types.Count; i++)
            {
                providers[i].defaultProviderType = k_Types[i];
            }
        }

        static void GetProviderTypesBatch(DefaultProvider[] providers)
        {
            k_TypeNames.Clear();
            k_Types.Clear();

            foreach (var row in providers)
            {
                k_TypeNames.Add(row.providerTypeName);
            }

            FindTypesByFullNameBatch(k_TypeNames, k_Types);

            for(var i = 0; i < k_Types.Count; i++)
            {
                providers[i].providerType = k_Types[i];
            }
        }

        static void FindTypesByFullNameBatch(List<string> typeNames, List<Type> resultList)
        {
            foreach (var typeName in typeNames)
            {
                Type type;
                if (k_ProviderTypes.TryGetValue(typeName, out type))
                    resultList.Add(type);
                else
                    resultList.Add(null);
            }
        }

        /// <summary>
        /// Returns the ProviderPriority attribute for a given type, if it exists
        /// </summary>
        /// <param name="type">The provider type to check</param>
        /// <returns>The ProviderPriority attribute, if it exists</returns>
        public static ProviderSelectionOptionsAttribute GetProviderSelectionOptions(Type type)
        {
            ProviderSelectionOptionsAttribute selectionOptions;
            return k_PreferredProviders.TryGetValue(type, out selectionOptions) ? selectionOptions : k_DefaultProviderSelectionOptions;
        }

        internal void Setup()
        {
            ValidateDefaultProviders();

            // Use a separate variable for the effective default providers so that overriding m_DefaultProviders does
            // not affect serialization
            m_EffectiveDefaultProviders = m_DefaultProviders;

            // Check if a platform override exists for the current platform
            if (m_PlatformOverrides != null)
            {
                var currentPlatform = ModuleLoaderCore.GetCurrentOverridePlatform();
                foreach (var platformOverride in m_PlatformOverrides)
                {
                    if ((platformOverride.platforms & currentPlatform) == 0)
                        continue;

                    var modes = platformOverride.modes;
                    if (!ModuleLoaderCore.CheckCurrentMode(modes))
                        continue;

                    m_EffectiveDefaultProviders = platformOverride.defaultProviders;
                }
            }

            // By default, objects that this island injects on will use this island as the functionality injection provider
            AddProvider(typeof(FunctionalityIsland), this);
            m_Setup = true;
        }

        void OnValidate()
        {
            ValidateDefaultProviders();
        }

        void ValidateDefaultProviders()
        {
            if (m_DefaultProviders != null)
                ValidateProviderArray(m_DefaultProviders);

            if (m_PlatformOverrides != null)
            {
                k_DuplicatePlatforms.Clear();
                foreach (var platformOverride in m_PlatformOverrides)
                {
                    var platforms = platformOverride.platforms;
                    ValidateProviderArray(platformOverride.defaultProviders, platforms);
                    if (!k_DuplicatePlatforms.Add(platforms))
                        Debug.LogWarning(string.Format("Duplicate instances of {0}", platforms), this);
                }
            }
        }

        void ValidateProviderArray(DefaultProvider[] defaultProviderArray, ModuleLoaderCore.OverridePlatforms? platform = null)
        {
            k_DuplicateProviderTypes.Clear();

            GetDefaultProviderTypesBatch(defaultProviderArray);
            GetProviderTypesBatch(defaultProviderArray);

            foreach (var row in defaultProviderArray)
            {
                var providerTypeName = row.providerTypeName;

                // Suppress warning when adding a new empty element
                if (providerTypeName == string.Empty)
                    continue;

                var providerType = row.providerType;
                if (providerType == null)
                    Debug.LogWarning(string.Format("Could not find provider type {0}", providerTypeName), this);

                var prefab = row.defaultProviderPrefab;
                if (prefab != null)
                {
                    // We can't call GetComponentsInChildren to check whether this prefab has the right component types
                }
                else
                {
                    var defaultProviderTypeName = row.defaultProviderTypeName;

                    // Suppress warning when adding a new empty element
                    if (defaultProviderTypeName == string.Empty)
                        continue;

                    var defaultProviderType = row.defaultProviderType;
                    if (defaultProviderType == null)
                    {
                        Debug.LogWarning(string.Format("Could not find default provider type {0}", defaultProviderTypeName), this);
                    }
                    else
                    {
                        var selectionOptions = GetProviderSelectionOptions(defaultProviderType);
                        if (selectionOptions != null && selectionOptions.DisallowAutoCreation)
                        {
                            Debug.LogWarning($"Provider type {defaultProviderTypeName} does not allow automatic instance creation. " +
                                "It can only be used as a default provider if a prefab reference is specified.", this);
                        }
                    }
                }

                if (!k_DuplicateProviderTypes.Add(providerTypeName))
                {
                    if (platform.HasValue)
                        Debug.LogWarning(string.Format("Duplicate instances of {0} in {1}", providerTypeName, platform), this);
                    else
                        Debug.LogWarning(string.Format("Duplicate instances of {0}", providerTypeName), this);
                }
            }
        }

        /// <summary>
        /// Set up functionality providers from the list of default providers
        /// This allows custom serialized data to be set up on prefabs for providers
        /// </summary>
        /// <param name="subscriberTypes">The types of subscribers that need providers</param>
        /// <param name="newProviders">(Optional) A list to which new providers will be added</param>
        public void SetupDefaultProviders(HashSet<Type> subscriberTypes, List<IFunctionalityProvider> newProviders = null)
        {
            if (subscriberTypes.Count == 0)
                return;

            Profiler.BeginSample(SetupDefaultProvidersProfilerLabel);

            CheckSetup();
            var moduleLoaderDebugSettings = ModuleLoaderDebugSettings.instance;
            if (moduleLoaderDebugSettings.functionalityInjectionModuleLogging)
                Debug.LogFormat("Requiring default providers on: {0}", string.Join(", ",
                    (from type in subscriberTypes select type.Name).ToArray()));

            // Determine which provider interfaces are needed for the given subscribers
            var requiredProviders = new HashSet<Type>();
            foreach (var subscriberType in subscriberTypes)
            {
                GetRequiredProviders(subscriberType, requiredProviders);
            }

            k_NewProviderPrefabInstances.Clear();
            var currentPlatform = ModuleLoaderCore.GetCurrentPlatform();
            while (CheckMissingProviders(requiredProviders) > 0)
            {
                var providerAdded = false;
                foreach (var row in m_EffectiveDefaultProviders)
                {
                    var providerTypeName = row.providerTypeName;
                    var providerType = row.providerType;
                    if (providerType == null)
                    {
                        Debug.LogWarningFormat("Could not find type for {0} while setting up default providers", providerTypeName);
                        continue;
                    }

                    // Silently skip provider types that have already been overridden
                    if (m_Providers.ContainsKey(providerType))
                        continue;

                    if (!requiredProviders.Contains(providerType))
                        continue;

                    ProviderSelectionOptionsAttribute selectionOptions;
                    var prefab = row.defaultProviderPrefab;
                    if (prefab != null)
                    {
                        var providersInPrefab = prefab.GetComponentsInChildren<IFunctionalityProvider>();
                        var excluded = false;
                        foreach (var provider in providersInPrefab)
                        {
                            var specificType = provider.GetType();
                            selectionOptions = GetProviderSelectionOptions(specificType);
                            if (selectionOptions != null)
                            {
                                var excludedPlatforms = selectionOptions.ExcludedPlatforms;
                                if (excludedPlatforms != null && excludedPlatforms.Contains(currentPlatform))
                                {
                                    excluded = true;
                                    break;
                                }
                            }
                        }

                        if (excluded)
                            continue;

                        GameObject instance;
                        if (!k_NewProviderPrefabInstances.TryGetValue(prefab, out instance))
                        {
                            if (moduleLoaderDebugSettings.functionalityInjectionModuleLogging)
                                Debug.LogFormat("Functionality Injection Module creating default provider: {0}", prefab);

                            instance = GameObjectUtils.Instantiate(prefab);
                            k_NewProviderPrefabInstances[prefab] = instance;
                        }

                        var hasRequiredProvider = false;
                        providersInPrefab = instance.GetComponentsInChildren<IFunctionalityProvider>();
                        foreach (var provider in providersInPrefab)
                        {
                            providerAdded = true;
                            var specificType = provider.GetType();
                            if (providerType.IsAssignableFrom(specificType))
                                hasRequiredProvider = true;

                            GetRequiredProviders(specificType, requiredProviders);
                            AddProvider(specificType, provider);
                        }

                        if (!hasRequiredProvider)
                            Debug.LogWarningFormat("Could not find a {0} on {1} while setting up default providers", providerTypeName, instance);

                        continue;
                    }

                    var defaultProviderTypeName = row.defaultProviderTypeName;
                    var defaultProviderType = row.defaultProviderType;
                    if (defaultProviderType == null)
                    {
                        Debug.LogWarningFormat("Cannot set up default provider {0}. Type cannot be found", defaultProviderTypeName);
                        continue;
                    }

                    if (!providerType.IsAssignableFrom(defaultProviderType))
                    {
                        Debug.LogWarningFormat("Cannot set up default provider. The given type {0} does not implement {1}", defaultProviderTypeName, providerType);
                        continue;
                    }

                    selectionOptions = GetProviderSelectionOptions(defaultProviderType);
                    if (selectionOptions != null)
                    {
                        if (selectionOptions.DisallowAutoCreation)
                            continue;

                        var excludedPlatforms = selectionOptions.ExcludedPlatforms;
                        if (excludedPlatforms != null && excludedPlatforms.Contains(currentPlatform))
                            continue;
                    }

                    var vanillaProvider = GetOrCreateProviderInstance(defaultProviderType, providerType);
                    if (vanillaProvider == null)
                    {
                        Debug.LogWarningFormat("Cannot instantiate {0} as an IFunctionalityProvider.", defaultProviderTypeName);
                        continue;
                    }

                    if (newProviders != null)
                        newProviders.Add(vanillaProvider);

                    providerAdded = true;
                    GetRequiredProviders(defaultProviderType, requiredProviders);
                    AddProvider(defaultProviderType, vanillaProvider);
                }

                if (!providerAdded)
                    break;
            }

            InjectFunctionalityInDefaultProviders(k_NewProviderPrefabInstances, newProviders);
            ActivateProviderGameObjects();

            Profiler.EndSample();
        }

        int CheckMissingProviders(HashSet<Type> requiredProviders)
        {
            var compareSet = new HashSet<Type>(requiredProviders);
            compareSet.ExceptWith(m_Providers.Keys);
            return compareSet.Count;
        }

        /// <summary>
        /// Activate all GameObjects backing MonoBehavior providers
        /// </summary>
        public void ActivateProviderGameObjects()
        {
            foreach (var provider in m_Providers)
            {
                var monoBehaviour = provider.Value as MonoBehaviour;
                if (monoBehaviour != null)
                    monoBehaviour.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// Inject functionality on providers that were created during the RequireDefaultProviders process
        /// </summary>
        /// <param name="newProvidersIn">New provider GameObjects which were instantiated from prefabs</param>
        /// <param name="newProvidersOut">All providers attached to objects in newProvidersIn</param>
        public void InjectFunctionalityInDefaultProviders(Dictionary<GameObject, GameObject> newProvidersIn,
            List<IFunctionalityProvider> newProvidersOut)
        {
            foreach (var provider in m_UniqueProviders)
            {
                InjectFunctionalitySingle(provider);
            }

            foreach (var kvp in newProvidersIn)
            {
                var provider = kvp.Value;
                foreach (var subscriber in provider.GetComponentsInChildren<IFunctionalitySubscriber>())
                {
                    InjectFunctionalitySingle(subscriber);
                }
            }

            if (newProvidersOut != null)
            {
                foreach (var kvp in newProvidersIn)
                {
                    newProvidersOut.AddRange(kvp.Value.GetComponentsInChildren<IFunctionalityProvider>());
                }
            }
        }

        /// <summary>
        /// Set up providers for a given set of subscriber types
        /// </summary>
        /// <param name="subscriberTypes">The set of subscriber types that need providers</param>
        /// <param name="newProviders">Providers that were created</param>
        public void PrepareFunctionalityForSubscriberTypes(HashSet<Type> subscriberTypes, List<IFunctionalityProvider> newProviders = null)
        {
            if (subscriberTypes.Count == 0)
                return;

            Profiler.BeginSample(SetupDefaultProvidersProfilerLabel);

            CheckSetup();
            var moduleLoaderDebugSettings = ModuleLoaderDebugSettings.instance;
            if (moduleLoaderDebugSettings.functionalityInjectionModuleLogging)
                Debug.LogFormat("Requiring default providers on: {0}", string.Join(", ",
                    (from type in subscriberTypes select type.Name).ToArray()));

            // Determine which provider interfaces are needed for the given subscribers
            var requiredProviders = new HashSet<Type>();
            foreach (var subscriberType in subscriberTypes)
            {
                GetRequiredProviders(subscriberType, requiredProviders);
            }

            PrepareProviders(requiredProviders, newProviders, true);
        }

        /// <summary>
        /// Inject functionality on a list of objects
        /// </summary>
        /// <param name="objects">The list of objects on which to inject functionality</param>
        /// <param name="newProviders">Functionality providers which were created to fulfill required functionality</param>
        public void InjectFunctionality(List<object> objects, List<IFunctionalityProvider> newProviders = null)
        {
            if (objects.Count == 0)
                return;

            Profiler.BeginSample(InjectFunctionalityProfilerLabel);

            CheckSetup();

            k_UniqueTypes.Clear();
            foreach (var obj in objects)
            {
                if (obj == null)
                    continue;

                k_UniqueTypes.Add(obj.GetType());
            }

            var requiredProviders = CollectionPool<HashSet<Type>, Type>.GetCollection();
            foreach (var type in k_UniqueTypes)
            {
                k_SubscriberInterfaces.Clear();
                type.GetGenericInterfaces(typeof(IFunctionalitySubscriber<>), k_SubscriberInterfaces);
                foreach (var @interface in k_SubscriberInterfaces)
                {
                    requiredProviders.Add(@interface.GetGenericArguments()[0]);
                }
            }

            PrepareProviders(requiredProviders, newProviders);
            CollectionPool<HashSet<Type>, Type>.RecycleCollection(requiredProviders);

            foreach (var obj in objects)
            {
                InjectFunctionalitySingle(obj);
            }

            Profiler.EndSample();
        }

        /// <summary>
        /// Inject functionality on a list of subscribers
        /// </summary>
        /// <param name="objects">The list of IFunctionalitySubscriber objects on which to inject functionality</param>
        /// <param name="newProviders">Functionality providers which were created to fulfill required functionality</param>
        public void InjectFunctionality(List<IFunctionalitySubscriber> objects, List<IFunctionalityProvider> newProviders = null)
        {
            if (objects.Count == 0)
                return;

            Profiler.BeginSample(InjectFunctionalityProfilerLabel);

            CheckSetup();

            k_UniqueTypes.Clear();
            foreach (var obj in objects)
            {
                if (obj == null)
                    continue;

                k_UniqueTypes.Add(obj.GetType());
            }

            var requiredProviders = CollectionPool<HashSet<Type>, Type>.GetCollection();
            foreach (var type in k_UniqueTypes)
            {
                k_SubscriberInterfaces.Clear();
                type.GetGenericInterfaces(typeof(IFunctionalitySubscriber<>), k_SubscriberInterfaces);
                foreach (var @interface in k_SubscriberInterfaces)
                {
                    requiredProviders.Add(@interface.GetGenericArguments()[0]);
                }
            }

            PrepareProviders(requiredProviders, newProviders);
            CollectionPool<HashSet<Type>, Type>.RecycleCollection(requiredProviders);

            InjectFunctionalityGroup(objects);

            Profiler.EndSample();
        }

        /// <summary>
        /// Inject functionality on a set of objects, assuming that all required providers have been setup.
        /// </summary>
        /// <param name="objects">List of subscriber objects on which to inject functionality</param>
        public void InjectPreparedFunctionality(List<IFunctionalitySubscriber> objects)
        {
            if (objects.Count == 0)
                return;

            CheckSetup();
            InjectFunctionalityGroup(objects);
        }

        /// <summary>
        /// Inject functionality on a set of objects, assuming that all required providers have been set up.
        /// </summary>
        /// <param name="objects"></param>
        public void InjectPreparedFunctionality(List<object> objects)
        {
            if (objects.Count == 0)
                return;

            CheckSetup();
            InjectFunctionalityGroup(objects);
        }

        void InjectFunctionalityGroup(List<IFunctionalitySubscriber> objects)
        {
            foreach (var obj in objects)
            {
                foreach (var provider in m_UniqueProviders)
                {
                    try
                    {
                        provider.ConnectSubscriber(obj);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                }
            }
        }

        void InjectFunctionalityGroup(List<object> objects)
        {
            foreach (var obj in objects)
            {
                foreach (var provider in m_UniqueProviders)
                {
                    try
                    {
                        provider.ConnectSubscriber(obj);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                }
            }
        }

        /// <summary>
        /// Inject functionality on a single object, assuming all providers have been set up.
        /// </summary>
        /// <param name="obj">The object on which to inject functionality</param>
        public void InjectFunctionalitySingle(object obj)
        {
            if (obj == null)
                return;

            CheckSetup();

            foreach (var provider in m_UniqueProviders)
            {
                try
                {
                    provider.ConnectSubscriber(obj);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }

        /// <summary>
        /// Inject functionality on an entire scene, assuming that
        /// </summary>
        /// <param name="scene"></param>
        public void InjectFunctionality(Scene scene)
        {
            CheckSetup();
            foreach (var go in scene.GetRootGameObjects())
            {
                InjectFunctionality(go);
            }
        }

        /// <summary>
        /// Inject functionality on all components of a GameObject which implement IFunctionalitySubscriber
        /// </summary>
        /// <param name="go">The GameObject from which to collect components</param>
        public void InjectFunctionality(GameObject go)
        {
            k_Subscribers.Clear();
            go.GetComponentsInChildren(k_Subscribers);
            InjectFunctionality(k_Subscribers);
        }

        /// <summary>
        /// Add a list of functionality providers to this island
        /// </summary>
        /// <param name="newProviders">The list of providers to be added</param>
        public void AddProviders(List<IFunctionalityProvider> newProviders)
        {
            if (newProviders.Count == 0)
                return;

            CheckSetup();

            foreach (var provider in newProviders)
            {
                var type = provider.GetType();
                if (m_Providers.ContainsKey(type))
                {
                    Debug.LogWarning(string.Format("A provider for {0} already exists.", type));
                    continue;
                }

                AddProvider(type, provider);
            }

            foreach (var provider in m_UniqueProviders)
            {
                InjectFunctionalitySingle(provider);
            }
        }

        /// <summary>
        /// Remove a list of providers from this functionality island
        /// </summary>
        /// <param name="providersToRemove">The list of providers to be removed</param>
        public void RemoveProviders(List<IFunctionalityProvider> providersToRemove)
        {
            CheckSetup();

            foreach (var provider in providersToRemove)
            {
                provider.UnloadProvider();
                m_UniqueProviders.Remove(provider);

                foreach (var providerInterface in provider.GetType().GetInterfaces())
                {
                    var baseProviderType = typeof(IFunctionalityProvider);
                    if (providerInterface == baseProviderType || !baseProviderType.IsAssignableFrom(providerInterface))
                        continue;

                    IFunctionalityProvider existingProvider;
                    if (m_Providers.TryGetValue(providerInterface, out existingProvider) && provider == existingProvider)
                        m_Providers.Remove(providerInterface);
                }
            }
        }

        void PrepareProviders(HashSet<Type> providerTypes, List<IFunctionalityProvider> newProviders, bool optional = false)
        {
            Profiler.BeginSample(RequireProvidersProfilerLabel);

            var newProvidersInternal = newProviders ?? CollectionPool<List<IFunctionalityProvider>, IFunctionalityProvider>.GetCollection();
            var providerCount = newProvidersInternal.Count;

            var currentPlatform = ModuleLoaderCore.GetCurrentPlatform();
            foreach (var providerType in providerTypes)
            {
                if (!providerType.IsInterface)
                {
                    Debug.LogWarning(string.Format("Type {0} is not an interface. Please provide the provider interface type, not the type which implements it.", providerType));
                    continue;
                }

                if (!typeof(IFunctionalityProvider).IsAssignableFrom(providerType))
                {
                    Debug.LogWarning(string.Format("Type {0} is not a functionality provider interface.", providerType));
                    continue;
                }

                if (m_Providers.ContainsKey(providerType))
                    continue;

                k_AllImplementors.Clear();
                k_Implementors.Clear();
                providerType.GetImplementationsOfInterface(k_AllImplementors);
                foreach (var type in k_AllImplementors)
                {
                    var selectionOptions = GetProviderSelectionOptions(type);
                    if (selectionOptions != null)
                    {
                        if (selectionOptions.DisallowAutoCreation)
                            continue;

                        var excludedPlatforms = selectionOptions.ExcludedPlatforms;
                        if (excludedPlatforms != null)
                        {
                            if (excludedPlatforms.Contains(currentPlatform))
                                continue;
                        }
                    }

                    k_Implementors.Add(type);
                }
                var count = k_Implementors.Count;
                if (count == 0)
                {
                    if (!optional)
                        Debug.LogWarning(string.Format("No providers found for {0}", providerType));

                    continue;
                }

                k_Implementors.Sort((a, b) =>
                    GetProviderSelectionOptions(b).Priority.CompareTo(GetProviderSelectionOptions(a).Priority));

                var firstProvider = k_Implementors[0];
                if (k_Implementors.Count > 1)
                {
                    var secondProvider = k_Implementors[1];
                    if (GetProviderSelectionOptions(firstProvider) == GetProviderSelectionOptions(secondProvider))
                        Debug.LogWarning(string.Format(k_EqualPriorityMessage, providerType, firstProvider, secondProvider, name), this);
                }

                // Spawn or gain access to the class needed to support the functionality
                var provider = GetOrCreateProviderInstance(firstProvider, providerType);

                newProvidersInternal.Add(provider);

                AddProvider(firstProvider, provider);
            }

            foreach (var provider in m_UniqueProviders)
            {
                InjectFunctionalitySingle(provider);
            }

            var newProviderTypes = CollectionPool<HashSet<Type>, Type>.GetCollection();
            foreach (var provider in newProvidersInternal)
            {
                newProviderTypes.Add(provider.GetType());
            }

            if (newProvidersInternal.Count > providerCount)
                SetupDefaultProviders(newProviderTypes, newProvidersInternal);

            CollectionPool<HashSet<Type>, Type>.RecycleCollection(newProviderTypes);
            if (newProviders == null)
                CollectionPool<List<IFunctionalityProvider>, IFunctionalityProvider>.RecycleCollection(newProvidersInternal);

            ActivateProviderGameObjects();
            Profiler.EndSample();
        }

        /// <summary>
        /// Get or create an instance of the given provider type
        /// </summary>
        /// <param name="implementorType">The specific provider implementation type</param>
        /// <param name="providerType">The provider interface type</param>
        /// <returns>The new or existing functionality provider</returns>
        public static IFunctionalityProvider GetOrCreateProviderInstance(Type implementorType, Type providerType)
        {
            IFunctionalityProvider provider;
            if (typeof(MonoBehaviour).IsAssignableFrom(implementorType))
            {
                var go = GameObjectUtils.Create(providerType.Name);
                go.SetActive(false);
                provider = (IFunctionalityProvider)go.AddComponent(implementorType);
            }
            else if (typeof(ScriptableSettingsBase).IsAssignableFrom(implementorType))
            {
                provider = (IFunctionalityProvider)ScriptableSettingsBase.GetInstanceByType(implementorType);
            }
            else if (typeof(ScriptableObject).IsAssignableFrom(implementorType))
            {
                Debug.LogError(string.Format("Trying to create {0}: Provider type {1} is a Scriptable Object. Functionality providers with " +
                    "serialized data must derive from ScriptableSettings for their data to survive reload.", providerType, implementorType));
                return null;
            }
            else
            {
                provider = (IFunctionalityProvider)Activator.CreateInstance(implementorType);
            }

            if (ModuleLoaderDebugSettings.instance.functionalityInjectionModuleLogging)
                Debug.LogFormat("Functionality Injection Module creating provider: {0}", provider);

            return provider;
        }

        /// <summary>
        /// Return true if the given type of provider can be added to this functionality island
        /// If the given type does not implement any provider interfaces which haven't already been added, it cannot be added
        /// </summary>
        /// <param name="providerType">The specific type of provider to check</param>
        /// <returns></returns>
        public bool CanAddProviderType(Type providerType)
        {
            List<Type> interfaces;
            if (!k_ProviderToProviderInterfaces.TryGetValue(providerType, out interfaces))
            {
                Debug.LogWarning(string.Format("Could not find provider interfaces for type {0}", providerType));
                return false;
            }

            foreach (var providerInterface in interfaces)
            {
                if (!m_Providers.ContainsKey(providerInterface))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Add a provider to a specific slot in the providers list
        /// </summary>
        /// <param name="providerType">The provider interface type, which serves as a key in the providers dictionary</param>
        /// <param name="provider">The provider object to be added</param>
        public void AddProvider(Type providerType, IFunctionalityProvider provider)
        {
            if (!m_UniqueProviders.Add(provider))
                Debug.LogWarning(string.Format("Provider {0} of type {1} was added twice", provider, providerType));

            try
            {
                provider.LoadProvider();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            List<Type> interfaces;
            if (!k_ProviderToProviderInterfaces.TryGetValue(providerType, out interfaces))
            {
                Debug.LogWarning(string.Format("Could not find provider interfaces for type {0}", providerType));
                return;
            }

            //One object may provide multiple functionalities
            foreach (var providerInterface in interfaces)
            {
                if (!m_Providers.ContainsKey(providerInterface))
                    m_Providers.Add(providerInterface, provider);
            }
        }

        static void GetRequiredProviders(Type subscriberType, HashSet<Type> providerTypes)
        {
            foreach (var subscriberInterface in subscriberType.GetInterfaces())
            {
                // In case of derived subscriber types
                GetRequiredProviders(subscriberInterface, providerTypes);

                if (!typeof(IFunctionalitySubscriber).IsAssignableFrom(subscriberInterface))
                    continue;

                var genericArguments = subscriberInterface.GetGenericArguments();
                if (genericArguments.Length == 0)
                    continue;

                var firstArgument = genericArguments[0];
                if (!typeof(IFunctionalityProvider).IsAssignableFrom(firstArgument))
                    continue;

                providerTypes.Add(firstArgument);
            }
        }

        /// <summary>
        /// Unload this island and all of its providers
        /// </summary>
        public void Unload()
        {
            CheckSetup();
            foreach (var provider in m_UniqueProviders)
            {
                if (provider != null)
                {
                    try
                    {
                        provider.UnloadProvider();
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                }
                else
                {
                    Debug.LogError("Encountered a null provider during Unload--this should never happen");
                }
            }

            m_Providers.Clear();
            m_UniqueProviders.Clear();
        }

        /// <summary>
        /// Log a warning if this Functionality Island has not been set up
        /// </summary>
        public void CheckSetup()
        {
            if (!m_Setup)
                Debug.LogWarningFormat("You are trying to use {0} but it is not set up. Do you need to add it to the " +
                    "Functionality Injection Module?", this);
        }

        /// <summary>
        /// Return a string describing what providers have been added to each island. This is useful to debug issues
        /// related to functionality injection when the issue occurs during load or when the asset's inspector does not
        /// provide helpful information.
        /// </summary>
        /// <returns>A string describing the current state of this Functionality Island</returns>
        public string PrintStatus()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("{0}:\n", name));
            foreach (var kvp in m_Providers)
            {
                var providerInterface = kvp.Key.GetNameWithGenericArguments();
                var providerType = kvp.Value.GetType().GetNameWithGenericArguments();
                sb.Append(string.Format("\t{0}: {1}\n", providerInterface, providerType));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Called when the provider is loaded into a <c>FunctionalityIsland</c>
        /// </summary>
        public void LoadProvider() {}

        /// <summary>
        /// Called by the <c>FunctionalityIsland</c> containing this provider when injecting functionality on an object
        /// </summary>
        /// <param name="obj">The object onto which functionality is being injected. If this implements a subscriber
        /// interface that subscribes to functionality provided by this object, it will set itself as the provider</param>
        public void ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesFunctionalityInjection>(obj);
        }

        /// <summary>
        /// Called when the provider is unloaded by the containing <c>FunctionalityIsland</c>
        /// </summary>
        public void UnloadProvider() {}


        /// <summary>
        /// Called by ModuleCallbacksBehaviour OnDestroy as early as possible (using a very low Script Execution Order)
        /// </summary>
        public void OnBehaviorDestroy()
        {
            // Disable all MonoBehavior providers so they send OnLoss events before objects are destroyed
            foreach (var provider in m_UniqueProviders)
            {
                var behavior = provider as MonoBehaviour;
                if (behavior)
                    behavior.enabled = false;
            }
        }
    }
}
