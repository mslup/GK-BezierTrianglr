using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Vertex
    {
        // maybe make it just Point3d
        public float x, y, z;
        public Point3D N;
        public Point3D P;

        public int XPixel(int size) => (int)(x * size);
        public int YPixel(int size) => (int)(y * size);

        public Vertex(float x, float y, float z, Point3D[,] controlPoints)
        {
            this.x = x;
            this.y = y;
            this.z = z;

            N = BezierSurface.NormalVector(x, y, controlPoints);
            P = new Point3D(0, 1, BezierSurface.TangentVector_dV_Z(x, y, controlPoints));
        }
    }
}
