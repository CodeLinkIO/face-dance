using UnityEditor;
#if UNITY_2021_2_OR_NEWER
using UnityEditor.SceneManagement;
#else
using UnityEditor.Experimental.SceneManagement;
#endif

using UnityEngine;
using UnityEngine.UI;

namespace Unity.MARS.Companion.Core
{
    static class SetConstantPhysicalSize
    {
        [MenuItem("GameObject/Set Constant Physical Size %;")]
        static void SetConstantPhysicalSizeAction()
        {
            var stage = PrefabStageUtility.GetCurrentPrefabStage();
            if (stage == null)
                return;

            var root = stage.prefabContentsRoot.transform.parent.gameObject;
            if (root == null)
                return;

            if (root.GetComponent<Canvas>() == null)
                return;

            var scaler = root.GetComponent<CanvasScaler>();
            if (scaler == null)
                scaler = root.AddComponent<CanvasScaler>();

            scaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPhysicalSize;
        }
    }
}
