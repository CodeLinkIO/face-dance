using System;
using Unity.MARS.Data;
using UnityEditor;
using UnityEngine;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS;

namespace Unity.MARS
{
    /// <summary>
    /// Common utility methods for inspecting <c>MarsMarkerLibrary</c> and image markers in the editor.
    /// </summary>
    static class ImageMarkerEditorUtils
    {
        class Styles
        {
            public readonly GUIContent AddImageMarkerButton;
            public readonly GUIContent RemoveImageMarkerButton;
            public readonly GUIContent SelectLoadedImageMarkerLibrary;
            public readonly GUIContent TopMarkerLibraryContent;
            public readonly GUIContent MarkerSize;
            public readonly GUIContent createLibraryButtonContent;

            public readonly GUIStyle createLibraryButtonStyle;

            public const int SpaceBetweenImagesHorizontal = 10;
            public const int SpaceBetweenImagesVertical = 20;
            public const int ImageBrowserHeight = 200;
            public const int EdgeSubtraction = 35;
            public const int ImageMarkersSize = 57;
            public const int AddRemoveButtonSize = 30;

            public const int offsetSelectLoadedLibButton = 5;
            public const int selectLoadedLibButtonWidth = 19;
            public const int selectLoadedLibButtonHeight = 14;

            public const string libraryFilePanelTitle = "Save new image marker library";
            public const string libraryFilePanelDefaultName = "ImageMarkerLibrary";
            public const string libraryFilePanelExtension = "asset";

            internal Styles()
            {
                AddImageMarkerButton = EditorGUIUtility.IconContent("Toolbar Plus",
                    "Adds an image marker to the current marker library loaded for this scene.");
                RemoveImageMarkerButton = EditorGUIUtility.IconContent("Toolbar Minus",
                    "Removes the current selected image marker from the current marker library loaded.");
                SelectLoadedImageMarkerLibrary = new GUIContent("...",
                    "Selects the current image marker library loaded for this scene.");
                TopMarkerLibraryContent = new GUIContent("  Marker Library",
                    "Go to the image marker library loaded for this scene.");
                MarkerSize = new GUIContent("Size (meters)",
                    "Physical size in meters the image marker would have.");

                createLibraryButtonContent = new GUIContent("Create Library",
                    "Creates an image marker library in your project to fill with image markers.");

                createLibraryButtonStyle = new GUIStyle(GUI.skin.button);
                createLibraryButtonStyle.fontSize = 10;
            }
        }

        internal const int UnselectedMarkerIndex = -1;

        const string k_NoMarkerLibraryModuleFound = "Marker Library Module not Loaded.\n" +
                                                       "Cannot provide more information on Marker Definition";

        const string k_NoCurrentMarkerLibraryAssigned = "No marker library assigned in this scene.\n" +
                                                        "On the MARS Session, select an existing library or create a " +
                                                        "new one via Assets -> Create -> MARS -> Marker Library.";

        static bool s_FlagSelectingMarker;
        static Styles s_Styles;

        static Styles styles => s_Styles ?? (s_Styles = new Styles());

        internal static event Action<string, Vector2> ImageMarkerSizeUpdate;

