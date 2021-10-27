using System.Collections.Generic;
using Unity.MARS.Data;

namespace Unity.MARS.Query
{
    class RelationTraitRefTransform : DataTransform<List<int>, Relations[], RelationTraitCache[]>
    {
        public RelationTraitRefTransform(ProcessDelegate process) : base(process)
        {
        }
    }

    class CacheRelationTraitReferencesStage : QueryStage<RelationTraitRefTransform>
    {
        public CacheRelationTraitReferencesStage(RelationTraitRefTransform transformation)
            : base("Cache Relation Trait Values", transformation)
        {
        }
    }
}
