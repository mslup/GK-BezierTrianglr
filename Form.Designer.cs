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
            lightSrcGroupBox = new GroupBox();
            animationCheckBox = new CheckBox();
            panel18 = new Panel();
            resetLightPosButton = new Button();
            panel3 = new Panel();
            lightZLabel = new Label();
            lightZSlider = new TrackBar();
            panel2 = new Panel();
            lightYLabel = new Label();
            lightYSlider = new TrackBar();
            panel1 = new Panel();
            lightXLabel = new Label();
            lightXSlider = new TrackBar();
            groupBox4 = new GroupBox();
            panel9 = new Panel();
            textureFileButton = new Button();
            textureComboBox = new ComboBox();
            textureRadioButton = new RadioButton();
            panel19 = new Panel();
            texturePictureBox = new PictureBox();
            panel7 = new Panel();
            panel8 = new Panel();
            objectColorButton = new Button();
            objColorRadioButton = new RadioButton();
            triangleDensityGroupBox = new GroupBox();
            normalVectorsCheckbox = new CheckBox();
            triangleGridCheckbox = new CheckBox();
            verticalDensityLabel = new Label();
            horizontalDensityLabel = new Label();
            verticalDensitySlider = new TrackBar();
            horizontalDensitySlider = new TrackBar();
            label2 = new Label();
            label1 = new Label();
            normalMapGroupBox = new GroupBox();
            panel17 = new Panel();
            zuchowskiRadioButton = new RadioButton();
            kotowskiRadioButton = new RadioButton();
            label6 = new Label();
            panel16 = new Panel();
            replaceNormalVectorsRadioButton = new RadioButton();
            addNormalVectorsRadioButton = new RadioButton();
            label4 = new Label();
            panel15 = new Panel();
            normalMapStandardCheckBox = new CheckBox();
            panelWithNormalMapCheckBox = new Panel();
            panel11 = new Panel();
            normalMapComboBox = new ComboBox();
            normalMapFileButton = new Button();
            normalMapCheckBox = new CheckBox();
            panel10 = new Panel();
            normalMapPictureBox = new PictureBox();
            groupBox2 = new GroupBox();
            lightColorButton = new Button();
            PointHeightBox = new GroupBox();
            resetSurfaceButton = new Button();
            pointHeightSlider = new TrackBar();
            ctrlPointZLabel = new Label();
            label7 = new Label();
            ctrlPointYLabel = new Label();
            label5 = new Label();
            ctrlPointXLabel = new Label();
            label3 = new Label();
            sphereCheckBox = new CheckBox();
            groupBox1 = new GroupBox();
            panel4 = new Panel();
            mSlider = new TrackBar();
            label9 = new Label();
            panel5 = new Panel();
            kSSlider = new TrackBar();
            label10 = new Label();
            panel6 = new Panel();
            kDSlider = new TrackBar();
            label11 = new Label();
            colorDialog = new ColorDialog();
            chooseFileDialog = new OpenFileDialog();
            animationTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            lightSrcGroupBox.SuspendLayout();
            panel18.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lightZSlider).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lightYSlider).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lightXSlider).BeginInit();
            groupBox4.SuspendLayout();
            panel9.SuspendLayout();
            panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)texturePictureBox).BeginInit();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            triangleDensityGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)verticalDensitySlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)horizontalDensitySlider).BeginInit();
            normalMapGroupBox.SuspendLayout();
            panel17.SuspendLayout();
            panel16.SuspendLayout();
            panel15.SuspendLayout();
            panelWithNormalMapCheckBox.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)normalMapPictureBox).BeginInit();
            groupBox2.SuspendLayout();
            PointHeightBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pointHeightSlider).BeginInit();
            groupBox1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mSlider).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)kSSlider).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)kDSlider).BeginInit();
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
            splitContainer.Panel2.Controls.Add(lightSrcGroupBox);
            splitContainer.Panel2.Controls.Add(groupBox4);
            splitContainer.Panel2.Controls.Add(triangleDensityGroupBox);
            splitContainer.Panel2.Controls.Add(normalMapGroupBox);
            splitContainer.Panel2.Controls.Add(groupBox2);
            splitContainer.Panel2.Controls.Add(PointHeightBox);
            splitContainer.Panel2.Controls.Add(groupBox1);
            splitContainer.Size = new Size(1252, 582);
            splitContainer.SplitterDistance = 500;
            splitContainer.TabIndex = 0;
            // 
            // canvas
            // 
            canvas.BackColor = Color.White;
            canvas.Dock = DockStyle.Fill;
            canvas.Location = new Point(0, 0);
            canvas.Name = "canvas";
            canvas.Size = new Size(500, 582);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            canvas.MouseDown += canvas_MouseDown;
            canvas.MouseLeave += canvas_MouseLeave;
            canvas.MouseMove += canvas_MouseMove;
            canvas.MouseUp += canvas_MouseUp;
            // 
            // lightSrcGroupBox
            // 
            lightSrcGroupBox.Controls.Add(animationCheckBox);
            lightSrcGroupBox.Controls.Add(panel18);
            lightSrcGroupBox.Controls.Add(panel3);
            lightSrcGroupBox.Controls.Add(panel2);
            lightSrcGroupBox.Controls.Add(panel1);
            lightSrcGroupBox.Location = new Point(6, 327);
            lightSrcGroupBox.Name = "lightSrcGroupBox";
            lightSrcGroupBox.Padding = new Padding(3, 9, 3, 8);
            lightSrcGroupBox.Size = new Size(276, 170);
            lightSrcGroupBox.TabIndex = 2;
            lightSrcGroupBox.TabStop = false;
            lightSrcGroupBox.Text = "Light source position";
            // 
            // animationCheckBox
            // 
            animationCheckBox.AutoSize = true;
            animationCheckBox.Dock = DockStyle.Left;
            animationCheckBox.Location = new Point(3, 139);
            animationCheckBox.Name = "animationCheckBox";
            animationCheckBox.Padding = new Padding(7, 0, 0, 0);
            animationCheckBox.Size = new Size(89, 23);
            animationCheckBox.TabIndex = 4;
            animationCheckBox.Text = "Animation";
            animationCheckBox.UseVisualStyleBackColor = true;
            animationCheckBox.CheckedChanged += animationCheckBox_CheckedChanged;
            // 
            // panel18
            // 
            panel18.Controls.Add(resetLightPosButton);
            panel18.Dock = DockStyle.Right;
            panel18.Location = new Point(161, 139);
            panel18.Name = "panel18";
            panel18.Padding = new Padding(0, 0, 15, 0);
            panel18.Size = new Size(112, 23);
            panel18.TabIndex = 11;
            // 
            // resetLightPosButton
            // 
            resetLightPosButton.Dock = DockStyle.Fill;
            resetLightPosButton.Location = new Point(0, 0);
            resetLightPosButton.Name = "resetLightPosButton";
            resetLightPosButton.Size = new Size(97, 23);
            resetLightPosButton.TabIndex = 0;
            resetLightPosButton.Text = "Reset position";
            resetLightPosButton.UseVisualStyleBackColor = true;
            resetLightPosButton.Click += resetLightPosButton_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(lightZLabel);
            panel3.Controls.Add(lightZSlider);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(270, 39);
            panel3.TabIndex = 10;
            // 
            // lightZLabel
            // 
            lightZLabel.Dock = DockStyle.Fill;
            lightZLabel.Location = new Point(0, 0);
            lightZLabel.Margin = new Padding(7, 0, 7, 0);
            lightZLabel.Name = "lightZLabel";
            lightZLabel.Padding = new Padding(5, 0, 0, 15);
            lightZLabel.Size = new Size(51, 39);
            lightZLabel.TabIndex = 3;
            lightZLabel.Text = "label8";
            lightZLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lightZSlider
            // 
            lightZSlider.Dock = DockStyle.Right;
            lightZSlider.Location = new Point(51, 0);
            lightZSlider.Maximum = 100;
            lightZSlider.Minimum = -100;
            lightZSlider.Name = "lightZSlider";
            lightZSlider.Size = new Size(219, 39);
            lightZSlider.TabIndex = 3;
            lightZSlider.TickFrequency = 10;
            lightZSlider.ValueChanged += lightZSlider_ValueChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(lightYLabel);
            panel2.Controls.Add(lightYSlider);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 62);
            panel2.Name = "panel2";
            panel2.Size = new Size(270, 38);
            panel2.TabIndex = 9;
            // 
            // lightYLabel
            // 
            lightYLabel.Dock = DockStyle.Fill;
            lightYLabel.Location = new Point(0, 0);
            lightYLabel.Margin = new Padding(7, 0, 7, 0);
            lightYLabel.Name = "lightYLabel";
            lightYLabel.Padding = new Padding(5, 0, 0, 15);
            lightYLabel.Size = new Size(51, 38);
            lightYLabel.TabIndex = 3;
            lightYLabel.Text = "label4";
            lightYLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lightYSlider
            // 
            lightYSlider.Dock = DockStyle.Right;
            lightYSlider.Location = new Point(51, 0);
            lightYSlider.Maximum = 100;
            lightYSlider.Name = "lightYSlider";
            lightYSlider.Size = new Size(219, 38);
            lightYSlider.TabIndex = 1;
            lightYSlider.TickFrequency = 10;
            lightYSlider.ValueChanged += lightYSlider_ValueChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(lightXLabel);
            panel1.Controls.Add(lightXSlider);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 37);
            panel1.TabIndex = 8;
            // 
            // lightXLabel
            // 
            lightXLabel.Dock = DockStyle.Fill;
            lightXLabel.Location = new Point(0, 0);
            lightXLabel.Margin = new Padding(7, 0, 7, 0);
            lightXLabel.Name = "lightXLabel";
            lightXLabel.Padding = new Padding(5, 0, 0, 15);
            lightXLabel.Size = new Size(51, 37);
            lightXLabel.TabIndex = 2;
            lightXLabel.Text = "label6";
            lightXLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lightXSlider
            // 
            lightXSlider.AutoSize = false;
            lightXSlider.Dock = DockStyle.Right;
            lightXSlider.Location = new Point(51, 0);
            lightXSlider.Maximum = 100;
            lightXSlider.Name = "lightXSlider";
            lightXSlider.Size = new Size(219, 37);
            lightXSlider.TabIndex = 0;
            lightXSlider.TickFrequency = 10;
            lightXSlider.ValueChanged += lightXSlider_ValueChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(panel9);
            groupBox4.Controls.Add(panel19);
            groupBox4.Controls.Add(panel7);
            groupBox4.Location = new Point(285, 148);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(289, 143);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "Object color";
            // 
            // panel9
            // 
            panel9.Controls.Add(textureFileButton);
            panel9.Controls.Add(textureComboBox);
            panel9.Controls.Add(textureRadioButton);
            panel9.Dock = DockStyle.Left;
            panel9.Location = new Point(3, 42);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(7, 8, 7, 8);
            panel9.Size = new Size(168, 98);
            panel9.TabIndex = 1;
            // 
            // textureFileButton
            // 
            textureFileButton.Location = new Point(27, 64);
            textureFileButton.Name = "textureFileButton";
            textureFileButton.Size = new Size(134, 24);
            textureFileButton.TabIndex = 1;
            textureFileButton.Text = "Choose file";
            textureFileButton.UseVisualStyleBackColor = true;
            textureFileButton.Click += textureButton_Click;
            // 
            // textureComboBox
            // 
            textureComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            textureComboBox.FormattingEnabled = true;
            textureComboBox.Items.AddRange(new object[] { "Choose predefined..." });
            textureComboBox.Location = new Point(28, 34);
            textureComboBox.Name = "textureComboBox";
            textureComboBox.Size = new Size(132, 23);
            textureComboBox.TabIndex = 2;
            textureComboBox.SelectedIndexChanged += textureComboBox_SelectedIndexChanged;
            // 
            // textureRadioButton
            // 
            textureRadioButton.AutoSize = true;
            textureRadioButton.Dock = DockStyle.Top;
            textureRadioButton.Location = new Point(7, 8);
            textureRadioButton.Name = "textureRadioButton";
            textureRadioButton.Size = new Size(154, 19);
            textureRadioButton.TabIndex = 0;
            textureRadioButton.TabStop = true;
            textureRadioButton.Text = "Texture";
            textureRadioButton.UseVisualStyleBackColor = true;
            textureRadioButton.CheckedChanged += textureRadioButton_CheckedChanged;
            // 
            // panel19
            // 
            panel19.Controls.Add(texturePictureBox);
            panel19.Dock = DockStyle.Right;
            panel19.Location = new Point(177, 42);
            panel19.Name = "panel19";
            panel19.Padding = new Padding(4);
            panel19.Size = new Size(109, 98);
            panel19.TabIndex = 12;
            // 
            // texturePictureBox
            // 
            texturePictureBox.BorderStyle = BorderStyle.FixedSingle;
            texturePictureBox.Location = new Point(7, 4);
            texturePictureBox.MaximumSize = new Size(90, 90);
            texturePictureBox.Name = "texturePictureBox";
            texturePictureBox.Size = new Size(84, 84);
            texturePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            texturePictureBox.TabIndex = 1;
            texturePictureBox.TabStop = false;
            // 
            // panel7
            // 
            panel7.Controls.Add(panel8);
            panel7.Controls.Add(objColorRadioButton);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(3, 19);
            panel7.Name = "panel7";
            panel7.Size = new Size(283, 23);
            panel7.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Controls.Add(objectColorButton);
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(94, 0);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(40, 0, 40, 0);
            panel8.Size = new Size(189, 23);
            panel8.TabIndex = 1;
            // 
            // objectColorButton
            // 
            objectColorButton.Location = new Point(14, 0);
            objectColorButton.Margin = new Padding(10, 3, 10, 3);
            objectColorButton.Name = "objectColorButton";
            objectColorButton.Size = new Size(157, 23);
            objectColorButton.TabIndex = 1;
            objectColorButton.Text = "Pick color";
            objectColorButton.UseVisualStyleBackColor = true;
            objectColorButton.Click += objectColorButton_Click;
            // 
            // objColorRadioButton
            // 
            objColorRadioButton.AutoSize = true;
            objColorRadioButton.Dock = DockStyle.Left;
            objColorRadioButton.Location = new Point(0, 0);
            objColorRadioButton.Name = "objColorRadioButton";
            objColorRadioButton.Padding = new Padding(7, 0, 7, 0);
            objColorRadioButton.Size = new Size(95, 23);
            objColorRadioButton.TabIndex = 0;
            objColorRadioButton.TabStop = true;
            objColorRadioButton.Text = "Solid color";
            objColorRadioButton.UseVisualStyleBackColor = true;
            objColorRadioButton.CheckedChanged += objColorRadioButton_CheckedChanged;
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
            triangleDensityGroupBox.Location = new Point(6, 148);
            triangleDensityGroupBox.Name = "triangleDensityGroupBox";
            triangleDensityGroupBox.Padding = new Padding(3, 9, 3, 3);
            triangleDensityGroupBox.Size = new Size(276, 179);
            triangleDensityGroupBox.TabIndex = 0;
            triangleDensityGroupBox.TabStop = false;
            triangleDensityGroupBox.Text = "Triangle grid";
            // 
            // normalVectorsCheckbox
            // 
            normalVectorsCheckbox.AutoSize = true;
            normalVectorsCheckbox.Location = new Point(136, 155);
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
            triangleGridCheckbox.Location = new Point(8, 155);
            triangleGridCheckbox.Name = "triangleGridCheckbox";
            triangleGridCheckbox.Size = new Size(122, 19);
            triangleGridCheckbox.TabIndex = 8;
            triangleGridCheckbox.Text = "Show triangle grid";
            triangleGridCheckbox.ThreeState = true;
            triangleGridCheckbox.UseVisualStyleBackColor = true;
            triangleGridCheckbox.CheckedChanged += triangleGridCheckbox_CheckedChanged;
            triangleGridCheckbox.CheckStateChanged += triangleGridCheckbox_CheckStateChanged;
            // 
            // verticalDensityLabel
            // 
            verticalDensityLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            verticalDensityLabel.AutoSize = true;
            verticalDensityLabel.Location = new Point(241, 88);
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
            horizontalDensityLabel.Location = new Point(241, 25);
            horizontalDensityLabel.Name = "horizontalDensityLabel";
            horizontalDensityLabel.Size = new Size(13, 15);
            horizontalDensityLabel.TabIndex = 6;
            horizontalDensityLabel.Text = "3";
            horizontalDensityLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // verticalDensitySlider
            // 
            verticalDensitySlider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            verticalDensitySlider.Location = new Point(3, 106);
            verticalDensitySlider.Maximum = 51;
            verticalDensitySlider.Minimum = 3;
            verticalDensitySlider.Name = "verticalDensitySlider";
            verticalDensitySlider.Size = new Size(270, 45);
            verticalDensitySlider.TabIndex = 5;
            verticalDensitySlider.TickFrequency = 3;
            verticalDensitySlider.Value = 3;
            verticalDensitySlider.ValueChanged += verticalDensityScrollBar_ValueChanged;
            // 
            // horizontalDensitySlider
            // 
            horizontalDensitySlider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            horizontalDensitySlider.Location = new Point(3, 40);
            horizontalDensitySlider.Maximum = 51;
            horizontalDensitySlider.Minimum = 3;
            horizontalDensitySlider.Name = "horizontalDensitySlider";
            horizontalDensitySlider.Size = new Size(270, 45);
            horizontalDensitySlider.TabIndex = 4;
            horizontalDensitySlider.TickFrequency = 3;
            horizontalDensitySlider.Value = 3;
            horizontalDensitySlider.ValueChanged += horizontalDensityScrollBar_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 88);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 3;
            label2.Text = "Vertical density";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 25);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 2;
            label1.Text = "Horizontal density";
            // 
            // normalMapGroupBox
            // 
            normalMapGroupBox.Controls.Add(panel17);
            normalMapGroupBox.Controls.Add(panel16);
            normalMapGroupBox.Controls.Add(panel15);
            normalMapGroupBox.Controls.Add(panelWithNormalMapCheckBox);
            normalMapGroupBox.Location = new Point(285, 297);
            normalMapGroupBox.Name = "normalMapGroupBox";
            normalMapGroupBox.Size = new Size(289, 262);
            normalMapGroupBox.TabIndex = 5;
            normalMapGroupBox.TabStop = false;
            normalMapGroupBox.Text = "Normal map";
            // 
            // panel17
            // 
            panel17.Controls.Add(zuchowskiRadioButton);
            panel17.Controls.Add(kotowskiRadioButton);
            panel17.Controls.Add(label6);
            panel17.Dock = DockStyle.Top;
            panel17.Location = new Point(3, 200);
            panel17.Name = "panel17";
            panel17.Padding = new Padding(6, 3, 6, 6);
            panel17.Size = new Size(283, 59);
            panel17.TabIndex = 11;
            // 
            // zuchowskiRadioButton
            // 
            zuchowskiRadioButton.AutoSize = true;
            zuchowskiRadioButton.Dock = DockStyle.Top;
            zuchowskiRadioButton.Location = new Point(6, 37);
            zuchowskiRadioButton.Name = "zuchowskiRadioButton";
            zuchowskiRadioButton.Size = new Size(271, 19);
            zuchowskiRadioButton.TabIndex = 2;
            zuchowskiRadioButton.TabStop = true;
            zuchowskiRadioButton.Text = "Żuchowski's approach";
            zuchowskiRadioButton.UseVisualStyleBackColor = true;
            zuchowskiRadioButton.Click += zuchowskiRadioButton_Click;
            // 
            // kotowskiRadioButton
            // 
            kotowskiRadioButton.AutoSize = true;
            kotowskiRadioButton.Dock = DockStyle.Top;
            kotowskiRadioButton.Location = new Point(6, 18);
            kotowskiRadioButton.Name = "kotowskiRadioButton";
            kotowskiRadioButton.Size = new Size(271, 19);
            kotowskiRadioButton.TabIndex = 1;
            kotowskiRadioButton.TabStop = true;
            kotowskiRadioButton.Text = "dr Kotowski's approach";
            kotowskiRadioButton.UseVisualStyleBackColor = true;
            kotowskiRadioButton.Click += kotowskiRadioButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Top;
            label6.Location = new Point(6, 3);
            label6.Name = "label6";
            label6.Size = new Size(162, 15);
            label6.TabIndex = 0;
            label6.Text = "Calculating bitangent vectors";
            // 
            // panel16
            // 
            panel16.Controls.Add(replaceNormalVectorsRadioButton);
            panel16.Controls.Add(addNormalVectorsRadioButton);
            panel16.Controls.Add(label4);
            panel16.Dock = DockStyle.Top;
            panel16.Location = new Point(3, 140);
            panel16.Name = "panel16";
            panel16.Padding = new Padding(6, 3, 6, 6);
            panel16.Size = new Size(283, 60);
            panel16.TabIndex = 10;
            // 
            // replaceNormalVectorsRadioButton
            // 
            replaceNormalVectorsRadioButton.AutoSize = true;
            replaceNormalVectorsRadioButton.Dock = DockStyle.Top;
            replaceNormalVectorsRadioButton.Location = new Point(6, 37);
            replaceNormalVectorsRadioButton.Name = "replaceNormalVectorsRadioButton";
            replaceNormalVectorsRadioButton.Size = new Size(271, 19);
            replaceNormalVectorsRadioButton.TabIndex = 4;
            replaceNormalVectorsRadioButton.Text = "Replace surface vectors";
            replaceNormalVectorsRadioButton.UseVisualStyleBackColor = true;
            replaceNormalVectorsRadioButton.CheckedChanged += replaceNormalVectorsRadioButton_CheckedChanged;
            // 
            // addNormalVectorsRadioButton
            // 
            addNormalVectorsRadioButton.AutoSize = true;
            addNormalVectorsRadioButton.Dock = DockStyle.Top;
            addNormalVectorsRadioButton.Location = new Point(6, 18);
            addNormalVectorsRadioButton.Name = "addNormalVectorsRadioButton";
            addNormalVectorsRadioButton.Size = new Size(271, 19);
            addNormalVectorsRadioButton.TabIndex = 3;
            addNormalVectorsRadioButton.TabStop = true;
            addNormalVectorsRadioButton.Text = "Add surface vectors";
            addNormalVectorsRadioButton.UseVisualStyleBackColor = true;
            addNormalVectorsRadioButton.CheckedChanged += addNormalVectorsRadioButton_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(6, 3);
            label4.Name = "label4";
            label4.Size = new Size(137, 15);
            label4.TabIndex = 0;
            label4.Text = "Mapping normal vectors";
            // 
            // panel15
            // 
            panel15.Controls.Add(normalMapStandardCheckBox);
            panel15.Dock = DockStyle.Top;
            panel15.Location = new Point(3, 115);
            panel15.Name = "panel15";
            panel15.Size = new Size(283, 25);
            panel15.TabIndex = 9;
            // 
            // normalMapStandardCheckBox
            // 
            normalMapStandardCheckBox.AutoSize = true;
            normalMapStandardCheckBox.Dock = DockStyle.Fill;
            normalMapStandardCheckBox.Location = new Point(0, 0);
            normalMapStandardCheckBox.Name = "normalMapStandardCheckBox";
            normalMapStandardCheckBox.Padding = new Padding(7, 0, 7, 0);
            normalMapStandardCheckBox.Size = new Size(283, 25);
            normalMapStandardCheckBox.TabIndex = 2;
            normalMapStandardCheckBox.Text = "Invert normal map Y coordinates";
            normalMapStandardCheckBox.UseVisualStyleBackColor = true;
            normalMapStandardCheckBox.CheckedChanged += normalMapStandardCheckBox_CheckedChanged;
            // 
            // panelWithNormalMapCheckBox
            // 
            panelWithNormalMapCheckBox.Controls.Add(panel11);
            panelWithNormalMapCheckBox.Controls.Add(panel10);
            panelWithNormalMapCheckBox.Dock = DockStyle.Top;
            panelWithNormalMapCheckBox.Location = new Point(3, 19);
            panelWithNormalMapCheckBox.Name = "panelWithNormalMapCheckBox";
            panelWithNormalMapCheckBox.Size = new Size(283, 96);
            panelWithNormalMapCheckBox.TabIndex = 5;
            // 
            // panel11
            // 
            panel11.Controls.Add(normalMapComboBox);
            panel11.Controls.Add(normalMapFileButton);
            panel11.Controls.Add(normalMapCheckBox);
            panel11.Dock = DockStyle.Left;
            panel11.Location = new Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(161, 96);
            panel11.TabIndex = 14;
            // 
            // normalMapComboBox
            // 
            normalMapComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            normalMapComboBox.FormattingEnabled = true;
            normalMapComboBox.Location = new Point(28, 35);
            normalMapComboBox.Name = "normalMapComboBox";
            normalMapComboBox.Size = new Size(132, 23);
            normalMapComboBox.TabIndex = 1;
            normalMapComboBox.SelectedIndexChanged += normalMapComboBox_SelectedIndexChanged;
            // 
            // normalMapFileButton
            // 
            normalMapFileButton.Location = new Point(27, 65);
            normalMapFileButton.Name = "normalMapFileButton";
            normalMapFileButton.Size = new Size(134, 25);
            normalMapFileButton.TabIndex = 0;
            normalMapFileButton.Text = "Choose file";
            normalMapFileButton.UseVisualStyleBackColor = true;
            normalMapFileButton.Click += normalMapButton_Click;
            // 
            // normalMapCheckBox
            // 
            normalMapCheckBox.AutoSize = true;
            normalMapCheckBox.Dock = DockStyle.Top;
            normalMapCheckBox.Location = new Point(0, 0);
            normalMapCheckBox.Name = "normalMapCheckBox";
            normalMapCheckBox.Padding = new Padding(7, 8, 0, 0);
            normalMapCheckBox.Size = new Size(161, 27);
            normalMapCheckBox.TabIndex = 3;
            normalMapCheckBox.Text = "Use normal map";
            normalMapCheckBox.UseVisualStyleBackColor = true;
            normalMapCheckBox.CheckedChanged += normalMapCheckBox_CheckedChanged;
            // 
            // panel10
            // 
            panel10.Controls.Add(normalMapPictureBox);
            panel10.Dock = DockStyle.Right;
            panel10.Location = new Point(174, 0);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(4);
            panel10.Size = new Size(109, 96);
            panel10.TabIndex = 13;
            // 
            // normalMapPictureBox
            // 
            normalMapPictureBox.BorderStyle = BorderStyle.FixedSingle;
            normalMapPictureBox.Location = new Point(7, 6);
            normalMapPictureBox.MaximumSize = new Size(90, 90);
            normalMapPictureBox.Name = "normalMapPictureBox";
            normalMapPictureBox.Size = new Size(84, 84);
            normalMapPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            normalMapPictureBox.TabIndex = 1;
            normalMapPictureBox.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lightColorButton);
            groupBox2.Location = new Point(6, 503);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(40, 6, 40, 6);
            groupBox2.Size = new Size(276, 53);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Light color";
            // 
            // lightColorButton
            // 
            lightColorButton.Dock = DockStyle.Fill;
            lightColorButton.Location = new Point(40, 22);
            lightColorButton.Name = "lightColorButton";
            lightColorButton.Size = new Size(196, 25);
            lightColorButton.TabIndex = 0;
            lightColorButton.Text = "Pick color";
            lightColorButton.UseVisualStyleBackColor = true;
            lightColorButton.Click += lightColorButton_Click;
            // 
            // PointHeightBox
            // 
            PointHeightBox.Controls.Add(resetSurfaceButton);
            PointHeightBox.Controls.Add(pointHeightSlider);
            PointHeightBox.Controls.Add(ctrlPointZLabel);
            PointHeightBox.Controls.Add(label7);
            PointHeightBox.Controls.Add(ctrlPointYLabel);
            PointHeightBox.Controls.Add(label5);
            PointHeightBox.Controls.Add(ctrlPointXLabel);
            PointHeightBox.Controls.Add(label3);
            PointHeightBox.Controls.Add(sphereCheckBox);
            PointHeightBox.Location = new Point(6, 3);
            PointHeightBox.Name = "PointHeightBox";
            PointHeightBox.Size = new Size(276, 142);
            PointHeightBox.TabIndex = 1;
            PointHeightBox.TabStop = false;
            PointHeightBox.Text = "Control point height";
            // 
            // resetSurfaceButton
            // 
            resetSurfaceButton.Location = new Point(161, 22);
            resetSurfaceButton.Name = "resetSurfaceButton";
            resetSurfaceButton.Size = new Size(100, 23);
            resetSurfaceButton.TabIndex = 7;
            resetSurfaceButton.Text = "Reset surface";
            resetSurfaceButton.UseVisualStyleBackColor = true;
            resetSurfaceButton.Click += resetSurfaceButton_Click;
            // 
            // pointHeightSlider
            // 
            pointHeightSlider.Dock = DockStyle.Bottom;
            pointHeightSlider.Location = new Point(3, 75);
            pointHeightSlider.Maximum = 100;
            pointHeightSlider.Minimum = -100;
            pointHeightSlider.Name = "pointHeightSlider";
            pointHeightSlider.Size = new Size(270, 45);
            pointHeightSlider.TabIndex = 6;
            pointHeightSlider.TickFrequency = 10;
            pointHeightSlider.ValueChanged += pointHeightScrollBar_ValueChanged;
            // 
            // ctrlPointZLabel
            // 
            ctrlPointZLabel.AutoSize = true;
            ctrlPointZLabel.Location = new Point(29, 49);
            ctrlPointZLabel.Name = "ctrlPointZLabel";
            ctrlPointZLabel.Size = new Size(0, 15);
            ctrlPointZLabel.TabIndex = 5;
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
            // ctrlPointYLabel
            // 
            ctrlPointYLabel.AutoSize = true;
            ctrlPointYLabel.Location = new Point(29, 34);
            ctrlPointYLabel.Name = "ctrlPointYLabel";
            ctrlPointYLabel.Size = new Size(0, 15);
            ctrlPointYLabel.TabIndex = 3;
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
            // ctrlPointXLabel
            // 
            ctrlPointXLabel.AutoSize = true;
            ctrlPointXLabel.Location = new Point(29, 19);
            ctrlPointXLabel.Name = "ctrlPointXLabel";
            ctrlPointXLabel.Size = new Size(0, 15);
            ctrlPointXLabel.TabIndex = 1;
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
            // sphereCheckBox
            // 
            sphereCheckBox.AutoSize = true;
            sphereCheckBox.Dock = DockStyle.Bottom;
            sphereCheckBox.Location = new Point(3, 120);
            sphereCheckBox.Name = "sphereCheckBox";
            sphereCheckBox.Size = new Size(270, 19);
            sphereCheckBox.TabIndex = 8;
            sphereCheckBox.Text = "Sphere";
            sphereCheckBox.UseVisualStyleBackColor = true;
            sphereCheckBox.CheckedChanged += sphereCheckBox_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel4);
            groupBox1.Controls.Add(panel5);
            groupBox1.Controls.Add(panel6);
            groupBox1.Location = new Point(285, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 9, 3, 3);
            groupBox1.Size = new Size(289, 142);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Light reflection parameters";
            // 
            // panel4
            // 
            panel4.Controls.Add(mSlider);
            panel4.Controls.Add(label9);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(3, 100);
            panel4.Name = "panel4";
            panel4.Size = new Size(283, 39);
            panel4.TabIndex = 13;
            // 
            // mSlider
            // 
            mSlider.Dock = DockStyle.Right;
            mSlider.Location = new Point(74, 0);
            mSlider.Maximum = 100;
            mSlider.Minimum = 1;
            mSlider.Name = "mSlider";
            mSlider.Size = new Size(209, 39);
            mSlider.TabIndex = 2;
            mSlider.TickFrequency = 10;
            mSlider.Value = 1;
            mSlider.ValueChanged += mSlider_ValueChanged;
            // 
            // label9
            // 
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(0, 0);
            label9.Margin = new Padding(7, 0, 7, 0);
            label9.Name = "label9";
            label9.Padding = new Padding(5, 0, 0, 15);
            label9.Size = new Size(283, 39);
            label9.TabIndex = 3;
            label9.Text = "Shininess";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            panel5.Controls.Add(kSSlider);
            panel5.Controls.Add(label10);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(3, 62);
            panel5.Name = "panel5";
            panel5.Size = new Size(283, 38);
            panel5.TabIndex = 12;
            // 
            // kSSlider
            // 
            kSSlider.Dock = DockStyle.Right;
            kSSlider.Location = new Point(74, 0);
            kSSlider.Maximum = 100;
            kSSlider.Name = "kSSlider";
            kSSlider.Size = new Size(209, 38);
            kSSlider.TabIndex = 1;
            kSSlider.TickFrequency = 10;
            kSSlider.ValueChanged += kSSlider_ValueChanged;
            // 
            // label10
            // 
            label10.Dock = DockStyle.Fill;
            label10.Location = new Point(0, 0);
            label10.Margin = new Padding(7, 0, 7, 0);
            label10.Name = "label10";
            label10.Padding = new Padding(5, 0, 0, 15);
            label10.Size = new Size(283, 38);
            label10.TabIndex = 3;
            label10.Text = "Specular";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            panel6.Controls.Add(kDSlider);
            panel6.Controls.Add(label11);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(3, 25);
            panel6.Name = "panel6";
            panel6.Size = new Size(283, 37);
            panel6.TabIndex = 11;
            // 
            // kDSlider
            // 
            kDSlider.Dock = DockStyle.Right;
            kDSlider.Location = new Point(74, 0);
            kDSlider.Maximum = 100;
            kDSlider.Name = "kDSlider";
            kDSlider.Size = new Size(209, 37);
            kDSlider.TabIndex = 0;
            kDSlider.TickFrequency = 10;
            kDSlider.ValueChanged += kDSlider_ValueChanged;
            // 
            // label11
            // 
            label11.Dock = DockStyle.Fill;
            label11.Location = new Point(0, 0);
            label11.Margin = new Padding(7, 0, 7, 0);
            label11.Name = "label11";
            label11.Padding = new Padding(5, 0, 0, 15);
            label11.Size = new Size(283, 37);
            label11.TabIndex = 2;
            label11.Text = "Diffuse";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // colorDialog
            // 
            colorDialog.FullOpen = true;
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
            ClientSize = new Size(1252, 582);
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
            panel18.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lightZSlider).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lightYSlider).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)lightXSlider).EndInit();
            groupBox4.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)texturePictureBox).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            triangleDensityGroupBox.ResumeLayout(false);
            triangleDensityGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)verticalDensitySlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)horizontalDensitySlider).EndInit();
            normalMapGroupBox.ResumeLayout(false);
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            panelWithNormalMapCheckBox.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)normalMapPictureBox).EndInit();
            groupBox2.ResumeLayout(false);
            PointHeightBox.ResumeLayout(false);
            PointHeightBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pointHeightSlider).EndInit();
            groupBox1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mSlider).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)kSSlider).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)kDSlider).EndInit();
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
        private Label ctrlPointZLabel;
        private Label label7;
        private Label ctrlPointYLabel;
        private Label label5;
        private Label ctrlPointXLabel;
        private Label verticalDensityLabel;
        private Label horizontalDensityLabel;
        private GroupBox groupBox1;
        private GroupBox lightSrcGroupBox;
        private TrackBar lightZSlider;
        private TrackBar lightYSlider;
        private TrackBar lightXSlider;
        private CheckBox animationCheckBox;
        private TrackBar kSSlider;
        private TrackBar kDSlider;
        private TrackBar mSlider;
        private Button lightColorButton;
        private ColorDialog colorDialog;
        private GroupBox normalMapGroupBox;
        private CheckBox normalVectorsCheckbox;
        private CheckBox triangleGridCheckbox;
        private Button normalMapFileButton;
        private OpenFileDialog chooseFileDialog;
        private GroupBox groupBox4;
        private Button objectColorButton;
        private System.Windows.Forms.Timer animationTimer;
        private Button textureFileButton;
        private ComboBox normalMapComboBox;
        private ComboBox textureComboBox;
        private RadioButton replaceNormalVectorsRadioButton;
        private RadioButton addNormalVectorsRadioButton;
        private CheckBox normalMapStandardCheckBox;
        private Panel panel1;
        private Label lightXLabel;
        private Panel panel2;
        private Label lightYLabel;
        private Panel panel3;
        private Label lightZLabel;
        private Panel panel4;
        private Label label9;
        private Panel panel5;
        private Label label10;
        private Panel panel6;
        private Label label11;
        private GroupBox groupBox2;
        private Panel panel7;
        private Panel panel8;
        private RadioButton objColorRadioButton;
        private Panel panel9;
        private RadioButton textureRadioButton;
        private Panel panelWithNormalMapCheckBox;
        private CheckBox normalMapCheckBox;
        private Button resetSurfaceButton;
        private Panel panel17;
        private RadioButton zuchowskiRadioButton;
        private RadioButton kotowskiRadioButton;
        private Label label6;
        private Panel panel16;
        private Label label4;
        private Panel panel15;
        private Panel panel18;
        private Button resetLightPosButton;
        private PictureBox texturePictureBox;
        private Panel panel19;
        private Panel panel11;
        private Panel panel10;
        private PictureBox normalMapPictureBox;
        private CheckBox sphereCheckBox;
    }
}