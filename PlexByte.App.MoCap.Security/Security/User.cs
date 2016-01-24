using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MoCap.Security
{
    #region Delegates

    public delegate void LogInEventHandler(object sender, UserEventArgs e);
    public delegate void LogOutEventHandler(object sender, UserEventArgs e);
    public delegate void InviteEventHandler(object sender, UserEventArgs e);
    public delegate void AcceptInviteEventHandler(object sender, UserEventArgs e);
    public delegate void DeclinedInviteEventHandler(object sender, UserEventArgs e);

    #endregion

    public class User : IPerson
    {
        #region Properties

        [ConfigurationProperty("FirstName", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 2, MaxLength = 250)]
        public string FirstName { get; set; }
        [ConfigurationProperty("MiddleName", DefaultValue = "", IsRequired = false)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 2, MaxLength = 250)]
        public string MiddleName { get; set; }
        [ConfigurationProperty("LastName", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 2, MaxLength = 250)]
        public string LastName { get; set; }
        [ConfigurationProperty("IsActive", DefaultValue = "", IsRequired = true)]
        public bool IsActive { get; set; }
        [ConfigurationProperty("EmailAddress", DefaultValue = "", IsRequired = false)]
        [StringValidator(InvalidCharacters = "~!#$%^&*()[]{}/;'\"|\\", MinLength = 2, MaxLength = 250)]
        public string EmailAddress { get; set; }
        [ConfigurationProperty("Created", DefaultValue = "", IsRequired = true)]
        public DateTime Created { get; set; }
        [ConfigurationProperty("Modified", DefaultValue = "", IsRequired = true)]
        public DateTime Modified { get; set; }

        [ConfigurationProperty("UserName", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!#$%^&*()[]{}/;'\"|\\", MinLength = 2, MaxLength = 250)]
        public string UserName { get; }
        public Session Connection { get; set; }

        #endregion

        #region Variables

        #endregion

        #region Events

        public event LogInEventHandler LoggedIn;
        public event LogOutEventHandler LoggedOut;
        public event InviteEventHandler Invited;
        public event AcceptInviteEventHandler AcceptedInvite;
        public event DeclinedInviteEventHandler DeclinedInvite;

        #endregion

        #region Ctor & Dtor

        public User(string pUserName)
        {
            UserName = pUserName;
        }

        #endregion

        #region Methods

        public bool LogIn(Session pSession)
        {
            return false;
        }

        public bool LogOut(Session pSession)
        {
            return false;
        }

        public bool Invite(IPerson pPerson)
        {
            return false;
        }

        public bool Invite(IPerson pPerson, Project pProject)
        {
            return false;
        }

        public bool AcceptInvite(out Project pProject)
        {
            pProject = null;
            return false;
        }

        public bool DeclineInvite(out Project pProject)
        {
            pProject = null;
            return false;
        }

        #endregion

        #region Event handlers

        protected virtual void OnLogIn(UserEventArgs e)
        {
            if (LoggedIn != null)
                LoggedIn(this, e);
        }

        protected virtual void OnLogOut(UserEventArgs e)
        {
            if (LoggedOut != null)
                LoggedOut(this, e);
        }

        protected virtual void OnInite(UserEventArgs e)
        {
            if (Invited != null)
                Invited(this, e);
        }

        protected virtual void OnAcceptInite(UserEventArgs e)
        {
            if (AcceptedInvite != null)
                AcceptedInvite(this, e);
        }

        protected virtual void OnDeclineInite(UserEventArgs e)
        {
            if (DeclinedInvite != null)
                DeclinedInvite(this, e);
        }

        #endregion
    }

    /// <summary>
    /// Helper!
    /// </summary>
    public class Project { }//Helper until interactions component is finished
}
