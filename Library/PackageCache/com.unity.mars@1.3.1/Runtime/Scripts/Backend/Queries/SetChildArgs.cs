namespace Unity.MARS.Query
{
    public struct SetChildArgs
    {
        /// <summary>Is this child necessary to maintain the set after it has been initially matched?</summary>
        public bool required;

        /// <summary>
        /// The pre-constructed arguments for matching this child's conditions
        /// </summary>
        public TryBestMatchArguments tryBestMatchArgs;

        /// <summary>A list of traits required for this query to function</summary>
        public ProxyTraitRequirements TraitRequirements;

        public SetChildArgs(ProxyConditions conditions, ProxyTraitRequirements requirements = null) :
            this(conditions, Exclusivity.ReadOnly, true, requirements) { }

        public SetChildArgs(ProxyConditions conditions, Exclusivity exclusivity, bool required,
            ProxyTraitRequirements requirements = null)
        {
            this.required = required;
            tryBestMatchArgs = new TryBestMatchArguments(conditions, exclusivity);
            TraitRequirements = requirements;
        }
    }
}
