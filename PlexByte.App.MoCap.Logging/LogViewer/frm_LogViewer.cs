using System;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using MoCap.Logging;

namespace MoCap.LogViewer
{
    public partial class frm_LogMessage : Form
    {
        public delegate void UpdateStatusLabelHandler(string pValue);
        public delegate void UpdateProgressbarHandler(int pValue);
        public delegate void AddFormatedMessageHandler(FormattedLogMessage pMessage);

        private TraceManager trace = null;
        int curRow = -1;

        public frm_LogMessage()
        {
            InitializeComponent();
            Thread.CurrentThread.Name = "LogViewer_Main";
            InitializeToolTips();
            toolStripStatusLabel1.Text = "Ready";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.DefaultExt = "Trace Files|*.trc;*.mocapLog;";
            openFileDialog1.Title = "Select log file to open";
            openFileDialog1.FileName = "MoCap.trc";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                new Thread(delegate () {
                    ReadLogFile(openFileDialog1.FileName);
                }).Start();
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void InitializeToolTips()
        {
            toolStripButton1.ToolTipText = "Open";
            toolStripButton2.ToolTipText = "Refresh";
            toolStripButton3.ToolTipText = "Auto Refresh";
            toolStripButton4.ToolTipText = "Bookmark";
            toolStripButton5.ToolTipText = "Jump to date time";
            toolStripButton6.ToolTipText = "Filter";
            toolStripButton7.ToolTipText = "Clear Bookmark";
            toolStripButton8.ToolTipText = "Clear date time selector";
            toolStripButton9.ToolTipText = "Clear Filter";
            toolStripButton10.ToolTipText = "Find String";
        }

        private void ReadLogFile(string pFullFilePath)
        {
            try
            {
                trace = new TraceManager(pFullFilePath);
                long numMsg = 0;
                long currNum = 0;

                TimeSpan duration = DateTime.Now.TimeOfDay;
                foreach (LogMessage msg in trace.ReadLogFile(trace.LogPath + "\\" + trace.RecentLogFileName, out numMsg))
                {
                    currNum++;
                    UpdateStatusLabel(String.Format("Reading {0} out of {1} Messages...", currNum, numMsg).ToString());
                    AddFormatedMessage(new FormattedLogMessage(msg, trace.IndentPrefix));
                    UpdateProgressBar(Convert.ToInt32(Convert.ToDouble(currNum) / Convert.ToDouble(numMsg) * 100));
                }
                duration = DateTime.Now.TimeOfDay - duration;
                UpdateStatusLabel(String.Format("All messages read in {0}.{1} seconds [TotalMessage={2}]",
                    duration.Seconds, (duration.Milliseconds < 100) ? 
                    "0" + duration.Milliseconds.ToString() : duration.Milliseconds.ToString(), numMsg));
                UpdateProgressBar(0);
            }
            catch { }
        }

        private void AddFormatedMessage(FormattedLogMessage pMessage)
        {
            if (this.InvokeRequired)
            {
                var d = new AddFormatedMessageHandler(AddFormatedMessage);
                this.Invoke(d, new object[] { pMessage });
            }
            else
                formattedLogMessageBindingSource.Add(pMessage);
        }

        public void UpdateStatusLabel(string pValue)
        {
            if (this.InvokeRequired)
            {
                UpdateStatusLabelHandler d = new UpdateStatusLabelHandler(UpdateStatusLabel);
                this.Invoke(d, new object[] { pValue });
            }
            else
                toolStripStatusLabel1.Text = pValue;
        }

        private void UpdateProgressBar(int pValue)
        {
            if (InvokeRequired)
            {
                var d = new UpdateProgressbarHandler(UpdateProgressBar);
                this.Invoke(d, new object[] { pValue });
            }
            else
                toolStripProgressBar1.Value = pValue;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (((FormattedLogMessage)row.DataBoundItem).MessageColor!=System.Drawing.Color.Transparent)
                    row.DefaultCellStyle.BackColor = ((FormattedLogMessage)row.DataBoundItem).MessageColor;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != curRow)
            {
                FormattedLogMessage fmt = (FormattedLogMessage)dataGridView1.CurrentRow.DataBoundItem;
                StringBuilder sb = new StringBuilder();
                sb.Append(fmt.SourceFile);
                sb.Append(Environment.NewLine);
                sb.Append(fmt.Component + "." + fmt.MethodDefinition);
                sb.Append(Environment.NewLine);
                sb.Append("Line " + fmt.LineNumber);
                sb.Append("\t\t\t");
                sb.Append("Level " + fmt.Level);
                sb.Append("\t\t\t");
                sb.Append("At " + fmt.TimeStamp);
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append(fmt.Message);
                tbx_MessageDetail.Text = sb.ToString();
                sb = null;
                fmt = null;
            }
            curRow = dataGridView1.CurrentRow.Index;
        }
    }
}
