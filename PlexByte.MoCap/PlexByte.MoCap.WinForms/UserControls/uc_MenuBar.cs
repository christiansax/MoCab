//////////////////////////////////////////////////////////////
//                      Windows form uc_MenuBar                              
//      Author: Christian B. Sax            Date:   2016/02/14
//      Contains the menu layer form, which is docked in the main form
using System;
using System.Windows.Forms;
using MoCap.PlexByte.MoCap.WinForms;
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms.UserControls
{
    public partial class uc_MenuBar : DockContent
    {
        public uc_MenuBar()
        {
            InitializeComponent();
        }

        public void RegisterEvents(UIManager pManagerInstance)
        {
            btn_Task.Click += new System.EventHandler(pManagerInstance.MenuButtonClicked);
            btn_Project.Click += new System.EventHandler(pManagerInstance.MenuButtonClicked);
            btn_Account.Click += new System.EventHandler(pManagerInstance.MenuButtonClicked);
            btn_Expense.Click += new System.EventHandler(pManagerInstance.MenuButtonClicked);
            btn_Survey.Click += new System.EventHandler(pManagerInstance.MenuButtonClicked);
            btn_SurveyOptions.Click += new System.EventHandler(pManagerInstance.MenuButtonClicked);
            btn_Timeslice.Click += new System.EventHandler(pManagerInstance.MenuButtonClicked);
            btn_User.Click += new System.EventHandler(pManagerInstance.MenuButtonClicked);
            btn_Vote.Click += new System.EventHandler(pManagerInstance.MenuButtonClicked);
        }

        private void Project_MouseEnter(object sender, EventArgs e)
        {
            SetToolTip((Control)sender, "New Project", 
                "Clicking this button opens the form to create a new project");
        }

        private void Task_MouseEnter(object sender, EventArgs e)
        {
            SetToolTip((Control)sender, "New Task",
                "Clicking this button opens the form to create a new task");
        }

        private void Survey_MouseEnter(object sender, EventArgs e)
        {
            SetToolTip((Control)sender, "New Survey",
                "Clicking this button opens the form to create a new survey");
        }

        private void Account_MouseEnter(object sender, EventArgs e)
        {
            SetToolTip((Control)sender, "Account",
                "Clicking this button opens the account details view");
        }

        private void SurveyOptions_MouseEnter(object sender, EventArgs e)
        {
            SetToolTip((Control)sender, "Survey Options",
                "Clicking this button opens the survey options dialog");
        }

        private void Vote_MouseEnter(object sender, EventArgs e)
        {
            SetToolTip((Control)sender, "Vote",
                "Clicking this button opens the voting dialog");
        }

        private void Expense_MouseEnter(object sender, EventArgs e)
        {
            SetToolTip((Control)sender, "Expense",
                "Clicking this button opens the expense dialog");
        }

        private void Timeslice_MouseEnter(object sender, EventArgs e)
        {
            SetToolTip((Control)sender, "Timeslice",
                "Clicking this button opens the timeslice dialog");
        }

        private void User_MouseEnter(object sender, EventArgs e)
        {
            SetToolTip((Control)sender, "Account",
                "Clicking this button opens the User dialog");
        }

        private void SetToolTip(Control pControl, string pTitle, string pText)
        {
            toolTip1.ToolTipTitle = pTitle;
            toolTip1.SetToolTip(pControl, pText);
        }
    }
}
