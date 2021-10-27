using Unity.MARS.MARSUtils;
using UnityEngine;
using UnityEngine.Playables;

namespace Unity.MARS
{
    /// <summary>
    /// The Playable Director attached to this game object will pause and resume play based on whether
    /// temporal simulation is active or not.
    /// </summary>
    [ExecuteAlways]
    [HelpURL(DocumentationConstants.SimulatedPlayableDocs)]
    [RequireComponent(typeof(PlayableDirector))]
    class SimulatedPlayable : MonoBehaviour
    {
#if UNITY_EDITOR
        PlayableDirector m_PlayableDirector;

        void Awake()
        {
            m_PlayableDirector = GetComponent<PlayableDirector>();
        }

        void OnEnable()
        {
            var isSimulatingTemporal = EditorOnlyDelegates.IsSimulatingTemporal != null && EditorOnlyDelegates.IsSimulatingTemporal();
            if (Application.isPlaying || !isSimulatingTemporal)
                return;

            m_PlayableDirector.Pause();
        }

        void Update()
        {
            if (Application.isPlaying)
                return;

            if (!m_PlayableDirector.playableGraph.IsValid())
                return;

            var paused = !m_PlayableDirector.playableGraph.IsPlaying();
            var temporal = EditorOnlyDelegates.IsSimulatingTemporal();

            if (temporal && paused)
                m_PlayableDirector.Resume();
            else if (!temporal && !paused)
                m_PlayableDirector.Pause();
        }
#endif
    }
}
