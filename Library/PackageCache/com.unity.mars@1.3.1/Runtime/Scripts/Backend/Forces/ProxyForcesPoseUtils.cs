using UnityEngine;


namespace Unity.MARS.Forces.ForceDefinitions
{
    internal static class PoseUtils
    {

        public static Vector3 WorldFromLocalPoint(Pose p , Vector3 v)
        {
            return (p.rotation * v) + p.position;
        }

        public static Vector3 WorldFromLocalVector(Pose p, Vector3 v)
        {
            return (p.rotation * v);
        }

        public static Quaternion WorldFromLocalQuat(Pose p, Quaternion r)
        {
            return (p.rotation * r);
        }

        public static Pose WorldFromLocalPose(Pose p, Pose d)
        {
            return new Pose(WorldFromLocalPoint(p, d.position), WorldFromLocalQuat(p, d.rotation));
        }

        public static Vector3 LocalFromWorldPoint(Pose p, Vector3 v)
        {
            return (Quaternion.Inverse(p.rotation) * (v - p.position));
        }

        public static Vector3 LocalFromWorldVector(Pose p, Vector3 v)
        {
            return (Quaternion.Inverse(p.rotation) * v);
        }

        public static Quaternion LocalFromWorldQuat(Pose p, Quaternion r)
        {
            return (Quaternion.Inverse(p.rotation) * r);
        }

        public static Pose LocalFromWorldPose(Pose otherWorld, Pose myPose)
        {
            return new Pose(LocalFromWorldPoint(otherWorld, myPose.position), LocalFromWorldQuat(otherWorld, myPose.rotation));
        }

        public static Pose FromTransform(Transform t)
        {
            return new Pose(t.position, t.rotation);
        }

        public static void ApplyToTransform(Pose p, Transform t)
        {
            t.position = p.position;
            t.rotation = p.rotation;
        }


        public static Vector3 Abs(Vector3 v)
        {
            return new Vector3(
                Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
        }

        public static Vector3 Sign(Vector3 v)
        {
            return new Vector3(
                Mathf.Sign(v.x), Mathf.Sign(v.y), Mathf.Sign(v.z));
        }

        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            return new Vector3(
                Mathf.Max(a.x, b.x), Mathf.Max(a.y, b.y), Mathf.Max(a.z, b.z));
        }

        public static Vector3 Min(Vector3 a, Vector3 b)
        {
            return new Vector3(
                Mathf.Min(a.x, b.x), Mathf.Min(a.y, b.y), Mathf.Min(a.z, b.z));
        }

        public static Vector3 ScaleVector3(Vector3 a, Vector3 b)
        {
            return new Vector3(
            a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public static Vector3 InvScaleVector3(Vector3 a, Vector3 b)
        {
            return new Vector3(
            a.x / b.x, a.y / b.y, a.z / b.z);
        }

        public static bool IsXTheMin(Vector3 v)
        {
            return ((v.x < v.y) && (v.x < v.z));
        }

        public static bool IsYTheMin(Vector3 v)
        {
            return ((v.y < v.x) && (v.y < v.z));
        }

        internal static Pose FromTransformLocal(Transform transform)
        {
            return new Pose(transform.localPosition, transform.localRotation);
        }

        public static Quaternion LookRotationSafe(Vector3 dir, Vector3 up)
        {
            if (dir.sqrMagnitude < Mathf.Epsilon)
            {
                return Quaternion.identity;
            }
            return Quaternion.LookRotation(dir, up);
        }
    }

}
