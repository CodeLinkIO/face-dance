using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.Tests;
using Unity.MARS.Query;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEngine;

namespace Unity.MARS.Tests
{
    static class TestUtils
    {
        static readonly List<GameObject> k_ToDestroy = new List<GameObject>();

        public static Proxy CreateDefaultTestProxy(out GameObject go, int index = 0)
        {
            go = new GameObject("proxy test object " + index);
            k_ToDestroy.Add(go);
            var rwo = go.AddComponent<Proxy>();
            go.AddTestFloatCondition();
            return rwo;
        }

        public static void DestroyDefaultProxyObjects()
        {
            foreach (var gameObject in k_ToDestroy)
            {
                UnityObjectUtils.Destroy(gameObject);
            }

            k_ToDestroy.Clear();
        }

        public static SetChildArgs DefaultSetChildArgs(Proxy proxy)
        {
            return new SetChildArgs
            {
                tryBestMatchArgs = new TryBestMatchArguments(new ProxyConditions(proxy), proxy.exclusivity),
                required = true,
            };
        }

        public static SetQueryArgs DefaultSetArgs(Relations relations)
        {
            return new SetQueryArgs
            {
                relations = relations,
                commonQueryData = new CommonQueryData()
                {
                    reacquireOnLoss = true,
                    timeOut = 100f,
                    updateMatchInterval = 1f
                },
                onAcquire = (result) => { },
                onMatchUpdate = (result) => { },
                onLoss = (result) => { },
                onTimeout = (args) => { },
            };
        }

        public static Relations GetRelations(GameObject gameObject)
        {
            var objectToArgs = new Dictionary<IMRObject, SetChildArgs>();
            foreach(var proxy in gameObject.GetComponentsInChildren<Proxy>())
            {
                var memberArgs = DefaultSetChildArgs(proxy);
                objectToArgs.Add(proxy, memberArgs);
            }

            var relations = new Relations(gameObject, objectToArgs);
            return relations;
        }

        public static Dictionary<int, float> RandomRatings(int count = 10)
        {
            var memberRatings = new Dictionary<int, float>();
            for (var i = 0; i < count; i++)
            {
                memberRatings.Add(i, Random.Range(0f, 1f));
            }

            return memberRatings;
        }

        public static TestFloatRelation AddFloatRelation(this GameObject go, string trait1, string trait2)
        {
            var relation = go.AddComponent<TestFloatRelation>();
            relation.SetChild1TraitName(trait1);
            relation.SetChild2TraitName(trait2);
            return relation;
        }

        public static Vector3 RandomVector3(float min = -1f, float max = 1f)
        {
            var x = Random.Range(min, max);
            var y = Random.Range(min, max);
            var z = Random.Range(min, max);
            return new Vector3(x, y, z);
        }

        public static Pose RandomPose(float min = -1f, float max = 1f)
        {
            var x = Random.Range(min, max);
            var y = Random.Range(min, max);
            var z = Random.Range(min, max);
            return new Pose(new Vector3(x, y, z), Quaternion.identity);
        }

        public static Vector2 RandomVector2(float min = -1f, float max = 1f)
        {
            var x = Random.Range(min, max);
            var y = Random.Range(min, max);
            return new Vector2(x, y);
        }

        public static string RandomString(float min = -1f, float max = 1f)
        {
            return Random.Range(min, max).ToString("F3");
        }
    }
}
