using System;
using System.Collections.Generic;

namespace Unity.MARS.Query
{
    class TraitRequirementFilterTransform : DataTransform<
        Dictionary<Type, Action<string, HashSet<int>>>,
        ProxyTraitRequirements[],
        HashSet<int>[]>
    {
        public TraitRequirementFilterTransform()
        {
            Process = ProcessStage;
        }

        public static void ProcessStage(List<int> workingIndices,
            Dictionary<Type, Action<string, HashSet<int>>> typeToFilterAction,
            ProxyTraitRequirements[] traitRequirements,
            ref HashSet<int>[] matchSets)
        {
            foreach (var i in workingIndices)
            {
                var requirements = traitRequirements[i];
                var matchSet = matchSets[i];

                foreach (var requirement in requirements)
                {
                    if (!requirement.Required)    // don't filter based on optional traits.
                        continue;

                    if (typeToFilterAction.TryGetValue(requirement.Type, out var filterAction))
                        filterAction.Invoke(requirement.TraitName, matchSet);
                }
            }
        }
    }

    class TraitRequirementFilterStage : QueryStage<TraitRequirementFilterTransform>
    {
        public TraitRequirementFilterStage(TraitRequirementFilterTransform transformation)
            : base("Trait Presence Filter", transformation)
        {
        }
    }
 }
