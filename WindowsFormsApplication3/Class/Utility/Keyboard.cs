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
        public static void KeyDown(Object targetObject, Keys key)
        {
            if (key == Keys.NumPad8)
            {
                targetObject.MoveZ(-1);
            }
            if (key == Keys.NumPad2)
            {
                targetObject.MoveZ(1);
            }

            if (key == Keys.NumPad6)
            {
                targetObject.MoveX(1);
            }
            if (key == Keys.NumPad4)
            {
                targetObject.MoveX(-1);
            }

            if (key == Keys.NumPad9)
            {
                targetObject.MoveY(1);
            }
            if (key == Keys.NumPad3)
            {
                targetObject.MoveY(-1);
            }
            if(key == Keys.NumPad7)
            {

            }
            if(key == Keys.NumPad1)
            {

            }

        }

        public static void KeyDown(ObjectManager objectManager, Keys key)
        {
            Object currentObject = objectManager.GetCurrentObject();

            if (key == Keys.NumPad8)
            {
                currentObject.MoveZ(-1);
            }
            if (key == Keys.NumPad2)
            {
                currentObject.MoveZ(1);
            }

            if (key == Keys.NumPad6)
            {
                currentObject.MoveX(1);
            }
            if (key == Keys.NumPad4)
            {
                currentObject.MoveX(-1);
            }

            if (key == Keys.NumPad9)
            {
                currentObject.MoveY(1);
            }
            if (key == Keys.NumPad3)
            {
                currentObject.MoveY(-1);
            }
            if (key == Keys.NumPad7)
            {
                objectManager.NextObject();
            }
            if (key == Keys.NumPad1)
            {
                objectManager.NextObject();
            }

        }
        
 
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
