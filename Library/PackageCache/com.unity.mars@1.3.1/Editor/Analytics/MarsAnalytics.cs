using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS.MARSUtils;
using Unity.MARS.Query;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

namespace Unity.MARS
{
    abstract class MarsEditorEvent
    {
        protected const int k_DefaultMaxEventsPerHour = 1000;
        protected const int k_DefaultMaxElementCount = 1000;

        /// <summary>
        /// The top-level name for an event determines which database table it goes into in the CDP backend.
        /// All events which we want grouped into a table must share the same top-level name.
        /// </summary>
        public readonly string TopLevelName;

        /// <summary>
        /// The actual event name - marsComponentAdded, dropTargetUsed, etc.
        /// </summary>
        public string Name;

        public int MaxEventsPerHour { get; private set; }
        public int MaxElementCount { get; private set; }

        internal MarsEditorEvent(string topLevelName, string name, int maxPerHour = k_DefaultMaxEventsPerHour, int maxElementCount = k_DefaultMaxElementCount)
        {
            TopLevelName = topLevelName;
            Name = name;
            MaxEventsPerHour = maxPerHour;
            MaxElementCount = maxElementCount;
        }
    }

    class MarsEditorEvent<T> : MarsEditorEvent where T: EditorEventArgs
    {
        const string k_AnalyticsDebugFilter = "[MARS Analytic event]";

        internal bool Send(T value)
        {
            // Analytics events will always refuse to send if analytics are disabled or the editor is for sure quitting
            if (MarsAnalytics.Disabled || MarsAnalytics.Quitting)
                return false;

            value.name = Name;
            var result = EditorAnalytics.SendEventWithLimit(TopLevelName, value);
            if (result != AnalyticsResult.Ok)
            {
#if DEBUG_MARS_EDITOR_ANALYTICS
                Debug.LogWarning($"{k_AnalyticsDebugFilter} Sending event {TopLevelName} : {value} Failed with status {result}");
#endif
                return false;
            }

#if DEBUG_MARS_EDITOR_ANALYTICS
            Debug.Log($"{k_AnalyticsDebugFilter} Sending event {TopLevelName} : {value} Success with status {result}");
#endif
            return true;
        }

        internal MarsEditorEvent(string topLevelName, string name, int maxPerHour = k_DefaultMaxEventsPerHour, int maxElementCount = k_DefaultMaxElementCount)
            : base(topLevelName, name, maxPerHour, maxElementCount) { }
    }

    [InitializeOnLoad]
    static class MarsAnalytics
    {
        const string k_MarsVendorKey = "unity.labs.mars-dev";

        internal static bool Quitting { get; private set; }
        internal static bool Disabled { get; private set; }

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<GameObject> k_RootObjects = new List<GameObject>();
        static readonly List<ICondition> k_Conditions = new List<ICondition>();
        static readonly List<Proxy> k_RealWorldObjects = new List<Proxy>();

        static MarsAnalytics ()
        {
            var result = RegisterMarsEvent(EditorEvents.CreationMenuItemUsed);
            // if the user has analytics disabled, respect that and make sure that no code actually tries to send events
            if (result == AnalyticsResult.AnalyticsDisabled)
            {
                Disabled = true;
                return;
            }

            EditorSceneManager.sceneSaved += DoSceneAnalysis;
            EditorApplication.quitting += SetQuitting;

            // this just means we've already previously registered this event for this client, and can stop.
            // remove this if you want to iterate on analytics without restarting the Editor.
            if (result == AnalyticsResult.TooManyRequests)
                return;

            RegisterMarsEvent(EditorEvents.UiComponentUsed);
            RegisterMarsEvent(EditorEvents.WindowUsed);
            RegisterMarsEvent(EditorEvents.MarsComponentChange);
            RegisterMarsEvent(EditorEvents.DropTargetUsed);
            RegisterMarsEvent(EditorEvents.EnvironmentCycle);
            RegisterMarsEvent(EditorEvents.SyntheticRecordingCycle);
            RegisterMarsEvent(EditorEvents.RecordingTimelineOpened);
            RegisterMarsEvent(EditorEvents.AutoSyncWithSceneToggled);
            RegisterMarsEvent(EditorEvents.AutoSyncWithTimeToggled);
            RegisterMarsEvent(EditorEvents.MultiSimulationStarted);
            RegisterMarsEvent(EditorEvents.SceneAnalysis);
            RegisterMarsEvent(EditorEvents.RulesUiUsed);
        }

        static void DoSceneAnalysis(Scene scene)
        {
            if (!scene.IsValid())
                return;

            var session = MarsRuntimeUtils.GetMarsSessionInScene(scene);
            if (!session)
                return;

            if (!scene.IsValid())
                return;

            // Static collections used below are cleared by the methods that use them
            scene.GetRootGameObjects(k_RootObjects);

            var marsObjectCount = 0;
            var conditionComponentCount = 0;
            foreach (var go in k_RootObjects)
            {
                go.GetComponentsInChildren(k_RealWorldObjects);
                var clientCount = k_RealWorldObjects.Count;
                if (clientCount == 0)
                    continue;

                marsObjectCount += clientCount;

                go.GetComponentsInChildren(k_Conditions);
                conditionComponentCount += k_Conditions.Count;
            }

            EditorEvents.SceneAnalysis.Send(new SceneAnalysisArgs
            {
                name = "Scene Analysis",
                scene_guid = AssetDatabase.AssetPathToGUID(scene.path),
                world_scale = session.transform.localScale.x,
                required_traits = session.requirements.TraitRequirements.Select(r => r.TraitName).ToArray(),
                non_mars_object_count = scene.rootCount - marsObjectCount,
                mars_object_count = marsObjectCount,
                conditions_count = conditionComponentCount
            });
        }

        // we set the Quitting variable so that we don't record window close events when the editor quits
        static void SetQuitting()
        {
            Quitting = true;
        }

        static AnalyticsResult RegisterMarsEvent(MarsEditorEvent me)
        {
            return EditorAnalytics.RegisterEventWithLimit(me.TopLevelName, me.MaxEventsPerHour, me.MaxElementCount, k_MarsVendorKey);
        }
    }
}
