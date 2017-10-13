using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLManager
{
    class ShaderGenerator
    {
        public string UniformVec3(string name)
        {
            string msg = "";
            msg += String.Format("uniform vec3 {0};\r\n", name);
            return msg;
        }

        public string Vec3(string name)
        {
            string msg = "";
            msg += String.Format("vec3 {0};\r\n", name);
            return msg;
        }

        public string LayoutLocation(int index, string type, string name)
        {
            string msg = "";
            msg += String.Format("layout(location = {0}) in {1} {2};\r\n", index, type, name);
            return msg;
        }

        public string MoveObject(string vertexPosition, string offsetVec3)
        {
            string msg = "";
            msg += String.Format("{0}.x = {0}.x + {1}.x;\r\n", vertexPosition, offsetVec3);
            msg += String.Format("{0}.y = {0}.y + {1}.y;\r\n", vertexPosition, offsetVec3);
            msg += String.Format("{0}.z = {0}.z + {1}.z;\r\n", vertexPosition, offsetVec3);
            return msg;
        }

        public string ScaleObject(string vertexPosition, string offsetVec3)
        {
            string msg = "";
            msg += String.Format("{0}.x = {0}.x * {1};\r\n", vertexPosition, offsetVec3);
            msg += String.Format("{0}.y = {0}.y * {1};\r\n", vertexPosition, offsetVec3);
            msg += String.Format("{0}.z = {0}.z * {1};\r\n", vertexPosition, offsetVec3);
            return msg;
        }

        public string Functions()
        {
            string msg = "";
            msg += @"
                mat3 roll = mat3(
                   cos(rotationAngle), sin(rotationAngle), 0, // first column (not row!)
                   -sin(rotationAngle), cos(rotationAngle), 0, // second column
                   0, 0, 1  // third column
                );

                mat3 pitch = mat3(
                   1, 0, 0,
                   0, cos(rotationAngle), sin(rotationAngle),
                   0,-sin(rotationAngle), cos(rotationAngle)
  
                );

                mat3 yaw = mat3(
                   cos(rotationAngle), 0, -sin(rotationAngle),
                   0, 1, 0 ,
                   sin(rotationAngle), 0, cos(rotationAngle)  
                );           
            ";

            return msg;
        }

        public void GenerateCode(Object myObject)
        {
            string msg = "";
            msg += "#version 410 compatibility\r\n";
            msg += UniformVec3("objectLocation");
            msg += "float scale = 0.1;\r\n";

            foreach (ObjectPart objectPart in myObject.objectParts)
            {
                msg += UniformVec3(objectPart.uniformName + "Offset");//remove offset from uniform
                msg += UniformVec3(objectPart.uniformName + "RotationalAngles");

            }
            msg += LayoutLocation(myObject.vbo.vertexIndex, "vec3", "vertexPosition");
            msg += LayoutLocation(myObject.vbo.textureIndex, "vec2", "textureCoordinate");
            msg += "out vec2 fragmentTextureCoordinate;\r\n";
            //msg += "vec3 translatedBackPosition;\r\n";
            msg += "void main(){\r\n";

            msg += "vec4 v = vec4(vertexPosition, 1);\r\n";
            msg += ScaleObject("v", "scale");
            msg += MoveObject("v", "objectLocation");
            //msg += Functions();
            msg += "gl_Position =  gl_ModelViewProjectionMatrix * v;\r\n";
            msg += "fragmentTextureCoordinate = textureCoordinate;\r\n";
            msg += "}\r\n";

            Console.Write(msg);

        }
    }
}
