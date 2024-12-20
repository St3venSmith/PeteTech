namespace PeteTech
{
    public partial class Form1 : Form
    {
        public bool soundOn;
        public int delayPBox;
        public bool bufferON;
        public bool buffer;
        private DataPoints dataPoints;





        private HotkeyHelper hotkey1; // Helper for Pbox
        private HotkeyHelper hotkey2; // Helper for Pause
        private HotkeyHelper hotkey3; // helper for 27k
        private HotkeyHelper hotkey4; // helper for 3074
        private HotkeyHelper hotkey5; // helper for fusion breachz
        private Macros macros;
        private GlobalKeyListener _keyListener;



        public Form1()
        {
            InitializeComponent();

            Form form = this;


            FontDialog fontDialog1 = new FontDialog();

            ColorDialog colorDialog1 = new ColorDialog();
            ColorDialog colorDialog2 = new ColorDialog();



            dataPoints = new DataPoints();

            string folderPath = @"C:\PeteData";
            string filePath = Path.Combine(folderPath, "PeteData.txt");
            if (File.Exists(filePath))
            {
                btnStartTracking.Enabled = false;
                dataPoints.LoadDataPoints();
            }


            if (Directory.Exists(folderPath))
            {
                dataPoints.LoadDataPoints();
                lblDateTrack.Text = File.GetCreationTime(filePath).ToString();
                lbl27kTrack.Text = dataPoints.Duration27K.ToString(@"dd\.hh\:mm\:ss");
                lbl3074Track.Text = dataPoints.Duration3074.ToString(@"dd\.hh\:mm\:ss");
                lblDCtrack.Text = dataPoints.DataPoint3.ToString();
                lblFBTrack.Text = dataPoints.DataPoint4.ToString();
                lblPboxTrack.Text = dataPoints.DataPoint5.ToString();
                lblSoloTrack.Text = dataPoints.DataPoint2.ToString();
                lblFullPause.Text = dataPoints.DataPoint1.ToString();
            }
            else if (!Directory.Exists(filePath))
            {
                lblDateTrack.Text = "No Data";
                lbl27kTrack.Text = "No Data";
                lbl3074Track.Text = "No Data";
                lblDCtrack.Text = "No Data";
                lblFBTrack.Text = "No Data";
                lblPboxTrack.Text = "No Data";
                lblSoloTrack.Text = "No Data";
                lblFullPause.Text = "No Data";
            }




            this.KeyPreview = true;
            this.KeyPress += Form_KeyPress;

            _keyListener = new GlobalKeyListener(this); // Pass the form instance
            _keyListener.InstallGlobalKeyHook(); // Start listening for global key presses


            macros = new Macros();





            macros.Duration27KChanged += Macros_Duration27KChanged;
            macros.Duration3074Changed += Macros_Duration3074Changed;


            // Create instances of HotkeyHelper for each TextBox
            hotkey1 = new HotkeyHelper(txtPboxHotKey, macros);
            hotkey2 = new HotkeyHelper(txtPauseHotKey, macros);
            hotkey3 = new HotkeyHelper(txt27HK, macros);
            hotkey4 = new HotkeyHelper(txt3074HK, macros);
            hotkey5 = new HotkeyHelper(txtFBHK, macros);

            macros.OnUpdateLbl27Status += UpdateLbl27Status;
            macros.OnUpdateLbl3074Status += UpdateLbl3074Status;
            macros.DataPoint1Incremented += Macros_DataPoint1Incremented; // full pause
            macros.DataPoint2Incremented += Macros_DataPoint2Incremented; // solo
            macros.DataPoint3Incremented += Macros_DataPoint3Incremented; // dc box
            macros.DataPoint4Incremented += Macros_DataPoint4Incremented; // fb box
            macros.DataPoint5Incremented += Macros_DataPoint5Incremented; // p box


            // Attach Scroll event handler
            tbFpsBar.Scroll += tbFpsBar_Scroll;
            lblFPS.Text = $"{tbFpsBar.Value}";

            cbo3074.Text = "in/out";
            cmbo27k.Text = "in/out";
        }




        // Event handler
        private void Macros_DataPoint1Incremented(object sender, EventArgs e)
        {
            // Handle the event (e.g., update a label or perform some action)
            dataPoints.UpdateDataPoint(1, 1); // Increment DataPoint1 in DataPoints
            lblFullPause.Text = dataPoints.DataPoint1.ToString(); // Update the label
        }
        private void Macros_DataPoint2Incremented(object sender, EventArgs e)
        {
            // Handle the event (e.g., update a label or perform some action)
            dataPoints.UpdateDataPoint(2, 1); // Increment DataPoint1 in DataPoints
            lblSoloTrack.Text = dataPoints.DataPoint2.ToString(); // Update the label
        }
        private void Macros_DataPoint3Incremented(object sender, EventArgs e)
        {
            // Handle the event (e.g., update a label or perform some action)
            dataPoints.UpdateDataPoint(3, 1); // Increment DataPoint1 in DataPoints
            lblDCtrack.Text = dataPoints.DataPoint3.ToString(); // Update the label
        }
        private void Macros_DataPoint4Incremented(object sender, EventArgs e)
        {
            // Handle the event (e.g., update a label or perform some action)
            dataPoints.UpdateDataPoint(4, 1); // Increment DataPoint1 in DataPoints
            lblFBTrack.Text = dataPoints.DataPoint4.ToString(); // Update the label
        }
        private void Macros_DataPoint5Incremented(object sender, EventArgs e)
        {
            // Handle the event (e.g., update a label or perform some action)
            dataPoints.UpdateDataPoint(5, 1); // Increment DataPoint1 in DataPoints
            lblPboxTrack.Text = dataPoints.DataPoint5.ToString(); // Update the label
        }

        private void UpdateLbl27Status(string status)
        {
            lbl27Status.Text = status;
        }

        private void UpdateLbl3074Status(string status)
        {
            lbl3074Status.Text = status;
        }

        private void Macros_Duration27KChanged(object sender, EventArgs e)
        {

            dataPoints.SetDuration27K(macros.Duration27K);
            dataPoints.SaveDataPoints();
            lbl27kTrack.Text = dataPoints.Duration27K.ToString(@"dd\.hh\:mm\:ss");


        }

        private void Macros_Duration3074Changed(object sender, EventArgs e)
        {

            dataPoints.SetDuration3074(macros.Duration3074);
            dataPoints.SaveDataPoints();
            lbl3074Track.Text = dataPoints.Duration3074.ToString(@"dd\.hh\:mm\:ss");
        }

        // Expose FPS Bar value as a property
        public int FpsBarValue
        {
            get => tbFpsBar.Value; // Get the current value
            set => tbFpsBar.Value = value; // Set a new value
        }

        public void UpdateFormLabels(string lbltS, string lbltrs)
        {
            lbl27Status.Text = macros.lbltS;
            lbl3074Status.Text = macros.lbltrS;
        }


        private void btn27K_Click(object sender, EventArgs e)
        {
            if (cmbo27k.Text == "in/out")
            {
                if (macros.RulesEnabled27K)  // Check if the rules are enabled
                {
                    macros.Disable27K();
                    macros.RulesEnabled27K = false;
                    
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(false);
                    }
                }
                else
                {
                    macros.Enable27K();
                    macros.RulesEnabled27K = true;
                    
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(true);
                    }
                }
            }
            else if (cmbo27k.Text == "in")
            {
                if (macros.RulesEnabled27K)  // Check if the rules are enabled
                {
                    macros.Disable27K();
                    macros.RulesEnabled27K = false;
                    
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(false);
                    }
                }
                else
                {
                    macros.Enable27KIN();
                    macros.RulesEnabled27K = true;
                    
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(true);
                    }
                }

            }
            else if (cmbo27k.Text == "out")
            {
                if (macros.RulesEnabled27K)  // Check if the rules are enabled
                {
                    macros.Disable27K();
                    macros.RulesEnabled27K = false;
                    
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(false);
                    }
                }
                else
                {
                    macros.Enable27KOUT();
                    macros.RulesEnabled27K = true;
                    
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(true);
                    }
                }
            }

        }

        private void btn3074_Click(object sender, EventArgs e)
        {
            if (cbo3074.Text == "in/out")
            {
                if (macros.RulesEnabled3074)  // Check if the rules are enabled
                {
                    macros.Disable3074();
                    macros.RulesEnabled3074 = false;
                    
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(false);
                    }
                }
                else
                {
                    macros.Enable3074();
                    macros.RulesEnabled3074 = true;
                    
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(true);
                    }
                }
            }
            else if (cbo3074.Text == "in")
            {
                if (macros.RulesEnabled3074)  // Check if the rules are enabled
                {
                    macros.Disable3074();
                    macros.RulesEnabled3074 = false;
                    
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(false);
                    }

                }
                else
                {
                    macros.Enable3074IN();
                    macros.RulesEnabled3074 = true;
                    
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(true);
                    }
                }
            }
            else if (cbo3074.Text == "out")
            {
                if (macros.RulesEnabled3074)  // Check if the rules are enabled
                {
                    macros.Disable3074();
                    macros.RulesEnabled3074 = false;
                    
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(false);
                    }

                }
                else
                {
                    macros.Enable3074OUT();
                    macros.RulesEnabled3074 = true;
                    
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(true);
                    }
                }
            }

        }
        private void btnSolo_Click(object sender, EventArgs e)
        {
            macros.SoloScript();
        }



        private void chkAutoBuffer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAutoBuffer.Checked == true)
            {
                macros.isBufferOn = true;

            }
            else
            {
                macros.isBufferOn = false;
            }
        }

        private void chkSounds_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSounds.Checked == true)
            {
                macros.isSoundOn = true;

            }
            else
            {
                macros.isSoundOn = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void Form_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _keyListener.UnhookKeyboardHook(); // Stop listening for global keys when the form is closed
            macros.Disable27K();
            macros.Disable3074();
            dataPoints.SaveDataPoints();
            base.OnFormClosed(e);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbFpsBar_Scroll(object sender, EventArgs e)
        {
            // Update label or use the value
            lblFPS.Text = $"{tbFpsBar.Value}";
            if (tbFpsBar.Value == 255)
            {
                lblFPS.Text = "∞";
            }
            delayPBox = 244 + (int)Math.Floor((tbFpsBar.Value * 50) / 220.0);
            macros.UpdateFps(tbFpsBar.Value);



            // Pass the delayPBox to macros

        }

        private void txtPboxMessage_TextChanged(object sender, EventArgs e)
        {
            macros.UpdatePboxText(txtPboxMessage.Text);
        }

        private void cmbo27k_SelectedIndexChanged(object sender, EventArgs e)
        {
            macros.kStatus = cmbo27k.Text;

        }

        private void cbo3074_SelectedIndexChanged(object sender, EventArgs e)
        {
            macros.tStatus = cbo3074.Text;
        }

        private void btnDC_Click(object sender, EventArgs e)
        {
            macros.DCScript();
        }

        private void btnStartTracking_Click(object sender, EventArgs e)
        {
            dataPoints.CreateFolderAndFile();
            btnStartTracking.Enabled = false;
        }


        // customization shi

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                lblFPS.ForeColor = colorDialog1.Color;
                lbl27kTrack.ForeColor = colorDialog1.Color;
                lbl3074Track.ForeColor = colorDialog1.Color;
                lblDCtrack.ForeColor = colorDialog1.Color;
                lblFBTrack.ForeColor = colorDialog1.Color;
                lblPboxTrack.ForeColor = colorDialog1.Color;
                lblSoloTrack.ForeColor = colorDialog1.Color;
                lblFullPause.ForeColor = colorDialog1.Color;
                label1.ForeColor = colorDialog1.Color;
                label2.ForeColor = colorDialog1.Color;
                label3.ForeColor = colorDialog1.Color;
                label4.ForeColor = colorDialog1.Color;
                label5.ForeColor = colorDialog1.Color;
                label6.ForeColor = colorDialog1.Color;
                label7.ForeColor = colorDialog1.Color;
                label8.ForeColor = colorDialog1.Color;
                label9.ForeColor = colorDialog1.Color;
                label10.ForeColor = colorDialog1.Color;
                label11.ForeColor = colorDialog1.Color;
                label12.ForeColor = colorDialog1.Color;
                label13.ForeColor = colorDialog1.Color;
                label14.ForeColor = colorDialog1.Color;
                label15.ForeColor = colorDialog1.Color;
                lbl27Status.ForeColor = colorDialog1.Color;
                lbl3074Status.ForeColor = colorDialog1.Color;
                lblFPS.ForeColor = colorDialog1.Color;
                lblDateTrack.ForeColor = colorDialog1.Color;
                lblFullPause.ForeColor = colorDialog1.Color;
                lblFusion.ForeColor = colorDialog1.Color;
                btnSolo.ForeColor = colorDialog1.Color;
                btnDC.ForeColor = colorDialog1.Color;
                chkAutoBuffer.ForeColor = colorDialog1.Color;
                chkSounds.ForeColor = colorDialog1.Color;
                btnStartTracking.ForeColor = colorDialog1.Color;
                btn27K.ForeColor = colorDialog1.Color;
                btn3074.ForeColor = colorDialog1.Color;
                cmbo27k.ForeColor = colorDialog1.Color;
                cbo3074.ForeColor = colorDialog1.Color;
                btnChangeFont.ForeColor = colorDialog1.Color;
                btnColor.ForeColor = colorDialog1.Color;
                btnTheme.ForeColor = colorDialog1.Color;
            }

        }

        private void trcTrans_Scroll(object sender, EventArgs e)
        {
            Form form = this;
            form.Opacity = (double)trcTrans.Value / 100;
        }

        private void btnChangeFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)

            {

                // Apply the selected font to a textbox (named "textBox1" in this example)



                lblFPS.Font = fontDialog1.Font;
                lbl27kTrack.Font = fontDialog1.Font;
                lbl3074Track.Font = fontDialog1.Font;
                lblDCtrack.Font = fontDialog1.Font;
                lblFBTrack.Font = fontDialog1.Font;
                lblPboxTrack.Font = fontDialog1.Font;
                lblSoloTrack.Font = fontDialog1.Font;
                lblFullPause.Font = fontDialog1.Font;
                label1.Font = fontDialog1.Font;
                label2.Font = fontDialog1.Font;
                label3.Font = fontDialog1.Font;
                label4.Font = fontDialog1.Font;
                label5.Font = fontDialog1.Font;
                label6.Font = fontDialog1.Font;
                label7.Font = fontDialog1.Font;
                label8.Font = fontDialog1.Font;
                label9.Font = fontDialog1.Font;
                label10.Font = fontDialog1.Font;
                label11.Font = fontDialog1.Font;
                label12.Font = fontDialog1.Font;
                label13.Font = fontDialog1.Font;
                label14.Font = fontDialog1.Font;
                label15.Font = fontDialog1.Font;
                lbl27Status.Font = fontDialog1.Font;
                lbl3074Status.Font = fontDialog1.Font;
                lblDateTrack.Font = fontDialog1.Font;
                lblFusion.Font = fontDialog1.Font;
                btnSolo.Font = fontDialog1.Font;
                btnDC.Font = fontDialog1.Font;
                chkAutoBuffer.Font = fontDialog1.Font;
                chkSounds.Font = fontDialog1.Font;
                btnStartTracking.Font = fontDialog1.Font;
                btn27K.Font = fontDialog1.Font;
                btn3074.Font = fontDialog1.Font;
                cmbo27k.Font = fontDialog1.Font;
                cbo3074.Font = fontDialog1.Font;
                btnChangeFont.Font = fontDialog1.Font;
                btnColor.Font = fontDialog1.Font;
                tabControl1.Font = fontDialog1.Font;
                btnTheme.Font = fontDialog1.Font;


            }
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            Form form = this;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                tabControl1.TabPages[0].BackColor = colorDialog1.Color;
                tabControl1.TabPages[1].BackColor = colorDialog1.Color;
                tabControl1.TabPages[2].BackColor = colorDialog1.Color;
                tabControl1.TabPages[3].BackColor = colorDialog1.Color;
                tabControl1.TabPages[4].BackColor = colorDialog1.Color;

            }

        }
    }
}
