using Unity.MARS.Conditions;
using UnityEditor;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Editor that handles in-lining up to four member condition editors of a multi-condition into a single editor
    /// </summary>
    [CustomEditor(typeof(MultiConditionBase), true)]
    class MultiConditionEditor : Editor
    {
        MultiConditionInspector m_MultiConditionInspector;

        public void OnEnable()
        {
            m_MultiConditionInspector = new MultiConditionInspector();
            m_MultiConditionInspector.Init(target, this);
        }

        public override void OnInspectorGUI()
        {
            m_MultiConditionInspector.OnInspectorGUI();
        }
    }
}
