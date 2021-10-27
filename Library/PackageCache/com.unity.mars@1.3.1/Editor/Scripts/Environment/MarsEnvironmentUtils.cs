using UnityEditor;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace Unity.MARS
{
    static class MarsEnvironmentUtils
    {
        public static void EnsureAssetHasEnvironmentLabel(Object obj)
        {
            const string environmentLabel = MARSEnvironmentManager.EnvironmentLabel;
            var labels = AssetDatabase.GetLabels(obj);
            foreach (var label in labels)
            {
                if (label == environmentLabel)
                    return;
            }

            var newLabels = new string[labels.Length + 1];
            labels.CopyTo(newLabels, 0);
            newLabels[newLabels.Length - 1] = environmentLabel;
            AssetDatabase.SetLabels(obj, newLabels);
        }

        public static bool IsDefaultEnvironment(Object obj)
        {
            var labels = AssetDatabase.GetLabels(obj);
            foreach (var label in labels)
            {
                if (label == MARSEnvironmentManager.DefaultEnvironmentLabel)
                    return true;
            }

            return false;
        }
    }
}
