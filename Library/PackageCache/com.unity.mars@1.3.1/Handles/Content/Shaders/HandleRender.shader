Shader "Hidden/MARS/Handles/HandleRender"
{
    Properties
    {
		_MainTex("Texture to blend", 2D) = "white" {}
    }

    SubShader
    {
		Tags
		{
			"Queue" = "Transparent"
		}

		Pass
		{
			Blend One One
			SetTexture[_MainTex] { combine texture }
		}
    }
}
