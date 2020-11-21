using CommandLine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RebootBench
{
    static class Program
    {
        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }

            [Option('s', "starttime", Required =false,HelpText ="Set the time of start of reboot.")]
            public string StartTime { get; set; }
        }

        internal static string getStartupShortcutFile()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Startup),
                Application.ProductName + ".lnk");
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string starttime = null;
            Parser.Default.ParseArguments<Options>(args)
               .WithParsed<Options>(o =>
               {
                   if (o.Verbose)
                   {
                       //Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                       //Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                   }
                   else
                   {
                       //Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                       //Console.WriteLine("Quick Start Example!");
                   }

                   starttime = o.StartTime;
               });

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (!string.IsNullOrEmpty(starttime))
            {
                Uri uri = new Uri("https://ambiesoft.github.io/RebootBench/rebooted.html" + 
                    "#starttime=" + starttime);

                Process.Start(new ProcessStartInfo(uri.AbsoluteUri)
                { UseShellExecute = true });

                string shortcutfile = getStartupShortcutFile();

                FileOperationAPIWrapper.MoveToRecycleBin(shortcutfile);
            }
            else
            {
                FormMain formMain = new FormMain();
                formMain.ShowDialog();
            }
        }
    }
}
