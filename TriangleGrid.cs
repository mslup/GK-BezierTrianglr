using System.Diagnostics;
using System.IO.IsolatedStorage;
using static lab2.Trianglr;

namespace lab2
{
    public class TriangleGrid
    {
        private int size;

        public int HorizontalDensity = 3;
        public int VerticalDensity = 3;

        public float verticalTriangleStep;
        public float horizontalTriangleStep;

        public List<float> horizontalTrianglePoints = new List<float>();
        public List<float> verticalTrianglePoints = new List<float>();

        private Vertex[,] grid;

        public TriangleGrid(int size)
        {
            this.size = size;
            CalculateHorizontal(HorizontalDensity);
            CalculateVertical(VerticalDensity);
            CalculateVertexGrid();
        }

        public void DrawTriangleGrid(DirectBitmap bmp)
        {
            bmp.Clear();
            DrawTriangleGridFilled(bmp);
            DrawTriangleGridOutline(bmp);
        }

        public void CalculateVertexGrid()
        {
            grid = new Vertex[VerticalDensity + 2, HorizontalDensity + 2];

            Parallel.For(0, VerticalDensity + 2, i =>
            {
                Parallel.For(0, HorizontalDensity + 2, j =>
                {
                    grid[i, j] = new Vertex(
                        horizontalTrianglePoints[j],
                        verticalTrianglePoints[i],
                        BezierSurface.BezierHeight(
                            horizontalTrianglePoints[j],
                            verticalTrianglePoints[i],
                            controlPoints));
                });
            });

        }

        private void CalculateHorizontal(int density)
        {
            HorizontalDensity = density;
            horizontalTrianglePoints.Clear();
            horizontalTriangleStep = 1.0f / HorizontalDensity;

            for (int j = 0; j <= HorizontalDensity + 1; j++)
            {
                horizontalTrianglePoints.Add(j * horizontalTriangleStep);
            }
        }

        private void CalculateVertical(int density)
        {
            VerticalDensity = density;
            verticalTrianglePoints.Clear();
            verticalTriangleStep = 1.0f / VerticalDensity;

            for (int i = 0; i <= VerticalDensity + 1; i++)
            {
                verticalTrianglePoints.Add(i * verticalTriangleStep);
            }
        }

        public void UpdateVertically(int density)
        {
            CalculateVertical(density);
            CalculateVertexGrid();
        }

        public void UpdateHorizontally(int density)
        {
            CalculateHorizontal(density);
            CalculateVertexGrid();
        }

        public Vertex[] GetTriangle(int vIndex, int hIndex, int v, int h)
        {
            return new Vertex[3]
            {
                grid[vIndex, hIndex],
                grid[vIndex + v, hIndex + h],
                grid[vIndex + 1, hIndex + 1]
            };

        }

        private void DrawTriangleGridOutline(DirectBitmap bmp)
        {
            int vStep = (int)(verticalTriangleStep * CanvasSize);
            int hStep = (int)(horizontalTriangleStep * CanvasSize);

            for (int i = 0; i <= VerticalDensity; i++)
            {
                int vPoint = (int)(verticalTrianglePoints[i] * CanvasSize);
                bmp.DrawFastLine(0, vPoint,
                    size, vPoint);

                for (int j = 0; j <= HorizontalDensity; j++)
                {
                    int hPoint = (int)(horizontalTrianglePoints[j] * CanvasSize);
                    bmp.DrawFastLine(hPoint, 0, hPoint, size);

                    bmp.DrawFastLine(hPoint, vPoint,
                        hPoint + hStep, vPoint + vStep);

                }
            }

            for (int i = 0; i <= VerticalDensity; i++)
            {
                for (int j = 0; j <= HorizontalDensity; j++)
                {
                    float x = grid[i, j].N.X;
                    float y = grid[i, j].N.Y;

                    float magn = (float)Math.Sqrt(x * x + y * y);

                    float nx, ny;
                    if (magn == 0)
                    {
                        nx = ny = 0;
                    }
                    else
                    {
                        nx = x / (magn * 20);
                        ny = y / (magn * 20);
                    }

                    if (grid[i, j].x + nx < 0 || grid[i, j].y + ny < 0)
                        continue;

                    bmp.DrawFastLine(
                        (int)(grid[i, j].x * CanvasSize),
                        (int)(grid[i, j].y * CanvasSize),
                        (int)((grid[i, j].x + nx) * CanvasSize),
                        (int)((grid[i, j].y + ny) * CanvasSize),
                        Color.Yellow);
                }
            }
        }

