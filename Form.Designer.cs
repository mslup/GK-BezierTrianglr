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
            components = new System.ComponentModel.Container();
            splitContainer = new SplitContainer();
            canvas = new PictureBox();
            groupBox4 = new GroupBox();
            comboBox1 = new ComboBox();
            textureButton = new Button();
            objectColorButton = new Button();
            groupBox3 = new GroupBox();
            normalMapComboBox = new ComboBox();
            normalMapButton = new Button();
            groupBox2 = new GroupBox();
            lightColorButton = new Button();
            groupBox1 = new GroupBox();
            mSlider = new TrackBar();
            kSSlider = new TrackBar();
            kDSlider = new TrackBar();
            lightSrcGroupBox = new GroupBox();
            animationCheckBox = new CheckBox();
            lightZSlider = new TrackBar();
            lightYSlider = new TrackBar();
            lightXSlider = new TrackBar();
            PointHeightBox = new GroupBox();
            pointHeightSlider = new TrackBar();
            ZLabel = new Label();
            label7 = new Label();
            YLabel = new Label();
            label5 = new Label();
            XLabel = new Label();
            label3 = new Label();
            triangleDensityGroupBox = new GroupBox();
            normalVectorsCheckbox = new CheckBox();
            triangleGridCheckbox = new CheckBox();
            verticalDensityLabel = new Label();
            horizontalDensityLabel = new Label();
            verticalDensitySlider = new TrackBar();
            horizontalDensitySlider = new TrackBar();
            label2 = new Label();
            label1 = new Label();
            colorDialog = new ColorDialog();
            chooseFileDialog = new OpenFileDialog();
            animationTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kSSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kDSlider).BeginInit();
            lightSrcGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lightZSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lightYSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lightXSlider).BeginInit();
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
            splitContainer.Panel2.Controls.Add(groupBox4);
            splitContainer.Panel2.Controls.Add(groupBox3);
            splitContainer.Panel2.Controls.Add(groupBox2);
            splitContainer.Panel2.Controls.Add(groupBox1);
            splitContainer.Panel2.Controls.Add(lightSrcGroupBox);
            splitContainer.Panel2.Controls.Add(PointHeightBox);
            splitContainer.Panel2.Controls.Add(triangleDensityGroupBox);
            splitContainer.Size = new Size(829, 1048);
            splitContainer.SplitterDistance = 500;
            splitContainer.TabIndex = 0;
            // 
            // canvas
            // 
            canvas.BackColor = Color.White;
            canvas.Dock = DockStyle.Fill;
            canvas.Location = new Point(0, 0);
            canvas.Name = "canvas";
            canvas.Size = new Size(500, 1048);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            canvas.MouseDown += canvas_MouseDown;
            canvas.MouseMove += canvas_MouseMove;
            canvas.MouseUp += canvas_MouseUp;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(comboBox1);
            groupBox4.Controls.Add(textureButton);
            groupBox4.Controls.Add(objectColorButton);
            groupBox4.Dock = DockStyle.Top;
            groupBox4.Location = new Point(0, 843);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(325, 100);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "Object color";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(87, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 2;
            // 
            // textureButton
            // 
            textureButton.Location = new Point(8, 51);
            textureButton.Name = "textureButton";
            textureButton.Size = new Size(137, 23);
            textureButton.TabIndex = 1;
            textureButton.Text = "Choose texture";
            textureButton.UseVisualStyleBackColor = true;
            textureButton.Click += textureButton_Click;
            // 
            // objectColorButton
            // 
            objectColorButton.Location = new Point(6, 22);
            objectColorButton.Name = "objectColorButton";
            objectColorButton.Size = new Size(75, 23);
            objectColorButton.TabIndex = 1;
            objectColorButton.Text = "Pick color";
            objectColorButton.UseVisualStyleBackColor = true;
            objectColorButton.Click += objectColorButton_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(normalMapComboBox);
            groupBox3.Controls.Add(normalMapButton);
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(0, 743);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(325, 100);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Normal map";
            // 
            // normalMapComboBox
            // 
            normalMapComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            normalMapComboBox.FormattingEnabled = true;
            normalMapComboBox.Items.AddRange(new object[] { "BrickWall" });
            normalMapComboBox.Location = new Point(8, 51);
            normalMapComboBox.Name = "normalMapComboBox";
            normalMapComboBox.Size = new Size(138, 23);
            normalMapComboBox.TabIndex = 1;
            normalMapComboBox.SelectedIndexChanged += normalMapComboBox_SelectedIndexChanged;
            // 
            // normalMapButton
            // 
            normalMapButton.Location = new Point(8, 22);
            normalMapButton.Name = "normalMapButton";
            normalMapButton.Size = new Size(137, 23);
            normalMapButton.TabIndex = 0;
            normalMapButton.Text = "Choose normal map";
            normalMapButton.UseVisualStyleBackColor = true;
            normalMapButton.Click += normalMapButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lightColorButton);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 643);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(325, 100);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Light color";
            // 
            // lightColorButton
            // 
            lightColorButton.Location = new Point(6, 22);
            lightColorButton.Name = "lightColorButton";
            lightColorButton.Size = new Size(75, 23);
            lightColorButton.TabIndex = 0;
            lightColorButton.Text = "Pick color";
            lightColorButton.UseVisualStyleBackColor = true;
            lightColorButton.Click += lightColorButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(mSlider);
            groupBox1.Controls.Add(kSSlider);
            groupBox1.Controls.Add(kDSlider);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 475);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(325, 168);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Light reflection parameters";
            // 
            // mSlider
            // 
            mSlider.Dock = DockStyle.Top;
            mSlider.Location = new Point(3, 109);
            mSlider.Maximum = 100;
            mSlider.Minimum = 1;
            mSlider.Name = "mSlider";
            mSlider.Size = new Size(319, 45);
            mSlider.TabIndex = 2;
            mSlider.TickFrequency = 10;
            mSlider.Value = 1;
            mSlider.ValueChanged += mSlider_ValueChanged;
            // 
            // kSSlider
            // 
            kSSlider.Dock = DockStyle.Top;
            kSSlider.Location = new Point(3, 64);
            kSSlider.Maximum = 100;
            kSSlider.Name = "kSSlider";
            kSSlider.Size = new Size(319, 45);
            kSSlider.TabIndex = 1;
            kSSlider.TickFrequency = 10;
            kSSlider.ValueChanged += kSSlider_ValueChanged;
            // 
            // kDSlider
            // 
            kDSlider.Dock = DockStyle.Top;
            kDSlider.Location = new Point(3, 19);
            kDSlider.Maximum = 100;
            kDSlider.Name = "kDSlider";
            kDSlider.Size = new Size(319, 45);
            kDSlider.TabIndex = 0;
            kDSlider.TickFrequency = 10;
            kDSlider.ValueChanged += kDSlider_ValueChanged;
            // 
            // lightSrcGroupBox
            // 
            lightSrcGroupBox.Controls.Add(animationCheckBox);
            lightSrcGroupBox.Controls.Add(lightZSlider);
            lightSrcGroupBox.Controls.Add(lightYSlider);
            lightSrcGroupBox.Controls.Add(lightXSlider);
            lightSrcGroupBox.Dock = DockStyle.Top;
            lightSrcGroupBox.Location = new Point(0, 300);
            lightSrcGroupBox.Name = "lightSrcGroupBox";
            lightSrcGroupBox.Size = new Size(325, 175);
            lightSrcGroupBox.TabIndex = 2;
            lightSrcGroupBox.TabStop = false;
            lightSrcGroupBox.Text = "Light source position";
            // 
            // animationCheckBox
            // 
            animationCheckBox.AutoSize = true;
            animationCheckBox.Dock = DockStyle.Fill;
            animationCheckBox.Location = new Point(3, 154);
            animationCheckBox.Name = "animationCheckBox";
            animationCheckBox.Size = new Size(319, 18);
            animationCheckBox.TabIndex = 4;
            animationCheckBox.Text = "Animation";
            animationCheckBox.UseVisualStyleBackColor = true;
            animationCheckBox.CheckedChanged += animationCheckBox_CheckedChanged;
            // 
            // lightZSlider
            // 
            lightZSlider.Dock = DockStyle.Top;
            lightZSlider.Location = new Point(3, 109);
            lightZSlider.Maximum = 100;
            lightZSlider.Minimum = -100;
            lightZSlider.Name = "lightZSlider";
            lightZSlider.Size = new Size(319, 45);
            lightZSlider.TabIndex = 3;
            lightZSlider.TickFrequency = 10;
            lightZSlider.ValueChanged += lightZSlider_ValueChanged;
            // 
            // lightYSlider
            // 
            lightYSlider.Dock = DockStyle.Top;
            lightYSlider.Location = new Point(3, 64);
            lightYSlider.Maximum = 100;
            lightYSlider.Name = "lightYSlider";
            lightYSlider.Size = new Size(319, 45);
            lightYSlider.TabIndex = 1;
            lightYSlider.TickFrequency = 10;
            lightYSlider.ValueChanged += lightYSlider_ValueChanged;
            // 
            // lightXSlider
            // 
            lightXSlider.Dock = DockStyle.Top;
            lightXSlider.Location = new Point(3, 19);
            lightXSlider.Maximum = 100;
            lightXSlider.Name = "lightXSlider";
            lightXSlider.Size = new Size(319, 45);
            lightXSlider.TabIndex = 0;
            lightXSlider.TickFrequency = 10;
            lightXSlider.ValueChanged += lightXSlider_ValueChanged;
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
            PointHeightBox.Location = new Point(0, 179);
            PointHeightBox.Name = "PointHeightBox";
            PointHeightBox.Size = new Size(325, 121);
            PointHeightBox.TabIndex = 1;
            PointHeightBox.TabStop = false;
            PointHeightBox.Text = "Point";
            // 
            // pointHeightSlider
            // 
            pointHeightSlider.Dock = DockStyle.Bottom;
            pointHeightSlider.Location = new Point(3, 73);
            pointHeightSlider.Maximum = 100;
            pointHeightSlider.Minimum = -100;
            pointHeightSlider.Name = "pointHeightSlider";
            pointHeightSlider.Size = new Size(319, 45);
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
            triangleDensityGroupBox.Controls.Add(normalVectorsCheckbox);
            triangleDensityGroupBox.Controls.Add(triangleGridCheckbox);
            triangleDensityGroupBox.Controls.Add(verticalDensityLabel);
            triangleDensityGroupBox.Controls.Add(horizontalDensityLabel);
            triangleDensityGroupBox.Controls.Add(verticalDensitySlider);
            triangleDensityGroupBox.Controls.Add(horizontalDensitySlider);
            triangleDensityGroupBox.Controls.Add(label2);
            triangleDensityGroupBox.Controls.Add(label1);
            triangleDensityGroupBox.Dock = DockStyle.Top;
            triangleDensityGroupBox.Location = new Point(0, 0);
            triangleDensityGroupBox.Name = "triangleDensityGroupBox";
            triangleDensityGroupBox.Size = new Size(325, 179);
            triangleDensityGroupBox.TabIndex = 0;
            triangleDensityGroupBox.TabStop = false;
            triangleDensityGroupBox.Text = "Triangle grid density";
            // 
            // normalVectorsCheckbox
            // 
            normalVectorsCheckbox.AutoSize = true;
            normalVectorsCheckbox.Location = new Point(136, 149);
            normalVectorsCheckbox.Name = "normalVectorsCheckbox";
            normalVectorsCheckbox.Size = new Size(137, 19);
            normalVectorsCheckbox.TabIndex = 0;
            normalVectorsCheckbox.Text = "Show normal vectors";
            normalVectorsCheckbox.UseVisualStyleBackColor = true;
            normalVectorsCheckbox.CheckedChanged += normalVectorsCheckbox_CheckedChanged;
            // 
            // triangleGridCheckbox
            // 
            triangleGridCheckbox.AutoSize = true;
            triangleGridCheckbox.Location = new Point(8, 149);
            triangleGridCheckbox.Name = "triangleGridCheckbox";
            triangleGridCheckbox.Size = new Size(122, 19);
            triangleGridCheckbox.TabIndex = 8;
            triangleGridCheckbox.Text = "Show triangle grid";
            triangleGridCheckbox.UseVisualStyleBackColor = true;
            triangleGridCheckbox.CheckedChanged += triangleGridCheckbox_CheckedChanged;
            // 
            // verticalDensityLabel
            // 
            verticalDensityLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            verticalDensityLabel.AutoSize = true;
            verticalDensityLabel.Location = new Point(290, 82);
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
            horizontalDensityLabel.Location = new Point(290, 19);
            horizontalDensityLabel.Name = "horizontalDensityLabel";
            horizontalDensityLabel.Size = new Size(13, 15);
            horizontalDensityLabel.TabIndex = 6;
            horizontalDensityLabel.Text = "3";
            horizontalDensityLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // verticalDensitySlider
            // 
            verticalDensitySlider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            verticalDensitySlider.Location = new Point(3, 100);
            verticalDensitySlider.Maximum = 51;
            verticalDensitySlider.Minimum = 3;
            verticalDensitySlider.Name = "verticalDensitySlider";
            verticalDensitySlider.Size = new Size(319, 45);
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
            horizontalDensitySlider.Size = new Size(319, 45);
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
            // chooseFileDialog
            // 
            chooseFileDialog.FileName = "openFileDialog1";
            // 
            // animationTimer
            // 
            animationTimer.Tick += AnimationTimer_Tick;
            // 
            // Trianglr
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 1048);
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
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)kSSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)kDSlider).EndInit();
            lightSrcGroupBox.ResumeLayout(false);
            lightSrcGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lightZSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)lightYSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)lightXSlider).EndInit();
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
        private TrackBar lightZSlider;
        private TrackBar lightYSlider;
        private TrackBar lightXSlider;
        private GroupBox groupBox2;
        private CheckBox animationCheckBox;
        private TrackBar kSSlider;
        private TrackBar kDSlider;
        private TrackBar mSlider;
        private Button lightColorButton;
        private ColorDialog colorDialog;
        private GroupBox groupBox3;
        private CheckBox normalVectorsCheckbox;
        private CheckBox triangleGridCheckbox;
        private Button normalMapButton;
        private OpenFileDialog chooseFileDialog;
        private GroupBox groupBox4;
        private Button objectColorButton;
        private System.Windows.Forms.Timer animationTimer;
        private Button textureButton;
        private ComboBox normalMapComboBox;
        private ComboBox comboBox1;
    }
}