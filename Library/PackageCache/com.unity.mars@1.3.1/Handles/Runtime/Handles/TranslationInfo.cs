using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    struct TranslationBeginInfo
    {
        public TranslationInfo world { get; private set; }
        public TranslationInfo local { get; private set; }

        public TranslationBeginInfo(TranslationInfo world, TranslationInfo local) : this()
        {
            this.world = world;
            this.local = local;
        }
    }

    struct TranslationUpdateInfo
    {
        public TranslationInfo world { get; private set; }
        public TranslationInfo local { get; private set; }

        public TranslationUpdateInfo(TranslationInfo world, TranslationInfo local) : this()
        {
            this.world = world;
            this.local = local;
        }
    }

    struct TranslationEndInfo
    {
        public TranslationInfo world { get; private set; }
        public TranslationInfo local { get; private set; }

        public TranslationEndInfo(TranslationInfo world, TranslationInfo local) : this()
        {
            this.world = world;
            this.local = local;
        }
    }

    struct TranslationInfo
    {
        public Vector3 initialPosition { get; private set; }
        public Vector3 delta { get; private set; }
        public Vector3 total { get; private set; }
        public Vector3 direction { get; private set; }

        public TranslationInfo(Vector3 initialPos, Vector3 delta, Vector3 total, Vector3 direction) : this()
        {
            this.initialPosition = initialPos;
            this.delta = delta;
            this.total = total;
            this.direction = direction;
        }
    }
}