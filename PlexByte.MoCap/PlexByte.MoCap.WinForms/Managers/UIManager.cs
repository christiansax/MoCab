//////////////////////////////////////////////////////////////
//                      Class UIManager
//      Author: Christian B. Sax            Date:   2016/03/16
//      This class manages the windows presented in the user interface. It further
//      registers to all available events and executes the corresponding action
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlexByte.MoCap.Backend;
using PlexByte.MoCap.Helpers;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;
using PlexByte.MoCap.WinForms.CustomForms;
using PlexByte.MoCap.WinForms.Managers;
using PlexByte.MoCap.WinForms.UserControls;
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms
{
    public enum UiType
    {
        User,
        Task,
        Project,
        Account, 
        Survey,
        Expense,
        Timeslice
    }

    /// <summary>
    /// This class is responsible for any window that is being presented to the user 
    /// and manages its corresponding events
    /// </summary>
    public class UIManager:IDisposable
    {
        #region Properties

        public User UserContext => _userContext;

        #endregion

        #region Variables

        private readonly frm_MoCapMain _MainUI = null;
        private readonly ErrorProvider _errorProvider = null;
        private DataManager _dataManager = null;
        private User _userContext = null;
        private uc_Overview _overviewPanel = null;
        private InteractionFactory _interactionFactory = null;
        private const string _longDateTimeFtm = "ddd dd MMM yyyy  HH:mm";
        private const string _DateTimeFtm = "yyyy.MM.dd HH:mm:ss";
        private const string _DateFtm = "yyyy.MM.dd";
        private const string _TimeFtm = "HH:mm:ss";
        private const string _dateTimeIdFmt = "yyyyMMddHHmmssfff";

        #endregion

        #region Ctor & Dtor

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="pMainUI">The pointer to the main form, which hosts any other window</param>
        public UIManager(frm_MoCapMain pMainUI)
        {
            _MainUI = pMainUI;
            _errorProvider = new ErrorProvider();
            _errorProvider.BlinkStyle= ErrorBlinkStyle.BlinkIfDifferentError;
            _dataManager=new DataManager();
            _interactionFactory=new InteractionFactory();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (UserContext != null)
                _userContext = null;
            if (_dataManager != null)
                _dataManager = null;

            _interactionFactory = null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds the user panel to the form and registers to its events
        /// </summary>
        public void AddUserPanel()
        {
            DockContent tmp = CreateContentPanel(UiType.User);
            tmp.TabText = "User Dialog";
            ((uc_User)tmp).RegisterEvents(this);
        }

        /// <summary>
        /// Adds the task panel to the form
        /// </summary>
        public void AddTaskPanel()
        {
            DockContent tmp = CreateContentPanel(UiType.Task);
            tmp.TabText = "Task Dialog";
            ((uc_Task)tmp).RegisterEvents(this);
        }

        /// <summary>
        /// Adds the survey panel to the form
        /// </summary>
        public void AddSurveyPanel()
        {
            DockContent tmp = CreateContentPanel(UiType.Survey);
            tmp.TabText = "Survey Dialog";
        }

        /// <summary>
        /// Adds the project panel to the form
        /// </summary>
        public void AddProjectPanel()
        {
            DockContent tmp = CreateContentPanel(UiType.Project);
            tmp.TabText = "Project Dialog";
            ((uc_Project)tmp).RegisterEvents(this);
        }

        /// <summary>
        /// Adds the account panel to the form
        /// </summary>
        public void AddAccoutPanel()
        {
            DockContent tmp = CreateContentPanel(UiType.Account);
            tmp.TabText = "Account Dialog";
        }

        /// <summary>
        /// Adds the expense panel to the form
        /// </summary>
        public void AddExpensePanel()
        {
            DockContent tmp = CreateContentPanel(UiType.Expense);
            tmp.TabText = "Expense Dialog";
        }

        /// <summary>
        /// Adds the timeslice panel to the form
        /// </summary>
        public void AddTimeslicePanel()
        {
            DockContent tmp = CreateContentPanel(UiType.Timeslice);
            tmp.TabText = "Timeslice Dialog";
        }

        /// <summary>
        /// Adds the menu bar and registers to its events
        /// </summary>
        public void AddMenuBar()
        {
            DockContent tmp = new uc_MenuBar();
            tmp.TabText = "Main Menu";
            tmp.CloseButton = false;
            tmp.Show(_MainUI.Panel, DockState.DockTop);
            ((uc_MenuBar) tmp).RegisterEvents(this);
        }

        /// <summary>
        /// Adds the overview panel and registers to its events
        /// </summary>
        public void AddOverview()
        {
            DockContent tmp = new uc_Overview(this);
            tmp.Show(_MainUI.Panel, DockState.DockLeft);
            _overviewPanel = (uc_Overview) tmp;
        }

        public DateTime LastUserLogin() { return _dataManager.GetLastUserLogin(UserContext.Id); }

        /// <summary>
        /// Eventlistener for the menu form. Any button event is captured here and corresponding action is executed
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        public void MenuButtonClicked(object sender, EventArgs e)
        {
            switch (((Button) sender).Name)
            {
                case "btn_User":
                    AddUserPanel();
                    break;
                case "btn_Survey":
                    AddSurveyPanel();
                    break;
                case "btn_Task":
                    AddTaskPanel();
                    break;
                case "btn_Project":
                    AddProjectPanel();
                    break;
                case "btn_Account":
                    AddAccoutPanel();
                    break;
                case "btn_Expense":
                    AddExpensePanel();
                    break;
                case "btn_Timeslice":
                    AddTimeslicePanel();
                    break;
                default:
                    break;
            }
        }

        public void UserButtonClicked(object sender, EventArgs e)
        {
            _errorProvider.Clear();
            List<Control> ctrls = GetAllControls(((Button)sender).Parent);
            switch (((Button) sender).Name)
            {
                case "btn_Edit":
                    UserButtonEdit(ctrls);
                    break;
                case "btn_New":
                    if(GetControlByName<Button>(ctrls, "btn_New").Text.ToLower()=="new")
                        UserButtonNew(ctrls);
                    else
                        UserButtonSave(ctrls);
                    break;
                case "btn_Login":
                    if (GetControlByName<Button>(ctrls, "btn_Login").Text.ToLower() == "login")
                        UserButtonLogin(ctrls);
                    else
                        UserButtonLogout(ctrls);
                    break;
                default:
                    break;
            }
        }

        public void TaskButtonClicked(object sender, EventArgs e)
        {
            _errorProvider.Clear();
            List<Control> ctrls = GetAllControls(((Button)sender).Parent);
            switch (((Button)sender).Name)
            {
                case "btn_New":
                    if (GetControlByName<Button>(ctrls, "btn_New").Text.ToLower() == "new")
                        TaskButtonNew(ctrls);
                    else
                        TaskButtonSave(ctrls);
                    break;
                case "btn_Update":
                    TaskButtonUpdate(ctrls);
                    break;
                case "btn_Subtask":
                    TaskButtonSubTask(ctrls);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Eventlistener for the Project form.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguements</param>
        internal void ProjectButtonClicked(object sender, EventArgs e)
        {
            _errorProvider.Clear();
            List<Control> ctrls = GetAllControls(((Button)sender).Parent);
            switch (((Button)sender).Name)
            {
                case "btn_Create":
                    if (GetControlByName<Button>(ctrls, "btn_Create").Text.ToLower() == "edit")
                        ProjectButtonEdit(ctrls);
                    else
                        ProjectButtonCreate(ctrls);
                    break;
                case "btn_Update":
                    ProjectButtonUpdatel(ctrls);
                    break;
                case "btn_InviteUser":
                    ProjectButtonInviteUser(ctrls);
                    break;
                case "btn_ChangeOwner":
                    ProjectButtonChangeOwner(ctrls);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Creates a dock content panel and returns its instance
        /// </summary>
        /// <param name="pType">The enumeration of panel type to create</param>
        /// <returns>DockContent representing the instance created</returns>
        private DockContent CreateContentPanel(UiType pType)
        {
            DockContent panel = null;
            switch (pType)
            {
                case UiType.Account:
                    panel = new uc_Account();
                    break;
                case UiType.Project:
                    panel = new uc_Project();
                    break;
                case UiType.Survey:
                    panel = new uc_Survey();
                    break;
                case UiType.Task:
                    panel = new uc_Task();
                    break;
                case UiType.User:
                    panel = new uc_User();
                    break;
                case UiType.Expense:
                    panel = new uc_Expense();
                    break;
                case UiType.Timeslice:
                    panel = new uc_Timeslice();
                    break;
                default:
                    break;
            }
            panel.Show(_MainUI.Panel, DockState.Document);
            panel.MdiParent = _MainUI;
            return panel;
        }

        /// <summary>
        /// This method loops through all controls on a form and adds them to a list
        /// </summary>
        /// <param name="container">The control to loop through</param>
        /// <returns>List of Controls that were found on the form</returns>
        private List<Control> GetAllControls(Control container)
        {
            List<Control> ctrlList = new List<Control>();
            foreach (Control c in container.Controls)
            {
                if (c.HasChildren)
                {
                    ctrlList.Add(c);
                    ctrlList.AddRange(GetAllControls(c));
                }
                else
                    ctrlList.Add(c);
            }
            return ctrlList;
        }

        /// <summary>
        /// This generic method returns the control fo type specified, which is named as provided in the controlName
        /// </summary>
        /// <typeparam name="T">The type of control to use</typeparam>
        /// <param name="pContainer">The parent container (form), which hosts the control</param>
        /// <param name="pControlName">The name of the control</param>
        /// <returns>Control of type T specified</returns>
        private T GetControlByName<T>(Control pContainer, string pControlName)
        {
            object control = default (T);
            try
            {
                List<Control> ctrls = GetAllControls(pContainer);
                foreach (var variable in ctrls)
                {
                    if (variable.GetType() == typeof (T))
                    {
                        if (variable.Name.ToLower() == pControlName.ToLower())
                            return (T)(control = variable);
                    }
                }
                return (T)control;
            }
            catch (Exception exp)
            {
                throw new Exception($"Expection while trying to get control of type {typeof(T).Name} and name {pControlName}. Excption message= {exp.Message}");
            }
        }

        /// <summary>
        /// This generic method was optimized to improved performance, as you can input the list of controls contained on the form,
        /// rather than generating the list of contained controls at with every call
        /// </summary>
        /// <typeparam name="T">The type of control to use</typeparam>
        /// <param name="pControls">The list of controls to search</param>
        /// <param name="pControlName">The name of the control</param>
        /// <returns>Control of type T specified</returns>
        private T GetControlByName<T>(List<Control> pControls, string pControlName)
        {
            object control = default(T);
            try
            {
                foreach (var variable in pControls)
                {
                    if (variable.GetType() == typeof(T))
                    {
                        if (variable.Name.ToLower() == pControlName.ToLower())
                            return (T)(control = variable);
                    }
                }
                return (T)control;
            }
            catch (Exception exp)
            {
                throw new Exception($"Expection while trying to get control of type {typeof (T).Name} and name {pControlName}. Excption message= {exp.Message}");
            }
        }

        /// <summary>
        /// This method either en- or disables the contols found on the uc_User form except controls excluded
        /// </summary>
        /// <param name="pControlList">The list of controls contained by the form</param>
        /// <param name="pExceptionList">The list of control to set opposit state</param>
        /// <param name="pIsEnabled">Indicating whether the controls should be enabled or not</param>
        private void UserButtonSetControlsState(List<Control> pControlList, List<Control> pExceptionList, bool pIsEnabled)
        {
            foreach (var control in pControlList)
            {
                if (!pExceptionList.Contains(control))
                    control.Enabled = pIsEnabled;
                else
                    control.Enabled = !pIsEnabled;
            }
        }

        /// <summary>
        /// This method deals with the New / Save button on the uc_User form
        /// </summary>
        /// <param name="pControlList">The list of controld contained on the form</param>
        private void UserButtonSave(List<Control> pControlList)
        {
            _errorProvider.Clear();
            // Initialize default values for controls
            GetControlByName<DateTimePicker>(pControlList, "dtp_Created").Value = DateTime.Now;
            GetControlByName<DateTimePicker>(pControlList, "dtp_Modified").Value = DateTime.Now;

            // Disable control list
            List<Control> expCtrls = new List<Control>();
            expCtrls.Add(GetControlByName<Button>(pControlList, "btn_Login"));
            expCtrls.Add(GetControlByName<Button>(pControlList, "btn_New"));
            UserButtonSetControlsState(pControlList, expCtrls, false);

            if (GetControlByName<Button>(pControlList, "btn_New").Text.ToLower() == "save")
            {
                // Save command
                try
                {
                    bool bError = false;
                    _MainUI.Enabled = false;

                    // Check if all fields have values
                    if (GetControlByName<TextBox>(pControlList, "tbx_FirstName").Text.Length < 1)
                    {
                        _errorProvider.SetError(GetControlByName<TextBox>(pControlList, "tbx_FirstName"),
                            "First name is not specified");
                        bError = true;
                    }
                    if(GetControlByName<TextBox>(pControlList, "tbx_LastName").Text.Length < 1)
                    { 
                        _errorProvider.SetError(GetControlByName<TextBox>(pControlList, "tbx_LastName"),
                            "Last name is not specified");
                        bError = true;
                    }
                    if (GetControlByName<TextBox>(pControlList, "tbx_Email").Text.Length < 1)
                    { 
                        _errorProvider.SetError(GetControlByName<TextBox>(pControlList, "tbx_Email"),
                            "Email is not specified");
                        bError = true;
                    }
                    if (GetControlByName<DateTimePicker>(pControlList, "dtp_Birthdate").Value>DateTime.Now.AddYears(-18))
                    { 
                        _errorProvider.SetError(GetControlByName<DateTimePicker>(pControlList, "dtp_Birthdate"),
                            "You must be 18+ to register with this service");
                        bError = true;
                    }
                    if (GetControlByName<TextBox>(pControlList, "tbx_UserName").Text.Length < 1)
                    { 
                        _errorProvider.SetError(GetControlByName<TextBox>(pControlList, "tbx_UserName"),
                            "User name is not specified");
                        bError = true;
                    }
                    if (GetControlByName<MaskedTextBox>(pControlList, "tbx_Password").Text.Length < 1)
                    { 
                        _errorProvider.SetError(GetControlByName<MaskedTextBox>(pControlList, "tbx_Password"),
                            "Password name is not specified");
                        bError = true;
                    }

                    if (!bError)
                    {
                        // Insert user in db
                        _dataManager.InsertUser(GetControlByName<TextBox>(pControlList, "tbx_Id").Text,
                            GetControlByName<TextBox>(pControlList, "tbx_FirstName").Text,
                            GetControlByName<TextBox>(pControlList, "tbx_LastName").Text,
                            GetControlByName<TextBox>(pControlList, "tbx_MiddleName").Text,
                            GetControlByName<TextBox>(pControlList, "tbx_Email").Text,
                            GetControlByName<DateTimePicker>(pControlList, "dtp_Birthdate").Value,
                            GetControlByName<TextBox>(pControlList, "tbx_UserName").Text,
                            CryptoHelper.Encrypt(GetControlByName<MaskedTextBox>(pControlList, "tbx_Password").Text,"MoCap"));

                        // Login using data given
                        UserButtonLogin(pControlList);
                        GetControlByName<Button>(pControlList, "btn_New").Text = "New";
                    }
                    else
                    {
                        // Enable control list
                        expCtrls = new List<Control>();
                        expCtrls.Add(GetControlByName<DateTimePicker>(pControlList, "dtp_Created"));
                        expCtrls.Add(GetControlByName<DateTimePicker>(pControlList, "dtp_Modified"));
                        expCtrls.Add(GetControlByName<TextBox>(pControlList, "tbx_Id"));
                        UserButtonSetControlsState(pControlList, expCtrls, true);
                        GetControlByName<Button>(pControlList, "btn_Edit").Visible = false;
                    }

                    // Enable Main GUI again
                    _MainUI.Enabled = true;
                }
                catch (Exception exp)
                {
                    _MainUI.ShowErrorMessage($"Exception while trying to save user. Exception thrown: {exp.Message}");
                    UserButtonSetControlsState(pControlList, expCtrls, true);
                }
            }
            else
            {
                // New command
                UserButtonSetControlsState(pControlList, expCtrls, true);
                GetControlByName<Button>(pControlList, "btn_New").Text = "Save";
            }
        }

        /// <summary>
        /// This mehtod deals with the Login button on the uc_User form
        /// </summary>
        /// <param name="pControlList">The list of controld contained on the form</param>
        private void UserButtonLogin(List<Control> pControlList)
        {
            try
            {
                // Disable control list
                List<Control> expCtrls = new List<Control>();
                expCtrls.Add(GetControlByName<Button>(pControlList, "btn_Login"));
                expCtrls.Add(GetControlByName<Button>(pControlList, "btn_New"));

                // There is no user context now, thus we attempt to login
                string sUserName = GetControlByName<TextBox>(pControlList, "tbx_username").Text;
                string sPassword = GetControlByName<MaskedTextBox>(pControlList, "tbx_password").Text;
                if (!string.IsNullOrEmpty(sUserName) && !string.IsNullOrEmpty(sPassword))
                {
                    _MainUI.Enabled = false;
                    _userContext = (User) _dataManager.AuthenticateUser(sUserName, sPassword);
                    _MainUI.Enabled = true;
                    GetControlByName<Button>(pControlList, "btn_Login").Text = "Logout";
                    GetControlByName<Button>(pControlList, "btn_Edit").Visible = true;

                    // Set Control values
                    GetControlByName<TextBox>(pControlList, "tbx_Id").Text = UserContext.Id;
                    GetControlByName<TextBox>(pControlList, "tbx_FirstName").Text = UserContext.FirstName;
                    GetControlByName<TextBox>(pControlList, "tbx_MiddleName").Text = UserContext.MiddleName;
                    GetControlByName<TextBox>(pControlList, "tbx_LastName").Text = UserContext.LastName;
                    GetControlByName<TextBox>(pControlList, "tbx_UserName").Text = UserContext.Username;
                    GetControlByName<MaskedTextBox>(pControlList, "tbx_Password").Text = UserContext.Password;
                    GetControlByName<TextBox>(pControlList, "tbx_Email").Text = UserContext.EmailAddress;
                    GetControlByName<DateTimePicker>(pControlList, "dtp_Birthdate").Value = UserContext.Birthdate;
                    GetControlByName<DateTimePicker>(pControlList, "dtp_Created").Value = UserContext.CreatedDateTime;
                    GetControlByName<DateTimePicker>(pControlList, "dtp_Modified").Value = UserContext.ModifiedDateTime;

                    DockContent tmp = (DockContent)pControlList[0].FindForm();
                    tmp.TabText = $"User Details ({UserContext.Username})";

                    _MainUI.Enabled = true;

                    GetControlByName<Button>(pControlList, "btn_Login").Text = "Logout";
                    GetControlByName<Button>(pControlList, "btn_New").Text = "New";
                    GetControlByName<Button>(pControlList, "btn_Edit").Visible = true;

                    expCtrls.Add(GetControlByName<Button>(pControlList, "btn_Edit"));
                }
                else
                {
                    expCtrls.Add(GetControlByName<TextBox>(pControlList, "tbx_UserName"));
                    expCtrls.Add(GetControlByName<MaskedTextBox>(pControlList, "tbx_Password"));
                    if (string.IsNullOrEmpty(sUserName))
                        _errorProvider.SetError(GetControlByName<TextBox>(pControlList, "tbx_username"), "UserName is not specified");
                    if (string.IsNullOrEmpty(sPassword))
                        _errorProvider.SetError(GetControlByName<MaskedTextBox>(pControlList, "tbx_password"), "Password is not specified");
                }

                UserButtonSetControlsState(pControlList, expCtrls, false);
            }
            catch (Exception exp)
            {
                _MainUI.ShowErrorMessage($"Exception while trying process login/logout. Exception thrown: {exp.Message}");
            }
        }

        /// <summary>
        /// This method logsout a user
        /// </summary>
        /// <param name="pControlList">The controls contained on the uc_User form</param>
        private void UserButtonLogout(List<Control> pControlList)
        {
            _userContext = null;
            uc_User tmp = (uc_User) pControlList[0].Parent;
            tmp.Close();
        }

        /// <summary>
        /// This method is called when the New button is clicked on the uc_User form
        /// </summary>
        /// <param name="pControlList">The controls contained on the uc_User form</param>
        private void UserButtonNew(List<Control> pControlList)
        {
            // Initialize default values for controls
            GetControlByName<DateTimePicker>(pControlList, "dtp_Created").Value = DateTime.Now;
            GetControlByName<DateTimePicker>(pControlList, "dtp_Modified").Value = DateTime.Now;
            GetControlByName<TextBox>(pControlList, "tbx_Id").Text = DateTime.Now.ToString(_dateTimeIdFmt);
            GetControlByName<Button>(pControlList, "btn_New").Text = "Save";

            // Disabled control list
            List<Control> expCtrls = new List<Control>();
            expCtrls.Add(GetControlByName<DateTimePicker>(pControlList, "dtp_Created"));
            expCtrls.Add(GetControlByName<DateTimePicker>(pControlList, "dtp_Modified"));
            expCtrls.Add(GetControlByName<Button>(pControlList, "btn_Login"));
            expCtrls.Add(GetControlByName<TextBox>(pControlList, "tbx_Id"));
            UserButtonSetControlsState(pControlList, expCtrls, true);
        }

        /// <summary>
        /// This method deals with the edit button on the uc_User form
        /// </summary>
        /// <param name="pControlList">The list of controld contained on the form</param>
        private void UserButtonEdit(List<Control> pControlList)
        {
            List<Control> expCtrls = new List<Control>();
            expCtrls.Add(GetControlByName<TextBox>(pControlList, "tbx_Id"));
            expCtrls.Add(GetControlByName<DateTimePicker>(pControlList, "dtp_Created"));
            expCtrls.Add(GetControlByName<DateTimePicker>(pControlList, "dtp_Modified"));
            expCtrls.Add(GetControlByName<Button>(pControlList, "btn_Login"));
            UserButtonSetControlsState(pControlList, expCtrls, true);
            GetControlByName<Button>(pControlList, "btn_New").Text = "Save";
            GetControlByName<Button>(pControlList, "btn_Edit").Visible = false;
        }

        private void TaskButtonNew(List<Control> pControlList)
        {
            // Get the form
            uc_Task tmp = (uc_Task)pControlList[0].Parent;
            tmp.TaskId = tmp.TaskId;
            tmp.MainTaskId = DateTime.Now.ToString(_dateTimeIdFmt);
            // Initialize button state
            List<Control> expCtrls = new List<Control>();
            expCtrls.Add(GetControlByName<TextBox>(pControlList, "tbx_CreatedBy"));
            expCtrls.Add(GetControlByName<TextBox>(pControlList, "tbx_ModifiedBy"));
            expCtrls.Add(GetControlByName<DateTimePicker>(pControlList, "dtp_Created"));
            expCtrls.Add(GetControlByName<DateTimePicker>(pControlList, "dtp_Modified"));
            UserButtonSetControlsState(pControlList, expCtrls, true);
            GetControlByName<Button>(pControlList, "btn_New").Text = "Save";
            GetControlByName<TextBox>(pControlList, "tbx_ModifiedBy").Text = _userContext.Username;
            GetControlByName<TextBox>(pControlList, "tbx_CreatedBy").Text = _userContext.Username;
            GetControlByName<TextBox>(pControlList, "tbx_Owner").Text = _userContext.Username;
            GetControlByName<DateTimePicker>(pControlList, "dtp_Created").Value = DateTime.Now;
            GetControlByName<DateTimePicker>(pControlList, "dtp_Modified").Value = DateTime.Now;
        }

        private void TaskButtonSave(List<Control> pControlList)
        {
            _errorProvider.Clear();
            bool isError = false;
            try
            {
                if (_userContext != null)
                {
                    if (GetControlByName<TextBox>(pControlList, "tbx_Description").Text.Length < 1)
                    {
                        isError = true;
                        _errorProvider.SetError(GetControlByName<TextBox>(pControlList, "tbx_Description"), "You must specify a description");
                    }
                    if (GetControlByName<DateTimePicker>(pControlList, "dtp_Start").Value < DateTime.Now)
                    {
                        isError = true;
                        _errorProvider.SetError(GetControlByName<DateTimePicker>(pControlList, "dtp_Start"), "Start date cannot be set in the past");
                    }
                    if  (GetControlByName<DateTimePicker>(pControlList, "dtp_End").Value < GetControlByName<DateTimePicker>(pControlList, "dtp_Start").Value.AddDays(1))
                    {
                        isError = true;
                        _errorProvider.SetError(GetControlByName<DateTimePicker>(pControlList, "dtp_End"), "End date must be at least one day ahead of start date");
                    }

                    if (!isError)
                    {
                        // Initialize button state
                        List<Control> expCtrls = new List<Control>();
                        expCtrls.Add(GetControlByName<Button>(pControlList, "btn_Update"));
                        expCtrls.Add(GetControlByName<Button>(pControlList, "btn_New"));
                        expCtrls.Add(GetControlByName<Button>(pControlList, "btn_Subtask"));
                        expCtrls.Add(GetControlByName<DataGridView>(pControlList, "dgw_Subtasks"));
                        UserButtonSetControlsState(pControlList, expCtrls, false);
                        GetControlByName<Button>(pControlList, "btn_New").Text = "New";

                        // Get the form
                        uc_Task tmp = (uc_Task) pControlList[0].Parent;

                        // Save task
                        ITask task = _interactionFactory.CreateTask(tmp.TaskId,
                            GetControlByName<TextBox>(pControlList, "tbx_Description").Text,
                            _userContext,
                            GetControlByName<DateTimePicker>(pControlList, "dtp_Start").Value,
                            GetControlByName<DateTimePicker>(pControlList, "dtp_End").Value,
                            GetControlByName<DateTimePicker>(pControlList, "dtp_DueDate").Value,
                            GetControlByName<NumericUpDown>(pControlList, "num_Budget").Value,
                            (Convert.ToInt32(GetControlByName<NumericUpDown>(pControlList, "num_EffortsHours").Value)*60) +
                            Convert.ToInt32(GetControlByName<NumericUpDown>(pControlList, "num_EffortsMin").Value),
                            Convert.ToInt32(GetControlByName<NumericUpDown>(pControlList, "num_Priority").Value),
                            (GetControlByName<DateTimePicker>(pControlList, "dtp_Start").Value <= DateTime.Now) ? InteractionState.Active : InteractionState.Queued,
                            0,
                            0,
                            null,
                            0);
                        _dataManager.TaskList.Add(task);
                        _dataManager.InsertTask();
                        tmp.TabText = $"Task Details ({task.Id})";
                    }
                    else
                        return;
                }
                else
                {
                    _MainUI.ShowErrorMessage("You must login first!");
                }
            }
            catch (Exception exp)
            {
                _MainUI.ShowErrorMessage($"Exception caught: {exp.Message}");
            }
        }

        private void TaskButtonUpdate(List<Control> pControlList)
        {
            // Is task loaded?
            uc_Task tmp = (uc_Task) pControlList[0].Parent;
            if (!string.IsNullOrEmpty(tmp.TaskId))
            {
                tmp.TabText = $"Task Details ({tmp.TaskId})";
                frm_TaskUpdateProgress progressForm = new frm_TaskUpdateProgress();
                if (progressForm.ShowDialog() == DialogResult.OK)
                {
                    // Get settings...

                    // Update current task with settings
                }
            }
        }

        private void TaskButtonSubTask(List<Control> pControlList)
        {
            uc_Task tmp = (uc_Task)pControlList[0].Parent;
            if(!string.IsNullOrEmpty(tmp.TaskId))
            { 
                uc_Task subTask = new uc_Task();
                subTask.MainTaskId = tmp.TaskId;
                subTask.TaskId = DateTime.Now.ToString(_dateTimeIdFmt);
                subTask.TabText = $"Task Details ({subTask.TaskId})";
                subTask.Show(_MainUI.Panel, DockState.Document);
                List<Control> subTaskCrtls = GetAllControls(subTask);
                GetControlByName<Button>(subTaskCrtls, "btn_Subtask").Visible = false;
                GetControlByName<Button>(subTaskCrtls, "btn_New").Text = "Save";
                GetControlByName<TextBox>(subTaskCrtls, "tbx_ProjectName").Text = GetControlByName<TextBox>(pControlList, "tbx_ProjectName").Text;
                GetControlByName<TextBox>(subTaskCrtls, "tbx_Owner").Text = UserContext.Username;
                GetControlByName<TextBox>(subTaskCrtls, "tbx_CreatedBy").Text = UserContext.Username;
                GetControlByName<TextBox>(subTaskCrtls, "tbx_ModifiedBy").Text = UserContext.Username;
                GetControlByName<DateTimePicker>(subTaskCrtls, "dtp_Created").Value = DateTime.Now;
                GetControlByName<DateTimePicker>(subTaskCrtls, "dtp_Modified").Value = DateTime.Now;
            }
        }

        /// <summary>
        /// This mehtod deals with the Create button on the uc_Project form
        /// </summary>
        /// <param name="pControlList">The list of controld contained on the form</param>
        private void ProjectButtonCreate(List<Control> pControlList)
        {

            // Disable control list
            List<Control> expCtrls = new List<Control>();
            expCtrls.Add(GetControlByName<Button>(pControlList, "btn_Update"));
            expCtrls.Add(GetControlByName<Button>(pControlList, "btn_InviteUser"));
            expCtrls.Add(GetControlByName<Button>(pControlList, "btn_AcceptInvite"));
            expCtrls.Add(GetControlByName<Button>(pControlList, "btn_Create"));

            if (_userContext != null)
            {

                // Save command
                try
                {
                    _MainUI.Enabled = false;
                    bool bError = false;
                    int _IsActive = Convert.ToByte(false);
                    int _StateId = Convert.ToInt32(InteractionState.Queued);
                    string _ProjectId = null;


                    if (GetControlByName<TextBox>(pControlList, "tbx_Title").Text.Length < 1)
                    {
                        _errorProvider.SetError(GetControlByName<TextBox>(pControlList, "tbx_Title"),
                            "Title is not specified");
                        bError = true;
                    }
                    if (GetControlByName<DateTimePicker>(pControlList, "dtp_EndDate").Value < GetControlByName<DateTimePicker>(pControlList, "dtp_StartDate").Value)
                    {
                        _errorProvider.SetError(GetControlByName<DateTimePicker>(pControlList, "dtp_EndDate"),
                            "The project needs to end after it starts");
                        bError = true;
                    }
                    if (GetControlByName<DateTimePicker>(pControlList, "dtp_EndDate").Value < DateTime.Now)
                    {
                        _errorProvider.SetError(GetControlByName<DateTimePicker>(pControlList, "dtp_EndDate"),
                            "The project end needs to be in the future");
                        bError = true;
                    }


                    if (!bError)
                    {

                        // Initialize default values for controls
                        GetControlByName<DateTimePicker>(pControlList, "dtp_Modified").Value = DateTime.Now;
                        if (GetControlByName<Button>(pControlList, "btn_Create").Text.ToLower() == "create")
                        {
                            GetControlByName<DateTimePicker>(pControlList, "dtp_Created").Value = DateTime.Now;
                            _ProjectId = DateTime.Now.ToString(_dateTimeIdFmt);
                            GetControlByName<TextBox>(pControlList, "tbx_Owner").Text = UserContext.Username;
                        }

                        //Convert
                        if (GetControlByName<DateTimePicker>(pControlList, "dtp_StartDate").Value <= DateTime.Now)
                        {
                            _IsActive = Convert.ToByte(true);
                            _StateId = Convert.ToInt32(InteractionState.Active);
                        }
                        

                        //Create project
                        IProject _NewProject = _interactionFactory.CreateProject(_ProjectId,
                            GetControlByName<TextBox>(pControlList, "tbx_Title").Text + ";" + GetControlByName<TextBox>(pControlList, "tbx_Description").Text,
                            Convert.ToBoolean(GetControlByName<CheckBox>(pControlList, "cbx_EnableBalance").CheckState),
                            Convert.ToBoolean(GetControlByName<CheckBox>(pControlList, "cbx_EnableSurvey").CheckState),
                            GetControlByName<DateTimePicker>(pControlList, "dtp_StartDate").Value,
                            GetControlByName<DateTimePicker>(pControlList, "dtp_EndDate").Value,
                            UserContext);

                        _dataManager.ProjectList.Add(_NewProject);

                        //Insert project in db
                        _dataManager.InsertProject(_ProjectId,
                            GetControlByName<TextBox>(pControlList, "tbx_Title").Text,
                            GetControlByName<TextBox>(pControlList, "tbx_Description").Text,
                            GetControlByName<DateTimePicker>(pControlList, "dtp_StartDate").Value,
                            GetControlByName<DateTimePicker>(pControlList, "dtp_EndDate").Value,
                            UserContext.Id,
                            UserContext.Id,
                            Convert.ToInt32(GetControlByName<CheckBox>(pControlList, "cbx_EnableBalance").CheckState),
                            Convert.ToInt32(GetControlByName<CheckBox>(pControlList, "cbx_EnableSurvey").CheckState),
                            _IsActive,
                            Convert.ToString(_StateId));



                        //Disable setting controls after project is created
                        GetControlByName<Button>(pControlList, "btn_Update").Enabled = true;
                        GetControlByName<Button>(pControlList, "btn_InviteUser").Enabled = true;
                        GetControlByName<CheckBox>(pControlList, "cbx_EnableBalance").Enabled = false;
                        GetControlByName<CheckBox>(pControlList, "cbx_EnableSurvey").Enabled = false;
                        GetControlByName<DateTimePicker>(pControlList, "dtp_StartDate").Enabled = false;
                        GetControlByName<DateTimePicker>(pControlList, "dtp_EndDate").Enabled = false;
                        GetControlByName<TextBox>(pControlList, "tbx_Title").Enabled = false;
                        GetControlByName<TextBox>(pControlList, "tbx_Description").Enabled = false;
                        GetControlByName<Button>(pControlList, "btn_Create").Text = "Edit";
                    }

                    _MainUI.Enabled = true;
                    
                }
                catch (Exception exp)
                {
                    _MainUI.ShowErrorMessage($"Exception while trying to create/edit project. Exception thrown: {exp.Message}");
                }

            }
            else
            {
                _MainUI.ShowErrorMessage($"Cannot create new project while no user is logged in!");
            }

        }

        /// <summary>
        /// This mehtod deals with the Edit button on the uc_Project form
        /// </summary>
        /// <param name="pControlList">The list of controld contained on the form</param>
        private void ProjectButtonEdit(List<Control> pControlList)
        {    
            if (_userContext != null)
            {

                //Eisable setting controls for editing project
                GetControlByName<Button>(pControlList, "btn_Update").Enabled = false;
                GetControlByName<Button>(pControlList, "btn_InviteUser").Enabled = false;
                GetControlByName<Button>(pControlList, "btn_ChangeOwner").Enabled = true;
                GetControlByName<CheckBox>(pControlList, "cbx_EnableBalance").Enabled = true;
                GetControlByName<CheckBox>(pControlList, "cbx_EnableSurvey").Enabled = true;
                GetControlByName<DateTimePicker>(pControlList, "dtp_StartDate").Enabled = true;
                GetControlByName<DateTimePicker>(pControlList, "dtp_EndDate").Enabled = true;
                GetControlByName<TextBox>(pControlList, "tbx_Title").Enabled = true;
                GetControlByName<TextBox>(pControlList, "tbx_Description").Enabled = true;
                GetControlByName<Button>(pControlList, "btn_Create").Text = "Save";
            }
            else
            {
                _MainUI.ShowErrorMessage($"Cannot edit project while no user is logged in!");
            }
        }

        /// <summary>
        /// This method opens a form to select a new owner for the project
        /// </summary>
        /// <param name="pControlList"></param>
        private void ProjectButtonChangeOwner(List<Control> pControlList)
        {
            List <IProject> _Project = _dataManager.ProjectList;
            List<IUser> _MemberList = null;
            string _NewOwnerId = null;

            foreach (Project pProject in _Project)
            {
                if(pProject.Name == GetControlByName<TextBox>(pControlList, "tbx_Title").Text)
                {
                    _MemberList = pProject.MemberList;
                }
            }


            // Create a new instance of the UserSelectionList class
            frm_OwnerChangeList _OwnerSelectionList = new frm_OwnerChangeList(_MemberList, _userContext.Id);

            // Show the UserSelectionList form
            _OwnerSelectionList.Show();

            if (_OwnerSelectionList.NewOwnerId != _userContext.Id)
                _NewOwnerId = _OwnerSelectionList.NewOwnerId;
        }


        private void ProjectButtonUpdatel(List<Control> pControlList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method opens a form to invite users to the project
        /// </summary>
        /// <param name="pControlList"></param>
        private void ProjectButtonInviteUser(List<Control> pControlList)
        {
            List<IProject> _Project = _dataManager.ProjectList;
            string _ProjectId = null;

            foreach (Project pProject in _Project)
            {
                if (pProject.Name == GetControlByName<TextBox>(pControlList, "tbx_Title").Text)
                {
                    _ProjectId = pProject.Id;
                }
            }
            

            // Create a new instance of the UserSelectionList class
            frm_UserSelectionList _UserSelectionList = new frm_UserSelectionList(_ProjectId, _userContext.Id);

            // Show the UserSelectionList form
            _UserSelectionList.Show();
        }


        private void GenerateOverviewPanel()
        {
            // _overviewPanel.
        }

        #endregion
    }
}
