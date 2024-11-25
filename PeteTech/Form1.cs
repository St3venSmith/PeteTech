namespace PeteTech
{
    public partial class Form1 : Form
    {
        public bool soundOn;
        public int delayPBox;
        public bool bufferON;
        public bool buffer;



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
            this.KeyPreview = true;
            this.KeyPress += Form_KeyPress;

            _keyListener = new GlobalKeyListener(this); // Pass the form instance
            _keyListener.InstallGlobalKeyHook(); // Start listening for global key presses


            macros = new Macros();


            // Create instances of HotkeyHelper for each TextBox
            hotkey1 = new HotkeyHelper(txtPboxHotKey, macros);
            hotkey2 = new HotkeyHelper(txtPauseHotKey, macros);
            hotkey3 = new HotkeyHelper(txt27HK, macros);
            hotkey4 = new HotkeyHelper(txt3074HK, macros);
            hotkey5 = new HotkeyHelper(txtFBHK, macros);

            macros.OnUpdateLbl27Status += UpdateLbl27Status;
            macros.OnUpdateLbl3074Status += UpdateLbl3074Status;


            // Attach Scroll event handler
            tbFpsBar.Scroll += tbFpsBar_Scroll;
            lblFPS.Text = $"Value: {tbFpsBar.Value}";

            cbo3074.Text = "in/out";
            cmbo27k.Text = "in/out";
        }


        private void UpdateLbl27Status(string status)
        {
            lbl27Status.Text = status;
        }

        private void UpdateLbl3074Status(string status)
        {
            lbl3074Status.Text = status;
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
                    lbl27Status.Text = "OFF";
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(false);
                    }
                }
                else
                {
                    macros.Enable27K();
                    macros.RulesEnabled27K = true;
                    lbl27Status.Text = "ON";
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
                    lbl27Status.Text = "OFF";
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(false);
                    }
                }
                else
                {
                    macros.Enable27KIN();
                    macros.RulesEnabled27K = true;
                    lbl27Status.Text = "ON";
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
                    lbl27Status.Text = "OFF";
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(false);
                    }
                }
                else
                {
                    macros.Enable27KOUT();
                    macros.RulesEnabled27K = true;
                    lbl27Status.Text = "ON";
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
                    lbl3074Status.Text = "OFF";
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(false);
                    }
                }
                else
                {
                    macros.Enable3074();
                    macros.RulesEnabled3074 = true;
                    lbl3074Status.Text = "ON";
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
                    lbl3074Status.Text = "OFF";
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(false);
                    }

                }
                else
                {
                    macros.Enable3074IN();
                    macros.RulesEnabled3074 = true;
                    lbl3074Status.Text = "ON";
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
                    lbl3074Status.Text = "OFF";
                    if (macros.isSoundOn)
                    {
                        macros.PlaySoundCue(false);
                    }

                }
                else
                {
                    macros.Enable3074OUT();
                    macros.RulesEnabled3074 = true;
                    lbl3074Status.Text = "ON";
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

        // H
        private void Form_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _keyListener.UnhookKeyboardHook(); // Stop listening for global keys when the form is closed
            macros.Disable27K();
            macros.Disable3074();
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

        









        // Code for Other Methods
        // could make a class for this but i was on lunch



    }
}
