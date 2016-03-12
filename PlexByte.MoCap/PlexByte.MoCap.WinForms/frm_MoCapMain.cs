//////////////////////////////////////////////////////////////
//                      Windows form frm_MoCapMain                              
//      Author: Christian B. Sax            Date:   2016/02/14
//      The main layer of mocap application holding any other form within docking pannel
using System.Windows.Forms;
using MoCap.PlexByte.MoCap.WinForms;
using PlexByte.MoCap.WinForms.UserControls;
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms
{
    public partial class frm_MoCapMain : Form
    {
        public DockPanel Panel => dockPanel1;
        public UIManager UIManager => _uiManager;


        private readonly UIManager _uiManager;

        public frm_MoCapMain()
        {
            InitializeComponent();
            _uiManager = new UIManager(this);
            _uiManager.AddMenuBar();
            _uiManager.AddOverview();
            _uiManager.AddUserPanel();

            dockPanel1.DockTopPortion = 80.00;
            dockPanel1.DockLeftPortion = 300.00;
        }
    }
}
