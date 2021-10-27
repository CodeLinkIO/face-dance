using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityEditor.XRTools.Utils
{
    [Serializable]
    public class AssemblyDefinition
    {
        [Serializable]
        public class VersionDefine
        {
            public string name;
            public string expression;
            public string define;
        }

        public string name;
        public string[] references;
        public string[] includePlatforms;
        public string[] excludePlatforms;
        public bool allowUnsafeCode;
        public bool overrideReferences;
        public string[] precompiledReferences;
        public bool autoReferenced;
        public string[] defineConstraints;
        public VersionDefine[] versionDefines;
        public bool noEngineReferences;

        public bool AddReferences(IEnumerable<string> newReferences)
        {
            var newRefs = newReferences as string[] ?? newReferences.ToArray();
            var duplicateStates = new bool[newRefs.Length];
            for (var i = 0; i < newRefs.Length; i++)
            {
                var newRef = newRefs[i];
                foreach (var existingRef in references)
                {
                    if (newRef == existingRef)
                    {
                        duplicateStates[i] = true;
                        break;
                    }
                }
            }

            var nonDuplicateCount = duplicateStates.Count(s => !s);
            if (nonDuplicateCount <= 0)
                return false;

            var newLength = references.Length + nonDuplicateCount;
            var refIndex = references.Length;
            Array.Resize(ref references, newLength);

            for (var i = 0; i < newRefs.Length; i++)
            {
                if (duplicateStates[i])
                    continue;

                references[refIndex] = newRefs[i];
                refIndex++;
            }

            return true;
        }
    }
}
