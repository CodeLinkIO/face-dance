using System;
using System.Collections.Generic;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Unity.MARS.Data
{
    /// <summary>
    ///     A MarsMarkerLibrary is a collection of MarsMarkerDefinition to search for in
    ///     the physical environment when marker tracking is enabled.
    /// </summary>
    [CreateAssetMenu(fileName = "MarsMarkerLibrary", menuName = "MARS/Marker Library", order = 1001)]
    [MovedFrom("Unity.MARS")]
    public class MarsMarkerLibrary : ScriptableObject, IMRMarkerLibrary
    {
        const string k_DefaultMarkerDefinitionLabel = "No Label";
        public static string DefaultMarkerDefinitionLabel => k_DefaultMarkerDefinitionLabel;

        [SerializeField]
        List<MarsMarkerDefinition> m_Markers = new List<MarsMarkerDefinition>();

        /// <summary>
        ///     The number of markers in the library.
        /// </summary>
        public int Count => m_Markers.Count;

        /// <summary>
        ///     Get an marker by index.
        /// </summary>
        /// <param name="index">The index of the marker in the library. Must be between 0 and count - 1.</param>
        /// <returns>The MarsMarkerDefinition at <paramref name="index" />.</returns>
        /// <exception cref="System.IndexOutOfRangeException">
        ///     Thrown if <paramref name="index" /> is not between 0 and
        ///     <see cref="Count" /><c> - 1</c>.
        /// </exception>
        public MarsMarkerDefinition this[int index]
        {
            get
            {
                if (Count == 0)
                    throw new IndexOutOfRangeException("The MarsMarkerLibrary is empty; cannot index into it.");

                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException(string.Format("{0} is out of range. 'index' must be between 0 and {1}", index, Count - 1));

                return m_Markers[index];
            }
        }

        /// <summary>
        ///     Gets an enumerator which can be used to iterate over the markers in this library.
        /// </summary>
        /// <example>
        ///     This examples iterates over the MarsMarkerDefinitions contained in the library.
        ///     <code>
        /// var markerLibrary = ...
        /// foreach (var markerDefinition in markerLibrary)
        ///     Debug.LogFormat("Marker label: {0}", markerDefinition.Label);
        /// </code>
        /// </example>
        /// <returns>An <c>IEnumerator</c> which can be used to iterate over the markers in the library.</returns>
        public List<MarsMarkerDefinition>.Enumerator GetEnumerator()
        {
            return m_Markers.GetEnumerator();
        }

        /// <summary>
        ///     Get the index of MarsMarkerDefinition in the marker library.
        /// </summary>
        /// <param name="markerDefinition">The MarsMarkerDefinition to find.</param>
        /// <returns>The zero-based index of the MarsMarkerDefinition, or -1 if not found.</returns>
        public int IndexOf(MarsMarkerDefinition markerDefinition)
        {
            return m_Markers.IndexOf(markerDefinition);
        }

        /// <summary>
        ///     Creates an empty <c>MarsMarkerDefinition</c> and adds it to the library. The new
        ///     marker is inserted at the end of the list of markers.
        /// </summary>
        /// <returns>The MarsMarkerDefinition created and added.</returns>
        public MarsMarkerDefinition CreateAndAdd()
        {
            var newMarker = new MarsMarkerDefinition
            {
                MarkerDefinitionId = SerializableGuid.empty,
                // By default marker has a size of a postcard
                Size = new Vector2(MarkerConstants.PostcardWidthInMeters, MarkerConstants.PostcardHeightInMeters),
                SpecifySize = true,
                Label = k_DefaultMarkerDefinitionLabel
            };

            m_Markers.Add(newMarker);

#if UNITY_EDITOR
            // Save assets to force sync with provider library and set valid GUID on new MarsMarkerDefinition
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
#endif

            return newMarker;
        }

        public void SetTexture(int index, Texture2D texture)
        {
            var marker = m_Markers[index];
            marker.Texture = texture;
            m_Markers[index] = marker;
        }

        public void SetSpecifySize(int index, bool specifySize)
        {
            var marker = m_Markers[index];
            marker.SpecifySize = specifySize;
            m_Markers[index] = marker;
        }

        public void SetSize(int index, Vector2 size)
        {
            var marker = m_Markers[index];
            marker.Size = size;
            m_Markers[index] = marker;
        }

        public void SetLabel(int index, string markerLabel)
        {
            var marker = m_Markers[index];
            marker.Label = markerLabel;
            m_Markers[index] = marker;
        }

        public void SetGuid(int index, Guid markerGuid)
        {
            var marker = m_Markers[index];
            marker.MarkerDefinitionId = SerializableGuidUtil.Create(markerGuid);
            m_Markers[index] = marker;
        }

        public void RemoveAt(int index)
        {
            m_Markers.RemoveAt(index);

#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }

        public void SaveMarkerLibrary()
        {
#if UNITY_EDITOR
            AssetDatabase.SaveAssets();
#endif
        }
    }
}
