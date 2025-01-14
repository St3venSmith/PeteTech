using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;
using System.Media;
using System.Drawing;
using Microsoft.VisualBasic.Devices;

namespace PeteTech
{
    public partial class Form1 : Form
    {



        public bool soundOn;
        public int delayPBox;
        public bool bufferON;
        public bool buffer;

        private bool overlay = false;
        public bool isAFK = false;
        public bool isSolo = false;
        private DataPoints dataPoints;

        private HotkeyHelper hotkey1; // Helper for Pbox
        private HotkeyHelper hotkey2; // Helper for Pause
        private HotkeyHelper hotkey3; // helper for 27k
        private HotkeyHelper hotkey4; // helper for 3074
        private HotkeyHelper hotkey5; // helper for fusion breachz
        private HotkeyHelper hotkey6; // helper for multi
        private HotkeyHelper hotkey7; // helper for 7500
        private HotkeyHelper hotkey8; // for 30k
        private WinDiverts winDiverts;
        private Macros macros;
        private PortDataRecorder _portDataRecorder;
        private GlobalKeyListener _keyListener;
        private Overlayklarity overlayForm;



        public Form1()
        {
            InitializeComponent();

            Form form = this;
            



            _portDataRecorder = new PortDataRecorder();
            _portDataRecorder.DataUsageUpdated += UpdateLabels;
            _portDataRecorder.Start();

            FontDialog fontDialog1 = new();

            ColorDialog colorDialog1 = new();
            ColorDialog colorDialog2 = new();

            winDiverts = new WinDiverts();



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
                lbl7500Track.Text = dataPoints.Duration7500.ToString(@"dd\.hh\:mm\:ss");
                lbl30kTrack.Text = dataPoints.Duration30k.ToString(@"dd\.hh\:mm\:ss");
                lblDCtrack.Text = dataPoints.DataPoint3.ToString();
                lblFBTrack.Text = dataPoints.DataPoint4.ToString();
                lblPboxTrack.Text = dataPoints.DataPoint5.ToString();
                lblSoloTrack.Text = dataPoints.DataPoint2.ToString();
                lblFullPause.Text = dataPoints.DataPoint1.ToString();
                lblmultitrack.Text = dataPoints.DataPoint6.ToString();

            }
            else if (!Directory.Exists(filePath))
            {
                lblDateTrack.Text = "No Data";
                lbl27kTrack.Text = "No Data";
                lbl3074Track.Text = "No Data";
                lbl7500Track.Text = "No Data";
                lbl30kTrack.Text = "No Data";
                lblDCtrack.Text = "No Data";
                lblFBTrack.Text = "No Data";
                lblPboxTrack.Text = "No Data";
                lblSoloTrack.Text = "No Data";
                lblFullPause.Text = "No Data";
                lblmultitrack.Text = "No Data";
            }




            this.KeyPreview = true;
            this.KeyPress += Form_KeyPress;

            _keyListener = new GlobalKeyListener(this); // Pass the form instance
            _keyListener.InstallGlobalKeyHook(); // Start listening for global key presses


            macros = new Macros();
            overlayForm = new Overlayklarity();

            macros.Duration27KChanged += Macros_Duration27KChanged;
            macros.Duration3074Changed += Macros_Duration3074Changed;
            macros.Duration7500Changed += Macros_Duration7500Changed;
            macros.Duration30KChanged += Macros_Duration30KChanged;


            // Create instances of HotkeyHelper for each TextBox
            hotkey1 = new HotkeyHelper(txtPboxHotKey, macros);
            hotkey2 = new HotkeyHelper(txtPauseHotKey, macros);
            hotkey3 = new HotkeyHelper(txt27HK, macros);
            hotkey4 = new HotkeyHelper(txt3074HK, macros);
            hotkey5 = new HotkeyHelper(txtFBHK, macros);
            hotkey6 = new HotkeyHelper(txtMulti, macros);
            hotkey7 = new HotkeyHelper(txt7500HK, macros);
            hotkey8 = new HotkeyHelper(txt30kHK, macros);



            macros.OnUpdateLbl27Status += UpdateLbl27Status;
            macros.OnUpdateLbl3074Status += UpdateLbl3074Status;
            macros.OnUpdateLbl7500Status += UpdateLbl7500Status;
            macros.OnUpdateLbl30KStatus += UpdateLbl30KStatus;
            macros.DataPoint1Incremented += Macros_DataPoint1Incremented; // full pause
            macros.DataPoint2Incremented += Macros_DataPoint2Incremented; // solo
            macros.DataPoint3Incremented += Macros_DataPoint3Incremented; // dc box
            macros.DataPoint4Incremented += Macros_DataPoint4Incremented; // fb box
            macros.DataPoint5Incremented += Macros_DataPoint5Incremented; // p box
            macros.DataPoint6Incremented += Macros_DataPoint6Incremented; // multi


