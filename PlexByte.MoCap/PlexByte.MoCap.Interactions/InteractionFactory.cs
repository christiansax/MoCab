//////////////////////////////////////////////////////////////
//                      Class Interaction Factory                              
//      Author: Christian B. Sax            Date:   2016/02/24
//              Fabian Ochsner              Date:   2016/02/27
//      Implementation of IInteractionFactory creating any object 
//      that inherits IInteraction
using System;
using System.Collections.Generic;
using PlexByte.MoCap.Security;
using PlexByte.MoCap.Helpers;

namespace PlexByte.MoCap.Interactions
{
    public class InteractionFactory : IInteractionFactory
    {
        public virtual IInteraction CreateTask(string pId, string pText, IUser pCreator)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return new Task(pId, pText, pCreator);
        }

        public virtual IInteraction CreateTask(string pId,
            string pText,
            IUser pCreator,
            DateTime pStartDT,
            DateTime pEndDT,
            DateTime pDueDT)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Task(pId, pText, pCreator, pStartDT, pEndDT, pDueDT));
        }

        public IInteraction CreateTask(string pId,
            string pText,
            IUser pCreator,
            DateTime pStartDT,
            DateTime pEndDT,
            DateTime pDueDT,
            decimal pBudget,
            int pDuration,
            int pPriority,
            InteractionState pState,
            decimal pBudgetUsed,
            int pTimeUsed,
            List<ITask> pSubTask,
            int pProgress)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Task(pId,
                pText,
                pCreator,
                pStartDT,
                pEndDT,
                pDueDT,
                pBudget,
                pDuration,
                pPriority,
                pState,
                pBudgetUsed,
                pTimeUsed,
                pSubTask,
                pProgress));
        }

        public virtual IInteraction CreateSurvey(string pId, string pText, List<ISurveyOption> pOptions, IUser pCreator)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Survey(pId, pText, pOptions, pCreator));
        }

        public virtual IInteraction CreateSurvey(string pId, string pText, List<string> pOptions, IUser pCreator)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Survey(pId, pText, pOptions, pCreator));
        }

        public virtual IInteraction CreateAccount(string pId, string pText, IUser pCreator)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Account(pId, pText, pCreator));
        }

        public virtual IInteraction CreateAccount(string pId,
            string pText,
            List<IExpense> pExpenseList,
            List<ITimeslice> pTimesliceList,
            IUser pCreator)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Account(pId, pText, pExpenseList, pTimesliceList, pCreator));
        }

        public virtual IInteraction CreateProject(string pId, string pText, bool pEnableBalance, bool pEnableSurvey, DateTime pStartDT, DateTime pEndDT, IUser pCreator)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Project(pId, pText, pEnableBalance, pEnableSurvey, pStartDT, pEndDT, pCreator));
        }

        public virtual IInteraction CreateProject(string pId,
            string pText,
            bool pEnableBalance,
            bool pEnableSurvey,
            DateTime pStartDT,
            DateTime pEndDT,
            IUser pCreator,
            IUser pOwner,
            List<IUser> pMemberList,
            List<IUser> pInvitationList,
            List<ITask> pTaskList,
            List<ISurvey> pSurveyList)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Project(pId, pText, pEnableBalance, pEnableSurvey, pStartDT, pEndDT, pCreator, pOwner, pMemberList, pInvitationList, pTaskList, pSurveyList));
        }

        public virtual IInteraction CreateChat(string pTextTitle, IUser pCreator, List<IUser> pUsers) { throw new System.NotImplementedException(); }

        public virtual IInteraction CreateChat(string pTextTitle,
            IUser pCreator,
            List<IUser> pUsers,
            DateTime pStartDateTime,
            DateTime pEndDateTime,
            bool pAllowSelfdestructing)
        {
            throw new System.NotImplementedException();
        }

    }
}