        private void DrawTriangleGridFilled(DirectBitmap bmp)
        {
            for (int i = 0; i < VerticalDensity; i++)
            //Parallel.For(0, VerticalDensity, i =>
            {
                for (int j = 0; j < HorizontalDensity; j++)
                //Parallel.For(0, HorizontalDensity, j =>
                {
                    FillTriangle(bmp, i, j, 1, 0); //bottom
                    FillTriangle(bmp, i, j, 0, 1); //top
                }
                //);
            }
            //);
        }

        private void FillTriangle(DirectBitmap bmp, int vIndex, int hIndex, int v, int h)
        {
            Vertex[] P = GetTriangle(vIndex, hIndex, v, h);
            bmp.FillPolygon(P);
        }

        public static (float, float, float) CalculateBarycentricCoords
            (Vertex[] P, float x, float y)
        {
            float x1 = P[0].x;
            float y1 = P[0].y;
            float x2 = P[1].x;
            float y2 = P[1].y;
            float x3 = P[2].x;
            float y3 = P[2].y;

            float detT = (y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3);

            float lambda1 = 1.0f * ((y2 - y3) * (x - x3) + (x3 - x2) * (y - y3)) / detT;
            float lambda2 = 1.0f * ((y3 - y1) * (x - x3) + (x1 - x3) * (y - y3)) / detT;
            float lambda3 = 1 - lambda1 - lambda2;

            return (lambda1, lambda2, lambda3);
        }

        public static Color GetColor((int x, int y)[] P, int x, int y)
        {
            float x1 = P[0].x;
            float y1 = P[0].y;
            float x2 = P[1].x;
            float y2 = P[1].y;
            float x3 = P[2].x;
            float y3 = P[2].y;

            float detT = (y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3);

            float lambda1 = 1.0f * ((y2 - y3) * (x - x3) + (x3 - x2) * (y - y3)) / detT;
            float lambda2 = 1.0f * ((y3 - y1) * (x - x3) + (x1 - x3) * (y - y3)) / detT;
            float lambda3 = 1 - lambda1 - lambda2;

            return Color.FromArgb(
                (int)Math.Clamp(lambda1 * 255, 0, 255),
                (int)Math.Clamp(lambda2 * 255, 0, 255),
                (int)Math.Clamp(lambda3 * 255, 0, 255)
                );
        }

        public static Color GetBarycentricColor(Vertex[] P, int x, int y)
        {
            (float r, float g, float b) = CalculateBarycentricCoords(P, 1.0f * x / CanvasSize, 1.0f * y / CanvasSize);

            return Color.FromArgb(
                (int)Math.Clamp(r * 255, 0, 255),
                (int)Math.Clamp(g * 255, 0, 255),
                (int)Math.Clamp(b * 255, 0, 255)
                );
        }

        static Point3D lightPos = new Point3D(0.5f, 0.5f, 1.0f);
        static Point3D lightColor = new Point3D(1, 1, 1);
        static Point3D objectColor = lightColor; //new Point3D(0.75f, 0.75f, 0.75f);

