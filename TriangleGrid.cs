using System.Diagnostics;
using System.Globalization;
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

        public float[] horizontalTrianglePoints = new float[1];
        public float[] verticalTrianglePoints = new float[1];

        private Vertex[,] grid;

        public static Point3D lightSourcePos = new Point3D(0.5f, 0.5f, 1.0f);
        public static Point3D lightSourceColor = new Point3D(1, 1, 1);
        public static Point3D objectColor = new Point3D(0.5f, 0.5f, 0.5f);

        public static int textureFlag = 0;
        public static int normalMapFlag = 0;

        public static float kD = 1;
        public static float kS = 0.5f;
        public static int m = 50;

        public bool showNormalVectors;
        public bool showTriangleGrid;

        public TriangleGrid(int size, bool showTriangleGrid, bool showNormalVectors)
        {
            this.size = size;
            CalculateHorizontal(HorizontalDensity);
            CalculateVertical(VerticalDensity);
            CalculateVertexGrid();

            this.showTriangleGrid = showTriangleGrid;
            this.showNormalVectors = showNormalVectors;
        }

        public void DrawTriangleGrid(DirectBitmap bmp)
        {
            //bmp.Clear();
            DrawTriangleGridFilled(bmp);
            if (showTriangleGrid)
                DrawTriangleGridOutline(bmp);
            if (showNormalVectors)
                DrawNormalVectors(bmp);
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
            horizontalTrianglePoints = new float[HorizontalDensity + 2];
            horizontalTriangleStep = 1.0f / HorizontalDensity;

            //Parallel.For(0, HorizontalDensity + 2, j =>
            for (int j = 0; j < HorizontalDensity + 2; ++j)
            {
                horizontalTrianglePoints[j] = j * horizontalTriangleStep;
            }
        }

        private void CalculateVertical(int density)
        {
            VerticalDensity = density;
            verticalTrianglePoints = new float[VerticalDensity + 2];
            verticalTriangleStep = 1.0f / VerticalDensity;

            //Parallel.For(0, VerticalDensity + 1, i =>
            for (int i = 0; i < VerticalDensity + 2; ++i)
            {
                verticalTrianglePoints[i] = i * verticalTriangleStep;
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

        }

        private void DrawNormalVectors(DirectBitmap bmp)
        {
            //Parallel.For(0, VerticalDensity, i =>
            for (int i = 0; i <= VerticalDensity; i++)
            {
                //Parallel.For(0, HorizontalDensity, j =>
                for (int j = 0; j <= HorizontalDensity; j++)
                {
                    var N = GetModNormalVector((grid[i, j].N.X, grid[i, j].N.Y, grid[i, j].N.Z),
                        (int)(grid[i, j].x * CanvasSize),
                        (int)(grid[i, j].y * CanvasSize));
                    float x = N.x;
                    float y = N.y;

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
                //);
            }
            //);
        }

        private void DrawTriangleGridFilled(DirectBitmap bmp)
        {
            //for (int i = 0; i < VerticalDensity; i++)
            Parallel.For(0, VerticalDensity, i =>
            {
                //for (int j = 0; j < HorizontalDensity; j++)
                Parallel.For(0, HorizontalDensity, j =>
                {
                    FillTriangle(bmp, i, j, 1, 0); //bottom
                    FillTriangle(bmp, i, j, 0, 1); //top
                }
                );
            }
            );
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

        public static Color GetBarycentricColor(Vertex[] P, int x, int y)
        {
            (float r, float g, float b) = CalculateBarycentricCoords(P, 1.0f * x / CanvasSize, 1.0f * y / CanvasSize);

            return Color.FromArgb(
                (int)Math.Clamp(r * 255, 0, 255),
                (int)Math.Clamp(g * 255, 0, 255),
                (int)Math.Clamp(b * 255, 0, 255)
                );
        }

        public static Color GetColor(Vertex[] P, int x, int y)
        {
            float X = 1.0f * x / CanvasSize;
            float Y = 1.0f * y / CanvasSize;

            //if (debugPoint != null && 
            //    Math.Abs(x - ((Point)debugPoint).X) < 1e-3 && 
            //    Math.Abs(y - ((Point)debugPoint).Y) < 1e-3)
            //{
            //    debugPoint = null;
            //    //Debugger.Break(); 
            //}

            (float lambda1, float lambda2, float lambda3) =
                CalculateBarycentricCoords(P, X, Y);

            (float x, float y, float z) pointCoords = (X, Y,
                lambda1 * P[0].z +
                lambda2 * P[1].z +
                lambda3 * P[2].z
            );

            (float x, float y, float z) lightVector = Normalize((
                lightSourcePos.X - pointCoords.x,
                lightSourcePos.Y - pointCoords.y,
                lightSourcePos.Z - pointCoords.z
            ));

            (float x, float y, float z) normalVector = Normalize((
                lambda1 * P[0].N.X + lambda2 * P[1].N.X + lambda3 * P[2].N.X,
                lambda1 * P[0].N.Y + lambda2 * P[1].N.Y + lambda3 * P[2].N.Y,
                lambda1 * P[0].N.Z + lambda2 * P[1].N.Z + lambda3 * P[2].N.Z
            ));

            normalVector = GetModNormalVector(normalVector, x, y);

            float cosNL = normalVector.x * lightVector.x +
                normalVector.y * lightVector.y +
                normalVector.z * lightVector.z;

            (float x, float y, float z) eyeVector = (0, 0, 1);
            (float x, float y, float z) reflectionVector = Normalize((
                2 * cosNL * normalVector.x - lightVector.x,
                2 * cosNL * normalVector.y - lightVector.y,
                2 * cosNL * normalVector.z - lightVector.z
            ));

            cosNL = Math.Clamp(cosNL, 0, 1);

            float cosVR = eyeVector.x * reflectionVector.x +
                eyeVector.y * reflectionVector.y +
                eyeVector.z * reflectionVector.z;

            cosVR = Math.Clamp(cosVR, 0, 1);

            float diffuseCoef = kD * cosNL;
            float specularCoef = kS * (float)Math.Pow(cosVR, m);

            int textureColor = textureFlag * Texture.GetPixel(x, y).ToArgb();
            float textureR = ((textureColor >> 16) & 0xFF) / 255.0f;
            float textureG = ((textureColor >> 8) & 0xFF) / 255.0f;
            float textureB = (textureColor & 0xFF) / 255.0f;

            float objectColorX = (1 - textureFlag) * objectColor.X + textureFlag * textureR;
            float objectColorY = (1 - textureFlag) * objectColor.Y + textureFlag * textureG;
            float objectColorZ = (1 - textureFlag) * objectColor.Z + textureFlag * textureB;

            float R = diffuseCoef * lightSourceColor.X * objectColorX +
                specularCoef * lightSourceColor.X * objectColorX;
            float G = diffuseCoef * lightSourceColor.Y * objectColorY +
                specularCoef * lightSourceColor.Y * objectColorY;
            float B = diffuseCoef * lightSourceColor.Z * objectColorZ +
                specularCoef * lightSourceColor.Z * objectColorZ;

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

        private static (float x, float y, float z) GetModNormalVector((float x, float y, float z) v, int x, int y)
        {
            if (normalMapFlag == 0)
                return v;

            int normalMapVector = normalMapFlag * NormalMap.GetPixel(x, y).ToArgb();
            float normalMapR = ((normalMapVector >> 16) & 0xFF) / 127.5f - 1;
            float normalMapG = ((normalMapVector >> 8) & 0xFF) / 127.5f - 1;
            float normalMapB = (normalMapVector & 0xFF) / 127.5f - 1;

            float Nx = v.x;
            float Ny = v.y;
            float Nz = v.z;

            (float x, float y, float z) B;

            if (Math.Abs(Nx) < 1e-6 && Math.Abs(Ny) < 1e-6 && Math.Abs(Nz - 1) < 1e-6)
                B = (0, 1, 0);
            else
                B = (Ny, -Nx, 0);

            (float x, float y, float z) T =
                (B.y * Nz - B.z * Ny,
                B.z * Nx - B.x * Nz,
                B.x * Ny - B.y * Nx);

            (float x, float y, float z)[] M = { T, B, v };

            float resultX = M[0].x * normalMapR + M[1].x * normalMapG + M[2].x * normalMapB;
            float resultY = M[0].y * normalMapR + M[1].y * normalMapG + M[2].y * normalMapB;
            float resultZ = M[0].z * normalMapR + M[1].z * normalMapG + M[2].z * normalMapB;

            return (resultX, resultY, resultZ);
        }
    }
}
