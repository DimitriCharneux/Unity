Shader "Custom/VertexShader" {
	Properties {
		_MaterialTex ("material", 2D) = "white" {}
		_NormalText ("normal", 2D) = "white" {}
		_Pourcent ("pourcent", Range(-0.03,0.03)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert vertex:vert

		sampler2D _MaterialTex;
		sampler2D _NormalText;
		float _Pourcent;

		struct Input {
			float2 uv_MaterialTex;
		};

		void vert (inout appdata_full v) {
          v.vertex.xyz += v.normal * _Pourcent;
      	}

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MaterialTex, IN.uv_MaterialTex);
			half4 c2 = tex2D (_NormalText, IN.uv_MaterialTex);
			o.Albedo = c.rgb; //c.rgb;
			o.Alpha = c.a;
			o.Normal = c2.rgb;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
