namespace PeteTech
{
    public partial class Form1 : Form
    {
        public bool soundOn;
        public int delayPBox;



        


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


            // Attach Scroll event handler
            tbFpsBar.Scroll += tbFpsBar_Scroll;
            lblFPS.Text = $"Value: {tbFpsBar.Value}";

            cbo3074.Text = "in/out";
            cmbo27k.Text = "in/out";
        }
       

        private void btn27K_Click(object sender, EventArgs e)
        {
            if (cmbo27k.Text == "in/out")
            {
                if (macros.RulesEnabled27K)  // Check if the rules are enabled
                {
                    macros.Disable27K();
                    macros.RulesEnabled27K = false;
                }
                else
                {
                    macros.Enable27K();
                    macros.RulesEnabled27K = true;
                }
            }
            else if(cmbo27k.Text == "in")
            {
                if (macros.RulesEnabled27K)  // Check if the rules are enabled
                {
                    macros.Disable27K();
                    macros.RulesEnabled27K = false;
                }
                else
                {
                    macros.Enable27KIN();
                    macros.RulesEnabled27K = true;
                }
            }
            
        }

        private void btn3074_Click(object sender, EventArgs e)
        {
            if (macros.RulesEnabled3074)  // Check if the rules are enabled
            {
                macros.Disable3074();
                macros.RulesEnabled3074 = false;
            }
            else
            {
                macros.Enable3074();
                macros.RulesEnabled3074 = true;
            }
        }
        private void btnSolo_Click(object sender, EventArgs e)
        {
            macros.SoloScript();
        }

        private void chkAutoBuffer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSounds.Checked == true)
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
            lblFPS.Text = $"Value: {tbFpsBar.Value}";
            delayPBox = 244 + (int)Math.Floor((tbFpsBar.Value * 50) / 220.0);

            // Pass the delayPBox to macros
           
        }









        // Code for Other Methods
        // could make a class for this but i was on lunch



    }
}
