using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Drawing;

using System.Windows.Forms;


namespace PeteTech
{
    internal partial class Overlayklarity : Macros
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_LAYERED = 0x00080000;
        private const int WS_EX_TRANSPARENT = 0x00000020;

        private Macros macros;
        private PortDataRecorder _portDataRecorder;
        
       






        public Overlayklarity()
        {
            InitializeComponent();
            macros = new Macros();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = System.Drawing.Color.Black;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.AllowTransparency = true;
            this.StartPosition = FormStartPosition.Manual;
            
        }

        private void Overlayklarity_Load(object sender, EventArgs e)
        {
            ApplyClickThroughStyle();
            // Position the form at the far left center of the screen
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int formHeight = this.Height;
            int yPos = (screenHeight - formHeight) / 2;
            this.Location = new System.Drawing.Point(0, yPos);

        }

        private void ApplyClickThroughStyle()
        {
            try
            {
                int exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
                SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle | WS_EX_LAYERED | WS_EX_TRANSPARENT);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to apply click-through style: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void UpdateLabels2(string filterName, double dataIn, double dataOut)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateLabels2(filterName, dataIn, dataOut)));
            }
            else
            {
                switch (filterName)
                {
                    case "3074":
                        lbl3074InO.Text = $"{dataIn:F2}";
                        lbl3074OutO.Text = $"{dataOut:F2}";
                        break;
                    case "27k":
                        lbl27kinO.Text = $"{dataIn:F2}";
                        lbl27KOutO.Text = $"{dataOut:F2}";

                        break;
                    case "7500":
                        lbl7500Ino.Text = $"{dataIn:F2}";
                        lbl7500OutO.Text = $"{dataOut:F2}";
                        break;
                    case "30k":
                       lbl30KinO.Text = $"{dataIn:F2}";
                       lbl30KOutO.Text = $"{dataOut:F2}";
                        break;
                }

            }
        }
        // Toggle method
        public void Toggle27kImage(bool State)
        {
            if (State)
            {
                pic27kOn.Visible = true;
            }
            else
            {
                pic27kOn.Visible = false;
            }
        }
        public void Toggle3074KImage(bool State)
        {
            if (State)
            {
                pic3700On.Visible = true;
            }
            else
            {
                pic3700On.Visible = false;
            }
        }
        public void Toggle7500Image(bool State)
        {
            if (State)
            {
                pic7500On.Visible = true;
            }
            else
            {
                pic7500On.Visible = false;
            }
        }

        public void Toggle30KImage(bool State)
        {
            if (State)
            {
                pic30000On.Visible = true;
            }
            else
            {
                pic30000On.Visible = false;
            }
        }

        private void pic27kOn_Click(object sender, EventArgs e)
        {

        }
    }
}
