namespace PeteTech
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btn27K = new Button();
            btn3074 = new Button();
            chkAutoBuffer = new CheckBox();
            chkSounds = new CheckBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
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
            tabPage2 = new TabPage();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbFpsBar).BeginInit();
            tabPage3.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // btn27K
            // 
            btn27K.Location = new Point(75, 2);
            btn27K.Margin = new Padding(3, 2, 3, 2);
            btn27K.Name = "btn27K";
            btn27K.Size = new Size(82, 22);
            btn27K.TabIndex = 0;
            btn27K.Text = "27k";
            btn27K.UseVisualStyleBackColor = true;
            btn27K.Click += btn27K_Click;
            // 
            // btn3074
            // 
            btn3074.Location = new Point(75, 31);
            btn3074.Margin = new Padding(3, 2, 3, 2);
            btn3074.Name = "btn3074";
            btn3074.Size = new Size(82, 22);
            btn3074.TabIndex = 1;
            btn3074.Text = "3074";
            btn3074.UseVisualStyleBackColor = true;
            btn3074.Click += btn3074_Click;
            // 
            // chkAutoBuffer
            // 
            chkAutoBuffer.AutoSize = true;
            chkAutoBuffer.Location = new Point(3, 56);
            chkAutoBuffer.Margin = new Padding(3, 2, 3, 2);
            chkAutoBuffer.Name = "chkAutoBuffer";
            chkAutoBuffer.Size = new Size(87, 19);
            chkAutoBuffer.TabIndex = 2;
            chkAutoBuffer.Text = "Auto Buffer";
            chkAutoBuffer.UseVisualStyleBackColor = true;
            chkAutoBuffer.CheckedChanged += chkAutoBuffer_CheckedChanged;
            // 
            // chkSounds
            // 
            chkSounds.AutoSize = true;
            chkSounds.Location = new Point(96, 56);
            chkSounds.Margin = new Padding(3, 2, 3, 2);
            chkSounds.Name = "chkSounds";
            chkSounds.Size = new Size(65, 19);
            chkSounds.TabIndex = 3;
            chkSounds.Text = "Sounds";
            chkSounds.UseVisualStyleBackColor = true;
            chkSounds.CheckedChanged += chkSounds_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage2);
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
            tabPage1.BackColor = Color.Transparent;
            tabPage1.BackgroundImage = (Image)resources.GetObject("tabPage1.BackgroundImage");
            tabPage1.BackgroundImageLayout = ImageLayout.Zoom;
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
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(692, 310);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Home";
            // 
            // lbl3074Status
            // 
            lbl3074Status.AutoSize = true;
            lbl3074Status.Location = new Point(192, 38);
            lbl3074Status.Name = "lbl3074Status";
            lbl3074Status.Size = new Size(38, 15);
            lbl3074Status.TabIndex = 19;
            lbl3074Status.Text = "label6";
            // 
            // lbl27Status
            // 
            lbl27Status.AutoSize = true;
            lbl27Status.Location = new Point(192, 11);
            lbl27Status.Name = "lbl27Status";
            lbl27Status.Size = new Size(38, 15);
            lbl27Status.TabIndex = 18;
            lbl27Status.Text = "label5";
            // 
            // cbo3074
            // 
            cbo3074.AutoCompleteCustomSource.AddRange(new string[] { "in/out", "in", "out" });
            cbo3074.FormattingEnabled = true;
            cbo3074.Items.AddRange(new object[] { "in/out", "in", "out" });
            cbo3074.Location = new Point(6, 29);
            cbo3074.Name = "cbo3074";
            cbo3074.Size = new Size(63, 23);
            cbo3074.TabIndex = 17;
            cbo3074.SelectedIndexChanged += cbo3074_SelectedIndexChanged;
            // 
            // cmbo27k
            // 
            cmbo27k.AutoCompleteCustomSource.AddRange(new string[] { "in/out", "in", "out" });
            cmbo27k.FormattingEnabled = true;
            cmbo27k.Items.AddRange(new object[] { "in/out", "in", "out" });
            cmbo27k.Location = new Point(6, 3);
            cmbo27k.Name = "cmbo27k";
            cmbo27k.Size = new Size(63, 23);
            cmbo27k.TabIndex = 16;
            cmbo27k.SelectedIndexChanged += cmbo27k_SelectedIndexChanged;
            // 
            // lblFPS
            // 
            lblFPS.AutoSize = true;
            lblFPS.Location = new Point(401, 142);
            lblFPS.Name = "lblFPS";
            lblFPS.Size = new Size(38, 15);
            lblFPS.TabIndex = 15;
            lblFPS.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(366, 142);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 14;
            label4.Text = "FPS:";
            label4.Click += label4_Click;
            // 
            // tbFpsBar
            // 
            tbFpsBar.BackColor = SystemColors.AppWorkspace;
            tbFpsBar.Location = new Point(6, 142);
            tbFpsBar.Maximum = 255;
            tbFpsBar.Minimum = 60;
            tbFpsBar.Name = "tbFpsBar";
            tbFpsBar.Size = new Size(354, 45);
            tbFpsBar.TabIndex = 13;
            tbFpsBar.Value = 60;
            tbFpsBar.Scroll += tbFpsBar_Scroll;
            // 
            // btnSolo
            // 
            btnSolo.Location = new Point(6, 224);
            btnSolo.Name = "btnSolo";
            btnSolo.Size = new Size(75, 22);
            btnSolo.TabIndex = 12;
            btnSolo.Text = "Solo Script";
            btnSolo.UseVisualStyleBackColor = true;
            btnSolo.Click += btnSolo_Click;
            // 
            // txtFBHK
            // 
            txtFBHK.Location = new Point(91, 193);
            txtFBHK.MaxLength = 1;
            txtFBHK.Name = "txtFBHK";
            txtFBHK.Size = new Size(21, 23);
            txtFBHK.TabIndex = 11;
            // 
            // lblFusion
            // 
            lblFusion.AutoSize = true;
            lblFusion.Location = new Point(6, 196);
            lblFusion.Name = "lblFusion";
            lblFusion.Size = new Size(81, 15);
            lblFusion.TabIndex = 10;
            lblFusion.Text = "Fusion Breach";
            // 
            // txt27HK
            // 
            txt27HK.Location = new Point(163, 3);
            txt27HK.MaxLength = 1;
            txt27HK.Name = "txt27HK";
            txt27HK.Size = new Size(23, 23);
            txt27HK.TabIndex = 9;
            // 
            // txt3074HK
            // 
            txt3074HK.Location = new Point(163, 29);
            txt3074HK.MaxLength = 1;
            txt3074HK.Name = "txt3074HK";
            txt3074HK.Size = new Size(23, 23);
            txt3074HK.TabIndex = 8;
            // 
            // txtPauseHotKey
            // 
            txtPauseHotKey.Location = new Point(48, 89);
            txtPauseHotKey.MaxLength = 1;
            txtPauseHotKey.Name = "txtPauseHotKey";
            txtPauseHotKey.Size = new Size(37, 23);
            txtPauseHotKey.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 92);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 6;
            label3.Text = "Pause";
            // 
            // txtPboxHotKey
            // 
            txtPboxHotKey.Location = new Point(48, 118);
            txtPboxHotKey.MaxLength = 1;
            txtPboxHotKey.Name = "txtPboxHotKey";
            txtPboxHotKey.Size = new Size(37, 23);
            txtPboxHotKey.TabIndex = 5;
            txtPboxHotKey.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 121);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
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
            label1.Size = new Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "Pete";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(700, 338);
            Controls.Add(tabControl1);
            DoubleBuffered = true;
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
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
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
    }
}
