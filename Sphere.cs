using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public static class Sphere
    {
        public const float R = 0.5f;
        public const float Sx = 0.5f;
        public const float Sy = 0.5f;

        public static Point3D NormalVector(float x, float y, float z)
        {
            if (!InsideSphere(x, y))
                return new Point3D(0, 0, 1);

            Point3D vec = new Point3D(x - 0.5f, y - 0.5f, z);
            vec.Normalize();
            return vec;
        }

        public static float GetHeight(float x, float y)
        {
            float X = x - Sx;
            float Y = y - Sy;

            if (X * X + Y * Y > R * R)
                return 0;

            return (float)Math.Sqrt(R * R - X * X - Y * Y); 
        }

        public static bool InsideSphere(float x, float y)
        {
            return ((x - Sx) * (x - Sx) + (y - Sy) * (y - Sy) < R * R);
        }
    }
}
