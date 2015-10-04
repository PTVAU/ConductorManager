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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnBrowsNewsFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = txtNewsFolder.Text;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;

            txtNewsFolder.Text = fbd.SelectedPath;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            txtNewsFolder.Text = Settings.NewsListMainPath;
            txtSelectedItems.Text = Settings.SelectedItemsTitle;
            txtNoLocaling.Text = Settings.NoLocalingItemsTitle;
            txtDeleteWebPath.Text = Settings.DeleteWebPath;
            nmProcessingList.Value = Settings.ProcessingListCount;
            chkAutoStart.Checked = Settings.AutoStart;
            nmDateOffset.Value = Settings.ProcessingDateOffset;
            txtDateModified.Text = Settings.DateModifiedText;

            for (int i = 0; i < Settings.SourceDestinations.Count; i++)
            {
                SourceDestination item = Settings.SourceDestinations[i];

                int row = dgSourceDestination.Rows.Add();
                dgSourceDestination.Rows[row].Cells[0].Value = item.Source;
                dgSourceDestination.Rows[row].Cells[1].Value = item.Destination;
            }

            CancelButton = btnCancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Settings.NewsListMainPath = txtNewsFolder.Text;
            Settings.SelectedItemsTitle = txtSelectedItems.Text;
            Settings.NoLocalingItemsTitle = txtNoLocaling.Text;
            Settings.DeleteWebPath = txtDeleteWebPath.Text;
            Settings.ProcessingListCount = Convert.ToInt32(nmProcessingList.Value);
            Settings.AutoStart = chkAutoStart.Checked;
            Settings.ProcessingDateOffset = Convert.ToInt32(nmDateOffset.Value);
            Settings.DateModifiedText = txtDateModified.Text;

            Settings.SourceDestinations.Clear();
            for (int row = 0; row < dgSourceDestination.Rows.Count; row++)
            {
                if (!dgSourceDestination.Rows[row].IsNewRow)
                {
                    if (dgSourceDestination.Rows[row].Cells[0].Value == null)
                        continue;

                    if (dgSourceDestination.Rows[row].Cells[1].Value == null)
                        continue;

                    Settings.SourceDestinations.Add(new SourceDestination(dgSourceDestination.Rows[row].Cells[0].Value.ToString(), dgSourceDestination.Rows[row].Cells[1].Value.ToString()));
                }
                //SourceDestination item = Settings.SourceDestinations[i];

                //int row = dgSourceDestination.Rows.Add();
               // dgSourceDestination.Rows[row].Cells[0].Value = item.Source;
                //dgSourceDestination.Rows[row].Cells[1].Value = item.Destination;
            }

            Settings.Save();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBrowsSelectedItems_Click(object sender, EventArgs e)
        {
            BrowsSelectedItemsForm frm = new BrowsSelectedItemsForm(txtSelectedItems.Text);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            txtSelectedItems.Text = frm.SelectedItems;
        }

        private void btnNoLocaling_Click(object sender, EventArgs e)
        {
            BrowsSelectedItemsForm frm = new BrowsSelectedItemsForm(txtNoLocaling.Text);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            txtNoLocaling.Text = frm.SelectedItems;

        }

        private void btnTestDeleteWebPath_Click(object sender, EventArgs e)
        {
            if (Settings.TestWebPath(txtDeleteWebPath.Text))
            {
                MessageBox.Show("Connection was Successfull.", "Test Web Path ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDateModifiedBrows_Click(object sender, EventArgs e)
        {
            PathListForm form = new PathListForm(txtDateModified.Text);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;

            txtDateModified.Text = form.SelectedPath;
        }
    }
}
