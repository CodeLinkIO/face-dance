using System;
using System.Linq;
using System.Reflection;
using Unity.MARS.Data;
using Unity.MARS.Query;
using Unity.XRTools.Utils;
using UnityEngine;

namespace UnityEditor.MARS.Internal
{
    /// <summary>
    /// Ensures that no conditions exist that are authored against external backing data
    /// </summary>
    [InitializeOnLoad]
    static class ConditionVerifier
    {
        static ConditionVerifier()
        {
            ReflectionUtils.ForEachAssembly(assembly =>
            {
                CheckForFaultyConditions(assembly);
            });
        }

        static bool CheckForFaultyConditions(Assembly assembly)
        {
            Func<Type, bool> planeFilter = t => (typeof(ICondition<MRPlane>).IsAssignableFrom(t));
            Func<Type, bool> faceFilter = t => (typeof(ICondition<IMRFace>).IsAssignableFrom(t));

            var badPlaneConditions = assembly.GetTypes().Where(planeFilter).FirstOrDefault();
            var badFaceConditions = assembly.GetTypes().Where(faceFilter).FirstOrDefault();

            if (badPlaneConditions != null)
            {
                Debug.LogError("A condition " + badPlaneConditions + " tries to test against MRPlane.  MRPlane is not a trait.  Please test for Vector2/Bounds2D instead.");
                return true;
            }

            if (badFaceConditions != null)
            {
                Debug.LogError("A condition " + badFaceConditions + " tries to test against IMRFace.  IMRFace is not a trait.  Please test for 'Face' trait instead.");
                return true;
            }

            return false;
        }
    }
}
