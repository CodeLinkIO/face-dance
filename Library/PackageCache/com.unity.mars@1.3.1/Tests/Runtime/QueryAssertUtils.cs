#if UNITY_EDITOR
using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.Data;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Tests
{
    static class QueryAssertUtils
    {
        static readonly List<Proxy> k_TempChildren = new List<Proxy>();

        public static void ActiveInHierarchy(bool active, params GameObject[] gameObjects)
        {
            foreach (var go in gameObjects)
            {
                if (active)
                    Assert.True(go.activeInHierarchy);
                else
                    Assert.False(go.activeInHierarchy);
            }
        }
        
        public static void QueryStateIs(QueryState state, params Proxy[] proxies)
        {
            foreach (var proxy in proxies)
            {
                Assert.AreEqual(state, proxy.queryState);
            }
        }
        
        public static void QueryStateIs(QueryState state, params ProxyGroup[] groups)
        {
            foreach (var group in groups)
            {
                Assert.AreEqual(state, group.queryState);
                group.GetChildList(k_TempChildren);
                QueryStateIs(state, k_TempChildren.ToArray());
            }
        }
        
        public static void AssignedDataIdIsValid(params Proxy[] proxies)
        {
            foreach (var proxy in proxies)
            {
                Assert.NotNull(proxy.currentData);
                Assert.AreNotEqual(ReservedDataIDs.Invalid, proxy.currentData.DataID);
            }
        }
        
        public static void AssignedDataIsNull(params Proxy[] proxies)
        {
            foreach (var proxy in proxies)
            {
                Assert.Null(proxy.currentData);
            }
        }
    }
}
#endif