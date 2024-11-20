using ProcessManagement;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;

namespace PeteTech
{
    internal class Macros : ISuspend
    {

        

        public bool isSoundOn = false;

        public bool isBufferOn = false;

        public int pBoxDelay;

        public bool togglePause;
        public bool RulesEnabled3074 { get; set; } = false;
        public bool RulesEnabled27K { get; set; } = false;

        


        // Importing the Windows API functions for key events
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        // Constants for keybd_event function
        const uint KEYEVENTF_KEYDOWN = 0x0000; // Key down flag
        const uint KEYEVENTF_KEYUP = 0x0002;   // Key up flag
        const byte VK_Q = 0x51;                 // Virtual key code for "Q"
        const byte VK_N = 0x4E;                 // Virtual key code for "N"
        const byte VK_A = 0x41;                 // Virtual key code for "A"
        const byte VK_SPACE = 0x20;             // Virtual key code for Spacebar
        const byte VK_ENTER = 0x0D;             // Virtual key code for Enter
        const byte VK_P = 0x50;                 // Virtual key code for "P"

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

        // Constants for OpenProcess and other API calls
        const int PROCESS_SUSPEND_RESUME = 0x0800;
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int PROCESS_VM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_TERMINATE = 0x0001;

        // Thread suspend/resume constants
        const int THREAD_SUSPEND_RESUME = 0x0002;

        // Constructor to initialize with the form instance
        

        public void txtPboxHotKey()
        {
            txtPboxMacro(120);
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

        public void txt3074HK()
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

        public void txtFBHK()
        {
            // Press and hold "Q"
            KeyDown(VK_Q);
            Thread.Sleep(200);
            KeyUp(VK_Q);

            // Press "N" and wait
            KeyDown(VK_N);
            Thread.Sleep(450);
            KeyUp(VK_N);

            // Press "A" and wait
            KeyDown(VK_A);
            Thread.Sleep(425);
            KeyUp(VK_A);

            // Press "Space" and "A"
            KeyDown(VK_SPACE);
            KeyDown(VK_A);
            Thread.Sleep(200);
            KeyUp(VK_A);
            KeyUp(VK_SPACE);
        }

        public void SoloScript()
        {
            MessageBox.Show("Solo script pressed!");
        }

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

        // Renamed method to txtPboxMacro
        public void txtPboxMacro(int delayPBox)
        {
            // Simulate Enter key down and up
            KeyDown(VK_ENTER);
            Thread.Sleep(10);
            KeyUp(VK_ENTER);
            Thread.Sleep(10);

            // Simulate P key down and up
            KeyDown(VK_P);
            Thread.Sleep(10);
            KeyUp(VK_P);
            Thread.Sleep(10);

            // Simulate Enter key down and up again
            KeyDown(VK_ENTER);
            Thread.Sleep(10);
            KeyUp(VK_ENTER);
            Thread.Sleep(10);

            // Simulate N key down and hold for delayPBox
            KeyDown(VK_N);
            Thread.Sleep(delayPBox);  // Hold for the custom delay
            Process_Suspend("focused");  // Suspend the process
            Thread.Sleep(1300);  // Sleep for the specified duration
            Process_Resume("focused");  // Resume the process

            // Simulate N key up after delay
            KeyUp(VK_N);
            Thread.Sleep(325);

            // Simulate N key down and up again
            KeyDown(VK_N);
            Thread.Sleep(325);
            KeyUp(VK_N);
        }

        // Method to suspend a process
        public void SuspendProcess(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                var process = processes[0];
                IntPtr processHandle = OpenProcess(PROCESS_SUSPEND_RESUME | PROCESS_QUERY_INFORMATION, false, process.Id);
                if (processHandle != IntPtr.Zero)
                {
                    // Suspend all threads of the process
                    foreach (ProcessThread thread in process.Threads)
                    {
                        IntPtr threadHandle = OpenThread(THREAD_SUSPEND_RESUME, false, thread.Id);
                        if (threadHandle != IntPtr.Zero)
                        {
                            SuspendThread(threadHandle);
                            CloseHandle(threadHandle);
                        }
                    }
                    CloseHandle(processHandle);
                }
            }
        }

        // Method to resume a suspended process
        public void ResumeProcess(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                var process = processes[0];
                IntPtr processHandle = OpenProcess(PROCESS_SUSPEND_RESUME | PROCESS_QUERY_INFORMATION, false, process.Id);
                if (processHandle != IntPtr.Zero)
                {
                    // Resume all threads of the process
                    foreach (ProcessThread thread in process.Threads)
                    {
                        IntPtr threadHandle = OpenThread(THREAD_SUSPEND_RESUME, false, thread.Id);
                        if (threadHandle != IntPtr.Zero)
                        {
                            ResumeThread(threadHandle);
                            CloseHandle(threadHandle);
                        }
                    }
                    CloseHandle(processHandle);
                }
            }
        }
        public void Enable3074()
        {
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-3074-tcp-in\" profile=any remoteport=3074 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-3074-udp-in\" profile=any remoteport=3074 protocol=udp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-3074-tcp-out\" profile=any remoteport=3074 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-3074-udp-out\" profile=any remoteport=3074 protocol=udp interfacetype=any");

            
        }

        public void Disable3074()
        {
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-3074-tcp-in\"");
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-3074-udp-in\"");
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-3074-tcp-out\"");
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-3074-udp-out\"");
        }

        public void Enable3074IN()
        {
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-3074-tcp-in\" profile=any remoteport=3074 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-3074-udp-in\" profile=any remoteport=3074 protocol=udp interfacetype=any");
        }
       
        public void Enable3074OUT()
        {
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-3074-tcp-out\" profile=any remoteport=3074 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-3074-udp-out\" profile=any remoteport=3074 protocol=udp interfacetype=any");
        }
    

       
    


        public void Enable27K()
        {
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-27k-tcp-out\" profile=any remoteport=27015-27200 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-27k-udp-out\" profile=any remoteport=27015-27200 protocol=udp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-27k-tcp-in\" profile=any remoteport=27015-27200 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-27k-udp-in\" profile=any remoteport=27015-27200 protocol=udp interfacetype=any");
           
        }

        // Method to disable firewall rules for 27k
        public void Disable27K()
        {
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-27k-tcp-out\"");
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-27k-udp-out\"");
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-27k-tcp-in\"");
            RunCommand("netsh advfirewall firewall delete rule name=\"d2limit-27k-udp-in\"");
        }

        public void Enable27KIN()
        {
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-27k-tcp-in\" profile=any remoteport=27015-27200 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=in action=block name=\"d2limit-27k-udp-in\" profile=any remoteport=27015-27200 protocol=udp interfacetype=any");
           
        }

        public void Enable27KOUT()
        {
            
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-27k-tcp-out\" profile=any remoteport=27015-27200 protocol=tcp interfacetype=any");
            RunCommand("netsh advfirewall firewall add rule dir=out action=block name=\"d2limit-27k-udp-out\" profile=any remoteport=27015-27200 protocol=udp interfacetype=any");
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
        private void PlaySoundCue(bool isOn)
        {
            Console.Beep(isOn ? 523 : 750, 100); // Higher tone for "ON"
            Console.Beep(isOn ? 750 : 523, 100); // Lower tone for "OFF"
        }
    }
}
