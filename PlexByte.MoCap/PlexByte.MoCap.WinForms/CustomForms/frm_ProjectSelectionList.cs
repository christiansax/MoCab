using System.Windows.Forms;

namespace PlexByte.MoCap.WinForms.CustomForms
{
    public partial class frm_ProjectSelectionList : Form
    {
        public string SelectedProjectId { get; private set; } = null;

        public frm_ProjectSelectionList()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Select the project to which the interaction will be associated or cancel this " +
                                         "dialog and create a new project first";
        }

        private void dgw_Projects_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgw_Projects.SelectedRows.Count > 0)
                SelectedProjectId = dgw_Projects.SelectedRows[0].Cells["Id"].ToString();
        }
    }
}
