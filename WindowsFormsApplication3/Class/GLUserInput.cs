using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;

namespace GLManager
{
    class GLUserInput
    {
        public Matrix4d lookAt = new Matrix4d();

        double lookdown = -1;
        // angle of rotation for the camera direction
        double angle = 0.0f;
        double verticalAngle = 0.0f;
        double lookX = 0.0f, lookZ = -1.0f, lookY = 0.0f;
        // XZ position of the camera

        double CameraY = 40;
        double CameraX = 0;
        double CameraZ = 180;

        double speedOfMovement = 10;


        public GLUserInput()
        {
            UpdateLookAt();
        }

        public void MoveForward()
        {
            CameraX += lookX * speedOfMovement;
            CameraZ += lookZ * speedOfMovement;
        }

        public void MoveBackward()
        {
            CameraX -= lookX * speedOfMovement;
            CameraZ -= lookZ * speedOfMovement;
        }

        public void TurnRight()
        {
            angle += 5;
            lookX = MathHelper.sinAngle(angle);
            lookZ = -MathHelper.cosAngle(angle);
        }

        public void TurnLeft()
        {
            angle -= 5;
            lookX = MathHelper.sinAngle(angle);
            lookZ = -MathHelper.cosAngle(angle);
        }

        public void LookDown()
        {
            lookdown--;
        }

        public void LookUp()
        {
            lookdown++;
        }

        public void MoveUp()
        {
            CameraY++;
        }

        public void MoveDown()
        {
            CameraY--;
        }

        public void LookAround(double InputX, double InputY)
        {
            angle += InputX;
            verticalAngle += InputY;

            lookY = -MathHelper.sinAngle(verticalAngle);
            lookX = MathHelper.sinAngle(angle);
            lookZ = -MathHelper.cosAngle(angle);
        }

        public Matrix4d UpdateLookAt()
        {
            lookAt = Matrix4d.LookAt(CameraX, CameraY, CameraZ,
                    CameraX + lookX, (CameraY + lookY) - 0.1 + lookdown * 0.1 + lookY, CameraZ + lookZ,
                    0, 1, 0);

            return lookAt;
        }
    }
}
