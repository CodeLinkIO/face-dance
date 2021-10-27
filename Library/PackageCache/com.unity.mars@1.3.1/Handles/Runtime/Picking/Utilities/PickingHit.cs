using System;

namespace Unity.MARS.MARSHandles.Picking
{
    struct PickingHit : IComparable<PickingHit>
    {
        public float distance { get; private set; }
        public IPickingTarget target { get; private set; }

        public bool valid { get { return target != null; } }

        public PickingHit(IPickingTarget target, float distance) : this()
        {
            this.target = target;
            this.distance = distance;
        }

        public int CompareTo(PickingHit other)
        {
            return distance.CompareTo(other.distance);
        }
    }
}