using System;

namespace Unity.MARS.Companion.Core
{
    /// <summary>
    /// A data structure that contains all the information needed
    /// to display and handle an issue that the user needs to handle
    /// </summary>
    public readonly struct IssueHandlingRequest
    {
        /// <summary>
        /// The issue code for this request
        /// </summary>
        public readonly string IssueCode;

        /// <summary>
        /// The settings that control what is displayed to the
        /// user via a dialog box.
        /// </summary>
        public readonly IssueDialogSettings Settings;

        /// <summary>
        /// An optional callback if we need to handle the result
        /// of the user's decision (if it's not just an information text box)
        /// </summary>
        public readonly IssueHandledCallback HandledCallback;

        /// <summary>
        /// If using the toggle change feature of the dialog box,
        /// this should be set to the current value.
        /// </summary>
        public readonly bool ToggleCurrentStatus;

        /// <summary>
        /// If this issue represents an exception that needs user handling
        /// or to inform the user of a critical error, this should contain
        /// the caught exception for logging / further handling.
        /// </summary>
        public readonly Exception Exception;

        /// <summary>
        /// Constructor for creating an issue handling request.
        /// </summary>
        /// <param name="issueCode">The code for this issue</param>
        /// <param name="settings">The settings data structure.</param>
        /// <param name="handledCallback">The handled callback, which can be null.</param>
        /// <param name="toggleCurrentStatus">The current toggle status for toggle dialogs, ignored if this isn't a toggle dialog.</param>
        public IssueHandlingRequest(string issueCode, IssueDialogSettings settings, IssueHandledCallback handledCallback = null,
            bool toggleCurrentStatus = false)
        {
            IssueCode = issueCode;
            Settings = settings;
            HandledCallback = handledCallback;
            ToggleCurrentStatus = toggleCurrentStatus;
            Exception = null;
        }
    }
}
