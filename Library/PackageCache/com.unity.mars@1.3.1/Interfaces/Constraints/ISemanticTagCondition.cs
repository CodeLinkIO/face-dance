namespace Unity.MARS.Query
{
    public interface ISemanticTagCondition : ICondition<bool>
    {
        /// <summary>
        /// Whether to require the presence or absence of the tag
        /// </summary>
        SemanticTagMatchRule matchRule { get; }
    }
}
