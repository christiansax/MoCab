//////////////////////////////////////////////////////////////
//                      Form frm_UserSelectionList
//      Author: Christian B. Sax            Date:   2016/03/18
//      This form allows you to select users from a given list, which is populated by the 
//      calling object
using System.Collections.Generic;
using System.Windows.Forms;
using PlexByte.MoCap.WinForms.Managers;

namespace PlexByte.MoCap.WinForms.CustomForms
{
    public partial class frm_UserSelectionList : Form
    {
        public List<string> UserIds { get; private set; }
        private string _projectId = null;
        private string _UserId = null;

        public frm_UserSelectionList(string pProjectId, string pUserId)
        {
            InitializeComponent();

            //Register event handlers
            CustomFormController controller = new CustomFormController(this, pUserId);
            btn_Add.Click += controller.UserSelectionListController;
            btn_OK.Click += controller.UserSelectionListController;
            btn_Remove.Click += controller.UserSelectionListController;
            _projectId = pProjectId;
            _UserId = pUserId;
            controller.FillUserGrid(_projectId);
        }

        /// <summary>
        /// Adds a user to the availableUsers datagridview
        /// </summary>
        /// <param name="pId">The id of the user</param>
        /// <param name="pUserName">The username</param>
        /// <param name="pFirstName">The users first name</param>
        /// <param name="pLastName">The users last name</param>
        public void AddAvailableUser(string pId, string pUserName, string pFirstName, string pLastName) { dgw_AvailUsers.Rows.Add(pId, pUserName, pFirstName, pLastName); }

        /// <summary>
        /// Adds a row from availableUsers to selectedUsers, updates the UserIds and removes the row from the availableUsers dgw
        /// </summary>
        public void UserSelectionAddUser()
        {
            if (dgw_AvailUsers.SelectedRows.Count > 0)
            {
                if (dgw_AvailUsers.CurrentCell.RowIndex > -1)
                {
                    UserIds.Add(dgw_AvailUsers.Rows[0].Cells["Id"].ToString());
                    dgw_SelectedUsers.Rows.Add(dgw_AvailUsers.SelectedRows[0]);
                    dgw_AvailUsers.Rows.Remove(dgw_AvailUsers.SelectedRows[0]);
                }
                dgw_AvailUsers.Refresh();
                dgw_SelectedUsers.Refresh();
            }
        }

        /// <summary>
        /// Removes a row from selectedUsers, updates the UserIds and adds the row to the availableUsers dgw
        /// </summary>
        public void UserSelectionRemoveUser()
        {
            if (dgw_SelectedUsers.SelectedRows.Count > 0)
            {
                if (dgw_SelectedUsers.CurrentCell.RowIndex > -1)
                {
                    UserIds.Remove(dgw_AvailUsers.SelectedRows[0].Cells["Id"].ToString());
                    dgw_AvailUsers.Rows.Add(dgw_AvailUsers.SelectedRows[0]);
                    dgw_SelectedUsers.Rows.Remove(dgw_AvailUsers.SelectedRows[0]);
                }
                dgw_AvailUsers.Refresh();
                dgw_SelectedUsers.Refresh();
            }
        }

        public void UserSelectionOk()
        {
            DialogResult= DialogResult.OK;
            Close();
        }
    }
}
