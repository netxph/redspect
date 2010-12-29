using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RedSpect.HostTest.Win
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void WriteLine(string message)
        {
            _textConsole.AppendText(string.Format("[{0}]>> {1}\r\n", DateTime.Now.ToString("ddMMMyyyy HH:mm:ss"), message));
        }

        private void _buttonAddText_Click(object sender, EventArgs e)
        {
            WriteLine("Test Message");
        }

        private void _buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
