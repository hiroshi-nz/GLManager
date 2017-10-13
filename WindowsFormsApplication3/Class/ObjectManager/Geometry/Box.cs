using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GLManager
{
    class Box
    {
        public static float[] vertexArray = new float[]
            
            {
                    //Box  Height:5, Width:5,  Depth:5,

                    //Bottom square
                    0, 0, 0,
                    5, 0, 0,
                    5, 0, 5,
                    0, 0, 5,

                    //Top square
                    0, 5, 0,
                    5, 5, 0,
                    5, 5, 5,
                    0, 5, 5,

                    //Left square
                    0, 0, 0,
                    0, 0, 5,
                    0, 5, 5,
                    0, 5, 0,

                    //Right square
                    5, 0, 0,
                    5, 0, 5,
                    5, 5, 5,
                    5, 5, 0,

                    //Front square
                    0, 0, 5,
                    0, 5, 5,
                    5, 5, 5,
                    5, 0, 5,

                    //Back square
                    0, 0, 0,
                    0, 5, 0,
                    5, 5, 0,
                    5, 0, 0,
            };
        public static Vector2[] textureArray = new Vector2[] { 
       

                    new Vector2(0.5f, 0.5f),
                    new Vector2(1.0f, 0.5f), 
                    new Vector2(1.0f, 1.0f), 
                    new Vector2(0.5f, 1.0f),

                    new Vector2(0.5f, 0.5f),
                    new Vector2(1.0f, 0.5f), 
                    new Vector2(1.0f, 1.0f), 
                    new Vector2(0.5f, 1.0f),


                    new Vector2(0.5f, 0.5f),
                    new Vector2(1.0f, 0.5f), 
                    new Vector2(1.0f, 1.0f), 
                    new Vector2(0.5f, 1.0f),


                    new Vector2(0.5f, 0.5f),
                    new Vector2(1.0f, 0.5f), 
                    new Vector2(1.0f, 1.0f), 
                    new Vector2(0.5f, 1.0f),


                    new Vector2(0.5f, 0.5f),
                    new Vector2(1.0f, 0.5f), 
                    new Vector2(1.0f, 1.0f), 
                    new Vector2(0.5f, 1.0f),


                    new Vector2(0.5f, 0.5f),
                    new Vector2(1.0f, 0.5f), 
                    new Vector2(1.0f, 1.0f), 
                    new Vector2(0.5f, 1.0f)

                        };

        public static float[] textureArray2 = new float[] { 
       

                    0.5f, 0.5f,
                    1.0f, 0.5f, 
                    1.0f, 1.0f, 
                    0.5f, 1.0f,

                    0.5f, 0.5f,
                    1.0f, 0.5f, 
                    1.0f, 1.0f, 
                    0.5f, 1.0f,


                    0.5f, 0.5f,
                    1.0f, 0.5f, 
                    1.0f, 1.0f, 
                    0.5f, 1.0f,


                    0.5f, 0.5f,
                    1.0f, 0.5f, 
                    1.0f, 1.0f, 
                    0.5f, 1.0f,


                    0.5f, 0.5f,
                    1.0f, 0.5f, 
                    1.0f, 1.0f, 
                    0.5f, 1.0f,


                    0.5f, 0.5f,
                    1.0f, 0.5f, 
                    1.0f, 1.0f, 
                    0.5f, 1.0f

                        };
    }
}