        /// <summary>
        /// Draw info contents (texture thumbnail, marker tag and size) for an image marker inside a library
        /// </summary>
        /// <param name="markerDefinitionProperty">The marker definition serialized property</param>
        /// <param name="markerSizeOptionIndex">Selected option for pre-set physical sizes</param>
        /// <returns>The current marker sized option index</returns>
        public static int DrawImageMarkerInfoContentsAtIndex(SerializedProperty markerDefinitionProperty,
            int markerSizeOptionIndex)
        {
            const string texturePropName = "m_Texture";
            const string labelPropName = "m_Label";
            const string sizePropName = "m_Size";

            var markerTextureProperty = markerDefinitionProperty.FindPropertyRelative(texturePropName);
            var labelProperty = markerDefinitionProperty.FindPropertyRelative(labelPropName);
            var sizeProperty = markerDefinitionProperty.FindPropertyRelative(sizePropName);


            using (new EditorGUILayout.VerticalScope())
            {
                using (var check = new EditorGUI.ChangeCheckScope())
                {
                    EditorGUILayout.PropertyField(markerTextureProperty);
                    EditorGUILayout.PropertyField(labelProperty);
                    var newSizeIndex = EditorGUILayout.Popup(styles.MarkerSize, markerSizeOptionIndex,
                        MarkerConstants.MarkerSizeOptions);

                    if (newSizeIndex != 0 && newSizeIndex != markerSizeOptionIndex)
                    {
                        markerSizeOptionIndex = newSizeIndex;
                        sizeProperty.vector2Value = MarkerConstants.MarkerSizeOptionsValuesInMeters[markerSizeOptionIndex];
                    }

                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(sizeProperty, new GUIContent(string.Empty, sizeProperty.tooltip));
                    EditorGUI.indentLevel--;

                    if (check.changed)
                    {
                        var sizeValue = sizeProperty.vector2Value;
                        sizeValue = new Vector2(
                            Mathf.Max(MarkerConstants.MinimumPhysicalMarkerSizeWidthInMeters, sizeValue.x),
                            Mathf.Max(MarkerConstants.MinimumPhysicalMarkerSizeHeightInMeters, sizeValue.y));
                        sizeProperty.vector2Value = sizeValue;

                        markerSizeOptionIndex = MarkerConstants.GetSelectedMarsMarkerSizeOption(sizeValue);

                        ImageMarkerSizeUpdate?.Invoke(BuildMarkerId(markerDefinitionProperty), sizeValue);
                    }
                }
            }

            return markerSizeOptionIndex;
        }

        static string BuildMarkerId(SerializedProperty markerDefinitionProperty)
        {
            const string k_GuidLowPropName = "m_MarkerDefinitionId.m_GuidLow";
            const string k_GuidHighPropName = "m_MarkerDefinitionId.m_GuidHigh";

            var guidLow = (ulong)markerDefinitionProperty.FindPropertyRelative(k_GuidLowPropName).longValue;
            var guidHigh = (ulong)markerDefinitionProperty.FindPropertyRelative(k_GuidHighPropName).longValue;
            var guidComp = XRTools.Utils.GuidUtil.Compose(guidLow, guidHigh);

            return guidComp.ToString();
        }

        static void ProcessDragAndDropTexturesToMarkerConditionInspector(Event currentEvent,
            MarsMarkerLibrary currentMarkerLib)
        {
            if (currentEvent.type == EventType.DragUpdated)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
                currentEvent.Use();
            }
            else if (currentEvent.type == EventType.DragPerform)
            {
                Undo.RecordObject(currentMarkerLib, "Drag images to marker library");
                for (var i = 0; i < DragAndDrop.objectReferences.Length; i++)
                {
                    var draggedTexture = DragAndDrop.objectReferences[i] as Texture2D;
                    if (draggedTexture != null)
                    {
                        currentMarkerLib.CreateAndAdd();

                        EditorUtility.SetDirty(currentMarkerLib);
                        currentMarkerLib.SaveMarkerLibrary();

                        currentMarkerLib.SetGuid(currentMarkerLib.Count - 1, Guid.NewGuid());
                        currentMarkerLib.SetTexture(currentMarkerLib.Count - 1, draggedTexture);
                    }
                }

                currentEvent.Use();
            }
        }

        /// <summary>
        /// UI to add a new image marker to the marker library
        /// </summary>
        /// <param name="markerLibrary">The marker library currently being edited</param>
        static void DrawAddImageMarkerButton(MarsMarkerLibrary markerLibrary)
        {
            const int pickerID = 0xC0FFEE;
            const string objectSelectorClosed = "ObjectSelectorClosed";

            if (GUILayout.Button(styles.AddImageMarkerButton, MarsEditorGUI.InternalEditorStyles.FooterButtonStyle,
                GUILayout.Width(Styles.AddRemoveButtonSize), GUILayout.Height(Styles.AddRemoveButtonSize)))
            {
                EditorGUIUtility.ShowObjectPicker<Texture2D>(null, false, "", pickerID);
                s_FlagSelectingMarker = true;
            }

            if (Event.current.commandName == objectSelectorClosed &&
                EditorGUIUtility.GetObjectPickerControlID() == pickerID && s_FlagSelectingMarker)
            {
                var selectedTexture = EditorGUIUtility.GetObjectPickerObject() as Texture2D;

                const string addEmptyImage = "Add an empty image marker";
                Undo.RecordObject(markerLibrary, addEmptyImage);

                markerLibrary.CreateAndAdd();

                markerLibrary.SetGuid(markerLibrary.Count - 1, Guid.NewGuid());
                markerLibrary.SetTexture(markerLibrary.Count - 1, selectedTexture);

                EditorUtility.SetDirty(markerLibrary);
                markerLibrary.SaveMarkerLibrary();
                s_FlagSelectingMarker = false;
            }
        }

