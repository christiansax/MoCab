﻿using System.Windows.Forms;
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
            uc_Task f2 = new uc_Task();
            f2.Show(dockPanel1, DockState.Document);
            uc_MenuBar menu = new uc_MenuBar();
            menu.Show(dockPanel1, DockState.DockTop);
            dockPanel1.DockTopPortion = 100.00;
            dockPanel1.DockLeftPortion = 300.00;
        }
    }
}