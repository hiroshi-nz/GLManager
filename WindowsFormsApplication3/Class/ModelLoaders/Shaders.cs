using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace GLManager
{
    class Shaders
    {
        public int programID { get; set; }

        private void loadShader(String filename, ShaderType type, int program, out int address)
        {
            address = GL.CreateShader(type);
            using (StreamReader sr = new StreamReader(filename))
            {
                GL.ShaderSource(address, sr.ReadToEnd());
                Console.WriteLine(sr.ReadToEnd());
            }
            GL.CompileShader(address);
            GL.AttachShader(program, address);
            Console.WriteLine(GL.GetShaderInfoLog(address));
        }

        public void MainShader(string vertexShaderPath, string fragmentShaderPath)
        {
            int vertexShaderID;
            int fragmentShaderID;
            programID = GL.CreateProgram();
            loadShader(vertexShaderPath, ShaderType.VertexShader, programID, out vertexShaderID);
            loadShader(fragmentShaderPath, ShaderType.FragmentShader, programID, out fragmentShaderID);
            GL.LinkProgram(programID);
            Console.WriteLine(GL.GetProgramInfoLog(programID));
        }

    }
}