        /// <summary>
        /// UI to remove the currently selected image marker from the library
        /// </summary>
        /// <param name="selectedImageMarkerIndex">The index of the selected image marker in the marker library.</param>
        /// <param name="markerLibrary">The marker library currently being edited</param>
        /// <returns><c>True</c> if image was removed</returns>
        static bool DrawRemoveImageMarkerButton(int selectedImageMarkerIndex, MarsMarkerLibrary markerLibrary)
        {
            using (new EditorGUI.DisabledScope(markerLibrary.Count <= 0 ||
                selectedImageMarkerIndex == UnselectedMarkerIndex))
            {
                if (GUILayout.Button(styles.RemoveImageMarkerButton, MarsEditorGUI.InternalEditorStyles.FooterButtonStyle,
                GUILayout.Width(Styles.AddRemoveButtonSize), GUILayout.Height(Styles.AddRemoveButtonSize)))
                {
                    const string removeSelectedImage = "Remove selected image marker";
                    Undo.RecordObject(markerLibrary, removeSelectedImage);

                    markerLibrary.RemoveAt(selectedImageMarkerIndex);

                    EditorUtility.SetDirty(markerLibrary);
                    markerLibrary.SaveMarkerLibrary();

                    return true;
                }
            }

            return false;
        }

        static void DrawTopImageMarkerInspectorBox(Rect imageMarkerPos, float verticalBoxOffset,
            MarsMarkerLibrary markerLibrary)
        {
            var topImageMarkerBoxRect = new Rect(imageMarkerPos.x, imageMarkerPos.y - verticalBoxOffset,
                imageMarkerPos.width, verticalBoxOffset);

            GUI.Box(topImageMarkerBoxRect, styles.TopMarkerLibraryContent, MarsEditorGUI.Styles.TopMarkerLibraryStyle);

            var boxX = topImageMarkerBoxRect.x + GUI.skin.box.CalcSize(styles.TopMarkerLibraryContent).x;
            if (GUI.Button(new Rect(boxX, topImageMarkerBoxRect.y + Styles.offsetSelectLoadedLibButton,
                Styles.selectLoadedLibButtonWidth, Styles.selectLoadedLibButtonHeight), styles.SelectLoadedImageMarkerLibrary))
            {
                Selection.activeObject = markerLibrary;
            }
        }

        /// <summary>
        /// Draw image marker select selector toggle button.
        /// </summary>
        /// <param name="xPos">starting x position</param>
        /// <param name="yPos">starting y position</param>
        /// <param name="isActive">is the image marker currently selected</param>
        /// <param name="markerDefinition">marker definition to draw</param>
        /// <returns><c>True</c>> if the marker is selected.</returns>
        static bool DrawImageMarker(float xPos, float yPos, bool isActive, MarsMarkerDefinition markerDefinition)
        {
            var imageMarkerRect = new Rect(xPos, yPos, Styles.ImageMarkersSize, Styles.ImageMarkersSize);
            var markerSelectionRect = new Rect(imageMarkerRect.x - 2, imageMarkerRect.y - 2,
                imageMarkerRect.width + 4, imageMarkerRect.height + 2 + EditorGUIUtility.singleLineHeight);

            isActive = EditorGUI.Toggle(markerSelectionRect, isActive,  EditorStyles.objectFieldThumb);

            if (markerDefinition.Texture)
                GUI.DrawTexture(imageMarkerRect, markerDefinition.Texture);
            else
                EditorGUI.HelpBox(imageMarkerRect, "\n\n    None    ", MessageType.None);

            using (new EditorGUI.DisabledScope(markerDefinition.Label == MarsMarkerLibrary.DefaultMarkerDefinitionLabel))
            {
                GUI.Label(new Rect(xPos, yPos + Styles.ImageMarkersSize, Styles.ImageMarkersSize,
                    EditorGUIUtility.singleLineHeight), markerDefinition.Label, EditorStyles.wordWrappedLabel);
            }

            return isActive;
        }

