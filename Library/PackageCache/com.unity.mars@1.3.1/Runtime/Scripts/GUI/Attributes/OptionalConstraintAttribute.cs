using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Attributes
{
    [MovedFrom("Unity.MARS")]
    public class OptionalConstraintAttribute : Attribute
    {
        public readonly string BoolPropertyName;

        public OptionalConstraintAttribute(string boolPropertyName) { BoolPropertyName = boolPropertyName; }
    }
}
