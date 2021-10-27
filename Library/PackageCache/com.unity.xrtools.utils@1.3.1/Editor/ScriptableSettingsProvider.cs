using Unity.XRTools.Utils;
using Unity.XRTools.Utils.Internal;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
#else
using UnityEngine.Experimental.UIElements;
#endif

namespace UnityEditor.XRTools.Utils
{
    /// <summary>
    /// Expose a ScriptableSettings of type T as a settings provider
    /// </summary>
    /// <typeparam name="T">The ScriptableSettings type which will be exposed</typeparam>
    public abstract class ScriptableSettingsProvider<T> : Internal.ScriptableSettingsProviderBase<T> where T : ScriptableSettingsBase<T>
    {
        /// <summary>
        /// The ScriptableSettings being provided
        /// </summary>
        protected static T target
        {
            get
            {
                if (s_Target == null || s_SerializedObject == null)
                    GetSerializedSettings();

                return s_Target;
            }
        }

        /// <summary>
        /// A SerializedObject representing the ScriptableSettings being provided
        /// </summary>
        protected static SerializedObject serializedObject
        {
            get
            {
                if (s_SerializedObject == null)
                    s_SerializedObject = GetSerializedSettings();

                return s_SerializedObject;
            }
        }

        /// <summary>
        /// Initialize a new ScriptableSettingsProvider
        /// </summary>
        /// <param name="path">The path to this settings view within the Preferences or Project Settings window</param>
        /// <param name="scope">The scope of these settings</param>
        protected ScriptableSettingsProvider(string path, SettingsScope scope = SettingsScope.User)
            : base(path, scope) {}

        /// <summary>
        /// Use this function to implement a handler for when the user clicks on the Settings in the Settings window. You can fetch a settings Asset or set up UIElements UI from this function.
        /// </summary>
        /// <param name="searchContext">Search context in the search box on the Settings window.</param>
        /// <param name="rootElement">Root of the UIElements tree. If you add to this root, the SettingsProvider uses UIElements instead of calling SettingsProvider.OnGUI to build the UI. If you do not add to this VisualElement, then you must use the IMGUI to build the UI.</param>
        public abstract override void OnActivate(string searchContext, VisualElement rootElement);

        /// <summary>
        /// Use this function to draw the UI based on IMGUI. This assumes you haven't added any children to the rootElement passed to the OnActivate function.
        /// </summary>
        /// <param name="searchContext">Search context for the Settings window. Used to show or hide relevant properties.</param>
        public abstract override void OnGUI(string searchContext);
    }
}

namespace UnityEditor.XRTools.Utils.Internal
{
    /// <summary>
    /// Base class for ScriptableSettingsProvider, which exposes a ScriptableSettings type as a settings provider
    /// </summary>
    /// <typeparam name="T">The ScriptableSettings type which will be exposed</typeparam>
    public abstract class ScriptableSettingsProviderBase<T> : SettingsProvider where T : ScriptableSettingsBase<T>
    {
        /// <summary>
        /// Cache field for target property
        /// </summary>
        protected static T s_Target;

        /// <summary>
        /// Cache field for serializedObject property
        /// </summary>
        protected static SerializedObject s_SerializedObject;

        /// <summary>
        /// Initialize a new ScriptableSettingsProviderBase
        /// </summary>
        /// <param name="path">The path to this settings view within the Preferences or Project Settings window</param>
        /// <param name="scope">The scope of these settings</param>
        protected ScriptableSettingsProviderBase(string path, SettingsScope scope)
            : base(path, scope) { }

        /// <summary>
        /// Initialize this settings object and return a SerializedObject wrapping it
        /// </summary>
        /// <returns>The SerializedObject wrapper</returns>
        protected static SerializedObject GetSerializedSettings()
        {
            if (typeof(EditorScriptableSettings<T>).IsAssignableFrom(typeof(T)))
            {
                s_Target = EditorScriptableSettings<T>.instance;
                return new SerializedObject(s_Target);
            }

            s_Target = ScriptableSettings<T>.instance;
            return new SerializedObject(s_Target);
        }
    }
}
