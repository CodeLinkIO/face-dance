using NUnit.Framework;
using UnityEngine;
using Object = System.Object;

namespace Unity.MARS.MARSHandles.Tests
{
    sealed class HandleStateColorsTests
    {
        public sealed class TestCase
        {
            public Transitions transitions { get; }
            public Color targetColor { get; }
            readonly string m_Name;

            public TestCase(string name, Color targetColor, Transitions transitions)
            {
                m_Name = name;
                this.transitions = transitions;
                this.targetColor = targetColor;
            }

            public override string ToString()
            {
                return m_Name;
            }
        }

        static readonly Color k_TargetColor = new Color(1, 0, 0, 1);
        public delegate void Transitions(FakeContext context, HandleStateColors main, HandleStateColors secondary);

        static TestCase[] s_TestCase =
        {
            new TestCase("Idle", k_TargetColor, (FakeContext context, HandleStateColors main, HandleStateColors secondary) =>
            {
                main.idleColor = k_TargetColor;
            }),

            new TestCase("Idle->Hover", k_TargetColor, (FakeContext context, HandleStateColors main, HandleStateColors secondary) =>
            {
                main.hoverColor = k_TargetColor;
                context.SetHover(main.ownerHandle);
            }),

            new TestCase("Idle->Hover->Idle", k_TargetColor, (FakeContext context, HandleStateColors main, HandleStateColors secondary) =>
            {
                main.idleColor = k_TargetColor;
                context.SetHover(main.ownerHandle);
                context.SetHover(null);
            }),

            new TestCase("Idle->Hover->Drag", k_TargetColor, (FakeContext context, HandleStateColors main, HandleStateColors secondary) =>
            {
                main.dragColor = k_TargetColor;
                context.SetHover(main.ownerHandle);
                context.DoDragStart();
            }),

            new TestCase("Idle->Hover->Drag->Hover", k_TargetColor, (FakeContext context, HandleStateColors main, HandleStateColors secondary) =>
            {
                main.hoverColor = k_TargetColor;
                context.SetHover(main.ownerHandle);
                context.DoDragStart();
                context.DoDragStop();
            }),

            new TestCase("Idle->Hover->Drag->Hover->Idle", k_TargetColor, (FakeContext context, HandleStateColors main, HandleStateColors secondary) =>
            {
                main.idleColor = k_TargetColor;
                context.SetHover(main.ownerHandle);
                context.DoDragStart();
                context.DoDragStop();
                context.SetHover(null);
            }),

            new TestCase("Idle->Hover->Disable", k_TargetColor, (FakeContext context, HandleStateColors main, HandleStateColors secondary) =>
            {
                main.disableColor = k_TargetColor;
                context.SetHover(secondary.ownerHandle);
                context.DoDragStart();
            }),

            new TestCase("Idle->Hover->Disable->Hover", k_TargetColor, (FakeContext context, HandleStateColors main, HandleStateColors secondary) =>
            {
                //Disable->Hover means that it not the target of the hover and should go back to idle
                main.idleColor = k_TargetColor;
                context.SetHover(secondary.ownerHandle);
                context.DoDragStart();
                context.DoDragStop();
            }),

            new TestCase("Idle->Hover->Disable->Hover->Idle", k_TargetColor, (FakeContext context, HandleStateColors main, HandleStateColors secondary) =>
            {
                main.idleColor = k_TargetColor;
                context.SetHover(secondary.ownerHandle);
                context.DoDragStart();
                context.DoDragStop();
                context.SetHover(null);
            }),
        };

        FakeContext m_Context;
        HandleStateColors m_MainHandleStateColors;
        HandleStateColors m_SecondaryHandleStateColors;
        GameObject m_TemplateHandle;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            m_TemplateHandle = new GameObject("[Template Handle]");
            m_TemplateHandle.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Unlit/Color"));
            m_TemplateHandle.AddComponent<HandleStateColors>();
            m_TemplateHandle.AddComponent<Slider1DHandle>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            UnityEngine.Object.DestroyImmediate(m_TemplateHandle);
        }

        [SetUp]
        public void SetUp()
        {
            m_Context = new FakeContext();
            m_MainHandleStateColors = m_Context.CreateHandle(m_TemplateHandle).GetComponent<HandleStateColors>();
            m_SecondaryHandleStateColors = m_Context.CreateHandle(m_TemplateHandle).GetComponent<HandleStateColors>();
        }

        [TearDown]
        public void TearDown()
        {
            m_Context.DestroyHandle(m_MainHandleStateColors.gameObject);
            m_Context.DestroyHandle(m_SecondaryHandleStateColors.gameObject);
            m_Context.Dispose();
        }

        [Test]
        [TestCaseSource(nameof(s_TestCase))]
        public void TestStateTransitions(TestCase testCase)
        {
            testCase.transitions.Invoke(m_Context, m_MainHandleStateColors, m_SecondaryHandleStateColors);

            Assert.That(m_MainHandleStateColors.targetRenderer.sharedMaterial.color, Is.EqualTo(testCase.targetColor));
        }
    }
}
