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
            btn27K = new Button();
            btn3074 = new Button();
            chkAutoBuffer = new CheckBox();
            chkSounds = new CheckBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // btn27K
            // 
            btn27K.Location = new Point(118, 6);
            btn27K.Name = "btn27K";
            btn27K.Size = new Size(94, 29);
            btn27K.TabIndex = 0;
            btn27K.Text = "27k";
            btn27K.UseVisualStyleBackColor = true;
            btn27K.Click += btn27K_Click;
            // 
            // btn3074
            // 
            btn3074.Location = new Point(6, 6);
            btn3074.Name = "btn3074";
            btn3074.Size = new Size(94, 29);
            btn3074.TabIndex = 1;
            btn3074.Text = "3074";
            btn3074.UseVisualStyleBackColor = true;
            btn3074.Click += btn3074_Click;
            // 
            // chkAutoBuffer
            // 
            chkAutoBuffer.AutoSize = true;
            chkAutoBuffer.Location = new Point(6, 41);
            chkAutoBuffer.Name = "chkAutoBuffer";
            chkAutoBuffer.Size = new Size(107, 24);
            chkAutoBuffer.TabIndex = 2;
            chkAutoBuffer.Text = "Auto Buffer";
            chkAutoBuffer.UseVisualStyleBackColor = true;
            chkAutoBuffer.CheckedChanged += chkAutoBuffer_CheckedChanged;
            // 
            // chkSounds
            // 
            chkSounds.AutoSize = true;
            chkSounds.Location = new Point(119, 41);
            chkSounds.Name = "chkSounds";
            chkSounds.Size = new Size(79, 24);
            chkSounds.TabIndex = 3;
            chkSounds.Text = "Sounds";
            chkSounds.UseVisualStyleBackColor = true;
            chkSounds.CheckedChanged += chkSounds_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btn3074);
            tabPage1.Controls.Add(chkSounds);
            tabPage1.Controls.Add(btn27K);
            tabPage1.Controls.Add(chkAutoBuffer);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 417);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Home";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 417);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Credits";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 13);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 0;
            label1.Text = "Pete and Delta";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "PeteTech";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
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
    }
}
