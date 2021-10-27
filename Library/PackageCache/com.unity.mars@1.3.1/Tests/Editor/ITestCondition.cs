using Unity.MARS.Query;

namespace Unity.MARS.Data.Tests
{
    interface ITestCondition<TConditionData, TInputTestData> : ICondition<TConditionData>
    {
        new string traitName { get; set; }

        TInputTestData value { get; set; }

        void Initialize(int traitIndex);
    }
}
