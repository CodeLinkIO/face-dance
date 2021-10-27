namespace Unity.MARS.Data
{
    public abstract class ProcessingJob
    {
        /// <summary>
        /// The number of subscribers to this job
        /// </summary>
        public int userCount { get; set; }

        /// <summary>
        /// Perform this job's processing
        /// </summary>
        public virtual void Execute() { }
    }

    /// <summary>
    /// A task that transforms data in the database
    /// </summary>
    /// <typeparam name="S">The type of the collection to be sorted (source)</typeparam>
    /// <typeparam name="P">The type of collection the processed data is stored in</typeparam>
    public abstract class ProcessingJob<S, P> : ProcessingJob
    {
        protected S m_Source;
        protected P m_Processed;

        /// <summary>
        /// The data output of this processing job
        /// </summary>
        public P processed { get { return m_Processed; } }
    }
}
