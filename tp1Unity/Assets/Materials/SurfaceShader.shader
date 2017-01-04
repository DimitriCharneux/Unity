Shader "Custom/SurfaceShader" {
	Properties {
		_WoodTex ("wood", 2D) = "white" {}
		_JeanText ("jean", 2D) = "white" {}
		_Pourcent ("Pourcent", Range(0.0,1.0)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _WoodTex;
		sampler2D _JeanText;
		float _Pourcent;

		struct Input {
			float2 uv_WoodTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_WoodTex, IN.uv_WoodTex);
			half4 c2 = tex2D (_JeanText, IN.uv_WoodTex);
			o.Albedo = c.rgb * _Pourcent + c2.rgb * (1 - _Pourcent); //c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
