using System;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// Class for managing suggested component type to add to a gameobject
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class PotentialComponent
    {
        internal Type componentType;
        internal Component createdComponent;

        GameObject m_GameObjectOwner;
        bool m_Use;

        internal int order;

        internal GameObject gameObjectOwner
        {
            get => m_GameObjectOwner;
            set
            {
                if (m_GameObjectOwner == value)
                    return;

                m_GameObjectOwner = value;
                if (m_GameObjectOwner == null)
                    return;

                FindComponentOnOwner();
                m_Use = createdComponent != null;
            }
        }

        internal virtual string valueString => "";

        internal bool use
        {
            get => m_Use;
            set
            {
                if (m_Use == value)
                    return;

                m_Use = value;
                UpdateComponent();
            }
        }

        internal virtual void UpdateComponent()
        {
            if (m_Use)
            {
                if (m_GameObjectOwner != null && createdComponent == null)
                {
                    SetupComponent();
                }
            }
            else
            {
                if (createdComponent != null)
                    UnityObjectUtils.Destroy(createdComponent);
            }
        }

        protected virtual void FindComponentOnOwner()
        {
            if (componentType == null)
                return;

            createdComponent = m_GameObjectOwner.GetComponent(componentType);
        }

        protected virtual void SetupComponent() { }
    }

    /// <summary>
    /// Class for managing a suggested condition component
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class PotentialCondition : PotentialComponent
    {
        internal TraitDataSnapshot data;

        internal override string valueString
        {
            get
            {
                var component = createdComponent as ICreateFromData;
                return component?.FormatDataString(data);
            }
        }

        protected override void SetupComponent()
        {
            createdComponent = gameObjectOwner.AddComponent(componentType);
            var component = createdComponent as ICreateFromData;
            component?.OptimizeForData(data);
        }
    }

    /// <summary>
    /// Class for managing a suggested tag condition. This needs to be different from other conditions because
    /// there can be multiple tag conditions with different trait names on the same gameObject
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class PotentialTagCondition: PotentialCondition
    {
        internal string tagName;

        protected override void SetupComponent()
        {
            // Don't call base.SetupComponent because tag conditions need their trait name set
            var tagCondition = gameObjectOwner.AddComponent<SemanticTagCondition>();
            createdComponent = tagCondition;

            tagCondition.SetTraitName(tagName);
        }

        protected override void FindComponentOnOwner()
        {
            var tagConditions = gameObjectOwner.GetComponents<SemanticTagCondition>();
            foreach (var condition in tagConditions)
            {
                if (condition.traitName == tagName)
                {
                    createdComponent = condition;
                    return;
                }
            }
        }
    }

    /// <summary>
    /// Class for managing a suggested relation between 2 members of a proxy group
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class PotentialRelation: PotentialComponent
    {
        internal TraitDataSnapshot traits1;
        internal TraitDataSnapshot traits2;

        internal override string valueString
        {
            get
            {
                var component = createdComponent as ICreateFromDataPair;
                return component?.FormatDataString(traits1, traits2);
            }
        }

        protected override void SetupComponent()
        {
            base.SetupComponent();
            createdComponent = gameObjectOwner.AddComponent(componentType);
            var component = createdComponent as ICreateFromDataPair;
            component?.OptimizeForData(traits1, traits2);
        }
    }
}
