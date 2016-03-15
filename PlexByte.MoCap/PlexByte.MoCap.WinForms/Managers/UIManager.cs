//////////////////////////////////////////////////////////////
//                      Class UIManager
//      Author: Christian B. Sax            Date:   2016/03/16
//      This class manages the windows presented in the user interface. It further
//      registers to all available events and executes the corresponding action
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using PlexByte.MoCap.Helpers;
using PlexByte.MoCap.WinForms;
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
    public class UIManager
    {
        #region Properties

        #endregion

        #region Variables

        private frm_MoCapMain _MainUI = null;
        private ErrorProvider _errorProvider = new ErrorProvider();

        #endregion

        #region Ctor & Dtor

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="pMainUI">The pointer to the main form, which hosts any other window</param>
        public UIManager(frm_MoCapMain pMainUI) { _MainUI = pMainUI; }

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
            DockContent tmp = new uc_Overview();
            tmp.Show(_MainUI.Panel, DockState.DockLeft);
        }

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
                case "btn_New":
                    bool isSave = ((Button) sender).Text.ToLower() == "save";
                    foreach (var VARIABLE in ctrls)
                    {
                        if (isSave)
                        {
                            if (VARIABLE.Text.ToLower() != "btn_new" ||
                                VARIABLE.Text.ToLower() != "btn_login" ||
                                VARIABLE.Text.ToLower() != "tbx_username" ||
                                VARIABLE.Text.ToLower() == "tbx_password")
                                VARIABLE.Enabled = false;
                        }
                        else
                        {
                            VARIABLE.Enabled = true;
                        }
                            
                    }
                    ((Button) sender).Text = (!isSave) ? "Save" : "New";
                    break;
                //case "btn_Edit":
                  //  break;
                case "btn_Login":
                    string sUserName = GetControlByName<TextBox>(((Control)sender).Parent, "tbx_username").Text;
                    string sPassword = GetControlByName<MaskedTextBox>(((Control) sender).Parent, "tbx_password").Text;
                    if (!string.IsNullOrEmpty(sUserName) && !string.IsNullOrEmpty(sPassword))
                    {
                        try
                        {
                            _MainUI.Enabled = false;
                            _MainUI.DataManager = new DataManager(sUserName, sPassword);
                            _MainUI.Enabled = true;
                        }
                        catch (Exception exp)
                        {
                            _MainUI.ShowErrorMessage(exp.Message);
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(sUserName))
                            _errorProvider.SetError(GetControlByName<TextBox>(((Control) sender).Parent, "tbx_username"), "UserName is not specified");
                        if (string.IsNullOrEmpty(sPassword))
                            _errorProvider.SetError(GetControlByName<MaskedTextBox>(((Control) sender).Parent, "tbx_password"), "Password is not specified");
                    }
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
                    ctrlList.AddRange(GetAllControls(c));
                else
                    ctrlList.Add(c);
            }
            return ctrlList;
        }

        private T GetControlByName<T>(Control pContainer, string pControlName)
        {
            object control = default (T);
            try
            {
                List<Control> ctrls = GetAllControls(pContainer);
                foreach (var VARIABLE in ctrls)
                {
                    if (VARIABLE.GetType() == typeof (T))
                    {
                        if (VARIABLE.Name.ToLower() == pControlName.ToLower())
                            return (T)(control = VARIABLE);
                    }
                }
                return (T)control;
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        #endregion
    }
}
