using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLManager
{
    class ParseObj //Obj file parsing, I need to optimize it
    {

        //read http://www.opengl-tutorial.org/beginners-tutorials/tutorial-7-model-loading/

        // v for vertex, vn for normal of vertex, f is a face.
        public static float[] ParsingVertex(string fileName)//accept non-clean text.
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
        public static float[] ParsingTexture(string fileName)//accept non-clean text.
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
        public static int[] ParsingFace(string fileName)//accept non-clean text.
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

        public static int[] ParsingFaceTexture(string fileName)//accept non-clean text.
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

        public static float[] VertexTextureAndFaceResult(float[] vertexArray, int[] faceArray)
        //working well
        {
            float[] resultArray = new float[faceArray.Length * 2];
            for (int i = 0; i < faceArray.Length; i++)
            {
                resultArray[i * 2] = vertexArray[(faceArray[i] - 1) * 2];//because of vertexArray start with [0], -1 is nessesary
                resultArray[i * 2 + 1] = vertexArray[(faceArray[i] - 1) * 2 + 1];
            }

            return resultArray;
        }

        public static float[] VertexAndFaceResult(float[] vertexArray, int[] faceArray)
        //working well
        {
            float[] resultArray = new float[faceArray.Length * 3];
            for (int i = 0; i < faceArray.Length; i++)
            {
                resultArray[i * 3] = vertexArray[(faceArray[i] - 1) * 3 + 0];//because of vertexArray start with [0], -1 is nessesary
                resultArray[i * 3 + 1] = vertexArray[(faceArray[i] - 1) * 3 + 1];
                resultArray[i * 3 + 2] = vertexArray[(faceArray[i] - 1) * 3 + 2];
            }

            return resultArray;
        }



        //===============Debug stuff==========================================================================
        public static string ParsingTextureDebug(string fileName)
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
            string debugString = "";
            for (int i = 0; i < vFloatArray.Length; i++)
            {
                debugString += vFloatArray[i] + ",\r\n";
            }
            return debugString;
        }
        public static string ParsingFaceTextureDebug(string fileName)
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
            string debugString = "";
            for (int i = 0; i < fIntArray.Length; i++)
            {
                debugString += fIntArray[i] + ",\r\n";
            }
            return debugString;
        }
        public static string VertexAndFaceResultDebug(float[] vertexArray, int[] faceArray)
        {
            float[] resultArray = new float[faceArray.Length * 3];
            for (int i = 0; i < faceArray.Length; i++)
            {
                resultArray[i * 3] = vertexArray[(faceArray[i] - 1) * 3 + 0];//because of vertexArray start with [0], -1 is nessesary
                resultArray[i * 3 + 1] = vertexArray[(faceArray[i] - 1) * 3 + 1];
                resultArray[i * 3 + 2] = vertexArray[(faceArray[i] - 1) * 3 + 2];
            }
            //return resultArray;
            string debugString = "";

            //debugString = "resultArray:" + resultArray.Length + " vertexArray:" + vertexArray.Length + " faceArray:" + faceArray.Length + "faceArray Max:" + faceArray.Max() + "\r\n";

            for (int i = 0; i < resultArray.Length; i++)
            {
                debugString += resultArray[i] + ",";
            }
            return debugString;
        }
        public static string VertexTextureAndFaceResultDebug(float[] vertexArray, int[] faceArray)
        {
            float[] resultArray = new float[faceArray.Length * 2];
            for (int i = 0; i < faceArray.Length; i++)
            {
                resultArray[i * 2] = vertexArray[(faceArray[i] - 1) * 2];//because of vertexArray start with [0], -1 is nessesary
                resultArray[i * 2 + 1] = vertexArray[(faceArray[i] - 1) * 2 + 1];
            }
            //return resultArray;
            string debugString = "";

            debugString = "resultArray:" + resultArray.Length + " vertexArray:" + vertexArray.Length + " faceArray:" + faceArray.Length + "faceArray Max:" + faceArray.Max() + "\r\n";

            for (int i = 0; i < resultArray.Length; i++)
            {
                debugString += resultArray[i] + ",";
            }
            return debugString;
        }
    }
}

