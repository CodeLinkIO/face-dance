using System;
using System.Linq;
using UnityEngine;

namespace Unity.XRTools.Utils
{
    public static class DebugUtils
    {
        static readonly bool k_DontLogAnything;

        static DebugUtils()
        {
            k_DontLogAnything = Environment.GetCommandLineArgs().Contains("-runTests");
        }

        /// <summary>
        /// Debug.Log, but will not print anything if tests are being run
        /// </summary>
        public static void Log(string message, UnityEngine.Object context = null)
        {
            if(!k_DontLogAnything)
                Debug.Log(message, context);
        }

        /// <summary>
        /// Debug.LogWarning, but will not print anything if tests are being run
        /// </summary>
        public static void LogWarning(string message, UnityEngine.Object context = null)
        {
            if(!k_DontLogAnything)
                Debug.LogWarning(message, context);
        }

        /// <summary>
        /// Debug.LogError, but will not print anything if tests are being run
        /// </summary>
        public static void LogError(string message, UnityEngine.Object context = null)
        {
            if(!k_DontLogAnything)
                Debug.LogError(message, context);
        }

        /// <summary>
        /// Debug.LogException, but will not print anything if tests are being run
        /// </summary>
        public static void LogException(Exception exception, UnityEngine.Object context = null)
        {
            if(!k_DontLogAnything)
                Debug.LogException(exception, context);
        }
    }
}
