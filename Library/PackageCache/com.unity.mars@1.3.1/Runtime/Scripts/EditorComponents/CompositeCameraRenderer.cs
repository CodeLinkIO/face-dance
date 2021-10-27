using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Simulation.Rendering
{
    [ExecuteAlways]
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Camera))]
    [MovedFrom("Unity.MARS")]
    public class CompositeCameraRenderer : MonoBehaviour
    {
        public event Action PreCullCamera;
        public event Action PostRenderCamera;

        void OnPreCull()
        {
            PreCullCamera?.Invoke();
        }

        void OnPostRender()
        {
            PostRenderCamera?.Invoke();
        }
    }
}
