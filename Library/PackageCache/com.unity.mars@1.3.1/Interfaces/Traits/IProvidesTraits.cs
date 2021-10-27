using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.MARS.MARSUtils;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Unity.MARS.Data
{
    public interface IProvidesTraits
    {
        // Implementors of IProvidesTraits must include a static readonly field which contains the definitions of traits this
        // provider will insert into the database, as defined below:
        // static readonly TraitDefinition[] k_ProvidedTraits;

        TraitDefinition[] GetProvidedTraits();
    }

    /// <summary>
    /// Defines the interface for providers of traits of the given type
    /// </summary>
    /// <typeparam name="T">Type of trait provided</typeparam>
    public interface IProvidesTraits<T> : IProvidesTraits { }

    public delegate void AddOrUpdateTraitDelegate<T>(int dataId, string traitName, T value);

    public delegate bool RemoveTraitDelegate<T>(int dataId, string traitName);

    public static class IProvidesTraitsMethods<T>
    {
        public static AddOrUpdateTraitDelegate<T> AddOrUpdateTrait { internal get; set; }
        public static RemoveTraitDelegate<T> RemoveTrait { internal get; set; }
    }

    public static class IProvidesTraitsMethods
    {
        public const string StaticProvidedTraitsFieldName = "k_ProvidedTraits";

        public const BindingFlags StaticProvidedTraitsBindingFlags =
            BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy;

        public static void AddOrUpdateTrait<T>(this IProvidesTraits<T> obj, int dataID, string traitName, T value)
        {
            IProvidesTraitsMethods<T>.AddOrUpdateTrait(dataID, traitName, value);
        }

        public static bool RemoveTrait<T>(this IProvidesTraits<T> obj, int dataID, string traitName)
        {
            return IProvidesTraitsMethods<T>.RemoveTrait(dataID, traitName);
        }
    }

#if UNITY_EDITOR
    [InitializeOnLoad]
    static class IProvidesTraitsAnalyzer
    {
        static IProvidesTraitsAnalyzer()
        {
            var implementors = new List<Type>();
            typeof(IProvidesTraits).GetImplementationsOfInterface(implementors);

            foreach (var implementor in implementors)
            {
                CheckType(implementor);
            }
        }

        static void CheckType(Type type)
        {
            var providedTraits = type.GetField(
                IProvidesTraitsMethods.StaticProvidedTraitsFieldName,
                IProvidesTraitsMethods.StaticProvidedTraitsBindingFlags);

            if (providedTraits == null)
            {
                Debug.LogErrorFormat("Error implementing IProvidesTraits in class {0}. Missing required static readonly " +
                    "field {1}. See IProvidesTraits.cs for details",
                    type.Name,
                    IProvidesTraitsMethods.StaticProvidedTraitsFieldName);

                return;
            }

            if (!providedTraits.IsInitOnly)
            {
                Debug.LogErrorFormat("Error implementing IProvidesTraits in class {0}. Required static field " +
                    "{1} must be readonly",
                    type.Name,
                    IProvidesTraitsMethods.StaticProvidedTraitsFieldName);

                return;
            }

            if (providedTraits.FieldType != typeof(TraitDefinition[]))
            {
                Debug.LogErrorFormat("Error implementing IProvidesTraits in class {0}. Required static readonly field " +
                    "{1} must be of type TraitDefinition[]",
                    type.Name,
                    IProvidesTraitsMethods.StaticProvidedTraitsFieldName);
            }
        }
    }
#endif
}
