using System;
using System.Collections.Generic;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// Identifies an object as a simulated replacement for real world data.
    /// It injects functionality into all synthesized traits and trackables on this object.
    /// </summary>
    [HelpURL(DocumentationConstants.SimulatedObjectDocs)]
    [MovedFrom("Unity.MARS")]
    public class SimulatedObject : MonoBehaviour, IUsesFunctionalityInjection
    {
        public event Action<SimulatedObject> onDisabled;

        readonly List<SynthesizedTrait> m_Traits = new List<SynthesizedTrait>();
        readonly List<SynthesizedTrackable> m_Trackables = new List<SynthesizedTrackable>();

        public List<SynthesizedTrait> traits { get { return m_Traits; } }

        IProvidesFunctionalityInjection IFunctionalitySubscriber<IProvidesFunctionalityInjection>.provider { get; set; }

        void OnDisable()
        {
            if (onDisabled != null)
                onDisabled(this);
        }

        void OnEnable()
        {
            GetComponentsInChildren(m_Traits);
            GetComponentsInChildren(m_Trackables);

            this.EnsureFunctionalityInjected();
            foreach (var currentTrait in m_Traits)
            {
                this.InjectFunctionalitySingle(currentTrait);
            }

            foreach (var currentTrackable in m_Trackables)
            {
                this.InjectFunctionalitySingle(currentTrackable);
            }
        }
    }
}
