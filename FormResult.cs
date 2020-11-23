using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RebootBench
{
    public partial class FormResult : Form
    {
        public FormResult(string message)
        {
            InitializeComponent();

            this.Text = Application.ProductName;
            txtResult.Text = message;
        }
    }
}
