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

        public int XPixel(int size) => (int)(x * size);
        public int YPixel(int size) => (int)(y * size);

        public Vertex(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

            N = BezierSurface.NormalVector(x, y, Trianglr.controlPoints);
        }
    }
}
