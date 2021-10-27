using System.Collections.Generic;
using Unity.MARS.Data;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// Creates MARS proxy groups and suggests relations based on the traits available on the group members
    /// </summary>
    [MovedFrom("Unity.MARS")]
    class CreateProxyGroupFromData : CreateFromDataBase
    {
        List<PotentialChild> m_PotentialGroupMembers = new List<PotentialChild>();
        readonly List<PotentialRelation> m_PotentialRelations = new List<PotentialRelation>();

        internal List<PotentialChild> PotentialGroupMembers => m_PotentialGroupMembers;
        internal List<PotentialRelation> PotentialRelations => m_PotentialRelations;
        internal GameObject CreatedGameObject => m_CreatedObject;

        internal ProxyGroup CreateNewProxyGroup(List<PotentialChild> children)
        {
            m_PotentialGroupMembers = children;
            var group = CreateProxyGroupObject();
            m_PotentialRelations.Clear();
            TraitDataSnapshot.GetPotentialRelations(m_PotentialGroupMembers, m_PotentialRelations, m_CreatedObject);
            SetProxyGroupName(GenerateProxyGroupName());
            return group;
        }

        internal void SetProxyGroupName(string newName)
        {
            if (m_CreatedObject != null)
                m_CreatedObject.name = newName;
        }

        internal string GenerateProxyGroupName()
        {
            return "New Proxy Group";
        }

        ProxyGroup CreateProxyGroupObject()
        {
            m_CreatedObject = new GameObject(GenerateProxyGroupName());
            m_CreatedObject.transform.SetParent(ObjectParent);

            if (Replicate)
                SetupReplicator();

            var createProxy1 = new CreateProxyFromData();
            createProxy1.Replicate = false;
            createProxy1.ObjectParent = m_CreatedObject.transform;
            createProxy1.CreateImmediately(m_PotentialGroupMembers[0].sourceObject);
            m_PotentialGroupMembers[0].createProxyFromData = createProxy1;

            var createProxy2 = new CreateProxyFromData();
            createProxy2.Replicate = false;
            createProxy2.ObjectParent = m_CreatedObject.transform;
            createProxy2.CreateImmediately(m_PotentialGroupMembers[1].sourceObject);
            m_PotentialGroupMembers[1].createProxyFromData = createProxy2;

            var proxyGroup = m_CreatedObject.AddComponent<ProxyGroup>();
            proxyGroup.RepopulateChildList();
            proxyGroup.ApplyHueToChildren();
            return proxyGroup;
        }
    }
}
