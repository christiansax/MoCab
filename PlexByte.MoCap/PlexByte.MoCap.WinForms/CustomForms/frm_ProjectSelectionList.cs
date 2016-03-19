//////////////////////////////////////////////////////////////
//                      Form frm_ProjectSelectionList
//      Author: Christian B. Sax            Date:   2016/03/18
//      This form displays a list of projects, whereof one is selected by doubleclicking it.
//      Subsequently the selected project Id is set and the dialogresult is set to ok
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
            {
                SelectedProjectId = dgw_Projects.SelectedRows[0].Cells["Id"].ToString();
                DialogResult=DialogResult.OK;
                Close();
            }
        }
    }
}
