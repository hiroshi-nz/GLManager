using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GLManager
{
    class Mouse
    {
        Point mouseStartingLocation = new Point(0, 0);
        Point mouseNewLocation = new Point(0, 0);

        int mouseSensitivity = 2;
        public bool mouseRightButton = false;
        
        public void MouseMove(GLUserInput glUserInput, Point mousePoint)
        {
            //Cursor.Hide();

            mouseNewLocation.X = mousePoint.X;
            mouseNewLocation.Y = mousePoint.Y;

            double deltaX = (mouseNewLocation.X - mouseStartingLocation.X) * 1 / mouseSensitivity;
            double deltaY = (mouseNewLocation.Y - mouseStartingLocation.Y) * 1 / mouseSensitivity;
           
            mouseStartingLocation.X = mouseNewLocation.X;
            mouseStartingLocation.Y = mouseNewLocation.Y;

            if (mouseRightButton)
            {

            }
            else
            {
                glUserInput.LookAround(deltaX, deltaY);
            }


        }

        public void MouseDown(Point mousePoint)
        {
            mouseStartingLocation.X = mousePoint.X;
            mouseStartingLocation.Y = mousePoint.Y;
        }
    }
}
