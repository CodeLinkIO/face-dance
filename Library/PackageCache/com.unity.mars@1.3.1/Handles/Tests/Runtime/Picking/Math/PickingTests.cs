using NUnit.Framework;
using UnityEngine;

namespace Unity.MARS.MARSHandles.Tests.HandleUtility
{
    abstract class PickingTests
    {
        protected Camera camera { get; private set; }
        protected Vector2 screenCenter { get; private set; }
        protected Vector3 objectPos { get { return new Vector3(0, 0, 10); } }

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            camera = new GameObject("Camera").AddComponent<Camera>();
            camera.transform.position = new Vector3(0, 0, 0);
            camera.transform.rotation = Quaternion.identity;
            camera.fieldOfView = 90.0f;
            camera.allowDynamicResolution = false;
            camera.targetTexture = RenderTexture.GetTemporary(500, 500);
            screenCenter = new Vector2(camera.pixelWidth / 2.0f, camera.pixelHeight / 2.0f);
        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            RenderTexture.ReleaseTemporary(camera.targetTexture);
            Object.DestroyImmediate(camera.gameObject);
        }
    }
}