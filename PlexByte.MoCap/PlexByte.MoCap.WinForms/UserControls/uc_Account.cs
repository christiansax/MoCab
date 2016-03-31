using System;
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms.UserControls
{
    public partial class uc_Account : DockContent
    {
        private const string PanelTitle = "Account Details";

        public uc_Account()
        {
            InitializeComponent();
            this.TabText = PanelTitle;
        }


        public void RegisterEvents(UIManager pManagerInstance)
        {
            btn_AssignProject.Click += new EventHandler(pManagerInstance.ProjectButtonClicked);
            btn_Update.Click += new EventHandler(pManagerInstance.ProjectButtonClicked);

        }
    }
}
