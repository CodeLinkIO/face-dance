Shader "MARS/Floor"
{
    Properties
    {
        _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
        _Fade ("Fade", Float) = 0.5
        _GradientSize ("Gradient Size", Float) = 2
        _MinFade ("Min Fade", Range(0, 1)) = 0
    }

    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        ZWrite Off
        Cull Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldUV : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Fade;
            half _MinFade;
            half _GradientSize;
            float3 _DropPos;
            fixed4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);

                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.uv = TRANSFORM_TEX(worldPos.xz, _MainTex);
                o.worldUV = worldPos;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = _Color * tex2D(_MainTex, i.uv);
                float distance = length(i.worldUV - _DropPos.xyz);

                float fadeFromBorderAmount = 1 - clamp(0, 1, (distance/_GradientSize));
                col.a = max(_MinFade, fadeFromBorderAmount);
                col.a *= _Fade;
                return col;
            }
            ENDCG
        }
    }
}
