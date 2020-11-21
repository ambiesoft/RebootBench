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

            [Option('s', "starttime", Required = false, HelpText = "Set the time of start of reboot.")]
            public string StartTime { get; set; }

            [Option('p', "startup", Required = false, HelpText = "Set the type of startup.")]
            public string StartUp { get; set; }
        }

        internal static long getEpochNow()
        {
            return (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1))).TotalMilliseconds;
        }

        internal static string getStartupShortcutFile()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Startup),
                Application.ProductName + ".lnk");
        }

        static string toTimeString(TimeSpan span)
        {
            return string.Format("{0}:{1}:{2}",
                span.Hours.ToString("00"),
                span.Minutes.ToString("00"),
                span.Seconds.ToString("00"));
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);//, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);//.ToLocalTime();
            return dtDateTime;
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string starttime = null;
            string startup = null;
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
                   startup = o.StartUp;
               });

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (!string.IsNullOrEmpty(starttime))
            {
                string shortcutfile = getStartupShortcutFile();
                FileOperationAPIWrapper.MoveToRecycleBin(shortcutfile);

                if (startup == "browser")
                {
                    Uri uri = new Uri("https://ambiesoft.github.io/RebootBench/rebooted.html" +
                        "#starttime=" + starttime);

                    Process.Start(new ProcessStartInfo(uri.AbsoluteUri)
                    { UseShellExecute = true });

                    return;
                }
                else if(startup=="rebootbench")
                {
                    // 100 nano
                    long lStartTime;
                    long.TryParse(starttime, out lStartTime);
                    DateTime dtStartup = UnixTimeStampToDateTime(lStartTime / 1000);
                    TimeSpan span = DateTime.UtcNow.Subtract(dtStartup);

                    string message = string.Format(Properties.Resources.STR_RESULT,
                        toTimeString(span));
                    MessageBox.Show(message,
                        Application.ProductName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }
                else
                {
                    MessageBox.Show(string.Format(Properties.Resources.UNKNOWN_STARTUP_TYPE,startup),
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                FormMain formMain = new FormMain();
                formMain.ShowDialog();
            }
        }
    }
}
