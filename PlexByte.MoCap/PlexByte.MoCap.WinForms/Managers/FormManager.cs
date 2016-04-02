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
using System.Data;
using System.Linq;
using System.Security.Authentication;
using System.Windows.Forms;
using PlexByte.MoCap.Helpers;
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

        /// <summary>
        /// This method creates a form based on the object type and initializes its fields with the objects values
        /// </summary>
        /// <param name="pObject">The interaction object to use</param>
        /// <returns>DockContent form initialized with the objects values</returns>
        public DockContent CreateFormFromObject(IInteraction pObject)
        {
            DockContent tmp = null;
            if (pObject.GetType() == typeof (Project))
            {
                tmp=new uc_Project();
            }
            else if (pObject.GetType() == typeof (Task))
            {
                tmp=new uc_Task();
            }
            else if (pObject.GetType() == typeof(Survey))
            {
                tmp=new uc_Survey();
            }
            return (tmp = CreateFormFromObject(pObject, ref tmp));
        }

        /// <summary>
        /// This method creates a form based on the user and initializes its fields with the objects values
        /// </summary>
        /// <param name="pInstance">The user to use</param>
        /// <returns>DockCOntent form initialized with the users values</returns>
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

        /// <summary>
        /// This method creates a form based on an object provided and initializes the forms values using the objects properties
        /// </summary>
        /// <param name="pObject">The object from which the form is generated</param>
        /// <param name="pInstance">The form to initialize</param>
        /// <returns>DockContent form that was given in the input</returns>
        public DockContent CreateFormFromObject(IInteraction pObject, ref DockContent pInstance)
        {
            if (_objectManager.UserContext != null)
            {
                if (pInstance.GetType() == typeof (uc_Project))
                {
                    pInstance = CreateProjectForm((IProject) pObject);
                }
                else if (pInstance.GetType() == typeof (uc_Task))
                {
                    pInstance = CreateTaskForm((ITask) pObject);
                }
                else if (pInstance.GetType() == typeof (uc_Survey))
                {
                    pInstance = CreateSurveyForm((ISurvey) pObject);
                }
                else if (pInstance.GetType() == typeof (uc_Account))
                {
                    pInstance = CreateAccountForm((IAccount) pObject);
                }
                else if (pInstance.GetType() == typeof (uc_Expense))
                {
                    pInstance = CreateExpenseForm((IExpense) pObject);
                }
                else if (pInstance.GetType() == typeof (uc_Timeslice))
                {
                    pInstance = CreateTimesliceForm((ITimeslice) pObject);
                }
                else
                {
                    throw new InvalidCastException($"The type {pInstance.GetType().ToString()} " +
                                                   $"is not a valid interaction type!");
                }
                return pInstance;
            }
            else
                throw new AuthenticationException("There seems to be no user logged in! Please login " +
                                                  "before you start working");
        }

        /// <summary>
        /// This method created an object from the form given
        /// </summary>
        /// <typeparam name="T">The type of interaction object to generate</typeparam>
        /// <param name="pInstance">The form to use creatin the interaction object</param>
        /// <returns></returns>
        public T CreateObjectFromForm<T>(DockContent pInstance)
        {
            if (_objectManager.UserContext != null)
            {
                if (pInstance.GetType() == typeof(uc_Project))
                {
                    return (T)CreatePojectFromForm((uc_Project)pInstance); 
                }
                else if (pInstance.GetType() == typeof(uc_Task))
                {
                    return (T)CreateTaskFromForm((uc_Task)pInstance);
                }
                else if (pInstance.GetType() == typeof(uc_Survey))
                {
                    if (typeof (T) == typeof (IVote))
                    {
                        IVote obj = CreateVoteFromForm((uc_Survey)pInstance);
                        return (T) obj;
                    }
                    else
                    {
                        ISurvey obj = CreateSurveyFromForm((uc_Survey)pInstance);
                        return (T)(ISurvey)obj;
                    }
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

        /// <summary>
        /// This method created a user from a form given
        /// </summary>
        /// <param name="pInstance">The form to use creating the user</param>
        /// <returns>IUser object created using the forms values</returns>
        public IUser CreateUserObjectFromForm(uc_User pInstance)
        {
            List<Control> ctrl = GetAllControls(pInstance);
            IUser obj = _objectFactory.CreateUser(GetControlByName<TextBox>(ctrl, "tbx_Id").Text,
                GetControlByName<TextBox>(ctrl, "tbx_FirstName").Text,
                GetControlByName<TextBox>(ctrl, "tbx_LastName").Text,
                GetControlByName<TextBox>(ctrl, "tbx_MiddleName").Text,
                GetControlByName<TextBox>(ctrl, "tbx_Email").Text,
                GetControlByName<DateTimePicker>(ctrl, "dtp_Birthdate").Value,
                GetControlByName<TextBox>(ctrl, "tbx_UserName").Text,
                GetControlByName<MaskedTextBox>(ctrl, "tbx_Password").Text,
                GetControlByName<DateTimePicker>(ctrl, "dtp_Modified").Value,
                GetControlByName<DateTimePicker>(ctrl, "dtp_Created").Value,
                DateTime.Now.ToString(DateStringFormatId));
            ctrl.Clear();
            ctrl = null;
            return obj;
        }

        #region Private Methods

        private ITask CreateTaskFromForm(uc_Task pForm)
        {
            List<Control> ctrl = GetAllControls(pForm);
            ITask obj = _interactionFactory.CreateTask(GetControlByName<TextBox>(ctrl, "tbx_Id").Text,
                GetControlByName<TextBox>(ctrl, "tbx_Description").Text,
                GetControlByName<TextBox>(ctrl, "tbx_Title").Text,
                _objectManager.UserContext,
                GetControlByName<DateTimePicker>(ctrl, "dtp_Start").Value,
                GetControlByName<DateTimePicker>(ctrl, "dtp_End").Value,
                GetControlByName<DateTimePicker>(ctrl, "dtp_DueDate").Value,
                GetControlByName<NumericUpDown>(ctrl, "num_Budget").Value,
                Convert.ToInt32(GetControlByName<NumericUpDown>(ctrl, "num_EffortsHours").Value)*60 +
                Convert.ToInt32(GetControlByName<NumericUpDown>(ctrl, "num_EffortsMin").Value),
                Convert.ToInt32(GetControlByName<NumericUpDown>(ctrl, "num_Priority").Value),
                (GetControlByName<DateTimePicker>(ctrl, "dtp_Start").Value < DateTime.Now)
                    ? InteractionState.Active
                    : InteractionState.Queued,
                0.00m,
                0,
                null,
                0);
            ctrl.Clear();
            ctrl = null;
            return obj;
        }

        /// <summary>
        /// This method created a project from the form given
        /// </summary>
        /// <param name="pInstance"></param>
        /// <returns></returns>
        private IProject CreatePojectFromForm(DockContent pInstance)
        {
            List<Control> ctrl = GetAllControls(pInstance);
            uc_Project tmp = (uc_Project)pInstance;
            //Initialize default values for controls
            if (string.IsNullOrEmpty(GetControlByName<Label>(ctrl, "lbl_Id").Text))
            {
                tmp.ProjectId = DateTime.Now.ToString(DateStringFormatId);
                GetControlByName<Label>(ctrl, "lbl_Id").Text = tmp.ProjectId;
            }
            else
            {
                tmp.ProjectId = GetControlByName<Label>(ctrl, "lbl_Id").Text;
            }

            IProject obj = _interactionFactory.CreateProject(tmp.ProjectId,
                GetControlByName<TextBox>(ctrl, "tbx_Title").Text + ";" + GetControlByName<TextBox>(ctrl, "tbx_Description").Text,
                Convert.ToBoolean(GetControlByName<CheckBox>(ctrl, "cbx_EnableBalance").CheckState),
                Convert.ToBoolean(GetControlByName<CheckBox>(ctrl, "cbx_EnableSurvey").CheckState),
                GetControlByName<DateTimePicker>(ctrl, "dtp_StartDate").Value,
                GetControlByName<DateTimePicker>(ctrl, "dtp_EndDate").Value,
                _objectManager.UserContext);

            GetControlByName<Button>(ctrl, "btn_Update").Enabled = true;
            GetControlByName<Button>(ctrl, "btn_InviteUser").Enabled = true;
            GetControlByName<CheckBox>(ctrl, "cbx_EnableBalance").Enabled = false;
            GetControlByName<CheckBox>(ctrl, "cbx_EnableSurvey").Enabled = false;
            GetControlByName<DateTimePicker>(ctrl, "dtp_StartDate").Enabled = false;
            GetControlByName<DateTimePicker>(ctrl, "dtp_EndDate").Enabled = false;
            GetControlByName<TextBox>(ctrl, "tbx_Title").Enabled = false;
            GetControlByName<TextBox>(ctrl, "tbx_Description").Enabled = false;
            GetControlByName<Button>(ctrl, "btn_Create").Text = "Edit";

            ctrl.Clear();
            ctrl = null;
            return obj;
        }

        /// <summary>
        /// This method creates a survey from the form inputs
        /// </summary>
        /// <param name="pForm">The form containing the values</param>
        /// <returns>ISurvey created based on the form values</returns>
        private ISurvey CreateSurveyFromForm(uc_Survey pForm)
        {
            List<Control> ctrl = GetAllControls(pForm);

            _errorProvider.Clear();
            if(GetControlByName<TextBox>(ctrl, "tbx_SurveyTitle").Text.Length<2)
                _errorProvider.SetError(GetControlByName<TextBox>(ctrl, "tbx_SurveyTitle"), "You need to set a title");
            if (GetControlByName<DateTimePicker>(ctrl, "dtp_DueDate").Value<= GetControlByName<DateTimePicker>(ctrl, "dtp_End").Value
                && GetControlByName<DateTimePicker>(ctrl, "dtp_DueDate").Value <= GetControlByName<DateTimePicker>(ctrl, "dtp_Start").Value)
                _errorProvider.SetError(GetControlByName<DateTimePicker>(ctrl, "dtp_DueDate"), "Due date must be set between Start and End date time");

            List<ISurveyOption> options = (from ListViewItem lvi in GetControlByName<ListView>(ctrl, "lv_Options").Items
                select _objectFactory.CreateSurveyOption(DateTime.Now.ToString(DateStringFormatId),
                    lvi.Text)).ToList();
            Survey obj = (Survey) _interactionFactory.CreateSurvey(pForm.Id,
                GetControlByName<TextBox>(ctrl, "tbx_SurveyTitle").Text,
                options,
                _objectManager.GetObjectById<IUser>(GetControlByName<TextBox>(ctrl, "tbx_CreatedBy").Text),
                GetControlByName<DateTimePicker>(ctrl, "dtp_Start").Value,
                GetControlByName<DateTimePicker>(ctrl, "dtp_End").Value,
                GetControlByName<DateTimePicker>(ctrl, "dtp_DueDate").Value,
                Convert.ToInt32(GetControlByName<NumericUpDown>(ctrl, "num_VotesPerUser").Value),
                GetControlByName<TextBox>(ctrl, "tbx_SurveyTitle").Text,
                _objectManager.ComputeState(DateTime.Now,
                    GetControlByName<DateTimePicker>(ctrl, "dtp_Start").Value,
                    GetControlByName<DateTimePicker>(ctrl, "dtp_End").Value,
                    GetControlByName<DateTimePicker>(ctrl, "dtp_DueDate").Value),
                new List<IVote>());
            obj.InteractionId = pForm.InteractionId;
            obj.ProjectId = pForm.ProjectId;
            obj.Owner = _objectManager.GetObjectById<IUser>(GetControlByName<TextBox>(ctrl, "tbx_ModifiedBy").Text);
            obj.ModifiedDateTime = GetControlByName<DateTimePicker>(ctrl, "dtp_ModifiedAt").Value;
            options.Clear();
            ctrl.Clear();
            ctrl = null;
            return obj;
        }

        private IVote CreateVoteFromForm(uc_Survey pForm)
        {
            ISurvey survey = _objectManager.SurveyList.First(x => x.Id == pForm.Id);
            if (_objectManager.SurveyList.Any(x => x.Id == pForm.Id))
            {
                if (survey.VoteList.All(x => x.User.Id != _objectManager.UserContext.Id))
                {
                    IVote obj = _objectFactory.CreateVote(DateTime.Now.ToString(DateStringFormatId),
                        _objectManager.UserContext,
                        survey.OptionList.First(x => x.Text.ToLower() ==
                                                     GetControlByName<ListView>(pForm, "lv_Otions").SelectedItems[0].Text.ToLower()));
                    return obj;
                }
            }
            survey = null;
            return null;
        }

        private DockContent CreateProjectForm(IProject pInstance)
        {
            _errorProvider.Clear();
            DockContent tmp = CreateContentPanel(UiType.Project);
            tmp.TabText = $"Project Dialog ({pInstance.Id})";
            List<Control> ctrl = GetAllControls(tmp);

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

            GetControlByName<Label>(ctrl, "lbl_Id").Text = t.Id;
            GetControlByName<TextBox>(ctrl, "tbx_Title").Text = t.Name;
            GetControlByName<TextBox>(ctrl, "tbx_Description").Text = t.Text;
            if (t.EnableBalance == true)
                GetControlByName<CheckBox>(ctrl, "cbx_EnableBalance").CheckState = CheckState.Checked;
            else
                GetControlByName<CheckBox>(ctrl, "cbx_EnableBalance").CheckState = CheckState.Unchecked;
            if (t.EnableSurvey == true)
                GetControlByName<CheckBox>(ctrl, "cbx_EnableSurvey").CheckState = CheckState.Checked;
            else
                GetControlByName<CheckBox>(ctrl, "cbx_EnableSurvey").CheckState = CheckState.Unchecked;
            GetControlByName<Label>(ctrl, "lbl_Countdown").Text = String.Format($"{Convert.ToInt32(_Countdown.TotalDays)}d:{_Countdown.Hours}h:{_Countdown.Minutes}min");
            GetControlByName<DateTimePicker>(ctrl, "dtp_StartDate").Value = t.StartDateTime;
            GetControlByName<DateTimePicker>(ctrl, "dtp_EndDate").Value = t.EndDateTime;
            GetControlByName<TextBox>(ctrl, "tbx_CreatedBy").Text = t.Creator.Username;
            GetControlByName<TextBox>(ctrl, "tbx_ModifiedBy").Text = t.Owner.Username;
            GetControlByName<DateTimePicker>(ctrl, "dtp_Created").Value = t.CreatedDateTime;
            GetControlByName<DateTimePicker>(ctrl, "dtp_Modified").Value = t.ModifiedDateTime;
            GetControlByName<Button>(ctrl, "btn_Update").Enabled = true;
            GetControlByName<Button>(ctrl, "btn_InviteUser").Enabled = true;
            GetControlByName<Button>(ctrl, "btn_Create").Enabled = true;
            GetControlByName<Button>(ctrl, "btn_Create").Text = "Edit";

            t = null;
            ctrl.Clear();
            ctrl = null;
            return tmp;
        }

        private DockContent CreateAccountForm(IAccount pInstance)
        {
            _errorProvider.Clear();
            DockContent tmp = CreateContentPanel(UiType.Account);
            tmp.TabText = $"Account Dialog ({pInstance.Id})";
            List<Control> ctrl = GetAllControls(tmp);

            Account t = (Account)pInstance;
            DataGridViewColumn column;
            column = new DataGridViewTextBoxColumn();

            // Populate the drop-down list with the enumeration values.
            ((DataGridViewTextBoxColumn)column).Name = pInstance.Id;

            t = null;
            ctrl.Clear();
            ctrl = null;
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
            _errorProvider.Clear();
            DockContent tmp = CreateContentPanel(UiType.Survey);
            tmp.TabText = $"Survey Details ({pInstance.Title})";
            List<Control> ctrls = GetAllControls(tmp);

            Survey t = (Survey)pInstance;

            foreach (var option in pInstance.OptionList)
            {
                GetControlByName<ListView>(ctrls, "lv_Otions").Items.Add(option.Text);
            }
            var q = from x in pInstance.VoteList
                    group x by x.Option into g
                    let count = g.Count()
                    orderby count descending
                    select new { Name = g.Key, Count = count };
            foreach (var x in q)
            {
                GetControlByName<ListView>(ctrls, "lsv_VoteOverview").Items.Add($"1. {x.Name.Text} ({x.Count} Votes)");
            }

            foreach (var project in _objectManager.ProjectList)
            {
                GetControlByName<ComboBox>(ctrls, "cbx_Project").Items.Add(project.Id);
            }
            ((uc_Survey) tmp).Id = t.Id;
            ((uc_Survey)tmp).ProjectId = t.ProjectId;
            ((uc_Survey)tmp).InteractionId = t.InteractionId;
            GetControlByName<TextBox>(ctrls, "tbx_SurveyTitle").Text = t.Text;
            GetControlByName<TextBox>(ctrls, "tbx_SurveyVoteCount").Text = t.VoteList.Count.ToString();
            GetControlByName<TextBox>(ctrls, "tbx_State").Text = t.State.ToString();
            GetControlByName<DateTimePicker>(ctrls, "dtp_DueDate").Value = t.DueDateTime;
            GetControlByName<DateTimePicker>(ctrls, "dtp_Start").Value = t.StartDateTime;
            GetControlByName<DateTimePicker>(ctrls, "dtp_End").Value = t.EndDateTime;
            GetControlByName<TextBox>(ctrls, "tbx_Description").Text = t.Text;
            GetControlByName<NumericUpDown>(ctrls, "num_VotesPerUser").Value = t.MaxVotesPerUser;
            GetControlByName<TextBox>(ctrls, "tbx_CreatedBy").Text = t.Creator.Username;
            GetControlByName<TextBox>(ctrls, "tbx_ModifiedBy").Text = t.Creator.Username;
            GetControlByName<DateTimePicker>(ctrls, "dtp_CreatedAt").Value = t.CreatedDateTime;
            GetControlByName<DateTimePicker>(ctrls, "dtp_ModifiedAt").Value = t.ModifiedDateTime;
            GetControlByName<ComboBox>(ctrls, "cbx_Project").Text = t.ProjectId;
            t = null;
            ctrls.Clear();
            ctrls = null;

            return tmp;
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
            tmp.TabText = $"Task Details ({pInstance.Title})";
            List<Control> ctrls = GetAllControls(tmp);

            Task t = (Task)pInstance;

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
            GetControlByName<Button>(ctrls, "btn_Update").Enabled = true;

            t = null;
            ctrls.Clear();
            ctrls = null;

            return tmp;
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
