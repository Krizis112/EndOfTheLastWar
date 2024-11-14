shader_type canvas_item;
uniform float blur_amount : hint_range(0.0, 5.0) = 3.0;
uniform float kernel_size : hint_range(0.0, 25.0, 0.1) = 10.0f;
uniform bool is_selected = false;

uniform vec4 simple_blur_color : source_color = vec4(1.0, 1.0, 1.0, 0.2);
// whether to use complex blur or not. complex blur usually has more
// cost, but it's real time and is kinda good ig.
uniform bool complex_blur = false;

void fragment() {
	vec4 color = texture(TEXTURE, UV);
	if (is_selected) {
		if (complex_blur) {
			vec2 texture_size = vec2(textureSize(TEXTURE, 0));
			vec2 pixel_size = 1.0 / texture_size;
			vec4 blur_color = vec4(0.0);
			
			for (float x = -kernel_size; x <= kernel_size; x++) {
				for (float y = -kernel_size; y <= kernel_size; y++) {
					vec2 offset = vec2(x, y) * pixel_size * blur_amount;
					blur_color += texture(TEXTURE, UV + offset);
				}
			}
			
			blur_color /= (kernel_size * 2.0 + 1.0) * (kernel_size * 2.0 + 1.0);
			COLOR = mix(color, blur_color, 0.5);
		} else {
			// we will do simple blur
			COLOR = mix(color, simple_blur_color, simple_blur_color.a);
		}
    }
}
