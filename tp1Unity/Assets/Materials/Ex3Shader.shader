Shader "Custom/Ex3Shader" {
	Properties {
		_Pourcent ("pourcent", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert vertex:vert

		float _Pourcent;
		float greyLevel;

		struct Input {
			float2 uv_MaterialTex;
			float mont;
		};

		float rand(float3 co)
		{
			return frac(sin(dot(co.xyz, float3(12.9898, 78.233, 45.5432))) * 43758.5453);
		}
		
		void vert(inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			v.vertex.y += 1 * rand(5 - abs(v.vertex)) * (5-abs(v.vertex.x)) * (5 - abs(v.vertex.z)) * _Pourcent * 0.5;
			o.mont = v.vertex.y;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			if (IN.mont < 0.3) {
				o.Albedo = float3(0,0,IN.mont/0.3);
			}
			else if (IN.mont < 0.7) {
				o.Albedo = float3(0, (IN.mont-0.3) / 0.4, 0);
			}
			else {
				o.Albedo = float3(IN.mont, IN.mont, IN.mont);
			}

		}
		ENDCG
	} 
	FallBack "Diffuse"
}
