#version 330 core

out vec4 FragColor;
  
in vec4 vertexColor; // the input variable from the vertex shader (same name and same type)  

uniform float time;
uniform vec3 rgb;
uniform mat4 modelView;
uniform mat4 modelProj;

void main()
{
    FragColor = vec4(rgb*(sin(time)+1)/2,1);
} 