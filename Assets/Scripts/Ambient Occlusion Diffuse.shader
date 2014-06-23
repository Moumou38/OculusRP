Shader "Custom/Ambient Occlusion Diffuse" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
	_AOTex ("Ambient Occlusion (RGB)", 2D) = "white" {}
	_AOFac ("Ambient Occlusion factor", Range (0.5, 30)) = 0.078125
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 300

CGPROGRAM
#pragma surface surf Lambert

sampler2D _MainTex;
sampler2D _BumpMap;
fixed4 _Color;
sampler2D _AOTex;
half _AOFac;

struct Input {
	float2 uv_MainTex;
	float2 uv_BumpMap;
	float2 uv2_AOTex;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	fixed4 ao = tex2D(_AOTex, IN.uv2_AOTex);
	ao.rgb = ((ao.rgb - 0.5f) * max(_AOFac, 0)) + 0.5f;
	o.Albedo = c.rgb  * ao.rgb;
	o.Alpha = c.a;
	o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
}
ENDCG  
}

FallBack "Diffuse"
}