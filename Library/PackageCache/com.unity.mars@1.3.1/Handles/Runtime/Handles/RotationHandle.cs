using System;
using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    [ExecuteInEditMode]
    [AddComponentMenu("")]
    sealed class RotationHandle : MonoBehaviour
    {
        public event Action<RotationBeginInfo> rotationBegun;
        public event Action<RotationUpdateInfo> rotationUpdated;
        public event Action<RotationEndInfo> rotationEnded;

        [SerializeField]
        RotatorHandle[] m_Rotators = new RotatorHandle[0];

        void Awake()
        {
            foreach (var rotator in m_Rotators)
            {
                if (rotator == null)
                    continue;

                rotator.rotationBegun += OnRotationBegun;
                rotator.rotationUpdated += OnRotationUpdated;
                rotator.rotationEnded += OnRotationEnded;
            }
        }

        void OnRotationBegun(RotationBeginInfo info)
        {
            if (rotationBegun != null) rotationBegun.Invoke(info);
        }

        void OnRotationUpdated(RotationUpdateInfo info)
        {
            if (rotationUpdated != null) rotationUpdated.Invoke(info);
        }

        void OnRotationEnded(RotationEndInfo info)
        {
            if (rotationEnded != null) rotationEnded.Invoke(info);
        }
    }
}
