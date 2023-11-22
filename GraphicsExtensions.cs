using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    static public class GraphicsExtensions
    {
        

        private static int pointWidth = Trianglr.PointRadius * 2;
        private static int hlPointWidth = pointWidth + Trianglr.Eps * 2;

        private static Brush pointBrush = new SolidBrush(Color.Black);
        private static Brush slcpointBrush = new SolidBrush(Color.IndianRed);
        private static Brush hlPointBrush = new SolidBrush(Color.FromArgb(127, 0, 0, 0));
        public static void DrawPoint(this Graphics g, Point3D p, bool highlight, bool selected)
        {
            if (highlight)
                g.FillEllipse(hlPointBrush,
                    p.XPixel - hlPointWidth / 2,
                    p.YPixel - hlPointWidth / 2,
                    hlPointWidth, hlPointWidth);

            var brush = selected ? slcpointBrush : pointBrush;
            int width = selected ? pointWidth + 4 : pointWidth;
            g.FillEllipse(brush,
                p.XPixel - width / 2,
                p.YPixel - width / 2,
                width, width);
        }

        
    }
}
