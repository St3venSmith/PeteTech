using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace PeteTech
{
    internal class Macros
    {
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

        public void txtPboxHotKey()
        {
            MessageBox.Show("Hotkey for Pbox pressed!");
        }

        public void txtPauseHotKey()
        {
            MessageBox.Show("Hotkey for Pause pressed!");
        }

        public void txt27HK()
        {
            MessageBox.Show("Hotkey for 27k pressed!");
        }

        public void txt3074HK()
        {
            MessageBox.Show("Hotkey for 3074 pressed!");
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
        public void txtPboxMacro()
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
            Thread.Sleep(1300);  // Hold for the custom delay
            SuspendProcess("BlackOps3.exe");
            Thread.Sleep(1300);  // Sleep for the specified duration
            ResumeProcess("BlackOps3.exe");

            // Simulate N key up after delay
            KeyUp(VK_N);
            Thread.Sleep(325);

            // Simulate N key down and up again
            KeyDown(VK_N);
            Thread.Sleep(325);
            KeyUp(VK_N);
        }

        // Method to suspend a process
        private void SuspendProcess(string processName)
        {
            Process process = Process.GetProcessesByName(processName).FirstOrDefault();
            if (process != null)
            {
                IntPtr handle = process.Handle;
                // Suspend the process (this may require administrator privileges)
                NtSuspendProcess(handle);
            }
        }

        // Method to resume a suspended process
        private void ResumeProcess(string processName)
        {
            Process process = Process.GetProcessesByName(processName).FirstOrDefault();
            if (process != null)
            {
                IntPtr handle = process.Handle;
                // Resume the process (this may require administrator privileges)
                NtResumeProcess(handle);
            }
        }

        // Importing suspend and resume process functions (Advanced, require P/Invoke)
        [DllImport("ntdll.dll")]
        public static extern int NtSuspendProcess(IntPtr processHandle);

        [DllImport("ntdll.dll")]
        public static extern int NtResumeProcess(IntPtr processHandle);
    }
}
