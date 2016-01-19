using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MoCap.Logging;

namespace MoCap.LogViewer
{
    public partial class frm_LogMessage : Form
    {
        TraceManager trace;

        public frm_LogMessage()
        {
            InitializeComponent();
            trace = new TraceManager("MoCap.trc", "E:\\Test", 0);
            for(int i=0;i<150;i++)
            trace.Log(new LogMessage("This is a message with all shabang " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.fff")+" item "+i.ToString(),
                MessageType.Info, 22, "defhj", "INIT", "dsjaklsjd", "Compo"));

            trace = null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trace = new TraceManager();
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.DefaultExt = "Trace Files|*.trc;*.mocapLog;";
            openFileDialog1.Title = "Select log file to open";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<LogMessage> messages = trace.ReadLogFile(openFileDialog1.FileName);
            }
        }
    }
}
