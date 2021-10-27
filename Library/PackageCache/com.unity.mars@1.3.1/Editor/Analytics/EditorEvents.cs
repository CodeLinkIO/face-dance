using System;

namespace Unity.MARS
{
    abstract class EditorEventArgs
    {
        public string name;
        public override string ToString() { return name; }
    }

    // Common Data Pipeline can only deal with snake_case field names, so all fields in event args are named like that.
    class MarsMenuEventArgs : EditorEventArgs
    {
        public string label;
        public override string ToString() { return $"{name}, {label}"; }
    }

    class UiComponentArgs : EditorEventArgs
    {
        public string label;
        public bool active;
        public override string ToString() { return $"{name}, {label}, {active}"; }
    }

    class ComponentChangeArgs : EditorEventArgs
    {
        public bool added;
        public string type;

        internal ComponentChangeArgs(Type type, bool added)
        {
            this.type = type.Name;
            this.added = added;
        }

        public override string ToString() { return $"{name}, {added}, {type}"; }
    }

    class MultiSimulationStartedArgs : EditorEventArgs {}

    class DropTargetUsedArgs : EditorEventArgs
    {
        public string type;
        public string label;

        public override string ToString() { return $"{name}, {type}, {label}"; }
    }

    class EnvironmentCycleArgs : EditorEventArgs
    {
        public string label;
        public int mode;                // store EnvironmentMode enum values as ints

        public override string ToString() { return $"{name}, {label}, {mode}"; }
    }

    class SyntheticRecordingCycleArgs : EditorEventArgs
    {
        public string label;
    }

    class RecordingTimelineOpenedArgs : EditorEventArgs { }

    class AutoSyncToggledArgs : EditorEventArgs
    {
        public bool enabled;
    }

    class SceneAnalysisArgs : EditorEventArgs
    {
        public string scene_guid;
        public string[] required_traits;
        public float world_scale;
        public int non_mars_object_count;
        public int mars_object_count;
        public int conditions_count;

        public override string ToString() { return $"{name}, {scene_guid}, {world_scale}, {non_mars_object_count}, {mars_object_count}, {conditions_count}"; }
    }

    class HintDismissedArgs : EditorEventArgs
    {
        public string label;
        public override string ToString() { return $"{name}, {label}"; }
    }

    class HintHelpButtonUsedArgs : EditorEventArgs
    {
        public string label;
        public string url;
        public override string ToString() { return $"{name}, {label}, {url}"; }
    }

    class RuleUiArgs : EditorEventArgs
    {
        public string label;
    }

    /*
     * Every new top-level event type results in a new database table in the CDP backend.
     * Therefore, on advice from Analytics, all of our events are grouped under two top-level tables,
     * and instead, we have a 'name' field for each event to allow us to look at specific events.
     * The two event top levels are "marsAlphaUi", for UI usage, and "marsAlphaScenes", for scene analyses
     */
    static class EditorEvents
    {
        const string k_UiPrefix = "marsAlphaUi";
        const string k_ScenesPrefix = "marsAlphaScenes";

        /// <summary>
        /// This event occurs when a MARS context menu item is used to create a new gameobject
        /// </summary>
        public static MarsEditorEvent<MarsMenuEventArgs> CreationMenuItemUsed = new MarsEditorEvent<MarsMenuEventArgs>(k_UiPrefix, "creationMenuItemUsed");

        /// <summary>
        /// This event occurs when a MARS component (client / condition / action) is added or removed to an object.
        /// </summary>
        public static MarsEditorEvent<ComponentChangeArgs> MarsComponentChange = new MarsEditorEvent<ComponentChangeArgs>(k_UiPrefix, "marsComponentChange");

        /// <summary>
        /// This event occurs when some UI component are enabled or disabled, and records the name and state.
        /// </summary>
        public static MarsEditorEvent<UiComponentArgs> UiComponentUsed = new MarsEditorEvent<UiComponentArgs>(k_UiPrefix, "uiComponentUsed");

