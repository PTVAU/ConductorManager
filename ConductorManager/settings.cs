using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;
using System.Windows.Forms;

namespace ConductorManager
{
    public class SourceDestination
    {
        public string Source = "";
        public string Destination = "";

        public SourceDestination(string source, string dest)
        {
            Source = source;
            Destination = dest;
        }

        public SourceDestination(XmlNode node)
        {
            Source = node["src"].InnerText;
            Destination = node["dest"].InnerText;
        }
    }

    public class SourceDestinationCollection
    {
        ArrayList List = new ArrayList();

        public SourceDestination Add(SourceDestination item)
        {
            if (this[item.Source] == "")
                List.Add(item);
            return item;
        }

        public SourceDestination this[int index]
        {
            get
            {
                return List[index] as SourceDestination;
            }
        }

        public int Count
        {
            get
            {
                return List.Count;
            }
        }

        public void Clear()
        {
            List.Clear();
        }

        public string this[string src]
        {
            get
            {
                foreach (SourceDestination item in List)
                {
                    if (item.Source.ToLower().Trim() == src.Trim().ToLower())
                        return item.Destination;
                }
                return "";
            }
        }
    }

    public class Settings
    {
        public static string NewsListMainPath = "\\\\192.168.20.121\\Playlist";
        public static ArrayList SelectedItems = new ArrayList();
        public static ArrayList NoLocalingItems = new ArrayList();
        public static string DeleteWebPath = "";
        public static string DateModifiedText = "";

        public static ArrayList ProceedFiles = new ArrayList();

        public static SourceDestinationCollection SourceDestinations = new SourceDestinationCollection();

        public static int ProcessingListCount = 1;
        public static int ProcessingDateOffset = 5;

        public static bool AutoStart = false;

        private static string ConfigPath
        {
            get
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                if (!path.EndsWith("\\"))
                    path += "\\";
                path += "config.xml";
                return path;
            }
        }

        public static string SelectedItemsTitle
        {
            get
            {
                string items = "";
                foreach (string item in SelectedItems)
                    items += item + ";";
                return items;
            }
            set
            {
                string[] items = value.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                SelectedItems.Clear();
                SelectedItems.AddRange(items);

            }
        }

        public static string NoLocalingItemsTitle
        {
            get
            {
                string items = "";
                foreach (string item in NoLocalingItems)
                    items += item + ";";
                return items;
            }
            set
            {
                string[] items = value.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                NoLocalingItems.Clear();
                NoLocalingItems.AddRange(items);

            }
        }

        public static void Load()
        {
            if (!File.Exists(ConfigPath))
                Save();

            XmlDocument doc = new XmlDocument();
            doc.Load(ConfigPath);
            XmlNode root = doc["settings"];

            if (root == null)
                return;

            XmlNode nnode = root["newsmainpath"];
            if (nnode != null)
                NewsListMainPath = nnode.InnerText;

            nnode = root["deletewebpath"];
            if (nnode != null)
                DeleteWebPath = nnode.InnerText;

            nnode = root["datemodified"];
            if (nnode != null)
                DateModifiedText = nnode.InnerText;

            nnode = root["selecteditems"];
            if (nnode != null)
            {
                SelectedItemsTitle = nnode.InnerText;
            }

            nnode = root["nolocalitems"];
            if (nnode != null)
            {
                NoLocalingItemsTitle = nnode.InnerText;
            }

            //ProcessingDateOffset
            nnode = root["processlistcount"];
            if (nnode != null)
                ProcessingListCount = int.Parse(nnode.InnerText);

            nnode = root["dateoffset"];
            if (nnode != null)
                ProcessingDateOffset = int.Parse(nnode.InnerText);

            nnode = root["autostart"];
            if (nnode != null)
                AutoStart = nnode.InnerText == "1";

            nnode = root["source_dest"];
            SourceDestinations.Clear();
            foreach (XmlNode node in nnode.ChildNodes)
            {
                SourceDestinations.Add(new SourceDestination(node));
            }

            //ProcessingListCount
        }

        public static void Save()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<settings></settings>");
            XmlNode root = doc["settings"];

            XmlNode nnode = doc.CreateNode(XmlNodeType.Element, "newsmainpath", "");
            nnode.InnerText = NewsListMainPath;
            root.AppendChild(nnode);

            nnode = doc.CreateNode(XmlNodeType.Element, "deletewebpath", "");
            nnode.InnerText = DeleteWebPath;
            root.AppendChild(nnode);

            nnode = doc.CreateNode(XmlNodeType.Element, "datemodified", "");
            nnode.InnerText = DateModifiedText;
            root.AppendChild(nnode);

            nnode = doc.CreateNode(XmlNodeType.Element, "selecteditems", "");
            nnode.InnerText = SelectedItemsTitle;
            root.AppendChild(nnode);

            nnode = doc.CreateNode(XmlNodeType.Element, "nolocalitems", "");
            nnode.InnerText = NoLocalingItemsTitle;
            root.AppendChild(nnode);

            nnode = doc.CreateNode(XmlNodeType.Element, "processlistcount", "");
            nnode.InnerText = ProcessingListCount.ToString();
            root.AppendChild(nnode);

            nnode = doc.CreateNode(XmlNodeType.Element, "dateoffset", "");
            nnode.InnerText = ProcessingDateOffset.ToString();
            root.AppendChild(nnode);

            nnode = doc.CreateNode(XmlNodeType.Element, "autostart", "");
            nnode.InnerText = "0";
            if(AutoStart)
                nnode.InnerText = "1";
            root.AppendChild(nnode);

            nnode = doc.CreateNode(XmlNodeType.Element, "source_dest", "");

            for (int i = 0; i < SourceDestinations.Count; i++)
            {
                SourceDestination item = SourceDestinations[i];

                XmlNode node = doc.CreateNode(XmlNodeType.Element, "item", "");

                XmlNode cnode = doc.CreateNode(XmlNodeType.Element, "src", "");
                cnode.InnerText = item.Source;
                node.AppendChild(cnode);

                cnode = doc.CreateNode(XmlNodeType.Element, "dest", "");
                cnode.InnerText = item.Destination;
                node.AppendChild(cnode);

                nnode.AppendChild(node);

            }
            root.AppendChild(nnode);

            doc.Save(ConfigPath);
        }

        public static bool TestWebPath(string path)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(path);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();


                StreamReader stream = new StreamReader(resp.GetResponseStream());

                string Response = stream.ReadToEnd();

                stream.Close();
                resp.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Test Web Path ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public static string GetWebPathContent(string path)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(path);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();


                StreamReader stream = new StreamReader(resp.GetResponseStream());

                string Response = stream.ReadToEnd();

                stream.Close();
                resp.Close();
                return Response;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Test Web Path ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public static bool PathDateModified(string path)
        {
            path = path.ToLower();

            string[] pathlist = DateModifiedText.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string mpath in pathlist)
            {
                if (path.StartsWith(mpath.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
