using Unity.MARS.Data;
using Unity.MARS.Data.Recorded;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Unity.MARS.Recording
{
    class PlaneEventMarker : Marker, INotification, INotificationOptionProvider
    {
        const NotificationFlags k_Flags = NotificationFlags.Retroactive | NotificationFlags.TriggerInEditMode;

        [SerializeField]
        MRPlane m_Plane;

        [SerializeField]
        TrackableEventType m_EventType;

        readonly PropertyName m_ID = new PropertyName();

        public PropertyName id { get { return m_ID; } }

        public NotificationFlags flags { get { return k_Flags; } }

        public MRPlane Plane => m_Plane;

        public TrackableEventType EventType => m_EventType;

        public void SetData(PlaneEvent planeEvent)
        {
            var plane = planeEvent.plane;
            var eventType = planeEvent.eventType;
            m_Plane = plane;
            m_EventType = eventType;
            name = $"{eventType} Plane {plane.id}";
        }
    }
}
