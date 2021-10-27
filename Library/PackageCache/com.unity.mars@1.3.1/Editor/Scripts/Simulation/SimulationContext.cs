using System;
using System.Collections.Generic;
using Unity.MARS;
using Unity.MARS.Data.Recorded;
using Unity.MARS.Query;
using Unity.MARS.Recording;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// State that determines the setup of a given simulation
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class SimulationContext
    {
        EnvironmentMode m_EnvironmentMode;
        GameObject m_EnvironmentPrefab;
        SessionRecordingInfo m_SyntheticRecording;
        SessionRecordingInfo m_IndependentRecording;
        bool m_Temporal;
        bool m_DisableRecordingPlayback;

        /// <summary>
        /// Collection of the functionality subscriber types used in the simulation
        /// </summary>
        public HashSet<Type> SceneSubscriberTypes { get; } = new HashSet<Type>();
        /// <summary>
        /// Trait requirements for simulation in a scene
        /// </summary>
        public HashSet<TraitRequirement> SceneRequirements { get; } = new HashSet<TraitRequirement>();

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        // Reference type collections must also be cleared after use
        static readonly HashSet<Type> k_SubscriberTypes = new HashSet<Type>();
        static readonly HashSet<TraitRequirement> k_TraitRequirements = new HashSet<TraitRequirement>();

        internal bool Update(MARSSession marsSession, List<IFunctionalitySubscriber> subscribers, bool temporal)
        {
            k_SubscriberTypes.Clear();
            k_TraitRequirements.Clear();

            var moduleLoader = ModuleLoaderCore.instance;
            foreach (var module in moduleLoader.modules)
            {
                k_SubscriberTypes.Add(module.GetType());
            }

            foreach (var subscriber in subscribers)
            {
                k_SubscriberTypes.Add(subscriber.GetType());
            }

            k_TraitRequirements.UnionWith(marsSession.requirements.TraitRequirements);

            var simulationSettings = SimulationSettings.instance;
            var environmentMode = simulationSettings.EnvironmentMode;
            var environmentPrefab = simulationSettings.EnvironmentPrefab;
            var independentRecording = simulationSettings.IndependentRecording;
            var syntheticRecording = simulationSettings.UseSyntheticRecording ?
                simulationSettings.GetRecordingForCurrentSyntheticEnvironment() : null;

            var recordingPlaybackModule = moduleLoader.GetModule<MarsRecordingPlaybackModule>();
            var disableRecordingPlayback = recordingPlaybackModule != null && recordingPlaybackModule.DisableRecordingPlayback;

            var changed = !SceneSubscriberTypes.SetEquals(k_SubscriberTypes) ||
                !SceneRequirements.SetEquals(k_TraitRequirements) ||
                m_EnvironmentMode != environmentMode ||
                m_EnvironmentPrefab != environmentPrefab ||
                m_SyntheticRecording != syntheticRecording ||
                m_IndependentRecording != independentRecording ||
                m_Temporal != temporal ||
                m_DisableRecordingPlayback != disableRecordingPlayback;

            SceneSubscriberTypes.Clear();
            SceneSubscriberTypes.UnionWith(k_SubscriberTypes);
            SceneRequirements.Clear();
            SceneRequirements.UnionWith(k_TraitRequirements);
            m_EnvironmentMode = environmentMode;
            m_EnvironmentPrefab = environmentPrefab;
            m_SyntheticRecording = syntheticRecording;
            m_IndependentRecording = independentRecording;
            m_Temporal = temporal;
            m_DisableRecordingPlayback = disableRecordingPlayback;

            k_SubscriberTypes.Clear();
            k_TraitRequirements.Clear();
            return changed;
        }

        /// <summary>
        /// Clear the context
        /// </summary>
        public void Clear()
        {
            SceneSubscriberTypes.Clear();
            SceneRequirements.Clear();
            m_EnvironmentMode = default;
            m_EnvironmentPrefab = null;
            m_SyntheticRecording = null;
            m_Temporal = false;
        }
    }
}
