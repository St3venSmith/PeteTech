using ProcessManagement;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PeteTech
{
    internal class Macros : ISuspend
    {


        public int FpsValue { get; set; }

        public string Pmessage;

        public string kStatus { get; set; }

        public string tStatus { get; set; }

        public string lbltS; // label for 27k

        public string lbltrS; // lable for 3074

        public bool isSoundOn = false;

        public bool isBufferOn = false;

        public bool togglePause;

        private bool _rulesEnabled3074;
        private bool _rulesEnabled27K;

        public bool RulesEnabled3074
        {
            get => _rulesEnabled3074;
            set
            {
                _rulesEnabled3074 = value;
                UpdateLabels();
            }
        }

        public bool RulesEnabled27K
        {
            get => _rulesEnabled27K;
            set
            {
                _rulesEnabled27K = value;
                UpdateLabels();
            }
        }

        // Events to notify when labels need to be updated
        public event Action<string> OnUpdateLbl27Status;
        public event Action<string> OnUpdateLbl3074Status;

        // Importing the Windows API functions for key events
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        // Constants for keybd_event function
        const uint KEYEVENTF_KEYDOWN = 0x0000; // Key down flag
        const uint KEYEVENTF_KEYUP = 0x0002;   // Key up flag


        // Importing necessary Windows API functions for process manipulation
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SuspendThread(IntPtr hThread);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ResumeThread(IntPtr hThread);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenThread(int dwDesiredAccess, bool bInheritHandle, int dwThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);



        // Helper method to simulate key down
        private void KeyDown(byte key)
        {
            keybd_event(key, 0, KEYEVENTF_KEYDOWN, 0);
        }

        // Helper method to simulate key up
        private void KeyUp(byte key)
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
            Pmessage = message;
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


            if (Pmessage != null)
            {
                SendKeys.Send(Pmessage);
                await Task.Delay(20);
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
        }

        public void txtPauseHotKey()
        {
            if (togglePause = !togglePause) // Toggle the state
            {
                // Update the GUI to show "ON" status


                // Suspend the "destiny2.exe" process
                Process_Suspend("focused");

                // Play the sound cue for activation
                if (isSoundOn)
                {
                    PlaySoundCue(true);
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
                    PlaySoundCue(false);
                }
            }
        }



        public void txt27HK()
        {
            if (kStatus == "in/out")
            {
                if (RulesEnabled27K)  // Check if the rules are enabled
                {
                    Disable27K();
                    RulesEnabled27K = false;
                    if (isSoundOn)
                    {
                        PlaySoundCue(false);
                    }
                }
                else
                {
                    Enable27K();
                    RulesEnabled27K = true;
                    if (isSoundOn)
                    {
                        PlaySoundCue(true);
                    }
                }
            }
            else if (kStatus == "in")
            {
                if (RulesEnabled27K)  // Check if the rules are enabled
                {
                    Disable27K();
                    RulesEnabled27K = false;
                    if (isSoundOn)
                    {
                        PlaySoundCue(false);
                    }
                }
                else
                {
                    Enable27KIN();
                    RulesEnabled27K = true;
                    if (isSoundOn)
                    {
                        PlaySoundCue(true);
                    }
                }

            }
            else if (kStatus == "out")
            {
                if (RulesEnabled27K)  // Check if the rules are enabled
                {
                    Disable27K();
                    RulesEnabled27K = false;
                    if (isSoundOn)
                    {
                        PlaySoundCue(false);
                    }
                }
                else
                {
                    Enable27KOUT();
                    RulesEnabled27K = true;
                    if (isSoundOn)
                    {
                        PlaySoundCue(true);
                    }
                }

            }
        }

        public void txt3074HK()
        {
            if (tStatus == "in/out")
            {
                if (RulesEnabled3074)  // Check if the rules are enabled
                {
                    Disable3074();
                    RulesEnabled3074 = false;
                    if (isSoundOn)
                    {
                        PlaySoundCue(false);
                    }
                }
                else
                {
                    Enable3074();
                    RulesEnabled3074 = true;
                    if (isSoundOn)
                    {
                        PlaySoundCue(true);
                    }
                }
            }
            else if (tStatus == "in")
            {
                if (RulesEnabled3074)  // Check if the rules are enabled
                {
                    Disable3074();
                    RulesEnabled3074 = false;
                    if (isSoundOn)
                    {
                        PlaySoundCue(false);
                    }

                }
                else
                {
                    Enable3074IN();
                    RulesEnabled3074 = true;
                    if (isSoundOn)
                    {
                        PlaySoundCue(true);
                    }
                }
            }
            else if (tStatus == "out")
            {
                if (RulesEnabled3074)  // Check if the rules are enabled
                {
                    Disable3074();
                    RulesEnabled3074 = false;
                    if (isSoundOn)
                    {
                        PlaySoundCue(false);
                    }

                }
                else
                {
                    Enable3074OUT();
                    RulesEnabled3074 = true;
                    if (isSoundOn)
                    {
                        PlaySoundCue(true);
                    }
                }
            }
        }

        public async void txtFBHK()
        {
            // Press and hold "Q"
            KeyDown(VKC.VK_Q);
            await Task.Delay(200);
            KeyUp(VKC.VK_Q);

            // Press "N" and wait
            KeyDown(VKC.VK_N);
            await Task.Delay(450);
            KeyUp(VKC.VK_N);

            // Press "A" and wait
            KeyDown(VKC.VK_A);
            await Task.Delay(425);




            // Press "Space" and "A"
            KeyDown(VKC.VK_Q);
            await Task.Delay(10);
            KeyDown(VKC.VK_SPACE);
            KeyUp(VKC.VK_A);
            KeyUp(VKC.VK_Q);

        }

        public void SoloScript()
        {
            if (RulesEnabled27K)  // Check if the rules are enabled
            {
                MessageBox.Show("Solo script Stopped");
                Disable27K();
                RulesEnabled27K = false;
                if (isSoundOn)
                {
                    PlaySoundCue(false);
                }
            }
            else
            {
                MessageBox.Show("Solo script Started");
                Enable27K();
                RulesEnabled27K = true;
                if (isSoundOn)
                {
                    PlaySoundCue(true);
                }
            }

        }







        public async void Enable3074()
        {
            Random rand = new Random();
            int randUnlimit = rand.Next(300, 501);  // Random delay before enabling the rules
            int randLimit = rand.Next(5000, 7000);  // Random delay for how long the rules are enabled

            lbltrS = "ON";

            // Add rules to block incoming and outgoing traffic on port 3074
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-3074-tcp-in\" profile=any remoteport=3074 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-3074-udp-in\" profile=any remoteport=3074 protocol=udp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-3074-tcp-out\" profile=any remoteport=3074 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-3074-udp-out\" profile=any remoteport=3074 protocol=udp interfacetype=any");

            // Start the loop that will enable/disable the rules while isBufferOn is true
            while (isBufferOn)
            {
                // Wait for the random amount of time before enabling the firewall rules
                await Task.Delay(randUnlimit);  // Delay before enabling

                // Enable the firewall rules
                Console.WriteLine("3074 Status: ON");
                RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-3074-tcp-in\" profile=any remoteport=3074 protocol=tcp interfacetype=any");
                RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-3074-udp-in\" profile=any remoteport=3074 protocol=udp interfacetype=any");
                RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-3074-tcp-out\" profile=any remoteport=3074 protocol=tcp interfacetype=any");
                RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-3074-udp-out\" profile=any remoteport=3074 protocol=udp interfacetype=any");

                lbltrS = "ON";

                // Wait for the random duration before disabling the firewall rules
                await Task.Delay(randLimit);  // Delay before disabling

                // Disable the firewall rules
                Console.WriteLine("3074 Status: OFF");
                Disable3074();

                lbltrS = "OFF";

                // If the buffer is turned off, stop the loop
                if (!isBufferOn || !RulesEnabled3074)
                {
                    Disable3074();
                    break;
                }

              
            }
        }

        public void Disable3074()
        {
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-3074-tcp-in\"");
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-3074-udp-in\"");
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-3074-tcp-out\"");
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-3074-udp-out\"");
        }

        public async void Enable3074IN()
        {
            Random rand = new Random();
            int randUnlimit = rand.Next(300, 501);  // Random delay before enabling the rules
            int randLimit = rand.Next(5000, 7000);  // Random delay for how long the rules are enabled

            lbltrS = "ON";

            // Add rules to block incoming traffic on port 3074
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-3074-tcp-in\" profile=any remoteport=3074 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-3074-udp-in\" profile=any remoteport=3074 protocol=udp interfacetype=any");

            // Start the loop that will enable the rules while isBufferOn is true
            while (isBufferOn)
            {
                // Wait for the random amount of time before enabling the rules
                await Task.Delay(randUnlimit);  // Delay before enabling

                // Enable the incoming firewall rules
                Console.WriteLine("3074 IN Status: ON");
                RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-3074-tcp-in\" profile=any remoteport=3074 protocol=tcp interfacetype=any");
                RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-3074-udp-in\" profile=any remoteport=3074 protocol=udp interfacetype=any");

                lbltrS = "ON";

                // Wait for the random duration before disabling the firewall rules
                await Task.Delay(randLimit);  // Delay before disabling

                // Disable the incoming firewall rules
                Console.WriteLine("3074 IN Status: OFF");
                lbltrS = "OFF";
                Disable3074();

                // If the buffer is turned off, stop the loop
                if (!isBufferOn || !RulesEnabled3074)
                {
                    Disable3074();
                    break;
                }

               
            }
        }


        public async void Enable3074OUT()
        {
            Random rand = new Random();
            int randUnlimit = rand.Next(300, 501);  // Random delay before enabling the rules
            int randLimit = rand.Next(5000, 7000);  // Random delay for how long the rules are enabled


            lbltrS = "ON";
            // Add rules to block outgoing traffic on port 3074
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-3074-tcp-out\" profile=any remoteport=3074 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-3074-udp-out\" profile=any remoteport=3074 protocol=udp interfacetype=any");

            // Start the loop that will enable the rules while isBufferOn is true
            while (isBufferOn)
            {
                // Wait for the random amount of time before enabling the rules
                await Task.Delay(randUnlimit);  // Delay before enabling

                lbltrS = "ON";

                // Enable the outgoing firewall rules
                Console.WriteLine("3074 OUT Status: ON");
                RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-3074-tcp-out\" profile=any remoteport=3074 protocol=tcp interfacetype=any");
                RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-3074-udp-out\" profile=any remoteport=3074 protocol=udp interfacetype=any");

                // Wait for the random duration before disabling the firewall rules
                await Task.Delay(randLimit);  // Delay before disabling

                lbltrS = "OFF";

                // Disable the outgoing firewall rules
                Console.WriteLine("3074 OUT Status: OFF");
                Disable3074();


                // If the buffer is turned off, stop the loop
                if (!isBufferOn || !RulesEnabled3074)
                {
                    Disable3074();
                    break;
                }

            }
        }







        public async void Enable27K()
        {
            Random rand = new Random();
            int randUnlimit = rand.Next(300, 501);  // Random delay before enabling the rules
            int randLimit = rand.Next(3000, 4000);  // Random delay for how long the rules are enabled

            lbltS = "ON";

            // Add rules to block incoming and outgoing traffic on port range 27015-27200
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-27k-tcp-out\" profile=any remoteport=27015-27200 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-27k-udp-out\" profile=any remoteport=27015-27200 protocol=udp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-27k-tcp-in\" profile=any remoteport=27015-27200 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-27k-udp-in\" profile=any remoteport=27015-27200 protocol=udp interfacetype=any");

            // Start the loop that will enable the rules while isBufferOn is true
            while (isBufferOn)
            {
                // Wait for the random amount of time before enabling the rules
                await Task.Delay(randUnlimit);  // Delay before enabling

                lbltS = "ON";

                // Enable the firewall rules (outbound and inbound)
                Console.WriteLine("27k Status: ON");
                RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-27k-tcp-out\" profile=any remoteport=27015-27200 protocol=tcp interfacetype=any");
                RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-27k-udp-out\" profile=any remoteport=27015-27200 protocol=udp interfacetype=any");
                RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-27k-tcp-in\" profile=any remoteport=27015-27200 protocol=tcp interfacetype=any");
                RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-27k-udp-in\" profile=any remoteport=27015-27200 protocol=udp interfacetype=any");

                // Wait for the random duration before disabling the firewall rules
                await Task.Delay(randLimit);  // Delay before disabling

                lbltS = "OFF";

                // Disable the firewall rules (outbound and inbound)
                Console.WriteLine("27k Status: OFF");
                Disable27K();

                // If the buffer is turned off, stop the loop
                if (!isBufferOn || !RulesEnabled27K)
                {
                    Disable27K();
                    break;
                }

                // Optionally, add another random delay before starting the next cycle
                // Delay before next cycle
            }
        }

        // Method to disable firewall rules for 27k
        public void Disable27K()
        {
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-27k-tcp-out\"");
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-27k-udp-out\"");
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-27k-tcp-in\"");
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-27k-udp-in\"");
        }

        public async void Enable27KIN()
        {
            Random rand = new Random();
            int randUnlimit = rand.Next(300, 501);  // Random delay before enabling the rules
            int randLimit = rand.Next(5000, 7000);  // Random delay for how long the rules are enabled

            lbltS = "ON";

            // Add rules to block incoming traffic on port range 27015-27200
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-27k-tcp-in\" profile=any remoteport=27015-27200 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-27k-udp-in\" profile=any remoteport=27015-27200 protocol=udp interfacetype=any");

            // Start the loop that will enable the rules while isBufferOn is true
            while (isBufferOn)
            {
                // Wait for the random amount of time before enabling the rules
                await Task.Delay(randUnlimit);  // Delay before enabling

                lbltS = "ON";

                // Enable the incoming traffic firewall rules
                Console.WriteLine("27k IN Status: ON");
                RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-27k-tcp-in\" profile=any remoteport=27015-27200 protocol=tcp interfacetype=any");
                RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-27k-udp-in\" profile=any remoteport=27015-27200 protocol=udp interfacetype=any");

                // Wait for the random duration before disabling the firewall rules
                await Task.Delay(randLimit);  // Delay before disabling

                lbltS = "OFF";

                // Disable the incoming traffic firewall rules
                Console.WriteLine("27k IN Status: OFF");
                Disable27K();

                // If the buffer is turned off, stop the loop
                if (!isBufferOn || !RulesEnabled27K)
                {
                    Disable27K();
                    break;
                }

            }
        }


        public async void Enable27KOUT()
        {
            Random rand = new Random();
            int randUnlimit = rand.Next(300, 501);  // Random delay before enabling the rules
            int randLimit = rand.Next(3000, 4000);  // Random delay for how long the rules are enabled



            lbltS = "ON";

            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-27k-tcp-out\" profile=any remoteport=27015-27200 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-27k-udp-out\" profile=any remoteport=27015-27200 protocol=udp interfacetype=any");

            // Start the loop that will enable the rules while isBufferOn is true
            while (isBufferOn)
            {
                // Wait for the random amount of time before enabling the rules
                await Task.Delay(randUnlimit);  // Delay before enabling

                lbltS = "ON";

                // Add rules to block outgoing traffic on port range 27015-27200
                Console.WriteLine("27k OUT Status: ON");
                RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-27k-tcp-out\" profile=any remoteport=27015-27200 protocol=tcp interfacetype=any");
                RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-27k-udp-out\" profile=any remoteport=27015-27200 protocol=udp interfacetype=any");

                // Wait for the random duration before disabling the firewall rules
                await Task.Delay(randLimit);  // Delay before disabling

                lbltS = "OFF";

                // Disable the outgoing traffic firewall rules
                Console.WriteLine("27k OUT Status: OFF");
                Disable27K();

                // If the buffer is turned off, stop the loop
                if (!isBufferOn || !RulesEnabled27K)
                {
                    Disable27K();
                    break;
                }

               
            }
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
            OnUpdateLbl27Status?.Invoke(lbltS);
            OnUpdateLbl3074Status?.Invoke(lbltrS);
        }

    }
}
