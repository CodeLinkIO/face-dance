using Unity.MARS.Query;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Base class for all types of MultiConditions to ensure they get the proper inspector
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public abstract class MultiConditionBase : ConditionBase, IComponentHost<ICondition>
    {
        protected ICondition[] m_HostedComponents;

        public ICondition[] HostedComponents
        {
            get { return m_HostedComponents; }
        }
    }

    /// <summary>
    /// Base class for conditions that interact with two traits at once
    /// This handles all the necessary wiring of making sure the SubConditions are properly serialized, available for queries
    /// and that each SubCondition has a proper reference back to the host
    /// </summary>
    /// <typeparam name="TCondition1">The type of the first SubCondition</typeparam>
    /// <typeparam name="TCondition2">The type of the second SubCondition</typeparam>
    public class MultiCondition<TCondition1, TCondition2> : MultiConditionBase, ISerializationCallbackReceiver where TCondition1 : SubCondition, ICondition, new() where TCondition2 : SubCondition, ICondition, new()
    {
        [SerializeField]
        protected TCondition1 m_Condition1 = new TCondition1();

        [SerializeField]
        protected TCondition2 m_Condition2 = new TCondition2();

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            m_Condition1.Host = this;
            m_Condition2.Host = this;
            m_HostedComponents = new ICondition[] { m_Condition1, m_Condition2 };
        }
        public MultiCondition()
        {
            m_Condition1.Host = this;
            m_Condition2.Host = this;
            m_HostedComponents = new ICondition[] { m_Condition1, m_Condition2 };
        }
    }

    /// <summary>
    /// Base class for conditions that interact with three traits at once
    /// This handles all the necessary wiring of making sure the SubConditions are properly serialized, available for queries
    /// and that each SubCondition has a proper reference back to the host
    /// </summary>
    /// <typeparam name="TCondition1">The type of the first SubCondition</typeparam>
    /// <typeparam name="TCondition2">The type of the second SubCondition</typeparam>
    /// <typeparam name="TCondition3">The type of the third SubCondition</typeparam>
    public class MultiCondition<TCondition1, TCondition2, TCondition3> : MultiConditionBase, ISerializationCallbackReceiver where TCondition1 : SubCondition, ICondition, new() where TCondition2 : SubCondition, ICondition, new() where TCondition3 : SubCondition, ICondition, new()
    {
        [SerializeField]
        protected TCondition1 m_Condition1 = new TCondition1();

        [SerializeField]
        protected TCondition2 m_Condition2 = new TCondition2();

        [SerializeField]
        protected TCondition3 m_Condition3 = new TCondition3();

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            m_Condition1.Host = this;
            m_Condition2.Host = this;
            m_Condition3.Host = this;
            m_HostedComponents = new ICondition[] { m_Condition1, m_Condition2, m_Condition3 };
        }

        public MultiCondition()
        {
            m_Condition1.Host = this;
            m_Condition2.Host = this;
            m_Condition3.Host = this;
            m_HostedComponents = new ICondition[] { m_Condition1, m_Condition2, m_Condition3 };
        }
    }
}
