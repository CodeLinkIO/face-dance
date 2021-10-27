using UnityEditor;
using UnityEngine;
using ZXing;
using ZXing.QrCode;

namespace Unity.MARS.Companion.Core
{
    /// <summary>
    /// Displays a QR code for linking MARS Companion Apps to Unity projects
    /// </summary>
    public class CompanionLinkWindow : EditorWindow
    {
        /// <summary>
        /// The title which should be used for instances of CompanionLinkWindow
        /// </summary>
        public const string Title = "Companion Project Link";

        const string k_MenuItemString = "Window/MARS/Companion Project Link";
        const int k_TextureSize = 256;
        const float k_TextHeight = 18;
        static readonly Vector2 k_MaxSize = new Vector2(k_TextureSize, k_TextureSize + k_TextHeight);
        static readonly BarcodeWriter k_Writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = k_TextureSize,
                Width = k_TextureSize
            }
        };

        Texture2D m_QRCode;

        [MenuItem(k_MenuItemString)]
        static void OnMenuItem()
        {
            GetWindow<CompanionLinkWindow>(true, Title);
        }

        [MenuItem(k_MenuItemString, true)]
        static bool ValidateMenuItem() { return !string.IsNullOrEmpty(Application.cloudProjectId); }

        void OnEnable()
        {
            maxSize = k_MaxSize;
            minSize = k_MaxSize;
        }

        void OnGUI()
        {
            var cloudProjectId = Application.cloudProjectId;
            if (string.IsNullOrEmpty(cloudProjectId))
            {
                GUILayout.Label("Please connect this project to cloud services");
                GUIUtility.ExitGUI();
            }

            // Texture is destroyed on exiting play mode but OnEnabled is not called, we need to create the texture in OnGUI
            if (m_QRCode == null)
            {
                var pixels = k_Writer.Write(cloudProjectId);
                m_QRCode = new Texture2D(k_TextureSize, k_TextureSize);
                m_QRCode.SetPixels32(pixels);
                m_QRCode.Apply();
            }

            var rect = new Rect(0, 0, k_TextureSize, k_TextureSize);
            GUI.DrawTexture(rect, m_QRCode);
            rect.y = k_TextureSize;
            rect.height = k_TextHeight;
            GUI.TextField(rect, cloudProjectId);
        }
    }
}
