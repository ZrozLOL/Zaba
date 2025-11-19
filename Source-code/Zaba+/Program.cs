using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaba_
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!IsRunAsAdmin())
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(Application.ExecutablePath)
                    {
                        Verb = "runas" // запускає як адмін
                    };
                    Process.Start(startInfo);
                }
                catch
                {
                    MessageBox.Show("⚠ Need admin launch!",
                        "Zaba+", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return; // виходимо з поточного екземпляру
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static bool IsRunAsAdmin()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
    }
}
