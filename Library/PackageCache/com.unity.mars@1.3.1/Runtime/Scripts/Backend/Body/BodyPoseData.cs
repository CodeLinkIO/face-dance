using System;
using UnityEngine;

namespace Unity.MARS.Data
{
    internal enum BodyData
    {
        Hips = 0,
        Spine = 1,
        Chest = 2,
        UpperChest = 3,
        Neck = 4,
        Head = 5,

        RightShoulder = 6,
        RightUpperArm = 7,
        RightLowerArm = 8,

        LeftShoulder = 9,
        LeftUpperArm = 10,
        LeftLowerArm = 11,

        RightUpperLeg = 12,
        RightLowerLeg = 13,

        LeftUpperLeg = 14,
        LeftLowerLeg = 15
    }

    /// <summary>
    /// This class stores muscle data for body poses.
    /// This class contains two arrays: one float array that contains the muscle data, and a second equal-size array
    /// that describes if that muscle is relevant to the created pose (for example, a seated pose takes into account the legs,
    /// but not the arms or anything above the hips).
    /// </summary>
    [Serializable]
    internal class BodyPoseData : ScriptableObject
    {
        [SerializeField]
        string m_BodyPoseName;

        [SerializeField]
        float[] m_MusclesData;

        // This array is used to hide irrelevant muscles for the body pose data in the inspector
        // because getting muscle names when drawn in the inspector UI are tied to an index
        [SerializeField]
        bool[] m_MuscleRelevantData;

        [SerializeField]
        Vector3[] m_BoneOrientations;

        // This array is used to selectively check for poses on specific body members
        // like left leg, left arm, head, etc
        [SerializeField]
        bool[] m_RelevantBonesData;

#pragma warning disable 414
        [SerializeField]
        bool m_TrackCenterLine = true;

        [SerializeField]
        bool m_TrackRightArm = true;

        [SerializeField]
        bool m_TrackLeftArm = true;

        [SerializeField]
        bool m_TrackRightLeg = true;

        [SerializeField]
        bool m_TrackLeftLeg = true;
#pragma warning restore 414

        internal string BodyPoseName { get => m_BodyPoseName; }
        internal float[] Muscles { get => m_MusclesData; }
        internal bool[] MuscleRelevantData { get => m_MuscleRelevantData; }
        internal Vector3[] BonesOrientations { get => m_BoneOrientations; }

        internal bool[] RelevantBoneData { get => m_RelevantBonesData; }

        internal bool TrackCenterLine { get => m_TrackCenterLine; }
        internal bool TrackRightArm { get => m_TrackRightArm; }
        internal bool TrackLeftArm { get => m_TrackLeftArm; }
        internal bool TrackRightLeg { get => m_TrackRightLeg; }
        internal bool TrackLeftLeg { get => m_TrackLeftLeg; }

        internal void Init(string name, float[] muscles, bool[] relevant, Vector3[] bonesOrientations, bool[] relevantBones,
            bool trackCenterLine = true, bool trackRightArm = true, bool trackLeftArm = true, bool trackRightLeg = true, bool trackLeftLeg = true)
        {
            m_BodyPoseName = name;

            m_MusclesData = muscles;
            m_MuscleRelevantData = relevant;
            m_BoneOrientations = bonesOrientations;
            m_RelevantBonesData = relevantBones;

            m_TrackCenterLine = trackCenterLine;
            m_TrackRightArm = trackRightArm;
            m_TrackLeftArm = trackLeftArm;
            m_TrackRightLeg = trackRightLeg;
            m_TrackLeftLeg = trackLeftLeg;
        }
    }
}