            // Attach Scroll event handler
            tbFpsBar.Scroll += tbFpsBar_Scroll;
            lblFPS.Text = $"{tbFpsBar.Value}";

            cbo3074.Text = "in/out";
            cmbo27k.Text = "in/out";
            cbo7500.Text = "in/out";
            cbo30k.Text = "in/out";


        }


        private async void UpdateLabels(string filterName, double dataIn, double dataOut)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateLabels(filterName, dataIn, dataOut)));
            }
            else
            {
                switch (filterName)
                {
                    case "3074":
                        lbl3074down.Text = $"{dataIn:F2}KB";
                        lbl3074Up.Text = $"{dataOut:F2}KB";
                        if (overlayForm != null)
                        {
                            overlayForm.UpdateLabels2(filterName, dataIn, dataOut);
                        }

                        break;
                    case "27k":
                        lbl27kdown.Text = $"{dataIn:F2}KB";
                        lbl27kUp.Text = $"{dataOut:F2}KB";
                        if (overlayForm != null)
                        {
                            overlayForm.UpdateLabels2(filterName, dataIn, dataOut);
                        }

                        break;
                    case "7500":
                        lbl7500Down.Text = $"{dataIn:F2}KB";
                        lbl7500Up.Text = $"{dataOut:F2}KB";
                        if (overlayForm != null)
                        {
                            overlayForm.UpdateLabels2(filterName, dataIn, dataOut);
                        }

                        break;
                    case "30k":
                        lbl30KDown.Text = $"{dataIn:F2}KB";
                        lbl30KUP.Text = $"{dataOut:F2}KB";
                        if (overlayForm != null)
                        {
                            overlayForm.UpdateLabels2(filterName, dataIn, dataOut);
                        }

                        break;
                }
            }
        }


        // Event handler
        private void Macros_DataPoint1Incremented(object? sender, EventArgs e)
        {
            // Handle the event (e.g., update a label or perform some action)
            dataPoints.UpdateDataPoint(1, 1); // Increment DataPoint1 in DataPoints
            lblFullPause.Text = dataPoints.DataPoint1.ToString(); // Update the label
        }
        private void Macros_DataPoint2Incremented(object? sender, EventArgs e)
        {
            // Handle the event (e.g., update a label or perform some action)
            dataPoints.UpdateDataPoint(2, 1); // Increment DataPoint1 in DataPoints
            lblSoloTrack.Text = dataPoints.DataPoint2.ToString(); // Update the label
        }
        private void Macros_DataPoint3Incremented(object? sender, EventArgs e)
        {
            // Handle the event (e.g., update a label or perform some action)
            dataPoints.UpdateDataPoint(3, 1); // Increment DataPoint1 in DataPoints
            lblDCtrack.Text = dataPoints.DataPoint3.ToString(); // Update the label
        }
        private void Macros_DataPoint4Incremented(object? sender, EventArgs e)
        {
            // Handle the event (e.g., update a label or perform some action)
            dataPoints.UpdateDataPoint(4, 1); // Increment DataPoint1 in DataPoints
            lblFBTrack.Text = dataPoints.DataPoint4.ToString(); // Update the label
        }
        private void Macros_DataPoint5Incremented(object? sender, EventArgs e)
        {
            // Handle the event (e.g., update a label or perform some action)
            dataPoints.UpdateDataPoint(5, 1); // Increment DataPoint1 in DataPoints
            lblPboxTrack.Text = dataPoints.DataPoint5.ToString(); // Update the label
        }

        private void Macros_DataPoint6Incremented(object? sender, EventArgs e)
        {
            // Handle the event (e.g., update a label or perform some action)
            dataPoints.UpdateDataPoint(6, 1); // Increment DataPoint1 in DataPoints
            lblmultitrack.Text = dataPoints.DataPoint6.ToString(); // Update the label
        }

        private void UpdateLbl27Status(string status)
        {
            lbl27Status.Text = status;

            if (status == "ON")
            {
                overlayForm.Toggle27kImage(true);
            }
            else if (status == "OFF")
            {
                overlayForm.Toggle27kImage(false);
            }
        }

        private void UpdateLbl3074Status(string status)
        {
            lbl3074Status.Text = status;

            if (status == "ON")
            {
                overlayForm.Toggle3074KImage(true);
            }
            else if (status == "OFF")
            {
                overlayForm.Toggle3074KImage(false);
            }
        }

        private void UpdateLbl7500Status(string status)
        {
            lbl7500Status.Text = status;

            if (status == "ON")
            {
                overlayForm.Toggle7500Image(true);
            }
            else if (status == "OFF")
            {
                overlayForm.Toggle7500Image(false);
            }
        }

        private void UpdateLbl30KStatus(string status)
        {
            lbl30kStatus.Text = status;

            if (status == "ON")
            {
                overlayForm.Toggle30KImage(true);
            }
            else if (status == "OFF")
            {
                overlayForm.Toggle30KImage(false);
            }
        }



        private void Macros_Duration27KChanged(object? sender, EventArgs e)
        {
            dataPoints.SetDuration27K(macros.Duration27K);
            dataPoints.SaveDataPoints();
            lbl27kTrack.Text = dataPoints.Duration27K.ToString(@"dd\.hh\:mm\:ss");
        }

        private void Macros_Duration3074Changed(object? sender, EventArgs e)
        {
            dataPoints.SetDuration3074(macros.Duration3074);
            dataPoints.SaveDataPoints();
            lbl3074Track.Text = dataPoints.Duration3074.ToString(@"dd\.hh\:mm\:ss");
        }
        private void Macros_Duration7500Changed(object? sender, EventArgs e)
        {
            dataPoints.SetDuration7500(macros.Duration7500);
            dataPoints.SaveDataPoints();
            lbl7500Track.Text = dataPoints.Duration7500.ToString(@"dd\.hh\:mm\:ss");
        }

        private void Macros_Duration30KChanged(object? sender, EventArgs e)
        {
            dataPoints.SetDuration30k(macros.Duration30k);
            dataPoints.SaveDataPoints();
            lbl30kTrack.Text = dataPoints.Duration30k.ToString(@"dd\.hh\:mm\:ss");
        }

        // Expose FPS Bar value as a property
        public int FpsBarValue
        {
            get => tbFpsBar.Value; // Get the current value
            set => tbFpsBar.Value = value; // Set a new value
        }

        public void UpdateFormLabels(string lbltS, string lbltrs, string lbltrx, string lbltrT)
        {
            lbl27Status.Text = macros.lbltS;
            lbl3074Status.Text = macros.lbltrS;
            lbl7500Status.Text = macros.lbltrx;
            lbl30kStatus.Text = macros.lbltrT;

        }

        private void txt7500HK_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbo30k_SelectedIndexChanged(object sender, EventArgs e)
        {
            macros.dStatus = cbo30k.Text;
        }

        private async void btn7500_Click(object sender, EventArgs e)
        {
            if (cbo7500.Text == "in/out")
            {
                if (macros.RulesEnabled7500)  // Check if the rules are enabled
                {
                    macros.RulesEnabled7500 = false;
                    await macros.Disable7500();

                }
                else
                {
                    macros.RulesEnabled7500 = true;
                    await macros.Enable7500();

                }
            }
            else if (cbo7500.Text == "in")
            {
                if (macros.RulesEnabled7500)  // Check if the rules are enabled
                {
                    macros.RulesEnabled7500 = false;
                    await macros.Disable7500();

                }
                else
                {
                    macros.RulesEnabled7500 = true;
                    await macros.Enable7500();

                }

            }
            else if (cbo7500.Text == "out")
            {
                if (macros.RulesEnabled7500)  // Check if the rules are enabled
                {
                    macros.RulesEnabled7500 = false;
                    await macros.Disable7500();

                }
                else
                {
                    macros.RulesEnabled7500 = true;
                    await macros.Enable7500();

                }
            }
        }


        private async void btn27K_Click(object sender, EventArgs e)
        {
            if (cmbo27k.Text == "in/out")
            {
                if (macros.RulesEnabled27K)  // Check if the rules are enabled
                {
                    macros.RulesEnabled27K = false;
                    await macros.Disable27K();

                }
                else
                {
                    macros.RulesEnabled27K = true;
                    await macros.Enable27K();

                }
            }
            else if (cmbo27k.Text == "in")
            {
                if (macros.RulesEnabled27K)  // Check if the rules are enabled
                {
                    macros.RulesEnabled27K = false;
                    await macros.Disable27K();

                }
                else
                {
                    macros.RulesEnabled27K = true;
                    await macros.Enable27K();

                }

            }
            else if (cmbo27k.Text == "out")
            {
                if (macros.RulesEnabled27K)  // Check if the rules are enabled
                {
                    macros.RulesEnabled27K = false;
                    await macros.Disable27K();

                }
                else
                {
                    macros.RulesEnabled27K = true;
                    await macros.Enable27K();

                }
            }

        }

        private async void btn30k_Click(object sender, EventArgs e)
        {
            if (cbo30k.Text == "in/out")
            {
                if (macros.RulesEnabled30k)  // Check if the rules are enabled
                {
                    macros.RulesEnabled30k = false;
                    await macros.Disable30k();

                }
                else
                {
                    macros.RulesEnabled30k = true;
                    await macros.Enable30k();

                }
            }
            else if (cbo30k.Text == "in")
            {
                if (macros.RulesEnabled30k)  // Check if the rules are enabled
                {
                    macros.RulesEnabled30k = false;
                    await macros.Disable30k();
                }
                else
                {
                    macros.RulesEnabled30k = true;
                    await macros.Enable30k();

                }
            }
            else if (cbo30k.Text == "out")
            {
                if (macros.RulesEnabled30k)  // Check if the rules are enabled
                {
                    macros.RulesEnabled30k = false;
                    await macros.Disable30k();

                }
                else
                {
                    macros.RulesEnabled30k = true;
                    await macros.Enable30k();

                }
            }
        }

        private async void btn3074_Click(object sender, EventArgs e)
        {
            if (cbo3074.Text == "in/out")
            {
                if (macros.RulesEnabled3074)  // Check if the rules are enabled
                {
                    macros.RulesEnabled3074 = false;
                    await macros.Disable3074();

                }
                else
                {
                    macros.RulesEnabled3074 = true;
                    await macros.Enable3074();

                }
            }
            else if (cbo3074.Text == "in")
            {
                if (macros.RulesEnabled3074)  // Check if the rules are enabled
                {
                    macros.RulesEnabled3074 = false;
                    await macros.Disable3074();
                }
                else
                {
                    macros.RulesEnabled3074 = true;
                    await macros.Enable3074();

                }
            }
            else if (cbo3074.Text == "out")
            {
                if (macros.RulesEnabled3074)  // Check if the rules are enabled
                {
                    macros.RulesEnabled3074 = false;
                    await macros.Disable3074();

                }
                else
                {
                    macros.RulesEnabled3074 = true;
                    await macros.Enable3074();

                }
            }

        }
        private async void btnSolo_Click(object sender, EventArgs e)
        {

            await macros.SoloScript();
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


        private void Form_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Your existing code here
        }

        protected override async void OnFormClosed(FormClosedEventArgs e)
        {

            _keyListener.UnhookKeyboardHook(); // Stop listening for global keys when the form is closed
            await macros.Disable27K();
            await macros.Disable3074();
            await macros.Disable7500();
            await macros.Disable30k();
            dataPoints.SaveDataPoints();
            base.OnFormClosed(e);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbFpsBar_Scroll(object? sender, EventArgs e)
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
        private void cbo7500_SelectedIndexChanged(object sender, EventArgs e)
        {
            macros.sStatus = cbo7500.Text;
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
                label16.ForeColor = colorDialog1.Color;
                label17.ForeColor = colorDialog1.Color;
                label18.ForeColor = colorDialog1.Color;

                lbl27Status.ForeColor = colorDialog1.Color;
                lbl3074Status.ForeColor = colorDialog1.Color;
                lbl7500Status.ForeColor = colorDialog1.Color;
                lbl30kStatus.ForeColor = colorDialog1.Color;
                lblmultitrack.ForeColor = colorDialog1.Color;
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
                lblMulti.ForeColor = colorDialog1.Color;

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
                label16.Font = fontDialog1.Font;
                label17.Font = fontDialog1.Font;
                label18.Font = fontDialog1.Font;
                lbl7500Track.Font = fontDialog1.Font;
                lbl30kTrack.Font = fontDialog1.Font;
                lblmultitrack.Font = fontDialog1.Font;
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
                lblMulti.Font = fontDialog1.Font;
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
                tabControl1.TabPages[5].BackColor = colorDialog1.Color;
            }

        }



        private CancellationTokenSource _afkCancellationTokenSource = new CancellationTokenSource();

        private async void btnAFK_Click(object sender, EventArgs e)
        {
            isAFK = !isAFK;

            if (!isAFK)
            {
                _afkCancellationTokenSource.Cancel();
                _afkCancellationTokenSource = new CancellationTokenSource();
            }

            await macros.txtAFK(isAFK, _afkCancellationTokenSource.Token);
        }


        private void txt30kHK_TextChanged(object sender, EventArgs e)
        {

        }



        void btnOverlay_Click(object sender, EventArgs e)
        {
            overlay = !overlay;

            if (overlay)
            {
                if (overlayForm.IsDisposed)
                {
                    overlayForm = new Overlayklarity();
                }
                overlayForm.Show();
            }
            else
            {
                overlayForm.Hide();
            }
        }

        private void btnOverlayKey_Click(object sender, EventArgs e)
        {
            if (colorDialog3.ShowDialog() == DialogResult.OK)
            {
                overlayForm.BackColor = colorDialog3.Color;
                overlayForm.TransparencyKey = colorDialog3.Color;
            }
        }
    }
}
