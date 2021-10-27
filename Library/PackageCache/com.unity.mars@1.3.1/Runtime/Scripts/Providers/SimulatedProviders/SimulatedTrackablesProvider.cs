#if UNITY_EDITOR
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.MARSUtils;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEditor;

namespace Unity.MARS.Providers.Synthetic
{
    public abstract class SimulatedTrackablesProvider<T> : MonoBehaviour, IUsesFunctionalityInjection, IUsesSlowTasks
        where T : IMRTrackable
    {
        const float k_UpdateStepTime = 0.5f;

        protected readonly Dictionary<SimulatedObject, List<T>> m_SimulatedTrackables = new Dictionary<SimulatedObject, List<T>>();

        IProvidesFunctionalityInjection IFunctionalitySubscriber<IProvidesFunctionalityInjection>.provider { get; set; }
        IProvidesSlowTasks IFunctionalitySubscriber<IProvidesSlowTasks>.provider { get; set; }

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        // Reference type collections must also be cleared after use
        static readonly List<SimulatedObject> k_SimulatedObjects = new List<SimulatedObject>();

        protected virtual void OnEnable()
        {
            Undo.postprocessModifications += OnPostprocessModifications;
            Undo.undoRedoPerformed += OnUndoRedoPerformed;
            this.AddMarsTimeSlowTask(AutoCollectAllTrackables, k_UpdateStepTime, true);

            m_SimulatedTrackables.Clear();

            var getSimulatedScene = EditorOnlyDelegates.GetSimulatedEnvironmentScene;
            if (getSimulatedScene == null)
                return;

            var simScene = getSimulatedScene();
            if (!simScene.IsValid())
                return;

            foreach (var simulatedObject in Resources.FindObjectsOfTypeAll<SimulatedObject>())
            {
                if (simulatedObject.gameObject.scene == simScene && simulatedObject.isActiveAndEnabled)
                    AddObject(simulatedObject);
            }
        }

        protected virtual void OnDisable()
        {
            Undo.postprocessModifications -= OnPostprocessModifications;
            Undo.undoRedoPerformed -= OnUndoRedoPerformed;
            this.RemoveMarsTimeSlowTask(AutoCollectAllTrackables);

            foreach (var pair in m_SimulatedTrackables)
            {
                if (pair.Key != null)
                    RemoveObject(pair.Key);
            }

            m_SimulatedTrackables.Clear();
        }

        void AutoCollectAllTrackables()
        {
            var getSimulatedScene = EditorOnlyDelegates.GetSimulatedEnvironmentScene;
            if (getSimulatedScene == null)
                return;

            var simScene = getSimulatedScene();
            if (!simScene.IsValid())
                return;

            k_SimulatedObjects.Clear();
            GameObjectUtils.GetComponentsInScene(simScene, k_SimulatedObjects);
            foreach (var simulatedObject in k_SimulatedObjects)
            {
                if (!simulatedObject.isActiveAndEnabled)
                    continue;

                if (m_SimulatedTrackables.ContainsKey(simulatedObject))
                    continue;

                AddObject(simulatedObject);
            }
        }

        void AddObject(SimulatedObject simulatedObject)
        {
            this.InjectFunctionalitySingle(simulatedObject);
            simulatedObject.StartRunInEditMode();
            simulatedObject.onDisabled += RemoveObject;
            AddObjectTrackables(simulatedObject);
        }

        protected abstract void AddObjectTrackables(SimulatedObject simulatedObject);

        void OnObjectChanged(SimulatedObject simulatedObject)
        {
            if (m_SimulatedTrackables.ContainsKey(simulatedObject))
                UpdateObjectTrackables(simulatedObject);
            else
                AddObject(simulatedObject);
        }

        protected abstract void UpdateObjectTrackables(SimulatedObject simulatedObject);

        void RemoveObject(SimulatedObject simulatedObject)
        {
            simulatedObject.onDisabled -= RemoveObject;
            simulatedObject.StopRunInEditMode();
            if (m_SimulatedTrackables.ContainsKey(simulatedObject))
            {
                foreach (var trackable in m_SimulatedTrackables[simulatedObject])
                {
                    RemoveTrackable(trackable);
                }
            }
        }

        protected abstract void RemoveTrackable(T trackable);

        UndoPropertyModification[] OnPostprocessModifications(UndoPropertyModification[] modifications)
        {
            foreach (var modification in modifications)
            {
                // We don't count an inactive/disabled SimulatedObject as a change since
                // we already subscribe to the object's onDisabled callback.
                var modifiedObject = modification.currentValue.target as GameObject;
                if (modifiedObject == null)
                {
                    var component = modification.currentValue.target as Component;
                    var behaviour = component as Behaviour;
                    if (component != null && (behaviour == null || behaviour.enabled))
                        modifiedObject = component.gameObject;
                }

                if (modifiedObject != null && modifiedObject.activeInHierarchy)
                {
                    k_SimulatedObjects.Clear();
                    modifiedObject.GetComponentsInChildren(k_SimulatedObjects);
                    foreach (var simulatedObject in k_SimulatedObjects)
                    {
                        OnObjectChanged(simulatedObject);
                    }
                }
            }

            return modifications;
        }

        void OnUndoRedoPerformed()
        {
            var selectedTransforms = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.ExcludePrefab);
            foreach (var selected in selectedTransforms)
            {
                if (selected.gameObject.activeInHierarchy)
                {
                    k_SimulatedObjects.Clear();
                    selected.GetComponentsInChildren(k_SimulatedObjects);
                    foreach (var simulatedObject in k_SimulatedObjects)
                    {
                        OnObjectChanged(simulatedObject);
                    }
                }
            }
        }
    }
}
#endif
