using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RedSpect.Shared;
using RedSpect.Shared.Providers;

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

            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("portName", "Diagnostics");
            properties.Add("authorizedGroup", "Everyone");

            ApplicationProbe.Start<IPCProbeProvider>(properties);
            Application.Run(Injection.MainForm);
        }
    }
}
