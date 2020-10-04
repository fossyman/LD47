[gd_resource type="ShaderMaterial" load_steps=2 format=2]

[sub_resource type="Shader" id=17]
code = "shader_type canvas_item;

uniform vec2 center;
uniform float force;

void fragment()
{
		vec2 disp = normalize(UV - center) * force;
		COLOR = vec4(UV - disp, 0.0f, 1.0f);
		COLOR = texture(TEXTURE, UV - vec2(0.5f, 0.0));
}"

[resource]
shader = SubResource( 17 )
shader_param/center = Vector2( 0.5, 0.5 )
shader_param/force = 0.0
