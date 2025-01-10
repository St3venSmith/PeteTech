using ProcessManagement;
using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;



namespace PeteTech
{
    internal class Macros : ISuspend
    {

        public SoundPlayer player = new SoundPlayer(new MemoryStream(Properties.Resources.SoundONPeteTechCut));
        public SoundPlayer player2 = new SoundPlayer(new MemoryStream(Properties.Resources.SoundOFFPeteTechCut));




        
        

        public int x;
        public int y;

        private Stopwatch _stopwatch27K = new Stopwatch();
        private Stopwatch _stopwatch3074 = new Stopwatch();
        private Stopwatch _stopwatch7500 = new Stopwatch();
        private Stopwatch _stopwatch30k = new Stopwatch();
        public TimeSpan Duration27K { get; private set; }
        public TimeSpan Duration3074 { get; private set; }

        public TimeSpan Duration7500 { get; private set; }
        public TimeSpan Duration30k { get; private set; }
        public int FpsValue { get; set; }

        public string? Pmessage;

        public string? kStatus { get; set; }

        public string? tStatus { get; set; }

        public string? sStatus { get; set; }

        public string? dStatus { get; set; }

        public string? lbltS; // label for 27k

        public string? lbltrS; // lable for 3074

        public string? lbltrx; // label for 7500

        public string? lbltrT; // label for 30k



        public bool isSoundOn = false;

        public bool isBufferOn;

        public bool togglePause;

        private bool _rulesEnabled3074;
        private bool _rulesEnabled27K;
        private bool _rulesEnabledDC;

        private bool _rulesEnabled7500;
        private bool _rulesEnabled30k;
        private Overlayklarity? overlayInstance;


        public event EventHandler? RulesEnabled27KChanged;

        
       

        /// <summary>
        /// Events for Stat tracking things
        /// </summary>
        public event EventHandler DataPoint1Incremented;
        public event EventHandler DataPoint2Incremented;
        public event EventHandler DataPoint3Incremented;
        public event EventHandler DataPoint4Incremented;
        public event EventHandler DataPoint5Incremented;
        public event EventHandler DataPoint6Incremented;

        // Constructor to initialize overlayklarity
       



        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void SetCursorPos(int x, int y);

        // Method to move the mouse to a specific position


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        public static void MouseDown()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }

