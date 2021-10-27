using Unity.MARS.Attributes;
using UnityEditor;
using UnityEditor.MARS;

namespace Unity.MARS
{
    [ComponentEditor(typeof(Replicator))]
    class ReplicatorInspector : ComponentInspector
    {
        Replicator m_Replicator;

        public override void OnEnable()
        {
            base.OnEnable();

            m_Replicator = target as Replicator;
        }

        public override void OnInspectorGUI()
        {
            // Refresh Child Objects
            serializedObject.Update();

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                DrawDefaultInspector();

                if (!m_Replicator.HasSourceObject)
                {
                    var errorMessage = string.Empty;
                    var replicantTarget = m_Replicator.CheckReplicatorSetup(ref errorMessage);
                    if (replicantTarget == null)
                        EditorGUIUtils.Warning(errorMessage);
                    else
                    {
                        EditorGUI.indentLevel++;
                        using (new EditorGUI.DisabledScope(true))
                            EditorGUILayout.ObjectField("Target to replicate", replicantTarget, replicantTarget.GetType(), true);
                        EditorGUI.indentLevel--;
                    }
                }

                if (check.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
