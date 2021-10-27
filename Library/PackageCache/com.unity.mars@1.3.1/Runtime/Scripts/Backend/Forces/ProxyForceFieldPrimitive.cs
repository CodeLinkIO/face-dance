using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.XRTools.Utils;

namespace Unity.MARS.Forces.ForceDefinitions
{
    [System.Serializable]
    internal struct ProxyForceFieldPrimitive
    {
        public FieldPrimitiveType primitiveType;
        public Vector3 vectorRadii;
        public List<Vector3> verticesInXZ;

        public enum FieldPrimitiveType
        {
            Box = 0,
            Sphere,
            PlaneForward,
            LineOnX,
            COUNT_TYPES
        }

        public enum ShapeSample
        {
            Fill = 0,
            Edge
        }

        //public DistFieldPrimitive() { }
        public ProxyForceFieldPrimitive(FieldPrimitiveType tp, Vector3 radii)
        {
            primitiveType = tp;
            vectorRadii = radii;
            verticesInXZ = null;
        }

        public Vector3 LocalFromUnitPoint(Vector3 pnt)
        {
            return PoseUtils.ScaleVector3(pnt, vectorRadii);
        }

        public float MaxRadius {
            get
            {
                return vectorRadii.magnitude;
            }
        }

        public float MinRadius
        {
            get
            {
                return Mathf.Min(vectorRadii.x, Mathf.Min(vectorRadii.y, vectorRadii.z));
            }
        }

        public static ProxyForceFieldPrimitive Default = new ProxyForceFieldPrimitive(FieldPrimitiveType.Box, Vector3.one * 0.5f);
        public const float DefaultOutsidePct = 1.00f;
        public const float DefaultInsidePct = 1.00f;
        public static Vector3[] DefaultUnitSamplePointsOutside_6 = new Vector3[]
        {
            (new Vector3( 1, 0, 0)) * DefaultOutsidePct,
            (new Vector3( 0, 1, 0)) * DefaultOutsidePct,
            (new Vector3( 0, 0, 1)) * DefaultOutsidePct,
            (new Vector3(-1, 0, 0)) * DefaultOutsidePct,
            (new Vector3( 0,-1, 0)) * DefaultOutsidePct,
            (new Vector3( 0, 0,-1)) * DefaultOutsidePct,
        };
        public static Vector3[] DefaultUnitSamplePointsOutside_8 = new Vector3[]
        {
            (new Vector3(-1,-1, 1)) * DefaultOutsidePct,
            (new Vector3(-1, 1, 1)) * DefaultOutsidePct,
            (new Vector3( 1,-1, 1)) * DefaultOutsidePct,
            (new Vector3( 1, 1, 1)) * DefaultOutsidePct,
            (new Vector3(-1,-1,-1)) * DefaultOutsidePct,
            (new Vector3(-1, 1,-1)) * DefaultOutsidePct,
            (new Vector3( 1,-1,-1)) * DefaultOutsidePct,
            (new Vector3( 1, 1,-1)) * DefaultOutsidePct,
        };
        public static Vector3[] DefaultUnitSamplePointsOutside_LineX_3 = new Vector3[]
        {
                    (new Vector3(-1, 0, 0)) * DefaultOutsidePct,
                    (new Vector3( 0, 0, 0)) * DefaultOutsidePct,
                    (new Vector3( 1, 0, 0)) * DefaultOutsidePct,
        };
        public static Vector3[] DefaultUnitSamplePointsOutside_PlaneZ_9 = new Vector3[]
        {
            (new Vector3(-1,-1, 0)) * DefaultOutsidePct,
            (new Vector3( 0,-1, 0)) * DefaultOutsidePct,
            (new Vector3( 1,-1, 0)) * DefaultOutsidePct,

            (new Vector3(-1, 0, 0)) * DefaultOutsidePct,
            //(new Vector3( 0, 0, 0)) * DefaultOutsidePct,
            (new Vector3( 1, 0, 0)) * DefaultOutsidePct,

            (new Vector3(-1, 1, 0)) * DefaultOutsidePct,
            (new Vector3( 0, 1, 0)) * DefaultOutsidePct,
            (new Vector3( 1, 1, 0)) * DefaultOutsidePct,
        };
        public static Vector3[] DefaultUnitSamplePointsOutside_27 = new Vector3[]
        {
                    (new Vector3(-1,-1,-1)) * DefaultOutsidePct,
                    (new Vector3( 0,-1,-1)) * DefaultOutsidePct,
                    (new Vector3( 1,-1,-1)) * DefaultOutsidePct,
                    (new Vector3(-1,-1, 0)) * DefaultOutsidePct,
                    (new Vector3( 0,-1, 0)) * DefaultOutsidePct,
                    (new Vector3( 1,-1, 0)) * DefaultOutsidePct,
                    (new Vector3(-1,-1, 1)) * DefaultOutsidePct,
                    (new Vector3( 0,-1, 1)) * DefaultOutsidePct,
                    (new Vector3( 1,-1, 1)) * DefaultOutsidePct,

                    (new Vector3(-1, 0,-1)) * DefaultOutsidePct,
                    (new Vector3( 0, 0,-1)) * DefaultOutsidePct,
                    (new Vector3( 1, 0,-1)) * DefaultOutsidePct,
                    (new Vector3(-1, 0, 0)) * DefaultOutsidePct,
                    //(new Vector3( 0, 0, 0)) * DefaultOutsidePct,
                    (new Vector3( 1, 0, 0)) * DefaultOutsidePct,
                    (new Vector3(-1, 0, 1)) * DefaultOutsidePct,
                    (new Vector3( 0, 0, 1)) * DefaultOutsidePct,
                    (new Vector3( 1, 0, 1)) * DefaultOutsidePct,

                    (new Vector3(-1, 1,-1)) * DefaultOutsidePct,
                    (new Vector3( 0, 1,-1)) * DefaultOutsidePct,
                    (new Vector3( 1, 1,-1)) * DefaultOutsidePct,
                    (new Vector3(-1, 1, 0)) * DefaultOutsidePct,
                    (new Vector3( 0, 1, 0)) * DefaultOutsidePct,
                    (new Vector3( 1, 1, 0)) * DefaultOutsidePct,
                    (new Vector3(-1, 1, 1)) * DefaultOutsidePct,
                    (new Vector3( 0, 1, 1)) * DefaultOutsidePct,
                    (new Vector3( 1, 1, 1)) * DefaultOutsidePct,
        };
        public static Vector3[] DefaultUnitSamplePointsOutside_14 = DefaultUnitSamplePointsOutside_6.Concat(DefaultUnitSamplePointsOutside_8).ToArray();
        public static Vector3[] DefaultUnitSamplePointsPlane = DefaultUnitSamplePointsOutside_PlaneZ_9;
        public static Vector3[] DefaultUnitSamplePointsLine = DefaultUnitSamplePointsOutside_LineX_3;

