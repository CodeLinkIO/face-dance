#if UNITY_EDITOR
using UnityEngine;
using NUnit.Framework;

namespace Unity.MARS.Forces.ForceDefinitions
{

    class ProxyForcesTests
    {
        [Test]
        public void TestPrimitives()
        {
            ProxyForceFieldPrimitive prim = ProxyForceFieldPrimitive.Default;
            Assert.True(prim.primitiveType == ProxyForceFieldPrimitive.FieldPrimitiveType.Box);

            {
                var s2 = prim.SampleDistanceVectorFromPointLocal(new Vector3(1.5f, 0, 0), ProxyForceFieldPrimitive.ShapeSample.Fill);
                Assert.True(s2.HasSample);
                AssertNear(s2.Distance, 1.0f);
                AssertNear(s2.ToSurface, new Vector3(-1, 0, 0));
                AssertNear(Mathf.Abs(s2.Distance), s2.ToSurface.magnitude);
            }

            {
                var s2 = prim.SampleDistanceVectorFromPointLocal(new Vector3(1.0f, 0, 0), ProxyForceFieldPrimitive.ShapeSample.Edge);
                Assert.True(s2.HasSample);
                AssertNear(s2.Distance,  Mathf.Sqrt(2.0f) * 0.5f);
            }

            {
                var testPnt = Vector3.one * 1.5f;
                var s2 = prim.SampleDistanceVectorFromPointLocal(testPnt, ProxyForceFieldPrimitive.ShapeSample.Fill);
                Assert.True(s2.HasSample);
                AssertNear(Mathf.Abs(s2.Distance), s2.ToSurface.magnitude);
                AssertNear(s2.ToSurface, Vector3.one * -1.0f);
                AssertNear(s2.Distance, Vector3.one.magnitude );

            }

            {
                var primPose = new Pose(new Vector3(5,0,0), Quaternion.identity);
                ProxyForceFieldPrimitivePosed posed = new ProxyForceFieldPrimitivePosed(prim, primPose);
                var s2 = posed.SampleDistanceFieldWorld(new Vector3(6.0f,0,0), ProxyForceFieldPrimitive.ShapeSample.Fill);
                Assert.True(s2.HasSample);
                AssertNear(s2.Distance, 0.5f);
            }
        }

        [Test]
        public void TestDefintions()
        {
            ProxyForceRegionDefintion rocc = new ProxyForceRegionDefintion() { regionType = ProxyRegionForceType.OccupiedSpace };
            ProxyForceRegionDefintion remp = new ProxyForceRegionDefintion() { regionType = ProxyRegionForceType.PaddingKeptEmpty };

            {
                AssertSame(rocc.GetResponceTypeToOtherRegion(remp), ProxyForceRegionResponce.StayOutOf);
                AssertSame(rocc.GetResponceTypeToOtherRegion(rocc), ProxyForceRegionResponce.StayOutOf);
                AssertSame(remp.GetResponceTypeToOtherRegion(remp), ProxyForceRegionResponce.Nothing);
            }
        }


        [Test]
        public void TestPoses()
        {
            Random.InitState(0);
            var p = new Pose(Random.insideUnitSphere, Random.rotation);
            var v = Random.insideUnitSphere;

            var w = PoseUtils.WorldFromLocalPoint(p, v);
            var v2 = PoseUtils.LocalFromWorldPoint(p, w);

            AssertNear(v, v2, 0.001f);
        }

        [System.Diagnostics.DebuggerHidden]
        private static void AssertNear(float a, float b, float dist = 0.0001f)
        {
            var d = Mathf.Abs(a - b) < dist;
            if (!d)
            {
                Debug.Log($"a={a} b={b}");
            }
            Assert.True(d);
        }

        [System.Diagnostics.DebuggerHidden]
        private static void AssertNear(Vector3 a, Vector3 b, float dist = 0.0001f)
        {
            var d = ((a - b).magnitude) < dist;
            if (!d)
            {
                Debug.Log($"a={a} b={b}");
            }
            Assert.True(d);
        }

        [System.Diagnostics.DebuggerHidden]
        private static void AssertEquals<T>(T a, T b) where T:System.IComparable<T>
        {
            var res = (a.CompareTo(b) == 0);
            Assert.True(res);
        }

        [System.Diagnostics.DebuggerHidden]
        private static void AssertSame<T>(T a, T b) where T : struct
        {
            var res = (a.Equals(b));
            if (!res)
            {
                Debug.Log($"a={a} b={b}");
            }
            Assert.True(res);
        }
    }
}
#endif

