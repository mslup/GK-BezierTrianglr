using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Light
    {
        public Point3D Color;
        public Point3D Position;

        public Light(
            Point3D position, Point3D color)
        {
            Color = color;
            Position = position;
            
        }
    }
}
