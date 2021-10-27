using System;
using Unity.MARS.Attributes;
using Unity.MARS.Landmarks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Landmarks
{
    /// <summary>
    /// Inspector for a component that defines landmarks
    /// </summary>
    [ComponentEditor(typeof(ICalculateLandmarks), true)]
    [MovedFrom("Unity.MARS")]
    public class CalculateLandmarksInspector : ComponentInspector
    {
        /// <inheritdoc />
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            LandmarkControllerEditor.DrawAddLandmarkButton((ICalculateLandmarks)target);
        }

        /// <inheritdoc />
        public override bool HasDisplayProperties()
        {
            return true;
        }
    }
}
