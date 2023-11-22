using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Point3D
    {
        public float X, Y, Z;


        public int XPixel
        {
            get => (int)(Trianglr.CanvasSize * X);
        }
        public int YPixel
        {
            get => (int)(Trianglr.CanvasSize * Y);
        }

        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public bool IsXYCloseToPoint(Point other)
        {
            int eps = Trianglr.Eps + Trianglr.PointRadius;
            return Math.Abs(XPixel - other.X) < eps &&
                Math.Abs(YPixel - other.Y) < eps;
        }

        public void Normalize()
        {
            float magnitude = (float)Math.Sqrt(X * X + Y * Y + Z * Z);

            if (magnitude > 0)
            {
                X /= magnitude;
                Y /= magnitude;
                Z /= magnitude;
            }
        }

        public static Point3D operator *(Point3D vec1, Point3D vec2)
        {
            return new Point3D(vec1.X * vec2.X, vec1.Y * vec2.Y, vec1.Z * vec2.Z);
        }

        public static Point3D operator *(float scalar, Point3D vec)
        {
            return new Point3D(scalar * vec.X, scalar * vec.Y, scalar * vec.Z);
        }

        public static Point3D operator -(Point3D vec1, Point3D vec2)
        {
            return new Point3D(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z);
        }

        public static Point3D operator +(Point3D vec1, Point3D vec2)
        {
            return new Point3D(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
        }

        public Point3D Clamp(float min, float max)
        {
            return new Point3D(
                Math.Clamp(X, min, max),
                Math.Clamp(Y, min, max),
                Math.Clamp(Z, min, max));
        }
    }
}
