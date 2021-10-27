using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    static class CoroutineUtils
    {
#if UNITY_EDITOR
        static readonly HashSet<IEnumerator> k_Coroutines = new HashSet<IEnumerator>();

        static CoroutineUtils()
        {
            EditorApplication.update += RunCoroutines;
        }

        static void RunCoroutines()
        {
            try
            {
                if (k_Coroutines.Count == 0)
                    return;

                var coroutineList = k_Coroutines.ToList();
                foreach (var coroutine in coroutineList)
                {
                    if (!coroutine.MoveNext())
                        k_Coroutines.Remove(coroutine);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
#else
        public static Func<IEnumerator, Coroutine> StartCoroutineAction { set; private get; }
#endif

        public static void StartCoroutine(IEnumerator coroutine)
        {
 #if UNITY_EDITOR
            k_Coroutines.Add(coroutine);
#else
            StartCoroutineAction(coroutine);
#endif
        }
    }
}
