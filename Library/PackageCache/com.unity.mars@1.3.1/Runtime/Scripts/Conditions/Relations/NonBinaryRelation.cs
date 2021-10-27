using UnityEngine;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Base class for all relations which have a match rating beyond simple pass/fail
    /// </summary>
    [RequireComponent(typeof(ProxyGroup))]
    public abstract class NonBinaryRelation<TRange, TTrait> : Relation<TTrait>, IConfigurableMatchRating,
        IRangeBoundingOptions<TRange>
    {
        [SerializeField]
        protected bool m_MinBounded = true;

        [SerializeField]
        protected bool m_MaxBounded = true;

        [SerializeField]
        [Tooltip("Sets the minimum value accepted for a match between the two child objects")]
        protected TRange m_Minimum;

        [SerializeField]
        [Tooltip("Sets the maximum value accepted for a match between the two child objects")]
        protected TRange m_Maximum;

        // hiding this in the inspector should be temporary - eventually we want to move
        // the curve drawer UI into an inspector for this.
        [SerializeField][HideInInspector]
        protected RatingConfiguration m_RatingConfig = new RatingConfiguration(0.25f);

        public bool noMinMaxWarning { get; protected set; }
        public bool smallMinMaxRangeWarning { get; protected set; }

        public RatingConfiguration ratingConfig
        {
            get { return m_RatingConfig; }
            set
            {
                m_RatingConfig = value;
                // usually after we change the rating config, we want to cache some values
                // that will later be used in calculating match ratings
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

        /// <summary>
        /// Minimum value accepted for a match between the two child objects
        /// </summary>
        public TRange minimum
        {
            get { return m_Minimum; }
            set
            {
                m_Minimum = value;
                OnRatingConfigChange();
            }
        }

        /// <summary>
        /// Maximum value accepted for a match between the two child objects
        /// </summary>
        public TRange maximum
        {
            get { return m_Maximum; }
            set
            {
                m_Maximum = value;
                OnRatingConfigChange();
            }
        }

#if UNITY_EDITOR
        public override void OnValidate()
        {
            base.OnValidate();
            noMinMaxWarning = !minBounded && !maxBounded;
        }
#endif

        public virtual void OnRatingConfigChange() { }
    }
}
