using UnityEngine;

namespace Unity.MARS.Behaviors
{
    internal class Scatter : ContentAction
    {
        [Range(0, 2f)]
        [SerializeField]
        float m_Radius = 0.5f;

        void OnEnable()
        {
            var parent = transform.parent;

            Vector3[] dirs = {Vector3.forward, Vector3.right, Vector3.back, Vector3.left};
            foreach (var dir in dirs)
            {
                var clone = Instantiate(parent, parent.parent).transform;
                foreach (var scatterChild in clone.GetComponentsInChildren<Scatter>())
                {
                    DestroyImmediate(scatterChild);
                }

                clone.position += dir * m_Radius;
            }
        }
    }
}
