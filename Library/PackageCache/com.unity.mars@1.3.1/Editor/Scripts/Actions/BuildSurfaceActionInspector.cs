using Unity.MARS.Actions;
using Unity.MARS.Attributes;
using UnityEngine;

using UnityObject = UnityEngine.Object;

namespace UnityEditor.MARS
{
    [ComponentEditor(typeof(BuildSurfaceAction))]
    class BuildSurfaceActionInspector : ComponentInspector
    {
        class Styles
        {
            const string k_PrepareForSurfaceColliderButtonLabel = "Create surface collider";
            const string k_SurfaceColliderButtonTooltip = "Adds the necessary extra components to be able to generate a collider surface on the scanned environment this proxy matches to.";
            const string k_PrepareForSurfaceMeshButtonLabel = "Create surface mesh";
            const string k_SurfaceMeshButtonTooltip = "Adds the necessary extra components to be able to generate a mesh surface on the scanned environment this proxy matches to.";
            const string k_PresetsMessage = "Build Surface Action requires a MeshFilter or a MeshCollider to properly work.";
                
            internal readonly GUIContent surfaceMeshContent;
            internal readonly GUIContent surfaceColliderContent;
            internal readonly GUIContent surfaceActionPresetsMessage; 
            
            internal readonly GUIStyle infoMessageStyle;
            
            internal Styles()
            {
                surfaceMeshContent = new GUIContent(k_PrepareForSurfaceMeshButtonLabel, k_SurfaceMeshButtonTooltip);
                surfaceColliderContent = new GUIContent(k_PrepareForSurfaceColliderButtonLabel, k_SurfaceColliderButtonTooltip);
                
                var infoIconTexture = EditorGUIUtility.IconContent("console.infoicon").image;
                surfaceActionPresetsMessage = new GUIContent(k_PresetsMessage, infoIconTexture);

                infoMessageStyle = EditorStyles.label;
                infoMessageStyle.fontSize = 10;
                infoMessageStyle.wordWrap = true;
                infoMessageStyle.padding = new RectOffset(5, 5, 2, 0);
            }
        }

        static Styles s_Styles;
        static Styles styles => s_Styles ?? (s_Styles = new Styles());
        
        BuildSurfaceAction m_SurfaceActionTarget;
        bool m_ShowPresets ;
        
        public override void OnEnable()
        {
            m_SurfaceActionTarget = (BuildSurfaceAction) target;
            m_ShowPresets = !BuildSurfaceActionHasCorrectComponents();
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            m_ShowPresets = !BuildSurfaceActionHasCorrectComponents();
            if (m_ShowPresets )
            {
                const float helpBoxWidth = 150;
                const float helpBoxHeight = 60f;
                const float buttonPadding = 5;
                var presetsRect = GUILayoutUtility.GetRect(helpBoxWidth, helpBoxHeight, EditorStyles.helpBox);
                
                GUI.Box(presetsRect, string.Empty, EditorStyles.helpBox);
                GUILayout.Space(-helpBoxHeight);
                GUILayout.Label(styles.surfaceActionPresetsMessage, styles.infoMessageStyle);
                using (new GUILayout.HorizontalScope())
                {
                    GUILayout.Space(buttonPadding);
                    if (GUILayout.Button(styles.surfaceMeshContent))
                    {
                        PrepareSurfaceActionToGenerateRenderedMesh();
                    }

                    if (GUILayout.Button(styles.surfaceColliderContent))
                    {
                        PrepareSurfaceActionToGenerateColliderMesh();
                    }
                    GUILayout.Space(buttonPadding);
                }
            }
        }

        void PrepareSurfaceActionToGenerateRenderedMesh()
        {
            Undo.AddComponent<MeshFilter>(m_SurfaceActionTarget.gameObject);
            Undo.AddComponent<MeshRenderer>(m_SurfaceActionTarget.gameObject);
        }

        void PrepareSurfaceActionToGenerateColliderMesh()
        {
            if(m_SurfaceActionTarget.GetComponent<MeshCollider>() != null)
                Undo.DestroyObjectImmediate(m_SurfaceActionTarget.GetComponent<MeshCollider>());
                
            Undo.AddComponent<MeshCollider>(m_SurfaceActionTarget.gameObject);
        }

        bool BuildSurfaceActionHasCorrectComponents()
        {
            return (m_SurfaceActionTarget.GetComponent<MeshFilter>() != null && m_SurfaceActionTarget.GetComponent<MeshRenderer>() != null) ||
                   m_SurfaceActionTarget.GetComponent<MeshCollider>() != null;
        }
    }
}
