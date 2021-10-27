using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Simulation
{
    /// <summary>
    /// Provides access to frame-rate independent time information for the MARS lifecycle
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public static class MarsTime
    {
        /// <summary>
        /// The time the latest <see cref="MarsUpdate"/> has started. This is the time in seconds since the start of the
        /// MARS lifecycle. This scales with <see cref="TimeScale"/>.
        /// </summary>
        public static float Time { get; internal set; }

        /// <summary>
        /// The fixed interval in seconds at which <see cref="MarsUpdate"/>s are performed. This is not affected by
        /// <see cref="TimeScale"/>.
        /// </summary>
        public static float TimeStep { get; internal set; }

        /// <summary>
        /// The total number of <see cref="MarsUpdate"/>s that have occurred
        /// </summary>
        public static int FrameCount { get; internal set; }

        /// <summary>
        /// Whether <see cref="MarsUpdate"/>s are paused
        /// </summary>
        public static bool Paused { get; internal set; }

        /// <summary>
        /// The scale at which <see cref="Time"/> passes. This is 1 at the start of the MARS lifecycle.
        /// When TimeScale is 1, MARS Time passes at the same rate as Unity <see cref="UnityEngine.Time.time"/>.
        /// When TimeScale is 0, <see cref="MarsUpdate"/>s are paused. A higher TimeScale value corresponds to a higher
        /// frequency of <see cref="MarsUpdate"/>s per frame. Setting this value does not affect updates until the next frame.
        /// </summary>
        public static float TimeScale
        {
            get => MarsTimeDelegates.GetTimeScale();
            set => MarsTimeDelegates.SetTimeScale(value);
        }

        /// <summary>
        /// Unity <see cref="UnityEngine.Time.deltaTime"/> scaled by <see cref="TimeScale"/>
        /// </summary>
        public static float ScaledDeltaTime => UnityEngine.Time.deltaTime * TimeScale;

        /// <summary>
        /// Called every <see cref="TimeStep"/> seconds while the MARS lifecycle is running. The frequency of MARS updates
        /// per player loop update scales with <see cref="TimeScale"/>.
        /// </summary>
        public static event Action MarsUpdate;

        /// <summary>
        /// Sets <see cref="TimeScale"/> to 0 and stops <see cref="MarsUpdate"/>s from running for the rest of the frame
        /// and until <see cref="TimeScale"/> is set to a positive value
        /// </summary>
        public static void Pause() { MarsTimeDelegates.Pause(); }

        /// <summary>
        /// If <see cref="Paused"/> is true, sets <see cref="TimeScale"/> to 1 and starts <see cref="MarsUpdate"/>s running.
        /// Does nothing if <see cref="Paused"/> is false.
        /// </summary>
        public static void Play() { MarsTimeDelegates.Play(); }

        internal static void InvokeMarsUpdate() { MarsUpdate?.Invoke(); }
    }

    static class MarsTimeDelegates
    {
        public static Func<float> GetTimeScale = GetTimeScaleNoop;
        public static Action<float> SetTimeScale = SetTimeScaleNoop;
        public static Action Pause = PauseNoop;
        public static Action Play = PlayNoop;

        public static void ResetDelegates()
        {
            GetTimeScale = GetTimeScaleNoop;
            SetTimeScale = SetTimeScaleNoop;
            Pause = PauseNoop;
            Play = PlayNoop;
        }

        static float GetTimeScaleNoop()
        {
            return 1f;
        }

        static void SetTimeScaleNoop(float timeScale) { }

        static void PauseNoop() { }

        static void PlayNoop() { }
    }
}
