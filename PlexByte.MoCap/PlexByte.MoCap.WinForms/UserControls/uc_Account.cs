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
    }
}
