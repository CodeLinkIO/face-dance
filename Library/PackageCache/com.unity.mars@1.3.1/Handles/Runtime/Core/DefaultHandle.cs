using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    enum DefaultHandle
    {
        PositionHandle,
    }

    internal static class DefaultHandles
    {
        static GameObject s_PositionPrefab;

        public static GameObject GetPrefab(DefaultHandle handle)
        {
            switch (handle)
            {
                case DefaultHandle.PositionHandle:
                    if (s_PositionPrefab == null)
                        s_PositionPrefab = Resources.Load<GameObject>("Handles/position-handle");

                    return s_PositionPrefab;
            }

            return null;
        }
    }
}
