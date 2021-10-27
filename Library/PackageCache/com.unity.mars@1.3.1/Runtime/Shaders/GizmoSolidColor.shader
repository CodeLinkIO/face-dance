Shader "Unity/Handles/GizmoSolidColor"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Power ("Power", float) = 1.9
        _EdgeShading ("Edge Shading", float) = 0.6
        _EdgeSize ("Edge Size", float) = 0.4
    }

    SubShader
    {
        Tags
        {
            "IgnoreProjector"="True" "RenderType"="Transparent"
        }
        
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            float4 _Color;
            float _Power;
            float _EdgeShading;
            float _EdgeSize;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldSpaceNormal : TEXCOORD0;
                float3 worldSpaceViewDirection : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);

                float4 worldPos = mul(unity_ObjectToWorld, v.vertex);
                o.worldSpaceNormal = UnityObjectToWorldNormal(v.normal);
                o.worldSpaceViewDirection = normalize(UnityWorldSpaceViewDir(worldPos));
                return o;
            }

            half4 frag (v2f i) : COLOR
            {
                float4 color = _Color;

                float fresnel = pow(1.0 - dot(i.worldSpaceNormal, i.worldSpaceViewDirection), _Power);
                float remap = (1 - fresnel) * (1 + _EdgeSize) - _EdgeSize;

                color.rgb *= max(_EdgeShading, remap);

                return color;
            }

            ENDCG
        }
    }
}
