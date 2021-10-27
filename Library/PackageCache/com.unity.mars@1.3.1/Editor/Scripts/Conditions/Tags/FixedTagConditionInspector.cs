using Unity.MARS.Conditions;
using UnityEditor.MARS.Authoring;
using UnityEngine.Scripting.APIUpdating;

#if UNITY_2020_2_OR_NEWER
using UnityEditor.EditorTools;
#else
using ToolManager = UnityEditor.EditorTools.EditorTools;
#endif

namespace UnityEditor.MARS
{
    /// <summary>
    /// Base class for blank semantic tag condition inspectors
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public abstract class FixedTagConditionInspector : ComponentInspector
    {
        /// <inheritdoc/>
        public override bool HasDisplayProperties()
        {
            return ToolManager.activeToolType == typeof(MarsCompareTool);
        }

        /// <inheritdoc/>
        public override void OnInspectorGUI()
        {
            if (isDirty)
                CleanUp();

            serializedObject.Update();

            MarsCompareTool.DrawComponentControls(target as SimpleTagCondition);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
