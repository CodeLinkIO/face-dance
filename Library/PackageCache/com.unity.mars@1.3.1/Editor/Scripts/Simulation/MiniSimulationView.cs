using System;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor.AnimatedValues;
using UnityEditor.MARS.Simulation.Rendering;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// Simulation view that can be drawn to a window and supports basic camera controls and composite rendering
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public class MiniSimulationView : ScriptableObject, ISimulationView, ICompositeView
    {
        [NonSerialized]
        static readonly Vector3 k_DefaultPivot = Vector3.zero;

        [NonSerialized]
        static readonly Quaternion k_DefaultRotation = Quaternion.LookRotation(new Vector3(-1, -.7f, -1));

        const float k_PerspectiveFov = 90;
        const float k_DefaultViewSize = 10f;
        const float k_OrthoThresholdAngle = 3f;

        [SerializeField]
        [Tooltip("Is rotation locked")]
        AnimBool m_RotationLocked = new AnimBool();

        [SerializeField]
        [Tooltip("Is the scene view ortho.")]
        AnimBool m_Ortho = new AnimBool(false);

        [SerializeField]
        [Tooltip("Camera used to render the view.")]
        Camera m_Camera;

        [SerializeField]
        RenderTexture m_OutputTexture;

        [SerializeField]
        RenderTexture m_CameraTargetTexture;

        [SerializeField]
        [Tooltip("The direction of the scene view. Modify it to rotate the view immediately, or use LookAt to animate it nicely.")]
        AnimQuaternion m_Rotation = new AnimQuaternion(k_DefaultRotation);

        [SerializeField]
        [Tooltip("Center point of the view. Modify it to move the view immediately, or use LookAt to animate it nicely.")]
        AnimVector3 m_Position = new AnimVector3(k_DefaultPivot);

        [SerializeField]
        [Tooltip("The size of the view measured diagonally.")]
        AnimFloat m_Size = new AnimFloat(k_DefaultViewSize);

        [SerializeField]
        [Tooltip("Type of view mode that is being used")]
        ViewSceneType m_SceneType = ViewSceneType.Simulation;

        [SerializeField]
        [Tooltip("Frame the view on start")]
        bool m_FramedOnStart;

        /// <summary>
        /// Type of view mode that is being used
        /// </summary>
        public ViewSceneType SceneType
        {
            get => m_SceneType;
            set => m_SceneType = value;
        }

        /// <summary>
        /// Is rotation locked
        /// </summary>
        public bool isRotationLocked
        {
            get => m_RotationLocked.target;
            set => m_RotationLocked.target = value;
        }

        /// <summary>
        /// Is the scene view ortho.
        /// </summary>
        public bool orthographic
        {
            get => m_Ortho.value;
            set => m_Ortho.value = value;
        }

        /// <summary>
        /// Center point of the view. Modify it to move the view immediately, or use LookAt to animate it nicely.
        /// </summary>
        public Vector3 pivot
        {
            get => m_Position.value;
            set => m_Position.value = value;
        }

        /// <summary>
        /// The direction of the scene view. Modify it to rotate the view immediately,
        /// or use LookAt to animate it nicely.
        /// </summary>
        public Quaternion rotation
        {
            get => m_Rotation.value;
            set => m_Rotation.value = value;
        }

        /// <summary>
        /// The size of the view measured diagonally.
        /// </summary>
        public float size
        {
            get => m_Size.value;
            set
            {
                if (value > 40000f)
                    value = 40000;

                m_Size.value = value;
            }
        }

        /// <summary>
        /// Camera used to render the view.
        /// </summary>
        public Camera camera => m_Camera;

        static bool useFallbackRendering => CompositeRenderModuleOptions.instance.UseFallbackCompositeRendering;
        static bool useCameraStackInFallback => CompositeRenderModuleOptions.instance.UseCameraStackInFallback;

        /// <inheritdoc />
        public ContextViewType ContextViewType => ContextViewType.OtherView;
        /// <inheritdoc />
        public Camera TargetCamera => m_Camera;
        /// <summary>
        /// The composite camera being used in the view
        /// </summary>
        public Camera CompositeCamera { get; private set; }
        /// <inheritdoc />
        public RenderTextureDescriptor CameraTargetDescriptor => m_OutputTexture.descriptor;
        /// <inheritdoc />
        public Color BackgroundColor => Color.clear;
        /// <inheritdoc />
        public bool ShowImageEffects => true;
        /// <inheritdoc />
        public bool BackgroundSceneActive => false;
        /// <inheritdoc />
        public bool DesaturateComposited => false;
        /// <inheritdoc />
        public bool UseXRay => true;

        /// <summary>
        /// Initialize the mini simulation view
        /// </summary>
        /// <param name="width">width of the viewport</param>
        /// <param name="height">height of the viewport</param>
        public void InitMiniSimulationView(float width, float height)
        {
            CreateCamera(width, height);

            if (CompositeRenderModule.GetActiveCompositeRenderModule(out var compositeRenderModule))
            {
                // Remove as a safety if Init was called multiple times.
                compositeRenderModule.RemoveView(this);
                compositeRenderModule.AddView(this);

                if (CompositeRenderModule.TryGetCompositeRenderContext(this, out var context))
                {
                    CompositeCamera = context.CompositeCamera;
                    context.BackgroundClearFlag = CameraClearFlags.SolidColor;
                    context.SetBackgroundColor(Color.black);
                }
            }

            m_Rotation.valueChanged.AddListener(Repaint);
            m_Position.valueChanged.AddListener(Repaint);
            m_Size.valueChanged.AddListener(Repaint);
            m_Ortho.valueChanged.AddListener(Repaint);
        }

        void OnDestroy()
        {
            if (CompositeRenderModule.GetActiveCompositeRenderModule(out var compositeRenderModule))
                compositeRenderModule.RemoveView(this);

            if (m_Camera != null)
            {
                if (m_Camera.targetTexture != null)
                    m_Camera.targetTexture.Release();

                m_Camera.targetTexture = null;

                UnityObjectUtils.Destroy(m_Camera.gameObject);
                m_Camera = null;
            }

            if (m_OutputTexture != null)
            {
                m_OutputTexture.Release();
                UnityObjectUtils.Destroy(m_OutputTexture);
                m_OutputTexture = null;
            }
        }

        void CreateCamera(float width = 1f, float height = 1f)
        {
            if (m_Camera != null)
            {
                if (m_Camera.targetTexture != null)
                    m_Camera.targetTexture.Release();

                m_Camera.targetTexture = null;

                UnityObjectUtils.Destroy(m_Camera.gameObject);
                m_Camera = null;
            }

            var camObject = EditorUtility.CreateGameObjectWithHideFlags($"Mini Sim View Camera {GetInstanceID()}",
                HideFlags.HideAndDontSave,
                typeof(Camera));
            m_Camera = camObject.GetComponent<Camera>();

            var intWidth = width > 1 ? (int)width : 1;
            var intHeight = height > 1 ? (int)height : 1;

            m_Camera.cameraType = CameraType.SceneView;
            m_Camera.clearFlags = CameraClearFlags.SolidColor;

            m_Camera.backgroundColor = Color.clear;

            m_Camera.aspect = intWidth / (float)intHeight;
            m_Camera.transform.position = m_Position.value + m_Camera.transform.rotation
                * new Vector3(0, 0, -CalculateCameraDistance());

            if (CompositeRenderModule.TryGetCompositeRenderContext(this, out var context))
            {
                context.SetTargetCamera(m_Camera);
                CompositeCamera = context.CompositeCamera;
            }

            PrepareRenderTargets(intWidth, intHeight);
        }

        /// <inheritdoc/>
        // Based on SceneView.LookAt
        public void LookAt(Vector3 point, Quaternion direction, float newSize, bool ortho, bool instant)
        {
            FixNegativeSize();
            if (instant)
            {
                m_Position.value = point;
                m_Rotation.value = direction;
                m_Size.value = Mathf.Abs(newSize);
                m_Ortho.value = ortho;
            }
            else
            {
                m_Position.target = point;
                m_Rotation.target = direction;
                m_Size.target = Mathf.Abs(newSize);
                m_Ortho.target = ortho;
            }
        }

        /// <inheritdoc/>
        public void Repaint()
        {
            if (Event.current == null || Event.current.type == EventType.Layout)
                return;

            SetupCamera();
            Render();
        }

        /// <summary>
        /// Render the view as a single frame only
        /// </summary>
        /// <param name="frameView">Frame the view</param>
        /// <returns>The render texture output of the view's composite</returns>
        public RenderTexture SingleFrameRepaint(bool frameView = false)
        {
            SetupViewAsSimUser(frameView);
            SetupCamera();
            Render();

            return m_OutputTexture;
        }

        /// <inheritdoc/>
        public void SetupViewAsSimUser(bool forceFrame = false)
        {
            var moduleLoaderCore = ModuleLoaderCore.instance;
            if (moduleLoaderCore == null || !moduleLoaderCore.ModulesAreLoaded)
                return;

            if (m_Camera != null && CompositeRenderModule.TryGetCompositeRenderContext(this, out var context))
                context.AssignCameraToSimulation();

            var envManager = moduleLoaderCore.GetModule<MARSEnvironmentManager>();
            if (envManager == null)
                return;

            if (!m_FramedOnStart || forceFrame)
            {
                envManager.TryFrameSimViewOnEnvironment(this, true);
                m_FramedOnStart = true;
            }
        }

        void PrepareRenderTargets(int width, int height)
        {
            width = width < 1 ? 1 : width;
            height = height < 1 ? 1 : height;

            var aspect = width / (float)height;
            m_Camera.aspect = aspect;

            var hdr = m_Camera.allowHDR;

            // Adapted from SceneView.CreateCameraTargetTexture
            // make sure we actually support R16G16B16A16_SFloat
            var format = (hdr && SystemInfo.IsFormatSupported(GraphicsFormat.R16G16B16A16_SFloat, FormatUsage.Render))
                ? GraphicsFormat.R16G16B16A16_SFloat : SystemInfo.GetGraphicsFormat(DefaultFormat.LDR);

            PrepareRenderTexture(ref m_OutputTexture,$"Mini Sim View Output Texture {GetInstanceID()}",
                format, width, height);

            PrepareRenderTexture(ref m_CameraTargetTexture,  $"Mini Sim View Camera Target {GetInstanceID()}",
                format, width, height);

            m_Camera.targetTexture = m_CameraTargetTexture;

            if (CompositeRenderModule.TryGetCompositeRenderContext(this, out var context))
                context.SetRenderTextureDescriptor(m_OutputTexture.descriptor);
        }

        static void PrepareRenderTexture(ref RenderTexture textureTarget, string textureName,
            GraphicsFormat format, int width, int height)
        {
            if (textureTarget != null && textureTarget.graphicsFormat != format)
            {
                UnityObjectUtils.Destroy(textureTarget);
                textureTarget = null;
            }

            if (textureTarget == null)
            {
                textureTarget = new RenderTexture(width, height, 24, format)
                {
                    name = textureName,
                    antiAliasing = 1,
                    hideFlags = HideFlags.HideAndDontSave
                };
            }

            if (textureTarget.width != width || textureTarget.height != height)
            {
                textureTarget.Release();
                textureTarget.width = width;
                textureTarget.height = height;
            }

            textureTarget.Create();
        }

        // Based on SceneView.CalculateCameraDistance
        float CalculateCameraDistance()
        {
            var fov = m_Ortho.Fade(k_PerspectiveFov, 0);

            if (!m_Camera.orthographic)
                return size / Mathf.Tan(fov * 0.5f * Mathf.Deg2Rad);

            return size * 2f;
        }

        // Based on SceneView.SetupCamera
        void SetupCamera()
        {
            if ((!useFallbackRendering || (useCameraStackInFallback && useFallbackRendering))
                && (m_Camera == null || CompositeCamera == null))
                CreateCamera();
            else if (m_Camera == null)
                CreateCamera();

            // If you zoom out enough, m_Position would get corrupted with no way to reset it,
            // even after restarting Unity. Crude hack to at least get the scene view working again!
            if (m_Position.value.x.IsUndefined())
                m_Position.value = Vector3.zero;

            if (m_Rotation.value.x.IsUndefined())
                m_Rotation.value = Quaternion.identity;

            m_Camera.transform.rotation = m_Rotation.value;
            m_Camera.backgroundColor = Color.clear;

            var fov = m_Ortho.Fade(k_PerspectiveFov, 0);
            if (fov > k_OrthoThresholdAngle)
            {
                m_Camera.orthographic = false;
                m_Camera.fieldOfView = m_Camera.GetVerticalFOV(fov);
            }
            else
            {
                m_Camera.orthographic = true;
                m_Camera.orthographicSize = m_Camera.GetVerticalOrthoSize(size);
            }

            m_Camera.transform.position = m_Position.value + m_Camera.transform.rotation
                * new Vector3(0, 0, -CalculateCameraDistance());

            var farClip = Mathf.Max(1000f, 2000f * size);
            m_Camera.nearClipPlane = farClip * 0.000005f;
            m_Camera.farClipPlane = farClip;

            if (CompositeRenderModule.TryGetCompositeRenderContext(this, out var context))
                context.UpdateCompositeCamera();
        }

        // Based on SceneView.FixNegativeSize
        void FixNegativeSize()
        {
            if (size >= 0)
                return;

            var distance = size / Mathf.Tan(k_PerspectiveFov * 0.5f * Mathf.Deg2Rad);
            var p = m_Position.value + rotation * new Vector3(0, 0, -distance);
            size = -size;
            distance = size / Mathf.Tan(k_PerspectiveFov * 0.5f * Mathf.Deg2Rad);
            m_Position.value = p + rotation * new Vector3(0, 0, distance);
        }

        /// <summary>
        /// Draw as a dynamic view in the given rect.
        /// </summary>
        /// <param name="rect">Rect to draw the View.</param>
        public void DrawMarsRenderView(Rect rect)
        {
            switch (Event.current.type)
            {
                case EventType.Layout:
                    SetupCamera();

                    SetupViewAsSimUser();

                    PrepareRenderTargets((int) rect.width, (int) rect.height);
                    break;
                case EventType.Repaint:
                    Repaint();
                    EditorGUI.DrawPreviewTexture(rect, m_OutputTexture);
                    break;
            }
        }


        void Render()
        {
            if (!CompositeRenderModule.TryGetCompositeRenderContext(this, out var context))
                return;

            if (useFallbackRendering && useCameraStackInFallback)
            {
                context.PreCompositeCullTargetCamera();
                CompositeCamera.Render();
                Graphics.Blit(context.CompositeCameraTexture, m_CameraTargetTexture);

                RenderTexture.active = null;
                m_Camera.clearFlags = CameraClearFlags.Depth;
                m_Camera.Render();
                context.PostCompositeRenderTargetCamera();
                Graphics.Blit(m_CameraTargetTexture, m_OutputTexture);
            }
            else if(useFallbackRendering)
            {
                context.PreCompositeCullTargetCamera();
                m_Camera.clearFlags = CameraClearFlags.SolidColor;
                m_Camera.Render();
                context.PostCompositeRenderTargetCamera();
                Graphics.Blit(m_CameraTargetTexture, m_OutputTexture);
            }
            else
            {
                m_Camera.Render();
                Graphics.Blit(m_CameraTargetTexture, m_OutputTexture);
            }

            // Need to set active render texture to null or else GUI will try to draw to it after using graphics blit
            RenderTexture.active = null;
        }
    }
}
