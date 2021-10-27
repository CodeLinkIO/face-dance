using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Data
{
    /// <summary>
    /// GUI utilities for drawing buttons for geo locations
    /// </summary>
    [MovedFrom("Unity.MARS.Providers")]
    public static class GeoLocationShortcutButtons
    {
        /// <summary>
        /// Draws an array of buttons for selecting a geo location from <c>MarsUserGeoLocations.UserGeoLocations</c>
        /// </summary>
        /// <param name="title">Title label for the buttons</param>
        /// <param name="shortcutAction">Button action for when it is pressed</param>
        /// <param name="useFoldout">Group the buttons under a foldout</param>
        /// <param name="isOpen">Is the foldout group open</param>
        /// <returns></returns>
        public static bool DrawShortcutButtons(string title, Action<double, double> shortcutAction,
            bool useFoldout = false, bool isOpen = true)
        {
            using (new EditorGUILayout.VerticalScope())
            {
                if (useFoldout)
                    isOpen = EditorGUILayout.Foldout(isOpen, title);
                else
                    EditorGUILayout.LabelField(title, EditorStyles.boldLabel);

                if (!useFoldout || isOpen)
                {
                    foreach (var shortcutButton in MarsUserGeoLocations.instance.UserGeoLocations)
                    {
                        if (GUILayout.Button(shortcutButton.Name))
                        {
                            shortcutAction(shortcutButton.Location.latitude, shortcutButton.Location.longitude);
                        }
                    }
                }
            }

            return isOpen;
        }
    }
}
