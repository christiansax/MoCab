//////////////////////////////////////////////////////////////
//                      Windows form uc_Task                              
//      Author: Christian B. Sax            Date:   2016/02/14
//      The task details form containing any task detail and is docked as document type in the main form
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms.UserControls
{
    public partial class uc_Survey : DockContent
    {
        public string Id { get; set; }
        public string InteractionId { get; set; }
        private const string PanelTitle = "Survey Details";

        public uc_Survey()
        {
            InitializeComponent();
            this.TabText = PanelTitle;
        }
    }
}
