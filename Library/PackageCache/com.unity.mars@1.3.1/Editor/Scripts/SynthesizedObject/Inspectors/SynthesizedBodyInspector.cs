using Unity.MARS.Data;
using Unity.MARS.Data.Synthetic;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation;
using UnityEngine;
using UnityEngine.Playables;

namespace Unity.MARS
{
    [CustomEditor(typeof(SynthesizedBody))]
    class SynthesizedBodyInspector : Editor
    {
        SynthesizedBody m_SynthesizedBody;

        static GUIContent m_PlayButtonContent;
        static GUIContent m_PauseButtonContent;
        static GUIContent m_StopButtonContent;
        static GUIContent m_SavePose;
        static GUIContent m_OpenTimeline;

        void OnEnable()
        {
            m_PlayButtonContent = EditorGUIUtility.TrTextContentWithIcon(
                "Play", "Stops the current playable director animation (if any)", "PlayButton");
            m_PauseButtonContent = EditorGUIUtility.TrTextContentWithIcon(
                "Pause", "Pauses the current playable director animation (if any)", "PauseButton");
            m_StopButtonContent = EditorGUIUtility.TrTextContentWithIcon(
                "Stop", "Stops the current playable director animation (if any)", "PreMatQuad");

            m_OpenTimeline = new GUIContent(MarsUIResources.instance.BodyIconData.OpenTimelineIcon.Icon, "Opens the Timeline window. " +
                "You can scrub to a specific frame in the animation and use 'Save Pose' to create a pose from that frame.");
            m_SavePose = new GUIContent("Save Pose", "Saves the current pose on this synthetic object");

            m_SynthesizedBody = (SynthesizedBody) target;

            QuerySimulationModule.onTemporalSimulationStart += PlayAnimation;
            QuerySimulationModule.onTemporalSimulationStop += StopAnimation;
        }

        void OnDisable()
        {
            QuerySimulationModule.onTemporalSimulationStart -= PlayAnimation;
            QuerySimulationModule.onTemporalSimulationStop -= StopAnimation;
        }
        

        void PlayAnimation()
        {
            m_SynthesizedBody.Director.Play();
        }

        void StopAnimation()
        {
            m_SynthesizedBody.Director.Stop();
        }

        public override void OnInspectorGUI()
        {
            using (new GUILayout.HorizontalScope())
            {
                GUILayout.Label("Animation Playback", MarsEditorGUI.Styles.ResetLabelMarginStyle, GUILayout.Width(EditorGUIUtility.labelWidth));

                if (GUILayout.Button(m_PlayButtonContent, MarsEditorGUI.Styles.ResetButtonMarginStyle))
                {
                    PlayAnimation();
                    SceneView.RepaintAll();
                }

                GUILayout.Space(4);

                if (GUILayout.Button(m_PauseButtonContent, MarsEditorGUI.Styles.ResetButtonMarginStyle))
                {
                    m_SynthesizedBody.Director.Pause();
                }

                GUILayout.Space(4);

                if (GUILayout.Button(m_StopButtonContent, MarsEditorGUI.Styles.ResetButtonMarginStyle))
                {
                    StopAnimation();
                }
            }

            GUILayout.Space(2);

            using (new GUILayout.HorizontalScope())
            {
                GUILayout.Space(EditorGUIUtility.labelWidth);

                if (GUILayout.Button(m_OpenTimeline,
                    MarsEditorGUI.Styles.IconButtonNoMarginStyle,
                    MarsEditorGUI.MarsStyles.BindingButtonGUIOptions))
                {
                    EditorApplication.ExecuteMenuItem("Window/Sequencing/Timeline");
                }

                using (new GUILayout.VerticalScope())
                {
                    GUILayout.Space(4);
                    GUILayout.Label("Open Timeline");
                }
            }

            GUILayout.Space(4);

            using (new GUILayout.HorizontalScope())
            {
                GUILayout.Label("Extract Body Pose", MarsEditorGUI.Styles.ResetLabelMarginStyle, GUILayout.Width(EditorGUIUtility.labelWidth));

                if (GUILayout.Button(m_SavePose, MarsEditorGUI.Styles.ResetButtonMarginStyle))
                {
                    BodyTrackingModule.GenerateSerializedDataFromAvatar(m_SynthesizedBody.animator);
                }
            }
        }
    }
}
