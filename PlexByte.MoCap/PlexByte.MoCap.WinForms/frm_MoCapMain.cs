//////////////////////////////////////////////////////////////
//                      Windows form frm_MoCapMain                              
//      Author: Christian B. Sax            Date:   2016/02/14
//      The main layer of mocap application holding any other form within docking pannel

using System;
using System.Windows.Forms;
using PlexByte.MoCap.Security;
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms
{
    public partial class frm_MoCapMain : Form
    {
        public DockPanel Panel => dockPanel1;
        public UIManager UIManager => _uiManager;

        /// <summary>
        /// The user this datamanager runs under
        /// </summary>
        public User LoggedInUser { get; set; }

        private readonly UIManager _uiManager;

        public frm_MoCapMain()
        {
            InitializeComponent();
            try
            {
                _uiManager = new UIManager(this);
                _uiManager.AddMenuBar();
                _uiManager.AddOverview();
                _uiManager.AddUserPanel();

                dockPanel1.DockTopPortion = 80.00;
                dockPanel1.DockLeftPortion = 300.00;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void ShowErrorMessage(string pErrorMessage)
        {
            if(MessageBox.Show(pErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                this.Enabled=true;
        }
    }
}
