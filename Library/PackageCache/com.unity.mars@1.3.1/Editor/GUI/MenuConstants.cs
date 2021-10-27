using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Constant values for MARS menu items
    /// </summary>
    [MovedFrom(true, "Unity.MARS", "Unity.MARS")]
    public class MenuConstants
    {
        /// <summary>
        /// Menu prefix for MARS menu items
        /// </summary>
        public const string MenuPrefix =
#if MARS_MENU
            "MARS/";
#else
            "Window/MARS/";
#endif

        /// <summary>
        /// Developer menu string path
        /// </summary>
        public const string DevMenuPrefix = MenuPrefix + "Developer/";
        /// <summary>
        /// Experimental menu string path
        /// </summary>
        public const string ExperimentalMenuPrefix = MenuPrefix + "Experimental/";

        // 0 = beginning of Window menu, after 'Previous Window'
        // 1000 = before 'Asset Store'
        // 3000 = after XR/, before Experimental/
        // 3020 = end of Window menu, after Experimental/
        // Note: may need to reboot the editor for change to take effect.
        const int k_BasePriority = 1000;

        // Priorities with a difference over 10 get a divider between them.
        const int k_Divider = 11;

        /// <summary>
        /// Base MARS menu item sort priority
        /// </summary>
        public const int PanelPriority = k_BasePriority + k_Divider;
        /// <summary>
        /// Panel menu item sort priority
        /// </summary>
        public const int SimulationViewPriority = PanelPriority + k_Divider;
        /// <summary>
        /// Device View menu item sort priority
        /// </summary>
        public const int DeviceViewPriority = SimulationViewPriority + 1;
        /// <summary>
        /// Simulation Test Runner menu item sort priority
        /// </summary>
        public const int SimTestRunnerPriority = DeviceViewPriority + 1;
        /// <summary>
        /// Simulation Settings menu item sort priority
        /// </summary>
        public const int SimSettingsPriority = SimTestRunnerPriority + 1;
        /// <summary>
        /// Rules Window menu item sort priority
        /// </summary>
        public const int RulesWindowPriority = SimSettingsPriority + k_Divider;
        /// <summary>
        /// Template menu item sort priority
        /// </summary>
        public const int TemplatePriority = RulesWindowPriority + k_Divider;
        /// <summary>
        /// Import Content menu item sort priority
        /// </summary>
        public const int ImportContentPriority = TemplatePriority + 1;
        /// <summary>
        /// Elective Extensions menu item sort priority
        /// </summary>
        public const int ElectiveExtensionsRunBuildCheckPriority = ImportContentPriority + k_Divider;

        /// <summary>
        /// Developer menu item sort priority
        /// </summary>
        public const int DeveloperPriority =
#if MARS_MENU
            k_BasePriority + 0;
#else
            k_BasePriority + ElectiveExtensionsRunBuildCheckPriority + k_Divider;
#endif
        /// <summary>
        /// Database Viewer menu item sort priority
        /// </summary>
        public const int DatabaseViewerPriority = DeveloperPriority + 2;
        /// <summary>
        /// Simulation Test Window menu item sort priority
        /// </summary>
        public const int SimTestWindowPriority = DatabaseViewerPriority + 1;
        /// <summary>
        /// Module Loader menu item sort priority
        /// </summary>
        public const int ModuleLoaderPriority = SimTestWindowPriority + k_Divider;
        /// <summary>
        /// Update Simulation Environments menu item sort priority
        /// </summary>
        public const int UpdateSimEnvironmentsPriority = ModuleLoaderPriority + k_Divider;
        /// <summary>
        /// Refresh Session Recordings menu item sort priority
        /// </summary>
        public const int RefreshSessionRecordingsPriority = UpdateSimEnvironmentsPriority + 1;

        /// <summary>
        /// Experimental menu item sort priority
        /// </summary>
        public const int ExperimentalPriority = DeveloperPriority + k_Divider;
        /// <summary>
        /// Rules Window menu item sort priority
        /// </summary>
        public const int RulesWindowImguiPriority = ExperimentalPriority + 1;
    }
}