        public static void MouseUp()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }


        protected virtual void OnDataPoint1Incremented()
        {
            DataPoint1Incremented?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnDataPoint2Incremented()
        {
            DataPoint2Incremented?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnDataPoint3Incremented()
        {
            DataPoint3Incremented?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnDataPoint4Incremented()
        {
            DataPoint4Incremented?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnDataPoint5Incremented()
        {
            DataPoint5Incremented?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDataPoint6Incremented()
        {
            DataPoint6Incremented?.Invoke(this, EventArgs.Empty);
        }

       

        public bool RulesEnabled3074
        {
            get { return _rulesEnabled3074; }
            set
            {

                if (_rulesEnabled3074 != value)
                {
                    _rulesEnabled3074 = value;
                    
                    if (_rulesEnabled3074)
                    {
                        if (isSoundOn)
                        {
                            player.Play();
                        }
                        _stopwatch3074.Start();
                    }
                    else
                    {
                        if (isSoundOn)
                        {
                            player2.Play();
                        }
                        _stopwatch3074.Stop();
                        Duration3074 += _stopwatch3074.Elapsed;
                        _stopwatch3074.Reset();
                        OnDuration3074Changed();
                    }
                    UpdateLabels();
                }
            }
        }

        public bool RulesEnabled7500
        {
            get { return _rulesEnabled7500; }
            set
            {
                if (_rulesEnabled7500 != value)
                {
                    _rulesEnabled7500 = value;
                    
                    if (_rulesEnabled7500)
                    {
                        if (isSoundOn)
                        {
                            player.Play();
                        }
                        _stopwatch7500.Start();
                    }
                    else
                    {
                        if (isSoundOn)
                        {
                            player2.Play();
                        }
                        _stopwatch7500.Stop();
                        Duration7500 += _stopwatch7500.Elapsed;
                        _stopwatch7500.Reset();
                        OnDuration7500Changed();
                    }
                    UpdateLabels();
                }
            }
        }

        public bool RulesEnabled30k
        {
            get { return _rulesEnabled30k; }
            set
            {
                if (_rulesEnabled30k != value)
                {
                    _rulesEnabled30k = value;
                    
                    if (_rulesEnabled30k)
                    {
                        if (isSoundOn)
                        {
                            player.Play();
                        }
                        _stopwatch30k.Start();
                    }
                    else
                    {
                        if (isSoundOn)
                        {
                            player2.Play();
                        }
                        _stopwatch30k.Stop();
                        Duration30k += _stopwatch30k.Elapsed;
                        _stopwatch30k.Reset();
                        OnDuration30KChanged();
                    }
                    UpdateLabels();
                }
            }
        }

        public bool RulesEnabled27K
        {
            get { return _rulesEnabled27K; }
            set
            {
                if (_rulesEnabled27K != value)
                {
                    _rulesEnabled27K = value;
                    OnRulesEnabled27KChanged();
                    if (_rulesEnabled27K)
                    {
                        if (isSoundOn)
                        {
                            player.Play();
                        }
                        _stopwatch27K.Start();
                    }
                    else
                    {
                        if (isSoundOn)
                        {
                            player2.Play();
                        }
                        _stopwatch27K.Stop();
                        Duration27K += _stopwatch27K.Elapsed;
                        _stopwatch27K.Reset();
                        OnDuration27KChanged();
                        
                    }
                    UpdateLabels();
                   
                }
            }
        }

        public event EventHandler? Duration27KChanged;
        public event EventHandler? Duration3074Changed;
        public event EventHandler? Duration7500Changed;
        public event EventHandler? Duration30KChanged;

        public event EventHandler? Pic27kChanged;

        protected virtual void OnPic27kChanged()
        {
            Pic27kChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnRulesEnabled27KChanged()
        {
            RulesEnabled27KChanged?.Invoke(this, EventArgs.Empty);
        }



        protected virtual void OnDuration27KChanged()
        {
            Duration27KChanged?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnDuration30KChanged()
        {
            Duration30KChanged?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnDuration3074Changed()
        {
            Duration3074Changed?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDuration7500Changed()
        {
            Duration7500Changed?.Invoke(this, EventArgs.Empty);
        }

        public bool RulesEnabledDC
        {
            get => _rulesEnabledDC;
            set
            {
                _rulesEnabledDC = value;
                UpdateLabels();
            }
        }




        // Events to notify when labels need to be updated
        public event Action<string> OnUpdateLbl27Status;
        public event Action<string> OnUpdateLbl3074Status;
        public event Action<string> OnUpdateLbl7500Status;
        public event Action<string> OnUpdateLbl30KStatus;

        // Importing the Windows API functions for key events
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        // Constants for keybd_event function
        const uint KEYEVENTF_KEYDOWN = 0x0000; // Key down flag
        const uint KEYEVENTF_KEYUP = 0x0002;   // Key up flag

        // Helper method to simulate key down
        private static new void KeyDown(byte key)
        {
            keybd_event(key, 0, KEYEVENTF_KEYDOWN, 0);
        }

        // Helper method to simulate key up
        private static new void KeyUp(byte key)
        {
            keybd_event(key, 0, KEYEVENTF_KEYUP, 0);
        }

        // Constructor to initialize with the form instance

        public void UpdateFps(int value)
        {
            FpsValue = 244 + (int)Math.Floor((value * 50) / 220.0); ;
            // Perform operations with FpsValue
            Console.WriteLine($"FPS Value Updated: {FpsValue}");
        }
        public void UpdatePboxText(string message)
        {
            Clipboard.Clear();
            Console.WriteLine("Pbox Text Cleared");
            Pmessage = null;
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine($"Pbox Text Updated: {message}");
                Pmessage = message;
                Clipboard.SetText(Pmessage);
            }
            else
            {
                Console.WriteLine("Pbox Text Cleared");
                Clipboard.Clear();
            }

        }




        private const uint MOUSEEVENTF_MOVE = 0x0001;
        private const uint MOUSEEVENTF_ABSOLUTE = 0x8000;



        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public uint type;
            public InputUnion u;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct InputUnion
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        const uint INPUT_MOUSE = 0;


        public static void MoveMouseTo(int x, int y)
        {
            // Get the current screen dimensions
            int screenWidth = GetSystemMetrics(0);
            int screenHeight = GetSystemMetrics(1);

            // Define the base resolution (1080p)
            int baseWidth = 1920;
            int baseHeight = 1080;

            // Calculate the scaling factors
            double scaleX = (double)screenWidth / baseWidth;
            double scaleY = (double)screenHeight / baseHeight;

            // Scale the coordinates
            int scaledX = (int)(x * scaleX);
            int scaledY = (int)(y * scaleY);

            // Move the mouse to the scaled coordinates
            SetCursorPos(scaledX, scaledY);

            INPUT[] inputs = new INPUT[1];
            inputs[0].type = INPUT_MOUSE;
            inputs[0].u.mi.dx = scaledX * (65536 / screenWidth); // Screen width
            inputs[0].u.mi.dy = scaledY * (65536 / screenHeight); // Screen height
            inputs[0].u.mi.dwFlags = MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE;

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        public async Task MoveMouseAcrossScreenAsync()
        {
            int screenWidth = GetSystemMetrics(0); // 0 is SM_CXSCREEN
            int screenHeight = GetSystemMetrics(1); // 1 is SM_CYSCREEN

            // Calculate the center of the screen
            int centerX = screenWidth / 2;
            int centerY = screenHeight / 2;

            x += 100;
            y += 100;

            MoveMouseTo(x, y);

        }

        // mouse locations
        // First slot 500, 370
        // Second slot 500, 500
        // Third slot 500, 650
        // amour slots
        // arm slot  1400, 370
        // class slot 1400, 800
        public async Task txtAFK(bool isafk, CancellationToken externalToken)
        {
            var combinedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(externalToken);
            var combinedToken = combinedTokenSource.Token;

            try
            {
                while (isafk && !combinedToken.IsCancellationRequested)
                {
                    await Task.Delay(5000, combinedToken);
                    await Task.Delay(10, combinedToken);
                    KeyDown(VKC.VK_I);
                    await Task.Delay(200, combinedToken);
                    KeyUp(VKC.VK_I);
                    await Task.Delay(500, combinedToken);
                    MoveMouseTo(1400, 800);
                    await Task.Delay(200, combinedToken);
                    MoveMouseTo(1500, 800);
                    await Task.Delay(300, combinedToken);
                    MouseDown();
                    await Task.Delay(300, combinedToken);
                    MouseUp();
                    await Task.Delay(300, combinedToken);
                    KeyDown(VKC.VK_I);
                    await Task.Delay(200, combinedToken);
                    KeyUp(VKC.VK_I);

                    await Task.Delay(20000, combinedToken);

                    if (!isafk)
                    {
                        break;
                    }
                }
            }
            catch (TaskCanceledException)
            {
                // Handle task cancellation
            }
        }



        public async void txt7500HK()
        {
            if (sStatus == "in/out")
            {
                if (RulesEnabled7500)  // Check if the rules are enabled
                {
                    RulesEnabled7500 = false;
                    await Disable7500();

                }
                else
                {
                    RulesEnabled7500 = true;
                    await Enable7500();

                }
            }
            else if (sStatus == "in")
            {
                if (RulesEnabled7500)  // Check if the rules are enabled
                {
                    RulesEnabled7500 = false;
                    await Disable7500();

                }
                else
                {
                    RulesEnabled7500 = true;
                    await Enable7500();

                }

            }
            else if (sStatus == "out")
            {
                if (RulesEnabled7500)  // Check if the rules are enabled
                {
                    RulesEnabled7500 = false;
                    await Disable7500();

                }
                else
                {
                    RulesEnabled7500 = true;
                    await Enable7500();

                }
            }
        }



        public async void txt30kHK()
        {
            if (dStatus == "in/out")
            {
                if (RulesEnabled30k)  // Check if the rules are enabled
                {
                    RulesEnabled30k = false;
                    await Disable30k();
                }
                else
                {
                    RulesEnabled30k = true;
                    await Enable30k();
                }
            }
            else if (dStatus == "in")
            {
                if (RulesEnabled30k)  // Check if the rules are enabled
                {
                    RulesEnabled30k = false;
                    await Disable30k();
                }
                else
                {
                    RulesEnabled30k = true;
                    await Enable30k();
                }
            }
            else if (dStatus == "out")
            {
                if (RulesEnabled30k)  // Check if the rules are enabled
                {
                    RulesEnabled30k = false;
                    await Disable30k();
                }
                else
                {
                    RulesEnabled30k = true;
                    await Enable30k();
                }
            }
        }


        public async void txtMulti()
        {


            

            

            txt3074HK();
            txt27HK();

            await Task.Delay(300);
            MouseDown();
            await Task.Delay(600);
            MouseUp();
            await Task.Delay(1050);

            txt27HK();
            txt3074HK();
            MouseUp();

            OnDataPoint6Incremented();

            //Noob likes Futa and Cake Farts

        }


        public async void txtPboxHotKey()
        {

            // Sequence logic implementation

            // Send {Enter down}
            KeyDown(VKC.VK_ENTER);
            await Task.Delay(10);

            // Send {Enter up}
            KeyUp(VKC.VK_ENTER);
            await Task.Delay(10);
            KeyDown(VKC.VK_BACK);
            KeyUp(VKC.VK_BACK);
            await Task.Delay(10);



            if (Pmessage != null)
            {
                KeyDown(VKC.VK_RSHIFT);
                KeyDown(VKC.VK_INSERT);
                await Task.Delay(10);
                KeyUp(VKC.VK_RSHIFT);
                KeyUp(VKC.VK_INSERT);
                await Task.Delay(10);
            }
            else
            {
                KeyDown(VKC.VK_RSHIFT);
                KeyDown(VKC.VK_P);
                await Task.Delay(10);
                KeyUp(VKC.VK_P);
                KeyUp(VKC.VK_RSHIFT);
                await Task.Delay(10);
            }


            // Send {Enter down}
            KeyDown(VKC.VK_ENTER);
            await Task.Delay(10);

            // Send {Enter up}
            KeyUp(VKC.VK_ENTER);
            await Task.Delay(10);

            // Send {N down}
            KeyDown(VKC.VK_N);
            await Task.Delay(FpsValue);

            // Suspend the process
            Process_Suspend("focused");
            await Task.Delay(1300);

            // Resume the process
            Process_Resume("focused");

            // Send {N down}
            KeyDown(VKC.VK_N);
            await Task.Delay(325);

            // Send {N up}
            KeyUp(VKC.VK_N);

            OnDataPoint5Incremented();
        }

        public async void txtPauseHotKey()
        {

            if (togglePause = !togglePause) // Toggle the state
            {
                // Update the GUI to show "ON" status
                OnDataPoint1Incremented();

                // Suspend the "destiny2.exe" process
                Process_Suspend("focused");

                // Play the sound cue for activation
                if (isSoundOn)
                {
                    player.Play();
                }

            }
            else
            {
                // Update the GUI to show "OFF" status


                // Resume the "destiny2.exe" process
                Process_Resume("focused");

                // Play the sound cue for deactivation
                if (isSoundOn)
                {
                    player2.Play();
                }
            }
        }



        public async void txt27HK()
        {
            if (kStatus == "in/out")
            {
                if (RulesEnabled27K)  // Check if the rules are enabled
                {
                    RulesEnabled27K = false;
                    await Disable27K();
                    
                }
                else
                {
                    RulesEnabled27K = true;
                    await Enable27K();
                    
                }
            }
            else if (kStatus == "in")
            {
                if (RulesEnabled27K)  // Check if the rules are enabled
                {
                    RulesEnabled27K = false;
                    await Disable27K();
                }
                else
                {
                    RulesEnabled27K = true;
                    await Enable27K();
                }
            }
            else if (kStatus == "out")
            {
                if (RulesEnabled27K)  // Check if the rules are enabled
                {
                    RulesEnabled27K = false;
                    await Disable27K();
                }
                else
                {
                    RulesEnabled27K = true;
                    await Enable27K();
                }
            }
        }

        public async void txt3074HK()
        {
            if (tStatus == "in/out")
            {
                if (RulesEnabled3074)  // Check if the rules are enabled
                {
                    RulesEnabled3074 = false;
                    await Disable3074();
                }
                else
                {
                    RulesEnabled3074 = true;
                    await Enable3074();
                }
            }
            else if (tStatus == "in")
            {
                if (RulesEnabled3074)  // Check if the rules are enabled
                {
                    RulesEnabled3074 = false;
                    await Disable3074();
                }
                else
                {
                    RulesEnabled3074 = true;
                    await Enable3074();
                }
            }
            else if (tStatus == "out")
            {
                if (RulesEnabled3074)  // Check if the rules are enabled
                {
                    RulesEnabled3074 = false;
                    await Disable3074();

                }
                else
                {
                    RulesEnabled3074 = true;
                    await Enable3074();
                }
            }
        }

        public async Task txtFBHK()
        {

            await Task.Run(async () =>
            {
                // Press and hold "Q"
                KeyDown(VKC.VK_Q);

                await Task.Delay(190);
                KeyUp(VKC.VK_Q);
                await Task.Delay(10);


                // Press "N" and wait
                KeyDown(VKC.VK_N);
                await Task.Delay(450);
                KeyUp(VKC.VK_N);

                // Press "A" and wait
                KeyDown(VKC.VK_A);
                await Task.Delay(500);
                KeyDown(VKC.VK_SPACE);
                await Task.Delay(10);
                KeyUp(VKC.VK_SPACE);
                KeyUp(VKC.VK_A);

                OnDataPoint4Incremented();
            });

        }

        public async Task SoloScript()
        {
            await Task.Run(async () =>
            {
                if (RulesEnabled27K)  // Check if the rules are enabled
                {
                    
                    RulesEnabled27K = false;
                    await Disable27K();

                    if (isSoundOn)
                    {
                       
                     player.Play();
                      
                    }
                }
                else
                {

                    MessageBox.Show("Solo script Started");
                    RulesEnabled27K = true;
                    await Enable27K();

                    if (isSoundOn)
                    {
                        player2.Play();
                    }
                    OnDataPoint2Incremented();

                }
            });



        }

        public async void DCScript()
        {
            if (isSoundOn)
            {
                player.Play();
            }
            await EnableDC();
            
            await Task.Delay(500);
            
            await DisableDC();
            if (isSoundOn)
            {
                player2.Play();
            }
            OnDataPoint3Incremented();

        }
        public async Task EnableDC()
        {
            await Task.Run(() =>
            {

                RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-30-tcp-in\" profile=any remoteport=30000-30009 protocol=tcp interfacetype=any");
                
                RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-30-tcp-out\" profile=any remoteport=30000-30009 protocol=tcp interfacetype=any");
                
            });

        }
        public async Task DisableDC()
        {
            await Task.Run(() =>
            {
                RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-30-tcp-in\"");
                
                RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-30-tcp-out\"");
                
            });
        }

        
        public async Task Enable3074()
        {
            await Task.Run(() =>
            {
                
                WinDiverts.Start3074(RulesEnabled3074, tStatus, isBufferOn);
           
            });

        }

        public async Task Enable30k()
        {
            await Task.Run(() =>
            {

                WinDiverts.Start30k(RulesEnabled30k, dStatus, isBufferOn);

            });

        }

        public async Task Disable30k()
        {
            await Task.Run(() =>
            {
                WinDiverts.Start30k(RulesEnabled30k, dStatus, isBufferOn);
                return Task.CompletedTask;
            });
        }
        public async Task Enable7500()
        {
            await Task.Run(() =>
            {
                WinDiverts.Start7500(RulesEnabled7500, sStatus, isBufferOn);
                
            });
        }

        public async Task Disable7500()
        {
            await Task.Run(() =>
            {
                WinDiverts.Start7500(RulesEnabled7500, sStatus, isBufferOn);
                return Task.CompletedTask;
            });
        }
        public async Task Disable3074()
        {
            await Task.Run(() =>
            {
                
                WinDiverts.Start3074(RulesEnabled3074, tStatus, isBufferOn);
                return Task.CompletedTask;
            });
        }

        public async Task Enable27K()
        {
            await Task.Run(() =>
            {
                WinDiverts.Start27K(RulesEnabled27K, kStatus, isBufferOn);
                

            });
        }

        // Method to disable firewall rules for 27k
        public async Task Disable27K()
        {
            await Task.Run(() =>
            {
                WinDiverts.Start27K(RulesEnabled27K, kStatus, isBufferOn);
                return Task.CompletedTask;
            });


        }
        private void RunCommand(string command)
        {
            try
            {
                ProcessStartInfo pro = new ProcessStartInfo("cmd.exe", "/c " + command);
                pro.RedirectStandardOutput = true;
                pro.UseShellExecute = false;
                pro.CreateNoWindow = true;
                Process process = Process.Start(pro);
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error running command: " + ex.Message);
            }
        }

        // Method to play the sound cues
        public void PlaySoundCue(bool isOn)
        {

            Console.Beep(isOn ? 523 : 750, 100); // Higher tone for "ON"
            Console.Beep(isOn ? 750 : 523, 100); // Lower tone for "OFF"

        }

        private void UpdateLabels()
        {
            lbltS = RulesEnabled27K ? "ON" : "OFF";
            lbltrS = RulesEnabled3074 ? "ON" : "OFF";
            lbltrx = RulesEnabled7500 ? "ON" : "OFF";
            lbltrT = RulesEnabled30k ? "ON" : "OFF";
            OnUpdateLbl27Status?.Invoke(lbltS);
            OnUpdateLbl3074Status?.Invoke(lbltrS);
            OnUpdateLbl7500Status?.Invoke(lbltrx);
            OnUpdateLbl30KStatus?.Invoke(lbltrT);
            



        }
        
    }
}
