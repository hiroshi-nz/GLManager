using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using OpenTK;

namespace GLManager
{
    class FontObject:Object
    {

        public void DrawFonts(PrimitiveType primitiveType)
        {
            //UpdateUniform();

            //special for tex with alpha
            GL.Enable(EnableCap.Blend);// In order to blend, it seems I need to draw it last.
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            //I might have to put these before uniform tex

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

            GL.Disable(EnableCap.Blend);
        }

        //panel letters related
        public float[] StringToOpenGLVertices(string sentence, Vector3 startLocation)
        {
            float height = 3;
            float width = 3;
            float offsetByEachCharacter = 3;

            float startX = startLocation.X;
            float startY = startLocation.Y;
            float startZ = startLocation.Z;

            float[] vertices = new float[sentence.Length * 12];

            for (int i = 0; i < sentence.Length; i++)
            {
                vertices[0 + i * 12] = offsetByEachCharacter * i + startX;
                vertices[1 + i * 12] = height + startY;
                vertices[2 + i * 12] = startZ;

                vertices[3 + i * 12] = offsetByEachCharacter * i + width + startX;
                vertices[4 + i * 12] = height + startY;
                vertices[5 + i * 12] = startZ;

                vertices[6 + i * 12] = offsetByEachCharacter * i + width + startX;
                vertices[7 + i * 12] = startY;
                vertices[8 + i * 12] = startZ;

                vertices[9 + i * 12] = offsetByEachCharacter * i + startX;
                vertices[10 + i * 12] = startY;
                vertices[11 + i * 12] = startZ;
            }
            return vertices;
        }

