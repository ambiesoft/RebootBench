using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RebootBench.WinApi;

namespace RebootBench
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            this.Text = Application.ProductName;
        }

        // https://stackoverflow.com/a/4897700
        private void urlShortcutToStartup(string linkName, string linkUrl)
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=" + linkUrl);
            }
        }

        long getEpochNow()
        {
            // return DateTimeOffset.Now.ToUnixTimeSeconds();
            return (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1))).TotalMilliseconds;
            //TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            //return t.TotalSeconds;
        }

        private void CreateShortcut(string app,string arg)
        {
            object startup = (object)"Startup";
            WshShell shell = new WshShell();
            string shortcutAddress = Program.getStartupShortcutFile(); // (string)shell.SpecialFolders.Item(ref startup) + @"\RebootBench.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            // shortcut.Description = "New shortcut for a Notepad";
            // shortcut.Hotkey = "Ctrl+Shift+N";
            shortcut.TargetPath = app;
            shortcut.Arguments = arg;
            shortcut.Save();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes != MessageBox.Show(Properties.Resources.ARE_YOU_SURE_TO_REBOOT,
                Application.ProductName,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2))
            {
                return;
            }
            string epochtimeString = getEpochNow().ToString();
            //string localhtmlfile = Path.Combine(
            //    Path.GetDirectoryName(Application.ExecutablePath),
            //    "html",
            //    "rebooted.html");
            string app = Application.ExecutablePath;
            string arg = string.Format("--starttime {0}", epochtimeString);

            CreateShortcut(app, arg);

            AdjustToken();
            ExitWindowsEx(ExitWindows.EWX_REBOOT, 0);
            //WinApi.ExitWindowsEx(
            //    WinApi.ExitWindows.Reboot,
            //    WinApi.ShutdownReason.MajorOther |
            //    WinApi.ShutdownReason.MinorOther |
            //    WinApi.ShutdownReason.FlagPlanned);

        }
    }
}
