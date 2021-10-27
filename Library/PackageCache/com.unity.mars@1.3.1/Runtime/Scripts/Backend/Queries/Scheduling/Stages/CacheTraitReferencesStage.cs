using System.Collections.Generic;
using Unity.MARS.Data;

namespace Unity.MARS.Query
{
    class TraitRefTransform : DataTransform<List<int>, ProxyConditions[], CachedTraitCollection[]>
    {
        public TraitRefTransform(ProcessDelegate process) : base(process)
        {
        }
    }

    class CacheTraitReferencesStage : QueryStage<TraitRefTransform>
    {
        public CacheTraitReferencesStage(TraitRefTransform transformation)
            : base("Cache Trait Values", transformation)
        {
        }
    }
}
