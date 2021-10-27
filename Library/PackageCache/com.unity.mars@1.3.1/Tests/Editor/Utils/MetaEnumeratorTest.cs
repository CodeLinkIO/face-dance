using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Tests
{
    class MetaEnumeratorTest
    {
        // it's important that these stays 2 - all of the test answers assume this depth
        static readonly int[] k_TargetDepths = {2, 2, 2, 2, 2};

        MetaEnumerator<KeyValuePair<int, int>, Dictionary<int, int>.Enumerator, Dictionary<int, int>> m_MetaEnumerator;

        [SetUp]
        public void BeforeEach()
        {
            var source = MetaEnumeratorTestData.Source;
            m_MetaEnumerator = new MetaEnumerator
                <KeyValuePair<int, int>, Dictionary<int, int>.Enumerator, Dictionary<int, int>>
                (source, k_TargetDepths);
        }

        [Test]
        public void MetaEnumerator_EqualDepth_5Wide3Deep()
        {
            m_MetaEnumerator.RefreshEnumerators();
            // get us into the state we'd be in at the first loop of a foreach
            m_MetaEnumerator.MoveNext();

            var allExpectedCombos = MetaEnumeratorTestData.ExpectedAnswerKeys;
            // iterationCount is just a guard against infinite loop,
            // in case the enumerator's protection against that gets broken during development
            var iterationCount = 0;
            do
            {
                // un-comment the next line to debug
                //Debug.Log("count " + iterationCount + "\n" + string.Join(" , ", m_MetaEnumerator.Current));

                var current = m_MetaEnumerator.Current;
                var expectedCombo = allExpectedCombos[iterationCount];
                for (var i = 0; i < current.Length; i++)
                {
                    var resultKvp = current[i];
                    var resultDictionaryIndex = resultKvp.Key;
                    // did we get the correct enumerator entry for each combo member ?
                    Assert.AreEqual(expectedCombo[i], resultDictionaryIndex);

                    var resultArrayIndex = resultKvp.Value;
                    // is the value in this entry in the array from the right enumerator ?
                    Assert.AreEqual(i, resultArrayIndex - 1);
                }
                iterationCount++;
            }
            while (m_MetaEnumerator.MoveNext() && iterationCount < 500);
        }

        [Test]
        public void MetaEnumerator_InitialStateTest()
        {
            m_MetaEnumerator.RefreshEnumerators();
            m_MetaEnumerator.MoveNext();
            for (var i = 0; i < MetaEnumeratorTestData.Source.Length; i++)
            {
                Assert.AreEqual(MetaEnumeratorTestData.Source[i].First(), m_MetaEnumerator.Current[i]);
            }
        }

    }
}
