//////////////////////////////////////////////////////////////
//                      Form frm_TaskUpdateProgress
//      Author: Christian B. Sax            Date:   2016/03/5
//      This form displays the options to update a task by adding hours or a percentage
using System;
using System.Windows.Forms;

namespace PlexByte.MoCap.WinForms.CustomForms
{
    public partial class frm_TaskUpdateProgress : Form
    {
        public frm_TaskUpdateProgress() { InitializeComponent(); }

        private void num_Progress_ValueChanged(object sender, EventArgs e) { btn_Update.Enabled = num_Progress.Value > 0; }

        private void num_Time_ValueChanged(object sender, EventArgs e) { btn_Add.Enabled = num_Time.Value > 0; }

        private void num_Value_ValueChanged(object sender, EventArgs e) { btn_Invoice.Enabled = num_Value.Value > 0; }
    }
}
