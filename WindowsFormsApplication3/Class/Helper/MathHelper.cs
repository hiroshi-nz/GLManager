using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLManager
{
    class MathHelper
    {
        public static double angleToRadian(double angle)
        {
            return (Math.PI / 180) * angle;
        }
        public static double sinAngle(double angle)
        {
            return Math.Sin((Math.PI / 180) * angle);
        }
        public static double cosAngle(double angle)
        {
            return Math.Cos((Math.PI / 180) * angle);
        }

        public static float angleToRadian(float angle)
        {
            return (float)(Math.PI / 180) * angle;
        }
        public static float sinAngle(float angle)
        {
            return (float)Math.Sin((Math.PI / 180) * angle);
        }
        public static float cosAngle(float angle)
        {
            return (float)Math.Cos((Math.PI / 180) * angle);
        }
    }
}