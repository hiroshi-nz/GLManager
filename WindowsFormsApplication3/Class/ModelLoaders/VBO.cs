using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace GLManager
{
    class VBO
    {
        public int vertexVBO { get; set; }
        public int textureVBO { get; set; }
        public int vertexIndex { get; set; }
        public int textureIndex { get; set; }
        public int arrayLength { get; set; }

        public float[] verticesAndFaceResult { get; set; }//ObjToVBO
        public int textureName { get; set; }//ObjToVBO

        public void VertexTextureFromString(int vertexIndex, int textureIndex, string verticesArrayPath, string textureArrayPath)
        {

            int vertexVBO;
            int textureVBO;
            this.vertexIndex = vertexIndex;
            this.textureIndex = textureIndex;

            float[] vertexArray = VerticesFromText.LoadFloatArrayFromText(verticesArrayPath);
            float[] textureArray = VerticesFromText.TwoVertices(textureArrayPath);

            GL.GenBuffers(1, out vertexVBO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertexArray.Length * sizeof(float)), vertexArray, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(vertexIndex, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            GL.GenBuffers(1, out textureVBO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, textureVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(textureArray.Length * sizeof(float)), textureArray, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(textureIndex, 2, VertexAttribPointerType.Float, true, 0, 0);

            this.vertexVBO = vertexVBO;
            this.textureVBO = textureVBO;
        }

        public void Vertex(int vertexIndex, float[] vertexArray)
        {

            int vertexVBO;
            this.vertexIndex = vertexIndex;

            GL.GenBuffers(1, out vertexVBO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertexArray.Length * sizeof(float)), vertexArray, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(vertexIndex, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            this.vertexVBO = vertexVBO;
            arrayLength = vertexArray.Length;
        }

        public void VertexTexture(int vertexIndex, int textureIndex, float[] verticesAndFaceResult, float[] textureVerticesAndFaceResult)//proper one
        {

            int vertexVBO;
            int textureVBO;

            this.vertexIndex = vertexIndex;
            this.textureIndex = textureIndex;

            GL.GenBuffers(1, out vertexVBO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(verticesAndFaceResult.Length * sizeof(float)), verticesAndFaceResult, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(vertexIndex, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            GL.GenBuffers(1, out textureVBO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, textureVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(textureVerticesAndFaceResult.Length * sizeof(float)), textureVerticesAndFaceResult, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(textureIndex, 2, VertexAttribPointerType.Float, true, 0, 0);

            this.vertexVBO = vertexVBO;
            this.textureVBO = textureVBO;

            this.vertexVBO = vertexVBO;
            arrayLength = verticesAndFaceResult.Length;
        }

        public void ObjToVBO(int vertexIndex, int textureIndex, string objFileName, string textureFileName)//Dependent on ParseObj
        {



            //------------------vertices parsing---------------------------------
            float[] vertices = ParsingVertex(objFileName);
            int[] verticesFace = ParsingFace(objFileName);

            //===================from VertexAndFaceResult=========================
            //generating final vertices array from v and f
            verticesAndFaceResult = new float[verticesFace.Length * 3];
            for (int i = 0; i < verticesFace.Length; i++)
            {
                verticesAndFaceResult[i * 3] = vertices[(verticesFace[i] - 1) * 3 + 0];//because of vertexArray start with [0], -1 is nessesary
                verticesAndFaceResult[i * 3 + 1] = vertices[(verticesFace[i] - 1) * 3 + 1];
                verticesAndFaceResult[i * 3 + 2] = vertices[(verticesFace[i] - 1) * 3 + 2];
            }

            //------------------texture parsing----------------------------
            float[] textureVertices = ParsingTexture(objFileName);
            int[] textureFace = ParsingFaceTexture(objFileName);

            //=============from VertexTextureAndFaceResult======================
            //generating final vertices array from vt and f
            float[] textureVerticesAndFaceResult = new float[textureFace.Length * 2];
            for (int i = 0; i < textureFace.Length; i++)
            {
                textureVerticesAndFaceResult[i * 2] = textureVertices[(textureFace[i] - 1) * 2];//because of vertexArray start with [0], -1 is nessesary
                textureVerticesAndFaceResult[i * 2 + 1] = textureVertices[(textureFace[i] - 1) * 2 + 1];
            }

            //==================== from VertexTexture============================
            int vertexVBO;
            int textureVBO;

            this.vertexIndex = vertexIndex;
            this.textureIndex = textureIndex;

            GL.GenBuffers(1, out vertexVBO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(verticesAndFaceResult.Length * sizeof(float)), verticesAndFaceResult, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(vertexIndex, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            GL.GenBuffers(1, out textureVBO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, textureVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(textureVerticesAndFaceResult.Length * sizeof(float)), textureVerticesAndFaceResult, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(textureIndex, 2, VertexAttribPointerType.Float, true, 0, 0);

            this.vertexVBO = vertexVBO;
            this.textureVBO = textureVBO;

            this.vertexVBO = vertexVBO;
            arrayLength = verticesAndFaceResult.Length;


            //Also load the texture too!
            LoadTexture(textureFileName);
        }

        public void LoadTexture(string textureFileName)// GenTextures "out" cannot pass value outside class,
        //so I needed use return to pass textureName...
        {
            int textureName;//textureName will be set after out textureName, so I don't pass it as an argument.
            Bitmap img = new Bitmap(textureFileName);//it needed to be vertically flipped...
            BitmapData data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            GL.GenTextures(1, out textureName);

            GL.BindTexture(TextureTarget.Texture2D, textureName);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                                        OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            img.UnlockBits(data);
            GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (float)TextureEnvMode.Modulate);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            this.textureName = textureName;
        }



        //==========from ParseObj PRIVATE=======================

        //read http://www.opengl-tutorial.org/beginners-tutorials/tutorial-7-model-loading/

        // v for vertex, vn for normal of vertex, f is a face.
        private static float[] ParsingVertex(string fileName)//accept non-clean text.
        {
            string v = "";
            string srLine;

            System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
            while ((srLine = sr.ReadLine()) != null)
            {
                if (srLine.StartsWith("v ") == true)//v is for vertex
                {
                    srLine = srLine.Replace("v ", "");
                    string[] parsedTextArray = srLine.Split(' ');
                    for (int i = 0; i < parsedTextArray.Length; i++)
                    {
                        v += parsedTextArray[i] + ",";
                    }
                }
            }
            string[] parsedVStringArray = v.Split(',');//parsing the text for last time.
            float[] vFloatArray = new float[parsedVStringArray.Length - 1];//the last array is empty because of extra ","

            for (int i = 0; i < vFloatArray.Length; i++)
            {
                vFloatArray[i] = float.Parse(parsedVStringArray[i]);
            }
            return vFloatArray;
        }

        // v for vertex, vn for normal of vertex, f is a face.
        private static float[] ParsingTexture(string fileName)//accept non-clean text.
        {
            string v = "";
            string srLine;

            System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
            while ((srLine = sr.ReadLine()) != null)
            {
                if (srLine.StartsWith("vt ") == true)//v is for vertex
                {
                    srLine = srLine.Replace("vt ", "");
                    string[] parsedTextArray = srLine.Split(' ');
                    for (int i = 0; i < parsedTextArray.Length; i++)
                    {
                        v += parsedTextArray[i] + ",";
                    }
                }
            }
            string[] parsedVStringArray = v.Split(',');//parsing the text for last time.
            float[] vFloatArray = new float[parsedVStringArray.Length - 1];//the last array is empty because of extra ","

            for (int i = 0; i < vFloatArray.Length; i++)
            {
                vFloatArray[i] = float.Parse(parsedVStringArray[i]);
            }
            return vFloatArray;
        }

        // v for vertex, vn for normal of vertex, f is a face.
        private static int[] ParsingFace(string fileName)//accept non-clean text.
        {
            string f = "";
            string srLine;
            System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
            while ((srLine = sr.ReadLine()) != null)
            {
                if (srLine.StartsWith("f ") == true)//f is face
                {
                    srLine = srLine.Replace("f ", "");
                    srLine = srLine.Replace("//", "/");//why double slash?
                    string[] parsedTextArray = srLine.Split(' ');
                    for (int i = 0; i < parsedTextArray.Length; i++)
                    {
                        f += parsedTextArray[i] + ",";
                    }
                }
            }
            string[] parsedVStringArray = f.Split(',');//parsing the text for last time.
            int[] fIntArray = new int[parsedVStringArray.Length - 1];//the last array is empty because of extra ","

            for (int i = 0; i < fIntArray.Length; i++)
            {
                string[] fSplit = parsedVStringArray[i].Split('/');

                fIntArray[i] = int.Parse(fSplit[0]);//first of fSplit is info about vertex
            }
            return fIntArray;
        }

        private static int[] ParsingFaceTexture(string fileName)//accept non-clean text.
        //made new one for texture instead of adding arguement for ParsingFace
        {
            string f = "";
            string srLine;
            System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
            while ((srLine = sr.ReadLine()) != null)
            {
                if (srLine.StartsWith("f ") == true)//f is face
                {
                    srLine = srLine.Replace("f ", "");
                    srLine = srLine.Replace("//", "/");//why double slash?
                    string[] parsedTextArray = srLine.Split(' ');
                    for (int i = 0; i < parsedTextArray.Length; i++)
                    {
                        f += parsedTextArray[i] + ",";
                    }
                }
            }
            string[] parsedVStringArray = f.Split(',');//parsing the text for last time.
            int[] fIntArray = new int[parsedVStringArray.Length - 1];//the last array is empty because of extra ","

            for (int i = 0; i < fIntArray.Length; i++)
            {
                string[] fSplit = parsedVStringArray[i].Split('/');

                fIntArray[i] = int.Parse(fSplit[1]);//second of fSplit is info about texture
            }
            return fIntArray;
        }
    }
}
