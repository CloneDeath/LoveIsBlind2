shader_type spatial;
render_mode depth_draw_always;
render_mode cull_disabled;

uniform float strength_fade = 10.0;
uniform float strength_speed = 3.0;
uniform float strength = 100.0;
uniform vec3 touch_point;

void fragment() {
	vec4 pos = CAMERA_MATRIX * vec4(VERTEX, 1.0);
	float dist = (-length(pos.xyz - touch_point)*strength_fade) + strength * strength_speed * strength_fade;
	ALPHA = dist;
	
	ALBEDO = COLOR.rgb;
}