using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Represents features of the hardware and software SDKs, used in a request for what the app needs vs. what is available
    /// </summary>
    [Serializable]
    public class Capabilities : ISerializationCallbackReceiver
    {
        [SerializeField]
        List<SerializedTraitRequirement> m_TraitRequirements;

        [SerializeField]
        CameraFacingDirection m_RequiredCameraFacing;

        HashSet<TraitRequirement> m_TraitRequirementsSet = new HashSet<TraitRequirement>();

        /// <summary>
        /// If the experience requires cloud data
        /// </summary>
        public bool cloudSupport;

        /// <summary>
        /// A set of exact traits that must be supported
        /// </summary>
        public HashSet<TraitRequirement> TraitRequirements => m_TraitRequirementsSet;

        /// <summary>
        /// The required camera facing direction
        /// </summary>
        public CameraFacingDirection RequiredCameraFacing
        {
            get => m_RequiredCameraFacing;
            set => m_RequiredCameraFacing = value;
        }

        /// <inheritdoc />
        public void OnBeforeSerialize()
        {
            if(m_TraitRequirementsSet != null)
                m_TraitRequirements = m_TraitRequirementsSet.Select(r => new SerializedTraitRequirement(r)).ToList();
        }

        /// <inheritdoc />
        public void OnAfterDeserialize()
        {
            if (m_TraitRequirements != null)
            {
                var typed = m_TraitRequirements.Select(r =>
                {
                    if (r.TypeName != null)
                        return TraitRequirement.FromSerialized(r);

                    Debug.LogWarningFormat("missing type name for trait {0}", r.TraitName);
                    return null;
                }).ToList();
                m_TraitRequirementsSet = new HashSet<TraitRequirement>(typed);
            }
            else
            {
                m_TraitRequirementsSet = new HashSet<TraitRequirement>();
            }
        }

        /// <summary>
        /// Adds features from another Capabilities to this set of features
        /// </summary>
        /// <param name="other">Capabilities to add</param>
        public void AddCapabilities(Capabilities other)
        {
            cloudSupport |= other.cloudSupport;

            if (m_TraitRequirementsSet == null)
                m_TraitRequirementsSet = other.m_TraitRequirementsSet;
            else if (other.m_TraitRequirementsSet != null)
                m_TraitRequirementsSet.UnionWith(other.m_TraitRequirementsSet);
        }
    }
}
