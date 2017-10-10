using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GLManager
{
    class Example1
    {
        public Object robot = new Object();
        public Object environment = new Object();

        public void InitializeWorld()
        {
            InitializeRobot();
            InitializeEnvironment();
        }

        public void DrawWorld()
        {
            UseTextures();
            robot.Draw();
            environment.Draw(PrimitiveType.Quads);
        }

        private void InitializeRobot()
        {
            robot.vbo.ObjToVBO(7, 8, "models/kapool/Kapool.obj", "models/kapool/Kapool.png");
            robot.shaders.MainShader("shaders/catVertexShader.txt", "shaders/catFragmentShader.txt");
            robot.objectParts.Add(new ObjectPart("TorsoOffset", new Vector3(0, 0, 0), 0f, 0, 2937));//torso doesn't have offset neither.
            robot.objectParts.Add(new ObjectPart("leftLegRotationOffset", new Vector3(0, 64.45056f, -14.3136f), 0f, 2937, 3831));
            robot.objectParts.Add(new ObjectPart("rightLegRotationOffset", new Vector3(0, 65.15328f, -9.68128f), 0f, 3831, 4725));
            //I only see one offset for both arm.
            robot.objectParts.Add(new ObjectPart("ArmRotationOffset", new Vector3(0, 121.207f, -10.25984f), 0f, 4725, 6174));
            //robot.objectParts.Add(new ObjectPart("leftArmRotationOffset", new Vector3(0, 121.207f, -10.25984f), 0f, 4725, 6174));
            //robot.objectParts.Add(new ObjectPart("rightArmRotationOffset", new Vector3(0, 121.207f, -10.25984f), 0f, 6174, 7623));
            robot.objectParts.Add(new ObjectPart("ArmorOffset", new Vector3(0, 0, 0), 0f, 7767, 10839));//this one doesn't have offset but for now.
        }

        private void InitializeEnvironment()
        {
            environment.vbo.VertexTextureFromString(0, 1, "verticesArray/landscapeVerticesArray.txt", "verticesArray/textureArray.txt");
            environment.vbo.LoadTexture("textures/all.png");//load texture separately
            environment.shaders.MainShader("shaders/landscapeVertexShader.txt", "shaders/landscapeFragmentShader.txt");
            environment.objectParts.Add(new ObjectPart("landScape", new Vector3(0, 0, 0), 0f, 0, 538));// If I want to add ceiling, add 400
        }

        public void UseTextures()
        {
            //-------------multiple textures-----------------------------------
            //http://stackoverflow.com/questions/25252512/how-can-i-pass-multiple-textures-to-a-single-shader
            
            robot.UseTexture("catTexture", TextureUnit.Texture0, 0);//same as TextureUnit but in numeric.
            environment.UseTexture("cubeTexture", TextureUnit.Texture2, 2);
        }


    }
}
