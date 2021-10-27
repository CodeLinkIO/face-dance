using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Forces
{
    internal struct ProxyForceFieldMotion
    {
        public Pose location;
        public Pose velocity;

        public ProxyForceFieldMotion(Pose location, Pose velocity)
        {
            this.location = location;
            this.velocity = velocity;
        }

        public static ProxyForceFieldMotion identity = new ProxyForceFieldMotion(Pose.identity, Pose.identity);
    }

    internal struct ProxyForceFieldId : System.IEquatable<ProxyForceFieldId>, System.IComparable<ProxyForceFieldId>
    {
        readonly int m_FieldId;

        static int s_GeneratorIndex = 1;

        public static ProxyForceFieldId GenerateNew()
        {
            var id = (s_GeneratorIndex++);
            return new ProxyForceFieldId(id);
        }

        public static ProxyForceFieldId DefaultUnknown { get { return new ProxyForceFieldId(); } }

        ProxyForceFieldId(int _id) { m_FieldId = _id; }

        public bool IsValid => (m_FieldId != 0);

        public bool Equals(ProxyForceFieldId other)
        {
            return (m_FieldId == other.m_FieldId);
        }

        public override int GetHashCode()
        {
            return m_FieldId.GetHashCode();
        }

        public override string ToString()
        {
            return "FieldSolverId_" + m_FieldId.ToString();
        }

        public int CompareTo(ProxyForceFieldId other)
        {
            return m_FieldId.CompareTo(other.m_FieldId);
        }
    }

    [MovedFrom("Unity.MARS.Forces.ForceDefinitions")]
    public static class ProxyForceMotionTypeUtils
    {
        public static bool IsMoving(this ProxyForceMotionType mt)
        {
            return (mt != ProxyForceMotionType.NotForced);
        }

        internal static ProxyForceFieldMotion TrimMotionUpdate(this ProxyForceMotionType mt, ProxyForceFieldMotion oldMotion, ProxyForceFieldMotion newMotion)
        {
            var newPose = mt.TrimPoseUpdate(oldMotion.location, newMotion.location);
            var ans = newMotion;
            ans.location = newPose;
            return ans;
        }

        public static Pose TrimPoseUpdate(this ProxyForceMotionType mt, Pose oldPose, Pose newPose)
        {
            Pose result;
            if (mt == ProxyForceMotionType.NotForced)
            {
                result = oldPose;
            }
            else if (mt == ProxyForceMotionType.MoveAndRotateFreely)
            {
                result = newPose;
            }
            else if (mt == ProxyForceMotionType.MoveAndRotateY)
            {
                result = newPose;
                var newAngles = newPose.rotation.eulerAngles;
                result.rotation = Quaternion.Euler(0, newAngles.y, 0);
            }
            else if (mt == ProxyForceMotionType.MoveAndRotateZ)
            {
                result = newPose;
                var newAngles = newPose.rotation.eulerAngles;
                result.rotation = Quaternion.Euler(0, 0, newAngles.z);
            }
            else
            {
                throw new System.NotImplementedException("TODO: " + mt);
            }
            return result;
        }
    }
}
