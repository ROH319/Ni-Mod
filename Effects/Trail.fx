﻿sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
sampler uImage2 : register(s2);
sampler uImage3 : register(s3);
float3 uColor;
float3 uSecondaryColor;
float2 uScreenResolution;
float2 uScreenPosition;
float2 uTargetPosition;
float2 uDirection;
float uOpacity;
float uTime;
float uIntensity;
float uProgress;
float2 uImageSize1;
float2 uImageSize2;
float2 uImageSize3;
float2 uImageOffset;
float uSaturation;
float4 uSourceRect;
float2 uZoom;

float4x4 uTransform;


struct VSInput {
	float2 Pos : POSITION0;
	float4 Color : COLOR0;
	float3 Texcoord : TEXCOORD0;
};

struct PSInput {
	float4 Pos : SV_POSITION;
	float4 Color : COLOR0;
	float3 Texcoord : TEXCOORD0;
};

float3 hsv2rgb(float3 c)
{
    float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
    float3 p = abs((c.xxx + K.xyz - floor(c.xxx + K.xyz)) * 6.0 - K.www);
    return c.z * lerp(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
}

float4 PixelShaderFunction(PSInput input) : COLOR0 {
	float3 coord = input.Texcoord;
	float y = uTime + coord.x;//插值，让图片循环采样
	float4 c1 = tex2D(uImage1, float2(coord.x, coord.y));//image1是形状（激光），c1就是取色
	float4 c3 = tex2D(uImage2, float2(y, coord.y));//image2是蒙版
	c1 *= c3;
	float4 c = tex2D(uImage0, float2(c1.r, 0));//image0是热度图，用了c1.r也就是黑白图片的亮度来做插值，亮度高的地方就映射到右边，亮度低就映射到左边
	if (c.r < 0.1)
		return float4(0, 0, 0, 0);
	return 2 * c * coord.z;//纹理坐标的z是透明度
}

PSInput VertexShaderFunction(VSInput input)  {
	PSInput output;
	output.Color = input.Color;
	output.Texcoord = input.Texcoord;
	output.Pos = mul(float4(input.Pos, 0, 1), uTransform);
	return output;
}


technique Technique1 {
	pass ColorBar {
		VertexShader = compile vs_2_0 VertexShaderFunction();
		PixelShader = compile ps_2_0 PixelShaderFunction();
	}
}