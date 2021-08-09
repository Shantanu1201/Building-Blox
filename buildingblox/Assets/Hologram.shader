/* A hologram shader by modifying alpha value, z-buffer and the Rim color*/

Shader "Binigya/Hologram"
{

	Properties
	{
	
		_RimColor("Rim Light Color", Color) = (0, 0.5, 0.5, 0.0)
		_RimPower("Rim Light Power", Range(0.5,8.0)) = 7.0
	
	}
	
	
	SubShader
	{
	
	//One thing run through the shader = 1 draw call = 1 pass
	//Can do multiple passes within Shaders
	
		Tags
		{
			"Queue" = "Transparent" 
		}
		
	
		Pass 
		{
			ZWrite On  //write depth data about the model in the Z-Buffer
			ColorMask 0 //don't write any color pixels in the frame buffer!
		}
		
		
		
		CGPROGRAM
		
		#pragma surface surf Lambert alpha:fade
		
		struct Input
		{
			float3 viewDir;
		};
		
		float4 _RimColor;
		float _RimPower;
		
		void surf (Input IN, inout SurfaceOutput o)
		{
			
			half rim = 1.0 - saturate( dot(normalize(IN.viewDir), o.Normal));
			o.Emission = _RimColor.rgb * pow (rim, _RimPower) * 10;
			o.Alpha = pow(rim, _RimPower);
		}
	
		ENDCG
	
	}

	Fallback "Diffuse"

}