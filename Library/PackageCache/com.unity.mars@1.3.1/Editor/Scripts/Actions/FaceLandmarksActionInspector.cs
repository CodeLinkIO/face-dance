using System.Collections.Generic;
using Unity.MARS;
using Unity.MARS.Attributes;
using Unity.MARS.Landmarks;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Authoring;
using UnityEditor.MARS.Landmarks;
using UnityEngine;

namespace UnityEditor.MARS
{
    [ComponentEditor(typeof(FaceLandmarksAction))]
    class FaceLandmarksActionInspector : CalculateLandmarksInspector
    {
        const string k_CreateAllLandmarksLabel = "Create all face landmarks";
        FaceLandmarksAction m_FaceLandmarksAction;

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        // Reference type collections must also be cleared after use
        static readonly HashSet<LandmarkDefinition> k_MissingLandmarks = new HashSet<LandmarkDefinition>();

        public override void OnEnable()
        {
            m_FaceLandmarksAction = (FaceLandmarksAction)target;
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            k_MissingLandmarks.Clear();
            var allLandmarkDefinitions = m_FaceLandmarksAction.AvailableLandmarkDefinitions;
            foreach (var definition in allLandmarkDefinitions)
            {
                k_MissingLandmarks.Add(definition);
            }

            var landmarks = m_FaceLandmarksAction.landmarks;
            foreach (var landmark in landmarks)
            {
                k_MissingLandmarks.Remove(landmark.landmarkDefinition);
            }

            using (new EditorGUI.DisabledScope(k_MissingLandmarks.Count == 0))
            {
                if (GUILayout.Button(k_CreateAllLandmarksLabel))
                {
                    foreach (var def in allLandmarkDefinitions)
                    {
                        if (k_MissingLandmarks.Contains(def))
                            m_FaceLandmarksAction.CreateLandmarkAsChild(def, def.outputTypes[0]);
                    }

                    var entityVisualsModule = ModuleLoaderCore.instance.GetModule<EntityVisualsModule>();
                    var marsEntity = m_FaceLandmarksAction.GetComponentInParent<MARSEntity>();
                    if (entityVisualsModule != null && marsEntity != null)
                    {
                        entityVisualsModule.InvalidateVisual(marsEntity);
                    }
                }
            }

            k_MissingLandmarks.Clear();
            base.OnInspectorGUI();
        }
    }
}
