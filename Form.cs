using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Security.Policy;
using System.Windows.Forms;
using lab2.Properties;

namespace lab2
{
    public partial class Trianglr : Form
    {
        public const int Eps = 10;
        public const int PointRadius = 5;

        private const int ctrlPtsNo = 3;
        private const string ComboBoxMessage = "Choose predefined...";

        private Point3D[,] controlPoints = new Point3D[ctrlPtsNo + 1, ctrlPtsNo + 1];

        private int CanvasSize;
        private Point3D? selectedPoint = null;
        private Point MousePos;

        private Renderer scene;

        private Image stashedTexture;
        private Image stashedNormalMap;

        private bool MovingVertex = false;
        private bool IsAnimating = false;

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

            scene = new Renderer(
                CanvasSize,
                8, 8,
                controlPoints,
                new Light(
                    new Point3D(0.5f, 0.5f, 0.5f),
                    new Point3D(1, 1, 1)
                    ),
                new SurfaceMaterial(
                    1, 0.5f, 50,
                    new Point3D(0.8f, 0.8f, 0.8f),
                    null, null),
                triangleGridCheckbox.Checked,
                normalVectorsCheckbox.Checked);

            InitializeParameters();

            scene.DrawTriangleGrid();

            textureComboBox.Text = ComboBoxMessage;
            normalMapComboBox.Text = ComboBoxMessage;

            InitializeComboBoxes();

        }

        private void InitializeParameters()
        {
            pointHeightSlider.Value = (pointHeightSlider.Maximum + pointHeightSlider.Minimum) / 2;
            pointHeightSlider.Enabled = false;

            horizontalDensitySlider.Value = scene.HorizontalDensity;
            verticalDensitySlider.Value = scene.VerticalDensity;

            InitializeLight();

            lightColorButton.BackColor = scene.light.Color.ToColor();

            InitializeSlider(kDSlider, scene.material.kD);
            InitializeSlider(kSSlider, scene.material.kS);
            InitializeSlider(mSlider, scene.material.m);

            objColorRadioButton.Checked = true;
            objColorRadioButton_CheckedChanged();
            objectColorButton.BackColor = scene.material.Color.ToColor();

            animationTimer.Interval = 24;

            normalMapCheckBox.Checked = false;
            normalMapCheckBox_CheckedChanged();

            scene.invertYnormalMap = true;

            scene.zuchowski = true;
            zuchowskiRadioButton.Checked = true;

        }

        private void InitializeComboBoxes()
        {
            foreach (DictionaryEntry resource in Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                string name = resource.Key.ToString();

                if (name.EndsWith("NM"))
                {
                    normalMapComboBox.Items.Add(name[..^2]);
                }
                else if (name.EndsWith("T"))
                {
                    textureComboBox.Items.Add(name[..^1]);
                }
            }
        }

