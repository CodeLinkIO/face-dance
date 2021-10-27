using System;
using System.Collections.Generic;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Providers
{
    class ARKitBodyRigSettings : ScriptableSettings<ARKitBodyRigSettings>
    {
#pragma warning disable 649
        [SerializeField]
        GameObject m_ControlRigPrefab;

        [SerializeField]
        string m_ControlRigRootName;
#pragma warning restore 649

        Transform[] m_BoneMapping;

        internal Transform[] GenerateJointMapping(GameObject rigPrefab = null)
        {
            if (rigPrefab == null)
                rigPrefab = m_ControlRigPrefab;

            m_BoneMapping = new Transform[ARKitJointIndices.Total];

            // Walk through all the child joints in the skeleton and
            // store the skeleton joints at the corresponding index in the m_BoneMapping array.
            // This assumes that the bones in the skeleton are named as per the
            // JointIndices enum above.
            var nodes = new Queue<Transform>();
            nodes.Enqueue(rigPrefab.GetNamedChild(m_ControlRigRootName).transform.parent);

            while (nodes.Count > 0)
            {
                var next = nodes.Dequeue();
                for (var i = 0; i < next.childCount; ++i)
                {
                    nodes.Enqueue(next.GetChild(i));
                }

                ProcessJoint(next);
            }

            return m_BoneMapping;
        }

        void ProcessJoint(Transform joint)
        {
            var index = GetJointIndex(joint.name);
            if (index >= 0 && index < ARKitJointIndices.Total)
            {
                m_BoneMapping[index] = joint;
            }
            else
            {
                Debug.LogWarning($"{joint.name} was not found.");
            }
        }

        // Returns the integer value corresponding to the JointIndices enum value
        // passed in as a string.
        static int GetJointIndex(string jointName)
        {
            ARKitJointIndices.NameToIndex val;
            if (Enum.TryParse(jointName, out val))
            {
                return (int)val;
            }

            return -1;
        }

        internal GameObject ControlRig { get { return m_ControlRigPrefab; } }
    }
}
