using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    interface IHandleContext
    {
        GameObject CreateHandle(DefaultHandle handle);
        GameObject CreateHandle(GameObject prefab);
        bool DestroyHandle(GameObject handle);
    }
}