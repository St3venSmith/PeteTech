using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace PeteTech
{
    public partial class Form1 : Form
    {
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
        }

        private void btn27K_Click(object sender, EventArgs e)
        {
            macros.txt27HK();
        }

        private void btn3074_Click(object sender, EventArgs e)
        {
            macros.txt3074HK();
        }
        private void btnSolo_Click(object sender, EventArgs e)
        {
            macros.SoloScript();
        }

        private void chkAutoBuffer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkSounds_CheckedChanged(object sender, EventArgs e)
        {

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
            base.OnFormClosed(e);
        }









        // Code for Other Methods
        // could make a class for this but i was on lunch



    }
}
