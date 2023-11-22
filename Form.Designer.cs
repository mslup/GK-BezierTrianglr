namespace lab2
{
    partial class Trianglr
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer = new SplitContainer();
            canvas = new PictureBox();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            lightSrcGroupBox = new GroupBox();
            trackBar3 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar1 = new TrackBar();
            PointHeightBox = new GroupBox();
            pointHeightSlider = new TrackBar();
            ZLabel = new Label();
            label7 = new Label();
            YLabel = new Label();
            label5 = new Label();
            XLabel = new Label();
            label3 = new Label();
            triangleDensityGroupBox = new GroupBox();
            verticalDensityLabel = new Label();
            horizontalDensityLabel = new Label();
            verticalDensitySlider = new TrackBar();
            horizontalDensitySlider = new TrackBar();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            lightSrcGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            PointHeightBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pointHeightSlider).BeginInit();
            triangleDensityGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)verticalDensitySlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)horizontalDensitySlider).BeginInit();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.FixedPanel = FixedPanel.Panel1;
            splitContainer.IsSplitterFixed = true;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(canvas);
            splitContainer.Panel1MinSize = 500;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.AutoScroll = true;
            splitContainer.Panel2.Controls.Add(groupBox2);
            splitContainer.Panel2.Controls.Add(groupBox1);
            splitContainer.Panel2.Controls.Add(lightSrcGroupBox);
            splitContainer.Panel2.Controls.Add(PointHeightBox);
            splitContainer.Panel2.Controls.Add(triangleDensityGroupBox);
            splitContainer.Size = new Size(816, 780);
            splitContainer.SplitterDistance = 500;
            splitContainer.TabIndex = 0;
            // 
            // canvas
            // 
            canvas.BackColor = Color.White;
            canvas.Dock = DockStyle.Fill;
            canvas.Location = new Point(0, 0);
            canvas.Name = "canvas";
            canvas.Size = new Size(500, 780);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            canvas.MouseClick += canvas_MouseClick;
            canvas.MouseMove += canvas_MouseMove;
            // 
            // groupBox2
            // 
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 517);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(312, 100);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // groupBox1
            // 
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 417);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(312, 100);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // lightSrcGroupBox
            // 
            lightSrcGroupBox.Controls.Add(trackBar3);
            lightSrcGroupBox.Controls.Add(trackBar2);
            lightSrcGroupBox.Controls.Add(trackBar1);
            lightSrcGroupBox.Dock = DockStyle.Top;
            lightSrcGroupBox.Location = new Point(0, 269);
            lightSrcGroupBox.Name = "lightSrcGroupBox";
            lightSrcGroupBox.Size = new Size(312, 148);
            lightSrcGroupBox.TabIndex = 2;
            lightSrcGroupBox.TabStop = false;
            lightSrcGroupBox.Text = "Light source parameters";
            // 
            // trackBar3
            // 
            trackBar3.Dock = DockStyle.Top;
            trackBar3.Location = new Point(3, 109);
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(306, 45);
            trackBar3.TabIndex = 3;
            // 
            // trackBar2
            // 
            trackBar2.Dock = DockStyle.Top;
            trackBar2.Location = new Point(3, 64);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(306, 45);
            trackBar2.TabIndex = 1;
            // 
            // trackBar1
            // 
            trackBar1.Dock = DockStyle.Top;
            trackBar1.Location = new Point(3, 19);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(306, 45);
            trackBar1.TabIndex = 0;
            // 
            // PointHeightBox
            // 
            PointHeightBox.Controls.Add(pointHeightSlider);
            PointHeightBox.Controls.Add(ZLabel);
            PointHeightBox.Controls.Add(label7);
            PointHeightBox.Controls.Add(YLabel);
            PointHeightBox.Controls.Add(label5);
            PointHeightBox.Controls.Add(XLabel);
            PointHeightBox.Controls.Add(label3);
            PointHeightBox.Dock = DockStyle.Top;
            PointHeightBox.Location = new Point(0, 148);
            PointHeightBox.Name = "PointHeightBox";
            PointHeightBox.Size = new Size(312, 121);
            PointHeightBox.TabIndex = 1;
            PointHeightBox.TabStop = false;
            PointHeightBox.Text = "Point";
            // 
            // pointHeightSlider
            // 
            pointHeightSlider.Dock = DockStyle.Bottom;
            pointHeightSlider.Location = new Point(3, 73);
            pointHeightSlider.Maximum = 100;
            pointHeightSlider.Name = "pointHeightSlider";
            pointHeightSlider.Size = new Size(306, 45);
            pointHeightSlider.TabIndex = 6;
            pointHeightSlider.TickFrequency = 10;
            pointHeightSlider.ValueChanged += pointHeightScrollBar_ValueChanged;
            // 
            // ZLabel
            // 
            ZLabel.AutoSize = true;
            ZLabel.Location = new Point(29, 49);
            ZLabel.Name = "ZLabel";
            ZLabel.Size = new Size(0, 15);
            ZLabel.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 49);
            label7.Name = "label7";
            label7.Size = new Size(17, 15);
            label7.TabIndex = 4;
            label7.Text = "Z:";
            // 
            // YLabel
            // 
            YLabel.AutoSize = true;
            YLabel.Location = new Point(29, 34);
            YLabel.Name = "YLabel";
            YLabel.Size = new Size(0, 15);
            YLabel.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 34);
            label5.Name = "label5";
            label5.Size = new Size(17, 15);
            label5.TabIndex = 2;
            label5.Text = "Y:";
            // 
            // XLabel
            // 
            XLabel.AutoSize = true;
            XLabel.Location = new Point(29, 19);
            XLabel.Name = "XLabel";
            XLabel.Size = new Size(0, 15);
            XLabel.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(17, 15);
            label3.TabIndex = 0;
            label3.Text = "X:";
            // 
            // triangleDensityGroupBox
            // 
            triangleDensityGroupBox.Controls.Add(verticalDensityLabel);
            triangleDensityGroupBox.Controls.Add(horizontalDensityLabel);
            triangleDensityGroupBox.Controls.Add(verticalDensitySlider);
            triangleDensityGroupBox.Controls.Add(horizontalDensitySlider);
            triangleDensityGroupBox.Controls.Add(label2);
            triangleDensityGroupBox.Controls.Add(label1);
            triangleDensityGroupBox.Dock = DockStyle.Top;
            triangleDensityGroupBox.Location = new Point(0, 0);
            triangleDensityGroupBox.Name = "triangleDensityGroupBox";
            triangleDensityGroupBox.Size = new Size(312, 148);
            triangleDensityGroupBox.TabIndex = 0;
            triangleDensityGroupBox.TabStop = false;
            triangleDensityGroupBox.Text = "Triangle grid density";
            // 
            // verticalDensityLabel
            // 
            verticalDensityLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            verticalDensityLabel.AutoSize = true;
            verticalDensityLabel.Location = new Point(277, 82);
            verticalDensityLabel.Name = "verticalDensityLabel";
            verticalDensityLabel.Size = new Size(13, 15);
            verticalDensityLabel.TabIndex = 7;
            verticalDensityLabel.Text = "3";
            verticalDensityLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // horizontalDensityLabel
            // 
            horizontalDensityLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            horizontalDensityLabel.AutoSize = true;
            horizontalDensityLabel.Location = new Point(277, 16);
            horizontalDensityLabel.Name = "horizontalDensityLabel";
            horizontalDensityLabel.Size = new Size(13, 15);
            horizontalDensityLabel.TabIndex = 6;
            horizontalDensityLabel.Text = "3";
            horizontalDensityLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // verticalDensitySlider
            // 
            verticalDensitySlider.Dock = DockStyle.Bottom;
            verticalDensitySlider.Location = new Point(3, 100);
            verticalDensitySlider.Maximum = 51;
            verticalDensitySlider.Minimum = 3;
            verticalDensitySlider.Name = "verticalDensitySlider";
            verticalDensitySlider.Size = new Size(306, 45);
            verticalDensitySlider.TabIndex = 5;
            verticalDensitySlider.TickFrequency = 3;
            verticalDensitySlider.Value = 3;
            verticalDensitySlider.ValueChanged += verticalDensityScrollBar_ValueChanged;
            // 
            // horizontalDensitySlider
            // 
            horizontalDensitySlider.Dock = DockStyle.Top;
            horizontalDensitySlider.Location = new Point(3, 34);
            horizontalDensitySlider.Maximum = 51;
            horizontalDensitySlider.Minimum = 3;
            horizontalDensitySlider.Name = "horizontalDensitySlider";
            horizontalDensitySlider.Size = new Size(306, 45);
            horizontalDensitySlider.TabIndex = 4;
            horizontalDensitySlider.TickFrequency = 3;
            horizontalDensitySlider.Value = 3;
            horizontalDensitySlider.ValueChanged += horizontalDensityScrollBar_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 82);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 3;
            label2.Text = "Vertical density";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(3, 19);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 2;
            label1.Text = "Horizontal density";
            // 
            // Trianglr
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 780);
            Controls.Add(splitContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Trianglr";
            Text = "Trianglr";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            lightSrcGroupBox.ResumeLayout(false);
            lightSrcGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            PointHeightBox.ResumeLayout(false);
            PointHeightBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pointHeightSlider).EndInit();
            triangleDensityGroupBox.ResumeLayout(false);
            triangleDensityGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)verticalDensitySlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)horizontalDensitySlider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer;
        private PictureBox canvas;
        private GroupBox triangleDensityGroupBox;
        private Label label1;
        private TrackBar verticalDensitySlider;
        private TrackBar horizontalDensitySlider;
        private Label label2;
        private GroupBox PointHeightBox;
        private Label label3;
        private TrackBar pointHeightSlider;
        private Label ZLabel;
        private Label label7;
        private Label YLabel;
        private Label label5;
        private Label XLabel;
        private Label verticalDensityLabel;
        private Label horizontalDensityLabel;
        private GroupBox groupBox1;
        private GroupBox lightSrcGroupBox;
        private TrackBar trackBar3;
        private TrackBar trackBar2;
        private TrackBar trackBar1;
        private GroupBox groupBox2;
    }
}