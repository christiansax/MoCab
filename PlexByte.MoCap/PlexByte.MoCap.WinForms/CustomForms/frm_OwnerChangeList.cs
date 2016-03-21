using PlexByte.MoCap.Security;
using PlexByte.MoCap.WinForms.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlexByte.MoCap.WinForms.CustomForms
{
    public partial class frm_OwnerChangeList : Form
    {
        private string _projectId = null;
        private string _UserId = null;
        List<IUser> _MemberList = null;

        public frm_OwnerChangeList(List<IUser> MemberList,string pUserId)
        {
            InitializeComponent();


            //Register event handlers
            CustomFormController controller = new CustomFormController(this, pUserId);
            btn_OK.Click += controller.UserSelectionListController;
            _UserId = pUserId;
            _MemberList = MemberList;
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

        }
    }
}
