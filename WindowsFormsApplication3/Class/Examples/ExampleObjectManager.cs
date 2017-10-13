using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GLManager
{
    class ExampleObjectManager
    {
        public ObjectManager objectManager = new ObjectManager();
        
        public Object robot = new Object();
        public Object environment = new Object();
        public Object box = new Object();
        //FallingBody fallingBody = new FallingBody();

        public void InitializeWorld()
        {
            InitializeRobot();
            InitializeEnvironment();
            InitializeBox();

            objectManager.AddObject(robot);
            objectManager.AddObject(environment);
            objectManager.AddObject(box);
            //fallingBody.InitializeEverything();
        }

        public void DrawWorld()
        {
            //fallingBody.Tick();
            UseTextures();
            objectManager.DrawAll();
        }

        private void InitializeRobot()
        {
            robot.primitiveType = PrimitiveType.Triangles;
            robot.vbo.ObjToVBO(7, 8, "models/kapool/Kapool.obj", "models/kapool/Kapool.png");
            //robot.shaders.MainShader("shaders/catVertexShader.txt", "shaders/catFragmentShader.txt");
            robot.shaders.MainShader("shaders/testVertexShader.txt", "shaders/catFragmentShader.txt");
            robot.location = (new Vector3(0, 10, 0));
            robot.objectParts.Add(new ObjectPart("TorsoOffset", new Vector3(0, 0, 0), new Vector3(0, 0, 0), 0, 2937));//torso doesn't have offset neither.
            robot.objectParts.Add(new ObjectPart("leftLegRotationOffset", new Vector3(0, 64.45056f, -14.3136f), new Vector3(0, 0, 0), 2937, 3831));
            robot.objectParts.Add(new ObjectPart("rightLegRotationOffset", new Vector3(0, 65.15328f, -9.68128f), new Vector3(0, 0, 0), 3831, 4725));
            //I only see one offset for both arm.
            robot.objectParts.Add(new ObjectPart("ArmRotationOffset", new Vector3(0, 121.207f, -10.25984f), new Vector3(0, 0, 0), 4725, 6174));
            //robot.objectParts.Add(new ObjectPart("leftArmRotationOffset", new Vector3(0, 121.207f, -10.25984f), new Vector3(0, 0, 0), 4725, 6174));
            //robot.objectParts.Add(new ObjectPart("rightArmRotationOffset", new Vector3(0, 121.207f, -10.25984f), new Vector3(0, 0, 0), 6174, 7623));
            robot.objectParts.Add(new ObjectPart("ArmorOffset", new Vector3(0, 0, 0), new Vector3(0, 0, 0), 7767, 10839));//this one doesn't have offset but for now.

            ShaderGenerator shaderGenerator = new ShaderGenerator();
            shaderGenerator.GenerateCode(robot);
        }

        private void InitializeEnvironment()
        {
            environment.primitiveType = PrimitiveType.Quads;
            environment.vbo.VertexTextureFromString(0, 1, "verticesArray/landscapeVerticesArray.txt", "verticesArray/textureArray.txt");
            environment.vbo.LoadTexture("textures/all.png");//load texture separately
            environment.shaders.MainShader("shaders/landscapeVertexShader.txt", "shaders/landscapeFragmentShader.txt");
            environment.objectParts.Add(new ObjectPart("landScape", new Vector3(0, 0, 0), new Vector3(0, 0, 0), 0, 538));// If I want to add ceiling, add 400
        }

        private void InitializeBox()
        {
            box.primitiveType = PrimitiveType.Quads;
            box.vbo.VertexTexture(2, 3, Box.vertexArray, Box.textureArray2);
            box.vbo.LoadTexture("textures/all.png");
            box.shaders.MainShader("shaders/BoxVertexShader.txt", "shaders/BoxFragmentShader.txt");
            box.objectParts.Add(new ObjectPart("box", new Vector3(0, 0, 0), new Vector3(0, 0, 0), 0, 24));// If I want to add ceiling, add 400
        }

        public void UseTextures()
        {
            //-------------multiple textures-----------------------------------
            //http://stackoverflow.com/questions/25252512/how-can-i-pass-multiple-textures-to-a-single-shader

            robot.UseTexture("catTexture", TextureUnit.Texture0, 0);//same as TextureUnit but in numeric.
            environment.UseTexture("cubeTexture", TextureUnit.Texture2, 2);
            box.UseTexture("cubeTexture", TextureUnit.Texture2, 2);
        }


    }
}
