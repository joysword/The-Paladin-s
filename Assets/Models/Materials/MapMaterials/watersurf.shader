Shader "Custom/watersurf" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness("Smoothness", Range(0,1)) = 1
        _Metallic("Metallic", Range(0,1)) = 1
            _Time("Time",Float) = 0
            _Var1("Var1",Float) = 2
        _Var2("Var2", Float) = 0.4
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
            float t = _Time * 100;
            o.Albedo = _Color;
            float2 uv = IN.uv_MainTex;
            uv[0] + t;
            uv[0] += sin(t + uv[1] * 40) * 0.04;
            uv[1] += cos(t + uv[0] * 40) * 0.04;
            
            o.Normal = UnpackNormal(tex2D(_MainTex, uv));
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = 1;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
