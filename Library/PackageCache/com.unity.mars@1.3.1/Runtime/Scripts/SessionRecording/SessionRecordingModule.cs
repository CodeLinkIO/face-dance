using System;
using System.Collections.Generic;
using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Module responsible for recording provider data during an MR session
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class SessionRecordingModule : IModule, IUsesFunctionalityInjection
    {
        readonly List<Type> m_RegisteredRecorderTypes = new List<Type>();
        readonly List<DataRecorder> m_CurrentRecorders = new List<DataRecorder>();

        IProvidesFunctionalityInjection IFunctionalitySubscriber<IProvidesFunctionalityInjection>.provider { get; set; }

        /// <summary>
        /// Is recording active
        /// </summary>
        public bool IsRecording { get; private set; }

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        // Reference type collections must also be cleared after use
        static readonly List<object> k_RecorderObjects = new List<object>();

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            m_RegisteredRecorderTypes.Clear();
            m_CurrentRecorders.Clear();
        }

        /// <inheritdoc />
        void IModule.UnloadModule() { }

        /// <summary>
        /// Registers a type of data recorder to include in the next recording
        /// </summary>
        /// <typeparam name="T">Type of data recorder to register</typeparam>
        public void RegisterRecorderType<T>() where T : DataRecorder, new()
        {
            m_RegisteredRecorderTypes.Add(typeof(T));
        }

        /// <summary>
        /// If not recording, starts recording data based on registered recorder types.
        /// If recording, records any last data if needed and then stops recording data.
        /// </summary>
        public void ToggleRecording()
        {
            IsRecording = !IsRecording;
            if (IsRecording)
                StartRecording();
            else
                FinishRecording();
        }

        void StartRecording()
        {
            k_RecorderObjects.Clear();
            m_CurrentRecorders.Clear();
            foreach (var recorderType in m_RegisteredRecorderTypes)
            {
                var recorder = (DataRecorder)Activator.CreateInstance(recorderType);
                m_CurrentRecorders.Add(recorder);
                k_RecorderObjects.Add(recorder);
            }

            this.InjectFunctionality(k_RecorderObjects);
            foreach (var dataRecorder in m_CurrentRecorders)
            {
                dataRecorder.ToggleRecording();
            }

            m_RegisteredRecorderTypes.Clear();
            k_RecorderObjects.Clear();
        }

        void FinishRecording()
        {
            foreach (var dataRecorder in m_CurrentRecorders)
            {
                if (dataRecorder.IsRecording)
                    dataRecorder.ToggleRecording();
            }
        }

        /// <summary>
        /// If recording, stops recording and discards recorded data
        /// </summary>
        public void CancelRecording()
        {
            if (!IsRecording)
                return;

            IsRecording = false;
            foreach (var dataRecorder in m_CurrentRecorders)
            {
                dataRecorder.CancelRecording();
            }

            m_CurrentRecorders.Clear();
        }

        public void CreateDataRecordings(TimelineAsset timeline, List<DataRecording> dataRecordings, List<UnityObject> newAssets)
        {
            foreach (var dataRecorder in m_CurrentRecorders)
            {
                var recording = dataRecorder.TryCreateDataRecording(timeline, newAssets);
                if (recording != null)
                    dataRecordings.Add(recording);
            }
        }
    }
}
