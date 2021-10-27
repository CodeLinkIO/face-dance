using UnityEngine;

#if INCLUDE_DELTA_DNA
using DeltaDNA;
#endif

namespace Unity.MARS.Companion.Analytics
{
    enum UIAction
    {
        ShowView
    }

    enum UILocation
    {
        WelcomeScreen,
        ProjectListMenu,
        Profile,
        ImportProject,
        ResourceListMenu,
        Home,
        Proxy,
        Environment,
        RecordData,
        Marker
    }

    static class UIInteractionEvent
    {
        const string k_EventName = "uiInteraction";
        const string k_ActionParamName = "UIAction";
        const string k_LocationParamName = "UILocation";

        public static void SendEvent(UIAction action, UILocation location)
        {
#if INCLUDE_DELTA_DNA
            if (!Application.isPlaying)
                return;

            DDNA.Instance.RecordEvent(AnalyticsUtils.GetGameEventWithProjectID(k_EventName)
                .AddParam(AnalyticsUtils.UserRoleParamName, AnalyticsUtils.CurrentUserRole)
                .AddParam(k_ActionParamName, action.ToString())
                .AddParam(k_LocationParamName, location.ToString()));
#endif
        }
    }
}
