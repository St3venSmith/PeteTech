using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeteTech
{
    internal class Macros
    {
        // function must match name of the txtbox for the macro to work
        // or to link to a button just name whatever and link with macro.{name of funtion}


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
            MessageBox.Show("Hotkey for fuison pressed!");
            SendKeys.Send("{ENTER}");
            Thread.Sleep(1000);
            SendKeys.Send("e");
            Thread.Sleep(1000);
            SendKeys.Send("e");
            Thread.Sleep(1000);
            SendKeys.Send("e");
            Thread.Sleep(1000);
            SendKeys.Send("e");
            Thread.Sleep(1000);
            SendKeys.Send("e");
            Thread.Sleep(1000);
            SendKeys.Send("e");

        }

        public void SoloScript()
        {
            MessageBox.Show("Solo script pressed!");
        }

    }
}
