namespace Unity.MARS
{
    static class ProviderPriorities
    {
        /// <summary>
        /// Provider priority for non-preferred providers
        /// This helps ensure providers are selected automatically in case more than one type provides the same functionality
        /// </summary>
        public const int PreferredPriority = int.MaxValue / 2;

        /// <summary>
        /// Provider priority for simulated providers
        /// This helps prevent simulated providers from being automatically selected at runtime
        /// </summary>
        public const int SimulatedProviderPriority = int.MinValue / 2;

        /// <summary>
        /// Provider priority for recorded providers
        /// This helps prevent recorded providers from being automatically selected at runtime
        /// </summary>
        public const int RecordedProviderPriority = SimulatedProviderPriority - 1;

        /// <summary>
        /// Provider priority for stub providers
        /// This helps prevent stub providers from being automatically selected at runtime
        /// </summary>
        public const int StubProviderPriority = RecordedProviderPriority - 1;

        /// <summary>
        /// Provider priority for test providers
        /// This helps prevent test providers from being automatically selected at runtime
        /// </summary>
        public const int TestProviderPriority = StubProviderPriority - 1;
    }
}
