using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    struct ScalingUpdatedInfo
    {
        public ScalingInfo world { get; private set; }
        public ScalingInfo local { get; private set; }

        public ScalingUpdatedInfo(ScalingInfo world, ScalingInfo local) : this()
        {
            this.world = world;
            this.local = local;
        }
    }

    struct ScalingInfo
    {
        public Vector3 initial { get; private set; }
        public Vector3 delta { get; private set; }
        public Vector3 total { get; private set; }

        public ScalingInfo(Vector3 initial, Vector3 delta, Vector3 total) : this()
        {
            this.initial = initial;
            this.delta = delta;
            this.total = total;
        }
    }
}