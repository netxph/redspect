using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RedSpect.HostTest.Win
{
    public class Injection
    {

        private static MainForm _mainForm = null;

        public static MainForm MainForm
        {
            get
            {
                if (_mainForm == null)
                {
                    _mainForm = new MainForm();
                    _mainForm.FormClosed += new FormClosedEventHandler(_mainForm_FormClosed);
                }

                return _mainForm;
            }
            set
            {
                _mainForm = value;
            }
        }

        private static void _mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm = null;
        }

        public static void WriteForm(string message)
        {
            MainForm.WriteLine(message);
        }

    }
}
