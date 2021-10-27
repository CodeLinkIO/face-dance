namespace Unity.MARS.Query
{
    /// <summary>
    /// Describes how data used in a query should be reserved
    /// </summary>
    public enum Exclusivity
    {
        /// <summary> Data can be used even if it is shared or owned; will not set ownership of data </summary>
        ReadOnly,
        /// <summary> Data can be used only if it is unowned or shared; data that is used will be marked as shared </summary>
        Shared,
        /// <summary> Data can be used only if it is unowned; data that is used will be marked as owned </summary>
        Reserved
    }
}
