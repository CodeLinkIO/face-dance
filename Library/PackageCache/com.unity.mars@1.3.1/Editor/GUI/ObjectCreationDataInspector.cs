namespace UnityEditor.MARS
{
    [CustomEditor(typeof(ObjectCreationData), true)]
    class ObjectCreationDataInspector : Editor
    {
        void OnEnable()
        {
            var inspectedTarget = (ObjectCreationData) target;
            inspectedTarget.UpdateObjectGUIContent();
        }

        public override void OnInspectorGUI()
        {
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                base.OnInspectorGUI();

                if (check.changed)
                {
                    var inspectedTarget = (ObjectCreationData) target;
                    inspectedTarget.UpdateObjectGUIContent();
                }
            }
        }
    }
}
