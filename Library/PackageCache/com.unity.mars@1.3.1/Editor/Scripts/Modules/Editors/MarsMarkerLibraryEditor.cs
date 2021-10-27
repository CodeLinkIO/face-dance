using System;
using Unity.MARS.Data;
using UnityEditor;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(MarsMarkerLibrary))]
    class MarsMarkerLibraryEditor : Editor
    {
        class Styles
        {
            public readonly string minimumMarkerDefinitionDimensionsStr =
                $"Dimensions must be at least {MarkerConstants.MinimumPhysicalMarkerSizeInCentimeters.x.ToString()}cm " +
                $"x {MarkerConstants.MinimumPhysicalMarkerSizeInCentimeters.y.ToString()}cm.";

            public readonly GUIContent removeButtonContent;
            public readonly GUIContent addButtonContent;

            public readonly GUIContent label;
            public readonly GUIContent specifySize;
            public readonly GUIContent sizePixels;
            public readonly GUIContent sizeMeters;

            internal Styles()
            {
                removeButtonContent = EditorGUIUtility.TrIconContent("clear", "| Remove this Marker Definition from the Database");

                addButtonContent = new GUIContent("Add Image", "Add a new Marker Definition to the Database");

                label = new GUIContent( "Label",
                    "The label of the reference image. This can useful for matching detected images with their reference image at runtime.");

                specifySize = new GUIContent( "Specify Size",
                    "If enabled, you can specify the physical dimensions of the image in meters. Some platforms require this.");

                sizePixels = new GUIContent( "Texture Size (pixels)",
                    "The texture dimensions, in pixels.");

                sizeMeters = new GUIContent( "Physical Size (meters)",
                    "The dimensions of the physical image, in meters.");
            }
        }

        const int k_CloseIconSize = 25;
        static Styles s_Styles;

        bool m_Changed;
        SerializedProperty m_MarkersProperty;

        static Styles styles => s_Styles ?? (s_Styles = new Styles());

        void OnEnable()
        {
            const string markersProp = "m_Markers";
            m_MarkersProperty = serializedObject.FindProperty(markersProp);
            Undo.undoRedoPerformed += OnUndoCalled;
        }

        void OnDisable()
        {
            Undo.undoRedoPerformed -= OnUndoCalled;

            // It is too expensive to save assets every time the GUI changed, so we do so in OnDisable if any
            // modifications have been made while the inspector is open
            // Delay call is needed to avoid crashing the editor
            if (m_Changed)
                EditorApplication.delayCall += AssetDatabase.SaveAssets;
        }

        void OnUndoCalled()
        {
            var library = (MarsMarkerLibrary) target;
            EditorUtility.SetDirty(library);
            library.SaveMarkerLibrary();
        }

        // Adapted from XRReferenceImageLibraryEditor.cs
        public override void OnInspectorGUI()
        {
            var library = (MarsMarkerLibrary)target;
            if (library == null)
                return;

            serializedObject.Update();

            using (var changed = new EditorGUI.ChangeCheckScope())
            {
                var indexToRemove = -1;
                for (var i = 0; i < m_MarkersProperty.arraySize; ++i)
                {
                    var shouldRemove = DrawMarkerDefinition(i);
                    if (shouldRemove)
                        indexToRemove = i;

                    EditorGUILayout.Separator();

                    if (i < m_MarkersProperty.arraySize - 1)
                        EditorGUILayout.LabelField(string.Empty, GUI.skin.horizontalSlider);
                }

                if (indexToRemove > -1)
                    m_MarkersProperty.DeleteArrayElementAtIndex(indexToRemove);

                m_Changed |= changed.changed;
            }

            if (GUILayout.Button(styles.addButtonContent))
            {
                Undo.RecordObject(target, "Add reference image");
                // CreateAndAdd calls AssetDatabase.SaveAssets so does not need to affect m_Changed
                library.CreateAndAdd();
            }

            serializedObject.ApplyModifiedProperties();
        }

        bool DrawMarkerDefinition(int index)
        {
            var library = target as MarsMarkerLibrary;
            if (library == null)
                return false;

            var referenceImage = library[index];
            var property = m_MarkersProperty.GetArrayElementAtIndex(index);

            const string textureProp = "m_Texture";
            const string labelProp = "m_Label";
            const string specifySizeProp = "m_SpecifySize";
            const string sizeProp = "m_Size";

            var textureProperty = property.FindPropertyRelative(textureProp);
            var labelProperty = property.FindPropertyRelative(labelProp);

            var specifySizeProperty = property.FindPropertyRelative(specifySizeProp);
            var sizeProperty = property.FindPropertyRelative(sizeProp);

            var texture = textureProperty.objectReferenceValue as Texture2D;

            bool shouldRemove;
            bool wasTextureUpdated;

            using (new EditorGUILayout.HorizontalScope())
            {
                using (var textureCheck = new EditorGUI.ChangeCheckScope())
                {
                    texture = TextureField(texture);
                    wasTextureUpdated = textureCheck.changed;
                }

                shouldRemove = GUILayout.Button(styles.removeButtonContent, GUILayout.Width(k_CloseIconSize), GUILayout.Height(k_CloseIconSize), GUILayout.ExpandWidth(false));
            }

            EditorGUILayout.PropertyField(labelProperty, styles.label);

            EditorGUILayout.PropertyField(specifySizeProperty, styles.specifySize);

            if (specifySizeProperty.boolValue)
            {
                using (new EditorGUI.IndentLevelScope())
                {
                    using (new EditorGUI.DisabledScope(true))
                    {
                        var imageDimensions = texture == null ? Vector2Int.zero :
                            new Vector2Int(texture.width, texture.height);
                        EditorGUILayout.Vector2IntField(styles.sizePixels, imageDimensions);
                    }

                    using (var changeCheck = new EditorGUI.ChangeCheckScope())
                    {
                        EditorGUILayout.PropertyField(sizeProperty, styles.sizeMeters);

                        // Prevent dimensions from going below zero.
                        var size = new Vector2(
                            Mathf.Max(MarkerConstants.MinimumPhysicalMarkerSizeWidthInMeters,
                                sizeProperty.vector2Value.x),
                            Mathf.Max(MarkerConstants.MinimumPhysicalMarkerSizeHeightInMeters,
                                sizeProperty.vector2Value.y));

                        if (sizeProperty.vector2Value.x < 0f || sizeProperty.vector2Value.y < 0f)
                            sizeProperty.vector2Value = size;

                        if (changeCheck.changed)
                        {
                            if (texture == null)
                            {
                                // If texture is null, then we just set whatever the user specifies
                                sizeProperty.vector2Value = size;
                            }
                            else
                            {
                                // Otherwise, maintain the aspect ratio
                                var delta = referenceImage.Size - size;
                                delta = new Vector2(Mathf.Abs(delta.x), Mathf.Abs(delta.y));

                                // Determine which dimension has changed and compute the unchanged dimension
                                if (delta.x > delta.y)
                                    sizeProperty.vector2Value = SizeFromWidth(texture, size);
                                else if (delta.y > 0f)
                                    sizeProperty.vector2Value = SizeFromHeight(texture, size);
                            }
                        }
                        else if (wasTextureUpdated && texture != null)
                        {
                            // If the texture changed, re-compute width / height
                            sizeProperty.vector2Value = Math.Abs(size.x) < float.Epsilon ? SizeFromHeight(texture, size)
                                : SizeFromWidth(texture, size);
                        }
                    }

                    if (sizeProperty.vector2Value.x <= MarkerConstants.MinimumPhysicalMarkerSizeWidthInMeters ||
                        sizeProperty.vector2Value.y <= MarkerConstants.MinimumPhysicalMarkerSizeHeightInMeters)
                        EditorGUILayout.HelpBox(styles.minimumMarkerDefinitionDimensionsStr,
                            MessageType.Warning);
                }
            }

            using (new EditorGUI.DisabledScope(texture == null))
            {
                using (var changeCheck = new EditorGUI.ChangeCheckScope())
                {
                    if (changeCheck.changed || wasTextureUpdated)
                    {
                        if (string.IsNullOrEmpty(labelProperty.stringValue) && texture != null)
                            labelProperty.stringValue = texture.name;

                        // Apply properties for anything that may have been modified, otherwise
                        // the texture change may be overwritten.
                        serializedObject.ApplyModifiedProperties();

                        Undo.RecordObject(target, "Update reference image texture");
                        library.SetTexture(index, texture);

                        EditorUtility.SetDirty(target);
                        library.SaveMarkerLibrary();
                    }
                }
            }

            return shouldRemove;
        }

        /// <summary>
        /// Computes a new size using the width and aspect ratio from the Texture2D.
        /// Width remains the same as before; height is recalculated.
        /// </summary>
        static Vector2 SizeFromWidth(Texture2D texture, Vector2 size)
        {
            var textureSize = new Vector2Int(texture.width, texture.height);
            return new Vector2(size.x, size.x * textureSize.y / textureSize.x);
        }

        /// <summary>
        /// Computes a new size using the height and aspect ratio from the Texture2D.
        /// Height remains the same as before; width is recalculated.
        /// </summary>
        static Vector2 SizeFromHeight(Texture2D texture, Vector2 size)
        {
            var textureSize = new Vector2Int(texture.width, texture.height);
            return new Vector2(size.y * textureSize.x / textureSize.y, size.y);
        }

        static Texture2D TextureField(Texture2D texture)
        {
            const int maxSideLength = 64;
            var width = maxSideLength;
            var height = maxSideLength;

            if (texture != null)
            {
                var textureSize = new Vector2Int(texture.width, texture.height);

                if (textureSize.x > textureSize.y)
                    height = width * textureSize.y / textureSize.x;
                else
                    width = height * textureSize.x / textureSize.y;
            }

            return (Texture2D) EditorGUILayout.ObjectField(texture, typeof(Texture2D), true,
                GUILayout.Width(width), GUILayout.Height(height));
        }
    }
}
