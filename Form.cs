using System.Drawing;
using System.Globalization;
using System.Security.Policy;

namespace lab2
{
    public partial class Trianglr : Form
    {
        private const int N = 3;
        public static int Eps = 10;
        public static int PointRadius = 5;

        public static int CanvasSize;
        public static Point3D[,] controlPoints = new Point3D[N + 1, N + 1];
        private Point3D? clickedPoint = null;
        private Point MousePos;

        private TriangleGrid TGrid;
        private DirectBitmap bmp;

        public Trianglr()
        {
            InitializeComponent();

            Height = 600;
            CanvasSize = canvas.Size.Height;
            splitContainer.SplitterDistance = canvas.Size.Height;
            pointHeightSlider.Value = pointHeightSlider.Maximum / 2;
            pointHeightSlider.Enabled = false;

            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    controlPoints[i, j] = new Point3D(i * 1.0f / N, j * 1.0f / N, 0);
                }
            }

            TGrid = new TriangleGrid(CanvasSize);

            horizontalDensitySlider.Value = TGrid.HorizontalDensity;
            verticalDensitySlider.Value = TGrid.VerticalDensity;

            bmp = new(CanvasSize * 2, CanvasSize * 2);
            TGrid.DrawTriangleGrid(bmp);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int size = canvas.Height;
            var pen = new Pen(new SolidBrush(Color.Black));

            g.DrawImage(bmp.Bitmap, 0, 0);

            float squareStep = 1.0f * size / N;

            // Draw square grid
            for (int i = 0; i < N + 3; i++)
            {
                g.DrawLine(pen, (int)(i * squareStep), 0, (int)(i * squareStep), size);
                g.DrawLine(pen, 0, (int)(i * squareStep), size, (int)(i * squareStep));
            }

            // Draw control points
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    g.DrawPoint(controlPoints[i, j],
                        controlPoints[i, j].IsXYCloseToPoint(MousePos),
                        controlPoints[i, j] == clickedPoint);
                }
            }

        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            MousePos = e.Location;

            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    if (controlPoints[i, j].IsXYCloseToPoint(MousePos))
                    {
                        clickedPoint = controlPoints[i, j];

                        XLabel.Text = string.Format("{0:F}", clickedPoint.X);
                        YLabel.Text = string.Format("{0:F}", clickedPoint.Y);
                        ZLabel.Text = string.Format("{0:F}", clickedPoint.Z);

                        pointHeightSlider.Value = (int)(clickedPoint.Z * 100.0);
                        pointHeightSlider.Enabled = true;

                        splitContainer.Refresh();

                        return;
                    }
                }
            }

            clickedPoint = null;

            XLabel.Text = "";
            YLabel.Text = "";
            ZLabel.Text = "";

            pointHeightSlider.Value = pointHeightSlider.Maximum / 2;
            pointHeightSlider.Enabled = false;

            splitContainer.Refresh();

        }

        private void pointHeightScrollBar_ValueChanged(object sender, EventArgs e)
        {
            if (clickedPoint == null)
                return;

            clickedPoint.Z = pointHeightSlider.Value / 100.0f;
            ZLabel.Text = String.Format("{0:F}", clickedPoint.Z);

            TGrid.CalculateVertexGrid();
            TGrid.DrawTriangleGrid(bmp);

            splitContainer.Refresh();
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            MousePos = e.Location;

            (sender as Control).Invalidate();
        }

        private void horizontalDensityScrollBar_ValueChanged(object sender, EventArgs e)
        {
            horizontalDensityLabel.Text = $"{horizontalDensitySlider.Value}";

            TGrid.UpdateHorizontally(horizontalDensitySlider.Value);
            TGrid.DrawTriangleGrid(bmp);

            splitContainer.Refresh();
        }

        private void verticalDensityScrollBar_ValueChanged(object sender, EventArgs e)
        {
            verticalDensityLabel.Text = $"{verticalDensitySlider.Value}";

            TGrid.UpdateVertically(verticalDensitySlider.Value);
            TGrid.DrawTriangleGrid(bmp);

            splitContainer.Refresh();
        }


    }
}