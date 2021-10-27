using System;
using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    [ExecuteInEditMode]
    [AddComponentMenu("")]
    sealed class PositionHandle : MonoBehaviour
    {
        /// <summary>
        /// Event sent when a translation of the handle begins.
        /// </summary>
        public event Action<TranslationBeginInfo> translationBegun;

        /// <summary>
        /// Event sent when a translation of the handle updates.
        /// </summary>
        public event Action<TranslationUpdateInfo> translationUpdated;

        /// <summary>
        /// Event sent when a translation of the handle ends.
        /// </summary>
        public event Action<TranslationEndInfo> translationEnded;

        [SerializeField] SliderHandleBase[] m_Sliders = new SliderHandleBase[0];

        void Awake()
        {
            foreach (var slider in m_Sliders)
            {
                if (slider == null)
                    continue;

                slider.translationBegun += OnTranslationBegun;
                slider.translationUpdated += OnTranslationUpdated;
                slider.translationEnded += OnTranslationEnded;
            }
        }

        void OnTranslationBegun(TranslationBeginInfo info)
        {
            if (translationBegun != null) translationBegun.Invoke(info);
        }

        void OnTranslationUpdated(TranslationUpdateInfo info)
        {
            if (translationUpdated != null) translationUpdated.Invoke(info);
        }

        void OnTranslationEnded(TranslationEndInfo info)
        {
            if (translationEnded != null) translationEnded.Invoke(info);
        }
    }
}
