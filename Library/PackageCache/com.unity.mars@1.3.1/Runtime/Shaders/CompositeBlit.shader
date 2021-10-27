Shader "MARS/CompositeBlit"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {} // Composite Camera
    }
    SubShader
    {
        Tags { }
        Cull Off ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile _ PREMULTIPLY_OVERLAY

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _CompositeBlitOverlayTex;
            sampler2D _CompositeAlphaSourceTex;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float4 a = saturate(tex2D(_CompositeBlitOverlayTex, i.uv));
                float alpha = saturate(tex2D(_CompositeAlphaSourceTex, i.uv).a);
                float4 b = saturate(tex2D(_MainTex, i.uv));

                float4 col;
#if PREMULTIPLY_OVERLAY
                col.rgb = (a.rgb) + (b.rgb * (1-alpha));
#else
                col.rgb = (a.rgb * alpha) + (b.rgb * (1-alpha));
#endif
                col.a = 1;
                return col;
            }
            ENDCG
        }
    }
}
