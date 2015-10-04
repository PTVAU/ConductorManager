using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

using Microsoft.VisualBasic.Devices;

namespace ConductorManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            ProcessListFiles();
            timer1_Tick(null, new EventArgs());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            tsbtnRefresh.Enabled = false;

            while (Settings.ProceedFiles.Count > 5000)
            {
                Settings.ProceedFiles.RemoveAt(Settings.ProceedFiles.Count - 1);
            }

            while (lstFiles.Items.Count > 5000)
            {
                lstFiles.Items.RemoveAt(lstFiles.Items.Count - 1);
            }

            //if (WaitForProcessCount > 0)
            //{
            //    while (ProcessingCount < 5)
            //    {
            //        for (int i = lstFiles.Items.Count - 1; i >= 0; i--)
            //        {
            //            PlayListItem litem = lstFiles.Items[i].Tag as PlayListItem;
            //            if (litem.Status == PlayListItemStatus.Wait)
            //            {
            //                litem.Start();
            //                //return;
            //            }
            //        }

            //    }
            //}

        
            for (int i = lstFiles.Items.Count - 1; i >= 0; i--)
            {
                PlayListItem litem = lstFiles.Items[i].Tag as PlayListItem;

                lstFiles.Items[i].SubItems[4].Text = litem.StatusTitle;

                if (litem.Status == PlayListItemStatus.Proccessing)
                {
                    litem.ResetStatus();
                }
                if (litem.Status == PlayListItemStatus.Complete && !litem.LastReset)
                {
                    litem.ResetStatus();
                    litem.LastReset = true;
                }

                if (litem.Status == PlayListItemStatus.Complete)
                {
                    if (litem.StartButton != null)
                        lstFiles.RemoveEmbeddedControl(litem.StartButton);
                    lstFiles.Items[i].ImageIndex = 2;
                    lstFiles.Items[i].StateImageIndex = 2;
                }

                if (Settings.AutoStart)
                {
                    if (litem.Status == PlayListItemStatus.Wait && WaitForProcessCount > 0 && ProcessingCount < Settings.ProcessingListCount)
                    {
                        string lf = litem.ListFilePath;
                        string date = "";

                        FileInfo fi = new FileInfo(lf);

                        lf = lf.Replace(Settings.NewsListMainPath, "");
                        if (lf.StartsWith("\\"))
                            lf = lf.Substring(1);
                        if (lf.StartsWith("2014"))
                        {
                            date = lf.Substring(0, 8);
                            lf = lf.Substring(9);
                        }
                        if (lf.EndsWith(fi.Name))
                            lf = lf.Substring(0, lf.Length - fi.Name.Length - 1);

                        if (Settings.SelectedItems.Contains(lf))
                        {
                            //if (lf.Contains("2030"))
                            {

                                litem.Start();
                                System.Threading.Thread.Sleep(1000);
                            }
                        }
                    }
                }

                lstFiles.Items[i].SubItems[4].Text = litem.StatusTitle;

            }

            ProcessListFiles();

            ProcessDeleteFiles();

            tsbtnRefresh.Enabled = true;
            timer1.Enabled = true;
        }

        private void ProcessListFiles()
        {
            DateTime today = DateTime.Now;
            
            DateTime date = DateTime.Now.AddHours(-1 * Settings.ProcessingDateOffset);

            if(date.Day < today.Day)
                ProcessDateListFiles(date);

            ProcessDateListFiles(DateTime.Now);

            date = DateTime.Now.AddHours(Settings.ProcessingDateOffset);

            if (date.Day > today.Day)
                ProcessDateListFiles(date);

        }

        private void ProcessDateListFiles(DateTime date)
        {
            string datepath = Settings.NewsListMainPath;
            if (!datepath.EndsWith("\\"))
                datepath += "\\";

            datepath = date.Year.ToString("0000") + date.Month.ToString("00") + date.Day.ToString("00");
            string path = Settings.NewsListMainPath;
            if (!path.EndsWith("\\"))
                path += "\\";

            path += datepath;
            if (!Directory.Exists(path))
                return;

            ArrayList files = ProcessSubFiles(path);

            foreach (string file in files)
            {
                string datestr = date.ToString("yyyy/MM/dd");
                 FileInfo fi = new FileInfo(file);
                string type = file.Replace(path, "");
                if (type.StartsWith("\\"))
                    type = type.Substring(1);
                try
                {
                    type = type.Substring(0, type.Length - fi.Name.Length - 1);

                }
                catch { type = ""; }

                PlayListItem litem = new PlayListItem(file, type, datestr);
                if (Settings.NoLocalingItems.Contains(type))
                    litem.NoLocaling = true;

                lstFiles.Items.Insert(0, "");
                lstFiles.Items[0].SubItems.Add(litem.ListDate);
                lstFiles.Items[0].SubItems.Add(litem.ListType);
                lstFiles.Items[0].SubItems.Add(fi.Name);
                lstFiles.Items[0].SubItems.Add("Waiting");
                lstFiles.Items[0].Tag = litem;
                lstFiles.Items[0].ImageIndex = 1;
                lstFiles.Items[0].StateImageIndex = 1;

                litem.ListItem = lstFiles.Items[0];

                lstFiles.AddEmbeddedControl(litem.Progress, 5, 0);

                //Button btn = new Button();
                //btn.Text = "Start";
                //btn.Click += new EventHandler(btn_Click);
                //btn.Tag = litem;
                lstFiles.AddEmbeddedControl(litem.StartButton, 6, 0);
            }

        }

        private void ProcessDeleteFiles()
        {
            if (Settings.DeleteWebPath == "")
                return;
            string cont = Settings.GetWebPathContent(Settings.DeleteWebPath);
            if (cont == "")
                return;

            string[] srcfiles = cont.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string srcfile in srcfiles)
            {
                string destfile = general.getDestinationFile(srcfile);
                if (destfile.EndsWith("\r"))
                    destfile = destfile.Substring(0, destfile.Length - 1);
                if (destfile == "")
                    continue;

                destfile = Regex.Replace(destfile, "&(?!amp;)", "&amp;");

                while (destfile.Contains("&amp;"))
                    destfile = destfile.Replace("&amp;", "");

                try
                {
                    general.DeleteFile(destfile);
                    //if (File.Exists(destfile))
                    //{
                    //    FileAttributes attr = File.GetAttributes(destfile);

                    //    attr &= ~FileAttributes.Hidden;
                    //    attr &= ~FileAttributes.ReadOnly;

                    //    attr = FileAttributes.Archive;
                    //    File.SetAttributes(destfile, attr);

                    //    File.Delete(destfile);
                    //}
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error : " + ex.Message, "Delete Old Files ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ListViewItem item = lstErrors.Items.Insert(0, "Error (Delete Files): " + ex.Message);
                    item.BackColor = Color.FromArgb(255, 100, 100);
                    continue;
                }
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            PlayListItem litem = btn.Tag as PlayListItem;
            if (litem.Status == PlayListItemStatus.Wait)
                litem.Start();
        }

        private ArrayList ProcessSubFiles(string path)
        {
            ArrayList list = new ArrayList();

            string[] files = Directory.GetFiles(path, "*.pspl");

            foreach (string file in files)
            {
                if (!Settings.ProceedFiles.Contains(file))
                {
                    list.Add(file);

                    Settings.ProceedFiles.Add(file);
                }

            }

            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                ArrayList slist = ProcessSubFiles(folder);
                if(slist.Count > 0)
                    list.AddRange(slist);
            }
 
            return list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //if (Settings.AutoStart)
            timer1.Enabled = true;

            Form1_Resize(null, new EventArgs());

        }

        private void lstFiles_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawDefault = true;
            e.DrawText();
            e.DrawFocusRectangle();
        }

        private void tsbtnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm frm = new SettingsForm();
            frm.ShowDialog();
        }

        private int WaitForProcessCount
        {
            get
            {
                int count = 0;
                foreach (ListViewItem item in lstFiles.Items)
                {
                    PlayListItem litem = item.Tag as PlayListItem;
                    if (litem.Status == PlayListItemStatus.Wait)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        private int ProcessingCount
        {
            get
            {
                int count = 0;
                foreach (ListViewItem item in lstFiles.Items)
                {
                    PlayListItem litem = item.Tag as PlayListItem;
                    if (litem.Status == PlayListItemStatus.Proccessing)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            lstFiles.Top = 40;
            lstFiles.Left = 10;
            lstFiles.Width = Width - 35;
            lstFiles.Height = Height - 150;

            lstErrors.Top = lstFiles.Bottom + 5;
            lstErrors.Left = 10;
            lstErrors.Height = 60;
            lstErrors.Width = Width - 35;
            lstErrors.Columns[0].Width = lstErrors.Width - 30;
        }

        private void lstErrors_DoubleClick(object sender, EventArgs e)
        {
            if (lstErrors.SelectedIndices.Count == 0)
                return;

            Clipboard.SetText(lstErrors.SelectedItems[0].Text);
        }
    }
}
