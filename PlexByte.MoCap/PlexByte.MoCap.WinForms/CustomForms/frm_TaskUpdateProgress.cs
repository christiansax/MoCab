//////////////////////////////////////////////////////////////
//                      Form frm_TaskUpdateProgress
//      Author: Christian B. Sax            Date:   2016/03/5
//      This form displays the options to update a task by adding hours or a percentage
using System;
using System.Windows.Forms;
using PlexByte.MoCap.WinForms.Managers;

namespace PlexByte.MoCap.WinForms.CustomForms
{
    public partial class frm_TaskUpdateProgress : Form
    {
        public int UpdateValue { get; set; }
        public int UpdateType { get; set; } // 1=Progress, 2=Time, 3=Expense

        public frm_TaskUpdateProgress()
        {
            InitializeComponent();
            CustomFormController tmp=new CustomFormController(this, null);
            btn_Update.Click += tmp.TaskUpdateProgress;
        }

        public void SetTaskName(string pTaskName) { lbl_Task.Text = pTaskName; }
        public void SetProjectName(string ProjectName) { lbl_Project.Text = ProjectName; }

        private void num_Progress_ValueChanged(object sender, EventArgs e)
        {
            btn_Update.Enabled = num_Progress.Value > 0;
            UpdateValue = (int)num_Progress.Value;
        }

        private void num_Time_ValueChanged(object sender, EventArgs e)
        {
            btn_Add.Enabled = num_Time.Value > 0;
            UpdateValue = (int)num_Time.Value;
        }

        private void num_Value_ValueChanged(object sender, EventArgs e)
        {
            btn_Invoice.Enabled = num_Value.Value > 0;
            UpdateValue = (int)num_Value.Value;
        }
    }
}
