using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace ConductorManager
{
    public class general
    {
        public static string getDestinationFile(string sourceFile)
        {
            sourceFile = sourceFile.Replace("/", "\\");
            for (int i = 0; i < Settings.SourceDestinations.Count; i++)
            {
                SourceDestination sitem = Settings.SourceDestinations[i];
                if (sourceFile.ToLower().StartsWith(sitem.Source.ToLower()))
                {
                    string srcset = sitem.Source;
                    string dest = sitem.Destination + "\\" + sourceFile.Substring(srcset.Length, sourceFile.Length - srcset.Length);
                    dest = dest.Replace("\\\\", "\\");
                    return dest;
                }
            }
            return "";
        }


        public static bool DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                FileAttributes attr = File.GetAttributes(path);

                attr &= ~FileAttributes.Hidden;
                attr &= ~FileAttributes.ReadOnly;

                attr = FileAttributes.Archive;
                File.SetAttributes(path, attr);

                File.Delete(path);

                return true;
            }

            return true;

        }
    }
}
