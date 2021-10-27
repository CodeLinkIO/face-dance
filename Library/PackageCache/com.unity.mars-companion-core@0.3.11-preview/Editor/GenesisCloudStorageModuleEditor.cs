using System.Collections.Generic;
using Unity.MARS.Companion.CloudStorage;
using UnityEditor;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [CustomEditor(typeof(GenesisCloudStorageModule))]
    class GenesisCloudStorageModuleEditor : Editor
    {
        const string k_GenesisRequestCountFormat = "Genesis Requests: {0}";
        const string k_RequestCountFormat = "Requests: {0}";

        bool m_RequestsExpanded;
        bool m_GenesisRequestsExpanded;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var module = (GenesisCloudStorageModule)target;
            DrawRequests(ref m_GenesisRequestsExpanded, k_GenesisRequestCountFormat, module.GenesisRequests);
            DrawRequests(ref m_RequestsExpanded, k_RequestCountFormat, module.Requests);
        }

        void DrawRequests(ref bool expanded, string countFormat, Dictionary<RequestHandle, GenesisCloudStorageModule.IRequest> requests)
        {
            expanded = EditorGUILayout.Foldout(expanded, string.Format(countFormat, requests.Count), true);
            if (expanded)
            {
                using (new EditorGUI.IndentLevelScope())
                {
                    foreach (var kvp in requests)
                    {
                        EditorGUILayout.LabelField($"{kvp.Key} - {kvp.Value}");
                    }
                }

                Repaint();
            }
        }
    }
}
