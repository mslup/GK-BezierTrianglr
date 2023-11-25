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
        public bool showMesh;

        public Light light;
        public SurfaceMaterial material;

        public static bool zuchowski;
        public static int invertYnormalMap;

        public TriangleGrid(int size, bool showTriangleGrid, bool showNormalVectors, 
            Light light, SurfaceMaterial material)
        {
            this.size = size;
            CalculateHorizontal(HorizontalDensity);
            CalculateVertical(VerticalDensity);
            CalculateVertexGrid();

            this.showTriangleGrid = showTriangleGrid;
            this.showNormalVectors = showNormalVectors;
            this.light = light;
            this.material = material;
        }

        public void DrawTriangleGrid(DirectBitmap bmp)
        {
            if (showMesh)
            {
                bmp.Clear();
                bmp.SetToBlack();

                
            }
            else
                DrawTriangleGridFilled(bmp);
            if (showTriangleGrid || showMesh)
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

            for (int i = 0; i < VerticalDensity; i++)
            {
                int vPoint = (int)(verticalTrianglePoints[i] * CanvasSize);

                for (int j = 0; j < HorizontalDensity; j++)
                {
                    int hPoint = (int)(horizontalTrianglePoints[j] * CanvasSize);
                    Vertex[] P = GetTriangle(i, j, 1, 0);
                    Func<int, int, Color> getColor = showMesh ? 
                        (x, y) => GetColor(P, x, y) :
                        (x, y) => Color.Black;

                    bmp.DrawFastLine(hPoint, vPoint, 
                        hPoint, vPoint + vStep, getColor);

                    bmp.DrawFastLine(hPoint, vPoint,
                        hPoint + hStep, vPoint + vStep, getColor);

                    bmp.DrawFastLine(hPoint, vPoint + vStep,
                        hPoint + hStep, vPoint + vStep, getColor);
                }
            }

        }

        private static (float x, float y, float z) CalculateB((float X, float Y, float Z) N)
        {
            if (Math.Abs(N.X) < 1e-3 && Math.Abs(N.Y) < 1e-3 && Math.Abs(N.Z - 1) < 1e-3)
                return (0, 1, 0);
            else
                return Normalize((N.Y, -N.X, 0));
        }

        private static (float x, float y, float z) CalculateB(Point3D N) => CalculateB((N.X, N.Y, N.Z));

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
                        (int)(grid[i, j].y * CanvasSize), 
                        (grid[i, j].P.X, grid[i, j].P.Y, grid[i, j].P.Z));

                    (float nx, float ny, float nz) = Normalize(N);
                    nx /= 10;
                    ny /= 10;

                    bmp.DrawFastLine(
                        Math.Clamp((int)(grid[i, j].x * CanvasSize), 0, CanvasSize),
                        Math.Clamp((int)(grid[i, j].y * CanvasSize), 0, CanvasSize),
                        Math.Clamp((int)((grid[i, j].x + nx) * CanvasSize), 0, CanvasSize),
                        Math.Clamp((int)((grid[i, j].y + ny) * CanvasSize), 0, CanvasSize),
                        Color.Yellow);

                    float theta = (float)Math.Atan2(ny, nx);
                    float cosTheta = (float)Math.Cos(theta);
                    float sinTheta = (float)Math.Sin(theta);
                    float k = 0.1f;
                    float l = (float)Math.Sqrt(nx * nx + ny * ny);
                    float alpha = (float)Math.PI / 5;
                    float tga = (float)Math.Tan(alpha);
                    float dx = -k * l;
                    float dy = k * l * tga;
                    float cosGamma = nx / l;
                    float sinGamma = ny / l;

                    float dx1 = cosGamma * dx - sinGamma * dy;
                    float dy1 = sinGamma * dx + cosGamma * dy;
                    float dx2 = cosGamma * dx + sinGamma * dy;
                    float dy2 = sinGamma * dx - cosGamma * dy;

                    

                    bmp.DrawFastLine(
                        Math.Clamp((int)((grid[i, j].x + nx) * CanvasSize), 0, CanvasSize),
                        Math.Clamp((int)((grid[i, j].y + ny) * CanvasSize), 0, CanvasSize),
                        Math.Clamp((int)((grid[i, j].x + nx + dx1) * CanvasSize), 0, CanvasSize),
                        Math.Clamp((int)((grid[i, j].y + ny + dy1) * CanvasSize), 0, CanvasSize),
                        Color.Yellow);

                    bmp.DrawFastLine(
                        Math.Clamp((int)((grid[i, j].x + nx) * CanvasSize), 0, CanvasSize),
                        Math.Clamp((int)((grid[i, j].y + ny) * CanvasSize), 0, CanvasSize),
                        Math.Clamp((int)((grid[i, j].x + nx + dx2) * CanvasSize), 0, CanvasSize),
                        Math.Clamp((int)((grid[i, j].y + ny + dy2) * CanvasSize), 0, CanvasSize),
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

            (float x, float y, float z) tangentVector = Normalize((
                lambda1 * P[0].P.X + lambda2 * P[1].P.X + lambda3 * P[2].P.X,
                lambda1 * P[0].P.Y + lambda2 * P[1].P.Y + lambda3 * P[2].P.Y,
                lambda1 * P[0].P.Z + lambda2 * P[1].P.Z + lambda3 * P[2].P.Z
                ));


            if (normalMapFlag != 0)
            {
                var modNormalVector = GetModNormalVector(normalVector, x, y, tangentVector);
                normalVector = (
                    normalVector.x * AddNormalVectors + modNormalVector.x,
                    normalVector.y * AddNormalVectors + modNormalVector.y,
                    normalVector.z * AddNormalVectors + modNormalVector.z
                );
                normalVector = Normalize(normalVector);

            }


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
            if (magnitude != 0)
            {
                return (
                    v.x / magnitude,
                    v.y / magnitude,
                    v.z / magnitude);
            }
            else
                return (0, 0, 0);
        }

        private static (float x, float y, float z) GetModNormalVector((float x, float y, float z) v, int x, int y, (float x, float y, float z) tangentVector)
        {
            if (normalMapFlag == 0)
                return v;

            int normalMapVector = NormalMap.GetPixel(x, y).ToArgb();
            float normalMapR = ((normalMapVector >> 16) & 0xFF) / 127.5f - 1;
            float normalMapG = invertYnormalMap * (((normalMapVector >> 8) & 0xFF) / 127.5f - 1);
            float normalMapB = (normalMapVector & 0xFF) / 127.5f - 1;

            float Nx = v.x;
            float Ny = v.y;
            float Nz = v.z;


            (float x, float y, float z) B;
            
            if (zuchowski)
                B = tangentVector;
            else
                B = CalculateB(v);

            (float x, float y, float z) T =
                Normalize(
                    (B.y * Nz - B.z * Ny,
                    B.z * Nx - B.x * Nz,
                    B.x * Ny - B.y * Nx));

            float resultX = T.x * normalMapR + B.x * normalMapG + Nx * normalMapB;
            float resultY = T.y * normalMapR + B.y * normalMapG + Ny * normalMapB;
            float resultZ = T.z * normalMapR + B.z * normalMapG + Nz * normalMapB;

            return (resultX, resultY, resultZ);
        }
    }
}
