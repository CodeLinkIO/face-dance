using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    struct RotationBeginInfo
    {
        public RotationInfo world { get; private set; }
        public RotationInfo local { get; private set; }

        public RotationBeginInfo(RotationInfo world, RotationInfo local) : this()
        {
            this.world = world;
            this.local = local;
        }
    }

    struct RotationUpdateInfo
    {
        public RotationInfo world { get; private set; }
        public RotationInfo local { get; private set; }

        public RotationUpdateInfo(RotationInfo world, RotationInfo local) : this()
        {
            this.world = world;
            this.local = local;
        }
    }

    struct RotationEndInfo
    {
        public RotationInfo world { get; private set; }
        public RotationInfo local { get; private set; }

        public RotationEndInfo(RotationInfo world, RotationInfo local) : this()
        {
            this.world = world;
            this.local = local;
        }
    }

    struct RotationInfo
    {
        public float total { get; private set; }
        public float delta { get; private set; }
        public Vector3 axis { get; private set; }

        public RotationInfo(float total, float delta, Vector3 axis) : this()
        {
            this.total = total;
            this.delta = delta;
            this.axis = axis;
        }
    }
}