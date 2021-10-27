using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    abstract class InteractiveHandle : HandleBehaviour
    {
        public abstract Plane GetProjectionPlane(Vector3 camPosition);
    }
}