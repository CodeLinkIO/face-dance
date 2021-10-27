using System;
using System.Collections;
using UnityEngine;

namespace Unity.XRTools.Utils
{
    /// <summary>
    /// Used for launching co-routines
    /// TODO: Use EditorCoroutines package
    /// </summary>
    public sealed class EditorMonoBehaviour : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance property
        /// </summary>
        public static EditorMonoBehaviour instance { get; private set; }

        void Awake()
        {
            instance = this;
        }

        void OnDestroy()
        {
            if (instance == this)
                instance = null;
        }

        internal static void StartEditorCoroutine(IEnumerator routine)
        {
            // Avoid null-coalescing operator for UnityObject
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (instance)
                instance.StartCoroutine(routine);
        }
    }
}
