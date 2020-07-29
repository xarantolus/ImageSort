using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSort
{
    public partial class LoadingForm : Form
    {
        public bool Stop;
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Shown(object sender, EventArgs e)
        {
            var t = new System.Threading.Thread(closewhen);
            t.Start();
            return;
        }
        private void LoadingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }
        void closewhen()
        {
            do
            {
                System.Threading.Thread.Sleep(100);
            } while (!Stop);
            Invoke((MethodInvoker)delegate () { Dispose(); });
        }
    }
}
