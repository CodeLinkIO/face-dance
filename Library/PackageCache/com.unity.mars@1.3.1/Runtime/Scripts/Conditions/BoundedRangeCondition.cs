using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Base class for all conditions which have a match rating beyond simple pass/fail
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public abstract class BoundedRangeCondition : Condition, IConfigurableMatchRating, IRangeBoundingOptions
    {
        [SerializeField]
        protected bool m_MinBounded = true;

        [SerializeField]
        protected bool m_MaxBounded = true;

        [SerializeField][HideInInspector]
        protected RatingConfiguration m_RatingConfig = new RatingConfiguration(0.25f);

        public virtual RatingConfiguration ratingConfig
        {
            get { return m_RatingConfig; }
            set
            {
                m_RatingConfig = value;
                OnRatingConfigChange();
            }
        }

        public bool minBounded
        {
            get { return m_MinBounded; }
            set { m_MinBounded = value; }
        }

        public bool maxBounded
        {
            get { return m_MaxBounded; }
            set { m_MaxBounded = value; }
        }

        public virtual void OnRatingConfigChange() { }

        public virtual void ScaleParameters(float scale) { }
    }

    public abstract class BoundedRangeCondition<TData> : Condition<TData>, IConfigurableMatchRating, IRangeBoundingOptions
    {
        [SerializeField]
        protected bool m_MinBounded = true;

        [SerializeField]
        protected bool m_MaxBounded = true;

        [SerializeField][HideInInspector]
        protected RatingConfiguration m_RatingConfig = new RatingConfiguration(0.25f);

        public virtual RatingConfiguration ratingConfig
        {
            get { return m_RatingConfig; }
            set
            {
                m_RatingConfig = value;
                OnRatingConfigChange();
            }
        }

        public bool minBounded
        {
            get { return m_MinBounded; }
            set { m_MinBounded = value; }
        }

        public bool maxBounded
        {
            get { return m_MaxBounded; }
            set { m_MaxBounded = value; }
        }

        public virtual void OnRatingConfigChange() { }

        public virtual void ScaleParameters(float scale) { }
    }
}
