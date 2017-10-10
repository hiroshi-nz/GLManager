using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

/*Model Viewer and Animator 2016/3/28 start
 * Cleaning up 2017/10/09
 * 
 * version 2.07
 *
 */

namespace GLManager
{

    public partial class Form1 : Form
    {
        bool loaded = false;
        public Form1()
        {
            InitializeComponent();
        }
        // http://www.opentk.com/book/export/html/105 OpenTK must read
        Stopwatch howLong = new Stopwatch();

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
        }

        int FPSCounter = 0;
        double oneSecCounter = 0;
        double counter16ms = 0;
        double totalTimeElapsed = 0;
        int second = 0;

        void Application_Idle(object sender, EventArgs e)
        {
            while (glControl1.IsIdle)// Main loop
            {
                howLong.Stop();
                double milliseconds = howLong.Elapsed.TotalMilliseconds;
                howLong.Reset();
                howLong.Start();

                oneSecCounter += milliseconds;
                counter16ms += milliseconds;
                totalTimeElapsed += milliseconds;

                if (oneSecCounter > 1000)//Check every second how many times Glcontrol was refreshed
                {
                    label1.Text = "FPS:" + FPSCounter.ToString();
                    second = (int)Math.Round(totalTimeElapsed) / 1000;
                    label1.Text += " Totaltime:" + second.ToString();
                    FPSCounter = 0;
                    oneSecCounter = 0;
                }
                if (counter16ms > 16) //refresh rate 60hz
                {
                    glManager.Render(glUserInput.UpdateLookAt());
                    counter16ms = 0;
                    FPSCounter++;
                }
            }
        }

        GLManager glManager = new GLManager();
        GLUserInput glUserInput = new GLUserInput();
        Mouse mouse = new Mouse();

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded) return;
            glManager.Initialize(glControl1, glUserInput.lookAt);
        }
   
        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.KeyDown(glUserInput, e.KeyCode);
            glManager.Render(glUserInput.UpdateLookAt());
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {   
            if (e.Button == MouseButtons.Left)
            {
                //Cursor.Hide();
                mouse.MouseMove(glUserInput, new Point(e.X, e.Y));
                glManager.Render(glUserInput.UpdateLookAt());  
            }
          
            if (e.Button == MouseButtons.Right)
            {
                //Cursor.Hide();
                mouse.mouseRightButton = true;
            }          
        }

        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            //Cursor.Hide();
            mouse.MouseDown(new Point(e.X, e.Y));

            if (e.Button == MouseButtons.Right)
            {
                mouse.mouseRightButton = true;
            }
        }

        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse.mouseRightButton = false;
        }

        private void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                //catLocation.Y += e.Delta / 100;
            }
        }
    }
}






