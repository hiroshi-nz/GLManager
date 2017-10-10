using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace GLManager
{
    class GLManager
    {

        FontExample fontExample = new FontExample();
        Example1 world = new Example1();

        GLControl glControl = new GLControl();

        public GLManager()
        {
            
        }

        public void Initialize(GLControl glControl, Matrix4d lookat)
        {

            this.glControl = glControl;

            GL.ClearColor(Color.Black);
            SetupViewport();
            
            GL.Enable(EnableCap.DepthTest);

            world.InitializeWorld();
            fontExample.InitializeFont();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            glControl.SwapBuffers();

            Render(lookat);
            GL.GetError();
        }

        public void Render(Matrix4d lookat)
        {
            GL.LoadIdentity();

            GL.LoadMatrix(ref lookat);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Color3(Color.White);

            world.DrawWorld();
            fontExample.Draw();


            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.Flush();
            glControl.SwapBuffers();
            GL.BindTexture(TextureTarget.Texture2D, 0);//unbind the texture http://gamedev.stackexchange.com/questions/10732/loading-textures-in-opengl-makes-everything-look-darker http://stackoverflow.com/questions/15273674/binding-a-zero-texture-in-opengl  
        }

        private void SetupViewport()
        {
            int w = glControl.Width;
            int h = glControl.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area            
            Matrix4 perspectiveMatrix = Matrix4.CreatePerspectiveFieldOfView(
            0.25f, w / h,
            50.0f, 500);
            GL.LoadMatrix(ref perspectiveMatrix);
            GL.MatrixMode(MatrixMode.Modelview);
        }
    }
}
