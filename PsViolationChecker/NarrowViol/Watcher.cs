using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

/* Issues:
 * - one change -> two events
 * - save to xml
 * - parse by linq
 * - loging
 * - config
 */
namespace NarrowViol
{
    public class Logger
    {
        FileSystemWatcher watcher;

        bool enabled = true;
        public Logger()
        {
             watcher.Filter = Config.SourceFName;

            watcher.Changed += Watcher_Changed;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string filePath = e.FullPath;
            string msg = String.Format("file {0} was changed. CRC {2}", filePath, 123);
            Log.PrintLog(msg);
        }
    }



    public class Watcher
    {
        static UInt32 Hash;
        public FileSystemWatcher FileSystemWatcher = null;

        public Watcher()
        {
            FileSystemWatcher = new FileSystemWatcher();
            FileSystemWatcher.Path = Config.path;
            FileSystemWatcher.IncludeSubdirectories = false;
            FileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;
            FileSystemWatcher.Filter = Config.SourceFName;
            FileSystemWatcher.Changed += FileSystemWatcher_Changed;
            
        }

        public void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fileName = Path.Combine(Config.path, Config.SourceFName);
            //UInt32 hash = Crc32.GetFileHash(fileName);
            //string msg = String.Format("file {0} was changed. CRC {1}", "event", hash);
            //Log.PrintLog(msg);

            //if (Hash != hash)   
            {
            //    Hash = hash;

                try
                {
                    parse(fileName);
                }
                catch(Exception ex)
                {
                    Log.PrintLog(String.Format("Exception happend: {0}", ex.Message));
                }
            }
        }

        public void Start()
        {
            FileSystemWatcher_Changed(null, null);

            FileSystemWatcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            FileSystemWatcher.EnableRaisingEvents = false;
        }
    //}

    //public class Parser
    //{
        public void parse(string fileName)
        {
            Log.PrintLog("Parser called");

            XDocument doc = XDocument.Load(fileName);

            using (StreamWriter sw = new StreamWriter(Path.Combine(Config.workspacePath, Config.ResultFName) + ".txt", false, System.Text.Encoding.Default))
            {
                foreach (XElement el in doc.Root.Element("StdViols").Elements())
                {
                    string msg = "", ln = "", locFile = "";
                    //sw.Write(string.Format("\n{0}", el.Name));

                    foreach (XAttribute atrb in el.Attributes())
                    {
                        if (atrb.Name == "msg")
                        {
                            msg = atrb.Value;
                        }
                        if (atrb.Name == "ln")
                        {
                            ln = atrb.Value;
                        }
                        if (atrb.Name == "locFile")
                        {
                            locFile = Path.GetFileName(atrb.Value);
                        }
                    }
                    sw.WriteLine(string.Format("{0},{1,4}, {2}", locFile, ln, msg));
                }
            }
            //IEnumerable<XAttribute> atr = doc.Root.Descendants("cat").ToList();

            //var tracks = from u in doc.Root.Element("StdViols").Elements().Attributes() where (u=> u.Name == "cat");
            //foreach (var t in tracks)
            //    sw.Write(string.Format(" {0}={1},", t, t));

            //сохраняем наш документ
            //doc.Save(conf.vsFileNameXml);
        }
    }
}
