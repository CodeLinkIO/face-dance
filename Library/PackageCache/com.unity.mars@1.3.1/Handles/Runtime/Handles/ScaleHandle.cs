using System;
using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    [ExecuteInEditMode]
    [AddComponentMenu("")]
    sealed class ScaleHandle : MonoBehaviour
    {
        public Action scalingBegun;
        public Action<ScalingUpdatedInfo> scaleUpdated;
        public Action scalingEnded;

        [SerializeField] SliderHandleBase[] m_Sliders = new SliderHandleBase[0];

        void Awake()
        {
            foreach (var s in m_Sliders)
            {
                var slider = s;
                slider.translationBegun += (info) => TranslationBegun(slider, info);
                slider.translationUpdated += (info) => TranslationUpdated(slider, info);
                slider.translationEnded += (info) => TranslationEnded(slider, info);
            }
        }

        void TranslationBegun(SliderHandleBase slider, TranslationBeginInfo info)
        {
            if (scalingBegun != null) scalingBegun.Invoke();
        }

        void TranslationUpdated(SliderHandleBase slider, TranslationUpdateInfo info)
        {
            if (scaleUpdated != null) scaleUpdated.Invoke(new ScalingUpdatedInfo
            (
                new ScalingInfo(  //World
                    Vector3.one,
                    GetScaleFromTranslation(info.world.delta),
                    GetScaleFromTranslation(info.world.total)),
                new ScalingInfo(  //Local
                    Vector3.one,
                    GetScaleFromTranslation(info.local.delta),
                    GetScaleFromTranslation(info.local.total))
            ));
        }

        void TranslationEnded(SliderHandleBase slider, TranslationEndInfo info)
        {
            if (scalingEnded != null) scalingEnded.Invoke();
        }

        Vector3 GetScaleFromTranslation(Vector3 translation)
        {
            return translation;
        }
    }
}