        /// <summary>
        /// Draws an inspector that displays the marker library contents
        /// and allows for selection of one of the markers in the library.
        /// </summary>
        /// <param name="scrollPos">The scroll position of the view showing the marker library</param>
        /// <param name="markerLibrary">The marker library currently being edited</param>
        /// <param name="selectedImageMarkerIndex">The index of the selected image marker in the marker library.</param>
        /// <returns>Current selected image marker index.</returns>
        public static int DrawImageMarkerLibraryInspector(ref Vector2 scrollPos, MarsMarkerLibrary markerLibrary,
            int selectedImageMarkerIndex)
        {
            var imageMarkerInspectorWidth = EditorGUIUtility.currentViewWidth - Styles.EdgeSubtraction;
            GUILayout.Box(string.Empty, GUILayout.Height(Styles.ImageBrowserHeight),
                GUILayout.Width(imageMarkerInspectorWidth));
            var scrollAreaPosRect = GUILayoutUtility.GetLastRect();

            // +4 space to fit buttons on top if img marker lib box
            var verticalBoxOffset = EditorGUIUtility.singleLineHeight + 4;
            scrollAreaPosRect = new Rect(scrollAreaPosRect.x, scrollAreaPosRect.y + verticalBoxOffset,
                scrollAreaPosRect.width - 1, scrollAreaPosRect.height - verticalBoxOffset - 1); // -1 to see box edges.

            var texturesToPlaceHorizontally = ((int)scrollAreaPosRect.width - Styles.EdgeSubtraction
                    + Styles.SpaceBetweenImagesHorizontal * 0.5f)
                / (Styles.ImageMarkersSize + Styles.SpaceBetweenImagesHorizontal);
            var texturesToPlaceVertically = Mathf.CeilToInt(markerLibrary.Count / texturesToPlaceHorizontally);

            var scrollViewHeight = texturesToPlaceVertically * (Styles.ImageMarkersSize
                + Styles.SpaceBetweenImagesHorizontal + EditorGUIUtility.singleLineHeight);
            var scrollAreaRect = new Rect(0, verticalBoxOffset,
                scrollAreaPosRect.width - Styles.EdgeSubtraction,
                scrollViewHeight + verticalBoxOffset - EditorGUIUtility.singleLineHeight);

            var offsetX = (((scrollAreaRect.width + Styles.SpaceBetweenImagesHorizontal * 0.5f)
                / (Styles.ImageMarkersSize + Styles.SpaceBetweenImagesHorizontal)) / texturesToPlaceHorizontally) - 1;

            DrawTopImageMarkerInspectorBox(scrollAreaPosRect, verticalBoxOffset, markerLibrary);

            using (var scrollScope = new GUI.ScrollViewScope(scrollAreaPosRect, scrollPos,
                scrollAreaRect, false, true))
            {
                scrollPos = scrollScope.scrollPosition;
                var currentEvent = Event.current;

                var counter = 0;
                for (var j = 0; j < texturesToPlaceVertically; j++)
                {
                    for (var i = 0; i < texturesToPlaceHorizontally; i++)
                    {
                        var xPos = (Styles.SpaceBetweenImagesHorizontal + i *
                            (Styles.ImageMarkersSize + Styles.SpaceBetweenImagesHorizontal))
                            + (offsetX * scrollAreaRect.width * 0.5f);
                        var yPos = EditorGUIUtility.singleLineHeight
                            + (Styles.SpaceBetweenImagesVertical * 0.5f + j
                            * (Styles.ImageMarkersSize + Styles.SpaceBetweenImagesVertical));

                        if (counter < markerLibrary.Count)
                        {
                            var isActive = counter == selectedImageMarkerIndex;
                            var markerDefinition = markerLibrary[counter];
                            if (DrawImageMarker(xPos, yPos, isActive, markerDefinition))
                            {
                                selectedImageMarkerIndex = counter;

                                if (markerLibrary[counter].MarkerId == Guid.Empty)
                                    Debug.LogError("Marker library should be rebuilt since it contains empty guid.");
                            }
                        }

                        counter++;
                    }
                }

                // Process here since we don't care if user drag/drops somewhere outside of img marker library box
                ProcessDragAndDropTexturesToMarkerConditionInspector(
                    currentEvent,
                    markerLibrary);
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Space(imageMarkerInspectorWidth - Styles.AddRemoveButtonSize * 2);
                DrawAddImageMarkerButton(markerLibrary);
                if (DrawRemoveImageMarkerButton(selectedImageMarkerIndex, markerLibrary))
                {
                    selectedImageMarkerIndex = UnselectedMarkerIndex;
                }
            }

            return selectedImageMarkerIndex;
        }

