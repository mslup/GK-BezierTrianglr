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
        private Point3D? selectedPoint = null;
        private Point MousePos;

        private TriangleGrid TGrid;
        private DirectBitmap bmp;
        public static DirectBitmap Texture;
        public static DirectBitmap NormalMap;

        private Image stashedTexture;
        private Image stashedNormalMap;

        public Light light { get; set; }
        public SurfaceMaterial material;

        public bool MovingVertex = false;
        private bool IsAnimating = false;

        public static bool MeshOnly = false;

        public static int AddNormalVectors = 0;

        public Trianglr()
        {
            InitializeComponent();

            Height = 700;
            CanvasSize = canvas.Size.Height;
            splitContainer.SplitterDistance = canvas.Size.Height;

            for (int i = 0; i <= ctrlPtsNo; i++)
            {
                for (int j = 0; j <= ctrlPtsNo; j++)
                {
                    controlPoints[i, j] = new Point3D(i * 1.0f / ctrlPtsNo, j * 1.0f / ctrlPtsNo, 0);
                }
            }

            TGrid = new TriangleGrid(CanvasSize, triangleGridCheckbox.Checked,
                normalVectorsCheckbox.Checked, light, material);

            InitializeParameters();

            TGrid.DrawTriangleGrid(bmp);

            textureComboBox.Text = "Choose predefined...";

            //SetNormalMap(Resources.ShapesNM);
        }

        private void InitializeParameters()
        {
            pointHeightSlider.Value = (pointHeightSlider.Maximum + pointHeightSlider.Minimum) / 2;
            pointHeightSlider.Enabled = false;

            horizontalDensitySlider.Value = TGrid.HorizontalDensity;
            verticalDensitySlider.Value = TGrid.VerticalDensity;

            bmp = new(CanvasSize + 1, CanvasSize + 1);
            Texture = new(CanvasSize + 1, CanvasSize + 1);

            InitializeLight();

            lightColorButton.BackColor = TriangleGrid.lightSourceColor.ToColor();

            InitializeSlider(kDSlider, TriangleGrid.kD);
            InitializeSlider(kSSlider, TriangleGrid.kS);
            InitializeSlider(mSlider, TriangleGrid.m);

            objColorRadioButton.Checked = true;
            objColorRadioButton_CheckedChanged();
            objectColorButton.BackColor = TriangleGrid.objectColor.ToColor();

            animationTimer.Interval = 24;

            normalMapCheckBox.Checked = false;
            normalMapCheckBox_CheckedChanged();

            TriangleGrid.invertYnormalMap = 1;

            TriangleGrid.zuchowski = true;
            zuchowskiRadioButton.Checked = true;
        }

        private void InitializeLight()
        {
            TriangleGrid.lightSourcePos = new Point3D(0.5f, 0.5f, 1);

            InitializeSlider(lightXSlider, TriangleGrid.lightSourcePos.X);
            InitializeSlider(lightYSlider, TriangleGrid.lightSourcePos.Y);
            InitializeSlider(lightZSlider, TriangleGrid.lightSourcePos.Z);
        }

        private void InitializeSlider(TrackBar slider, float value)
        {
            slider.Value = (int)(value * (slider.Maximum - slider.Minimum) + slider.Minimum);
        }

        private void InitializeSlider(TrackBar slider, int value)
        {
            slider.Value = value;
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
                        controlPoints[i, j].IsXYCloseToPoint(MousePos) ||
                        (MovingVertex && controlPoints[i, j] == selectedPoint),
                        controlPoints[i, j] == selectedPoint);
                }
            }

            g.DrawPoint(TriangleGrid.lightSourcePos,
                TriangleGrid.lightSourcePos.IsXYCloseToPoint(MousePos) ||
                        (MovingVertex && TriangleGrid.lightSourcePos == selectedPoint),
                TriangleGrid.lightSourcePos == selectedPoint);

        }

        public static Point? debugPoint = null;



        private void pointHeightScrollBar_ValueChanged(object sender, EventArgs e)
        {
            if (selectedPoint == null)
                return;

            selectedPoint.Z = pointHeightSlider.Value / 100.0f;
            ctrlPointZLabel.Text = String.Format("{0:F}", selectedPoint.Z);

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

                IsAnimating = true;

                animationTimer.Start();
            }
            else
            {
                lightXSlider.Enabled = true;
                lightYSlider.Enabled = true;
                IsAnimating = false;

                animationTimer.Stop();
            }
        }

        private void lightXSlider_ValueChanged(object sender, EventArgs e)
        {
            if (!IsAnimating && !MovingVertex)
                TriangleGrid.lightSourcePos.X = lightXSlider.Value / 100.0f;

            lightXLabel.Text = string.Format("X: {0:F}", TriangleGrid.lightSourcePos.X);

            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void lightYSlider_ValueChanged(object sender, EventArgs e)
        {
            if (!IsAnimating && !MovingVertex)
                TriangleGrid.lightSourcePos.Y = lightYSlider.Value / 100.0f;

            lightYLabel.Text = string.Format("Y: {0:F}", TriangleGrid.lightSourcePos.Y);

            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void lightZSlider_ValueChanged(object sender, EventArgs e)
        {
            TriangleGrid.lightSourcePos.Z = lightZSlider.Value / 100.0f;

            lightZLabel.Text = string.Format("Z: {0:F}", TriangleGrid.lightSourcePos.Z);

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
                lightColorButton.BackColor = colorDialog.Color;
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

        }

        private void objectColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                TriangleGrid.objectColor = new Point3D(
                    colorDialog.Color.R / 255.0f,
                    colorDialog.Color.G / 255.0f,
                    colorDialog.Color.B / 255.0f);
                objectColorButton.BackColor = colorDialog.Color;
                objectColorButton.Refresh();
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

            lightXLabel.Text = string.Format("X: {0:F}", newX);
            lightYLabel.Text = string.Format("Y: {0:F}", newY);

            lightXSlider.Value = (int)(newX * 100f);
            lightYSlider.Value = (int)(newY * 100f);

            angle += 0.05f;//0.9f * timeStep;
            //TGrid.DrawTriangleGrid(bmp);
            canvas.Invalidate();

        }

        private void textureButton_Click(object sender, EventArgs e)
        {
            if (chooseFileDialog.ShowDialog() == DialogResult.OK)
            {
                Texture = new DirectBitmap(Image.FromFile(chooseFileDialog.FileName), CanvasSize + 1, CanvasSize + 1);
                TriangleGrid.textureFlag = 1;
                stashedTexture = Image.FromFile(chooseFileDialog.FileName);
                texturePictureBox.Image = stashedTexture;
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
            MousePos = e.Location;

            if (MovingVertex == false)
            {
                canvas.Refresh();
                return;
            }

            float newX = 1.0f * e.Location.X / CanvasSize;
            float newY = 1.0f * e.Location.Y / CanvasSize;

            if (selectedPoint != null &&
                Math.Abs(selectedPoint.X - newX) < 1e-2 &&
                Math.Abs(selectedPoint.Y - newY) < 1e-2)
                return;

            if (selectedPoint == TriangleGrid.lightSourcePos)
            {
                if (IsAnimating) return;

                lightXSlider.Value = Math.Clamp((int)(TriangleGrid.lightSourcePos.X * lightXSlider.Maximum), lightXSlider.Minimum, lightXSlider.Maximum);
                lightYSlider.Value = Math.Clamp((int)(TriangleGrid.lightSourcePos.Y * lightYSlider.Maximum), lightYSlider.Minimum, lightYSlider.Maximum);

                selectedPoint.X = TriangleGrid.lightSourcePos.X = newX;
                selectedPoint.Y = TriangleGrid.lightSourcePos.Y = newY;

                TGrid.DrawTriangleGrid(bmp);
                canvas.Refresh();
                return;
            }

            for (int i = 0; i <= ctrlPtsNo; i++)
            {
                for (int j = 0; j <= ctrlPtsNo; j++)
                {
                    // save i, j of clickedPoint
                    if (controlPoints[i, j] == selectedPoint)
                    {
                        float newZ = (selectedPoint.Y - 1.0f * e.Location.Y / CanvasSize) * 4;
                        //if (newZ < -1 || newZ > 1)
                        //    return;

                        controlPoints[i, j].Z = Math.Clamp(newZ, -1, 1);
                        pointHeightSlider.Value = (int)(controlPoints[i, j].Z * (pointHeightSlider.Maximum));

                        if (newZ > -1 && newZ < 1)
                        {
                            TGrid.DrawTriangleGrid(bmp);
                            lightSrcGroupBox.Refresh();
                            canvas.Refresh();

                        }
                        return;
                    }
                }
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            MousePos = e.Location;
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
                selectedPoint = TriangleGrid.lightSourcePos;

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
                        selectedPoint = controlPoints[i, j];

                        ctrlPointXLabel.Text = string.Format("{0:F}", selectedPoint.X);
                        ctrlPointYLabel.Text = string.Format("{0:F}", selectedPoint.Y);
                        ctrlPointZLabel.Text = string.Format("{0:F}", selectedPoint.Z);

                        pointHeightSlider.Value = (int)(selectedPoint.Z * 100.0);
                        pointHeightSlider.Enabled = true;

                        MovingVertex = true;

                        canvas.Refresh();

                        return;
                    }
                }
            }

            selectedPoint = null;

            /// DEBUG
            //{
            //    debugPoint = MousePos;
            //    TGrid.DrawTriangleGrid(bmp);
            //    canvas.Refresh();
            //}
            /// DEBUG

            ctrlPointXLabel.Text = "";
            ctrlPointYLabel.Text = "";
            ctrlPointZLabel.Text = "";

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
            stashedNormalMap = image;
            normalMapPictureBox.Image = image;
            TriangleGrid.normalMapFlag = 1;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void replaceNormalVectorsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AddNormalVectors = 0;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void addNormalVectorsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AddNormalVectors = 1;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void collapsibleGroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void triangleDensityGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lightZSlider_Scroll(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }



        private void triangleGridCheckbox_CheckStateChanged(object sender, EventArgs e)
        {
            if (triangleGridCheckbox.CheckState == CheckState.Unchecked)
            {
                TGrid.showMesh = TGrid.showTriangleGrid = false;
            }
            else if (triangleGridCheckbox.CheckState == CheckState.Checked)
            {
                TGrid.showMesh = false;
                TGrid.showTriangleGrid = true;
            }
            else if (triangleGridCheckbox.CheckState == CheckState.Indeterminate)
            {
                TGrid.showMesh = TGrid.showTriangleGrid = true;
            }

            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void resetSurfaceButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= ctrlPtsNo; i++)
            {
                for (int j = 0; j <= ctrlPtsNo; j++)
                {
                    controlPoints[i, j].Z = 0;
                }
            }

            selectedPoint = null;

            ctrlPointXLabel.Text = "";
            ctrlPointYLabel.Text = "";
            ctrlPointZLabel.Text = "";

            pointHeightSlider.Value = (pointHeightSlider.Maximum + pointHeightSlider.Minimum) / 2;
            pointHeightSlider.Enabled = false;

            TGrid.CalculateVertexGrid();
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
            //PointHeightBox.Refresh();
        }

        private void canvas_MouseLeave(object sender, EventArgs e)
        {
            MousePos = new Point(-100, -100);
            canvas.Refresh();
        }

        private void resetLightPosButton_Click(object sender, EventArgs e)
        {
            InitializeLight();
            animationCheckBox.Checked = false;
        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void objColorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            objColorRadioButton_CheckedChanged();
        }

        private void objColorRadioButton_CheckedChanged()
        {
            if (objColorRadioButton.Checked)
            {
                objectColorButton.Enabled = true;

                textureRadioButton.Checked = false;
                textureComboBox.Enabled = false;
                textureFileButton.Enabled = false;
                texturePictureBox.Image = null;

                TriangleGrid.textureFlag = 0;
                TGrid.DrawTriangleGrid(bmp);
                canvas.Refresh();
            }
        }

        private void textureRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (textureRadioButton.Checked)
            {
                objectColorButton.Enabled = false;
                objColorRadioButton.Checked = false;
                objectColorButton.BackColor = Color.White;

                textureComboBox.Enabled = true;
                textureFileButton.Enabled = true;
                texturePictureBox.Image = stashedTexture ?? null;

                TriangleGrid.textureFlag = 1;
                TGrid.DrawTriangleGrid(bmp);
                canvas.Refresh();
            }
        }

        private void normalMapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            normalMapCheckBox_CheckedChanged();
        }

        private void normalMapCheckBox_CheckedChanged()
        {
            foreach (Control control in normalMapGroupBox.Controls)
            {
                if (control != panelWithNormalMapCheckBox)
                    control.Enabled = normalMapCheckBox.Checked;
            }
            normalMapComboBox.Enabled = normalMapCheckBox.Checked;
            normalMapFileButton.Enabled = normalMapCheckBox.Checked;
            normalMapPictureBox.Enabled = normalMapCheckBox.Checked;
            normalMapCheckBox.Enabled = true;

            TriangleGrid.normalMapFlag = normalMapCheckBox.Checked ? 1 : 0;

            if (normalMapCheckBox.Checked)
                normalMapPictureBox.Image = stashedNormalMap ?? null;
            else
                normalMapPictureBox.Image = null;
        }

        private void kotowskiRadioButton_Click(object sender, EventArgs e)
        {
            TriangleGrid.zuchowski = false;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }

        private void zuchowskiRadioButton_Click(object sender, EventArgs e)
        {
            TriangleGrid.zuchowski = true;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();

        }

        private void normalMapStandardCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TriangleGrid.invertYnormalMap =
                normalMapStandardCheckBox.Checked ? -1 : 1;
            TGrid.DrawTriangleGrid(bmp);
            canvas.Refresh();
        }
    }
}