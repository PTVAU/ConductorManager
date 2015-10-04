using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConductorManager
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            SettingsForm frm = new SettingsForm();
            frm.ShowDialog();

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 1;
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                timer1.Enabled = false;
                Close();
            }
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            this.CancelButton = btnSkip;
            AcceptButton = btnSkip;
        }
    }
}
