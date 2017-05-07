Shader "Hidden/Test" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Pass {
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#include "UnityCG.cginc"
		
			uniform sampler2D _MainTex;
			
 
			fixed4 frag (v2f_img i) : COLOR {
				fixed4 base = tex2D(_MainTex, i.uv);
				return float4(base.r,base.g,1,1);
			}
			ENDCG
		}
	}
}