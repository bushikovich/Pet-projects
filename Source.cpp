#define PI 3.14159265
#define GLUT_DISABLE_ATEXIT_HACK
float angle = 0.0;

#include <iostream>
#include <cstdlib>
#include <windows.h>
#include <conio.h> 
#include <locale.h>
#include <cmath>                                       // для функции sin

// OpenGL
#define GLUT_DISABLE_ATEXIT_HACK
#define PI 3.14159265     
//#define GLFW_DLL
//#define GLEW_STATIC

#pragma comment(lib, "libs\\GL_AL\\glfw3.lib")
#pragma comment(lib, "libs\\GL_AL\\glut32.lib")
//#pragma comment(lib, "libs\\GL_AL\\glut32.dll")
// comment(lib, "libs\\GL_AL\\alut.lib")
#pragma comment(lib, "libs\\GL_AL\\glew32.lib")
#pragma comment(lib, "libs\\GL_AL\\glew32s.lib")

// VS2013+ - bugfix - Thanks Bolsunov Dmitry
#pragma comment(lib, "msvcrt.lib")
#pragma comment(lib, "msvcmrt.lib")
#pragma comment(lib, "legacy_stdio_definitions.lib")

#include "libs\GL_AL\glew.h"
#include "libs\GL_AL\glfw3.h"
#include "libs\GL_AL\glut.h"
#include "libs\GL_AL\glm\glm.hpp"
#include "libs\GL_AL\glm\gtc\matrix_transform.hpp"
#include "libs\GL_AL\glm\gtc\type_ptr.hpp"
#include "libs\GL_AL\shader.h"
#include "libs\GL_AL\glm\gtc\random.hpp"

float colorRGB = 0.0;
namespace Cube {
    float vertices[] = {
      -0.5f, -0.5f, -0.5f, 0.0f, 0.0f,
      0.5f, -0.5f, -0.5f, 1.0f, 0.0f,
      0.5f, 0.5f, -0.5f, 1.0f, 1.0f,
      0.5f, 0.5f, -0.5f, 1.0f, 1.0f,
      -0.5f, 0.5f, -0.5f, 0.0f, 1.0f,
      -0.5f, -0.5f, -0.5f, 0.0f, 0.0f,

      -0.5f, -0.5f, 0.5f, 0.0f, 0.0f,
      0.5f, -0.5f, 0.5f, 1.0f, 0.0f,
      0.5f, 0.5f, 0.5f, 1.0f, 1.0f,
      0.5f, 0.5f, 0.5f, 1.0f, 1.0f,
      -0.5f, 0.5f, 0.5f, 0.0f, 1.0f,
      -0.5f, -0.5f, 0.5f, 0.0f, 0.0f,

      -0.5f, 0.5f, 0.5f, 1.0f, 0.0f,
      -0.5f, 0.5f, -0.5f, 1.0f, 1.0f,
      -0.5f, -0.5f, -0.5f, 0.0f, 1.0f,
      -0.5f, -0.5f, -0.5f, 0.0f, 1.0f,
      -0.5f, -0.5f, 0.5f, 0.0f, 0.0f,
      -0.5f, 0.5f, 0.5f, 1.0f, 0.0f,

      0.5f, 0.5f, 0.5f, 1.0f, 0.0f,
      0.5f, 0.5f, -0.5f, 1.0f, 1.0f,
      0.5f, -0.5f, -0.5f, 0.0f, 1.0f,
      0.5f, -0.5f, -0.5f, 0.0f, 1.0f,
      0.5f, -0.5f, 0.5f, 0.0f, 0.0f,
      0.5f, 0.5f, 0.5f, 1.0f, 0.0f,

      -0.5f, -0.5f, -0.5f, 0.0f, 1.0f,
      0.5f, -0.5f, -0.5f, 1.0f, 1.0f,
      0.5f, -0.5f, 0.5f, 1.0f, 0.0f,
      0.5f, -0.5f, 0.5f, 1.0f, 0.0f,
      -0.5f, -0.5f, 0.5f, 0.0f, 0.0f,
      -0.5f, -0.5f, -0.5f, 0.0f, 1.0f,

      -0.5f, 0.5f, -0.5f, 0.0f, 1.0f,
      0.5f, 0.5f, -0.5f, 1.0f, 1.0f,
      0.5f, 0.5f, 0.5f, 1.0f, 0.0f,
      0.5f, 0.5f, 0.5f, 1.0f, 0.0f,
      -0.5f, 0.5f, 0.5f, 0.0f, 0.0f,
      -0.5f, 0.5f, -0.5f, 0.0f, 1.0f
    };
    // world space positions of our cubes
    glm::vec3 cubePositions[] = {
      glm::vec3(0.0f, 0.0f, 0.0f),
      glm::vec3(2.0f, 5.0f, -15.0f),
      glm::vec3(-1.5f, -2.2f, -2.5f),
      glm::vec3(-3.8f, -2.0f, -12.3f),
      glm::vec3(2.4f, -0.4f, -3.5f),
      glm::vec3(-1.7f, 3.0f, -7.5f),
      glm::vec3(1.3f, -2.0f, -2.5f),
      glm::vec3(1.5f, 2.0f, -2.5f),
      glm::vec3(1.5f, 0.2f, -1.5f),
      glm::vec3(-1.3f, 1.0f, -1.5f)
    };
    unsigned int VBO;
    unsigned int VAO;
    unsigned int texture1;
    unsigned int texture2;
    Shader ourShader;

