using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ConductorManager
{
    public partial class BrowsSelectedItemsForm : Form
    {
        public string SelectedItems = "";

        public BrowsSelectedItemsForm(string selected)
        {
            InitializeComponent();

            SelectedItems = selected;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedItems = "";
            ProcessTreeNodes(trwItems.Nodes[0]);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedItems = "";
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BrowsSelectedItemsForm_Load(object sender, EventArgs e)
        {
            ProcessDateList();
        }

        private void ProcessTreeNodes(TreeNode parent)
        {
            foreach (TreeNode node in parent.Nodes)
            {
                if (node.Checked && node.Nodes.Count == 0)
                {
                    string path = node.FullPath;

                    path = path.Replace("Items\\", "");

                    SelectedItems += path + ";";


                }

                if (node.Nodes.Count > 0)
                    ProcessTreeNodes(node);
            }
        }

        private void ProcessDateList()
        {
            string datepath = Settings.NewsListMainPath;
            if (!datepath.EndsWith("\\"))
                datepath += "\\";

            DateTime date = DateTime.Now.AddDays(-1);

            datepath = date.Year.ToString("0000") + date.Month.ToString("00") + date.Day.ToString("00");
            string path = Settings.NewsListMainPath;
            if (!path.EndsWith("\\"))
                path += "\\";

            path += datepath;
            if (!Directory.Exists(path))
                return;

            trwItems.Nodes.Clear();
            TreeNode root = trwItems.Nodes.Add("Items");
            ProcessSubFiles(path , root);
            root.ExpandAll();

        }

        private void ProcessSubFiles(string path , TreeNode parent)
        {

            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                DirectoryInfo di = new DirectoryInfo(folder);
                TreeNode node = parent.Nodes.Add(di.Name);
                if (SelectedItems.ToLower().Contains(di.Name.ToLower() + ";"))
                    node.Checked = true;

                ProcessSubFiles(folder, node);
            }
        }

    }
}
