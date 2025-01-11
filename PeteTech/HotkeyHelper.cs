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
        private bool _keyProcessed = false; // Flag to track if the key has been processed

        // Hook constants
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

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

            // Attach KeyDown event handler to the TextBox
            _textBox.KeyDown += TextBox_KeyDown;
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
            if (nCode >= 0)
            {
                if ((int)wParam == WM_KEYDOWN && !_keyProcessed) // Check if a key is being pressed and not already processed
                {
                    _keyProcessed = true; // Mark the key as processed

                    int vkCode = Marshal.ReadInt32(lParam); // Get the virtual key code from lParam
                    char pressedKey = MapVirtualKeyToChar((uint)vkCode); // Map VK to actual char

                    Debug.WriteLine($"Key Pressed: {pressedKey} (VK Code: {vkCode})");

                    if (_textBox != null && !string.IsNullOrEmpty(_textBox.Text))
                    {
                        string targetKey = _textBox.Text; // TextBox text

                        Debug.WriteLine($"TextBox '{_textBox.Name}' Target Key: {targetKey}");

                        if (IsFunctionKey(targetKey, vkCode) || pressedKey.ToString().Equals(targetKey, StringComparison.OrdinalIgnoreCase)) // Match function key or regular key
                        {
                            Debug.WriteLine($"Key matched. Invoking method for {_textBox.Name}");
                            InvokeMethodFromClass();
                        }
                        else
                        {
                            Debug.WriteLine($"Key mismatch: {pressedKey} != {targetKey}");
                        }
                    }
                }
                else if ((int)wParam == WM_KEYUP) // Reset the flag when the key is released
                {
                    _keyProcessed = false;
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

        private bool IsFunctionKey(string targetKey, int vkCode)
        {
            // Check if the targetKey is a function key (F1-F12) and if the vkCode matches
            for (int i = 1; i <= 12; i++)
            {
                if (targetKey.Equals($"F{i}", StringComparison.OrdinalIgnoreCase) && vkCode == (0x70 + (i - 1))) // 0x70 is the virtual key code for F1
                {
                    return true;
                }
            }

            // Check for arrow keys
            if (targetKey.Equals("Left", StringComparison.OrdinalIgnoreCase) && vkCode == (int)Keys.Left)
            {
                return true;
            }
            if (targetKey.Equals("Right", StringComparison.OrdinalIgnoreCase) && vkCode == (int)Keys.Right)
            {
                return true;
            }
            if (targetKey.Equals("Up", StringComparison.OrdinalIgnoreCase) && vkCode == (int)Keys.Up)
            {
                return true;
            }
            if (targetKey.Equals("Down", StringComparison.OrdinalIgnoreCase) && vkCode == (int)Keys.Down)
            {
                return true;
            }

            return false;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the pressed key is a function key (F1-F12)
            if (e.KeyCode >= Keys.F1 && e.KeyCode <= Keys.F12)
            {
                // Update the TextBox text with the function key name
                _textBox.Text = e.KeyCode.ToString();
                e.Handled = true; // Mark the event as handled
            }
            // Check if the pressed key is an arrow key
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Update the TextBox text with the arrow key name
                _textBox.Text = e.KeyCode.ToString();
                e.Handled = true; // Mark the event as handled
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