        public static Vector3[] UnitSamplesPointsForType(FieldPrimitiveType pt)
        {
            switch (pt)
            {
                case FieldPrimitiveType.PlaneForward:
                    return DefaultUnitSamplePointsPlane;
                case FieldPrimitiveType.LineOnX:
                    return DefaultUnitSamplePointsLine;
                default:
                    return DefaultUnitSamplePointsOutside_14;
            }
        }

        internal struct DistanceSample
        {
            public float Distance;
            public Vector3 ToSurface;
            public float SampleWeight;
            public Vector3 WorldPoint;
            public Vector3 RegionToSurface;
            public bool HasSample;

            //public DistanceSample() { }
            public DistanceSample(float dist, Vector3 dir)
            {
                Distance = dist;
                ToSurface = dir;
                HasSample = true;
                SampleWeight = 1.0f;
                WorldPoint = Vector3.zero;
                RegionToSurface = Vector3.zero;
            }

            internal DistanceSample AdjustedForResponce(ProxyForceRegionResponce resp, Vector3 worldPoint, Pose sampleRegionPose)
            {
                var ans = this;
                ans.WorldPoint = worldPoint;
                if (resp == ProxyForceRegionResponce.StayOutOf)
                {
                    if (Distance > 0.0f)
                    {
                        ans.HasSample = false;
                    }
                    else
                    {
                        // If pushing out, go other way if deeply overlapping
                        if (Vector3.Dot(ToSurface, worldPoint - sampleRegionPose.position) > 0.0f)
                        {
                            ans.ToSurface *= -1.0f;
                        }
                    }
                }
                return ans;
            }

