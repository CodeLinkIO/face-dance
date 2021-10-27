using System;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using Unity.MARS.Query;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    abstract class RatingCurveDrawer<TRelation, TData> : RatingCurveDrawerBase<TRelation>
        where TRelation :
        NonBinaryRelation<float, TData>
    {
        static readonly Vector2 k_DefaultTextureSize = new Vector2(280, 100);

        public RatingCurveDrawer(TRelation relation)
            : base(relation, k_DefaultTextureSize)
        {
            m_HeaderLabel = typeof(TRelation).Name;

            m_Samples = new float[m_TextureSize.x];
            m_SamplePixelHeights = new int[m_TextureSize.x];
            m_Condition.ratingConfig = m_RatingConfig;

            SetupPreviewTexture();
            ApplyPixels();
        }

        public void OnGUI()
        {
            OnGuiInternal();
        }

        protected void Init()
        {
            m_Samples = new float[m_TextureSize.x];
            m_SamplePixelHeights = new int[m_TextureSize.x];
        }

        protected void DrawColumn(int widthIndex, int width, float distance, float increasePerStep)
        {
            var rating = m_Samples[widthIndex];
            var yPixel = m_SamplePixelHeights[widthIndex];
            var index = yPixel * width + widthIndex;

            // Draw first sample point for this column
            m_Pixels[index] = rating == 0f ? m_Red : Color.Lerp(k_MinimumRatingColor, m_Green, rating);

            // then, figure out if we need to draw more to make a good line
            var nextIndex = widthIndex < width - 1 ? widthIndex + 1 : 0;
            var nextSampleHeight = m_SamplePixelHeights[nextIndex];
            var signedNextPixelDiff = nextSampleHeight - yPixel;
            var goingUp = signedNextPixelDiff > 0f;

            if (signedNextPixelDiff >= -1 && signedNextPixelDiff <= 1)
                return;

            var end = goingUp ? signedNextPixelDiff + 1 : -signedNextPixelDiff + 1;
            var smallerStep = increasePerStep / end;

            // sample & draw more points. The reason we don't just draw up / down without sampling is that
            // it's not guaranteed that the output of RateDataMatch is continuous between this sample & the next
            for(var n = 1; n < end; n+=1)
            {
                var newDistance = distance + n * smallerStep;
                // implement SampleAtPoint in derived classes, since that's the only step that changes
                var newRating = SampleAtPoint(newDistance);
                var newYPixel = YPixelForRating(newRating);
                var newIndex = newYPixel * width + widthIndex;
                m_Pixels[newIndex] = Color.Lerp(k_MinimumRatingColor, Color.green, newRating);
            }
        }

        public override void SampleAndDraw()
        {
            if (m_Samples == null)
                Init();

            var width = m_TextureSize.x;
            const float borderWidth = 8f;
            var increasePerStep = 1f / (width - borderWidth * 2f);

            // start iterating at some point outside the condition's bounds, so that we
            // draw 10 pixels of 0 ratings & can see the cutoff point clearly
            var startingPointOutsideRange = m_Condition.minimum + increasePerStep * -borderWidth;
            for (int i = 0; i < width; i += 1)
            {
                SampleColumn(i, startingPointOutsideRange, increasePerStep);
            }
            for (int i = 0; i < width; i += 1)
            {
                DrawColumn(i, width, startingPointOutsideRange + i * increasePerStep, increasePerStep);
            }
        }

        protected abstract void SampleColumn(int widthIndex, float startPoint, float increasePerStep);

        public override string GetMouseLabel()
        {
            var width = m_TextureSize.x;
            var mouseX = Event.current.mousePosition.x;
            return m_Samples[(int)Mathf.Clamp(mouseX, 0, width)].ToString("F4");
        }
    }

    abstract class RatingCurveDrawerBase<T> where T : Component, IConfigurableMatchRating
    {
        // Using this as the negative end of our color range means that a rating at the global
        // minimum passing rating gets a color which has an exaggerated difference between it &
        // the pure red for failure, to better communicate that the rating still passes
        protected static readonly Color k_MinimumRatingColor = new Color(0.875f, 0.125f, 0f, 1f);

        /// <summary>
        /// The condition or relation we are evaluating the match rating of
        /// </summary>
        protected T m_Condition;

        protected RatingConfiguration m_RatingConfig = new RatingConfiguration(0.25f);

        protected float m_PreviousDeadZone;
        protected float m_PreviousCenter;

        protected string m_HeaderLabel;

        protected Texture2D m_PreviewTexture;
        protected Vector2Int m_TextureSize;

        protected Color[] m_BackgroundPixels;
        protected Color[] m_Pixels;

        protected float[] m_Samples;            // our results from sampling the RateDataMatch method
        protected int[] m_SamplePixelHeights;

        protected Color m_Red;
        protected Color m_Green;

        public RatingCurveDrawerBase(T condition, Vector2 textureSize)
        {
            m_TextureSize = new Vector2Int((int)textureSize.x, (int)textureSize.y);
            m_HeaderLabel = typeof(T).Name;
            m_Condition = condition;
            m_Condition.ratingConfig = m_RatingConfig;

            // cache these as member variables so we don't access these properties 100s of times per draw
            m_Red = Color.red;
            m_Green = Color.green;

            InitializeSampleBuffer();
            SetupPreviewTexture();
            SampleAndDraw();
            ApplyPixels();
        }

        protected void SetupPreviewTexture()
        {
            var width = m_TextureSize.x;
            var height = m_TextureSize.y;
            m_PreviewTexture = new Texture2D(width, m_TextureSize.y);

            var pixelCount = width * height;
            m_BackgroundPixels = new Color[pixelCount];
            m_Pixels = new Color[pixelCount];

            var yMinusOne = m_TextureSize.y - 1f;
            var yPixel = (int) Mathf.Clamp(Mathf.Floor(MARSDatabase.MinimumPassingConditionRating * yMinusOne), 0f, yMinusOne);

            var offBlack = Color.Lerp(Color.black, Color.gray, 0.3f);
            for (int i = 0; i < m_Pixels.Length; i++)
            {
                m_BackgroundPixels[i] = offBlack;
            }

            // draw the dotted line to represent the minimum condition rating
            for (int i = 0; i < width; i += 8)
            {
                var index = yPixel * width + i;
                m_BackgroundPixels[index] = Color.gray;
            }

            ResetPixels();
        }

        internal void OnGuiInternal()
        {
            if (m_PreviewTexture == null)
                return;

            EditorGUILayout.LabelField(m_HeaderLabel, EditorStyles.whiteLargeLabel);

            var newDeadZone =
                Mathf.Clamp(EditorGUILayout.FloatField("dead zone", m_RatingConfig.deadZone), 0f, 0.98f);

            var newCenter = Mathf.Clamp01(EditorGUILayout.FloatField("center", m_RatingConfig.center));

            if (newDeadZone != m_PreviousDeadZone || newCenter != m_PreviousCenter)
            {
                m_RatingConfig = new RatingConfiguration(newDeadZone, newCenter);
                m_Condition.ratingConfig = m_RatingConfig;
                DrawTexture();
            }

            var rect = EditorGUILayout.GetControlRect(false, m_TextureSize.y, GUILayout.Width(m_TextureSize.x));
            EditorGUI.DrawPreviewTexture(rect, m_PreviewTexture);

            if (rect.Contains(Event.current.mousePosition))
            {
                EditorGUIUtils.MouseLabel(GetMouseLabel());
            }

            m_PreviousDeadZone = m_RatingConfig.deadZone;
            m_PreviousCenter = m_RatingConfig.center;
        }

        void ResetPixels()
        {
            // wipe the previous frame and set it to black
            m_PreviewTexture.SetPixels(m_BackgroundPixels);
            m_BackgroundPixels.CopyTo(m_Pixels, 0);
        }

        protected void ApplyPixels()
        {
            m_PreviewTexture.SetPixels(m_Pixels);
            m_PreviewTexture.Apply();
        }

        protected void InitializeSampleBuffer()
        {
            m_Samples = new float[m_TextureSize.x];
            m_SamplePixelHeights = new int[m_TextureSize.x];
        }

        void DrawTexture()
        {
            ResetPixels();
            SampleAndDraw();
            ApplyPixels();
        }

        public virtual void SampleAndDraw() { }

        public abstract float SampleAtPoint(float pointInDistribution);

        protected int YPixelForRating(float rating)
        {
            var heightMinusOne = m_TextureSize.y - 1;
            var clamped = Mathf.Clamp(rating * heightMinusOne, 0f, heightMinusOne);
            return Mathf.RoundToInt(clamped);
        }

        public virtual string GetMouseLabel() { return String.Empty; }
    }
}
