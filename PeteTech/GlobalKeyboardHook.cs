using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace PeteTech
{
    public class GlobalKeyListener
    {
        // Constants for the keyboard hook
        private const int WH_KEYBOARD_LL = 13; // Low-Level Keyboard Hook


        // Delegate for the hook callback function
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        // Importing necessary functions from user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowsHookEx(int hookType, HookProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(IntPtr hook);

        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(IntPtr hook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        // Holds the hook ID
        private IntPtr _keyboardHookID = IntPtr.Zero;
        private HookProc _hookProc;
        private Form _form;
        private Overlayklarity overlayInstance;

        public GlobalKeyListener(Form form)
        {
            _form = form;
            _hookProc = new HookProc(KeyPressCallback); // Initialize the hook procedure callback
        }

        // Method to install the global key hook
        public void InstallGlobalKeyHook()
        {
            _keyboardHookID = SetWindowsHookEx(WH_KEYBOARD_LL, _hookProc, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
        }

        // This callback function is triggered when a key is pressed globally
        private int KeyPressCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam); // Get the virtual key code from lParam
                char pressedChar = (char)vkCode;

                // Check each TextBox to see if the character in it matches the pressed key
                foreach (Control control in _form.Controls)
                {
                    if (control is TextBox textBox && textBox.Text.Length == 1)
                    {
                        char targetChar = textBox.Text[0];

                        if (pressedChar == targetChar)
                        {
                            string methodName = textBox.Name;

                            // Find and invoke the method from Macros
                            MethodInfo method = typeof(Macros).GetMethod(methodName);
                            if (method != null)
                            {
                                object macrosInstance = new Macros();
                                method.Invoke(macrosInstance, null); // Invoke the method
                            }
                            else
                            {
                                MessageBox.Show($"No method found for {textBox.Name}!");
                            }
                        }
                    }
                }
            }
            return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam); // Pass control to the next hook in the chain
        }

        // Unhook the global keyboard hook when the form is closed
        public void UnhookKeyboardHook()
        {
            if (_keyboardHookID != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_keyboardHookID);
            }
        }
    }
}
