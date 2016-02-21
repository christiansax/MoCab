//////////////////////////////////////////////////////////////
//      Overview form listing all items in the main form, 
//      docked on the left side                              
//      Author: Christian B. Sax            Date:   2016/02/21
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms.UserControls
{
    public partial class uc_Overview : DockContent
    {
        /// <summary>
        /// The text shown in the tab title
        /// </summary>
        private const string ControlTitle = "Interactions Overview";

        public uc_Overview()
        {
            InitializeComponent();
            this.TabText = ControlTitle;
        }
    }
}
