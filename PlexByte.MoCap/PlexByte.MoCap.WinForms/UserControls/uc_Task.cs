using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms.UserControls
{
    public partial class uc_Task : DockContent
    {
        private const string PanelTitle = "Task Details";

        public uc_Task()
        {
            InitializeComponent();
            this.TabText = PanelTitle;
        }
    }
}
