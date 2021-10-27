using System.Collections.Generic;

namespace Unity.MARS.Query
{
    class MarkDataUsedTransform : DataTransform<int[], QueryMatchID[], Exclusivity[]> {}

    class MarkUsedStage : QueryStage<MarkDataUsedTransform>
    {
        public MarkUsedStage(MarkDataUsedTransform transformation)
            : base("Mark Data Used", transformation)
        {
        }
    }
}
