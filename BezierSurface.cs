using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class BezierSurface
    {
        private static float BernsteinPolynomial(int i, int n, float t)
        {
            return (float)(BinomCoef[n, i] * Math.Pow(t, i) * Math.Pow(1 - t, n - i));
        }

        private static readonly float[,] BinomCoef = new float[4, 4]
        {
            {1, 0, 0, 0},
            {1, 1, 0, 0},
            {1, 2, 1, 0},
            {1, 3, 3, 1}
        };

        public static float BezierHeight(float x, float y, Point3D[,] pts)
        {
            int n = 3;

            float sum = 0;
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    sum += pts[i, j].Z *
                        BernsteinPolynomial(i, n, x) *
                        BernsteinPolynomial(j, n, y);
                }
            }

            return sum;
        }

        public static float TangentVector_dU_Z(float u, float v, Point3D[,] pts)
        {
            int n = 3, m = 3;

            float sum = 0;
            for (int i = 0; i <= n - 1; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    sum += (float)((pts[i + 1, j].Z - pts[i, j].Z)
                        * BernsteinPolynomial(i, n - 1, u)
                        * BernsteinPolynomial(j, m, v));
                }
            }
            return n * sum;
        }

        public static float TangentVector_dV_Z(float u, float v, Point3D[,] pts)
        {
            int n = 3, m = 3;

            float sum = 0;
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m - 1; j++)
                {
                    sum += (float)((pts[i, j + 1].Z - pts[i, j].Z)
                        * BernsteinPolynomial(i, n, u)
                        * BernsteinPolynomial(j, m - 1, v));
                }
            }

            return m * sum;
        }

        public static Point3D NormalVector(float u, float v, Point3D[,] pts)
        {
            Point3D vec = new Point3D(
                -TangentVector_dU_Z(u, v, pts),
                -TangentVector_dV_Z(u, v, pts),
                1);
            vec.Normalize();
            return vec;
        }
    }
}
