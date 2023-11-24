using System.Drawing;
using System.Globalization;
using System.Security.Policy;
using lab2.Properties;

namespace lab2
{
    public partial class Trianglr : Form
    {
        private const int ctrlPtsNo = 3;
        public static int Eps = 10;
        public static int PointRadius = 5;

        public static int CanvasSize;
        public static Point3D[,] controlPoints = new Point3D[ctrlPtsNo + 1, ctrlPtsNo + 1];
        private Point3D? clickedPoint = null;
        private Point MousePos;

        private TriangleGrid TGrid;
        private DirectBitmap bmp;
        public static DirectBitmap Texture;
        public static DirectBitmap NormalMap;

        public bool MovingVertex = false;

        public Trianglr()
        {
            InitializeComponent();

            Height = 600;
            CanvasSize = canvas.Size.Height;
            splitContainer.SplitterDistance = canvas.Size.Height;
            pointHeightSlider.Value = (pointHeightSlider.Maximum + pointHeightSlider.Minimum) / 2;
            pointHeightSlider.Enabled = false;

            for (int i = 0; i <= ctrlPtsNo; i++)
            {
                for (int j = 0; j <= ctrlPtsNo; j++)
                {
                    controlPoints[i, j] = new Point3D(i * 1.0f / ctrlPtsNo, j * 1.0f / ctrlPtsNo, 0);
                }
            }

            TGrid = new TriangleGrid(CanvasSize, triangleGridCheckbox.Checked, normalVectorsCheckbox.Checked);

            horizontalDensitySlider.Value = TGrid.HorizontalDensity;
            verticalDensitySlider.Value = TGrid.VerticalDensity;

            bmp = new(CanvasSize + 1, CanvasSize + 1);
            Texture = new(CanvasSize + 1, CanvasSize + 1);
            TGrid.DrawTriangleGrid(bmp);

            animationTimer.Interval = 24;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int size = canvas.Height;
            var pen = new Pen(new SolidBrush(Color.Black));

            g.DrawImage(bmp.Bitmap, 0, 0);

            float squareStep = 1.0f * size / ctrlPtsNo;

            // Draw square grid
            for (int i = 0; i < ctrlPtsNo + 3; i++)
            {
                g.DrawLine(pen, (int)(i * squareStep), 0, (int)(i * squareStep), size);
                g.DrawLine(pen, 0, (int)(i * squareStep), size, (int)(i * squareStep));
            }

            // Draw control points
            for (int i = 0; i <= ctrlPtsNo; i++)
            {
                for (int j = 0; j <= ctrlPtsNo; j++)
                {
                    g.DrawPoint(controlPoints[i, j],
                        controlPoints[i, j].IsXYCloseToPoint(MousePos),
                        controlPoints[i, j] == clickedPoint);
                }
            }

            g.DrawPoint(TriangleGrid.lightSourcePos,
                TriangleGrid.lightSourcePos.IsXYCloseToPoint(MousePos),
                TriangleGrid.lightSourcePos == clickedPoint);

        }

        public static Point? debugPoint = null;

        

        private void pointHeightScrollBar_ValueChanged(object sender, EventArgs e)
        {
            if (clickedPoint == null)
                return;

            clickedPoint.Z = pointHeightSlider.Value / 100.0f;
            ZLabel.Text = String.Format("{0:F}", clickedPoint.Z);

            TGrid.CalculateVertexGrid();
            TGrid.DrawTriangleGrid(bmp);

            canvas.Refresh();
        }

       
        private void horizontalDensityScrollBar_ValueChanged(object sender, EventArgs e)
        {
            horizontalDensityLabel.Text = $"{horizontalDensitySlider.Value}";

            TGrid.UpdateHorizontally(horizontalDensitySlider.Value);
            TGrid.DrawTriangleGrid(bmp);

            canvas.Refresh();
        }

        private void verticalDensityScrollBar_ValueChanged(object sender, EventArgs e)
        {
            verticalDensityLabel.Text = $"{verticalDensitySlider.Value}";

            TGrid.UpdateVertically(verticalDensitySlider.Value);
            TGrid.DrawTriangleGrid(bmp);

            canvas.Refresh();
        }

        private void animationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (animationCheckBox.Checked)
            {
                lightXSlider.Enabled = false;
                lightYSlider.Enabled = false;

                animationTimer.Start();
            }
            else
            {
                lightXSlider.Enabled = true;
                lightYSlider.Enabled = true;

                animationTimer.Stop();
            }
        }