        public float[] StringToOpenGLTexture(string sentence)
        {
            //create char array, to evaluate each letter
            char[] sentenceCharArray = sentence.ToCharArray(0, sentence.Length);
            int[] charLocation = new int[sentenceCharArray.Length * 2];

            float charColumnSize = 0.166f;
            float charRowSize = 0.121f;

            for (int i = 0; i < sentenceCharArray.Length; i++)
            {
                switch (sentenceCharArray[i])//
                {
                    case 'a':
                        charLocation[i * 2] = 0;
                        charLocation[i * 2 + 1] = 0;
                        break;
                    case 'b':
                        charLocation[i * 2] = 1;
                        charLocation[i * 2 + 1] = 0;
                        break;
                    case 'c':
                        charLocation[i * 2] = 2;
                        charLocation[i * 2 + 1] = 0;
                        break;
                    case 'd':
                        charLocation[i * 2] = 3;
                        charLocation[i * 2 + 1] = 0;
                        break;
                    case 'e':
                        charLocation[i * 2] = 4;
                        charLocation[i * 2 + 1] = 0;
                        break;
                    case 'f':
                        charLocation[i * 2] = 5;
                        charLocation[i * 2 + 1] = 0;
                        break;
                    case 'g':
                        charLocation[i * 2] = 0;
                        charLocation[i * 2 + 1] = 1;
                        break;
                    case 'h':
                        charLocation[i * 2] = 1;
                        charLocation[i * 2 + 1] = 1;
                        break;
                    case 'i':
                        charLocation[i * 2] = 2;
                        charLocation[i * 2 + 1] = 1;
                        break;
                    case 'j':
                        charLocation[i * 2] = 3;
                        charLocation[i * 2 + 1] = 1;
                        break;
                    case 'k':
                        charLocation[i * 2] = 4;
                        charLocation[i * 2 + 1] = 1;
                        break;
                    case 'l':
                        charLocation[i * 2] = 5;
                        charLocation[i * 2 + 1] = 1;
                        break;
                    case 'm':
                        charLocation[i * 2] = 0;
                        charLocation[i * 2 + 1] = 2;
                        break;
                    case 'n':
                        charLocation[i * 2] = 1;
                        charLocation[i * 2 + 1] = 2;
                        break;
                    case 'o':
                        charLocation[i * 2] = 2;
                        charLocation[i * 2 + 1] = 2;
                        break;
                    case 'p':
                        charLocation[i * 2] = 3;
                        charLocation[i * 2 + 1] = 2;
                        break;
                    case 'q':
                        charLocation[i * 2] = 4;
                        charLocation[i * 2 + 1] = 2;
                        break;
                    case 'r':
                        charLocation[i * 2] = 5;
                        charLocation[i * 2 + 1] = 2;
                        break;
                    case 's':
                        charLocation[i * 2] = 0;
                        charLocation[i * 2 + 1] = 3;
                        break;
                    case 't':
                        charLocation[i * 2] = 1;
                        charLocation[i * 2 + 1] = 3;
                        break;
                    case 'u':
                        charLocation[i * 2] = 2;
                        charLocation[i * 2 + 1] = 3;
                        break;
                    case 'v':
                        charLocation[i * 2] = 3;
                        charLocation[i * 2 + 1] = 3;
                        break;
                    case 'w':
                        charLocation[i * 2] = 4;
                        charLocation[i * 2 + 1] = 3;
                        break;
                    case 'x':
                        charLocation[i * 2] = 5;
                        charLocation[i * 2 + 1] = 3;
                        break;
                    case 'y':
                        charLocation[i * 2] = 0;
                        charLocation[i * 2 + 1] = 4;
                        break;
                    case 'z':
                        charLocation[i * 2] = 1;
                        charLocation[i * 2 + 1] = 4;
                        break;
                    case '1':
                        charLocation[i * 2] = 2;
                        charLocation[i * 2 + 1] = 4;
                        break;
                    case '2':
                        charLocation[i * 2] = 3;
                        charLocation[i * 2 + 1] = 4;
                        break;
                    case '3':
                        charLocation[i * 2] = 4;
                        charLocation[i * 2 + 1] = 4;
                        break;
                    case '4':
                        charLocation[i * 2] = 5;
                        charLocation[i * 2 + 1] = 4;
                        break;
                    case '5':
                        charLocation[i * 2] = 0;
                        charLocation[i * 2 + 1] = 5;
                        break;
                    case '6':
                        charLocation[i * 2] = 1;
                        charLocation[i * 2 + 1] = 5;
                        break;
                    case '7':
                        charLocation[i * 2] = 2;
                        charLocation[i * 2 + 1] = 5;
                        break;
                    case '8':
                        charLocation[i * 2] = 3;
                        charLocation[i * 2 + 1] = 5;
                        break;
                    case '9':
                        charLocation[i * 2] = 4;
                        charLocation[i * 2 + 1] = 5;
                        break;
                    case '0':
                        charLocation[i * 2] = 5;
                        charLocation[i * 2 + 1] = 5;
                        break;
                    case ' ':
                        charLocation[i * 2] = 2147483647;//max of int
                        charLocation[i * 2 + 1] = 2147483647;
                        break;
                }
            }
            //charLocation is only xy * 1 but characterTextureCoordinates are xy * 4 
            //because of 4 points on the texture.
            float[] characterTextureCoordinates = new float[charLocation.Length * 4];
            for (int i = 0; i < characterTextureCoordinates.Length; i += 8)
            {
                if (charLocation[0 + i / 4] != 2147483647 && charLocation[1 + i / 4] != 2147483647)
                {
                    characterTextureCoordinates[0 + i] = charColumnSize * charLocation[0 + i / 4];
                    characterTextureCoordinates[1 + i] = charRowSize * charLocation[1 + i / 4];
                    characterTextureCoordinates[2 + i] = charColumnSize * (charLocation[0 + i / 4] + 1);
                    characterTextureCoordinates[3 + i] = charRowSize * charLocation[1 + i / 4];

                    characterTextureCoordinates[4 + i] = charColumnSize * (charLocation[0 + i / 4] + 1);
                    characterTextureCoordinates[5 + i] = charRowSize * (charLocation[1 + i / 4] + 1);
                    characterTextureCoordinates[6 + i] = charColumnSize * charLocation[0 + i / 4];
                    characterTextureCoordinates[7 + i] = charRowSize * (charLocation[1 + i / 4] + 1);
                }
                else
                {
                    characterTextureCoordinates[0 + i] = 0;
                    characterTextureCoordinates[1 + i] = 0;
                    characterTextureCoordinates[2 + i] = 0;
                    characterTextureCoordinates[3 + i] = 0;

                    characterTextureCoordinates[4 + i] = 0;
                    characterTextureCoordinates[5 + i] = 0;
                    characterTextureCoordinates[6 + i] = 0;
                    characterTextureCoordinates[7 + i] = 0;
                }
            }
            return characterTextureCoordinates;
        }
    }
    
}