        /// <summary>
        /// Find the current selected image marker index from the serializable guid string value.
        /// </summary>
        /// <param name="markerLibrary">The marker library currently in use.</param>
        /// <param name="serializableGuidStringValue">The string value of the serializable guid for the image marker.</param>
        /// <returns>Returns current selected image marker. If none exists the <c>UnselectedMarkerIndex</c> is returned.</returns>
        public static int CurrentSelectedImageMarkerIndex(MarsMarkerLibrary markerLibrary, string serializableGuidStringValue)
        {
            if (markerLibrary == null)
                return UnselectedMarkerIndex;

            for (var i = 0; i < markerLibrary.Count; i++)
            {
                if (serializableGuidStringValue == markerLibrary[i].MarkerId.ToString())
                    return i;
            }

            return UnselectedMarkerIndex;
        }

        /// <summary>
        /// Get the <c>MarsMarkerLibrary</c> assigned in the current <c>MARSSession</c>
        /// </summary>
        /// <returns>Returns the currently assigned <c>MarsMarkerLibrary</c> on the active <c>MARSSession</c>,
        /// <c>null</c> if none is found.</returns>
        public static MarsMarkerLibrary GetSessionMarkerLibrary()
        {
            var moduleLoader = ModuleLoaderCore.instance;
            if (moduleLoader == null)
                return null;

            var markerLibraryModule = ModuleLoaderCore.instance.GetModule<MARSMarkerLibraryModule>();
            if (markerLibraryModule == null)
            {
                EditorGUILayout.HelpBox(k_NoMarkerLibraryModuleFound, MessageType.Info);
                return null;
            }

            // Set here in case we have several inspectors and user removes marker library reference
            // from MARSSession while visualizing
            var marsSession = MARSSession.Instance;
            if (marsSession == null)
                return null;

            var currentMarkerLib = marsSession.MarkerLibrary;
            if (currentMarkerLib == null)
            {
                EditorGUILayout.HelpBox(k_NoCurrentMarkerLibraryAssigned, MessageType.Info);
                if (GUILayout.Button(styles.createLibraryButtonContent, styles.createLibraryButtonStyle))
                {
                    var createdMarkerLibrary = ScriptableObject.CreateInstance<MarsMarkerLibrary>();
                    
                    var createdMarkerLibraryPath = EditorUtility.SaveFilePanelInProject(
                        Styles.libraryFilePanelTitle, Styles.libraryFilePanelDefaultName, Styles.libraryFilePanelExtension, "");

                    if (createdMarkerLibraryPath.Length != 0)
                    {
                        AssetDatabase.CreateAsset(createdMarkerLibrary, createdMarkerLibraryPath);
                        AssetDatabase.SaveAssets();
                        
                        SerializedObject marsSessionSerializedObj = new SerializedObject(marsSession);
                        SerializedProperty markerLibraryProperty = marsSessionSerializedObj.FindProperty("m_MarkerLibrary");

                        markerLibraryProperty.objectReferenceValue = createdMarkerLibrary;
                        marsSessionSerializedObj.ApplyModifiedProperties();
                    }
                }
            }

            return currentMarkerLib;
        }
    }
}
