using System;
using System.Collections.Generic;
using Unity.MARS.Simulation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

#if UNITY_EDITOR
#if UNITY_2021_2_OR_NEWER
using UnityEditor.SceneManagement;
#else
using UnityEditor.Experimental.SceneManagement;
#endif
#endif

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// A mesh that handles objects being hovered over it and being dropped onto it.
    /// </summary>
    [ExecuteInEditMode]
    [MovedFrom("Unity.MARS")]
    public class InteractionTarget : MonoBehaviour
    {
        public enum InteractionState
        {
            None,
            Hovered,
            Selected
        }

        static readonly HashSet<InteractionTarget> k_AllInteractionTargets = new HashSet<InteractionTarget>();

#if UNITY_EDITOR
        static PrefabStage s_LastPrefabStage;
        static bool s_LastStageIsEnvironment;
#endif

        [SerializeField]
        Transform m_AttachTarget;

        bool m_UseInteractionTarget = true;
        protected InteractionState m_State = InteractionState.None;
        protected bool m_Selected;
        protected bool m_Hovered;

        public static HashSet<InteractionTarget> AllTargets { get { return k_AllInteractionTargets; } }

        public bool UseInteractionTarget { get { return m_UseInteractionTarget && m_AttachTarget != null && enabled; } }

        /// <summary>
        /// Action that is called when the interaction state of the interaction target has changed
        /// </summary>
        public event Action<InteractionState> interactionStateChanged;

        /// <summary>
        /// The transform that objects will be attached to when they are dropped on this object's mesh
        /// </summary>
        public Transform AttachTarget
        {
            get { return m_AttachTarget; }
            set { m_AttachTarget = value; }
        }

        protected virtual void OnEnable()
        {
            k_AllInteractionTargets.Add(this);

#if UNITY_EDITOR
            // If the target is part of a simulated environment in a prefab stage don't use it.
            var stage = PrefabStageUtility.GetPrefabStage(gameObject);
            if (stage != null)
            {
                // Check to see if the prefab stage has been checked
                if (stage == s_LastPrefabStage)
                {
                    // Do not use interaction targets in sim scene isolation
                    if (s_LastStageIsEnvironment)
                        m_UseInteractionTarget = false;
                }
                else
                {
                    // Check if the stage has env settings
                    var settings = GetComponentInParent<MARSEnvironmentSettings>();
                    if (settings != null)
                    {
                        m_UseInteractionTarget = false;
                        s_LastStageIsEnvironment = true;
                    }

                    s_LastPrefabStage = stage;
                }
            }
            else
            {
                s_LastStageIsEnvironment = false;
                s_LastPrefabStage = null;
            }
#endif
        }

        void OnDisable()
        {
            k_AllInteractionTargets.Remove(this);
        }

        /// <summary>
        /// Set the hover state of the interaction target
        /// </summary>
        /// <param name="newHoverState"> Whether the target is currently hovered</param>
        public void SetHovered(bool newHoverState)
        {
            m_Hovered = newHoverState;

            if (m_Hovered && m_State == InteractionState.None)
            {
                m_State = InteractionState.Hovered;
                OnStateChanged();
            }
            else if (!m_Hovered && m_State == InteractionState.Hovered)
            {
                m_State = m_Selected ? InteractionState.Selected : InteractionState.None;
                OnStateChanged();
            }

        }

        /// <summary>
        /// Set the selected state of the interaction target
        /// </summary>
        /// <param name="isSelected"> Whether the target is currently selected</param>
        public void SetSelected(bool isSelected)
        {
            m_Selected = isSelected;
            if (m_Selected && m_State != InteractionState.Selected)
            {
                m_State = InteractionState.Selected;
                OnStateChanged();
            }
            else if (!m_Selected && m_State == InteractionState.Selected)
            {
                m_State = m_Hovered ? InteractionState.Hovered : InteractionState.None;
                OnStateChanged();
            }
        }

        /// <summary>
        /// Called by MARS when the interaction state changes
        /// </summary>
        protected virtual void OnStateChanged()
        {
            if (interactionStateChanged != null)
                interactionStateChanged.Invoke(m_State);
        }
    }
}
