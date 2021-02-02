#pragma once
#ifndef GLCAMERA_H
#define GLCAMERA_H

namespace BDO {
    namespace GraphCore {

        class Camera {
        public:

            virtual void setPerspective(float fov, float aspect, float near, float far) {

            };

            virtual void setPos(glm::vec3 pos) {
            };

            virtual void setTarget(glm::vec3 pos) {

            };

            virtual glm::vec3 getPos() = 0;

            virtual void start() {
            };

            virtual void end() {
            };
            virtual glm::mat4 getMat4ModelView() = 0;
            virtual glm::mat4 getMat4ModelProj() = 0;
        protected:
            glm::mat4 _modelproj = glm::mat4(0.0f);
            glm::vec3 _pos = glm::vec3(0.0f);
            glm::vec3 _direction = glm::vec3(0.0f);
            glm::mat4 _modelview = glm::mat4(0.0f);
        };

        class GLCameraFree : public Camera {
        public:

            void setPerspective(float fov, float aspect, float near1, float far1) {
                /*
                // Calculate The Aspect Ratio Of The Window
                // The parameters are:
                // (view angle, aspect ration of the width to the height,
                //  The closest distance to the camera before it clips,
                // FOV, Ratio,  The farthest distance before it stops drawing)
                 */
                 //gluPerspective(45.0f, (GLfloat) width / (GLfloat) height, 0.5f, 3000.0f);

                glMatrixMode(GL_PROJECTION);
                _modelproj = glm::perspective(fov, aspect, near1, far1);
                glLoadMatrixf(glm::value_ptr(_modelproj));


            };

            void setPos(glm::vec3 pos) {
                glm::vec3 target = glm::vec3(0.0f);
                glm::vec3 direction = glm::normalize(pos - target);
                _modelview = glm::lookAt(pos, direction, glm::vec3(0, 1, 0));
            }
            void start() {
                glMatrixMode(GL_MODELVIEW);
                glPushMatrix();
                glLoadMatrixf(glm::value_ptr(_modelview));
            }

            void end() {
                glPopMatrix();
                //glMatrixMode(GL_PROJECTION);
                //glMatrixMode(GL_PROJECTION);
            }

            glm::vec3 getPos() {
                return glm::vec3(0);
            };
            glm::mat4 getMat4ModelView() {
                return _modelview;
            };

            glm::mat4 getMat4ModelProj() {
                return _modelproj;
            };

        };

        class GLCameraTarget : public Camera
        {

        };



    };
}

#endif /* GLCAMERA_H */