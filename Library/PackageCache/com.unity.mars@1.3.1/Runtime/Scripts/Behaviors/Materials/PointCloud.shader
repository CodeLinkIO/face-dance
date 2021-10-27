// Don't remove the following line. It is used to bypass Unity
// upgrader change. This is necessary to make sure the shader
// continues to compile on Unity 5.2
// UNITY_SHADER_NO_UPGRADE
Shader "MARS Point Cloud" {
Properties{
        _PointSize("Point Size", Float) = 5.0
}
  SubShader {
     Pass {
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag

        #include "UnityCG.cginc"

        struct appdata
        {
           float4 vertex : POSITION;
           float4 color : COLOR;
        };

        struct v2f
        {
           float4 vertex : SV_POSITION;
           float4 color : COLOR;
           float size : PSIZE;
        };

        float _PointSize;
        fixed4 _Color;

        v2f vert (appdata v)
        {
           v2f o;
           o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
           o.size = _PointSize;
           o.color = v.color;

           return o;
        }

        fixed4 frag (v2f i) : SV_Target
        {
           return i.color;
        }
        ENDCG
     }
  }
}
