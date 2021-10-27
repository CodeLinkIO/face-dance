using System.Collections.Generic;
using Unity.MARS.Companion.Mobile;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEditor;
using UnityEngine.Experimental.Rendering;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Companion.Core
{
    static class ThumbnailUtility
    {
        static readonly Quaternion k_PreviewRotation = Quaternion.Euler(20, -120, 0);
        static readonly Quaternion k_FirstLightRotation = k_PreviewRotation * Quaternion.Euler(40f, 40f, 0);
        static readonly Quaternion k_SecondLightRotation = k_PreviewRotation * Quaternion.Euler(340, 218, 177);
        static readonly Rect k_TextureRect = new Rect(0, 0, 256, 256);
        const float k_FieldOfView = 30.0f;
        const float k_CameraDistanceRatio = 3.8f;
        const float k_LightIntensity = 0.7f;
        const float k_Padding = 1.1f;
        static readonly Color k_BackgroundColor = Color.clear;
        static readonly Color k_AmbientLightColor = new Color(.1f, .1f, .1f, 0);
        const int k_IconSize = 144;
        const string k_ScreenshotLayerName = "Screenshot";
        const string k_TempCameraName = "Temp camera";

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<GameObject> k_GameObjects = new List<GameObject>();

        public static int screenshotLayer => LayerMask.NameToLayer(k_ScreenshotLayerName);

#if UNITY_EDITOR
        public static byte[] GeneratePrefabThumbnail(GameObject prefab)
        {
            var prefabInstance = UnityObject.Instantiate(prefab);

            var renderUtility = new PreviewRenderUtility();
            var renderCamera = renderUtility.camera;
            var renderCameraTransform = renderCamera.transform;

            renderCamera.fieldOfView = k_FieldOfView;

            renderUtility.AddSingleGO(prefabInstance);
            renderCamera.backgroundColor = k_BackgroundColor;

            var prefabList = new List<GameObject>();
            prefabList.Add(prefabInstance);

            var bounds = BoundsUtils.GetBounds(prefabList);
            var halfSize = Mathf.Max(bounds.extents.magnitude, 0.0001f);
            var distance = halfSize * k_CameraDistanceRatio;

            var pos = bounds.center - k_PreviewRotation * (Vector3.forward * distance);
            renderCameraTransform.position = pos;
            renderCameraTransform.rotation = k_PreviewRotation;
            renderCamera.nearClipPlane = distance - halfSize * k_Padding;
            renderCamera.farClipPlane = distance + halfSize * k_Padding;

            renderUtility.lights[0].intensity = k_LightIntensity;
            renderUtility.lights[0].transform.rotation = k_FirstLightRotation;
            renderUtility.lights[1].intensity = k_LightIntensity;
            renderUtility.lights[1].transform.rotation = k_SecondLightRotation;

            renderUtility.ambientColor = k_AmbientLightColor;

            renderUtility.BeginPreview(k_TextureRect, null);
            renderUtility.Render(true);

            var renderTexture = renderUtility.EndPreview() as RenderTexture;
            var temporary = RenderTexture.GetTemporary((int) k_TextureRect.width, (int) k_TextureRect.height, 0, GraphicsFormat.R8G8B8A8_UNorm);
            Graphics.Blit(renderTexture, temporary);
            RenderTexture.active = temporary;
            var texture = new Texture2D((int) k_TextureRect.width, (int) k_TextureRect.height, TextureFormat.RGBA32, false, false);
            texture.ReadPixels(new Rect(0.0f, 0.0f, k_TextureRect.width, k_TextureRect.height), 0, 0);
            texture.Apply();
            var thumbnail = texture.EncodeToPNG();

            RenderTexture.ReleaseTemporary(temporary);
            renderUtility.Cleanup();
            UnityObject.DestroyImmediate(texture);

            return thumbnail;
        }
#endif

        public static byte[] GenerateSceneThumbnail(Camera mainCamera)
        {
            var tempCamGo = new GameObject(k_TempCameraName, typeof(Camera));

            var tempCamTransform = tempCamGo.transform;
            tempCamTransform.SetWorldPose(mainCamera.transform.GetWorldPose());

            var tempCam = tempCamGo.GetComponent<Camera>();
            tempCam.fieldOfView = mainCamera.fieldOfView;
            tempCam.nearClipPlane = mainCamera.nearClipPlane;
            tempCam.farClipPlane = mainCamera.farClipPlane;
            tempCam.clearFlags = CameraClearFlags.SolidColor;
            tempCam.backgroundColor = k_BackgroundColor;
            if(screenshotLayer >= 0)
                tempCam.cullingMask = 1 << screenshotLayer;

            var captureTex = new RenderTexture(k_IconSize, k_IconSize, 24);
            var texture = new Texture2D(k_IconSize, k_IconSize, TextureFormat.RGBA32, true);
            var textureRect = new Rect(0, 0, k_IconSize, k_IconSize);

            tempCam.targetTexture = captureTex;
            tempCam.Render();

            RenderTexture.active = captureTex;

            // Read pixels
            texture.ReadPixels(textureRect, 0, 0);
            texture.Apply();
            var thumbnail = texture.EncodeToPNG();

            RenderTexture.active = null;

            UnityObject.DestroyImmediate(tempCam.gameObject);
            UnityObject.Destroy(captureTex);
            UnityObject.Destroy(texture);

            return thumbnail;
        }

        public static byte[] GenerateMarkerThumbnail(Texture2D hotSpotImage, Texture2D markerImage, List<Transform> hotspots)
        {
            var icon = ScaleToIcon(markerImage);

            var hotSpotHalfX = hotSpotImage.width / 2;
            var hotSpotHalfY = hotSpotImage.height / 2;

            // Add Hotspot Dots
            var xIsLarger = markerImage.width > markerImage.height;
            foreach (var hotspot in hotspots)
            {
                var normalizedPosition = hotspot.localPosition;

                normalizedPosition.x /= markerImage.width;
                normalizedPosition.y /= markerImage.height;

                if (xIsLarger)
                    normalizedPosition.x *= markerImage.width / (float)markerImage.height;
                else
                    normalizedPosition.y *= markerImage.height / (float)markerImage.width;

                // Convert from center to bottom anchor
                normalizedPosition.x += 0.5f;
                normalizedPosition.y += 0.5f;

                var x = (int)(normalizedPosition.x * icon.width);
                var y = (int)(normalizedPosition.y * icon.height);

                var startX = x - hotSpotHalfX;
                var startY = y - hotSpotHalfY;
                for (var i = 0; i < hotSpotImage.width; i++)
                {
                    for (var j = 0; j < hotSpotImage.height; j++)
                    {
                        var setPixX = startX + i;
                        if (setPixX < 0 || setPixX >= icon.width)
                            continue;

                        var setPixY = startY + j;
                        if (setPixY < 0 || setPixY >= icon.height)
                            continue;

                        var c = hotSpotImage.GetPixel(i, j);
                        icon.SetPixel(setPixX, setPixY, c);
                    }
                }
            }

            var thumbnail = icon.EncodeToPNG();
            UnityObject.Destroy(icon);
            return thumbnail;
        }

        public static byte[] GenerateDataRecordingThumbnail()
        {
            var screenshot = ScreenCapture.CaptureScreenshotAsTexture();
            var texture = ScaleToIcon(screenshot);
            var thumbnail = texture.EncodeToPNG();
            UnityObject.Destroy(texture);
            UnityObject.Destroy(screenshot);
            return thumbnail;
        }

        internal static byte[] GenerateEnvironmentThumbnail(List<Post> posts)
        {
            k_GameObjects.Clear();

            foreach(var post in posts)
                k_GameObjects.Add(post.gameObject);

            var bounds = BoundsUtils.GetBounds(k_GameObjects);

            var halfSize = Mathf.Max(bounds.extents.magnitude, 0.0001f);
            var distance = halfSize * 1.2f;
            var pos = bounds.center + Vector3.up * distance;

            var tempCamGo = new GameObject(k_TempCameraName, typeof(Camera));
            var tempCamTransform = tempCamGo.transform;
            tempCamTransform.position = pos;
            tempCamTransform.forward = Vector3.down;

            var tempCam = tempCamGo.GetComponent<Camera>();
            tempCam.fieldOfView = 90.0f;
            tempCam.nearClipPlane = distance - halfSize * k_Padding;
            tempCam.farClipPlane = distance + halfSize * k_Padding;
            tempCam.clearFlags = CameraClearFlags.SolidColor;
            tempCam.backgroundColor = k_BackgroundColor;
            if(screenshotLayer >= 0)
                tempCam.cullingMask = 1 << screenshotLayer;

            var captureTex = new RenderTexture(k_IconSize, k_IconSize, 24);
            captureTex.antiAliasing = 32;
            var texture = new Texture2D(k_IconSize, k_IconSize, TextureFormat.RGBA32, true);
            var textureRect = new Rect(0, 0, k_IconSize, k_IconSize);

            tempCam.targetTexture = captureTex;
            tempCam.Render();

            RenderTexture.active = captureTex;

            texture.ReadPixels(textureRect, 0, 0);
            texture.Apply();
            var thumbnail = texture.EncodeToPNG();

            RenderTexture.active = null;

            UnityObject.DestroyImmediate(tempCamGo);
            UnityObject.Destroy(captureTex);
            UnityObject.Destroy(texture);

            return thumbnail;
        }

        static Texture2D ScaleToIcon(Texture2D tex)
        {
            var icon = new Texture2D(k_IconSize, k_IconSize, TextureFormat.ARGB32, false);

            var xIsLarger = tex.width > tex.height;
            var increment = (int)Mathf.Floor((xIsLarger ? tex.height  : tex.width) / (float)k_IconSize);

            const int iconHalfSize = k_IconSize / 2;
            var xOffset = xIsLarger ? tex.width / 2 - iconHalfSize * increment : 0;
            var yOffset = xIsLarger ? 0 : tex.height / 2 - iconHalfSize * increment;
            for (var i = 0; i < k_IconSize; i++)
            {
                for (var j = 0; j < k_IconSize; j++)
                {
                    var c = tex.GetPixel(xOffset + i * increment, yOffset + j * increment);
                    icon.SetPixel(i, j, c);
                }
            }

            return icon;
        }
    }
}
