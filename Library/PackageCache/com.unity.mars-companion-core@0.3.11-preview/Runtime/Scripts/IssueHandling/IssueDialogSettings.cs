using System;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    /// <summary>
    /// The settings to configure an issue handling dialog box.
    /// </summary>
    [Serializable]
    public struct IssueDialogSettings
    {
        /// <summary>
        /// Text that will be displayed in the title label
        /// </summary>
        public string Title;

        /// <summary>
        /// Text that will be displayed in the main body/description label
        /// </summary>
        public string Description;

        /// <summary>
        /// Text that will be displayed on the cancel button
        /// </summary>
        public string CancelText;

        /// <summary>
        /// Text that will be displayed on the accept/"OK" button
        /// </summary>
        public string AcceptText;

        /// <summary>
        /// How will the text be logged to the console for diagnostics.
        /// Defaults to "Error" level logging.
        /// </summary>
        public LogType LogType;

        /// <summary>
        /// Should the dialog display a boolean state toggle,
        /// primarily for "ignore this message" settings.
        /// Can also be used for an important user preference toggle.
        /// </summary>
        public bool HasToggle;

        /// <summary>
        /// Text that will be displayed in the toggle field label.
        /// </summary>
        public string ToggleText;

        /// <summary>
        /// Forces the toggle to be used for the ignore feature.
        /// </summary>
        public bool ForceIgnoreToggle;

        /// <summary>
        /// Do these settings have the minimum information
        /// needed to display a proper dialog box?
        /// </summary>
        public bool IsValid => !string.IsNullOrEmpty(Title) &&
                               !string.IsNullOrEmpty(AcceptText);
    }
}
