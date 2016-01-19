using System;
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
            trace = new TraceManager("MoCap.trc", "C:\\Test", 0);
            for (int i = 0; i < 150; i++)
            {
                if (i == 1)
                {
                    trace.Log(new LogMessage("This is a message with all shabang " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.fff") + " item " + i.ToString(),
                        MessageType.EnterScope, 22, "defhj", "INIT", "dsjaklsjd", "Compo"));
                }
                else if (i == 4)
                {
                    trace.Log(new LogMessage("This is a message with all shabang " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.fff") + " item " + i.ToString(),
                        MessageType.EnterScope, 22, "defhj", "INIT", "dsjaklsjd", "Compo"));
                }
                else if(i==20)
                {
                    trace.Log(new LogMessage("This is a message with all shabang " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.fff") + " item " + i.ToString(),
                        MessageType.ExitScope, 22, "defhj", "INIT", "dsjaklsjd", "Compo"));
                }
                else if (i == 29)
                {
                    trace.Log(new LogMessage("This is a message with all shabang " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.fff") + " item " + i.ToString(),
                        MessageType.ExitScope, 22, "defhj", "INIT", "dsjaklsjd", "Compo"));
                }
                else
                {
                    trace.Log(new LogMessage("This is a message with all shabang " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.fff") + " item " + i.ToString(),
                        MessageType.Info, 22, "defhj", "INIT", "dsjaklsjd", "Compo"));
                }
            }
            trace.Dispose();
            trace = null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.DefaultExt = "Trace Files|*.trc;*.mocapLog;";
            openFileDialog1.Title = "Select log file to open";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                trace = new TraceManager(openFileDialog1.FileName);
            }
        }
    }
}
