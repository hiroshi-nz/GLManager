using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace GLManager
{
    class ObjectPart
    {
   
        public string uniformName;
        public Vector3 translationalOffset = new Vector3();//in order to rotate a part, at first move the rotational axis to 0 on the coordinates system.
        public Vector3 rotationalAngles;
        public int startLocation;
        public int endLocation;

        public ObjectPart(string uniformName, Vector3 translationalOffset, Vector3 rotationalAngles, int startLocation, int endLocation)
        {
            this.uniformName = uniformName;
            this.translationalOffset = translationalOffset;
            this.rotationalAngles = rotationalAngles;
            this.startLocation = startLocation;
            this.endLocation = endLocation;
        }
    }
}
