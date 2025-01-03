﻿namespace PeteTech
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btn27K = new Button();
            btn3074 = new Button();
            chkAutoBuffer = new CheckBox();
            chkSounds = new CheckBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnAFK = new Button();
            btnDC = new Button();
            lbl3074Status = new Label();
            lbl27Status = new Label();
            cbo3074 = new ComboBox();
            cmbo27k = new ComboBox();
            lblFPS = new Label();
            label4 = new Label();
            tbFpsBar = new TrackBar();
            btnSolo = new Button();
            txtFBHK = new TextBox();
            lblFusion = new Label();
            txt27HK = new TextBox();
            txt3074HK = new TextBox();
            txtPauseHotKey = new TextBox();
            label3 = new Label();
            txtPboxHotKey = new TextBox();
            label2 = new Label();
            tabPage3 = new TabPage();
            txtPboxMessage = new TextBox();
            label5 = new Label();
            tabPage4 = new TabPage();
            lblSoloTrack = new Label();
            lblDCtrack = new Label();
            lblFBTrack = new Label();
            lblFullPause = new Label();
            lblPboxTrack = new Label();
            lbl27kTrack = new Label();
            label14 = new Label();
            lbl3074Track = new Label();
            lblDateTrack = new Label();
            label13 = new Label();
            btnStartTracking = new Button();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            tabPage2 = new TabPage();
            label1 = new Label();
            tabPage5 = new TabPage();
            btnTheme = new Button();
            btnColor = new Button();
            btnChangeFont = new Button();
            label15 = new Label();
            trcTrans = new TrackBar();
            tabPage6 = new TabPage();
            txtMulti = new TextBox();
            lblMulti = new Label();
            toolTip1 = new ToolTip(components);
            fontDialog1 = new FontDialog();
            pageSetupDialog1 = new PageSetupDialog();
            colorDialog1 = new ColorDialog();
            colorDialog2 = new ColorDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbFpsBar).BeginInit();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trcTrans).BeginInit();
            tabPage6.SuspendLayout();
            SuspendLayout();
            // 
            // btn27K
            // 
            btn27K.FlatStyle = FlatStyle.Popup;
            btn27K.ImageKey = "(none)";
            btn27K.Location = new Point(76, 2);
            btn27K.Margin = new Padding(3, 2, 3, 2);
            btn27K.Name = "btn27K";
            btn27K.Size = new Size(109, 24);
            btn27K.TabIndex = 0;
            btn27K.Text = "27k";
            toolTip1.SetToolTip(btn27K, "limits ports 27k");
            btn27K.UseVisualStyleBackColor = true;
            btn27K.Click += btn27K_Click;
            // 
            // btn3074
            // 
            btn3074.AutoSize = true;
            btn3074.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            btn3074.FlatStyle = FlatStyle.Popup;
            btn3074.ForeColor = SystemColors.ActiveCaptionText;
            btn3074.Location = new Point(76, 30);
            btn3074.Margin = new Padding(3, 2, 3, 2);
            btn3074.Name = "btn3074";
            btn3074.Size = new Size(109, 26);
            btn3074.TabIndex = 1;
            btn3074.Text = "3074";
            toolTip1.SetToolTip(btn3074, "Limits 3074: Can be used to Unload Doors");
            btn3074.UseVisualStyleBackColor = true;
            btn3074.Click += btn3074_Click;
            // 
            // chkAutoBuffer
            // 
            chkAutoBuffer.Appearance = Appearance.Button;
            chkAutoBuffer.AutoSize = true;
            chkAutoBuffer.Location = new Point(3, 60);
            chkAutoBuffer.Margin = new Padding(3, 2, 3, 2);
            chkAutoBuffer.Name = "chkAutoBuffer";
            chkAutoBuffer.Size = new Size(78, 26);
            chkAutoBuffer.TabIndex = 2;
            chkAutoBuffer.Text = "Auto Buffer";
            toolTip1.SetToolTip(chkAutoBuffer, "Buffers the limit held");
            chkAutoBuffer.UseVisualStyleBackColor = true;
            chkAutoBuffer.CheckedChanged += chkAutoBuffer_CheckedChanged;
            // 
            // chkSounds
            // 
            chkSounds.Appearance = Appearance.Button;
            chkSounds.BackColor = Color.Transparent;
            chkSounds.FlatAppearance.BorderColor = Color.Red;
            chkSounds.Location = new Point(87, 60);
            chkSounds.Margin = new Padding(3, 2, 3, 2);
            chkSounds.Name = "chkSounds";
            chkSounds.Size = new Size(55, 26);
            chkSounds.TabIndex = 3;
            chkSounds.Text = "Sounds";
            toolTip1.SetToolTip(chkSounds, "Turns sound on to let you know if you are limiting");
            chkSounds.UseVisualStyleBackColor = false;
            chkSounds.CheckedChanged += chkSounds_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(700, 338);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.BackgroundImage = (Image)resources.GetObject("tabPage1.BackgroundImage");
            tabPage1.BackgroundImageLayout = ImageLayout.Zoom;
            tabPage1.BorderStyle = BorderStyle.FixedSingle;
            tabPage1.Controls.Add(btnAFK);
            tabPage1.Controls.Add(btnDC);
            tabPage1.Controls.Add(lbl3074Status);
            tabPage1.Controls.Add(lbl27Status);
            tabPage1.Controls.Add(cbo3074);
            tabPage1.Controls.Add(cmbo27k);
            tabPage1.Controls.Add(lblFPS);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(tbFpsBar);
            tabPage1.Controls.Add(btnSolo);
            tabPage1.Controls.Add(txtFBHK);
            tabPage1.Controls.Add(lblFusion);
            tabPage1.Controls.Add(txt27HK);
            tabPage1.Controls.Add(txt3074HK);
            tabPage1.Controls.Add(txtPauseHotKey);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtPboxHotKey);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(btn3074);
            tabPage1.Controls.Add(chkSounds);
            tabPage1.Controls.Add(btn27K);
            tabPage1.Controls.Add(chkAutoBuffer);
            tabPage1.Font = new Font("Microsoft YaHei", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage1.ForeColor = Color.FromArgb(32, 32, 32);
            tabPage1.ImageKey = "(none)";
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(692, 310);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Home";
            // 
            // btnAFK
            // 
            btnAFK.Location = new Point(158, 225);
            btnAFK.Name = "btnAFK";
            btnAFK.Size = new Size(75, 25);
            btnAFK.TabIndex = 21;
            btnAFK.Text = "AFK";
            btnAFK.UseVisualStyleBackColor = true;
            btnAFK.Click += btnAFK_Click;
            // 
            // btnDC
            // 
            btnDC.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDC.Location = new Point(82, 225);
            btnDC.Name = "btnDC";
            btnDC.Size = new Size(70, 26);
            btnDC.TabIndex = 20;
            btnDC.Text = "DC";
            toolTip1.SetToolTip(btnDC, "Spawn on Fireteam Leader (Doesnt Work In Patrol)");
            btnDC.UseVisualStyleBackColor = true;
            btnDC.Click += btnDC_Click;
            // 
            // lbl3074Status
            // 
            lbl3074Status.AutoSize = true;
            lbl3074Status.Location = new Point(215, 35);
            lbl3074Status.Name = "lbl3074Status";
            lbl3074Status.Size = new Size(28, 16);
            lbl3074Status.TabIndex = 19;
            lbl3074Status.Text = "OFF";
            // 
            // lbl27Status
            // 
            lbl27Status.AutoSize = true;
            lbl27Status.Location = new Point(215, 6);
            lbl27Status.Name = "lbl27Status";
            lbl27Status.Size = new Size(28, 16);
            lbl27Status.TabIndex = 18;
            lbl27Status.Text = "OFF";
            // 
            // cbo3074
            // 
            cbo3074.AutoCompleteCustomSource.AddRange(new string[] { "in/out", "in", "out" });
            cbo3074.FormattingEnabled = true;
            cbo3074.Items.AddRange(new object[] { "in/out", "in", "out" });
            cbo3074.Location = new Point(3, 32);
            cbo3074.Name = "cbo3074";
            cbo3074.Size = new Size(67, 24);
            cbo3074.TabIndex = 17;
            toolTip1.SetToolTip(cbo3074, "Select Option");
            cbo3074.SelectedIndexChanged += cbo3074_SelectedIndexChanged;
            // 
            // cmbo27k
            // 
            cmbo27k.AutoCompleteCustomSource.AddRange(new string[] { "in/out", "in", "out" });
            cmbo27k.FormattingEnabled = true;
            cmbo27k.Items.AddRange(new object[] { "in/out", "in", "out" });
            cmbo27k.Location = new Point(3, 2);
            cmbo27k.Name = "cmbo27k";
            cmbo27k.Size = new Size(67, 24);
            cmbo27k.TabIndex = 16;
            toolTip1.SetToolTip(cmbo27k, "Select Option");
            cmbo27k.SelectedIndexChanged += cmbo27k_SelectedIndexChanged;
            // 
            // lblFPS
            // 
            lblFPS.AutoSize = true;
            lblFPS.Location = new Point(397, 152);
            lblFPS.Name = "lblFPS";
            lblFPS.Size = new Size(38, 16);
            lblFPS.TabIndex = 15;
            lblFPS.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(362, 152);
            label4.Name = "label4";
            label4.Size = new Size(29, 16);
            label4.TabIndex = 14;
            label4.Text = "FPS:";
            label4.Click += label4_Click;
            // 
            // tbFpsBar
            // 
            tbFpsBar.AutoSize = false;
            tbFpsBar.BackColor = SystemColors.MenuBar;
            tbFpsBar.Location = new Point(3, 143);
            tbFpsBar.Maximum = 255;
            tbFpsBar.Minimum = 30;
            tbFpsBar.Name = "tbFpsBar";
            tbFpsBar.Size = new Size(353, 45);
            tbFpsBar.TabIndex = 13;
            tbFpsBar.TickStyle = TickStyle.Both;
            toolTip1.SetToolTip(tbFpsBar, "Enter your FPS: Allows for Pbox to work");
            tbFpsBar.Value = 30;
            tbFpsBar.Scroll += tbFpsBar_Scroll;
            // 
            // btnSolo
            // 
            btnSolo.AutoSize = true;
            btnSolo.Location = new Point(3, 225);
            btnSolo.Name = "btnSolo";
            btnSolo.Size = new Size(73, 26);
            btnSolo.TabIndex = 12;
            btnSolo.Text = "Solo Script";
            toolTip1.SetToolTip(btnSolo, "Click for solo match making while in orbit.");
            btnSolo.UseVisualStyleBackColor = true;
            btnSolo.Click += btnSolo_Click;
            // 
            // txtFBHK
            // 
            txtFBHK.Location = new Point(90, 194);
            txtFBHK.MaxLength = 1;
            txtFBHK.Name = "txtFBHK";
            txtFBHK.Size = new Size(29, 22);
            txtFBHK.TabIndex = 11;
            toolTip1.SetToolTip(txtFBHK, "Keybind box for Fuision Breach: Equip Fusion Nades");
            // 
            // lblFusion
            // 
            lblFusion.AutoSize = true;
            lblFusion.Location = new Point(3, 197);
            lblFusion.Name = "lblFusion";
            lblFusion.Size = new Size(81, 16);
            lblFusion.TabIndex = 10;
            lblFusion.Text = "Fusion Breach";
            // 
            // txt27HK
            // 
            txt27HK.Location = new Point(188, 3);
            txt27HK.MaxLength = 1;
            txt27HK.Name = "txt27HK";
            txt27HK.Size = new Size(21, 22);
            txt27HK.TabIndex = 9;
            toolTip1.SetToolTip(txt27HK, "Keybind For 27K");
            // 
            // txt3074HK
            // 
            txt3074HK.Location = new Point(188, 32);
            txt3074HK.MaxLength = 1;
            txt3074HK.Name = "txt3074HK";
            txt3074HK.Size = new Size(21, 22);
            txt3074HK.TabIndex = 8;
            toolTip1.SetToolTip(txt3074HK, "Keybind for 3074");
            // 
            // txtPauseHotKey
            // 
            txtPauseHotKey.Location = new Point(41, 87);
            txtPauseHotKey.MaxLength = 1;
            txtPauseHotKey.Name = "txtPauseHotKey";
            txtPauseHotKey.Size = new Size(29, 22);
            txtPauseHotKey.TabIndex = 7;
            toolTip1.SetToolTip(txtPauseHotKey, "Keybind box for Pause");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 90);
            label3.Name = "label3";
            label3.Size = new Size(38, 16);
            label3.TabIndex = 6;
            label3.Text = "Pause";
            // 
            // txtPboxHotKey
            // 
            txtPboxHotKey.BackColor = SystemColors.HighlightText;
            txtPboxHotKey.ForeColor = SystemColors.WindowText;
            txtPboxHotKey.HideSelection = false;
            txtPboxHotKey.Location = new Point(41, 115);
            txtPboxHotKey.MaxLength = 1;
            txtPboxHotKey.Name = "txtPboxHotKey";
            txtPboxHotKey.Size = new Size(29, 22);
            txtPboxHotKey.TabIndex = 5;
            toolTip1.SetToolTip(txtPboxHotKey, "Keybind box for Pbox");
            txtPboxHotKey.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 118);
            label2.Name = "label2";
            label2.Size = new Size(34, 16);
            label2.TabIndex = 4;
            label2.Text = "Pbox";
            label2.Click += label2_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(txtPboxMessage);
            tabPage3.Controls.Add(label5);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(692, 310);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Settings";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtPboxMessage
            // 
            txtPboxMessage.Location = new Point(97, 6);
            txtPboxMessage.Name = "txtPboxMessage";
            txtPboxMessage.Size = new Size(587, 23);
            txtPboxMessage.TabIndex = 1;
            toolTip1.SetToolTip(txtPboxMessage, "Message that is typed in chat when Pbox is hit: Will cause a delay");
            txtPboxMessage.TextChanged += txtPboxMessage_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 9);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 0;
            label5.Text = "Pbox Message";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(lblSoloTrack);
            tabPage4.Controls.Add(lblDCtrack);
            tabPage4.Controls.Add(lblFBTrack);
            tabPage4.Controls.Add(lblFullPause);
            tabPage4.Controls.Add(lblPboxTrack);
            tabPage4.Controls.Add(lbl27kTrack);
            tabPage4.Controls.Add(label14);
            tabPage4.Controls.Add(lbl3074Track);
            tabPage4.Controls.Add(lblDateTrack);
            tabPage4.Controls.Add(label13);
            tabPage4.Controls.Add(btnStartTracking);
            tabPage4.Controls.Add(label12);
            tabPage4.Controls.Add(label11);
            tabPage4.Controls.Add(label10);
            tabPage4.Controls.Add(label9);
            tabPage4.Controls.Add(label8);
            tabPage4.Controls.Add(label7);
            tabPage4.Controls.Add(label6);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(692, 310);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Stats";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // lblSoloTrack
            // 
            lblSoloTrack.AutoEllipsis = true;
            lblSoloTrack.AutoSize = true;
            lblSoloTrack.Location = new Point(141, 163);
            lblSoloTrack.Name = "lblSoloTrack";
            lblSoloTrack.Size = new Size(57, 15);
            lblSoloTrack.TabIndex = 17;
            lblSoloTrack.Text = "SoloTrack";
            // 
            // lblDCtrack
            // 
            lblDCtrack.AutoEllipsis = true;
            lblDCtrack.AutoSize = true;
            lblDCtrack.Location = new Point(91, 148);
            lblDCtrack.Name = "lblDCtrack";
            lblDCtrack.Size = new Size(23, 15);
            lblDCtrack.TabIndex = 16;
            lblDCtrack.Text = "DC";
            // 
            // lblFBTrack
            // 
            lblFBTrack.AutoEllipsis = true;
            lblFBTrack.AutoSize = true;
            lblFBTrack.Location = new Point(261, 133);
            lblFBTrack.Name = "lblFBTrack";
            lblFBTrack.Size = new Size(79, 15);
            lblFBTrack.TabIndex = 15;
            lblFBTrack.Text = "fusion breach";
            // 
            // lblFullPause
            // 
            lblFullPause.AutoEllipsis = true;
            lblFullPause.AutoSize = true;
            lblFullPause.Location = new Point(276, 118);
            lblFullPause.Name = "lblFullPause";
            lblFullPause.Size = new Size(57, 15);
            lblFullPause.TabIndex = 14;
            lblFullPause.Text = "FullPause";
            // 
            // lblPboxTrack
            // 
            lblPboxTrack.AutoEllipsis = true;
            lblPboxTrack.AutoSize = true;
            lblPboxTrack.Location = new Point(209, 103);
            lblPboxTrack.Name = "lblPboxTrack";
            lblPboxTrack.Size = new Size(61, 15);
            lblPboxTrack.TabIndex = 13;
            lblPboxTrack.Text = "PboxTrack";
            // 
            // lbl27kTrack
            // 
            lbl27kTrack.AutoEllipsis = true;
            lbl27kTrack.AutoSize = true;
            lbl27kTrack.Location = new Point(110, 66);
            lbl27kTrack.Name = "lbl27kTrack";
            lbl27kTrack.Size = new Size(52, 15);
            lbl27kTrack.TabIndex = 12;
            lbl27kTrack.Text = "27kTrack";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(110, 66);
            label14.Name = "label14";
            label14.Size = new Size(0, 15);
            label14.TabIndex = 11;
            // 
            // lbl3074Track
            // 
            lbl3074Track.AutoEllipsis = true;
            lbl3074Track.AutoSize = true;
            lbl3074Track.Location = new Point(116, 51);
            lbl3074Track.Name = "lbl3074Track";
            lbl3074Track.Size = new Size(58, 15);
            lbl3074Track.TabIndex = 10;
            lbl3074Track.Text = "3074Track";
            // 
            // lblDateTrack
            // 
            lblDateTrack.AutoSize = true;
            lblDateTrack.Location = new Point(127, 0);
            lblDateTrack.Name = "lblDateTrack";
            lblDateTrack.Size = new Size(31, 15);
            lblDateTrack.TabIndex = 9;
            lblDateTrack.Text = "Date";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(0, 0);
            label13.Name = "label13";
            label13.Size = new Size(121, 15);
            label13.TabIndex = 8;
            label13.Text = "Date Started Tracking:";
            // 
            // btnStartTracking
            // 
            btnStartTracking.Location = new Point(585, 284);
            btnStartTracking.Name = "btnStartTracking";
            btnStartTracking.Size = new Size(99, 23);
            btnStartTracking.TabIndex = 7;
            btnStartTracking.Text = "Start Tracking";
            btnStartTracking.UseVisualStyleBackColor = true;
            btnStartTracking.Click += btnStartTracking_Click;
            // 
            // label12
            // 
            label12.AutoEllipsis = true;
            label12.AutoSize = true;
            label12.Location = new Point(3, 163);
            label12.Name = "label12";
            label12.Size = new Size(132, 15);
            label12.TabIndex = 6;
            label12.Text = "Number of Solo Scripts:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(3, 148);
            label11.Name = "label11";
            label11.Size = new Size(87, 15);
            label11.TabIndex = 5;
            label11.Text = "Number of DC:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 66);
            label10.Name = "label10";
            label10.Size = new Size(101, 15);
            label10.TabIndex = 4;
            label10.Text = "Time holding 27k:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 51);
            label9.Name = "label9";
            label9.Size = new Size(107, 15);
            label9.TabIndex = 3;
            label9.Text = "Time holding 3074:";
            // 
            // label8
            // 
            label8.AllowDrop = true;
            label8.AutoEllipsis = true;
            label8.AutoSize = true;
            label8.Location = new Point(3, 133);
            label8.Name = "label8";
            label8.Size = new Size(252, 15);
            label8.TabIndex = 2;
            label8.Text = "Number of times you have fusioned breached:";
            // 
            // label7
            // 
            label7.AutoEllipsis = true;
            label7.AutoSize = true;
            label7.Location = new Point(3, 118);
            label7.Name = "label7";
            label7.Size = new Size(271, 15);
            label7.TabIndex = 1;
            label7.Text = "Number of times you have fully paused the game:";
            // 
            // label6
            // 
            label6.AutoEllipsis = true;
            label6.AutoSize = true;
            label6.Location = new Point(3, 103);
            label6.Name = "label6";
            label6.Size = new Size(200, 15);
            label6.TabIndex = 0;
            label6.Text = "Number of times you have P boxed: ";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(692, 310);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Credits";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 10);
            label1.Name = "label1";
            label1.Size = new Size(1993, 15);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            toolTip1.SetToolTip(label1, "Noob Like Futa");
            label1.Click += label1_Click;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(btnTheme);
            tabPage5.Controls.Add(btnColor);
            tabPage5.Controls.Add(btnChangeFont);
            tabPage5.Controls.Add(label15);
            tabPage5.Controls.Add(trcTrans);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(692, 310);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Looks";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnTheme
            // 
            btnTheme.Location = new Point(171, 72);
            btnTheme.Name = "btnTheme";
            btnTheme.Size = new Size(75, 23);
            btnTheme.TabIndex = 4;
            btnTheme.Text = "Theme";
            toolTip1.SetToolTip(btnTheme, "Select the background color of the program");
            btnTheme.UseVisualStyleBackColor = true;
            btnTheme.Click += btnTheme_Click;
            // 
            // btnColor
            // 
            btnColor.Location = new Point(90, 72);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(75, 23);
            btnColor.TabIndex = 3;
            btnColor.Text = "Text Color";
            toolTip1.SetToolTip(btnColor, "Change Color of Text");
            btnColor.UseVisualStyleBackColor = true;
            btnColor.Click += btnColor_Click;
            // 
            // btnChangeFont
            // 
            btnChangeFont.Location = new Point(9, 72);
            btnChangeFont.Name = "btnChangeFont";
            btnChangeFont.Size = new Size(75, 23);
            btnChangeFont.TabIndex = 2;
            btnChangeFont.Text = "Font";
            toolTip1.SetToolTip(btnChangeFont, "Change the font of the program (Might need to adjust size of font )");
            btnChangeFont.UseVisualStyleBackColor = true;
            btnChangeFont.Click += btnChangeFont_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(9, 3);
            label15.Name = "label15";
            label15.Size = new Size(76, 15);
            label15.TabIndex = 1;
            label15.Text = "Transparency";
            // 
            // trcTrans
            // 
            trcTrans.Location = new Point(8, 21);
            trcTrans.Maximum = 100;
            trcTrans.Minimum = 20;
            trcTrans.Name = "trcTrans";
            trcTrans.Size = new Size(281, 45);
            trcTrans.TabIndex = 0;
            toolTip1.SetToolTip(trcTrans, "Change the Transparency of the Program");
            trcTrans.Value = 90;
            trcTrans.Scroll += trcTrans_Scroll;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(txtMulti);
            tabPage6.Controls.Add(lblMulti);
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(692, 310);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Scum";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // txtMulti
            // 
            txtMulti.Location = new Point(68, 135);
            txtMulti.MaxLength = 1;
            txtMulti.Name = "txtMulti";
            txtMulti.Size = new Size(25, 23);
            txtMulti.TabIndex = 1;
            // 
            // lblMulti
            // 
            lblMulti.AutoSize = true;
            lblMulti.Location = new Point(3, 138);
            lblMulti.Name = "lblMulti";
            lblMulti.Size = new Size(59, 15);
            lblMulti.TabIndex = 0;
            lblMulti.Text = "MultiShot";
            // 
            // pageSetupDialog1
            // 
            pageSetupDialog1.ShowHelp = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            BackColor = Color.FromArgb(32, 32, 32);
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(700, 338);
            Controls.Add(tabControl1);
            DoubleBuffered = true;
            ForeColor = SystemColors.ActiveCaptionText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Opacity = 0.9D;
            Text = "PeteTech";
            TopMost = true;
            TransparencyKey = Color.FromArgb(192, 255, 255);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbFpsBar).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trcTrans).EndInit();
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btn27K;
        private Button btn3074;
        private CheckBox chkAutoBuffer;
        private CheckBox chkSounds;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private Label label2;
        private TextBox txtPboxHotKey;
        private Label label3;
        private TextBox txtPauseHotKey;
        private TextBox txt27HK;
        private TextBox txt3074HK;
        private Button btnSolo;
        private TextBox txtFBHK;
        private Label lblFusion;
        private TrackBar tbFpsBar;
        private Label label4;
        private Label lblFPS;
        private ComboBox cbo3074;
        private ComboBox cmbo27k;
        private Label lbl3074Status;
        private Label lbl27Status;
        private TabPage tabPage3;
        private Label label5;
        private TextBox txtPboxMessage;
        private ToolTip toolTip1;
        private Button btnDC;
        private TabPage tabPage4;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label12;
        private Label label11;
        private Button btnStartTracking;
        private Label lblDCtrack;
        private Label lblFBTrack;
        private Label lblFullPause;
        private Label lblPboxTrack;
        private Label lbl27kTrack;
        private Label label14;
        private Label lbl3074Track;
        private Label lblDateTrack;
        private Label label13;
        private Label lblSoloTrack;
        private FontDialog fontDialog1;
        private PageSetupDialog pageSetupDialog1;
        private TabPage tabPage5;
        private Label label15;
        private TrackBar trcTrans;
        private Button btnColor;
        private Button btnChangeFont;
        private ColorDialog colorDialog1;
        private Button btnTheme;
        private ColorDialog colorDialog2;
        private TabPage tabPage6;
        private TextBox txtMulti;
        private Label lblMulti;
        private Button btnAFK;
    }
}
