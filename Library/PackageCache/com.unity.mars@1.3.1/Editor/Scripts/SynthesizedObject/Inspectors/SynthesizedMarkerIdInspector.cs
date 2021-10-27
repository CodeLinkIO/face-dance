using Unity.MARS.Data;
using Unity.MARS.Data.Synthetic;
using UnityEditor;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(SynthesizedMarkerId))]
    class SynthesizedMarkerIdInspector : Editor
    {
        const string k_SynthesizedMarkerGuidProp = "m_MarkerGuid";
        const string k_SynthesizedMarkerTextureProp = "m_SyntheticMarkerTexture";

        Vector3 m_LastSyncedTransformScale = Vector3.one;

        MarkerDefinitionSelectorDrawer m_MarkerDefinitionSelectorDrawer;
        SerializedProperty m_SynthMarkerGuidProperty;
        SerializedProperty m_SynthMarkerTextureProperty;

        SynthesizedMarkerId m_SynthesizedMarkerId;

        void OnEnable()
        {
            m_SynthesizedMarkerId = (SynthesizedMarkerId) target;

            m_SynthMarkerGuidProperty = serializedObject.FindProperty(k_SynthesizedMarkerGuidProp);
            m_SynthMarkerTextureProperty = serializedObject.FindProperty(k_SynthesizedMarkerTextureProp);


            m_MarkerDefinitionSelectorDrawer = new MarkerDefinitionSelectorDrawer(m_SynthMarkerGuidProperty.stringValue);

            HideRenderingAndSyntheticComponents(m_SynthesizedMarkerId.gameObject);
        }

        void OnDisable()
        {
            m_MarkerDefinitionSelectorDrawer = null;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var markerLibrary = ImageMarkerEditorUtils.GetSessionMarkerLibrary();
            if (markerLibrary == null)
                return;

            var markerIndex = ImageMarkerEditorUtils.UnselectedMarkerIndex;
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                var currentMarkerID = m_SynthMarkerGuidProperty.stringValue;
                var newMarkerID = m_MarkerDefinitionSelectorDrawer.DrawSelectorGUI(markerLibrary, currentMarkerID);

                markerIndex = ImageMarkerEditorUtils.CurrentSelectedImageMarkerIndex(markerLibrary, newMarkerID);

                if (markerIndex != ImageMarkerEditorUtils.UnselectedMarkerIndex)
                {
                    var markerDefinition = markerLibrary[markerIndex];

                    if (newMarkerID != currentMarkerID)
                    {
                        m_SynthMarkerGuidProperty.stringValue = newMarkerID;
                        m_SynthMarkerTextureProperty.objectReferenceValue = markerDefinition.Texture;

                        serializedObject.ApplyModifiedProperties();
                        m_MarkerDefinitionSelectorDrawer.UpdateMarkerLibraryData(m_SynthMarkerGuidProperty.stringValue);
                    }

                    if (check.changed)
                        m_SynthesizedMarkerId.UpdateMarkerSize(markerDefinition.Size);

                }

                if (check.changed)
                {
                    serializedObject.ApplyModifiedProperties();
                    MARSSession.Instance.CheckCapabilities();
                    EditorUtility.SetDirty(this);
                }
            }

            SetMarkerSizeToTransformScale(markerLibrary, markerIndex);
        }

        void SetMarkerSizeToTransformScale(MarsMarkerLibrary markerLib, int markerIndex)
        {
            var transformScale = m_SynthesizedMarkerId.transform.localScale;
            if (m_LastSyncedTransformScale == transformScale)
                return;

            if (markerLib != null && markerIndex != ImageMarkerEditorUtils.UnselectedMarkerIndex)
            {
                var correctedScale = new Vector3(
                    transformScale.x > MarkerConstants.MinimumPhysicalMarkerSizeWidthInMeters ?
                        transformScale.x :
                        MarkerConstants.MinimumPhysicalMarkerSizeWidthInMeters,
                    transformScale.y > MarkerConstants.MinimumPhysicalMarkerSizeWidthInMeters ?
                        transformScale.y :
                        MarkerConstants.MinimumPhysicalMarkerSizeWidthInMeters,
                    transformScale.z > MarkerConstants.MinimumPhysicalMarkerSizeHeightInMeters ?
                        transformScale.z :
                        MarkerConstants.MinimumPhysicalMarkerSizeHeightInMeters);
                m_SynthesizedMarkerId.transform.localScale = correctedScale;

                markerLib.SetSize(markerIndex, new Vector2(correctedScale.x, correctedScale.z));
                m_MarkerDefinitionSelectorDrawer.UpdateMarkerLibrarySerializedObject();
            }

            m_LastSyncedTransformScale = transformScale;
        }

        static void HideRenderingAndSyntheticComponents(GameObject g)
        {
            SetHideFlags<MeshCollider>(g, HideFlags.HideInInspector);
            SetHideFlags<MeshFilter>(g, HideFlags.HideInInspector);
            var meshRenderer = g.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.hideFlags = HideFlags.HideInInspector;
                foreach (var material in meshRenderer.sharedMaterials)
                {
                    if (material != null)
                        material.hideFlags = HideFlags.HideInInspector;
                }
            }

            SetHideFlags<SynthesizedPose>(g, HideFlags.HideInInspector);
            SetHideFlags<SimulatedObject>(g, HideFlags.HideInInspector);
            SetHideFlags<SynthesizedBounds2D>(g, HideFlags.HideInInspector);
            SetHideFlags<SynthesizedMarker>(g, HideFlags.HideInInspector);
        }

        static void SetHideFlags<T>(GameObject g, HideFlags hideFlags) where T : Component
        {
            var component = g.GetComponent<T>();
            if (component != null)
                component.hideFlags = hideFlags;
        }
    }
}
