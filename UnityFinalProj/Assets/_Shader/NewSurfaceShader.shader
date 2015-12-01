Shader "Custom/NewSurfaceShader" {
	Properties {
_NoiseTex ("Noise Texture (RG)", 2D) = "white" {}
_strength("strength", Float) = 1
}


Category {
Tags { "Queue" = "Transparent+10" }
SubShader {
GrabPass {
Name "BASE"
Tags { "LightMode" = "Always" }
}

Pass {
Name "BASE"
Tags { "LightMode" = "Always" }
Lighting Off
Cull Off
ZWrite On
ZTest LEqual
Blend SrcAlpha OneMinusSrcAlpha
AlphaTest Greater 0


CGPROGRAM
#pragma exclude_renderers d3d11 xbox360
#pragma vertex vert
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest
#pragma multi_compile_particles
#include "UnityCG.cginc"


sampler2D _GrabTexture : register(s0);
float4 _NoiseTex_ST;
sampler2D _NoiseTex;
float _strength;




struct data {
float4 vertex : POSITION;
float3 normal : NORMAL;
float4 texcoord : TEXCOORD0;
fixed4 color : COLOR;

};


struct v2f {
float4 position : POSITION;
float4 screenPos : TEXCOORD0;
float2 uvmain : TEXCOORD2;
float distortion;
fixed4 color : COLOR;
};


v2f vert(data i){
v2f o;
o.position = mul(UNITY_MATRIX_MVP, i.vertex);
o.uvmain = TRANSFORM_TEX(i.texcoord, _NoiseTex);
float viewAngle = dot(normalize(ObjSpaceViewDir(i.vertex)),i.normal);
o.distortion = viewAngle * viewAngle;
float depth = -mul( UNITY_MATRIX_MV, i.vertex ).z;
o.distortion /= 1+depth;
o.distortion *= _strength ;
o.screenPos = o.position; 
o.color= i.color;
return o;
}


half4 frag( v2f i ) : COLOR
{ 


float2 screenPos = i.screenPos.xy / i.screenPos.w; 
screenPos.x = (screenPos.x + 1) * 0.5;
screenPos.y = (screenPos.y + 1) * 0.5;


if (_ProjectionParams.x > 0)
screenPos.y = 1 - screenPos.y ;
half4 offsetColor1 = tex2D(_NoiseTex, i.uvmain ); 
screenPos.x += ((offsetColor1.r + offsetColor1.r) - 1) * i.distortion ;
screenPos.y += ((offsetColor1.g + offsetColor1.g) - 1) * i.distortion ;
half4 tex = tex2D( _GrabTexture , screenPos ) ;
half4 col = tex * i.color;
col.a = (i.distortion * i.color.a * offsetColor1.a );
return col;
}


ENDCG
}
}
SubShader{
Blend SrcAlpha OneMinusSrcAlpha
Pass{
Name "BASE"
SetTexture [_MainTex] {combine texture * primary double, texture * primary}
}
}
}
}
