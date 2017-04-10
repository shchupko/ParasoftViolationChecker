using System;
using System.IO;
using NarrowViol;

namespace NV.Console
{
    class Console
    {
        static void Main(string[] args)
        {
            //var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "monitors.cfg");
            var watcher = new Watcher();
            watcher.Start();

            System.Console.WriteLine("Press any key to exit");
            System.Console.ReadKey();
            watcher.Stop();
        }
    }
}
