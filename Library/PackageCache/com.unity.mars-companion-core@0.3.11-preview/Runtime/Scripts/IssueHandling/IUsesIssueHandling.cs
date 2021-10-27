using System;
using Unity.XRTools.ModuleLoader;

namespace Unity.MARS.Companion.Core
{
    interface IUsesIssueHandling : IFunctionalitySubscriber<IProvidesIssueHandling>
    {
    }

    static class IssueHandlingMethods
    {
        public static void RaiseIssueRequest(this IUsesIssueHandling user, in IssueHandlingRequest request)
        {
            user.provider.RaiseIssueRequest(request);
        }

        public static void RaiseIssueRequest(this IUsesIssueHandling user, string issueCode,
            IssueDialogSettings? settings = null, IssueHandledCallback handlingHandledCallback = null, bool useToggle = false, bool toggleStatus = false)
        {
            user.provider.RaiseIssueRequest(issueCode, settings, handlingHandledCallback, useToggle, toggleStatus);
        }

        public static void RaiseIssueRequest(this IUsesIssueHandling user, string infoText, string issueCode,
            Action callback = null)
        {
            user.provider.RaiseIssueRequest(infoText, issueCode, callback);
        }

        public static void RaiseIssueRequest(this IUsesIssueHandling user, string issueCode, Action closedCallback)
        {
            user.provider.RaiseIssueRequest(issueCode, closedCallback);
        }

        public static bool GetIssueDialogSettings(this IUsesIssueHandling user, string issueCode,
            out IssueDialogSettings settings)
        {
            return user.provider.GetIssueDialogSettings(issueCode, out settings);
        }

        public static void SubscribeOnIssueRaised(this IUsesIssueHandling user,
            IssueHandlingRequested onIssueRaised)
        {
            user.provider.OnIssueRaised += onIssueRaised;
        }

        public static void UnsubscribeOnIssueRaised(this IUsesIssueHandling user,
            IssueHandlingRequested onIssueRaised)
        {
            user.provider.OnIssueRaised -= onIssueRaised;
        }

        public static bool IsIgnored(this IUsesIssueHandling user, string issueCode)
        {
            return user.provider.IsIgnored(issueCode);
        }
    }
}
