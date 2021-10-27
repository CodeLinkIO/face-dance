using Unity.MARS.Simulation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// Base representation of a single property in a Synthesized MARS Object
    /// Most often you'll want to inherit from SynthesizedTrait&gt;T&lt; instead
    /// </summary>
    [MovedFrom("Unity.MARS.Data")]
    public abstract class SynthesizedTrait : MonoBehaviour, ISimulatable, ISynthesizedData
    {
        /// <summary>
        /// Marks this as having FI performed by a SyntheticObject
        /// so we don't re-run FI if a user toggles a trait dynamically
        /// multiple times.
        /// </summary>
        internal bool HasFunctionalityInjected;

        public abstract string TraitName { get; }

        /// <summary>
        /// The associated SynthesizedObject
        /// </summary>
        public SynthesizedObject SynthesizedObject { get; private set; }

        /// <summary>
        /// Should this trait update when its transform does?
        /// </summary>
        public abstract bool UpdateWithTransform { get; }

        /// <summary>
        /// True if the value for this trait is valid
        /// </summary>
        public virtual bool HasValidValue => true;

        /// <summary>
        /// Called when the SynthesizedObject around this trait is being added
        /// </summary>
        /// <param name="dataID">The entity that will hold all of the synthesized data</param>
        public abstract void AddTrait(int dataID);

        /// <summary>
        /// Called when the SynthesizedObject around this trait is being updated
        /// </summary>
        /// <param name="dataID">The entity that will hold all of the synthesized data</param>
        public abstract void UpdateTrait(int dataID);

        /// <summary>
        /// Called when the SynthesizedObject around this trait is being removed
        /// </summary>
        /// <param name="dataID">The entity that holds this trait</param>
        public abstract void RemoveTrait(int dataID);

        /// <summary>
        /// Called by Unity when the object is first activated
        /// </summary>
        protected virtual void Awake()
        {
            if (SynthesizedObject == null)
                SynthesizedObject = GetComponent<SynthesizedObject>();
        }

        /// <summary>
        /// Called by Unity when the object is enabled
        /// </summary>
        protected virtual void OnEnable()
        {
            TryAdd();
        }

        /// <summary>
        /// Called by Unity when the object is disabled
        /// </summary>
        protected virtual void OnDisable()
        {
            TryRemove();
        }

        /// <summary>
        /// Try to add this trait to the associated SynthesizedObject
        /// </summary>
        /// <returns>True if the trait was added successfully</returns>
        public bool TryAdd()
        {
            return SynthesizedObject != null && SynthesizedObject.TryAddTrait(this);
        }

        /// <summary>
        /// Try to remove this trait from the associated SynthesizedObject
        /// </summary>
        /// <returns>True if the trait was removed successfully</returns>
        public bool TryRemove()
        {
            return SynthesizedObject != null && SynthesizedObject.TryRemoveTrait(this);
        }
    }

    /// <summary>
    /// Representation for a single typed property in a Synthesized MARS Object
    /// </summary>
    /// <typeparam name="T">The type of data being represented by this trait</typeparam>
    public abstract class SynthesizedTrait<T> : SynthesizedTrait, IProvidesTraits<T>
    {
        protected static readonly TraitDefinition[] k_ProvidedTraits = new TraitDefinition[1];

        /// <summary>
        /// Get the TraitDefinitions provided by this SynthesizedTrait
        /// </summary>
        /// <returns>The provided traits</returns>
        public TraitDefinition[] GetProvidedTraits()
        {
            if (k_ProvidedTraits[0] == default(TraitDefinition))
                k_ProvidedTraits[0] = new TraitDefinition(TraitName, typeof(T));

            return k_ProvidedTraits;
        }

        /// <summary>
        /// Calculates and retrieves the most up-to-date piece of data representing this trait
        /// </summary>
        /// <returns>The data for this trait</returns>
        public abstract T GetTraitData();

        /// <summary>
        /// Add this trait to the associated SynthesizedObject in the MARS database
        /// </summary>
        /// <param name="dataID">The data ID which has been assigned to the associated SynthesizedObject</param>
        public sealed override void AddTrait(int dataID)
        {
            // Get the trait data, insert it in this entity
            this.AddOrUpdateTrait(dataID, TraitName, GetTraitData());
        }

        /// <summary>
        /// Remove the data for this trait in the MARS database
        /// </summary>
        /// <param name="dataID">The data ID which has been assigned to the associated SynthesizedObject</param>
        public sealed override void UpdateTrait(int dataID)
        {
            // Get the trait data, insert it in this entity
            this.AddOrUpdateTrait(dataID, TraitName, GetTraitData());
        }

        /// <summary>
        /// Remove this trait from the associated SynthesizedObject in the MARS database
        /// </summary>
        /// <param name="dataID">The data ID which has been assigned to the associated SynthesizedObject</param>
        public sealed override void RemoveTrait(int dataID)
        {
            this.RemoveTrait(dataID, TraitName);
        }
    }
}
