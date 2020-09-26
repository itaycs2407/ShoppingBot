using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingBot
{
    public partial class MainFrm : Form
    {
        public Controller ctrl;
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.ctrl.StartBot();
            btnStart.Enabled = false;
            btnStop.Enabled = true;

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.ctrl.StopBot();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnChanageKey_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            txtKey.Enabled = true;
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            txtKey.Text = ctrl.getCurrentKey();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtKey.Enabled = false;
        }
    }

}
