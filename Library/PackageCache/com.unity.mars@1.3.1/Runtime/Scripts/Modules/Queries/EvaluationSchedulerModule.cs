using System;
using System.Collections.Generic;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    [ScriptableSettingsPath(MARSCore.SettingsFolder)]
    [MovedFrom("Unity.MARS")]
    public class EvaluationSchedulerModule : ScriptableSettings<EvaluationSchedulerModule>, IModuleMarsUpdate,
        IModuleBehaviorCallbacks, IModuleDependency<QueryPipelinesModule>
    {
        internal const float AbsoluteMinimumIntervalTime = 1f / 90f;  // hard limit on interval is 1 frame at 90hz

        [SerializeField]
        [Tooltip("The mode to use by default when MARS starts")]
        MarsSceneEvaluationMode m_StartupMode = MarsSceneEvaluationMode.EvaluateOnInterval;

        [SerializeField]
        [Tooltip("How often to check for query acquisition, if using EvaluateOnInterval mode")]
        float m_EvaluationInterval = 0.3f;

        [SerializeField]
        [Tooltip("The minimum time to let elapse between the end of one evaluation and the beginning of the next, if using WaitForRequest mode")]
        float m_MinimumEvaluationInterval = 0.2f;

        readonly List<Action> m_OnEvaluationDoneCallbacksCurrent = new List<Action>();
        readonly List<Action> m_OnEvaluationDoneCallbacksNext = new List<Action>();

        QueryPipelinesModule m_PipelinesModule;

        internal bool CurrentlyEvaluating { get; private set; }
        internal bool EvaluationQueued { get; private set; }

        internal MarsSceneEvaluationMode ActiveMode { get; private set; }

        internal float LastEvaluationFinishTime { get; private set; }

        internal float MinimumEvaluationInterval => m_MinimumEvaluationInterval;

        /// <inheritdoc />
        void IModuleDependency<QueryPipelinesModule>.ConnectDependency(QueryPipelinesModule dependency)
        {
            m_PipelinesModule = dependency;
        }

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            IUsesMarsSceneEvaluationMethods.RequestSceneEvaluation = RequestSceneEvaluation;
            IUsesMarsSceneEvaluationMethods.SetEvaluationMode = SetMode;
            IUsesMarsSceneEvaluationMethods.GetEvaluationInterval = GetEvaluationInterval;
            IUsesMarsSceneEvaluationMethods.SetEvaluationInterval = SetEvaluationInterval;
            m_PipelinesModule.OnSceneEvaluationComplete += OnEvaluationComplete;
            ActiveMode = m_StartupMode;
            LastEvaluationFinishTime = MarsTime.Time;
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            IUsesMarsSceneEvaluationMethods.RequestSceneEvaluation = RequestSceneEvaluationNoop;
            IUsesMarsSceneEvaluationMethods.SetEvaluationMode = mode => { };
            IUsesMarsSceneEvaluationMethods.GetEvaluationInterval = () => 0f;
            IUsesMarsSceneEvaluationMethods.SetEvaluationInterval = seconds => { };
            m_PipelinesModule.OnSceneEvaluationComplete -= OnEvaluationComplete;
            CurrentlyEvaluating = false;
            EvaluationQueued = false;
        }

        /// <inheritdoc />
        void IModuleMarsUpdate.OnMarsUpdate()
        {
            switch (ActiveMode)
            {
                case MarsSceneEvaluationMode.WaitForRequest:
                    if (EvaluationQueued && !CurrentlyEvaluating)
                    {
                        if (MarsTime.Time - LastEvaluationFinishTime >= m_MinimumEvaluationInterval)
                            OnEvaluationStart();
                    }

                    break;
                case MarsSceneEvaluationMode.EvaluateOnInterval:
                    if (CurrentlyEvaluating)
                        return;

                    if(MarsTime.Time - LastEvaluationFinishTime >= m_EvaluationInterval)
                        OnEvaluationStart();

                    break;
            }
        }

        internal MarsSceneEvaluationRequestResponse RequestSceneEvaluation(Action onEvaluationComplete = null)
        {
            // when using interval evaluation mode, a request to evaluate the scene will not result in a new evaluation
            if (ActiveMode == MarsSceneEvaluationMode.EvaluateOnInterval)
            {
                if (onEvaluationComplete != null)
                {
                    // even though this request does not result in a new evaluation being queued,
                    // because that evaluation is going to happen anyway, we still support the completion callback.
                    if(CurrentlyEvaluating)
                        m_OnEvaluationDoneCallbacksNext.Add(onEvaluationComplete);
                    else
                        m_OnEvaluationDoneCallbacksCurrent.Add(onEvaluationComplete);
                }

                return MarsSceneEvaluationRequestResponse.NotQueued;
            }

            MarsSceneEvaluationRequestResponse response;
            if (CurrentlyEvaluating)
            {
                response = EvaluationQueued ? MarsSceneEvaluationRequestResponse.AlreadyQueued
                    : MarsSceneEvaluationRequestResponse.QueuedAfterCooldown;

                // since we started evaluating before this request came in, this request's callback will happen
                // after the next evaluation, not the currently happening one
                if(onEvaluationComplete != null)
                    m_OnEvaluationDoneCallbacksNext.Add(onEvaluationComplete);
            }
            else
            {
                if (EvaluationQueued)
                {
                    response = MarsSceneEvaluationRequestResponse.AlreadyQueued;
                }
                else
                {
                    var elapsedSinceLastEval = MarsTime.Time - LastEvaluationFinishTime;
                    response = elapsedSinceLastEval < m_MinimumEvaluationInterval
                        ? MarsSceneEvaluationRequestResponse.QueuedAfterCooldown
                        : MarsSceneEvaluationRequestResponse.QueuedImmediately;
                }

                if(onEvaluationComplete != null)
                    m_OnEvaluationDoneCallbacksCurrent.Add(onEvaluationComplete);
            }

            EvaluationQueued = true;
            return response;
        }

        static MarsSceneEvaluationRequestResponse RequestSceneEvaluationNoop(Action onEvaluationComplete = null)
        {
            return MarsSceneEvaluationRequestResponse.NotQueued;
        }

        void OnEvaluationStart()
        {
            EvaluationQueued = false;
            CurrentlyEvaluating = true;
            m_PipelinesModule.StartCycle();
        }

        void OnEvaluationComplete()
        {
            LastEvaluationFinishTime = MarsTime.Time;
            CurrentlyEvaluating = false;
            foreach (var callback in m_OnEvaluationDoneCallbacksCurrent)
            {
                callback.Invoke();
            }

            m_OnEvaluationDoneCallbacksCurrent.Clear();

            // if any completion callbacks were buffered while this evaluation cycle was running,
            // make sure they run after the next cycle completes.
            foreach (var t in m_OnEvaluationDoneCallbacksNext)
            {
                m_OnEvaluationDoneCallbacksCurrent.Add(t);
            }

            m_OnEvaluationDoneCallbacksNext.Clear();
        }

        internal void SetMode(MarsSceneEvaluationMode mode)
        {
            if (mode == MarsSceneEvaluationMode.EvaluateOnInterval && ActiveMode == MarsSceneEvaluationMode.WaitForRequest)
            {
                // if we're evaluating when we get a request to change to interval mode,
                // we need to let the current evaluation finish and queue another one.
                if (CurrentlyEvaluating)
                    EvaluationQueued = true;
                // otherwise we can immediately start a new evaluation
                else
                    OnEvaluationStart();
            }

            ActiveMode = mode;
        }

        /// <summary>Reset the last execution time for the evaluation task</summary>
        public void ResetTime()
        {
            LastEvaluationFinishTime = MarsTime.Time;
        }

        public float GetEvaluationInterval()
        {
            return m_EvaluationInterval;
        }

        public void SetEvaluationInterval(float seconds)
        {
            m_EvaluationInterval = seconds > AbsoluteMinimumIntervalTime ? seconds : AbsoluteMinimumIntervalTime;
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorEnable()
        {
            ActiveMode = m_StartupMode;
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorAwake() { }
        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorStart() { }
        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorUpdate() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDisable()
        {
            CurrentlyEvaluating = false;
            EvaluationQueued = false;
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDestroy() { }
    }
}