            public DistanceSample CombinedWith(DistanceSample other)
            {
                if ((!HasSample) || (other.HasSample && (other.Distance < Distance)))
                {
                    return other;
                }
                return this;
            }

            public static DistanceSample Null
            {
                get
                {
                    return new DistanceSample();
                }
            }
        }

        public Vector3 UnitFromReferenceVector(Vector3 v)
        {
            if (primitiveType == FieldPrimitiveType.Sphere)
            {
                return v.normalized;
            }
            return v;
        }

        static Vector3 ClosetPointOnPolygonEdge(Vector3 testPoint, List<Vector3> polygon)
        {
            var bestPoint = polygon[0];
            var bestDistance = (bestPoint - testPoint).magnitude;
            for (var i = 1; i < polygon.Count; i++)
            {
                var a = polygon[i - 1];
                var b = polygon[i];
                var point = GeometryUtils.ClosestPointOnLineSegment(testPoint, a, b);
                var distance = (point - testPoint).magnitude;
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestPoint = point;
                }
            }
            return bestPoint;
        }

        internal DistanceSample SampleDistanceVectorFromPointLocal(Vector3 localPos, ShapeSample shape)
        {
            if (verticesInXZ != null)
            {
                var polygon = verticesInXZ;
                var nearestPoint = localPos;
                if ((shape == ShapeSample.Fill) && GeometryUtils.PointInPolygon(localPos, polygon))
                {
                    nearestPoint.y = 0.0f;
                }
                else
                {
                    nearestPoint = ClosetPointOnPolygonEdge(localPos, polygon);
                }
                var toSurf = (nearestPoint - localPos);
                return new DistanceSample(toSurf.magnitude, toSurf);
            }

            if (primitiveType == FieldPrimitiveType.Box)
            {
                // Note: C0 not C1 continuous
                if (shape == ShapeSample.Fill)
                {
                    var nearest = PoseUtils.ScaleVector3(PoseUtils.Min(PoseUtils.Abs(localPos), vectorRadii), PoseUtils.Sign(localPos));
                    var b = PoseUtils.Abs(localPos) - (vectorRadii);
                    var dist = Mathf.Max(b.x, Mathf.Max(b.y, b.z));
                    if (dist < 0.0f)
                    {
                        b = vectorRadii - PoseUtils.Abs(localPos);
                        nearest = localPos;
                        var nearestTip = PoseUtils.ScaleVector3(vectorRadii, PoseUtils.Sign(localPos));
                        if (PoseUtils.IsXTheMin(b))
                        {
                            nearest.x = nearestTip.x;
                        }
                        else if (PoseUtils.IsYTheMin(b))
                        {
                            nearest.y = nearestTip.y;
                        }
                        else
                        {
                            nearest.z = nearestTip.z;
                        }
                    }
                    else
                    {
                        dist = (nearest - localPos).magnitude;
                    }

                    var toSurf = (nearest - localPos);
                    return new DistanceSample(dist, toSurf);
                }
                else if (shape == ShapeSample.Edge)
                {
                    var absLocal = PoseUtils.Abs(localPos);
                    var absUnit = PoseUtils.Abs(PoseUtils.InvScaleVector3(localPos, vectorRadii) - Vector3.one);
                    var absNearest = vectorRadii;
                    if (PoseUtils.IsXTheMin(absUnit))
                    {
                        absNearest = new Vector3(absLocal.x, vectorRadii.y, vectorRadii.z);
                    }
                    else if (PoseUtils.IsYTheMin(absUnit))
                    {
                        absNearest = new Vector3(vectorRadii.x, absLocal.y, vectorRadii.z);
                    }
                    else
                    {
                        absNearest = new Vector3(vectorRadii.x, vectorRadii.y, absLocal.z);
                    }
                    var nearest = PoseUtils.ScaleVector3(absNearest, PoseUtils.Sign(localPos));
                    var toSurf = (nearest - localPos);
                    var dist = toSurf.magnitude;
                    return new DistanceSample(dist, toSurf);

                }
                else
                {
                    throw new System.NotImplementedException("TODO:" + shape);
                }
            }
            else if (primitiveType == FieldPrimitiveType.Sphere)
            {
                var nearest = PoseUtils.ScaleVector3(localPos.normalized, vectorRadii);
                var dist = (localPos.magnitude - nearest.magnitude);
                return new DistanceSample(dist, nearest - localPos);
            }
            else if (primitiveType == FieldPrimitiveType.PlaneForward)
            {
                if (shape == ShapeSample.Edge) throw new System.NotImplementedException("TODO: Plane+Edge");
                Vector3 nearest;
                var flipDistance = false;
                if ((shape == ShapeSample.Fill) && (localPos.z >= 0))
                {
                    nearest = new Vector3(
                        Mathf.Clamp(localPos.x, -vectorRadii.x, vectorRadii.x),
                        Mathf.Clamp(localPos.y, -vectorRadii.y, vectorRadii.y),
                        Mathf.Clamp(localPos.z, -vectorRadii.z, vectorRadii.z)
                    );
                    nearest.z = 0.0f;
                }
                else // if edge or if behind the plane
                {
                    nearest = PoseUtils.ScaleVector3(vectorRadii, PoseUtils.Sign(localPos));
                    nearest.z = 0.0f;
                }
                var dist = (localPos.magnitude - nearest.magnitude) * (flipDistance ? -1.0f : 1.0f);
                return new DistanceSample(dist, nearest - localPos);
            }
            else if (primitiveType == FieldPrimitiveType.LineOnX)
            {
                var radius = vectorRadii.x;
                var fx = Mathf.Clamp(localPos.x, -radius, radius);
                var nearest = new Vector3(fx, 0, 0);
                var dist = nearest.magnitude;
                return new DistanceSample(dist, nearest);
            }
            else
            {
                throw new System.NotImplementedException("TODO.");
            }
        }

    }

    internal struct ProxyForceFieldPrimitivePosed
    {
        public ProxyForceFieldPrimitive Primitive;
        public Pose Pose;

        //public VolumetricPrimitivePosed() { }
        public ProxyForceFieldPrimitivePosed(ProxyForceFieldPrimitive _prim, Pose _pose)
        {
            Primitive = _prim;
            Pose = _pose;
        }

        public Vector3 ClosestWorldPoint(Vector3 worldPos, ProxyForceFieldPrimitive.ShapeSample responce)
        {
            var s = SampleDistanceFieldWorld(worldPos, responce);
            var pos = worldPos + s.ToSurface;
            return pos;
        }

        public bool EstimateCollision(ProxyForceFieldPrimitivePosed other)
        {
            var centerDist = (Pose.position - other.Pose.position).magnitude;
            var maxRadius = (Primitive.MaxRadius + other.Primitive.MaxRadius);

            return (centerDist <= maxRadius);
        }

        public bool EstimateAttraction(ProxyForceFieldPrimitivePosed other)
        {
            var centerDist = (Pose.position - other.Pose.position).magnitude;
            var maxRadius = (Primitive.MaxRadius + other.Primitive.MaxRadius);

            return (centerDist < (maxRadius * 3));
        }

        public bool TryDecollisionSample(ProxyForceFieldPrimitivePosed other, out Vector3 movement)
        {
            return DecollisionSystem.DecollisionVector(this, other, out movement);
        }

        public Vector3 ClosestCornerTo(Vector3 worldPos)
        {
            var lp = LocalFromWorldPoint(worldPos);
            var corner = PoseUtils.ScaleVector3(PoseUtils.Sign(lp), Primitive.vectorRadii);
            return WorldFromLocalPoint(corner);
        }


        public ProxyForceFieldPrimitive.DistanceSample SampleDistanceFieldWorld(Vector3 worldPos, ProxyForceFieldPrimitive.ShapeSample responce)
        {
            var lp = LocalFromWorldPoint(worldPos);
            var samp = Primitive.SampleDistanceVectorFromPointLocal(lp,responce);
            samp.ToSurface = WorldFromLocalVector(samp.ToSurface);
            return samp;
        }

        public Vector3 WorldFromUnitPoint(Vector3 pnt)
        {
            return WorldFromLocalPoint(Primitive.LocalFromUnitPoint(pnt));
        }

        public Vector3 WorldFromLocalPoint(Vector3 pnt)
        {
            return PoseUtils.WorldFromLocalPoint(Pose, pnt);
        }

        public Vector3 WorldFromLocalVector(Vector3 pnt)
        {
            return PoseUtils.WorldFromLocalVector(Pose, pnt);
        }

        public Vector3 LocalFromWorldPoint(Vector3 pnt)
        {
            return PoseUtils.LocalFromWorldPoint(Pose, pnt);
        }

        public void DebugDraw(Color color)
        {
            var corners = ProxyForceFieldPrimitive.UnitSamplesPointsForType(Primitive.primitiveType);
            var center = Pose.position;
            foreach (var c in corners)
            {
                var world = WorldFromUnitPoint(c);
                Debug.DrawLine(center, world, color);
            }
        }

        static class DecollisionSystem
        {
            static Collider[][] s_CollidersByArgByPrimType = null;
            static GameObject s_ColliderCoreObject = null;

            public static bool DecollisionVector(ProxyForceFieldPrimitivePosed a, ProxyForceFieldPrimitivePosed b, out Vector3 dir)
            {
                var colliderA = ConfigTempCollider(0, a.Primitive);
                var colliderB = ConfigTempCollider(1, b.Primitive);

                var res = UnityEngine.Physics.ComputePenetration(
                    colliderA, a.Pose.position, a.Pose.rotation,
                    colliderB, b.Pose.position, b.Pose.rotation,
                    out dir, out float dist);
                dir *= dist; // direction is normalized until scaled by distance

                ReleaseTempCollider(colliderA);
                ReleaseTempCollider(colliderB);

                return res;
            }

            static bool AreAlmostExact(Pose a, Pose b) { return ((a.position - b.position).sqrMagnitude < Mathf.Epsilon); }

            static Collider ConfigTempCollider(int argIndex, ProxyForceFieldPrimitive vp)
            {
                var col = EnsureCollider(argIndex, vp.primitiveType);
                SetupCollider(col, vp);
                col.enabled = true;
                return col;
            }

            static void ReleaseTempCollider(Collider collider)
            {
                collider.enabled = false;
            }

            static void SetupCollider(Collider c, ProxyForceFieldPrimitive vp)
            {
                if (vp.primitiveType == ProxyForceFieldPrimitive.FieldPrimitiveType.Sphere)
                {
                    var sc = (SphereCollider)c;
                    sc.radius = vp.MaxRadius;
                }
                else
                {
                    var bc = (BoxCollider)c;
                    bc.size = vp.vectorRadii * 2.0f;
                }

            }

            static Collider EnsureCollider(int argIndex, ProxyForceFieldPrimitive.FieldPrimitiveType pt)
            {
                const int maxArgs = 2;
                const int maxTypes = (int)(ProxyForceFieldPrimitive.FieldPrimitiveType.COUNT_TYPES);

                if (s_CollidersByArgByPrimType != null)
                {
                    // already allocted
                }
                else
                {
                    s_CollidersByArgByPrimType = new Collider[maxArgs][];
                    for (var ai=0; ai<maxArgs; ai++)
                    {
                        s_CollidersByArgByPrimType[ai] = new Collider[maxTypes];
                    }
                }

                var typeIndex = (int)pt;
                var col = s_CollidersByArgByPrimType[argIndex][typeIndex];
                if (col) return col;

                col = AllocCollider(pt);
                s_CollidersByArgByPrimType[argIndex][typeIndex] = col;
                return col;
            }

            static Collider AllocCollider(ProxyForceFieldPrimitive.FieldPrimitiveType pt)
            {
                if (!s_ColliderCoreObject)
                {
                    const string k_tempObjName = "TempForceFieldPrimPosedForCollision";
                    s_ColliderCoreObject = new GameObject();
                    s_ColliderCoreObject.hideFlags = HideFlags.HideAndDontSave;
                    s_ColliderCoreObject.name = k_tempObjName;
                }
                var gm = s_ColliderCoreObject;
                switch (pt)
                {
                    case ProxyForceFieldPrimitive.FieldPrimitiveType.Box:
                    case ProxyForceFieldPrimitive.FieldPrimitiveType.PlaneForward:
                    case ProxyForceFieldPrimitive.FieldPrimitiveType.LineOnX:
                        return gm.AddComponent<BoxCollider>();
                    case ProxyForceFieldPrimitive.FieldPrimitiveType.Sphere:
                        return gm.AddComponent<SphereCollider>();
                    default:
                        throw new System.NotImplementedException("Collider for " + pt);
                }
            }
        }
    }

}
