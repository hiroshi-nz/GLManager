using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GLManager
{
    class Object
    {
        public VBO vbo = new VBO();
        public Shaders shaders = new Shaders();
        public List<ObjectPart> objectParts = new List<ObjectPart>();


        public void Draw()
        {
            UpdateUniform();
            
            GL.UseProgram(shaders.programID);
            GL.EnableVertexAttribArray(vbo.vertexIndex);
            GL.EnableVertexAttribArray(vbo.textureIndex);
            foreach (ObjectPart objectPart in objectParts)
            {
                GL.DrawArrays(PrimitiveType.Triangles, objectPart.startLocation, objectPart.endLocation);
            }
            GL.UseProgram(shaders.programID);
            GL.DisableVertexAttribArray(vbo.vertexIndex);
            GL.DisableVertexAttribArray(vbo.textureIndex);
        }

        public void Draw(PrimitiveType primitiveType)
        {
            UpdateUniform();

            GL.UseProgram(shaders.programID);
            GL.EnableVertexAttribArray(vbo.vertexIndex);
            GL.EnableVertexAttribArray(vbo.textureIndex);
            foreach (ObjectPart objectPart in objectParts)
            {
                GL.DrawArrays(primitiveType, objectPart.startLocation, objectPart.endLocation);
            }
            GL.UseProgram(shaders.programID);
            GL.DisableVertexAttribArray(vbo.vertexIndex);
            GL.DisableVertexAttribArray(vbo.textureIndex);
        }

        public void UseTexture(string uniformName, TextureUnit textureUnit, int sameAsTextureUnit)
        {
            GL.UseProgram(shaders.programID);
            GL.Uniform1(GL.GetUniformLocation(shaders.programID, uniformName), sameAsTextureUnit);//The number is TextureUnit number!

            GL.ActiveTexture(textureUnit);
            GL.BindTexture(TextureTarget.Texture2D, vbo.textureName);
        }

        public void UpdateUniform()
        {
            foreach(ObjectPart objectPart in objectParts)
            {
                GL.UseProgram(shaders.programID);
                GL.Uniform3(GL.GetUniformLocation(shaders.programID, objectPart.uniformName), objectPart.translationalOffset);
            }

        }
    }
}
