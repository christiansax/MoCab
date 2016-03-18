using System.Windows.Forms;

namespace PlexByte.MoCap.WinForms.CustomForms
{
    public partial class frm_ProjectSelectionList : Form
    {
        public frm_ProjectSelectionList()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Select the project to which the interaction will be associated or cancel this " +
                                         "dialog and create a new project first";
        }
    }
}
