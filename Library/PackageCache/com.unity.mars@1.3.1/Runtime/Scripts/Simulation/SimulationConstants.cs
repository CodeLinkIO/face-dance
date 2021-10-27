using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Simulation
{
    /// <summary>
    /// Constant and static values used for simulations in MARS
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public static class SimulationConstants
    {
        /// <summary>
        /// The name of the expected Simulation Environment Layer for the simulated environment.
        /// </summary>
        public const string SimulationEnvironmentLayerName = "MARS Simulation Environment";
        internal const int MaxLayerIndex = AllLayerCount - 1;
        internal const int ValidLayerCount = AllLayerCount - FirstValidLayer;
        internal const int DefaultEnvironmentLayerIndex = 3;
        internal const int FirstValidLayer = 1;
        internal static readonly int[] ReservedLayers = { 0, 1, 2, 3, 4, 5, 6, 7, 31 };
        internal const int AllLayerCount = 32;

        /// <summary>
        /// The layer index value used for GameObjects in the simulated environment.
        /// This is used when setting `gameObject.layer` to that of the simulated environment.
        /// </summary>
        public static int SimulatedEnvironmentLayerIndex => SimulationEnvironmentSettings.instance ?
            SimulationEnvironmentSettings.instance.SimulationEnvironmentLayerIndex : DefaultEnvironmentLayerIndex;

        /// <summary>
        /// The bit mask for the layer used for GameObjects in the simulated environment.
        /// This is used when needing to a layer culling or include mask to the simulated environment.
        /// </summary>
        public static int SimulatedEnvironmentLayerMask => 1 << SimulatedEnvironmentLayerIndex;
    }
}
