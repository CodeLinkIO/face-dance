using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.MARS.MARSUtils;
using Unity.MARS.Query;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Unity.MARS.Data
{
    public interface IRequiresTraits
    {
        // Implementors of IRequiresTraits must include a static readonly field which contains the definitions of traits
        // this object requires, as defined below:
        // static readonly TraitRequirement[] k_RequiredTraits;

        /// <summary>
        /// Get the TraitRequirements that are required by this object
        /// </summary>
        /// <returns>The required traits</returns>
        TraitRequirement[] GetRequiredTraits();
    }

    /// <summary>
    /// Defines the interface for objects that require traits of the given type
    /// </summary>
    /// <typeparam name="T">Type of trait required</typeparam>
    public interface IRequiresTraits<T> : IRequiresTraits { }

    public delegate bool TryGetTraitValueDelegate<T>(int dataId, string traitName, out T value);
    public delegate bool TryGetAllTraitsWithSemanticTagDelegate<T>(string traitName, string tag, out Dictionary<int, T> values);
    public delegate void ForEachContextIdWithTraitDelegate<T>(string traitName, Action<int> action);

    public static class IRequiresTraitsMethods<T>
    {
        public static TryGetTraitValueDelegate<T> TryGetTraitValue { internal get; set; }
        public static TryGetAllTraitsWithSemanticTagDelegate<T> TryGetAllTraitsWithSemanticTag { internal get; set; }
        public static ForEachContextIdWithTraitDelegate<T> ForEachContextIdWithTrait { get; set; }
    }

    public static class IRequiresTraitsMethods
    {
        public const string StaticRequiredTraitsFieldName = "k_RequiredTraits";

        public const BindingFlags StaticRequiredTraitsBindingFlags =
            BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy;

        public static bool TryGetTraitValue<T>(this IRequiresTraits<T> obj, int dataID, string traitName,
            out T value)
        {
            return IRequiresTraitsMethods<T>.TryGetTraitValue(dataID, traitName, out value);
        }

        public static bool TryGetAllTraitsWithSemanticTag<T>(this IRequiresTraits<T> obj, string traitName,
            string tag, out Dictionary<int, T> values)
        {
            return IRequiresTraitsMethods<T>.TryGetAllTraitsWithSemanticTag(traitName, tag, out values);
        }

        public static void ForEachContextIdWithTrait<T>(this IRequiresTraits<T> obj, string traitName,
            Action<int> forEach)
        {
            IRequiresTraitsMethods<T>.ForEachContextIdWithTrait(traitName, forEach);
        }
    }

#if UNITY_EDITOR
    [InitializeOnLoad]
    static class IRequiresTraitsAnalyzer
    {
        static IRequiresTraitsAnalyzer()
        {
            var implementors = new List<Type>();
            typeof(IRequiresTraits).GetImplementationsOfInterface(implementors);

            foreach (var implementor in implementors)
            {
                CheckType(implementor);
            }
        }

        static void CheckType(Type type)
        {
            foreach (var inter in type.GetInterfaces())
            {
                // Semantic tag conditions have variable requirements so they don't need to include static requirements
                if (inter == typeof(ISemanticTagCondition))
                    return;
            }

            var requiredTraits = type.GetField(
                IRequiresTraitsMethods.StaticRequiredTraitsFieldName,
                IRequiresTraitsMethods.StaticRequiredTraitsBindingFlags);

            if (requiredTraits == null)
            {
                Debug.LogErrorFormat("Error implementing IRequiresTraits in class {0}. Missing required static readonly " +
                    "field {1}. See IRequiresTraits.cs for details",
                    type.Name,
                    IRequiresTraitsMethods.StaticRequiredTraitsFieldName);

                return;
            }

            if (!requiredTraits.IsInitOnly)
            {
                Debug.LogErrorFormat("Error implementing IRequiresTraits in class {0}. Required static field " +
                    "{1} must be readonly",
                    type.Name,
                    IRequiresTraitsMethods.StaticRequiredTraitsFieldName);

                return;
            }

            if (requiredTraits.FieldType != typeof(TraitRequirement[]))
            {
                Debug.LogErrorFormat("Error implementing IRequiresTraits in class {0}. Required static readonly field " +
                    "{1} must be of type TraitRequirement[]",
                    type.Name,
                    IRequiresTraitsMethods.StaticRequiredTraitsFieldName);
            }
        }
    }
#endif
}
