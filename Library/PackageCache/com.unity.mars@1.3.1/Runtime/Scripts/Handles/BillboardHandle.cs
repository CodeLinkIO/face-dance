using UnityEngine;
using Unity.MARS.MARSHandles;

namespace Unity.MARS
{
    [AddComponentMenu("")]
    [ExecuteInEditMode]
    class BillboardHandle : HandleBehaviour
    {
        protected override void PreRender(Camera camera)
        {
            base.PreRender(camera);
            if (camera == null)
                return;

            var forward = camera.transform.forward;
            if (forward != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(forward, camera.transform.up);
        }
    }
}
