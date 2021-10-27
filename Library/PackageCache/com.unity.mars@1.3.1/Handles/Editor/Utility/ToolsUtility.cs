using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Unity.MARS.HandlesEditor
{
    static class ToolsUtility
    {
        internal static class TestAccess
        {
            public static bool invalidateHandlePositionExists => s_InvalidateHandlePosition != null;
        }

        static readonly Action s_InvalidateHandlePosition;

        static ToolsUtility()
        {
            var method = typeof(Tools).GetMethod("InvalidateHandlePosition", BindingFlags.Static | BindingFlags.NonPublic);
            if (method == null)
            {
                Debug.LogError("Couldn't find InvalidateHandlePosition in UnityEditor.Tools");
                return;
            }

            s_InvalidateHandlePosition = (Action)Delegate.CreateDelegate(typeof(Action), method);
        }

        public static void InvalidateHandlePosition()
        {
            s_InvalidateHandlePosition?.Invoke();
        }
    }
}
