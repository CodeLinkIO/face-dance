using System.Collections;
using NUnit.Framework;
using Unity.MARS.Query;
using Unity.XRTools.Utils;

namespace Unity.MARS.Data.Tests
{
    static class QueryTestData
    {
        static Exclusivity[] s_Exclusivities = EnumValues<Exclusivity>.Values;

        public static IEnumerable Exclusivity
        {
            get
            {
                foreach (var markedDataExclusivity in s_Exclusivities)
                {
                    foreach (var queryExclusivity in s_Exclusivities)
                    {
                        var expected = queryExclusivity == Query.Exclusivity.ReadOnly ||
                            queryExclusivity == Query.Exclusivity.Shared &&
                            (markedDataExclusivity == Query.Exclusivity.ReadOnly || markedDataExclusivity == Query.Exclusivity.Shared) ||
                            queryExclusivity == Query.Exclusivity.Reserved && markedDataExclusivity == Query.Exclusivity.ReadOnly;
                        yield return new TestCaseData(markedDataExclusivity, queryExclusivity, expected);
                    }
                }
            }
        }

        public static IEnumerable ProposalsExclusivity
        {
            get
            {
                foreach (var markedDataExclusivity in s_Exclusivities)
                {
                    foreach (var queryExclusivity in s_Exclusivities)
                    {
                        var expected = queryExclusivity == Query.Exclusivity.ReadOnly ||
                                       queryExclusivity == Query.Exclusivity.Shared &&
                                       (markedDataExclusivity == Query.Exclusivity.ReadOnly || markedDataExclusivity == Query.Exclusivity.Shared) ||
                                       queryExclusivity == Query.Exclusivity.Reserved && markedDataExclusivity == Query.Exclusivity.ReadOnly;

                        yield return new TestCaseData(markedDataExclusivity, queryExclusivity, expected ? 0 : 1);
                    }
                }
            }
        }

        public static IEnumerable SingleExclusivities
        {
            get
            {
                foreach (var markedDataExclusivity in s_Exclusivities)
                {
                    yield return new TestCaseData(markedDataExclusivity);
                }
            }
        }

        public static IEnumerable ExclusivityByType
        {
            get
            {
                foreach (var exclusivity in s_Exclusivities)
                {
                    yield return new TestCaseData(exclusivity);
                }
            }
        }
    }
}
