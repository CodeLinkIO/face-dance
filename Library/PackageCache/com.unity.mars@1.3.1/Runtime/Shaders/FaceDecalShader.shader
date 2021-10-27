Shader "MARS/FaceDecalShader"
{
 Properties
 {
        [HideInInspector]
        _DecalTex ("Decal", 2D) = "white" {}
        [HideInInspector]
        _DecalPositionOffset ("Decal Position Offset", Vector) = (0.0,0.0,0.0,0.0)
        [HideInInspector]
        _DecalSize ("Decal Size", Vector) = (1.0,1.0,0.0,0.0)
        [HideInInspector]
        _SrcBlend ("Source Blending Mode", Int) = 0
        [HideInInspector]
        _DstBlend ("Dest Blending Mode", Int) = 0
        [HideInInspector]
        _BlendOp ("Blending operation", Int) = 0
 }
 SubShader
 {
        Tags {"Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        BlendOp [_BlendOp]
        Blend [_SrcBlend] [_DstBlend]

     Pass
     {
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #pragma multi_compile BLEND_ADD BLEND_MULTIPLY BLEND_NORMAL BLEND_DIFFERENCE BLEND_OVERLAY BLEND_SUBSTRACT BLEND_SCREEN

        #include "UnityCG.cginc"
        #include "UnityUI.cginc"

        struct appdata
        {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
        };

        struct v2f
        {
            float2 uv_decal : TEXCOORD0;
            float4 vertex : SV_POSITION;
        };

        sampler2D _DecalTex;
        float4 _DecalTex_ST;

        float4 _DecalPositionOffset;
        float4 _DecalSize;

        v2f vert (appdata v)
        {
         v2f o;

         o.vertex = UnityObjectToClipPos(v.vertex);
            //First line: UV from texture.
            //Second line: Offset the DecalSize to compensate for not centered pivot
            //Third line: Extra offset set by User
            //Fourth line: Correction to make Bottom Left be 0,0 and Top Right 1,1
            //Fifth line: Scaling properly based on Size set by User
            o.uv_decal = (TRANSFORM_TEX(v.vertex.xy, _DecalTex)
                - float2((1 - _DecalSize.x) * 0.5, (1 - _DecalSize.y) * 0.5) 
                - float2(_DecalPositionOffset.x, _DecalPositionOffset.y)
                + float2(1.0,1.0))
                / float2(_DecalSize.x, _DecalSize.y);
         return o;
        }

        fixed4 frag (v2f i) : SV_Target
        {

            fixed4 decalColor = tex2D(_DecalTex, i.uv_decal);
            // Clamp edges to 0 alpha
            decalColor.a *= (1.0 - step(1.0, abs(i.uv_decal.x - 0.5)*2));
            decalColor.a *= (1.0 - step(1.0, abs(i.uv_decal.y - 0.5)*2));

            // Premultiply the alpha - lets us switch blending modes less often
            decalColor.rgb *= decalColor.a;

            return decalColor;
        }

        ENDCG
    }
 }
}
