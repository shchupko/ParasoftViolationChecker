using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using NarrowViol;

namespace viol
{




    public partial class Form1 : Form
    {
        //public Config conf = new Config();
        public Watcher watcher = new Watcher();

        public Form1()
        {
            InitializeComponent();
            //parse(Path.Combine(conf.path, "cs_violations - save1312.xml"));
            //watcher.Init(conf);
        }

        private void tsMenuLog_LoadFile_Click(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = ".xml";
            openFileDialog.Filter = "cs_violations*.xml|cs_violations*.xml|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Config.path;
            openFileDialog.ShowDialog();
            if (!openFileDialog.FileName.Equals(""))
            {
                LogRText.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                //parse(openFileDialog.FileName);
            }

            //if (LogRText.Text.Length > 0)
            //    ExtractEventsItem.Enabled = true;
            //LogStatus.Text = openFileDialog.FileName;
        }



        private void LogRText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
