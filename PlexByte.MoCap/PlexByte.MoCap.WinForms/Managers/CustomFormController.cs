//////////////////////////////////////////////////////////////
//                      Class CustomFormCOntroller
//      Author: Christian B. Sax            Date:   2016/03/18
//      This class manages the event being raised by the form contained in the CustomForms folder
using System;
using System.Windows.Forms;
using PlexByte.MoCap.WinForms.CustomForms;

namespace PlexByte.MoCap.WinForms.Managers
{
    public class CustomFormController
    {
        private Form _instance = null;

        public CustomFormController(Form pInstance) { _instance = pInstance; }

        /// <summary>
        /// This method manages the functionality of the frm_ProjectSelectionList
        /// </summary>
        /// <param name="sender">The object raising the event</param>
        /// <param name="e">The event argument for this event</param>
        public void ProjectSelectionListController(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// This method manages the functionality of the frm_UserSelectionList
        /// </summary>
        /// <param name="sender">The object raising the event</param>
        /// <param name="e">The event argument for this event</param>
        public void UserSelectionListController(object sender, EventArgs e)
        {
            frm_UserSelectionList gui = (frm_UserSelectionList) _instance;
            switch (((Button)sender).Text.ToLower())
            {
                case "add >>":
                    gui.UserSelectionAddUser();
                    break;
                case "<< Remove":
                    gui.UserSelectionRemoveUser();
                    break;
                case "ok":
                    gui.UserSelectionOk();
                    break;
                default:
                    return;
            }
        }
    }
}