        /// <summary>
        /// This event occurs when a MARS-specific window is opened or closed
        /// </summary>
        public static MarsEditorEvent<UiComponentArgs> WindowUsed = new MarsEditorEvent<UiComponentArgs>(k_UiPrefix, "windowUsed");

        /// <summary>
        /// This event occurs when an object is drag and dropped onto an interaction target
        /// </summary>
        public static MarsEditorEvent<DropTargetUsedArgs> DropTargetUsed = new MarsEditorEvent<DropTargetUsedArgs>(k_UiPrefix, "dropTargetUsed");

        /// <summary>
        /// This event occurs when a user presses "next / previous environment" in the UI
        /// </summary>
        public static MarsEditorEvent<EnvironmentCycleArgs> EnvironmentCycle = new MarsEditorEvent<EnvironmentCycleArgs>(k_UiPrefix, "environmentCycle");

        /// <summary>
        /// This event occurs when a user presses "next / previous recording" in synthetic mode in the simulation controls panel
        /// </summary>
        public static MarsEditorEvent<SyntheticRecordingCycleArgs> SyntheticRecordingCycle = new MarsEditorEvent<SyntheticRecordingCycleArgs>(k_UiPrefix, "syntheticRecordingCycle");

        /// <summary>
        /// This event occurs when a user presses the "Open Timeline" button in Simulation Controls
        /// </summary>
        public static MarsEditorEvent<RecordingTimelineOpenedArgs> RecordingTimelineOpened = new MarsEditorEvent<RecordingTimelineOpenedArgs>(k_UiPrefix, "recordingTimelineOpened");

        /// <summary>
        /// This event occurs when a user toggles the "With Scene" Auto Sync option in Simulation Controls
        /// </summary>
        public static MarsEditorEvent<AutoSyncToggledArgs> AutoSyncWithSceneToggled = new MarsEditorEvent<AutoSyncToggledArgs>(k_UiPrefix, "autoSyncWithSceneToggled");

        /// <summary>
        /// This event occurs when a user toggles the "With Time" Auto Sync option in Simulation Controls
        /// </summary>
        public static MarsEditorEvent<AutoSyncToggledArgs> AutoSyncWithTimeToggled = new MarsEditorEvent<AutoSyncToggledArgs>(k_UiPrefix, "autoSyncWithTimeToggled");

        /// <summary>
        /// This event occurs when a multi-environment simulation is triggered in the sim test runner
        /// </summary>
        public static MarsEditorEvent<MultiSimulationStartedArgs> MultiSimulationStarted = new MarsEditorEvent<MultiSimulationStartedArgs>(k_UiPrefix, "multiSimulationStarted");

        /// <summary>
        /// This event occurs when a scene is saved, and records a summary of the MARS scene
        /// </summary>
        public static MarsEditorEvent<SceneAnalysisArgs> SceneAnalysis = new MarsEditorEvent<SceneAnalysisArgs>(k_ScenesPrefix, "sceneAnalysis", 100);

        /// <summary>
        /// This event occurs when a user dismisses a hint in the UI
        /// </summary>
        public static MarsEditorEvent<HintDismissedArgs> HintDismissed = new MarsEditorEvent<HintDismissedArgs>(k_UiPrefix, "hintDismissed");

        /// <summary>
        /// This event occurs when a user follows a HintBox "Learn More" button
        /// </summary>
        public static MarsEditorEvent<HintHelpButtonUsedArgs> HintButtonUsed = new MarsEditorEvent<HintHelpButtonUsedArgs>(k_UiPrefix, "hintButtonUsed");

        /// <summary>
        /// This event occurs when a user uses with an element in the Rules workflow.
        /// </summary>
        public static MarsEditorEvent<RuleUiArgs> RulesUiUsed = new MarsEditorEvent<RuleUiArgs>(k_UiPrefix, "rules");
    }
}
