using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
