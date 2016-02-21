using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms.UserControls
{
    public partial class uc_MenuBar : DockContent
    {
        private const string PanelTitle = "Main Menu";
        public uc_MenuBar()
        {
            InitializeComponent();
            this.TabText = PanelTitle;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            SetToolTip((Control)sender, "New Project", 
                "Clicking this button opens the form to create a new project");
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            SetToolTip((Control)sender, "New Task",
                "Clicking this button opens the form to create a new task");
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            SetToolTip((Control)sender, "New Survey",
                "Clicking this button opens the form to create a new survey");
        }

        private void SetToolTip(Control pControl, string pTitle, string pText)
        {
            toolTip1.ToolTipTitle = pTitle;
            toolTip1.SetToolTip(pControl, pText);
        }
    }
}
