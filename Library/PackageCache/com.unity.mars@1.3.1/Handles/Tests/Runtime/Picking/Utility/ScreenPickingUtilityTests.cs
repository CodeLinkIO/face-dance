using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.MARSHandles.Picking;
using UnityEngine;
using UnityEngine.TestTools.Constraints;
using Is = NUnit.Framework.Is;
using Object = System.Object;

namespace Unity.MARS.MARSHandles.Tests.Picking
{
    internal sealed class ScreenPickingUtilityTests
    {
        public sealed class Method
        {
            readonly Action<IReadOnlyList<IPickingTarget>, Camera, List<PickingHit>> m_TargetCode;
            readonly Action<IReadOnlyList<GameObject>, Camera, List<PickingHit>> m_GameObjectCode;
            readonly string m_Name;
            public readonly bool usesResultBuffer;
            public readonly bool allocationExpected;

            public bool hasGameObjectInput
            {
                get { return m_GameObjectCode != null; }
            }

            public Method(string name, bool allocationExpected,
                Action<IReadOnlyList<IPickingTarget>, Camera, List<PickingHit>> code)
            {
                m_TargetCode = code;
                m_GameObjectCode = null;
                m_Name = name;
                usesResultBuffer = true;
                this.allocationExpected = allocationExpected;
            }

            public Method(string name, bool allocationExpected,
                Action<IReadOnlyList<GameObject>, Camera, List<PickingHit>> code)
            {
                m_GameObjectCode = code;
                m_TargetCode = null;
                m_Name = name;
                usesResultBuffer = true;
                this.allocationExpected = allocationExpected;
            }

            public Method(string name, bool allocationExpected, Action<IReadOnlyList<IPickingTarget>, Camera> code)
            {
                m_TargetCode = (targets, camera, results) => { code.Invoke(targets, camera); };
                m_GameObjectCode = null;
                m_Name = name;
                usesResultBuffer = false;
                this.allocationExpected = allocationExpected;
            }

            public Method(string name, bool allocationExpected, Action<IReadOnlyList<GameObject>, Camera> code)
            {
                m_GameObjectCode = (targets, camera, results) => { code.Invoke(targets, camera); };
                m_TargetCode = null;
                m_Name = name;
                this.allocationExpected = allocationExpected;
            }

            public void Invoke(IReadOnlyList<GameObject> targets, Camera camera, List<PickingHit> results)
            {
                m_GameObjectCode.Invoke(targets, camera, results);
            }

            public void Invoke(IReadOnlyList<IPickingTarget> targets, Camera camera, List<PickingHit> results)
            {
                m_TargetCode.Invoke(targets, camera, results);
            }

            public override string ToString()
            {
                return m_Name;
            }
        }

        List<PickingHit> m_ResultBuffer;
        Camera m_Camera;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            m_Camera = new GameObject("Camera").AddComponent<Camera>();
            m_ResultBuffer = new List<PickingHit>();

            //When these functions are called for the first time after domain reload, they will initialize static arrays (producing allocation)
            //Prewarm them so the allocation tests are valid
            foreach (var method in s_Methods)
            {
                if (method.hasGameObjectInput)
                {
                    method.Invoke(new GameObject[0], m_Camera, m_ResultBuffer);
                }
                else
                {
                    method.Invoke(new IPickingTarget[0], m_Camera, m_ResultBuffer);
                }
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            UnityEngine.Object.DestroyImmediate(m_Camera);
        }

