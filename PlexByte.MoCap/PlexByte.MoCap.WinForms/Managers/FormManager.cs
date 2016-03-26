//////////////////////////////////////////////////////////////
//                      Class FormManager
//      Author: Christian B. Sax            Date:   2016/03/24
//      This class manages the conversion from interaction to form and vice versa
//      The manager takes the UI instance and creates the object using the interaction- or
//      objectFactory
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;
using PlexByte.MoCap.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Windows.Forms;
using PlexByte.MoCap.WinForms;
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.Managers
{
    public class FormManager: IDisposable
    {
        IInteractionFactory _interactionFactory = null;
        ObjectManager _objectManager = null;
        IObjectFactory _objectFactory = null;
        ErrorProvider _errorProvider = null;
        const string DateStringFormatId = "yyyyMMddhhmmssfff";

        #region Ctor & Dtor
        public FormManager(ObjectManager pInstance)
        {
            _interactionFactory = new InteractionFactory();
            _objectFactory = new ObjectFactory();
            _errorProvider=new ErrorProvider();
            _objectManager = pInstance;
        }

        public void Dispose()
        {
            _interactionFactory = null;
            _objectFactory = null;
            _errorProvider.Clear();
            _errorProvider = null;
        }

        #endregion

        public DockContent CreateFormFromObject(IInteraction pObject)
        {
            throw new System.NotImplementedException();
        }

        private DockContent CreateProjectForm(IProject pInstance)
        {
            _errorProvider.Clear();
            DockContent tmp = CreateContentPanel(UiType.Project);
            tmp.TabText = $"Project Dialog ({pInstance.Id})";
            List<Control> ctrls = GetAllControls(tmp);

            Project t = (Project)pInstance;
            TimeSpan _Countdown;

            if (t.StartDateTime < DateTime.Now)
            {
                _Countdown = t.EndDateTime.Subtract(DateTime.Now);
            }
            else
            {
                _Countdown = t.EndDateTime.Subtract(t.StartDateTime);
            }

            GetControlByName<TextBox>(ctrls, "tbx_Title").Text = t.Name;
            GetControlByName<TextBox>(ctrls, "tbx_Description").Text = t.Text;
            if (t.EnableBalance == true)
                GetControlByName<CheckBox>(ctrls, "cbx_EnableBalance").CheckState = CheckState.Checked;
            else
                GetControlByName<CheckBox>(ctrls, "cbx_EnableBalance").CheckState = CheckState.Unchecked;
            if (t.EnableSurvey == true)
                GetControlByName<CheckBox>(ctrls, "cbx_EnableSurvey").CheckState = CheckState.Checked;
            else
                GetControlByName<CheckBox>(ctrls, "cbx_EnableSurvey").CheckState = CheckState.Unchecked;
            GetControlByName<Label>(ctrls, "lbl_Countdown").Text = String.Format($"{_Countdown.TotalDays}d:{_Countdown.Hours}h:{_Countdown.Minutes}min");
            GetControlByName<DateTimePicker>(ctrls, "dtp_StartDate").Value = t.StartDateTime;
            GetControlByName<DateTimePicker>(ctrls, "dtp_EndDate").Value = t.EndDateTime;
            GetControlByName<TextBox>(ctrls, "tbx_CreatedBy").Text = t.Creator.Username;
            GetControlByName<TextBox>(ctrls, "tbx_ModifiedBy").Text = t.Owner.Username;
            GetControlByName<DateTimePicker>(ctrls, "dtp_Created").Value = t.CreatedDateTime;
            GetControlByName<DateTimePicker>(ctrls, "dtp_Modified").Value = t.ModifiedDateTime;

            t = null;
            return tmp;
        }

        private DockContent CreateAccountForm(IAccount pInstance)
        {
            _errorProvider.Clear();
            DockContent tmp = CreateContentPanel(UiType.Account);
            tmp.TabText = $"Account Dialog ({pInstance.Id})";
            List<Control> ctrls = GetAllControls(tmp);

            Account t = (Account)pInstance;



            t = null;
            return tmp;
        }

        private DockContent CreateExpenseForm(IExpense pInstance)
        {
            _errorProvider.Clear();
            DockContent tmp = CreateContentPanel(UiType.Expense);
            tmp.TabText = $"Expense Dialog ({pInstance.Target})";
            List<Control> ctrls = GetAllControls(tmp);

            Expense t = (Expense)pInstance;




            t = null;
            return tmp;
        }

        private DockContent CreateSurveyForm(ISurvey pInstance)
        {
            throw new System.NotImplementedException();
        }

        private DockContent CreateTimesliceForm(ITimeslice pInstance)
        {
            _errorProvider.Clear();
            DockContent tmp = CreateContentPanel(UiType.Timeslice);
            tmp.TabText = $"Timeslice Dialog ({pInstance.Target})";
            List<Control> ctrls = GetAllControls(tmp);

            Timeslice t = (Timeslice)pInstance;




            t = null;
            return tmp;
        }

        private DockContent CreateTaskForm(ITask pInstance)
        {
            _errorProvider.Clear();
            DockContent tmp = CreateContentPanel(UiType.Task);
            tmp.TabText = $"Task Details ({pInstance.Id})";
            List<Control> ctrls = GetAllControls(tmp);

            Task t = (Task) pInstance;

            GetControlByName<TextBox>(ctrls, "tbx_Title").Text = t.Text;
            GetControlByName<NumericUpDown>(ctrls, "num_Priority").Value = t.Priority;
            GetControlByName<TextBox>(ctrls, "tbx_ProjectName").Text = t.ProjectId;
            GetControlByName<DateTimePicker>(ctrls, "dtp_DueDate").Value = t.DueDateTime;
            GetControlByName<NumericUpDown>(ctrls, "num_EffortsHours").Value = t.Duration / 60;
            GetControlByName<NumericUpDown>(ctrls, "num_EffortsMin").Value = t.Duration % 60;
            GetControlByName<DateTimePicker>(ctrls, "dtp_Start").Value = t.StartDateTime;
            GetControlByName<TextBox>(ctrls, "tbx_Description").Text = t.Text;
            GetControlByName<TextBox>(ctrls, "tbx_Owner").Text = t.Owner.Username;
            GetControlByName<ProgressBar>(ctrls, "pbr_Progress").Value = t.Progress;
            GetControlByName<NumericUpDown>(ctrls, "num_TotalCosts").Value = t.BudgetUsed;
            GetControlByName<DateTimePicker>(ctrls, "dtp_End").Value = t.EndDateTime;
            GetControlByName<TextBox>(ctrls, "tbx_CreatedBy").Text = t.Creator.Username;
            GetControlByName<TextBox>(ctrls, "tbx_ModifiedBy").Text = t.Owner.Username;
            GetControlByName<DateTimePicker>(ctrls, "dtp_Created").Value = t.CreatedDateTime;
            GetControlByName<DateTimePicker>(ctrls, "dtp_End").Value = t.ModifiedDateTime;

            t = null;

            return tmp;
        }

        public DockContent CreateUserFormFromObject(IUser pInstance)
        {
            _errorProvider.Clear();
            DockContent tmp = CreateContentPanel(UiType.User);
            tmp.TabText = $"User Details ({pInstance.Id})";
            List<Control> ctrls = GetAllControls(tmp);

            User u = (User) pInstance;
            GetControlByName<TextBox>(ctrls, "tbx_Id").Text = u.Id;
            GetControlByName<TextBox>(ctrls, "tbx_FirstName").Text = u.FirstName;
            GetControlByName<TextBox>(ctrls, "tbx_LastName").Text = u.LastName;
            GetControlByName<TextBox>(ctrls, "tbx_MiddleName").Text = u.MiddleName;
            GetControlByName<TextBox>(ctrls, "tbx_UserName").Text = u.Username;
            GetControlByName<TextBox>(ctrls, "tbx_Password").Text = u.Password;
            GetControlByName<TextBox>(ctrls, "tbx_Email").Text = u.EmailAddress;
            GetControlByName<DateTimePicker>(ctrls, "dtp_Birthdate").Value = u.Birthdate;
            GetControlByName<DateTimePicker>(ctrls, "dtp_Modified").Value = u.ModifiedDateTime;
            GetControlByName<DateTimePicker>(ctrls, "dtp_Created").Value = u.CreatedDateTime;

            return tmp;
        }

        public DockContent CreateFormFromObject(IInteraction pObject, DockContent pInstance)
        {
            if (_objectManager.UserContext != null)
            {
                if (pInstance.GetType() == typeof (uc_Project))
                {
                    return CreateProjectForm((IProject) pObject);
                }
                else if (pInstance.GetType() == typeof (uc_Task))
                {
                    return CreateTaskForm((ITask) pObject);
                }
                else if (pInstance.GetType() == typeof (uc_Survey))
                {
                    return null;
                }
                else if (pInstance.GetType() == typeof (uc_Account))
                {
                    return CreateAccountForm((IAccount) pObject);
                }
                else if (pInstance.GetType() == typeof (uc_Expense))
                {
                    return CreateExpenseForm((IExpense) pObject);
                }
                else if (pInstance.GetType() == typeof (uc_Timeslice))
                {
                    return CreateTimesliceForm((ITimeslice) pObject);
                }
                else
                {
                    throw new InvalidCastException($"The type {pInstance.GetType().ToString()} " +
                                                   $"is not a valid interaction type!");
                }
            }
            else
                throw new AuthenticationException("There seems to be no user logged in! Please login " +
                                                  "before you start working");
        }

        public T CreateObjectFromForm<T>(DockContent pInstance)
        {
            if (_objectManager.UserContext != null)
            {
                if (pInstance.GetType() == typeof(uc_Project))
                {
                    IProject obj = CreatePojectFromForm(pInstance);
                    return (T)obj;
                }
                else if (pInstance.GetType() == typeof(uc_Task))
                {
                    return (T)CreateTaskFromForm((uc_Task)pInstance);
                }
                else if (pInstance.GetType() == typeof(uc_Survey))
                {
                    ISurvey obj = _interactionFactory.CreateSurvey("",
                        "",
                        new System.Collections.Generic.List<ISurveyOption>()
                        {new SurveyOption("", "")},
                        new User()
                        );
                    return (T)obj;
                }
                else if (pInstance.GetType() == typeof(uc_Expense))
                {
                    IExpense obj = _interactionFactory.CreateExpense("", "", new User(), new Task("", "", new User()));
                    return (T)obj;
                }
                else if (pInstance.GetType() == typeof(uc_Timeslice))
                {
                    ITimeslice obj = _interactionFactory.CreateTimeslice("", new User(), 0, new Task("", "", new User()));
                    return (T)obj;
                }
                else
                {
                    throw new InvalidCastException($"The type {pInstance.GetType().ToString()} is not a valid interaction type!");
                }
            }
            else
                throw new AuthenticationException("There seems to be no user logged in! Please login " +
                                                  "before you start working");
        }

        public IUser CreateUserObjectFromForm(DockContent pInstance)
        {
            throw new System.NotImplementedException();
        }

        #region Private Methods

        private ITask CreateTaskFromForm(uc_Task pForm)
        {
            ITask obj = _interactionFactory.CreateTask(GetControlByName<TextBox>(pForm, "tbx_Id").Text,
                GetControlByName<TextBox>(pForm, "tbx_Description").Text,
                GetControlByName<TextBox>(pForm, "tbx_Title").Text,
                _objectManager.UserContext,
                GetControlByName<DateTimePicker>(pForm, "dtp_Start").Value,
                GetControlByName<DateTimePicker>(pForm, "dtp_End").Value,
                GetControlByName<DateTimePicker>(pForm, "dtp_DueDate").Value,
                GetControlByName<NumericUpDown>(pForm, "num_Budget").Value,
                Convert.ToInt32(GetControlByName<NumericUpDown>(pForm, "num_EffortsHours").Value)*60 +
                Convert.ToInt32(GetControlByName<NumericUpDown>(pForm, "num_EffortsMin").Value),
                Convert.ToInt32(GetControlByName<NumericUpDown>(pForm, "num_Priority").Value),
                (GetControlByName<DateTimePicker>(pForm, "dtp_Start").Value < DateTime.Now)
                    ? InteractionState.Active
                    : InteractionState.Queued,
                0.00m,
                0,
                null,
                0);
                return obj;
        }

        private IProject CreatePojectFromForm(DockContent pInstance)
        {
            bool bError = false;
            string _ProjectId = null;

            if (GetControlByName<TextBox>(pInstance, "tbx_Title").Text.Contains(";"))
            {
                _errorProvider.SetError(GetControlByName<TextBox>(pInstance, "tbx_Title"),
                    "The symbol ';' is not allowed in Title");
                bError = true;
            }
            if (GetControlByName<TextBox>(pInstance, "tbx_Title").Text.Length < 1)
            {
                _errorProvider.SetError(GetControlByName<TextBox>(pInstance, "tbx_Title"),
                    "Title is not specified");
                bError = true;
            }
            if (GetControlByName<DateTimePicker>(pInstance, "dtp_EndDate").Value < GetControlByName<DateTimePicker>(pInstance, "dtp_StartDate").Value)
            {
                _errorProvider.SetError(GetControlByName<DateTimePicker>(pInstance, "dtp_EndDate"),
                    "The project needs to end after it starts");
                bError = true;
            }
            if (GetControlByName<DateTimePicker>(pInstance, "dtp_EndDate").Value < DateTime.Now)
            {
                _errorProvider.SetError(GetControlByName<DateTimePicker>(pInstance, "dtp_EndDate"),
                    "The project end needs to be in the future");
                bError = true;
            }

            if (!bError)
            {
                // Initialize default values for controls
                GetControlByName<DateTimePicker>(pInstance, "dtp_Modified").Value = DateTime.Now;
                if (GetControlByName<Button>(pInstance, "btn_Create").Text.ToLower() == "create")
                {
                    GetControlByName<DateTimePicker>(pInstance, "dtp_Created").Value = DateTime.Now;
                    //_ProjectId = DateTime.Now.ToString(_dateTimeIdFmt);
                    GetControlByName<TextBox>(pInstance, "tbx_Owner").Text = _objectManager.UserContext.Username;
                }

                IProject obj = _interactionFactory.CreateProject(_ProjectId,
                    GetControlByName<TextBox>(pInstance, "tbx_Title").Text + ";" + GetControlByName<TextBox>(pInstance, "tbx_Description").Text,
                    Convert.ToBoolean(GetControlByName<CheckBox>(pInstance, "cbx_EnableBalance").CheckState),
                    Convert.ToBoolean(GetControlByName<CheckBox>(pInstance, "cbx_EnableSurvey").CheckState),
                    GetControlByName<DateTimePicker>(pInstance, "dtp_StartDate").Value,
                    GetControlByName<DateTimePicker>(pInstance, "dtp_EndDate").Value,
                    _objectManager.UserContext);

                return obj;
            }
            return null;
        }

        private ISurvey CreateSurveyFromForm(uc_Survey pForm)
        {
            List<ISurveyOption> options = (from ListViewItem lvi in GetControlByName<ListView>(pForm, "lv_Otions").Items
                select _objectFactory.CreateSurveyOption(DateTime.Now.ToString(DateStringFormatId),
                    lvi.Text)).ToList();
            ISurvey obj = _interactionFactory.CreateSurvey(pForm.Id,
                GetControlByName<TextBox>(pForm, "tbx_SurveyTitle").Text,
                options,
                _objectManager.UserContext);
            options.Clear();
            return obj;
        }

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
            object control = default(T);
            try
            {
                List<Control> ctrls = GetAllControls(pContainer);
                foreach (var variable in ctrls)
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
                throw new Exception($"Expection while trying to get control of type {typeof(T).Name} and name {pControlName}. Excption message= {exp.Message}");
            }
        }

        #endregion
    }
}
