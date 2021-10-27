using UnityEngine;
using UnityEngine.UI;

namespace Unity.MARS.Companion.Core
{
    /// <summary>
    /// Common utility methods for UI
    /// </summary>
    public static class UIUtils
    {
        /// <summary>
        /// Force ContentSizeFitters on this object and its parent to update
        /// </summary>
        /// <param name="gameObject"></param>
        public static void UpdateConstrainedTextLayout(GameObject gameObject)
        {
            var contentSizeFitter = gameObject.GetComponent<ContentSizeFitter>();
            if (contentSizeFitter != null)
                contentSizeFitter.SetLayoutHorizontal();

            contentSizeFitter = gameObject.GetComponentInParent<ContentSizeFitter>();
            if (contentSizeFitter != null)
                contentSizeFitter.SetLayoutHorizontal();
        }
    }
}
