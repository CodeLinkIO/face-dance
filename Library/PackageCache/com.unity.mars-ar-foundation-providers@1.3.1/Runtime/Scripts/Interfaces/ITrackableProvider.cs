namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines methods for resetting the state of trackable providers
    /// </summary>
    interface ITrackableProvider
    {
        /// <summary>
        /// Clear all trackable data and execute removed events
        /// </summary>
        void ClearTrackables();

        /// <summary>
        /// Add back all trackable data from the hardware, executing add events
        /// </summary>
        void AddExistingTrackables();
    }
}
