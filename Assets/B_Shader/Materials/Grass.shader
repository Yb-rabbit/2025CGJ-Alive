// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Grass"
{
	Properties
	{
		_Grass_pe1jvwp0_Albedo("Grass_pe1jvwp0_Albedo", 2D) = "white" {}
		_Grass_pe1jvwp0_NormalBent("Grass_pe1jvwp0_NormalBent", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Grass_pe1jvwp0_NormalBent;
		uniform float4 _Grass_pe1jvwp0_NormalBent_ST;
		uniform sampler2D _Grass_pe1jvwp0_Albedo;
		uniform float4 _Grass_pe1jvwp0_Albedo_ST;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Grass_pe1jvwp0_NormalBent = i.uv_texcoord * _Grass_pe1jvwp0_NormalBent_ST.xy + _Grass_pe1jvwp0_NormalBent_ST.zw;
			o.Normal = tex2D( _Grass_pe1jvwp0_NormalBent, uv_Grass_pe1jvwp0_NormalBent ).rgb;
			float2 uv_Grass_pe1jvwp0_Albedo = i.uv_texcoord * _Grass_pe1jvwp0_Albedo_ST.xy + _Grass_pe1jvwp0_Albedo_ST.zw;
			o.Albedo = tex2D( _Grass_pe1jvwp0_Albedo, uv_Grass_pe1jvwp0_Albedo ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18935
-1355;-102;1227;662;1255.009;369.6653;1.131886;True;True
Node;AmplifyShaderEditor.SamplerNode;4;-762.7321,180.3375;Inherit;True;Property;_Grass_pe1jvwp0_NormalBent;Grass_pe1jvwp0_NormalBent;1;0;Create;True;0;0;0;False;0;False;-1;8b12643a55238cf47b6ea4c03010aad4;8b12643a55238cf47b6ea4c03010aad4;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;3;-705.9306,-260.954;Inherit;True;Property;_Grass_pe1jvwp0_Albedo;Grass_pe1jvwp0_Albedo;0;0;Create;True;0;0;0;False;0;False;-1;9b941c6d347096f4e92f6b42c532fb1c;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Grass;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;0;0;3;0
WireConnection;0;1;4;0
ASEEND*/
//CHKSM=B63F527453559A10273B3432317DBDA6AE676929