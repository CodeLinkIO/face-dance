using UnityEngine;

#if INCLUDE_DELTA_DNA
using DeltaDNA;
#endif

namespace Unity.MARS.Companion.Analytics
{
    enum UserRole
    {
        Anonymous,
        SignedIn
    }

    static class AnalyticsUtils
    {
        public const string UserRoleParamName = "userRole";
        const string k_ProjectIdParamName = "projectId";
        public static string CurrentProjectId { get; set; }
        public static UserRole CurrentUserRole { get; set; }

        public static void Initialize()
        {
#if INCLUDE_DELTA_DNA
            DDNA.Instance.StartSDK();
#endif
        }

#if INCLUDE_DELTA_DNA
        public static GameEvent GetGameEventWithProjectID(string eventName)
        {
            var gameEvent = new GameEvent(eventName);
            if (!string.IsNullOrEmpty(CurrentProjectId))
                gameEvent.AddParam(k_ProjectIdParamName, CurrentProjectId);

            return gameEvent;
        }
#endif
    }
}
