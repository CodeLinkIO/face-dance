using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Unity.MARS.Behaviors
{
    internal class RandomizeTransform : ContentAction
    {
#pragma warning disable 649
        [SerializeField]
        Vector3 m_PositionRange;

        [SerializeField]
        bool m_RandomizeYaw;

        [SerializeField]
        [Min(0f)]
        float m_ScaleRange;
#pragma warning restore 649

        void OnEnable()
        {
            var parent = transform.parent;

            if (m_PositionRange != Vector3.zero)
            {
                var randomX = Random.Range(-m_PositionRange.x, m_PositionRange.x);
                var randomY = Random.Range(-m_PositionRange.y, m_PositionRange.y);
                var randomZ = Random.Range(-m_PositionRange.z, m_PositionRange.z);

                parent.position += new Vector3(randomX, randomY, randomZ);
            }

            if (m_RandomizeYaw)
                parent.Rotate(Vector3.up, Random.Range(0f, 360f), Space.Self);

            if (Math.Abs(m_ScaleRange) > Mathf.Epsilon)
                parent.localScale *= 1f + Random.Range(-m_ScaleRange, m_ScaleRange);
        }
    }
}
