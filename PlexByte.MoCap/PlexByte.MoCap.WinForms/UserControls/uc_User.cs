//////////////////////////////////////////////////////////////
//                      UserControl uc_User
//      Author: Christian B. Sax            Date:   2016/03/16
//      This control is used for any user related features such as new user, login, logout and edit
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms.UserControls
{
    public partial class uc_User : DockContent
    {
        private const string PanelTitle = "User Details";

        public uc_User()
        {
            InitializeComponent();
            this.TabText = PanelTitle;
        }

        public void RegisterEvents(UIManager pManagerInstance)
        {
            btn_Edit.Click += new System.EventHandler(pManagerInstance.UserButtonClicked);
            btn_Login.Click += new System.EventHandler(pManagerInstance.UserButtonClicked);
            btn_New.Click += new System.EventHandler(pManagerInstance.UserButtonClicked);
        }

        public void ToggelEnabled()
        {
            
        }
    }
}
