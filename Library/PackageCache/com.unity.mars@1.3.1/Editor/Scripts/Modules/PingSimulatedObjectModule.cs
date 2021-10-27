using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation
{
    [MovedFrom("Unity.MARS")]
    internal class PingSimulatedObjectModule : IModule
    {
        void IModule.LoadModule()
        {
            Selection.selectionChanged += OnSelectionChanged;
        }

        void IModule.UnloadModule()
        {
            Selection.selectionChanged -= OnSelectionChanged;
            HierarchyTreeView.UnsetPing();
        }

        static void OnSelectionChanged()
        {
            HierarchyTreeView.PingObjects(Selection.transforms);
        }
    }
}
