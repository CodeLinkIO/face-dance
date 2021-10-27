using Unity.MARS.Query;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Base class for all types of MultiRelations to ensure they get the proper inspector
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public abstract class MultiRelationBase : RelationBase, IComponentHost<IRelation>
    {
        protected IRelation[] m_HostedComponents;

        public IRelation[] HostedComponents => m_HostedComponents ?? (m_HostedComponents = new IRelation[0]);

        public abstract void SetChildren(Proxy context1, Proxy context2);
    }

    /// <summary>
    /// Base class for conditions that interact with two traits at once
    /// This handles all the necessary wiring of making sure the SubRelations are properly serialized, available for queries
    /// and that each SubRelation has a proper reference back to the host
    /// </summary>
    /// <typeparam name="TRelation1">The type of the first SubRelation</typeparam>
    /// <typeparam name="TRelation2">The type of the second SubRelation</typeparam>
    public class MultiRelation<TRelation1, TRelation2> : MultiRelationBase, ISerializationCallbackReceiver
        where TRelation1 : SubRelation, IRelation, new()
        where TRelation2 : SubRelation, IRelation, new()
    {
        [SerializeField]
        protected TRelation1 m_Relation1 = new TRelation1();

        [SerializeField]
        protected TRelation2 m_Relation2 = new TRelation2();

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            m_Relation1.Host = this;
            m_Relation2.Host = this;
            m_HostedComponents = new IRelation[] { m_Relation1, m_Relation2 };
        }

        public override void SetChildren(Proxy context1, Proxy context2)
        {
            m_Relation1.SetChildren(context1, context2);
            m_Relation2.SetChildren(context1, context2);
        }
    }

    /// <summary>
    /// Base class for conditions that interact with three traits at once
    /// This handles all the necessary wiring of making sure the SubRelations are properly serialized, available for queries
    /// and that each SubRelation has a proper reference back to the host
    /// </summary>
    /// <typeparam name="TRelation1">The type of the first SubRelation</typeparam>
    /// <typeparam name="TRelation2">The type of the second SubRelation</typeparam>
    /// <typeparam name="TRelation3">The type of the third SubRelation</typeparam>
    public class MultiRelation<TRelation1, TRelation2, TRelation3> : MultiRelationBase, ISerializationCallbackReceiver
        where TRelation1 : SubRelation, IRelation, new()
        where TRelation2 : SubRelation, IRelation, new()
        where TRelation3 : SubRelation, IRelation, new()
    {
        [SerializeField]
        protected TRelation1 m_Relation1 = new TRelation1();

        [SerializeField]
        protected TRelation2 m_Relation2 = new TRelation2();

        [SerializeField]
        protected TRelation3 m_Relation3 = new TRelation3();

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            m_Relation1.Host = this;
            m_Relation2.Host = this;
            m_Relation3.Host = this;
            m_HostedComponents = new IRelation[] { m_Relation1, m_Relation2, m_Relation3 };
        }

        public override void SetChildren(Proxy context1, Proxy context2)
        {
            m_Relation1.SetChildren(context1, context2);
            m_Relation2.SetChildren(context1, context2);
            m_Relation3.SetChildren(context1, context2);
        }
    }
}
