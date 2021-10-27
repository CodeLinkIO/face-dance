using Unity.MARS.Authoring;
using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
#if UNITY_2021_2_OR_NEWER
using UnityEditor.SceneManagement;
#else
using UnityEditor.Experimental.SceneManagement;
#endif
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Authoring
{
    /// <summary>
    /// Whenever the selection is changed in the editor, this module will replace elements in the selection that have a
    /// "RedirectSelection" component with the GameObject that the component specifies as the target
    /// </summary>
    [MovedFrom("Unity.MARS")]
    sealed class SelectionRedirectModule : IModule
    {
        Object[] m_NewSelection;
        bool m_RedirectSelection;

        void IModule.LoadModule()
        {
            SceneView.duringSceneGui += OnSceneGUI;
            Selection.selectionChanged += OnSelectionChanged;
        }

        void IModule.UnloadModule()
        {
            SceneView.duringSceneGui -= OnSceneGUI;
            Selection.selectionChanged -= OnSelectionChanged;
        }

        void OnSelectionChanged()
        {
            var prefabStage = PrefabStageUtility.GetCurrentPrefabStage();
            // When selecting an object with a RedirectSelection component, we want to change the selection to the object it targets. Selection cannot
            // be changed within onSelectionChanged callback so use a variable and then change the selection before repaint
            // The selection change does not use EditorApplication.delayCall because that would show the selection change quickly after 1 frame.
            if (MarsDebugSettings.allowInteractionTargetSelection && prefabStage == null)
                return;

            var selectedObjects = Selection.objects;
            m_RedirectSelection = false;
            for (var i = 0; i < selectedObjects.Length; i++)
            {
                var selectedObj = selectedObjects[i];
                var selectedGameObject = selectedObj as GameObject;
                if (selectedGameObject == null || MarsDebugSettings.allowInteractionTargetSelection && selectedGameObject.scene != prefabStage.scene)
                    continue;

                var redirector = selectedGameObject.GetComponentInParent<RedirectSelection>();
                if (redirector != null && redirector.target != null)
                {
                    selectedObjects[i] = redirector.target;
                    m_RedirectSelection = true;
                }
            }

            m_NewSelection = selectedObjects;
        }

        void OnSceneGUI(SceneView sceneView)
        {
            DoRedirect();
        }

        void DoRedirect()
        {
            // Change the selection to the redirected objects
            if (m_RedirectSelection)
            {
                m_RedirectSelection = false;
                Selection.objects = m_NewSelection;
            }
        }
    }
}
