using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Unity.MARS.MARSHandles;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace Unity.MARS.HandlesEditor.Tests
{
    sealed class EditorHandleStateColorsTests
    {
        sealed class DummyEditorContext : EditorHandleContext {}
        sealed class DummyRuntimeContext : RuntimeHandleContext {}

        static IEnumerable<EditorHandleStateColors.IdleColor> s_IdleColors
        {
            get
            {
                foreach (var value in Enum.GetValues(typeof(EditorHandleStateColors.IdleColor)))
                {
                    yield return (EditorHandleStateColors.IdleColor) value;
                }
            }
        }

        EditorHandleContext m_EditorContext;
        RuntimeHandleContext m_RuntimeContext;
        EditorHandleStateColors m_EditorContextStateColors;
        EditorHandleStateColors m_RuntimeContextStateColors;
        GameObject m_TemplateHandle;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            m_TemplateHandle = new GameObject("[Template Handle]");
            m_TemplateHandle.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Unlit/Color"));
            m_TemplateHandle.AddComponent<EditorHandleStateColors>();
            m_TemplateHandle.AddComponent<Slider1DHandle>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Object.DestroyImmediate(m_TemplateHandle);
        }

        [SetUp]
        public void SetUp()
        {
            m_EditorContext = new DummyEditorContext();
            m_EditorContextStateColors = m_EditorContext.CreateHandle(m_TemplateHandle).GetComponent<EditorHandleStateColors>();
            m_RuntimeContext = new DummyRuntimeContext();
            m_RuntimeContextStateColors = m_RuntimeContext.CreateHandle(m_TemplateHandle).GetComponent<EditorHandleStateColors>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(m_EditorContextStateColors.gameObject);
            Object.DestroyImmediate(m_RuntimeContextStateColors.gameObject);
            m_EditorContext.Dispose();
            m_RuntimeContext.Dispose();
        }

        [Test]
        [TestCaseSource(nameof(s_IdleColors))]
        public void EditorContext_IdleColor_IsLinkedToPreference(EditorHandleStateColors.IdleColor idleColor)
        {
            var targetColor = Color.clear;
            switch (idleColor)
            {
                case EditorHandleStateColors.IdleColor.KeepMaterialColor:
                    targetColor = m_EditorContextStateColors.targetRenderer.sharedMaterial.color;
                    break;

                case EditorHandleStateColors.IdleColor.Axis_X:
                    targetColor = UnityEditor.Handles.xAxisColor;
                    break;

                case EditorHandleStateColors.IdleColor.Axis_Y:
                    targetColor = UnityEditor.Handles.yAxisColor;
                    break;

                case EditorHandleStateColors.IdleColor.Axis_Z:
                    targetColor = UnityEditor.Handles.zAxisColor;
                    break;

                case EditorHandleStateColors.IdleColor.Axis_Center:
                    targetColor = UnityEditor.Handles.centerColor;
                    break;

                default:
                    Assert.Fail("Idle Color target preference not implemented in test");
                    break;
            }

            m_EditorContextStateColors.targetIdleColor = idleColor;
            Assert.That(m_EditorContextStateColors.idleColor, Is.EqualTo(targetColor));
        }

        [Test]
        public void EditorContext_HoverColor_IsLinkedToPreference()
        {
            Assert.That(m_EditorContextStateColors.hoverColor, Is.EqualTo(UnityEditor.Handles.preselectionColor));
        }

        [Test]
        public void EditorContext_DragColor_IsLinkedToPreference()
        {
            Assert.That(m_EditorContextStateColors.dragColor, Is.EqualTo(UnityEditor.Handles.selectedColor));
        }

        [Test]
        public void EditorContext_DisableColor_IsLinkedToPreference()
        {
            Assert.That(m_EditorContextStateColors.disableColor, Is.EqualTo(EditorHandleStateColors.editorDefaultDisableColor));
        }

        [Test]
        public void RuntimeContext_IdleColor_ShouldWarnInvalidContextAndBeMagentaColor()
        {
            Assert.That(m_RuntimeContextStateColors.idleColor, Is.EqualTo(EditorHandleStateColors.wrongContextColor));
            LogAssert.Expect(LogType.Warning, EditorHandleStateColors.wrongContextWarning);
        }

        [Test]
        public void RuntimeContext_HoverColor_ShouldWarnInvalidContextAndBeMagentaColor()
        {
            Assert.That(m_RuntimeContextStateColors.hoverColor, Is.EqualTo(EditorHandleStateColors.wrongContextColor));
            LogAssert.Expect(LogType.Warning, EditorHandleStateColors.wrongContextWarning);
        }

        [Test]
        public void RuntimeContext_DragColor_ShouldWarnInvalidContextAndBeMagentaColor()
        {
            Assert.That(m_RuntimeContextStateColors.dragColor, Is.EqualTo(EditorHandleStateColors.wrongContextColor));
            LogAssert.Expect(LogType.Warning, EditorHandleStateColors.wrongContextWarning);
        }

        [Test]
        public void RuntimeContext_DisableColor_ShouldWarnInvalidContextAndBeMagentaColor()
        {
            Assert.That(m_RuntimeContextStateColors.disableColor, Is.EqualTo(EditorHandleStateColors.wrongContextColor));
            LogAssert.Expect(LogType.Warning, EditorHandleStateColors.wrongContextWarning);
        }
    }
}
