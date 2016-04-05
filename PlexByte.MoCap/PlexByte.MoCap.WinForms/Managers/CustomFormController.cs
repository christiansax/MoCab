//////////////////////////////////////////////////////////////
//                      Class CustomFormCOntroller
//      Author: Christian B. Sax            Date:   2016/03/18
//      This class manages the event being raised by the form contained in the CustomForms folder
using System;
using System.Data;
using System.Windows.Forms;
using PlexByte.MoCap.Backend;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;
using PlexByte.MoCap.WinForms.CustomForms;

namespace PlexByte.MoCap.WinForms.Managers
{
    public class CustomFormController
    {
        private Form _instance = null;
        private string _userId = null;

        public CustomFormController(Form pInstance, string pUserId)
        {
            _instance = pInstance;
            _userId = pUserId;
        }

        /// <summary>
        /// This method manages the functionality of the frm_ProjectSelectionList
        /// </summary>
        /// <param name="sender">The object raising the event</param>
        /// <param name="e">The event argument for this event</param>
        public void ProjectSelectionListController(object sender, EventArgs e)
        {
            
        }

        public void TaskUpdateProgress(object sender, EventArgs e)
        {
            if (((Button) sender).Text.ToLower() == "update")
            {
                ((frm_TaskUpdateProgress)_instance).UpdateType = 1;
                _instance.DialogResult= DialogResult.OK;
            }
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

        public void FillUserGrid(string pProjectId)
        {
            BackendService backend = new BackendService();
            DataTable users = backend.GetAllReferencedUsers(_userId);
            backend = null;
            foreach (DataRow row in users.Rows)
            {
                ((frm_UserSelectionList) _instance).AddAvailableUser(row["Id"].ToString(),
                    row["Username"].ToString(),
                    row["FirstName"].ToString(),
                    row["LastName"].ToString());
            }
        }
    }
}
