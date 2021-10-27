using System;
using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    abstract class SliderHandleBase : InteractiveHandle
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

        Vector3 m_InitialPosWorld;
        Vector3 m_InitialPosLocal;
        Vector3 m_TotalTranslation;
        Vector3 m_CurrentDirection;

        /// <summary>
        /// Called when a translation begins.
        /// </summary>
        /// <param name="translationInfo">The initial screen drag information.</param>
        protected virtual void OnTranslationBegin(DragTranslation translationInfo)
        {
        }

        /// <summary>
        /// Called when a translation ends.
        /// </summary>
        /// <param name="translationInfo">The last screen drag information.</param>
        protected virtual void OnTranslationEnd(DragTranslation translationInfo)
        {
        }

        /// <summary>
        /// Get the delta of the current translation. The delta is in world space.
        /// </summary>
        /// <param name="translationInfo">The information of the drag.</param>
        /// <param name="sourcePos">The original position of the handle when the translation was started.</param>
        /// <returns>The delta since last translation in world space.</returns>
        protected abstract Vector3 GetWorldTranslationDelta(DragTranslation translationInfo,  Vector3 sourcePos);

        protected override void DragBegin(InteractiveHandle target, DragBeginInfo info)
        {
            if (target != ownerHandle)
                return;

            m_InitialPosWorld = info.translation.initialPosition;
            m_InitialPosLocal = Quaternion.Inverse(transform.localRotation) * transform.localPosition;
            m_TotalTranslation = Vector3.zero;
            if (translationBegun != null)
            {
                translationBegun.Invoke(new TranslationBeginInfo(
                    //World
                    new TranslationInfo(
                        m_InitialPosWorld,
                        Vector3.zero,
                        Vector3.zero,
                        transform.forward),

                    //Local
                    new TranslationInfo(
                        m_InitialPosLocal,
                        Vector3.zero,
                        Vector3.zero,
                        transform.localRotation * Vector3.forward)));
            }

            OnTranslationBegin(info.translation);
        }

        protected override void DragUpdate(InteractiveHandle target, DragUpdateInfo info)
        {
            if (target != ownerHandle)
                return;

            var delta = GetWorldTranslationDelta(info.translation, m_InitialPosWorld);
            m_TotalTranslation = m_TotalTranslation + delta;
            m_CurrentDirection = delta.normalized;

            var inverseRotation = Quaternion.Inverse(transform.rotation);

            if (translationUpdated != null)
            {
                translationUpdated.Invoke(new TranslationUpdateInfo(
                    //World
                    new TranslationInfo(
                        m_InitialPosWorld,
                        delta,
                        m_TotalTranslation,
                        m_CurrentDirection),

                    //Local
                    new TranslationInfo(
                        m_InitialPosLocal,
                        inverseRotation * delta,
                        inverseRotation * m_TotalTranslation,
                        inverseRotation * m_CurrentDirection)
                ));
            }
        }

        protected override void DragEnd(InteractiveHandle target, DragEndInfo info)
        {
            if (target != ownerHandle)
                return;

            if (translationEnded != null)
            {
                translationEnded.Invoke(new TranslationEndInfo(
                    //World
                    new TranslationInfo(
                        m_InitialPosWorld,
                        Vector3.zero,
                        m_TotalTranslation,
                        Vector3.zero),

                    //Local
                    new TranslationInfo(
                        m_InitialPosLocal,
                        Vector3.zero,
                        Quaternion.Inverse(transform.rotation) * m_TotalTranslation,
                        Vector3.zero)));
            }

            m_CurrentDirection = Vector3.zero;
            m_TotalTranslation = Vector3.zero;
            OnTranslationEnd(info.translation);
        }
    }
}