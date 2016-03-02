//////////////////////////////////////////////////////////////
//                      Windows form frm_MoCapMain                              
//      Author: Christian B. Sax            Date:   2016/02/14
//      The main layer of mocap application holding any other form within docking pannel
using System.Windows.Forms;
using PlexByte.MoCap.WinForms.UserControls;
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms
{
    public partial class frm_MoCapMain : Form
    {
        private uc_Overview OverviewPannel = new uc_Overview();
        public frm_MoCapMain()
        {
            InitializeComponent();
            // Place overview panel on the left and dock
            OverviewPannel.Show(dockPanel1, DockState.DockLeft);
            uc_Task taskPanel1 = new uc_Task();
            taskPanel1.Show(dockPanel1, DockState.Document);
            uc_Survey surveyPanel1 = new uc_Survey();
            surveyPanel1.Show(dockPanel1, DockState.Document);
            uc_MenuBar menu = new uc_MenuBar();
            menu.Show(dockPanel1, DockState.DockTop);
            dockPanel1.DockTopPortion = 100.00;
            dockPanel1.DockLeftPortion = 300.00;
        }
    }
}
