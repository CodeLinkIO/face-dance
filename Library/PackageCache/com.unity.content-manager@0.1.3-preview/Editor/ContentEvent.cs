using UnityEditor.PackageManager.Requests;

namespace Unity.ContentManager
{
    /// <summary>
    /// Contains data for a queued Package Manager operation.
    /// </summary>
    [System.Serializable]
    class ContentEvent
    {
        public PackageAction action;
        public ContentPack targetPack;
        public Request request;
    }
}
