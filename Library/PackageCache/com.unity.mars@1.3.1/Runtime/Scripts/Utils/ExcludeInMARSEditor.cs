using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Attributes
{
    /// <summary>
    /// Attribute marks a class that will not be included in the MARS Entity in the inspector and not included in the Add MARS Component menu
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [MovedFrom("Unity.MARS")]
    public class ExcludeInMARSEditor : Attribute { }
}
