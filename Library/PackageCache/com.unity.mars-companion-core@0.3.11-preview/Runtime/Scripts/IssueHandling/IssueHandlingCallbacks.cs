namespace Unity.MARS.Companion.Core
{
    /// <summary>
    /// Delegate used by the IssueHandling framework when an issue is requested.
    /// Implementers of <see cref="IUsesIssueHandling"/> must subscribe and handle
    /// how the request is presented to the user.
    /// </summary>
    /// <param name="request">The request data struct.</param>
    public delegate void IssueHandlingRequested(in IssueHandlingRequest request);

    /// <summary>
    /// The callback that signals the issue has been handled by user action
    /// </summary>
    /// <param name="result">The results struct that contains the results of the user's decision (if applicable)</param>
    public delegate void IssueHandledCallback(IssueHandlingResult result);
}
