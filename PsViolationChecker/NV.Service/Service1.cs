using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using NarrowViol;

namespace NV.Service
{
    public partial class Service1 : ServiceBase
    {
        Logger logger;
        Watcher watcher;

        public Service1()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = false;
        }
 
        protected override void OnStart(string[] args)
        {
            logger = new Logger();
            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            loggerThread.Start();

            watcher = new Watcher();
            watcher.Start();
        }
 
        protected override void OnStop()
        {
            logger.Stop();
            watcher.Stop();
            Thread.Sleep(1000);
        }
    }
}