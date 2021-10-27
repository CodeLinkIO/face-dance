#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.MARSUtils
{
    [MovedFrom("Unity.MARS")]
    public static class EditorOnlyEvents
    {
        public static event Action onTemporalSimulationStart;
        public static event Action onEnvironmentSetup;
        public static event Action<List<IFunctionalitySubscriber>, HashSet<TraitRequirement>> onSimulationStart;
        public static event Action<List<MonoBehaviour>> onSetupSimulatables;
        public static event Action<MonoBehaviour, bool> onBlockSimulationSync;

        public static void OnSimulationStart(List<IFunctionalitySubscriber> subscribers, HashSet<TraitRequirement> traitRequirements)
        {
            if (onSimulationStart != null)
                onSimulationStart(subscribers, traitRequirements);
        }

        public static void OnSetupSimulatables(List<MonoBehaviour> simulatables)
        {
            if (onSetupSimulatables != null)
                onSetupSimulatables(simulatables);
        }

        public static void OnTemporalSimulationStart()
        {
            if (onTemporalSimulationStart != null)
                onTemporalSimulationStart();
        }

        public static void OnEnvironmentSetup()
        {
            if (onEnvironmentSetup != null)
                onEnvironmentSetup();
        }

        public static void BlockSimulationSync(MonoBehaviour monoBehaviour, bool block)
        {
            if (onBlockSimulationSync != null)
                onBlockSimulationSync(monoBehaviour, block);
        }
    }
}
#endif
