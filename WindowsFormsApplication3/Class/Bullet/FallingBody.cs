﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulletSharp;

namespace GLManager
{
    class FallingBody
    {

                //http://bulletphysics.org/mediawiki-1.5.8/index.php/Hello_World
        //https://github.com/AndresTraks/BulletSharp/blob/master/test/BulletTests.cs

        DiscreteDynamicsWorld dynamicsWorld;
        RigidBody fallRigidBody;

        public void InitializeEverything()
        {
            InitializeWorld();
            fallRigidBody = AddFallingRigidBody();
            AddGroundRigidBody();
        }

        public void Tick(Object myObject)
        {
                dynamicsWorld.StepSimulation(1 / 60f, 10);
                myObject.location.Y = fallRigidBody.WorldTransform.Origin.Y;
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


        public RigidBody AddFallingRigidBody()
        {
            CollisionShape fallShape = new SphereShape(1);
            BulletSharp.Math.Vector3 fallInertia = new BulletSharp.Math.Vector3(0, 0, 0);
            float mass = 1;
            fallShape.CalculateLocalInertia(mass, out fallInertia);

            RigidBodyConstructionInfo fallRigidBodyCI = new RigidBodyConstructionInfo(mass, new DefaultMotionState(), fallShape, BulletSharp.Math.Vector3.Zero);
            RigidBody fallRigidBody = new RigidBody(fallRigidBodyCI);
            fallRigidBody.Translate(new BulletSharp.Math.Vector3(0, 100, 0));
            dynamicsWorld.AddRigidBody(fallRigidBody);

            return fallRigidBody;
        }

        public void AddGroundRigidBody()
        {
            CollisionShape groundShape = new StaticPlaneShape(new BulletSharp.Math.Vector3(0, 1, 0), 1);
            RigidBodyConstructionInfo groundRigidBodyCI = new RigidBodyConstructionInfo(0, new DefaultMotionState(), groundShape, BulletSharp.Math.Vector3.Zero);
            RigidBody groundRigidBody = new RigidBody(groundRigidBodyCI);
            dynamicsWorld.AddRigidBody(groundRigidBody);            
        }
    }
}