        private void InitializeLight()
        {
            scene.light.Position = new Point3D(0.5f, 0.5f, 1);

            InitializeSlider(lightXSlider, scene.light.Position.X);
            InitializeSlider(lightYSlider, scene.light.Position.Y);
            InitializeSlider(lightZSlider, scene.light.Position.Z);
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

            g.DrawImage(scene.Bmp.Bitmap, 0, 0);

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
                    g.DrawPoint(controlPoints[i, j], CanvasSize,
                        controlPoints[i, j].IsXYCloseToPoint(MousePos, CanvasSize) ||
                        (MovingVertex && controlPoints[i, j] == selectedPoint),
                        controlPoints[i, j] == selectedPoint);
                }
            }

            g.DrawPoint(scene.light.Position, CanvasSize,
                scene.light.Position.IsXYCloseToPoint(MousePos, CanvasSize) ||
                        (MovingVertex && scene.light.Position == selectedPoint),
                scene.light.Position == selectedPoint);

        }

        private void pointHeightScrollBar_ValueChanged(object sender, EventArgs e)
        {
            if (selectedPoint == null)
                return;

            selectedPoint.Z = pointHeightSlider.Value / 100.0f;
            ctrlPointZLabel.Text = String.Format("{0:F}", selectedPoint.Z);

            scene.CalculateVertexGrid();
            scene.DrawTriangleGrid();

            canvas.Refresh();
        }

        private void horizontalDensityScrollBar_ValueChanged(object sender, EventArgs e)
        {
            horizontalDensityLabel.Text = $"{horizontalDensitySlider.Value}";

            scene.UpdateHorizontally(horizontalDensitySlider.Value);
            scene.DrawTriangleGrid();

            canvas.Refresh();
        }

        private void verticalDensityScrollBar_ValueChanged(object sender, EventArgs e)
        {
            verticalDensityLabel.Text = $"{verticalDensitySlider.Value}";

            scene.UpdateVertically(verticalDensitySlider.Value);
            scene.DrawTriangleGrid();

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
                scene.light.Position.X = lightXSlider.Value / 100.0f;

            lightXLabel.Text = string.Format("X: {0:F}", scene.light.Position.X);

            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private void lightYSlider_ValueChanged(object sender, EventArgs e)
        {
            if (!IsAnimating && !MovingVertex)
                scene.light.Position.Y = lightYSlider.Value / 100.0f;

            lightYLabel.Text = string.Format("Y: {0:F}", scene.light.Position.Y);

            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private void lightZSlider_ValueChanged(object sender, EventArgs e)
        {
            scene.light.Position.Z = lightZSlider.Value / 100.0f;

            lightZLabel.Text = string.Format("Z: {0:F}", scene.light.Position.Z);

            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private void kDSlider_ValueChanged(object sender, EventArgs e)
        {
            scene.material.kD = kDSlider.Value / 100.0f;
            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private void kSSlider_ValueChanged(object sender, EventArgs e)
        {
            scene.material.kS = kSSlider.Value / 100.0f;
            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private void mSlider_ValueChanged(object sender, EventArgs e)
        {
            scene.material.m = mSlider.Value;
            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private void lightColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                scene.light.Color = new Point3D(
                    colorDialog.Color.R / 255.0f,
                    colorDialog.Color.G / 255.0f,
                    colorDialog.Color.B / 255.0f);
                lightColorButton.BackColor = colorDialog.Color;
            }
            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private void normalVectorsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            scene.showNormalVectors = normalVectorsCheckbox.Checked;
            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private void triangleGridCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void objectColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                scene.material.Color = new Point3D(
                    colorDialog.Color.R / 255.0f,
                    colorDialog.Color.G / 255.0f,
                    colorDialog.Color.B / 255.0f);
                objectColorButton.BackColor = colorDialog.Color;
                objectColorButton.Refresh();
            }
            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private float angle = 0f;
        private float k = 7;

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            float newX = 0.5f + 0.3f * (float)Math.Sin(angle / k) * (float)Math.Cos(angle);
            float newY = 0.5f + 0.3f * (float)Math.Sin(angle / k) * (float)Math.Sin(angle);

            scene.light.Position.X = newX;
            scene.light.Position.Y = newY;

            lightXLabel.Text = string.Format("X: {0:F}", newX);
            lightYLabel.Text = string.Format("Y: {0:F}", newY);

            lightXSlider.Value = (int)(newX * 100f);
            lightYSlider.Value = (int)(newY * 100f);

            angle += 0.05f;//0.9f * timeStep;
            //TGrid.DrawTriangleGrid();
            canvas.Invalidate();

        }

        private void textureButton_Click(object sender, EventArgs e)
        {
            chooseFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif";
            chooseFileDialog.FilterIndex = 1;

            if (chooseFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetTexture(Image.FromFile(chooseFileDialog.FileName));
            }
        }

        private void normalMapButton_Click(object sender, EventArgs e)
        {
            chooseFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif";
            chooseFileDialog.FilterIndex = 1;

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

            if (selectedPoint == scene.light.Position)
            {
                if (IsAnimating) return;

                lightXSlider.Value = Math.Clamp((int)(scene.light.Position.X * lightXSlider.Maximum), lightXSlider.Minimum, lightXSlider.Maximum);
                lightYSlider.Value = Math.Clamp((int)(scene.light.Position.Y * lightYSlider.Maximum), lightYSlider.Minimum, lightYSlider.Maximum);

                selectedPoint.X = scene.light.Position.X = newX;
                selectedPoint.Y = scene.light.Position.Y = newY;

                scene.DrawTriangleGrid();
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
                            scene.DrawTriangleGrid();
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

            if (scene.light.Position.IsXYCloseToPoint(MousePos, CanvasSize))
            {
                selectedPoint = scene.light.Position;

                MovingVertex = true;
                (sender as Control).Invalidate();
                return;
            }

            for (int i = 0; i <= ctrlPtsNo; i++)
            {
                for (int j = 0; j <= ctrlPtsNo; j++)
                {
                    if (controlPoints[i, j].IsXYCloseToPoint(MousePos, CanvasSize))
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
            //    TGrid.DrawTriangleGrid();
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

        private void SetNormalMap(Image image)
        {
            stashedNormalMap = image;
            normalMapPictureBox.Image = image;
            scene.SetNormalMap(image);
            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private void SetTexture(Image image)
        {
            stashedTexture = image;
            texturePictureBox.Image = image;
            scene.SetTexture(image);
            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private void replaceNormalVectorsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            scene.AddNormalVectors = false;
            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private void addNormalVectorsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            scene.AddNormalVectors = true;
            scene.DrawTriangleGrid();
            canvas.Refresh();
        }


        private void triangleGridCheckbox_CheckStateChanged(object sender, EventArgs e)
        {
            if (triangleGridCheckbox.CheckState == CheckState.Unchecked)
            {
                scene.showMesh = scene.showTriangleGrid = false;
            }
            else if (triangleGridCheckbox.CheckState == CheckState.Checked)
            {
                scene.showMesh = false;
                scene.showTriangleGrid = true;
            }
            else if (triangleGridCheckbox.CheckState == CheckState.Indeterminate)
            {
                scene.showMesh = scene.showTriangleGrid = true;
            }

            scene.DrawTriangleGrid();
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

            scene.CalculateVertexGrid();
            scene.DrawTriangleGrid();
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
                scene.IsTextureEnabled = false;

                objectColorButton.BackColor = scene.material.Color.ToColor();

                scene.DrawTriangleGrid();
                canvas.Refresh();
            }
        }

        private void textureRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (textureRadioButton.Checked)
            {
                objectColorButton.Enabled = false;
                objColorRadioButton.Checked = false;
                objectColorButton.BackColor = SystemColors.ButtonShadow;

                textureComboBox.Enabled = true;
                textureFileButton.Enabled = true;
                texturePictureBox.Image = stashedTexture ?? null;
                scene.IsTextureEnabled = true;

                scene.DrawTriangleGrid();
                canvas.Refresh();
            }
        }

        private void normalMapCheckBox_CheckedChanged(object sender, EventArgs e) => normalMapCheckBox_CheckedChanged();

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

            if (normalMapCheckBox.Checked)
                normalMapPictureBox.Image = stashedNormalMap ?? null;
            else
                normalMapPictureBox.Image = null;

            scene.IsNormalMapEnabled = normalMapCheckBox.Checked;
            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private void kotowskiRadioButton_Click(object sender, EventArgs e)
        {
            scene.zuchowski = false;
            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private void zuchowskiRadioButton_Click(object sender, EventArgs e)
        {
            scene.zuchowski = true;
            scene.DrawTriangleGrid();
            canvas.Refresh();

        }

        private void normalMapStandardCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            scene.invertYnormalMap =
                !normalMapStandardCheckBox.Checked;
            scene.DrawTriangleGrid();
            canvas.Refresh();
        }

        private void normalMapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!normalMapComboBox.Enabled)
                return;

            normalMapComboBox.Items.Remove(ComboBoxMessage);

            var item = normalMapComboBox.SelectedItem;
            try
            {
                SetNormalMap((Image)Resources.ResourceManager.GetObject((string)item + "NM"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void textureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!textureComboBox.Enabled)
                return;

            textureComboBox.Items.Remove(ComboBoxMessage);

            var item = textureComboBox.SelectedItem;
            try
            {
                SetTexture((Image)Resources.ResourceManager.GetObject((string)item + "T"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
    }
}