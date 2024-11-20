using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace PeteTech
{
    public class HotkeyHelper
    {
        private readonly TextBox _textBox; // Associated TextBox
        private readonly object _targetClass; // Target class containing the methods
        private IntPtr _keyboardHookID = IntPtr.Zero; // Hook ID
        private HookProc _hookProc; // Hook callback delegate

        // Hook constants
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        // Import user32.dll functions
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowsHookEx(int hookType, HookProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(IntPtr hook);

        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(IntPtr hook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        // Hook delegate
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        public HotkeyHelper(TextBox textBox, object targetClass)
        {
            _textBox = textBox ?? throw new ArgumentNullException(nameof(textBox));
            _targetClass = targetClass ?? throw new ArgumentNullException(nameof(targetClass));
            _hookProc = KeyPressCallback;
            InstallGlobalKeyHook();
        }

        private void InstallGlobalKeyHook()
        {
            _keyboardHookID = SetWindowsHookEx(
                WH_KEYBOARD_LL,
                _hookProc,
                GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName),
                0);
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int ToUnicode(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags);

        private int KeyPressCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (int)wParam == WM_KEYDOWN) // Check if a key is being pressed
            {
                int vkCode = Marshal.ReadInt32(lParam); // Get the virtual key code from lParam
                char pressedKey = MapVirtualKeyToChar((uint)vkCode); // Map VK to actual char

                Debug.WriteLine($"Key Pressed: {pressedKey} (VK Code: {vkCode})");

                if (_textBox != null && !string.IsNullOrEmpty(_textBox.Text))
                {
                    char targetChar = _textBox.Text[0]; // First character of the TextBox text

                    Debug.WriteLine($"TextBox '{_textBox.Name}' Target Key: {targetChar}");

                    if (pressedKey == targetChar) // Exact match
                    {
                        Debug.WriteLine($"Key matched. Invoking method for {_textBox.Name}");
                        InvokeMethodFromClass();
                    }
                    else
                    {
                        Debug.WriteLine($"Key mismatch: {pressedKey} != {targetChar}");
                    }
                }
            }

            return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam);
        }

        // Helper to map VK code to a character
        private char MapVirtualKeyToChar(uint vkCode)
        {
            StringBuilder buffer = new StringBuilder(2);
            byte[] keyboardState = new byte[256];
            GetKeyboardState(keyboardState);

            int result = ToUnicode(
                vkCode,
                0,
                keyboardState,
                buffer,
                buffer.Capacity,
                0
            );

            if (result > 0)
            {
                return buffer[0]; // Return the first character in the buffer
            }

            return '\0'; // Return null char if no mapping found
        }

        // Import GetKeyboardState
        [DllImport("user32.dll")]
        private static extern bool GetKeyboardState(byte[] lpKeyState);

        private void InvokeMethodFromClass()
        {
            string methodName = _textBox.Name; // Use TextBox.Name to find the method in the target class

            try
            {
                MethodInfo method = _targetClass.GetType().GetMethod(methodName);

                if (method != null)
                {
                    method.Invoke(_targetClass, null); // Invoke the method with no parameters
                }
                else
                {
                    MessageBox.Show($"Method '{methodName}' not found in class {_targetClass.GetType().Name}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error invoking method '{methodName}': {ex.Message}");
            }
        }

        public void UnhookKeyboardHook()
        {
            if (_keyboardHookID != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_keyboardHookID);
                _keyboardHookID = IntPtr.Zero;
            }
        }
    }
}

