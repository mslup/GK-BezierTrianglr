using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class DirectBitmap : IDisposable
    {
        // https://stackoverflow.com/questions/24701703/c-sharp-faster-alternatives-to-setpixel-and-getpixel-for-bitmaps-for-windows-f?fbclid=IwAR1mLB-HaMFHUOq8X6GstgGexO_MFZ2PlhWtaOk9nhXE6yZHQ5I-8WNQ7Y4
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;

            Clear();
        }

        public DirectBitmap(Image image, int width, int height) : this(width, height)
        {
            if (image == null)
                return;

            using (var g = Graphics.FromImage(Bitmap))
                g.DrawImage(image, 0, 0, Width, Height);
        }

        public void Clear()
        {
            Bits = new Int32[Width * Height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetToBlack()
        {
            for (int i = 0; i < Height; ++i)
                for (int j = 0; j < Width; ++j)
                    SetPixel(i, j, Color.Black);
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();

            Bits[index] = col;
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
        public void DrawFastLine(int x1, int y1, int x2, int y2, Color? _color = null)
        {
            Color color = _color == null ? Color.Black : (Color)_color;

            int dx = x2 - x1;
            int dy = y2 - y1;

            int sgndx = (dx >= 0) ? 1 : -1;
            int sgndy = (dy >= 0) ? 1 : -1;
            dx = sgndx * dx;
            dy = sgndy * dy;

            if (dx >= dy)
                Bresenham(x1, y1, dx, dy, sgndx, sgndy, (x, y) => SetPixel(x, y, color));
            else
                Bresenham(y1, x1, dy, dx, sgndy, sgndx, (x, y) => SetPixel(y, x, color));
        }

        public void DrawFastLine(int x1, int y1, int x2, int y2, Func<int, int, Color> getColor)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;

            int sgndx = (dx >= 0) ? 1 : -1;
            int sgndy = (dy >= 0) ? 1 : -1;
            dx = sgndx * dx;
            dy = sgndy * dy;

            if (dx >= dy)
                Bresenham(x1, y1, dx, dy, sgndx, sgndy, (x, y) => SetPixel(x, y, getColor(x, y)));
            else
                Bresenham(y1, x1, dy, dx, sgndy, sgndx, (y, x) => SetPixel(x, y, getColor(x, y)));
        }

        private void Bresenham(int x1, int y1, int dx, int dy, int sgndx, int sgndy, Action<int, int> setter)
        {
            int dStr = 2 * dy;
            int dDiag = 2 * (dy - dx);
            int d = 2 * dy - dx;

            int x = x1;
            int y = y1;

            setter(x, y);
            for (int i = 0; i <= dx; ++i)
            {
                if (d < 0)
                {
                    d += dStr;
                    x += sgndx;
                }
                else
                {
                    d += dDiag;
                    x += sgndx;
                    y += sgndy;
                }

                if (x < Width && y < Height && x > 0 && y > 0)
                    setter(x, y);

            }
        }

        private class AETNode
        {
            public float yMax;
            public float x;
            public float m;

            public AETNode(float yMax, float x, float m)
            {
                this.yMax = yMax;
                this.x = x;
                this.m = m;
            }
        }

        public void FillPolygon(Vertex[] V, int size, Func<Vertex[], int, int, Color> getColor)
        {
            if (V.Length < 3)
            {
                throw new ArgumentException("P should have at least 3 vertices");
            }

            var AET = new List<AETNode>();

            (int x, int y)[] P = new (int x, int y)[3]
            {
                ((int)(V[0].x * size), (int)(V[0].y * size)),
                ((int)(V[1].x * size), (int)(V[2].y * size)),
                ((int)(V[2].x * size), (int)(V[1].y * size))
            };

            int yMin = P.Min(_ => _.y);
            int yMax = P.Max(_ => _.y);
            int xMin = P.Min(_ => _.x);
            int xMax = P.Max(_ => _.x);

            void CheckNeighborEdges(int k, int ptIdx)
            {
                float slope;
                if (P[ptIdx].y == P[k].y)
                    return;
                else
                    slope = 1.0f * (P[ptIdx].x - P[k].x) / (P[ptIdx].y - P[k].y);

                if (P[ptIdx].y >= P[k].y)
                {
                    AET!.Add(new AETNode(P[ptIdx].y,
                        P[k].x,
                        slope));
                }
                else
                {
                    int idx = AET!.FindIndex(node => node.yMax == P[ptIdx].y);
                    if (idx != -1)
                        AET.RemoveAt(idx);
                }
            }

            for (int y = yMin; y <= yMax; y++)
            {
                for (int k = 0; k < P.Length; k++)
                {
                    if (P[k].y != y)
                        continue;

                    float slope;

                    int prev = (k - 1 + P.Length) % P.Length;
                    CheckNeighborEdges(k, prev);

                    int next = (k + 1) % P.Length;
                    CheckNeighborEdges(k, next);
                }

                // posortuj w kolejności rosnących x
                AET.Sort((node1, node2) => node1.x.CompareTo(node2.x));

                // wypełnij piksele pomiędzy krawędziami 0-1, 2-3
                for (int i = 0; i + 1 < AET.Count; i += 2)
                {
                    for (int x = (int)AET[i].x; x <= AET[i + 1].x; x++)
                    {
                        SetPixel(x, y, getColor(V, x, y));
                    }
                }

                // uaktualnij wartości x dla nowej scanlinii
                for (int i = 0; i < AET.Count; i++)
                {
                    AET[i].x += AET[i].m;
                }
            }
        }


    }
}
