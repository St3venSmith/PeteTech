using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ProcessManagement
{
    internal class ISuspend : Form
    {



        // Constants for process access rights
        private const uint PROCESS_ALL_ACCESS = 0x1F0FFF;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSuspendProcess(IntPtr processHandle);

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtResumeProcess(IntPtr processHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        /// <summary>
        /// Suspends a process by its PID or name, or the currently focused window.
        /// </summary>
        /// <param name="pidOrName">The PID or process name. Pass "focused" to suspend the focused window.</param>
        public static void Process_Suspend(string pidOrName)
        {
            int pid = pidOrName.ToLower() == "focused" ? GetFocusedWindowPID() : GetProcessId(pidOrName);
            if (pid == -1)
            {
                Console.WriteLine("Process not found.");
                return;
            }

            IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, pid);
            if (processHandle == IntPtr.Zero)
            {
                Console.WriteLine("Failed to open process.");
                return;
            }

            int result = NtSuspendProcess(processHandle);
            if (result == 0)
            {
                Console.WriteLine($"Process {pid} suspended successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to suspend process {pid} (Error code: {result}).");
            }

            CloseHandle(processHandle);
        }

        /// <summary>
        /// Resumes a process by its PID or name, or the currently focused window.
        /// </summary>
        /// <param name="pidOrName">The PID or process name. Pass "focused" to resume the focused window.</param>
        public static void Process_Resume(string pidOrName)
        {
            int pid = pidOrName.ToLower() == "focused" ? GetFocusedWindowPID() : GetProcessId(pidOrName);
            if (pid == -1)
            {
                Console.WriteLine("Process not found.");
                return;
            }

            IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, pid);
            if (processHandle == IntPtr.Zero)
            {
                Console.WriteLine("Failed to open process.");
                return;
            }

            int result = NtResumeProcess(processHandle);
            if (result == 0)
            {
                Console.WriteLine($"Process {pid} resumed successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to resume process {pid} (Error code: {result}).");
            }

            CloseHandle(processHandle);
        }

        /// <summary>
        /// Gets the process ID (PID) for the given process name or PID.
        /// </summary>
        /// <param name="pidOrName">The process name or PID as a string.</param>
        /// <returns>The PID if found; -1 otherwise.</returns>
        private static int GetProcessId(string pidOrName)
        {
            if (int.TryParse(pidOrName, out int pid))
            {
                return pid; // If it's already a PID, return it
            }

            Process[] processes = Process.GetProcessesByName(pidOrName);
            if (processes.Length > 0)
            {
                return processes[0].Id; // Return the PID of the first matching process
            }

            return -1; // Process not found
        }

        /// <summary>
        /// Gets the PID of the currently focused window.
        /// </summary>
        /// <returns>The PID if found; -1 otherwise.</returns>
        public static int GetFocusedWindowPID()
        {
            IntPtr hWnd = GetForegroundWindow();
            if (hWnd == IntPtr.Zero)
            {
                Console.WriteLine("No window is currently focused.");
                return -1;
            }

            GetWindowThreadProcessId(hWnd, out uint pid);
            return (int)pid;
        }
    }
}
