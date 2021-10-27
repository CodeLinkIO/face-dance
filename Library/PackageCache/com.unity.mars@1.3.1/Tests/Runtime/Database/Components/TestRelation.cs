using Unity.MARS.Conditions;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    abstract class TestRelation<TRange, TTrait> : NonBinaryRelation<TRange, TTrait>
    {
        protected static readonly TraitRequirement[] k_RequiredTraits;

        protected readonly TraitRequirement[] m_RequiredTraits = new TraitRequirement[2];

        public override TraitRequirement[] GetRequiredTraits() { return m_RequiredTraits; }

        public void SetChild1TraitName(string traitName) { m_RequiredTraits[0] = new TraitRequirement(traitName, typeof(TTrait)); }

        public void SetChild2TraitName(string traitName) { m_RequiredTraits[1] = new TraitRequirement(traitName, typeof(TTrait)); }
    }

}
