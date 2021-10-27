using Unity.MARS.Conditions;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS
{
    abstract class ConditionRatingCurveDrawer<TCondition, TData> : RatingCurveDrawerBase<TCondition>
        where TCondition : BoundedRangeCondition<TData>, ICondition<TData>
    {
        public ConditionRatingCurveDrawer(TCondition condition, Vector2 textureSize) 
            : base(condition, textureSize)
        {
            m_HeaderLabel = typeof(TCondition).Name;
            m_Condition.ratingConfig = m_RatingConfig;
        }

        public void OnGUI()
        {
            OnGuiInternal();
        }
    }
}
