using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace MetroWF
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            metroProgressBar1.Increment(1);
            int value = metroProgressBar1.Value;
            metroLabel1.Text = "Processing " + value + " %";
            if (metroProgressBar1.Value == 100)
            {
                timer1.Stop();
                metroLabel1.Text = "Processing " + value + " % completed";
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
