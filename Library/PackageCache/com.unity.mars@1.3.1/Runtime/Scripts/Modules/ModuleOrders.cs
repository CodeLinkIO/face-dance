namespace Unity.MARS
{
    static class ModuleOrders
    {
        const int k_DefaultOrder = int.MaxValue / 2;

        /// <summary>
        /// Behavior callback order for the MARS time module. This ensures time is set to 0 before any other modules
        /// receive OnBehaviorEnable.
        /// </summary>
        public const int MarsTimeBehaviorOrder = -k_DefaultOrder;

        /// <summary>
        /// Behavior callback order for the scene module
        /// </summary>
        public const int SceneBehaviorOrder = k_DefaultOrder;

        /// <summary>
        /// Behavior callback order for the reasoning API updates.
        /// </summary>
        public const int ReasoningBehaviorOrder = SceneBehaviorOrder + 1;

        /// <summary>
        /// Behavior callback order for the backend. This lets the backend hook up Data API clients after scene module
        /// has satisfied requirements with providers
        /// </summary>
        public const int BackendBehaviorOrder = ReasoningBehaviorOrder + 1;

        /// <summary>
        /// Module load order for the database
        /// </summary>
        public const int DatabaseLoadOrder = k_DefaultOrder;

        /// <summary>
        /// Module load order for the database
        /// </summary>
        public const int ForcesFieldSolverLoadOrder = DatabaseLoadOrder + 1;

        /// <summary>
        /// Module load order for the query pipelines module
        /// </summary>
        public const int PipelinesLoadOrder = ForcesFieldSolverLoadOrder + 1;

        /// <summary>
        /// Module load order for the backend
        /// </summary>
        public const int BackendLoadOrder = PipelinesLoadOrder + 1;

        /// <summary>
        /// Module load order for the geolocation module
        /// </summary>
        public const int GeoLocationLoadOrder = DatabaseLoadOrder + 1;

        /// <summary>
        /// Module load order for the simulation scene module. This lets the environment manager subscribe to the
        /// sim scene created callback before the sim scene is created in the sim scene module's load.
        /// </summary>
        public const int SimSceneLoadOrder = DatabaseLoadOrder + 1;

        /// <summary>
        /// Behavior callback order for the simulation scene module.
        /// </summary>
        public const int SimSceneBehaviorOrder = k_DefaultOrder + 1;

        /// <summary>
        /// Module load order for the simulated discovery module
        /// </summary>
        public const int SimDiscoveryLoadOrder = SimSceneLoadOrder + 1;

        /// <summary>
        /// Module load order for the proxy forces planes module.
        /// </summary>
        public const int ForcesFromPlanesLoadOrder = SimDiscoveryLoadOrder + 1;

        /// <summary>
        /// Module load order for the Composite Render View Module
        /// </summary>
        public const int CompositeRenderLoadOrder = SimSceneLoadOrder + 1;

        /// <summary>
        /// Module unload order for the Composite Render View Module
        /// </summary>
        public const int CompositeRenderUnloadOrder = k_DefaultOrder;

        /// <summary>
        /// Module unload order for the backend
        /// </summary>
        public const int BackendUnloadOrder = k_DefaultOrder;

        /// <summary>
        /// Module unload order for the query pipelines module
        /// </summary>
        public const int PipelinesUnloadOrder = BackendUnloadOrder + 1;

        /// <summary>
        /// Module unload order for the spatial data module
        /// Load after SpatialHashModule, which does not specify a load order
        /// </summary>
        public const int SpatialDataModuleOrder = DatabaseLoadOrder;
    }
}
