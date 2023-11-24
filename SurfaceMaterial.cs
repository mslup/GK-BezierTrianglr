using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class SurfaceMaterial
    {
        public DirectBitmap NormalMap;
        public DirectBitmap Texture;
        public Point3D Color;
        public float kD;
        public float kS;
        public float m;

        public SurfaceMaterial(
            float kD, float kS, float m, 
            DirectBitmap normalMap, 
            DirectBitmap texture, 
            Point3D objectColor)
        {
            NormalMap = normalMap;
            Texture = texture;
            Color = objectColor;
            this.kD = kD;
            this.kS = kS;
            this.m = m;
        }
    }
}
