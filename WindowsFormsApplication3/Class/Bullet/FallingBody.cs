using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulletSharp;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GLManager
{
    class FallingBody
    {

        //http://bulletphysics.org/mediawiki-1.5.8/index.php/Hello_World
        //https://github.com/AndresTraks/BulletSharp/blob/master/test/BulletTests.cs

        DiscreteDynamicsWorld dynamicsWorld;
        RigidBody fallRigidBody;
        RigidBody fallRigidBody2;
        Character character;

        public void InitializeEverything()
        {
            InitializeWorld();
            fallRigidBody = AddFallingRigidBody(new Vector3(-20, 0, 0), 10);
            fallRigidBody2 = AddFallingRigidBody(new Vector3(0, 5, 0), 50);
            AddGroundRigidBody();

            character = new Character(fallRigidBody);

            //https://www.sjbaker.org/wiki/index.php?title=Physics_-_Bullet_Tutorial2_example
            //really good explanation of rigidbody properties of bullet objects
            //fallRigidBody.WorldTransform;
            //fallRigidBody.UserObject = "a";
            //fallRigidBody.Friction = 0.5f;
            //fallRigidBody.LinearFactor = new BulletSharp.Math.Vector3(1, 1, 1);
            //fallRigidBody.LinearVelocity = new BulletSharp.Math.Vector3(10, 0, 0);
            //fallRigidBody.AngularVelocity = BulletSharp.Math.Vector3.Zero;
            //fallRigidBody.ContactProcessingThreshold = 1e30f;
            fallRigidBody.Restitution = 0.7f;//bounciness
            fallRigidBody.LinearVelocity = new BulletSharp.Math.Vector3(25, 0, 0);
            fallRigidBody.Friction = 0.5f;
            fallRigidBody2.Restitution = 0.7f;
            //fallRigidBody.LinearDamping = 0.1f;//resistance to translational motion           
        }

        public void Tick(Object myObject, Object myObject2)
        {
                dynamicsWorld.StepSimulation(1 / 60f, 10);

                myObject.location = VectorBulletToGL(fallRigidBody.WorldTransform.Origin);
                myObject2.location = VectorBulletToGL(fallRigidBody2.WorldTransform.Origin);
        }

        public void ThrowObject(Object myObject)
        {
            fallRigidBody.LinearVelocity = new BulletSharp.Math.Vector3(1, 10, 0);
            myObject.location = VectorBulletToGL(fallRigidBody.WorldTransform.Origin);

        }

        public void MoveObject(Object myObject)
        {
            character.MoveX(myObject, 10);
        }

        public static OpenTK.Vector3 VectorBulletToGL(BulletSharp.Math.Vector3 bulletVector)
        {
            OpenTK.Vector3 glVector = new OpenTK.Vector3(bulletVector.X, bulletVector.Y, bulletVector.Z);
            return glVector;
        }

        public void Tick()
        {
            dynamicsWorld.StepSimulation(1 / 60f, 10);
            Console.WriteLine(fallRigidBody.WorldTransform.Origin.Y);
        }

        public void InitializeWorld()
        {
            DbvtBroadphase broadphase = new DbvtBroadphase();
            DefaultCollisionConfiguration conf = new DefaultCollisionConfiguration();
            CollisionDispatcher dispacher = new CollisionDispatcher(conf);
            SequentialImpulseConstraintSolver solver = new SequentialImpulseConstraintSolver();
            dynamicsWorld = new DiscreteDynamicsWorld(dispacher, broadphase, solver, conf);

            BulletSharp.Math.Vector3 gravity = new BulletSharp.Math.Vector3(0, -10, 0);
            dynamicsWorld.SetGravity(ref gravity);
        }


        public RigidBody AddFallingRigidBody(Vector3 location, float mass)
        {
            //CollisionShape fallShape = new SphereShape(1);
            CollisionShape fallShape = new BoxShape(2.5f, 2.5f, 2.5f);
            BulletSharp.Math.Vector3 fallInertia = new BulletSharp.Math.Vector3(0, 0, 0);
            fallShape.CalculateLocalInertia(mass, out fallInertia);
        
            RigidBodyConstructionInfo fallRigidBodyCI = new RigidBodyConstructionInfo(mass, new DefaultMotionState(), fallShape, BulletSharp.Math.Vector3.Zero);
            RigidBody fallRigidBody = new RigidBody(fallRigidBodyCI);

            fallRigidBody.Translate(new BulletSharp.Math.Vector3(location.X, location.Y, location.Z));
            dynamicsWorld.AddRigidBody(fallRigidBody);

            return fallRigidBody;
        }

        public void AddGroundRigidBody()
        {
            CollisionShape groundShape = new StaticPlaneShape(new BulletSharp.Math.Vector3(0, 1, 0), 1);
            RigidBodyConstructionInfo groundRigidBodyCI = new RigidBodyConstructionInfo(0, new DefaultMotionState(), groundShape, BulletSharp.Math.Vector3.Zero);
            RigidBody groundRigidBody = new RigidBody(groundRigidBodyCI);

            groundRigidBody.Friction = 0.5f;

            dynamicsWorld.AddRigidBody(groundRigidBody);            
        }
    }
}
