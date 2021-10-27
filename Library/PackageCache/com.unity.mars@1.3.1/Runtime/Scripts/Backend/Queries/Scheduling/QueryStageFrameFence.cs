namespace Unity.MARS.Query
{
    ///<summary>
    /// Represents the start and end stages of a set of stages executed together in a query pipeline
    ///</summary>
    [System.Serializable]
    public struct QueryStageFrameFence
    {
        public int endingStage;

        public QueryStageFrameFence(int end)
        {
            endingStage = end;
        }
    }
}
