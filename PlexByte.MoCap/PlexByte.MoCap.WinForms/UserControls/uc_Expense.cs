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
    public partial class uc_Expense : DockContent
    {
        private const string PanelTitle = "Expense Details";

        public uc_Expense()
        {
            InitializeComponent();
            this.TabText = PanelTitle;
        }
    }
}
