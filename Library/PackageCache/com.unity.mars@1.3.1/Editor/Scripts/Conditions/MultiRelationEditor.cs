using Unity.MARS.Conditions;
using UnityEditor;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Editor that handles in-lining up to three member condition editors of a multi-condition into a single editor
    /// </summary>
    [CustomEditor(typeof(MultiRelationBase), true)]
    class MultiRelationEditor : Editor
    {
        MultiRelationInspector m_MultiRelationInspector;

        public void OnEnable()
        {
            m_MultiRelationInspector = new MultiRelationInspector();
            m_MultiRelationInspector.Init(target, this);
        }

        public override void OnInspectorGUI()
        {
            m_MultiRelationInspector.OnInspectorGUI();
        }
    }
}