        static IEnumerable<Method> s_Methods
        {
            get
            {
                yield return new Method(
                    "bool GetHovered(IEnumerable<IPickingTarget>, Vector2, Camera, float, out PickingHit)",
                    allocationExpected: false,
                    (IReadOnlyList<IPickingTarget> targets, Camera camera) =>
                        ScreenPickingUtility.GetHovered(targets, Vector2.zero, camera, 15, out PickingHit hit));
                yield return new Method(
                    "bool GetHovered(IEnumerable<GameObject>, Vector2, Camera, float, out PickingHit)",
                    allocationExpected: false,
                    (IReadOnlyList<GameObject> targets, Camera camera) =>
                        ScreenPickingUtility.GetHovered(targets, Vector2.zero, camera, 15, out PickingHit hit));
                yield return new Method(
                    "bool GetHoveredAll(IEnumerable<IPickingTarget>, Vector2, Camera, float, List<PickingHit>)",
                    allocationExpected: false,
                    (IReadOnlyList<IPickingTarget> targets, Camera camera, List<PickingHit> results) =>
                        ScreenPickingUtility.GetHoveredAll(targets, Vector2.zero, camera, 15, results));
                yield return new Method(
                    "bool GetHoveredAll(IEnumerable<GameObject>, Vector2, Camera, float, List<PickingHit>)",
                    allocationExpected: false,
                    (IReadOnlyList<GameObject> targets, Camera camera, List<PickingHit> results) =>
                        ScreenPickingUtility.GetHoveredAll(targets, Vector2.zero, camera, 15, results));
                yield return new Method(
                    "PickingHit[] GetHoveredAll(IEnumerable<IPickingTarget>, Vector2, Camera, float)",
                    allocationExpected: true,
                    (IReadOnlyList<GameObject> targets, Camera camera) =>
                        ScreenPickingUtility.GetHoveredAll(targets, Vector2.zero, camera, 15));
                yield return new Method(
                    "PickingHit[] GetHoveredAll(IEnumerable<GameObject>, Vector2, Camera, float)",
                    allocationExpected: true,
                    (IReadOnlyList<GameObject> targets, Camera camera) =>
                        ScreenPickingUtility.GetHoveredAll(targets, Vector2.zero, camera, 15));
            }
        }

        public enum ArgumentToNull
        {
            ArgumentNull_Nothing,
            ArgumentNull_Targets,
            ArgumentNull_Camera,
            ArgumentNull_Results,
        }

        static IEnumerable<ArgumentToNull> s_NullArgumentCases
        {
            get
            {
                yield return ArgumentToNull.ArgumentNull_Nothing;
                yield return ArgumentToNull.ArgumentNull_Targets;
                yield return ArgumentToNull.ArgumentNull_Camera;
                yield return ArgumentToNull.ArgumentNull_Results;
            }
        }

        [Test]
        public void CheckNullArgument_ThrowsException(
            [ValueSource(nameof(s_Methods))] Method method,
            [ValueSource(nameof(s_NullArgumentCases))]
            ArgumentToNull argument)
        {
            if (argument == ArgumentToNull.ArgumentNull_Results && !method.usesResultBuffer)
                Assert.Pass(); //If the method doesn't have a result argument, skip this test (has a success)

            TestDelegate codeToTest = () =>
            {
                var camera = argument != ArgumentToNull.ArgumentNull_Camera ? m_Camera : null;
                var results = argument != ArgumentToNull.ArgumentNull_Results ? m_ResultBuffer : null;

                if (method.hasGameObjectInput)
                {
                    var targets = argument != ArgumentToNull.ArgumentNull_Targets ? new GameObject[0] : null;
                    method.Invoke(targets, camera, results);
                }
                else
                {
                    var targets = argument != ArgumentToNull.ArgumentNull_Targets ? new IPickingTarget[0] : null;
                    method.Invoke(targets, camera, results);
                }
            };

            switch (argument)
            {
                case ArgumentToNull.ArgumentNull_Nothing:
                    Assert.DoesNotThrow(codeToTest);
                    break;

                default:
                    Assert.Catch<ArgumentNullException>(codeToTest);
                    break;
            }
        }

        [Test]
        public void CheckAllocation_ExpectedAllocationResults(
            [ValueSource(nameof(s_Methods))] Method method)
        {
            if (method.allocationExpected)
                Assert.Pass();

            TestDelegate codeToTest;
            if (method.hasGameObjectInput)
            {
                var target = new List<GameObject>();
                codeToTest = () =>
                {
                    method.Invoke(target, m_Camera, m_ResultBuffer);
                };
            }
            else
            {
                var target = new List<IPickingTarget>();
                codeToTest = () =>
                {
                    method.Invoke(target, m_Camera, m_ResultBuffer);
                };
            }

            Assert.That(codeToTest, Is.Not.AllocatingGCMemory());
        }
    }
}
