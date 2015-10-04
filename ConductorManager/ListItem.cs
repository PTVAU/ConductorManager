using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Threading;

using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.MyServices;
using Microsoft.VisualBasic.FileIO;

namespace ConductorManager
{
    public class ClipItem
    {
        public string Name = "";
        public string VideoFile = "";
        public string Content = "";

        public ClipItem(XmlNode parentnode)
        {
            XmlNode node = parentnode["name"];
            if (node != null)
                Name = node.InnerText;

            node = parentnode["videofile"];
            if (node != null)
                VideoFile = node.InnerText;

            Content = parentnode.OuterXml;
        }

    }

    public enum PlayListItemStatus
    {
        Wait,Proccessing,Complete,Error
    }

    public class PlayListItem
    {
        public ProgressBar Progress = new ProgressBar();
        public ListViewItem ListItem = null;
        public Button StartButton = new Button();
        public ArrayList NoDestinationFiles = new ArrayList();

        public string ListFilePath = "";
        public string ListType = "";
        public string ListDate = "";
        public string Content = "";
        public PlayListItemStatus Status = PlayListItemStatus.Wait;
        public bool LastReset = false;

        public int ProceedFiles = 0;

        public bool NoLocaling = false;

        private Thread MainThread = null;

        public int TotalFiles
        {
            get
            {
                return ClipList.Count;
            }
        }

        public ArrayList ClipList = new ArrayList();

        public PlayListItem(string file, string type, string date)
        {
            ListFilePath = file;
            ListType = type;
            ListDate = date;

            if (!Load())
                Status = PlayListItemStatus.Error;

            Progress.ForeColor = System.Drawing.Color.FromArgb(128, 255, 128);
            Progress.Minimum = 0;
            Progress.Maximum = ClipList.Count;
            Progress.Value = 0;

            StartButton.Image = global::ConductorManager.Properties.Resources.Play_icon14;
            StartButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            StartButton.Location = new System.Drawing.Point(821, 500);
            StartButton.Size = new System.Drawing.Size(60, 23);
            StartButton.Text = "Start";
            StartButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            StartButton.Click += new EventHandler(StartButton_Click);


            MainThread = new Thread(new ThreadStart(ProcessList));
        }

        void StartButton_Click(object sender, EventArgs e)
        {
            Start();
            StartButton.Dispose();
            StartButton = null;
        }

        public bool Load()
        {
            //if (ListFilePath.ToLower().Contains("news in") && ListFilePath.Contains("0730"))
            //{
            //    ListFilePath = ListFilePath;
            //    Content = File.ReadAllText(ListFilePath , Encoding.Default);
            //}

            if (!File.Exists(ListFilePath))
                return false;

            Content = File.ReadAllText(ListFilePath, Encoding.Default);

            XmlDocument doc = new XmlDocument();
            try
            {
                //doc.Load(ListFilePath);
                doc.LoadXml(Content);
            }
            catch(Exception ex)
            { 
                string s = ex.Message;
                return false; 
            }

            XmlNode root = doc["playlist"];
            if (root == null)
                return false;

            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name.ToLower() == "clip")
                {
                    ClipItem clip = new ClipItem(node);
                    ClipList.Add(clip);
                }
            }

            return true;
        }

        public void ResetStatus()
        {
            Progress.Value = ProceedFiles;
            if (ListItem != null)
            {
                if (Status == PlayListItemStatus.Error)
                    ListItem.BackColor = System.Drawing.Color.Red;
            }
        }

        public void Start()
        {
            if (MainThread != null)
            {
                if (!MainThread.IsAlive)
                    MainThread.Start();
            }
        }
        public void Stop()
        {
            if (MainThread != null)
            {
                if (MainThread.IsAlive)
                    MainThread.Abort();
            }

        }

        private void ProcessList()
        {
            Computer comp = new Computer();
            int copied = 0;

            Status = PlayListItemStatus.Proccessing;
            foreach (ClipItem clip in ClipList)
            {
                try
                {
                    string dest = general.getDestinationFile(clip.VideoFile);

                    if (dest == "")
                    {
                        NoDestinationFiles.Add(clip.VideoFile);
                        ProceedFiles++;
                        continue;
                    }

                    string dir = Path.GetDirectoryName(dest);
                    if (!Directory.Exists(dir))
                    {
                            Directory.CreateDirectory(dir);
                        
                    }

                    if (!File.Exists(dest))
                    {
                        if (!NoLocaling)
                        {

                            comp.FileSystem.CopyFile(clip.VideoFile, dest, UIOption.AllDialogs, UICancelOption.ThrowException);
                            copied++;
                        }
                        else
                        {
                            ProceedFiles++;
                            continue;
                        }
                    }
                    else
                    {
                        if (Settings.PathDateModified(dest))
                        {
                            FileInfo srcfi = new FileInfo(clip.VideoFile);
                            FileInfo dstfi = new FileInfo(dest);

                            if (dstfi.LastWriteTime < srcfi.LastWriteTime || srcfi.Length != dstfi.Length)
                            {
                                if (general.DeleteFile(dest))
                                {
                                    comp.FileSystem.CopyFile(clip.VideoFile, dest, UIOption.AllDialogs, UICancelOption.ThrowException);
                                    copied++;
                                }
                            }
                        }
                    }

                    ProceedFiles++;
                    Content = Content.Replace(clip.VideoFile, dest);
                    
                }
                catch (Exception ex)
                {
                    Status = PlayListItemStatus.Error;
                    MessageBox.Show("Error (File Copy) : " + ex.Message, "File Copy...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Status != PlayListItemStatus.Error)
            {
                Status = PlayListItemStatus.Complete;

                try
                {
                    string dest = general.getDestinationFile(ListFilePath);

                    string dir = Path.GetDirectoryName(dest);
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    if (File.Exists(dest) && copied == 0)
                    {
                        return;
                    }

                    File.WriteAllText(dest, Content, Encoding.Default);
                }
                catch (Exception ex)
                {
                    Status = PlayListItemStatus.Error;
                    MessageBox.Show("Error (List File Copy) : " + ex.Message, "List File Copy...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string StatusTitle
        {
            get
            {
                switch (Status)
                {
                    case PlayListItemStatus.Complete: return "Complete";
                    case PlayListItemStatus.Error: return "Error";
                    case PlayListItemStatus.Proccessing:
                        int per = (ProceedFiles * 100) / TotalFiles;
                        return "Proccessing " + ProceedFiles.ToString() + " of " + TotalFiles.ToString();
                    case PlayListItemStatus.Wait: return "Wait";
                }
                return "";
            }
        }
    }
}
