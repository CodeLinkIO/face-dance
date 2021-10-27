using System;
using Unity.MARS;
using Unity.MARS.Behaviors;
using UnityEngine;

namespace UnityEditor.MARS.Forces.EditorExtensions
{
    [CustomEditor(typeof(ApplyForces))]
    class ApplyForcesEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ApplyForces applyForces = (ApplyForces)this.target;
            GameObject addTo = applyForces.gameObject;
            var isGoBack = false;

            var proxy = addTo.GetComponentInParent<Proxy>();
            if (proxy)
                addTo = proxy.gameObject;

            if ((addTo != applyForces.gameObject) && GUILayout.Button("Back to Content", MarsEditorGUI.Styles.MiniFontButton))
                isGoBack = true;

            if (ForcesMenuItemsRegions.DrawForcesInInspectorForMainProxy(addTo, true))
                isGoBack = true;

            if (isGoBack)
                Selection.activeObject = addTo;
        }
    }
}
