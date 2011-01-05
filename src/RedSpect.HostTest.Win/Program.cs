using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RedSpect.Shared;

namespace RedSpect.HostTest.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationProbe.RegisterCommands(new WindowsTestCommand());
            ApplicationProbe.Start();
            Application.Run(Injection.MainForm);
        }
    }
}
