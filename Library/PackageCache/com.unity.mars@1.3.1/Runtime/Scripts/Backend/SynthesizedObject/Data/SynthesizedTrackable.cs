using Unity.MARS.Simulation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// Base representation of a single data type in a Synthesized MARS data
    /// Most often you'll want to inherit from SynthesizedTrackable&lt;T&gt; instead
    /// </summary>
    [MovedFrom("Unity.MARS.Data")]
    public abstract class SynthesizedTrackable : MonoBehaviour, ISimulatable, ISynthesizedData
    {
        /// <summary>
        /// The trait name associated with this SynthesizedTrackable
        /// </summary>
        public abstract string TraitName { get; }

        /// <summary>
        /// The SynthesizedObject associated with this SynthesizedTrackable
        /// </summary>
        public SynthesizedObject SynthesizedObject { get; private set; }

        /// <summary>
        /// True if the data for this SynthesizedTrackable is valid
        /// </summary>
        public virtual bool HasValidValue => true;

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
        /// Called when the SynthesizedTrackable is used for the first time by a SynthesizedObject
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Called when the SynthesizedTrackable data is cleared by a SynthesizedObject
        /// </summary>
        public virtual void Terminate() { }

        /// <summary>
        /// Called when the SynthesizedObject is appending this data to an existing object
        /// </summary>
        /// <param name="dataID">The entity that will hold the synthesized data</param>
        public abstract void AddSynthData(int dataID);

        /// <summary>
        /// Called when the SynthesizedObject around this data is being updated
        /// </summary>
        public abstract void UpdateSynthData();

        /// <summary>
        /// Called when the SynthesizedObject around this data is being removed
        /// </summary>
        /// <param name="dataID">The entity that holds this data</param>
        public abstract void RemoveSynthData(int dataID);

        /// <summary>
        /// Try to add this trait to the associated SynthesizedObject
        /// </summary>
        /// <returns>True if the trait was added successfully</returns>
        public bool TryAdd()
        {
            return SynthesizedObject != null && SynthesizedObject.TryAddTrackable(this);
        }

        /// <summary>
        /// Try to remove this trait from the associated SynthesizedObject
        /// </summary>
        /// <returns>True if the trait was removed successfully</returns>
        public bool TryRemove()
        {
            return SynthesizedObject != null && SynthesizedObject.TryRemoveTrackable(this);
        }
    }

    /// <summary>
    /// Representation for a single typed property in a piece of Synthesized MARS data
    /// </summary>
    /// <typeparam name="T">The type of data being represented by this trait</typeparam>
    public abstract class SynthesizedTrackable<T> : SynthesizedTrackable, IProvidesTraits<bool>,
        IUsesMARSTrackableData<T> where T : IMRTrackable
    {
        readonly TraitDefinition[] k_ProvidedTraits = new TraitDefinition[1];

        /// <summary>
        /// Calculates and retrieves the most up-to-date piece of data representing this trackable object
        /// </summary>
        /// <returns>The data representing this trackable object</returns>
        public abstract T GetData();

        /// <summary>
        /// Add the data for this SynthesizedTrackable to the MARS database
        /// </summary>
        /// <param name="dataID">The data ID associated with this trackable object</param>
        public sealed override void AddSynthData(int dataID)
        {
            Initialize();
            SafeAddTrackableData(dataID);
            this.AddOrUpdateTrait(dataID, TraitName, true);
        }

        void SafeAddTrackableData(int dataID)
        {
            try
            {
                this.AddData(dataID, GetData());
            }
            catch (System.ArgumentException)
            {
                // argument exception means it's already added - if so, that's ok, just update
                UpdateSynthData();
            }
        }

        /// <summary>
        /// Update the data in the MARS database associated with this trackable object
        /// </summary>
        public sealed override void UpdateSynthData()
        {
            this.AddOrUpdateData(GetData());
        }

        /// <summary>
        /// Remove the data for this SynthesizedTrackable from the MARS database
        /// </summary>
        /// <param name="dataID">The data ID associated with this trackable object</param>
        public sealed override void RemoveSynthData(int dataID)
        {
            this.RemoveData(GetData());
            this.RemoveTrait(dataID, TraitName);
            Terminate();
        }

        /// <summary>
        /// Get the traits provided by this SynthesizedTrackable
        /// </summary>
        /// <returns>The provided traits</returns>
        public virtual TraitDefinition[] GetProvidedTraits()
        {
            if (k_ProvidedTraits[0] == default(TraitDefinition))
                k_ProvidedTraits[0] = new TraitDefinition(TraitName, typeof(T));

            return k_ProvidedTraits;
        }
    }
}
