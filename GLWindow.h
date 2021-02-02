/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   GLWindow.h
 * Author: KnightDanila
 *
 * Created on 17 сентября 2019 г., 0:04
 */

#ifndef GLWINDOW_H
#define GLWINDOW_H
namespace BDO {

    class GLWindow {
        GLFWwindow* _handle;
    public:
        GLWindow(const std::string& title, uint32_t width, uint32_t height)
        {
            this->_handle = glfwCreateWindow(width, height, title.data(), nullptr, nullptr);
        };
        GLWindow(const std::string& title, uint32_t width, uint32_t height, GLFWwindow* share)
        {
            _handle = glfwCreateWindow(width, height, title.data(), nullptr, share);
        };

        ~GLWindow() {
            glfwDestroyWindow(_handle);
        };
        uint32_t getWidth() const;
        uint32_t getHeight() const;

        GLFWwindow* getGLFWHandle() const
        {
            return _handle;
        };
    };
}
#endif /* GLWINDOW_H */

