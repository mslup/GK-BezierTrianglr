using System.Diagnostics;
using System.Globalization;
using System.IO.IsolatedStorage;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace lab2
{
    public class Renderer
    {
        private int size;

        public int HorizontalDensity;
        public int VerticalDensity;

        public float verticalTriangleStep;
        public float horizontalTriangleStep;

        public float[] horizontalTrianglePoints = new float[1];
        public float[] verticalTrianglePoints = new float[1];

        private Vertex[,] grid;
        private Point3D[,] controlPoints;

        public bool IsTextureSet = false;
        public bool IsNormalMapSet = false;
        public bool IsTextureEnabled = false;
        public bool IsNormalMapEnabled = false;

        public bool SphereSurface = false;

        public bool AddNormalVectors;
        public bool showNormalVectors;
        public bool showTriangleGrid;
        public bool showMesh;
        public bool zuchowski;
        public bool invertYnormalMap;
        private int invertY;
        private int addNormalVectors;

        public Light light;
        public SurfaceMaterial material;
        public DirectBitmap Bmp { get; private set; }
        public DirectBitmap Texture { get; private set; }
        public DirectBitmap NormalMap { get; private set; }

        public Renderer(int size, int horizontalDensity, int verticalDensity,
            Point3D[,] controlPoints,
            Light light, SurfaceMaterial material,
            bool showTriangleGrid, bool showNormalVectors)
        {
            this.size = size;
            this.controlPoints = controlPoints;
            HorizontalDensity = horizontalDensity;
            VerticalDensity = verticalDensity;

            CalculateHorizontal(HorizontalDensity);
            CalculateVertical(VerticalDensity);
            CalculateVertexGrid();

            this.showTriangleGrid = showTriangleGrid;
            this.showNormalVectors = showNormalVectors;
            this.light = light;
            this.material = material;

            Bmp = new DirectBitmap(size + 1, size + 1);
        }

        public void DrawScene()
        {
            invertY = invertYnormalMap ? 1 : -1;
            addNormalVectors = AddNormalVectors ? 1 : 0;

            if (showMesh)
            {
                Bmp.Clear();
                Bmp.SetToBlack();
            }
            else
                DrawTriangleGridFilled();
            if (showTriangleGrid || showMesh)
                DrawTriangleGridOutline();
            if (showNormalVectors)
                DrawNormalVectors();
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
                            controlPoints),
                        controlPoints);
                });
            });


            //for (int i = 0; i < VerticalDensity + 2; i++)
            //{
            //    for (int j = 0; j < HorizontalDensity + 2; j++)
            //    {
            //        Console.Write(String.Format("{0}, {1}, {2:F2}", i, j, grid[i, j].sphereZ) + "\t");
            //    }
            //    Console.WriteLine();
            //}

        }

        private void CalculateHorizontal(int density)
        {
            HorizontalDensity = density;
            horizontalTrianglePoints = new float[HorizontalDensity + 2];
            horizontalTriangleStep = 1.0f / HorizontalDensity;

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

        private void DrawTriangleGridOutline()
        {
            int vStep = (int)(verticalTriangleStep * size);
            int hStep = (int)(horizontalTriangleStep * size);

            for (int i = 0; i < VerticalDensity; i++)
            {
                int vPoint = (int)(verticalTrianglePoints[i] * size);

                for (int j = 0; j < HorizontalDensity; j++)
                {
                    int hPoint = (int)(horizontalTrianglePoints[j] * size);
                    Vertex[] P = GetTriangle(i, j, 1, 0);
                    Func<int, int, Color> getColor = showMesh ?
                        (x, y) => GetColor(P, x, y) :
                        (x, y) => Color.Black;

                    Bmp.DrawFastLine(hPoint, vPoint,
                        hPoint, vPoint + vStep, getColor);

                    Bmp.DrawFastLine(hPoint, vPoint,
                        hPoint + hStep, vPoint + vStep, getColor);

                    Bmp.DrawFastLine(hPoint, vPoint + vStep,
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

        private void DrawNormalVectors()
        {
            //Parallel.For(0, VerticalDensity, i =>
            for (int i = 0; i <= VerticalDensity; i++)
            {
                //Parallel.For(0, HorizontalDensity, j =>
                for (int j = 0; j <= HorizontalDensity; j++)
                {
                    var N = GetModNormalVector((grid[i, j].N.X, grid[i, j].N.Y, grid[i, j].N.Z),
                        (int)(grid[i, j].x * size),
                        (int)(grid[i, j].y * size),
                        (grid[i, j].P.X, grid[i, j].P.Y, grid[i, j].P.Z));

                    (float nx, float ny, _) = Normalize(N);
                    nx /= 10;
                    ny /= 10;

                    Bmp.DrawFastLine(
                        Math.Clamp((int)(grid[i, j].x * size), 0, size),
                        Math.Clamp((int)(grid[i, j].y * size), 0, size),
                        Math.Clamp((int)((grid[i, j].x + nx) * size), 0, size),
                        Math.Clamp((int)((grid[i, j].y + ny) * size), 0, size),
                        Color.Yellow);

                    float k = 0.1f;
                    float l = (float)Math.Sqrt(nx * nx + ny * ny);
                    float alpha = (float)Math.PI / 5;
                    float tga = (float)Math.Tan(alpha);
                    float dx = -k * l;
                    float dy = k * l * tga;

                    if (l < 1e-2)
                        continue;

                    float sinGamma = ny / l;
                    float cosGamma = nx / l;

                    float dx1 = cosGamma * dx - sinGamma * dy;
                    float dy1 = sinGamma * dx + cosGamma * dy;
                    float dx2 = cosGamma * dx + sinGamma * dy;
                    float dy2 = sinGamma * dx - cosGamma * dy;

                    Bmp.DrawFastLine(
                    Math.Clamp((int)((grid[i, j].x + nx) * size), 0, size),
                    Math.Clamp((int)((grid[i, j].y + ny) * size), 0, size),
                    Math.Clamp((int)((grid[i, j].x + nx + dx1) * size), 0, size),
                    Math.Clamp((int)((grid[i, j].y + ny + dy1) * size), 0, size),
                    Color.Yellow);

                    Bmp.DrawFastLine(
                        Math.Clamp((int)((grid[i, j].x + nx) * size), 0, size),
                        Math.Clamp((int)((grid[i, j].y + ny) * size), 0, size),
                        Math.Clamp((int)((grid[i, j].x + nx + dx2) * size), 0, size),
                        Math.Clamp((int)((grid[i, j].y + ny + dy2) * size), 0, size),
                        Color.Yellow);
                }
                //);
            }
            //);
        }

        private void DrawTriangleGridFilled()
        {
            //for (int i = 0; i < VerticalDensity; i++)
            Parallel.For(0, VerticalDensity, i =>
            {
                //for (int j = 0; j < HorizontalDensity; j++)
                Parallel.For(0, HorizontalDensity, j =>
                    {
                    FillTriangle(i, j, 1, 0); //bottom
                    FillTriangle(i, j, 0, 1); //top
                }
                );
            }
            );
        }

        private void FillTriangle(int vIndex, int hIndex, int v, int h)
        {
            Vertex[] P = GetTriangle(vIndex, hIndex, v, h);
            Bmp.FillPolygon(P, size, GetColor);
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

        public Color GetBarycentricColor(Vertex[] P, int x, int y)
        {
            (float r, float g, float b) = CalculateBarycentricCoords(P, 1.0f * x / size, 1.0f * y / size);

            return Color.FromArgb(
                (int)Math.Clamp(r * 255, 0, 255),
                (int)Math.Clamp(g * 255, 0, 255),
                (int)Math.Clamp(b * 255, 0, 255)
                );
        }

        public Color GetColor(Vertex[] P, int x, int y)
        {
            float X = 1.0f * x / size;
            float Y = 1.0f * y / size;

            if (SphereSurface && !Sphere.InsideSphere(X, Y))
                return Color.White;

            (float lambda1, float lambda2, float lambda3) =
                CalculateBarycentricCoords(P, X, Y);

            (float x, float y, float z) pointCoords = (X, Y,
                lambda1 * (SphereSurface ? P[0].sphereZ : P[0].z) +
                lambda2 * (SphereSurface ? P[1].sphereZ : P[1].z) +
                lambda3 * (SphereSurface ? P[2].sphereZ : P[2].z)
            );

            (float x, float y, float z) lightVector = Normalize((
                light.Position.X - pointCoords.x,
                light.Position.Y - pointCoords.y,
                light.Position.Z - pointCoords.z
            ));

            Point3D N0, N1, N2, P0, P1, P2;

            if (SphereSurface)
            {
                N0 = P[0].sphereN;
                N1 = P[1].sphereN;
                N2 = P[2].sphereN;
                P0 = P[0].sphereP;
                P1 = P[1].sphereP;
                P2 = P[2].sphereP;
            }
            else
            {
                N0 = P[0].N;
                N1 = P[1].N;
                N2 = P[2].N;
                P0 = P[0].P;
                P1 = P[1].P;
                P2 = P[2].P;
            }

            (float x, float y, float z) normalVector = Normalize((
                lambda1 * N0.X + lambda2 * N1.X + lambda3 * N2.X,
                lambda1 * N0.Y + lambda2 * N1.Y + lambda3 * N2.Y,
                lambda1 * N0.Z + lambda2 * N1.Z + lambda3 * N2.Z
            ));

            (float x, float y, float z) tangentVector;

            if (!SphereSurface)
            {
                tangentVector = Normalize((
                    lambda1 * P0.X + lambda2 * P1.X + lambda3 * P2.X,
                    lambda1 * P0.Y + lambda2 * P1.Y + lambda3 * P2.Y,
                    lambda1 * P0.Z + lambda2 * P1.Z + lambda3 * P2.Z
                ));
            }
            else
            {
                tangentVector = (0, 0, 0);
            }


            if (IsNormalMapSet && IsNormalMapEnabled)
            {
                var modNormalVector = GetModNormalVector(normalVector, x, y, tangentVector);
                normalVector = (
                    normalVector.x * addNormalVectors + modNormalVector.x,
                    normalVector.y * addNormalVectors + modNormalVector.y,
                    normalVector.z * addNormalVectors + modNormalVector.z
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

            float diffuseCoef = material.kD * cosNL;
            float specularCoef = material.kS * (float)Math.Pow(cosVR, material.m);

            int textureColor = IsTextureSet && IsTextureEnabled ? Texture.GetPixel(x, y).ToArgb() : 0;
            float textureR = ((textureColor >> 16) & 0xFF) / 255.0f;
            float textureG = ((textureColor >> 8) & 0xFF) / 255.0f;
            float textureB = (textureColor & 0xFF) / 255.0f;

            int textureFlag = IsTextureSet && IsTextureEnabled ? 1 : 0;
            float objectColorX = (1 - textureFlag) * material.Color.X + textureFlag * textureR;
            float objectColorY = (1 - textureFlag) * material.Color.Y + textureFlag * textureG;
            float objectColorZ = (1 - textureFlag) * material.Color.Z + textureFlag * textureB;

            float R = diffuseCoef * light.Color.X * objectColorX +
                specularCoef * light.Color.X * objectColorX;
            float G = diffuseCoef * light.Color.Y * objectColorY +
                specularCoef * light.Color.Y * objectColorY;
            float B = diffuseCoef * light.Color.Z * objectColorZ +
                specularCoef * light.Color.Z * objectColorZ;

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

        private (float x, float y, float z) GetModNormalVector((float x, float y, float z) v, int x, int y, (float x, float y, float z) tangentVector)
        {
            if (!IsNormalMapSet || !IsNormalMapEnabled)
                return v;

            int normalMapVector = NormalMap.GetPixel(x, y).ToArgb();
            float normalMapR = ((normalMapVector >> 16) & 0xFF) / 127.5f - 1;
            float normalMapG = invertY * (((normalMapVector >> 8) & 0xFF) / 127.5f - 1);
            float normalMapB = (normalMapVector & 0xFF) / 127.5f - 1;

            float Nx = v.x;
            float Ny = v.y;
            float Nz = v.z;


            (float x, float y, float z) B;

            if (zuchowski && !SphereSurface)
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

        public void SetTexture(Image image)
        {
            IsTextureSet = true;
            Texture = new DirectBitmap(image, size + 1, size + 1);
        }

        public void SetNormalMap(Image image)
        {
            IsNormalMapSet = true;
            NormalMap = new DirectBitmap(image, size + 1, size + 1);
        }
    }
}
