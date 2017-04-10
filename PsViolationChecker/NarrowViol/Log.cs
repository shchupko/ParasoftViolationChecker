using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrowViol
{
    public class Log
    {
        //object obj = new object();

        public static void PrintLog(string msg)
        {
            //lock (obj)
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(Config.path, Config.LogFileName), true))
                {
                    writer.WriteLine(String.Format("{0} {1}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), msg));
                    writer.Flush();
                }
            }
        }
    }
}
