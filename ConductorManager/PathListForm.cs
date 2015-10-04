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
    public partial class PathListForm : Form
    {
        public string SelectedPath = "";

        private bool Loading = true;

        public PathListForm(string selectedPath)
        {
            InitializeComponent();

            string[] pathlist = selectedPath.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string path in pathlist)
            {
                int row = dgPathList.Rows.Add();
                dgPathList[0, row].Value = path;
            }

            Loading = false;
        }

        private void PathListForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedPath = "";
            foreach (DataGridViewRow dr in dgPathList.Rows)
            {
                if (!dr.IsNewRow)
                {
                    if (dr.Cells[0].Value != null)
                    {
                        SelectedPath += dr.Cells[0].Value.ToString() + ";";
                    }
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

      
    }
}
