using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ShoppingBot
{
    public partial class MainFrm : Form
    {
        public Controller ctrl;
        private string[] m_Items;
       
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
            m_Items = getItemsFromFile(openFileDialog1.FileName);
            updateItemList();
        }

        private string[] getItemsFromFile(string i_FileName)
        {
            return File.ReadAllLines(i_FileName);
        }

        private bool validateShoppingFile()
        {
            return true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteItem.Enabled = listBox1.SelectedItem != null;
        }
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            string itemSelected = listBox1.SelectedItem.ToString();
            DialogResult result = MessageBox.Show($"Are you sure you want to delete {itemSelected} ?", "Shopping Bot", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                List<string> newListItems = new List<string>();
                foreach (string item in m_Items)
                {
                    if (!item.Equals(itemSelected))
                    {
                        newListItems.Add(item);
                    }
                }
                m_Items = newListItems.ToArray();
                updateItemList();
                btnDeleteItem.Enabled = false;
            }
        }

        private void updateItemList()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(m_Items);
        }
    }
}
