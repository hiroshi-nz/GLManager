using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLManager
{
    //Only needed parsing from C# array, I don't need to run every time. I think I should make cleanning tool separately
    class VerticesFromText
    {

        public static float[] LoadFloatArrayFromText(string fileName)//accept non-clean text.
        {
            string srLine;
            string parsedText = "";
            System.IO.StreamReader sr = new System.IO.StreamReader(fileName);

            int arrayCounter = 0;
            //first pass is finding out how many array elements are there.
            while ((srLine = sr.ReadLine()) != null)
            {
                //textBox1.AppendText(srLine + "\r\n"); DEBUG
                srLine = srLine.Replace(" ", "");//removing spaces and indentations
                if (srLine.StartsWith("//") == false)//removing comment
                {
                    string[] parsedVertices = srLine.Split(',');
                    foreach (string parsedVertex in parsedVertices)
                    {
                        if (parsedVertex != "")//remove empty entries
                        {
                            arrayCounter++;
                            parsedText += parsedVertex + ",";
                            //textBox2.AppendText(parsedVertex + "\r\n");debug
                        }
                    }
                }
            }
            if (arrayCounter % 3 == 0)//check the array is legal triple vertices or not
            {

                //Console.WriteLine("Total array length is " + arrayCounter + ", devisible by 3, and has " + arrayCounter / 3 + " vertices");
            }
            else
            {
                //Console.WriteLine("Total array length is " + arrayCounter + " and not devisible by 3\r\n");
            }
            //Found out how many array elements are there and its legal or not.

            string[] parsedTextArray = parsedText.Split(',');//parsing the text for last time.
            float[] vertexArray = new float[parsedTextArray.Length];

            for (int i = 0; i < parsedTextArray.Length - 1; i++) // -1 because of the last array is empty
            {
                if (float.TryParse(parsedTextArray[i], out vertexArray[i]) == true)//playing safe
                {
                    //textBox2.AppendText(vertexArray[i].ToString() + "\r\n");  DEBUG
                }
                else
                {
                    //Console.WriteLine("error there is other than number\r\n");
                }
            }
            return vertexArray;
        }

        public static float[] TwoVertices(string fileName)//accept non-clean text.
        {

            string srLine;
            string parsedText = "";
            System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
            string errorMessage = "";

            int arrayCounter = 0;
            //first pass is finding out how many array elements are there.
            while ((srLine = sr.ReadLine()) != null)
            {
                //errorMessage += srLine + "\r\n";//DEBUG
                srLine = srLine.Replace("new Vector2(", "");//remove "new Vector2(" key words
                srLine = srLine.Replace(")", "");//Replace ")"
                srLine = srLine.Replace("f", "");//remove 'f'
                srLine = srLine.Replace(" ", "");//removing spaces and indentations

                if (srLine.StartsWith("//") == false)//removing comment
                {
                    string[] parsedVertices = srLine.Split(',');
                    foreach (string parsedVertex in parsedVertices)
                    {
                        if (parsedVertex != "")//remove empty entries
                        {
                            arrayCounter++;
                            parsedText += parsedVertex + ",";
                            //errorMessage += parsedVertex + "\r\n";//DEBUG
                        }
                    }
                }
            }
            if (arrayCounter % 2 == 0)//check the array is legal triple vertices or not
            {
                //Console.WriteLine("Total array length is " + arrayCounter + ", devisible by 2, and has " + arrayCounter/2 + " vertices");
            }
            else
            {
                //Console.WriteLine("Total array length is " + arrayCounter + " and not devisible by 2\r\n");
            }
            //Found out how many array elements are there and its legal or not.

            string[] parsedTextArray = parsedText.Split(',');//parsing the text for last time.
            float[] vertexArray = new float[parsedTextArray.Length];

            for (int i = 0; i < parsedTextArray.Length - 1; i++) // -1 because of the last array is empty
            {
                if (float.TryParse(parsedTextArray[i], out vertexArray[i]) == true)//playing safe
                {
                    errorMessage += vertexArray[i].ToString() + "\r\n";  //DEBUG
                }
                else
                {
                    //Console.WriteLine("error there is other than number\r\n");
                }
            }
            //return errorMessage;//DEBUG
            return vertexArray;
        }
    }
}

