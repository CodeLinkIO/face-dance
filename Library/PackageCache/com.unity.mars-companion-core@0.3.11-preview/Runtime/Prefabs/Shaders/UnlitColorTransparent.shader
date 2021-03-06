Shader "Unlit/Transparent Color"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
    }

    SubShader
    {
        Tags
        {
            "IgnoreProjector"="True" "RenderType"="Transparent"
        }
        Lighting Off
        ZTest LEqual
        ZWrite Off
        Cull Back
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            float4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex.xyz);
                return o;
            }

            half4 frag (v2f i) : COLOR
            {
                return _Color;
            }

            ENDCG
        }
    }
}
