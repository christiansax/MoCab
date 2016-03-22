using System;
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms.UserControls
{
    public partial class uc_Project : DockContent
    {
        private const string PanelTitle = "Project Details";

        public uc_Project()
        {
            InitializeComponent();
            this.TabText = PanelTitle;
        }
        public void RegisterEvents(UIManager pManagerInstance)
        {
            btn_Create.Click += new EventHandler(pManagerInstance.ProjectButtonClicked);
            btn_Update.Click += new EventHandler(pManagerInstance.ProjectButtonClicked);
            btn_InviteUser.Click += new EventHandler(pManagerInstance.ProjectButtonClicked);
            btn_ChangeOwner.Click += new EventHandler(pManagerInstance.ProjectButtonClicked);
        }
    }
}
