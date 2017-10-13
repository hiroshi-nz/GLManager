using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

//not showing up!
namespace GLManager
{
    class FontExample
    {
        FontObject fontObject = new FontObject();
    
        public void InitializeFont() 
        {
            string message = "hello world";            
            float[] texbuff = fontObject.StringToOpenGLTexture(message);
            float[] verbuff = fontObject.StringToOpenGLVertices(message, new Vector3(-30, 10, -70));
            fontObject.vbo.VertexTexture(5, 6, verbuff, texbuff);
            fontObject.shaders.MainShader("shaders/panelVertexShader.txt", "shaders/panelFragmentShader.txt");
            fontObject.vbo.LoadTexture("textures/font.png");//load texture separately
            fontObject.objectParts.Add(new ObjectPart("font", new Vector3(0, 0, 0), new Vector3(0, 0, 0), 0, 400));
        }

        public void Draw()
        {
            UseTextures();
            fontObject.DrawFonts(PrimitiveType.Quads);
        }

        public void UseTextures()
        {
            fontObject.UseTexture("fontTexture", TextureUnit.Texture1, 1);
        }
    }
}
