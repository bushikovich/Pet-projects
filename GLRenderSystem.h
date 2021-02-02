/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   GLRenderSystem.h
 * Author: KnightDanila
 *
 * Created on 17 сентября 2019 г., 7:11
 */

#ifndef GLRENDERSYSTEM_H
#define GLRENDERSYSTEM_H
//float colorRGB = 0.0;
namespace BDO {
    namespace GraphCore {

        class GLRenderSystem {
        public:

            virtual void init() {
            }

            virtual void render(GLFWwindow * window) {
            }

            virtual void renderTriangleArray(GLfloat vertices[], GLfloat colors[]) {
            }

            virtual void renderVBO() {
            }
        };

        class GLRender : public GLRenderSystem {

            void init() {
                if (!glfwInit()) {
                    fprintf(stderr, "Ошибка при инициализации GLFW\n");
                    return;
                }

                glfwWindowHint(GLFW_SAMPLES, 4); // 4x Сглаживание
                //glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3); // Мы хотим использовать OpenGL 3.3
                //glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 0);
            }

            void render(GLFWwindow * window) {
                glClearColor(sin(colorRGB * PI / 180), abs(cos(colorRGB * PI / 180)), abs(sin(colorRGB * PI / 180) + cos(colorRGB * PI / 180)), 1.0f);
                glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); // also clear the depth buffer now!
                {
                    colorRGB <= 180 ? colorRGB += 0.1 : colorRGB = 0;
                }
                glEnable(GL_DEPTH_TEST);
                glMatrixMode(GL_MODELVIEW); //set the matrix to model view mode
                glPushMatrix(); // push the matrix
                angle = glfwGetTime() * 50.0f;
                glRotatef(angle, 1.0, 1.0, 0.0); //apply transformation
                glGenBuffers(1, &Cube::VBO);
                glBindBuffer(GL_ARRAY_BUFFER, Cube::VBO);
                glBufferData(GL_ARRAY_BUFFER, sizeof(Cube::vertices), Cube::vertices, GL_STATIC_DRAW);
                glVertexPointer(3, GL_FLOAT, 0, NULL);
                glBindBuffer(GL_ARRAY_BUFFER, Cube::VBO);
                glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 5 * sizeof(float), (void*)0);
                glEnableVertexAttribArray(0);
                glEnableClientState(GL_VERTEX_ARRAY);
                glDrawArrays(GL_TRIANGLES, 0, sizeof(Cube::vertices) / sizeof(Cube::vertices[0]) / 5);
                glPopMatrix();
                glEnableClientState(GL_VERTEX_ARRAY);
            }

            void renderTriangleArray(GLfloat vertices[], GLfloat colors[]) {
            }
        };

        class GLRendererOld2_1 : public GLRenderSystem {

            void init() {
                if (!glfwInit()) {
                    fprintf(stderr, "Ошибка при инициализации GLFW\n");
                }
                glfwWindowHint(GLFW_SAMPLES, 4);
                glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 2);
                glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 1);

            }

            void render(GLFWwindow * window) {
                glClearColor(sin(colorRGB * PI / 180), abs(cos(colorRGB * PI / 180)), abs(sin(colorRGB * PI / 180) + cos(colorRGB * PI / 180)), 1.0f);
                glClear(GL_COLOR_BUFFER_BIT);


                {
                    colorRGB <= 180 ? colorRGB += 0.1 : colorRGB = 0;
                }


                glLoadIdentity();
                glRotatef((float) glfwGetTime() * 50.f, 0.f, 0.f, 1.f);
                glBegin(GL_TRIANGLES);
                glColor3f(1.f, 0.f, 0.f);
                glVertex3f(-0.6f, -0.4f, 0.f);
                glColor3f(0.f, 1.f, 0.f);
                glVertex3f(0.6f, -0.4f, 0.f);
                glColor3f(0.f, 0.f, 1.f);
                glVertex3f(0.f, 0.6f, 0.f);
                glEnd();
            }

            void renderTriangleArray(GLfloat vertices[], GLfloat colors[]) {

                glClear(GL_COLOR_BUFFER_BIT);


                glEnableClientState(GL_VERTEX_ARRAY);
                glEnableClientState(GL_COLOR_ARRAY);

                glVertexPointer(3, GL_FLOAT, 0, vertices);
                glColorPointer(3, GL_FLOAT, 0, colors);

                glDrawArrays(GL_QUADS, 0, 8);


                glDisableClientState(GL_COLOR_ARRAY);
                glDisableClientState(GL_VERTEX_ARRAY);
            }

            void renderVBO()
            {
            };
        };
    }
}


#endif /* GLRENDERSYSTEM_H */

