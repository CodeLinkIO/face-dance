using System;
using UnityEngine;

namespace Unity.XRTools.Utils
{
    /// <summary>
    /// Behavior that fires a callback when it is destroyed
    /// </summary>
    [ExecuteInEditMode]
    public class OnDestroyNotifier : MonoBehaviour
    {
        /// <summary>
        /// Called when this behavior is destroyed
        /// </summary>
        public Action<OnDestroyNotifier> destroyed { private get; set; }

        void OnDestroy()
        {
            if (destroyed != null)
                destroyed(this);
        }
    }
}
