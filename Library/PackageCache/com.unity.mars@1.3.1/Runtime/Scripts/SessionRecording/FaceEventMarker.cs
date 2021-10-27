using Unity.MARS.Data.Recorded;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Unity.MARS.Recording
{
    class FaceEventMarker : Marker, INotification, INotificationOptionProvider
    {
        const NotificationFlags k_Flags = NotificationFlags.Retroactive | NotificationFlags.TriggerInEditMode;

        [SerializeField]
        SerializedFaceData m_FaceData;

        [SerializeField]
        TrackableEventType m_EventType;

        public PropertyName id { get; } = new PropertyName();

        public NotificationFlags flags => k_Flags;

        public SerializedFaceData FaceData => m_FaceData;

        public TrackableEventType EventType => m_EventType;

        public void SetData(FaceEvent faceEvent)
        {
            var faceData = faceEvent.FaceData;
            var eventType = faceEvent.EventType;
            m_FaceData = faceData;
            m_EventType = eventType;
            name = $"{eventType} Face {faceData.ID}";
        }
    }
}
