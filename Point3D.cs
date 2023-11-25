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

        public Color ToColor()
        {
            return Color.FromArgb(
                Math.Clamp((int)(X * 255), 0, 255),
                Math.Clamp((int)(Y * 255), 0, 255),
                Math.Clamp((int)(Z * 255), 0, 255)
                );
        }
    }
}
