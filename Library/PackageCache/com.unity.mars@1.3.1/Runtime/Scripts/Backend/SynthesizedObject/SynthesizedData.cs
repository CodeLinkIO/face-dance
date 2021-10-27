namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// Interface for SynthesizedTrait and SynthesizedTrackable
    /// Handles dynamic runtime behavior for SynthesizedObject
    /// If used with a SimulatedObject, does nothing.
    /// </summary>
    public interface ISynthesizedData
    {
        /// <summary>
        /// The SynthesizedObject reference,
        /// if one is attached to the same GameObject
        /// </summary>
        SynthesizedObject SynthesizedObject { get; }

        /// <summary>
        /// Only returns false if the data represented has a
        /// null/invalid state and is in that null/invalid state
        /// </summary>
        bool HasValidValue { get; }

        /// <summary>
        /// Identifies the data being applied to the Synthesized Object
        /// </summary>
        string TraitName { get; }

        /// <summary>
        /// Attempts to add the data to a SyntheticObject,
        /// if one is attached to the same GameObject.
        /// </summary>
        /// <returns>True if adding the data successful,
        /// false on failure or redundant add.</returns>
        bool TryAdd();

        /// <summary>
        /// Attempts to add the data to a SyntheticObject,
        /// if one is attached to the same GameObject.
        /// </summary>
        /// <returns>True if removing the data successful,
        /// false on error or redundant remove.</returns>
        bool TryRemove();
    }
}