    void init() {

        {
            glGenBuffers(1, &VBO);
            glBindBuffer(GL_ARRAY_BUFFER, VBO);
            glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW);

            // position attribute
            //glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 5 * sizeof (float), (void*) 0);
            //glEnableVertexAttribArray(0);
            // texture coord attribute
            //glVertexAttribPointer(1, 2, GL_FLOAT, GL_FALSE, 5 * sizeof (float), (void*) (3 * sizeof (float)));
            //glEnableVertexAttribArray(1);
        }
    }


};
namespace Squares
{
    GLfloat vertices[] = {
      0, 0, 0,
      1, 0, 0,
      1, 1, 0,
      0, 1, 0,

      0, 0, 0,
      0, 1, 0,
      -1, 1, 0,
      -1, 0, 0
    };

    GLfloat colors[] = {

      255, 0, 0,
      255, 0, 0,
      255, 0, 0,
      255, 0, 0,

      0, 0, 255,
      0, 0, 255,
      0, 0, 255,
      0, 0, 255
    };
}

using namespace std;
template < typename T>
void println(T i)
{
    cout << i << endl;
}
void resize(GLFWwindow* window, int width, int height) {
    string s = "Width:" + width;
    s += "-Height:" + height;
    cout << "Width:" << width << "-Height:" << height << endl;

    float ratio = width / (float)height;
    glViewport(0, 0, width, height);
    glClear(GL_COLOR_BUFFER_BIT);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    glOrtho(-ratio, ratio, -1.f, 1.f, 1.f, -1.f);
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
}

#include "GLWindow.h"
#include "GLCamera.h"
#include "GLRenderSystem.h"
#include "GLShader.h"
glm::vec3 RGB = glm::vec3(0);

void keyCallback(GLFWwindow* window, int key, int scancode, int action, int mode) {
    cout<<"key:" << key << "-scancode:" << scancode << "-action:" << action << "-mode:" << mode<<endl;

    if (key == GLFW_KEY_SPACE && action == GLFW_PRESS) {
        cout<<"SPACE"<<endl;
        RGB = glm::vec3(glm::linearRand(0, 1), glm::linearRand(0, 1), glm::linearRand(0, 1));
    }
}

int main(int argc, char** argv) {
    BDO::GraphCore::GLRenderSystem* renderer;
    bool OpenGL33 = true;
    if (OpenGL33) {
        renderer = new  BDO::GraphCore::GLRender();
    }
    else
    {
        renderer = new  BDO::GraphCore::GLRendererOld2_1();
    }
    renderer->init();

    //GLFWwindow* window; // (В сопроводительном исходном коде эта переменная является глобальной)
    //window = glfwCreateWindow(640, 480, "Lesson 02", NULL, NULL);
    BDO::GLWindow* Win1 = new BDO::GLWindow("Lesson 021", 320, 240);
    //BDO::GLWindow* Win2 = new BDO::GLWindow("Lesson 022", 640, 480);
    glfwMakeContextCurrent(Win1->getGLFWHandle());

    glfwSwapInterval(1);
    // Инициализируем GLEW
    glewExperimental = true; // Флаг необходим в Core-режиме OpenGL
    if (glewInit() != GLEW_OK)
    {
        fprintf(stderr, "Невозможно инициализировать GLEW\n");
        return -1;
    }
    BDO::GraphCore::GLShader* shaderBrightDim = new BDO::GraphCore::GLShader("BrightAndDim_VertexShader.vs", "BrightAndDim_FragmentShader.fs");
    //Cube::init();
  //  glfwSetWindowSizeCallback(window, resize);
    BDO::GraphCore::Camera* CamFree = new BDO::GraphCore::GLCameraFree();
    //CamFree->setPerspective(45.0f, 640.0f / 480.0f, 0.5f, 1000.0f);
    CamFree->setPerspective(glm::radians(45.0f), (float)640 / 480, 0.01f, 1000.0f);

    // Включим режим отслеживания нажатия клавиш, для проверки ниже
    glfwSetInputMode(Win1->getGLFWHandle(), GLFW_STICKY_KEYS, GL_TRUE);
    glfwSetKeyCallback(Win1->getGLFWHandle(), keyCallback);
    // Проверяем нажатие клавиши Escape или закрытие окна
    while (glfwGetKey(Win1->getGLFWHandle(), GLFW_KEY_ESCAPE) != GLFW_PRESS &&
        glfwWindowShouldClose(Win1->getGLFWHandle()) == 0) {
        glfwMakeContextCurrent(Win1->getGLFWHandle());
        angle = glfwGetTime() * 50.0f;
        CamFree->setPos(glm::vec3(2 * cos(angle * PI / 180), 2, 2 * sin(angle * PI / 180)));

        shaderBrightDim->use();
        shaderBrightDim->setVec3("rgb", RGB);
        shaderBrightDim->setMat4("modelView", CamFree->getMat4ModelView());
        shaderBrightDim->setMat4("modelProj", CamFree->getMat4ModelProj());
        shaderBrightDim->setFloat("time", glfwGetTime());

        renderer->render(Win1->getGLFWHandle());

        glUseProgram(0);

       // CamFree->start();

        //glfwMakeContextCurrent(Win1->getGLFWHandle());
        //renderer->render(Win1->getGLFWHandle());
        //  ...
        glfwSwapBuffers(Win1->getGLFWHandle());


        //glfwMakeContextCurrent(Win2->getGLFWHandle());
        //renderer->render(Win2->getGLFWHandle());
        //   ...
        //glfwSwapBuffers(Win2->getGLFWHandle());

       // CamFree->end();
        glfwPollEvents();
        glfwMakeContextCurrent(Win1->getGLFWHandle());
    }


    glDeleteBuffers(1, &Cube::VBO);

    // glfwDestroyWindow();
    glfwTerminate();

    return 0;
}