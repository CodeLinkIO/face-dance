using Unity.MARS.Companion.Core;
using UnityEngine;

#if INCLUDE_DELTA_DNA
using DeltaDNA;
#endif

namespace Unity.MARS.Companion.Analytics
{
    enum SyncAction
    {
        Upload,
        Download,
        Remove
    }

    static class ResourceSyncEvent
    {
        const string k_EventName = "resourceSync";
        const string k_SyncActionParamName = "syncAction";
        const string k_ResourceKeyParamName = "resourceKey";
        const string k_ResourceTypeParamName = "resourceType";
        const string k_FileSizeParamName = "fileSize";

        public static void SendEvent(SyncAction action, string key, ResourceType type, long fileSize)
        {
#if INCLUDE_DELTA_DNA
            if (!Application.isPlaying)
                return;

            DDNA.Instance.RecordEvent(AnalyticsUtils.GetGameEventWithProjectID(k_EventName)
                .AddParam(k_SyncActionParamName, action.ToString())
                .AddParam(k_ResourceKeyParamName, key)
                .AddParam(k_ResourceTypeParamName, type.ToString())
                .AddParam(k_FileSizeParamName, fileSize));
#endif
        }
    }
}
