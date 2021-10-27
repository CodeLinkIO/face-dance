namespace Unity.MARS.Companion.Core
{
    /// <summary>
    /// The result of a Issue handling dialog closure
    /// </summary>
    public struct IssueHandlingResult
    {
        /// <summary>
        /// If the dialog has the ability to accept, and the user accepted, then this will be true.
        /// </summary>
        public bool Accept;

        /// <summary>
        /// Returns the toggle state, which the user can only change if the dialog request
        /// includes the ability to change the set toggle value.
        /// If the toggle dialog box was canceled, this value should be the same as was passed
        /// into the request (no change).
        /// </summary>
        public bool Toggled;
    }
}
