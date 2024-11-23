using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void LinkToSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "http://andreev-music.whf.bz/web";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
