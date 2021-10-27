using Unity.Profiling;

namespace Unity.MARS
{
    static class ProfilerLabels
    {
        internal const string SetAcquireCheck = "MARSQueryBackend.SetAcquireCheck()";
        internal const string TryStartSimulation = "QuerySimulationModule.TryStartSimulation()";
        internal const string CopySimulatablesToSimulationScene = "SimulatedObjectsManager.CopySimulatablesToSimulationScene()";
    }

    static class ProfilerMarkers
    {
        internal static readonly ProfilerMarker SetAcquireCheck = new ProfilerMarker(ProfilerLabels.SetAcquireCheck);
        internal static readonly ProfilerMarker TryStartSimulation = new ProfilerMarker(ProfilerLabels.TryStartSimulation);
        internal static readonly ProfilerMarker CopySimulatablesToSimulationScene = new ProfilerMarker(ProfilerLabels.CopySimulatablesToSimulationScene);
    }
}
