Shader "Custom/Ambient Occlusion" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Shininess ("Shininess", Range (0.03, 1)) = 0.078125
		_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
		_BumpMap ("Normal Map", 2D) = "bump" {}
		_AOTex ("Ambient Occlusion (RGB)", 2D) = "white" {}
		_AOFac ("Ambient Occlusion factor", Range (0.5, 30)) = 0.078125
		_Emis ("Emission factor", Range (0, 1)) = 0
	}
	SubShader { 
		Tags { "RenderType"="Opaque" }
		LOD 400

	CGPROGRAM
	#pragma surface surf BlinnPhong

	sampler2D _MainTex;
	sampler2D _BumpMap;
	sampler2D _AOTex;
	fixed4 _Color;
	half _Shininess;
	half _AOFac;
	half _Emis;

	struct Input {
		float2 uv_MainTex;
		float2 uv_BumpMap;
		float2 uv2_AOTex;
	};

	void surf (Input IN, inout SurfaceOutput o) {
		fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
		fixed4 ao = tex2D(_AOTex, IN.uv2_AOTex);
		ao.rgb = ((ao.rgb - 0.5f) * max(_AOFac, 0)) + 0.5f;
		o.Albedo = tex.rgb * _Color.rgb * ao.rgb;
		o.Gloss = tex.a;
		o.Alpha = tex.a * _Color.a;
		o.Specular = _Shininess;
		o.Emission = tex.rgb * _Emis;
		o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
	}
	ENDCG
	}

	FallBack "Specular"
}