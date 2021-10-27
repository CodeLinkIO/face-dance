using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// Creates data for a semantic tag trait
    /// When added to a synthesized object, adds a semantic tag to its representation in the database
    /// </summary>
    [HelpURL(DocumentationConstants.SynthesizedSemanticTagDocs)]
    [MovedFrom("Unity.MARS.Data")]
    public class SynthesizedSemanticTag : SynthesizedTrait<bool>
    {
        [SerializeField]
        [Tooltip("The semantic tag to apply to the Synthesized Object")]
        string m_SemanticTag;

        /// <summary>
        /// Automatically changes the tag in the database when set.
        /// </summary>
        public string SemanticTag
        {
            get => m_SemanticTag;

            set
            {
                value = ValidateIfNeeded(value);

                if(HasValidValue)
                    TryRemove();

                m_SemanticTag = value;

                if (HasValidValue)
                    TryAdd();
            }
        }

        /// <summary>
        /// The trait which will be added to the associated SynthesizedObject
        /// </summary>
        public override string TraitName { get { return m_SemanticTag; } }

        /// <summary>
        /// Whether to update the synthesized data with this object's Transform
        /// </summary>
        public override bool UpdateWithTransform { get { return false; } }

        /// <summary>
        /// Overridden as null/empty values don't work with the database currently.
        /// </summary>
        public override bool HasValidValue => !string.IsNullOrEmpty(m_SemanticTag);

        void OnValidate()
        {
            m_SemanticTag = ValidateIfNeeded(m_SemanticTag);
        }

        static string ValidateIfNeeded(string semanticTag)
        {
            return !string.IsNullOrEmpty(semanticTag) ? semanticTag.ToLower() : semanticTag;
        }

        /// <summary>
        /// Get the trait data for this synthesized semantic tag
        /// </summary>
        /// <returns>The trait data</returns>
        public override bool GetTraitData() { return true; }
    }
}
