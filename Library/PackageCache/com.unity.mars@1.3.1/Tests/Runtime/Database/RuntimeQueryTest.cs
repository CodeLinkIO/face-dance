#if UNITY_EDITOR
using System;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    abstract class RuntimeQueryTest : MarsRuntimeTest
    {
        protected static readonly TraitDefinition[] k_ProvidedTraits = new TraitDefinition[0];

        public virtual TraitDefinition[] GetProvidedTraits()
        {
            return new TraitDefinition[0];
        }
    }
}
#endif
