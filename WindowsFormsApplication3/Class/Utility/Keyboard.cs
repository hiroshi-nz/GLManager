using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GLManager
{
    class Keyboard
    {          
       public static void KeyDown(GLUserInput glUserInput, Keys key)
       {
            if (key == Keys.A)
            {
                glUserInput.TurnLeft();
            }
            if (key == Keys.D)
            {
                glUserInput.TurnRight();
            }
            if (key == Keys.W)
            {
                glUserInput.MoveForward();
            }
            if (key == Keys.S)
            {
                glUserInput.MoveBackward();
            }

            if (key == Keys.E)
            {
                glUserInput.MoveUp();
            }

            if (key == Keys.C)
            {
                glUserInput.MoveDown();
            }

            if (key == Keys.Q)
            { 
                glUserInput.LookUp(); 
            }
            if (key == Keys.Z)
            { 
                glUserInput.LookDown(); 
            }
            glUserInput.UpdateLookAt();
            }
    }
}
