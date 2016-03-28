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
        public virtual ITask CreateTask(string pId, string pText, IUser pCreator)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return new Task(pId, pText, pCreator);
        }

        public virtual ITask CreateTask(string pId,
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

        public ITask CreateTask(string pId,
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
                "",
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

        public ITask CreateTask(string pId,
            string pText,
            string pTitle,
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
                pTitle,
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

        public virtual ISurvey CreateSurvey(string pId, string pText, List<ISurveyOption> pOptions,
            IUser pCreator,
            DateTime pStartDT,
            DateTime pEndDT,
            DateTime pDueDT,
            int pVotesPerUser,
            string pTitle,
            InteractionState pState,
            List<IVote> pVotes)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            Survey survey = new Survey(pId, pText, pOptions, pCreator);
            survey.StartDateTime = pStartDT;
            survey.EndDateTime = pEndDT;
            survey.DueDateTime = pDueDT;
            survey.MaxVotesPerUser = pVotesPerUser;
            survey.Title = pTitle;
            survey.VoteList = pVotes;
            return (new Survey(pId, pText, pOptions, pCreator));
        }

        public virtual ISurvey CreateSurvey(string pId, string pText, List<string> pOptions, IUser pCreator)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Survey(pId, pText, pOptions, pCreator));
        }

        public virtual IAccount CreateAccount(string pId, string pText, IUser pCreator)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Account(pId, pText, pCreator));
        }

        public virtual IAccount CreateAccount(string pId,
            string pText,
            List<IExpense> pExpenseList,
            List<ITimeslice> pTimesliceList,
            IUser pCreator)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Account(pId, pText, pExpenseList, pTimesliceList, pCreator));
        }

        public virtual ITimeslice CreateTimeslice(string pId, IUser pUser, DateTime pStartDT, DateTime pEndDT, IInteraction pTarget)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Timeslice(pId, pUser, pStartDT, pEndDT, pTarget));
        }

        public virtual ITimeslice CreateTimeslice(string pId, IUser pUser, int pDuration, IInteraction pTarget)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Timeslice(pId, pUser, pDuration, pTarget));
        }

        public virtual IExpense CreateExpense(string pId, string pText, System.Drawing.Image pReceipt, decimal pValue, IUser pUser, IInteraction pTarget)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Expense(pId, pText, pReceipt, pValue, pUser, pTarget));
        }

        public virtual IExpense CreateExpense(string pId, string pText, IUser pUser, IInteraction pTarget)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Expense(pId, pText, pUser, pTarget));
        }

        public virtual IProject CreateProject(string pId, string pText, bool pEnableBalance, bool pEnableSurvey, DateTime pStartDT, DateTime pEndDT, IUser pCreator)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Project(pId, pText, pEnableBalance, pEnableSurvey, pStartDT, pEndDT, pCreator));
        }

        public virtual IProject CreateProject(string pId, string pText, bool pEnableBalance, bool pEnableSurvey, DateTime pStartDT, DateTime pEndDT, IUser pCreator, IUser pOwner, List<IUser> pMemberList, List<IUser> pInvitationList, List<ITask> pTaskList, List<ISurvey> pSurveyList, string pName)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Project(pId, pName, pText, pEnableBalance, pEnableSurvey, pStartDT, pEndDT, pCreator, pOwner, pMemberList, pInvitationList, pTaskList, pSurveyList));
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

        public virtual IInteraction CreateInteraction(string pId,
            DateTime pStartDateTime,
            DateTime pEndDateTime,
            bool pIsActive,
            string pText,
            InteractionType pType,
            InteractionState pState,
            IUser pOwner,
            IUser pCreator,
            DateTime pCreated,
            DateTime pModified)
        {
            if (string.IsNullOrEmpty(pId))
                pId = GenericHelper.GenerateId();
            return (new Interaction(pId,
                pStartDateTime,
                pEndDateTime,
                pCreated,
                pModified,
                pIsActive,
                pText,
                pType,
                pCreator,
                pOwner,
                pState));
        }

    }
}