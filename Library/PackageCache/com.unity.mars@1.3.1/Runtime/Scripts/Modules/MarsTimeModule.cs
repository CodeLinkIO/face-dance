using System.Collections.Generic;
using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Simulation
{
    /// <summary>
    /// Manages <see cref="MarsTime"/> properties and callbacks
    /// </summary>
    [ScriptableSettingsPath(MARSCore.SettingsFolder)]
    [ModuleBehaviorCallbackOrder(ModuleOrders.MarsTimeBehaviorOrder)]
    [MovedFrom("Unity.MARS")]
    public class MarsTimeModule : ScriptableSettings<MarsTimeModule>, IModuleBehaviorCallbacks
    {
        internal const string NegativeTimeScaleMessage = "MarsTime.TimeScale cannot be less than 0";

        [SerializeField]
        [Tooltip("Sets the interval in seconds at which MarsUpdate events are performed")]
        float m_TimeStep = 0.016f;

        readonly List<IModuleMarsUpdate> m_MarsUpdateModules = new List<IModuleMarsUpdate>();

        float m_FixedTimeStep;
        float m_TimeScale = 1f;
        bool m_TimeScaleChangedThisFrame;
        float m_TimeAtLastTimeScaleChange;
        float m_MarsTimeAtLastTimeScaleChange;

        // This is the time scale value that is actually used in Mars Time update calculations.  It is separate from m_TimeScale
        // so that changes to MarsTime.TimeScale are applied in the *next* frame, as that is the case with Time.timeScale.
        float m_EffectiveTimeScale;

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            MarsTimeDelegates.GetTimeScale = GetTimeScale;
            MarsTimeDelegates.SetTimeScale = SetTimeScale;
            MarsTimeDelegates.Pause = Pause;
            MarsTimeDelegates.Play = Play;
            MarsTime.TimeStep = m_TimeStep;
            m_MarsUpdateModules.Clear();
            foreach (var module in ModuleLoaderCore.instance.modules)
            {
                if (module is IModuleMarsUpdate marsUpdateModule)
                    m_MarsUpdateModules.Add(marsUpdateModule);
            }
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            MarsTimeDelegates.ResetDelegates();
            MarsTime.Time = 0f;
            MarsTime.FrameCount = 0;
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorAwake() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorEnable()
        {
            MarsTime.Time = 0f;
            MarsTime.FrameCount = 0;
            MarsTime.TimeStep = m_TimeStep;
            MarsTime.Paused = false;
            m_FixedTimeStep = m_TimeStep; // Cache the time step here in case the serialized value changes during this session
            m_TimeScale = 1f;
            m_EffectiveTimeScale = m_TimeScale;
            m_TimeScaleChangedThisFrame = false;
            m_TimeAtLastTimeScaleChange = Time.time;
            m_MarsTimeAtLastTimeScaleChange = 0f;
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorStart() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorUpdate()
        {
            // Mars Time must tick on a fixed time step and also progress at the same pace as Time.time scaled by MarsTime.TimeScale.
            // So in each behavior update we tick Mars Time by the fixed time step until it has caught up as much as it can
            // to endMarsTime without surpassing it.  To determine endMarsTime we need to keep track of what Time.time and
            // MarsTime.Time were the last time there was a change in MarsTime.TimeScale, and only apply our time scale to
            // the Time.time that has passed since the last change.
            var time = Time.time;
            var timeSinceLastTimeScaleChange = time - m_TimeAtLastTimeScaleChange;
            var endMarsTime = m_MarsTimeAtLastTimeScaleChange + timeSinceLastTimeScaleChange * m_EffectiveTimeScale;
            var marsTime = MarsTime.Time + m_FixedTimeStep;
            while (marsTime <= endMarsTime && !MarsTime.Paused)
            {
                MarsTime.Time = marsTime;
                MarsTime.FrameCount++;
                InvokeMarsUpdate();
                marsTime += m_FixedTimeStep;
            }

            if (m_TimeScaleChangedThisFrame)
            {
                m_TimeScaleChangedThisFrame = false;

                // Start applying this time scale next frame, and pause/unpause if needed
                m_EffectiveTimeScale = m_TimeScale;
                MarsTime.Paused = Mathf.Approximately(m_TimeScale, 0f);

                // For time scale to only affect the time that has passed since it was changed, we must capture
                // these time values before we start applying time scale
                m_TimeAtLastTimeScaleChange = time;
                m_MarsTimeAtLastTimeScaleChange = MarsTime.Time;
            }
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDisable() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDestroy() { }

        void InvokeMarsUpdate()
        {
            foreach (var module in m_MarsUpdateModules)
            {
                module.OnMarsUpdate();
            }

            MarsTime.InvokeMarsUpdate();
        }

        float GetTimeScale() { return m_TimeScale; }

        void SetTimeScale(float timeScale)
        {
            if (timeScale < 0f)
            {
                Debug.LogError(NegativeTimeScaleMessage);
                return;
            }

            m_TimeScale = timeScale;
            m_TimeScaleChangedThisFrame = true;
        }

        void Pause()
        {
            // Calling Pause differs from just setting MarsTime.TimeScale to 0 in that it also immediately stops
            // Mars Time from ticking for the rest of the frame.  This is why setting TimeScale to 0 does not immediately
            // set Paused to true, but calling Pause does.
            m_TimeScale = 0f;
            m_EffectiveTimeScale = m_TimeScale;
            MarsTime.Paused = true;
            m_TimeAtLastTimeScaleChange = Time.time;
            m_MarsTimeAtLastTimeScaleChange = MarsTime.Time;
        }

        void Play()
        {
            m_TimeScale = 1f;
            m_EffectiveTimeScale = m_TimeScale;
            MarsTime.Paused = false;
            m_TimeAtLastTimeScaleChange = Time.time;
            m_MarsTimeAtLastTimeScaleChange = MarsTime.Time;
        }
    }
}
