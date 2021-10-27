Shader "MARS/PlaneWithEdgeTransparent"
{
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
		_EdgeColor ("Edge Color", Color) = (1,1,1,1)
		_EdgeGradient ("Gradient", Float) = 1
		_MainTex ("Texture", 2D) = "white" {}
		_EdgeTex ("Edge Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags {"Queue"="Transparent" "RenderType"="Transparent"}
		LOD 100
		Cull Off
		ZWrite Off
		Offset -1, 0
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_instancing

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
			};

			sampler2D _MainTex;
			sampler2D _EdgeTex;
			float4 _MainTex_ST;
			fixed4 _Color;
			fixed4 _EdgeColor;
			float _EdgeGradient;

			v2f vert (appdata v)
			{
				v2f o;

				UNITY_SETUP_INSTANCE_ID(v);

				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv2 = v.uv2;
				return o;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				float4 col = tex2D(_MainTex, i.uv) * _Color;

				float edge = i.uv2.y;
				// If there are no edge polys then uv2 is zero.
				if (edge > 0.05) {
					// Gradient
					edge = pow(i.uv2.y, _EdgeGradient);

					// Texture
					float4 texCol = tex2D(_EdgeTex, i.uv2);

					return lerp(col, texCol * _EdgeColor, edge);
				}
				return col;
			}
			ENDCG
		}
	}
}
