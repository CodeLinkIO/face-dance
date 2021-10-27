using Unity.MARS.Attributes;
using Unity.MARS.Forces.EditorExtensions;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS.Forces
{
    [ComponentEditor(typeof(ProxyForces))]
    class ProxyForcesInspector : ComponentInspector
    {

        public override void OnSceneGUI()
        {
            base.OnSceneGUI();
            var forces = (target as ProxyForces);
            if (forces)
            {
                ProxyForcesHandles.main.CustomForcesHandles(forces);
            }
        }
    }
}