        private void lightXSlider_ValueChanged(object sender, EventArgs e)
        {
            TriangleGrid.lightSourcePos.X = lightXSlider.Value / 100.0f;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void lightYSlider_ValueChanged(object sender, EventArgs e)
        {
            TriangleGrid.lightSourcePos.Y = lightYSlider.Value / 100.0f;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void lightZSlider_ValueChanged(object sender, EventArgs e)
        {
            TriangleGrid.lightSourcePos.Z = lightZSlider.Value / 100.0f;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void kDSlider_ValueChanged(object sender, EventArgs e)
        {
            TriangleGrid.kD = kDSlider.Value / 100.0f;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void kSSlider_ValueChanged(object sender, EventArgs e)
        {
            TriangleGrid.kS = kSSlider.Value / 100.0f;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void mSlider_ValueChanged(object sender, EventArgs e)
        {
            TriangleGrid.m = mSlider.Value;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void lightColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                TriangleGrid.lightSourceColor = new Point3D(
                    colorDialog.Color.R / 255.0f,
                    colorDialog.Color.G / 255.0f,
                    colorDialog.Color.B / 255.0f);
            }
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void normalVectorsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            TGrid.showNormalVectors = normalVectorsCheckbox.Checked;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void triangleGridCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            TGrid.showTriangleGrid = triangleGridCheckbox.Checked;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void objectColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                TriangleGrid.objectColor = new Point3D(
                    colorDialog.Color.R / 255.0f,
                    colorDialog.Color.G / 255.0f,
                    colorDialog.Color.B / 255.0f);
            }
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private float angle = 0f;
        private float k = 7;

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            float newX = 0.5f + 0.3f * (float)Math.Sin(angle / k) * (float)Math.Cos(angle);
            float newY = 0.5f + 0.3f * (float)Math.Sin(angle / k) * (float)Math.Sin(angle);

            TriangleGrid.lightSourcePos.X = newX;
            TriangleGrid.lightSourcePos.Y = newY;

            lightXSlider.Value = (int)(newX * 100f);
            lightYSlider.Value = (int)(newY * 100f);

            angle += 0.01f;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Invalidate();
        }

        private void textureButton_Click(object sender, EventArgs e)
        {
            if (chooseFileDialog.ShowDialog() == DialogResult.OK)
            {
                Texture = new DirectBitmap(Image.FromFile(chooseFileDialog.FileName), CanvasSize + 1, CanvasSize + 1);
                TriangleGrid.textureFlag = 1;
                TGrid.DrawTriangleGrid(bmp);
                canvas.Refresh();
            }
        }

        private void normalMapButton_Click(object sender, EventArgs e)
        {
            if (chooseFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetNormalMap(Image.FromFile(chooseFileDialog.FileName));
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (MovingVertex == false)
                return;

            float newX = 1.0f * e.Location.X / CanvasSize;
            float newY = 1.0f * e.Location.Y / CanvasSize;

            if (clickedPoint != null &&
                Math.Abs(clickedPoint.X - newX) < 1e-2 &&
                Math.Abs(clickedPoint.Y - newY) < 1e-2)
                return;

            if (clickedPoint == TriangleGrid.lightSourcePos)
            {
                //lightXSlider.Value = (int)(TriangleGrid.lightSourcePos.X / lightXSlider.Maximum);
                //lightYSlider.Value = (int)(TriangleGrid.lightSourcePos.Y / lightYSlider.Maximum);

                clickedPoint.X = TriangleGrid.lightSourcePos.X = newX;
                clickedPoint.Y = TriangleGrid.lightSourcePos.Y = newY;

                TGrid.DrawTriangleGrid(bmp);
                (sender as Control).Invalidate();
                return;
            }

            for (int i = 0; i <= ctrlPtsNo; i++)
            {
                for (int j = 0; j <= ctrlPtsNo; j++)
                {
                    // save i, j of clickedPoint
                    if (controlPoints[i, j] == clickedPoint)
                    {
                        float newZ = (clickedPoint.Y - 1.0f * e.Location.Y / CanvasSize) * 4;
                        if (newZ < -1 || newZ > 1)
                            return;

                        controlPoints[i, j].Z = Math.Clamp(newZ, -1, 1);
                        pointHeightSlider.Value = (int)(controlPoints[i, j].Z * (pointHeightSlider.Maximum));

                        TGrid.DrawTriangleGrid(bmp);
                        (sender as Control).Invalidate();
                        return;
                    }
                }
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (MovingVertex == true)
            {
                MovingVertex = false;
            }
        }
       
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            MousePos = e.Location;

            if (TriangleGrid.lightSourcePos.IsXYCloseToPoint(MousePos))
            {
                clickedPoint = TriangleGrid.lightSourcePos;

                MovingVertex = true;
                (sender as Control).Invalidate();
                return;
            }

            for (int i = 0; i <= ctrlPtsNo; i++)
            {
                for (int j = 0; j <= ctrlPtsNo; j++)
                {
                    if (controlPoints[i, j].IsXYCloseToPoint(MousePos))
                    {
                        clickedPoint = controlPoints[i, j];

                        XLabel.Text = string.Format("{0:F}", clickedPoint.X);
                        YLabel.Text = string.Format("{0:F}", clickedPoint.Y);
                        ZLabel.Text = string.Format("{0:F}", clickedPoint.Z);

                        pointHeightSlider.Value = (int)(clickedPoint.Z * 100.0);
                        pointHeightSlider.Enabled = true;

                        MovingVertex = true;

                        canvas.Refresh();

                        return;
                    }
                }
            }

            clickedPoint = null;

            /// DEBUG
            //{
            //    debugPoint = MousePos;
            //    TGrid.DrawTriangleGrid(bmp);
            //    canvas.Refresh();
            //}
            /// DEBUG

            XLabel.Text = "";
            YLabel.Text = "";
            ZLabel.Text = "";

            pointHeightSlider.Value = (pointHeightSlider.Maximum + pointHeightSlider.Minimum) / 2;
            pointHeightSlider.Enabled = false;

            (sender as Control).Invalidate();
        }

        private void normalMapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (normalMapComboBox.SelectedItem)
            {
            case "BrickWall":
                SetNormalMap(Resources.BrickWallNM);
                return;
            }
        }

        private void SetNormalMap(Image image)
        {
            NormalMap = new DirectBitmap(image, CanvasSize + 1, CanvasSize + 1);
            TriangleGrid.normalMapFlag = 1;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

    }
}