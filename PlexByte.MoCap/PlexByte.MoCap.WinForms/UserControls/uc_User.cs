using MoCap.PlexByte.MoCap.WinForms;
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms.UserControls
{
    public partial class uc_User : DockContent
    {
        private const string PanelTitle = "User Details";

        public uc_User()
        {
            InitializeComponent();
            this.TabText = PanelTitle;
        }

        public void RegisterEvents(UIManager pManagerInstance)
        {
            btn_Edit.Click += new System.EventHandler(pManagerInstance.UserButtonClicked);
            btn_Login.Click += new System.EventHandler(pManagerInstance.UserButtonClicked);
            btn_New.Click += new System.EventHandler(pManagerInstance.UserButtonClicked);
        }
    }
}
