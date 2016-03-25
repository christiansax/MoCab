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
using System.Windows.Forms;
using PlexByte.MoCap.WinForms;
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.Managers
{
    #region Ctor & Dtor

    public class FormManager: IDisposable
    {
        IInteractionFactory _interactionFactory = null;
        IObjectFactory _objectFactory = null;
        private ErrorProvider _errorProvider = null;

        public FormManager()
        {
            _interactionFactory = new InteractionFactory();
            _objectFactory = new ObjectFactory();
            _errorProvider=new ErrorProvider();
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
            throw new System.NotImplementedException();
        }

        private DockContent CreateExpenseForm(IExpense pInstance)
        {
            throw new System.NotImplementedException();
        }

        private DockContent CreateSurveyForm(ISurvey pInstance)
        {
            throw new System.NotImplementedException();
        }

        private DockContent CreateTimesliceForm(ITimeslice pInstance)
        {
            throw new System.NotImplementedException();
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
            if (pInstance.GetType() == typeof(uc_Project))
            {
                
            }
            else if (pInstance.GetType() == typeof(uc_Task))
            {
                CreateTaskForm((ITask)pObject);
            }
            else if (pInstance.GetType() == typeof(uc_Survey))
            {
                
            }
            else if (pInstance.GetType() == typeof(uc_Expense))
            {
                
            }
            else if (pInstance.GetType() == typeof(uc_Timeslice))
            {
                
            }
            else { throw new InvalidCastException($"The type {pInstance.GetType().ToString()} is not a valid interaction type!"); }
        }

        public T CreateObjectFromForm<T>(DockContent pInstance)
        {
            if (pInstance.GetType() == typeof(uc_Project))
            {
                IProject obj = _interactionFactory.CreateProject("", "", false, false, DateTime.Now, DateTime.Now, new User());
                return (T)obj;
            }
            else if (pInstance.GetType() == typeof(uc_Task))
            {
                ITask obj = _interactionFactory.CreateTask("", "", new User());
                return (T)obj;
            }
            else if (pInstance.GetType() == typeof(uc_Survey))
            {
                ISurvey obj = _interactionFactory.CreateSurvey("", "", new System.Collections.Generic.List<ISurveyOption>()
                    { new SurveyOption("", "") },
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
            else { throw new InvalidCastException($"The type {pInstance.GetType().ToString()} is not a valid interaction type!"); }
        }

        public IUser CreateUserObjectFromFForm(DockContent pInstance)
        {
            throw new System.NotImplementedException();
        }

        #region Private Methods

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
