using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.MARSUtils
{
    /// <summary>
    /// Extension methods for Type objects
    /// </summary>
    [MovedFrom("Unity.MARS.Interfaces")]
    public static class TypeExtensions
    {
        /// <summary>
        /// Find all types that implement the given interface type, and append them to a list
        /// If the input type is not an interface type, no action is taken.
        /// </summary>
        /// <param name="type">The interface type whose implementors will be found</param>
        /// <param name="list">The list to which implementors will be appended</param>
        public static void GetImplementationsOfInterface(this Type type, List<Type> list)
        {
            if (!type.IsInterface)
                return;

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                try
                {
                    var types = assembly.GetTypes();
                    foreach (var t in types)
                    {
                        if (type.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                            list.Add(t);
                    }
                }
                catch (ReflectionTypeLoadException)
                {
                    // Skip any assemblies that don't load properly -- suppress errors
                }
            }
        }
    }
}
