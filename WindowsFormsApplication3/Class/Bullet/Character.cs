using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulletSharp;

namespace GLManager
{
    class Character
    {
        RigidBody rigidBody;
        //Object myObject;

        public Character(RigidBody rigidBody)
        {
            this.rigidBody = rigidBody;
        }

        public void MoveX(Object myObject, float delta)
        {
            rigidBody.LinearVelocity = new BulletSharp.Math.Vector3(delta, 0, 0);
            myObject.location = FallingBody.VectorBulletToGL(rigidBody.WorldTransform.Origin);
        }
        public void MoveY(Object myObject, float delta)
        {
            rigidBody.LinearVelocity = new BulletSharp.Math.Vector3(0, delta, 0);
            myObject.location = FallingBody.VectorBulletToGL(rigidBody.WorldTransform.Origin);
        }
        public void MoveZ(Object myObject, float delta)
        {
            rigidBody.LinearVelocity = new BulletSharp.Math.Vector3(0, 0, delta);
            myObject.location = FallingBody.VectorBulletToGL(rigidBody.WorldTransform.Origin);
        }

        public void Jump(Object myObject)
        {
            rigidBody.LinearVelocity = new BulletSharp.Math.Vector3(0, 0, 5);
            myObject.location = FallingBody.VectorBulletToGL(rigidBody.WorldTransform.Origin);
        }
    }
}
