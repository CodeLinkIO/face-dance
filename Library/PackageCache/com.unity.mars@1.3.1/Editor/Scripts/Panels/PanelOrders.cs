namespace Unity.MARS
{
    static class PanelOrders
    {
        const int k_DefaultOrder = int.MaxValue / 2;

        /// <summary>
        /// Starting item order in the panel order for a multi panel view.
        /// </summary>
        public const int DefaultOrder = k_DefaultOrder;

        /// <summary>
        /// Order of creation panel in multi panel view.
        /// </summary>
        public const int MARSObjectCreationOrder = k_DefaultOrder + 100;

        /// <summary>
        /// Order of scene placement panel in multi panel view.
        /// </summary>
        public const int ScenePlacementOrder = k_DefaultOrder + 150;

        /// <summary>
        /// Order of simulation controls panel in multi panel view.
        /// </summary>
        public const int SimulationControlsOrder = k_DefaultOrder + 200;

        /// <summary>
        /// Order of content hierarchy panel in multi panel view.
        /// </summary>
        public const int ContentHierarchyOrder = k_DefaultOrder + 300;

        /// <summary>
        /// Order of environment hierarchy panel in multi panel view.
        /// </summary>
        public const int EnvironmentHierarchyOrder = k_DefaultOrder + 350;
    }
}
