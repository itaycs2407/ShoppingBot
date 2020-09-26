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

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (validateShoppingFile())
            {
                txtFileName.Text = openFileDialog1.FileName;
                btnSaveFile.Enabled = true;
                addContentToList();
            }
            else
            {
                MessageBox.Show("Problem loading file, try again", "Shopping Bot", MessageBoxButtons.OK);
            }
        }

        private void addContentToList()
        {
            throw new NotImplementedException();
        }

        private bool validateShoppingFile()
        {
            return true;
        }
    }

}
