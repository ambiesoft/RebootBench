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
        private void urlShortcutToDesktop(string linkName, string linkUrl)
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=" + linkUrl);
            }
        }

        long getEpochNow()
        {
            // return DateTimeOffset.Now.ToUnixTimeSeconds();
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
            //TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            //return t.TotalSeconds;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            string hash = string.Format("#starttime={0}", getEpochNow());
            //string htmlfile = Path.Combine(
            //    Path.GetDirectoryName(Application.ExecutablePath),
            //    "html",
            //    "rebooted.html");
            //Uri uri = new Uri(htmlfile);
            Uri uri = new Uri("https://ambiesoft.github.io/RebootBench/rebooted.html" + hash);

            Process.Start(new ProcessStartInfo(uri.AbsoluteUri)
                { UseShellExecute = true });

            // Process.Start(uri.AbsoluteUri);
        }
    }
}
