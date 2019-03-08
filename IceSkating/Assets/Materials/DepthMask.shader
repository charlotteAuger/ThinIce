Shader "Masked/Mask" {
 
	SubShader {
		// Render the mask after regular geometry, but before masked geometry and
		// transparent things.
 
		Tags {"Queue" = "Geometry-10" }
 
		// Don't draw in the RGBA channels; just the depth buffer
 
		ColorMask 0
		ZTest Always
		ZWrite On
		Offset -1, -1
		//Lighting Off
 
		// Do nothing specific in the pass:
 
		Pass {}
	}
}
