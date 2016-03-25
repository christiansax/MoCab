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
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.Managers
{
    #region Ctor & Dtor

    public class FormManager: IDisposable
    {
        IInteractionFactory _interactionFactory = null;
        IObjectFactory _objectFactory = null;

        public FormManager()
        {
            _interactionFactory = new InteractionFactory();
            _objectFactory = new ObjectFactory();
        }

        public void Dispose()
        {
            if (_interactionFactory != null)
                _interactionFactory = null;
            if (_objectFactory != null)
                _objectFactory = null;
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
            throw new System.NotImplementedException();
        }

        public DockContent CreateUserFormFromObject(IUser pInstance)
        {
            throw new System.NotImplementedException();
        }

        public DockContent CreateFormFromObject(IInteraction pObject, DockContent pInstance)
        {
            throw new System.NotImplementedException();
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
                // Factory misses method to create expenses... 
                IExpense obj = new Expense("", "", new User(), new Task("", "", new User()));
                return (T)obj;
            }
            else if (pInstance.GetType() == typeof(uc_Timeslice))
            {
                // Factory misses method to create timeslice ITimeslice obj = _interactionFactory.Create("", "", new User());
                ITimeslice obj = new Timeslice("", new User(), 0, new Task("", "", new User()));
                return (T)obj;
            }
            else { throw new InvalidCastException($"The type {pInstance.GetType().ToString()} is not a valid interaction type!"); }
        }

        public IUser CreateUserObjectFromFForm(DockContent pInstance)
        {
            throw new System.NotImplementedException();
        }
    }
}