        public static Color GetColor(Vertex[] P, int x, int y)
        {
            float kD = 0.5f, kS = 0.5f;
            int m = 100;

            float X = 1.0f * x / CanvasSize;
            float Y = 1.0f * y / CanvasSize;

            (float lambda1, float lambda2, float lambda3) =
                CalculateBarycentricCoords(P, X, Y);

            (float x, float y, float z) pointCoords = (X, Y,
                lambda1 * P[0].z +
                lambda2 * P[1].z +
                lambda3 * P[2].z
            );

            (float x, float y, float z) lightVector = (
                lightPos.X - pointCoords.x,
                lightPos.Y - pointCoords.y,
                lightPos.Z - pointCoords.z
            );

            lightVector = Normalize(lightVector);

            (float x, float y, float z) normalVector = (
                lambda1 * P[0].N.X + lambda2 * P[1].N.X + lambda3 * P[2].N.X,
                lambda1 * P[0].N.Y + lambda2 * P[1].N.Y + lambda3 * P[2].N.Y,
                lambda1 * P[0].N.Z + lambda2 * P[1].N.Z + lambda3 * P[2].N.Z
            );

            normalVector = Normalize(normalVector);

            float cosNL = normalVector.x * lightVector.x +
                normalVector.y * lightVector.y +
                normalVector.z * lightVector.z;

            (float x, float y, float z) eyeVector = (0, 0, 1);
            (float x, float y, float z) reflectionVector = (
                2 * cosNL * (normalVector.x - lightVector.x),
                2 * cosNL * (normalVector.y - lightVector.y),
                2 * cosNL * (normalVector.z - lightVector.z)
            );
            reflectionVector = Normalize(reflectionVector);


            cosNL = Math.Clamp(cosNL, 0, 1);

            float cosVR = eyeVector.x * reflectionVector.x +
                eyeVector.y * reflectionVector.y +
                eyeVector.z * reflectionVector.z;
            cosVR = Math.Clamp(cosVR, 0, 1);

            // debug
            //var arr = new (float x, float y, float z)[] { pointCoords, lightVector, normalVector, reflectionVector };
            //foreach (var i in arr)
            //{
            //    Debug.Assert(i.x >= -1 && i.y >= -1 && i.z >= -1
            //        && i.x <= 1 && i.y <= 1 && i.z <= 1);
            //}

            float R = kD * lightColor.X * objectColor.X * cosNL +
                kS * lightColor.X * objectColor.X * (float)Math.Pow(cosVR, m);
            float G = kD * lightColor.Y * objectColor.Y * cosNL +
                kS * lightColor.Y * objectColor.Y * (float)Math.Pow(cosVR, m);
            float B = kD * lightColor.Z * objectColor.Z * cosNL +
                kS * lightColor.Z * objectColor.Z * (float)Math.Pow(cosVR, m);

            //Point3D C = kD * lightColor * objectColor * (normalVector * lightVector).Clamp(0, 1) +
            //    kS * lightColor * objectColor * (eyeVector * RVector).Clamp(0, 1);
            //Point3D Cn = (255 * C).Clamp(0, 255);

            return Color.FromArgb(
                (int)Math.Clamp(R * 255, 0, 255),
                (int)Math.Clamp(G * 255, 0, 255),
                (int)Math.Clamp(B * 255, 0, 255)
            );
        }

        private static (float x, float y, float z) Normalize((float x, float y, float z) v)
        {
            float magnitude = (float)Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
            if (magnitude > 0)
            {
                return (
                    v.x / magnitude,
                    v.y / magnitude,
                    v.z / magnitude);
            }
            else
                return (0, 0, 0);
        }

        //public static Color GetColor(Vertex[] P, int x, int y)
        //{
        //    float kD = 1, kS = 1;
        //    float X = 1.0f * x / CanvasSize;
        //    float Y = 1.0f * y / CanvasSize;

        //    Point3D lightColor = new Point3D(1, 1, 1);
        //    Point3D objectColor = new Point3D(0.5f, 0.5f, 0.5f);

        //    (float lambda1, float lambda2, float lambda3) =
        //        CalculateBarycentricCoords(P, X, Y);

        //    Point3D lightPos = new Point3D(0.5f, 0.5f, 1.5f);
        //    Point3D pointCoords = new Point3D(X, Y,
        //        lambda1 * P[0].z +
        //        lambda2 * P[1].z +
        //        lambda3 * P[2].z
        //    );

        //    Point3D lightVector = lightPos - pointCoords;
        //    lightVector.Normalize();
        //    Point3D normalVector =
        //        lambda1 * P[0].N +
        //        lambda2 * P[1].N +
        //        lambda3 * P[2].N;
        //    Point3D eyeVector = new Point3D(0, 0, 1);
        //    Point3D R = 2 * (normalVector - lightVector);
        //    int m = 50;

        //    Point3D C = kD * lightColor * objectColor * (normalVector * lightVector).Clamp(0, 1) +
        //        kS * lightColor * objectColor * (eyeVector * R).Clamp(0, 1);

        //    Point3D Cn = (255 * C).Clamp(0, 255);

        //    //return Color.FromArgb(
        //    //    255 / 2, 255/ 2, 255/2
        //    //    );

        //    return Color.FromArgb(
        //        (int)Cn.X,
        //        (int)Cn.Y,
        //        (int)Cn.Z);
        //}
    }
}
