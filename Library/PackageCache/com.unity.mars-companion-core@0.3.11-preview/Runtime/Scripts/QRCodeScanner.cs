using System;
using System.Threading;
using UnityEngine;
using ZXing;

namespace Unity.MARS.Companion.Core
{
    class QRCodeScanner : MonoBehaviour
    {
#if !PLATFORM_LUMIN
        const int k_WebCamFPS = 20;

        bool m_Running;
        string m_LastResult;
        string m_CurrentResult;
        Color32[] m_CapturedImage;
        int m_CamTextureWidth;
        int m_CamTextureHeight;
        Action<Texture> m_TextureSetupCallback;
        Action<string> m_ScanCallback;
        bool m_WebCamReady;
        bool m_ShouldStartScanning;
        bool m_ShouldStopScanning;
        WebCamTexture m_WebCamTexture;
#endif

        public void StartScanning(Action<string> scanCallback, Action<Texture> textureSetupCallback)
        {
#if PLATFORM_LUMIN
            throw new NotImplementedException();
#else
            m_ShouldStartScanning = true;
            m_ScanCallback = scanCallback;
            m_TextureSetupCallback = textureSetupCallback;

            if (m_WebCamTexture != null)
                textureSetupCallback?.Invoke(m_WebCamTexture);
#endif
        }

        public void StopScanning()
        {
#if PLATFORM_LUMIN
            throw new NotImplementedException();
#else
            m_ScanCallback = null;
            m_TextureSetupCallback = null;

            if (m_ShouldStartScanning)
            {
                m_ShouldStartScanning = false;
                return;
            }

            m_ShouldStopScanning = true;
#endif
        }

#if !PLATFORM_LUMIN
        void DecodeQR()
        {
            // create a reader with a custom luminance source
            var barcodeReader = new BarcodeReader { AutoRotate = false };
            while (m_Running)
            {
                try
                {
                    if (m_CapturedImage == null)
                    {
                        Thread.Sleep(30);
                        continue;
                    }

                    // decode the current frame
                    var result = barcodeReader.Decode(m_CapturedImage, m_CamTextureWidth, m_CamTextureHeight);
                    m_CurrentResult = result?.Text;

                    // Sleep a little bit and set the signal to get the next frame
                    Thread.Sleep(200);
                    m_CapturedImage = null;
                }
                catch (Exception e)
                {
                    Debug.LogErrorFormat("Error reading QR Code: {0}\n{1}", e.Message, e.StackTrace);
                }
            }
        }

        void Update()
        {
            if (m_WebCamTexture == null)
            {
                if (!m_WebCamReady)
                    return;

                if (WebCamTexture.devices.Length == 0)
                    return;

                m_WebCamTexture = new WebCamTexture(WebCamTexture.devices[0].name);
                m_WebCamTexture.requestedHeight = Screen.width;
                m_WebCamTexture.requestedWidth = Screen.width;
                m_WebCamTexture.requestedFPS = k_WebCamFPS;
                m_TextureSetupCallback?.Invoke(m_WebCamTexture);
            }

            if (m_ShouldStartScanning)
            {
                m_ShouldStartScanning = false;
                m_WebCamTexture.Play();

                m_Running = true;
                new Thread(DecodeQR).Start();
            }

            if (m_ShouldStopScanning)
            {
                m_ShouldStopScanning = false;
                m_Running = false;
                m_WebCamTexture.Stop();
            }

            if (m_CapturedImage == null && m_WebCamTexture.isPlaying)
            {
                m_CamTextureWidth = m_WebCamTexture.width;
                m_CamTextureHeight = m_WebCamTexture.height;
                m_CapturedImage = m_WebCamTexture.GetPixels32();
            }

            if (!string.IsNullOrEmpty(m_CurrentResult))
            {
                if (m_CurrentResult != m_LastResult)
                    m_ScanCallback?.Invoke(m_CurrentResult);
            }

            m_LastResult = m_CurrentResult;
        }
#endif

        public void UpdateImageRect(RectTransform rectTransform, out Rect uvRect)
        {
#if !PLATFORM_LUMIN
            uvRect = default;
            if (m_CapturedImage == null)
                return;

            var containerSize = rectTransform.rect.size;
            var containerAspect = containerSize.x / containerSize.y;
            var imageAspect = (float)m_CamTextureWidth / m_CamTextureHeight;
            if (imageAspect > containerAspect)
            {
                var width = containerAspect / imageAspect;
#if !UNITY_EDITOR && UNITY_IOS
                uvRect.height = -1;
                uvRect.y = 1;
#else
                uvRect.height = 1;
                uvRect.y = 0;
#endif
                uvRect.width = width;
                uvRect.x = (1 - width) * 0.5f;
            }
            else
            {
                var height = imageAspect / containerAspect;
                uvRect.x = 0;
                uvRect.width = 1;

#if !UNITY_EDITOR && UNITY_IOS
                uvRect.height = -height;
                uvRect.y = (1 - height) * 0.5f + height;
#else
                uvRect.height = height;
                uvRect.y = (1 - height) * 0.5f;
#endif
            }
#else
            uvRect = new Rect(Vector2.zero, Vector2.one);
#endif
        }

        public void NotifyWebCamReady()
        {
#if !PLATFORM_LUMIN
            m_WebCamReady = true;
#endif
        }

#if !PLATFORM_LUMIN
        void OnApplicationQuit() { m_Running = false; }
#endif
    }
}
