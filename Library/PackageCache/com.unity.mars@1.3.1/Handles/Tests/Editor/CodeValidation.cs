using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.MARS.MARSHandles;
using UnityEngine;
using Unity.MARS.MARSHandles.Picking;

namespace Unity.MARS.HandlesEditor.Tests
{
    internal sealed class CodeValidation
    {
        static readonly Assembly[] s_AssemblyToValidate =
        {
            Assembly.GetAssembly(typeof(RuntimeHandleContext)), // Unity.MARS.MARSHandles
            Assembly.GetAssembly(typeof(EditorHandleContext)),  // Unity.MARS.HandlesEditor
            Assembly.GetAssembly(typeof(IPickingTarget)),       // Unity.MARS.MARSHandles.Picking
        };

        static IEnumerable<Type> s_BuiltinInteractiveHandles
        {
            get { return GetInheritingTypes(s_AssemblyToValidate, new [] {typeof(InteractiveHandle)}); }
        }

        static IEnumerable<Type> s_BuiltinPickingTargets
        {
            get { return GetInheritingTypes(s_AssemblyToValidate, new[] { typeof(IPickingTarget)}); }
        }

        static IEnumerable<Type> s_BuiltinHandleBehaviours
        {
            get { return GetInheritingTypes(s_AssemblyToValidate, new[] { typeof(HandleBehaviour) }, new[] { typeof(InteractiveHandle) }); }
        }

        static List<Type> GetInheritingTypes(Assembly[] assemblies, Type[] include, Type[] ignore = null)
        {
            List<Type> results = new List<Type>();

            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    foreach (var includeType in include)
                    {
                        if (includeType.IsAssignableFrom(type))
                        {
                            if (ShouldIgnoreType(type, ignore))
                                break;

                            results.Add(type);
                            break;
                        }
                    }

                }
            }

            return results;
        }

        static bool ShouldIgnoreType(Type type, Type[] ignore)
        {
            if (type.IsAbstract || type.IsInterface)
                return true;

            if (ignore == null)
                return false;

            foreach (var ti in ignore)
            {
                if (ti.IsAssignableFrom(type))
                    return true;
            }

            return false;
        }
    }
}
