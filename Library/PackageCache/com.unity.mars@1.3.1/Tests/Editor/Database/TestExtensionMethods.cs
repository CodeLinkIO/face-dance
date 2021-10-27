using System.Collections.Generic;
using System.Text;
using Unity.MARS;
using Unity.MARS.Query;
using UnityEngine;

namespace MARS.Tests.Editor.Database
{
    static class TestExtensionMethods
    {
        static readonly StringBuilder k_String = new StringBuilder();

        internal static QueryArgs GetQueryArgs(this GameObject go, Exclusivity exclusivity = Exclusivity.ReadOnly)
        {
            return new QueryArgs
            {
                conditions = ProxyConditions.FromGameObject<Proxy>(go),
                exclusivity = exclusivity,
                commonQueryData = new CommonQueryData()
            };
        }

        internal static void DebugLogBlock<T>(this IEnumerable<T> enumerable)
        {
            k_String.Clear();
            foreach (var t in enumerable)
            {
                k_String.AppendFormat("{0},\n", t);
            }

            Debug.Log(k_String);
        }
    }
}
