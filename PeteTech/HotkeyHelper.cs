using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PeteTech
{
    public class HotkeyHelper
    {
        private readonly System.Windows.Forms.TextBox _textBox; // The TextBox associated with this hotkey
        private readonly object _targetClass;

        public HotkeyHelper(System.Windows.Forms.TextBox textBox, object targetClass)
        {
            _textBox = textBox;
            _targetClass = targetClass;
        }

        public void AttachHotkey(Form form)
        {
            form.KeyPreview = true; // Ensure the form captures key presses (Important)
            form.KeyPress += Form_KeyPress; // Attach the KeyPress event, I hate Squiggle
        }

        private void Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_textBox != null && !string.IsNullOrEmpty(_textBox.Text))
            {
                char targetChar = _textBox.Text[0]; // Get the first character from the TextBox (shouldnt worry all macro hotkey boxs should have max character limit set to 1 anyway)

                if (e.KeyChar == targetChar) // Compare the pressed key with the TextBox character
                {
                    InvokeMethodFromClass();
                }
            }
        }
        // Dynamically invoke the method based on the TextBox's Name
        private void InvokeMethodFromClass()
        {
            string methodName = _textBox.Name; // Get the name of the TextBox (e.g., "txtPboxHotKey")

            // Use reflection to find and invoke a method in the target class with the same name as the TextBox
            MethodInfo method = _targetClass.GetType().GetMethod(methodName);
            if (method != null)
            {
                method.Invoke(_targetClass, null); // Invoke the method
            }
            else
            {
                MessageBox.Show($"Method {methodName} not found in class {_targetClass.GetType().Name}"); // funny error big sad
            }
        }
    }
}
