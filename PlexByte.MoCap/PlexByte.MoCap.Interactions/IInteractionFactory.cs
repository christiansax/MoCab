//////////////////////////////////////////////////////////////
//                      Interface IInteractionFactory                              
//      Author: Christian B. Sax            Date:   2016/02/23
//      Defined the interface to create any object inheriting from IInteraction
using System;
using System.Collections.Generic;
using PlexByte.MoCap.Security;

namespace PlexByte.MoCap.Interactions
{
    public interface IInteractionFactory
    {
        ITask CreateTask(string pId, string pText, IUser pCreator);

        ITask CreateTask(string pId, string pText, IUser pCreator, DateTime pStartDT, DateTime pEndDT, DateTime pDueDT);

        ITask CreateTask(string pId,
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
            int pProgress);


        ISurvey CreateSurvey(string pId, string pText, List<ISurveyOption> pOptions, IUser pCreator);

        ISurvey CreateSurvey(string pId, string pText, List<string> pOptions, IUser pCreator);

        IAccount CreateAccount(string pId, string pText, IUser pCreator);

        IAccount CreateAccount(string pId, string pText, List<IExpense> pExpenseList, List<ITimeslice> pTimesliceList, IUser pCreator);

        ITimeslice CreateTimeslice(string pId, IUser pUser, DateTime pStartDT, DateTime pEndDT, IInteraction pTarget);

        ITimeslice CreateTimeslice(string pId, IUser pUser, int pDuration, IInteraction pTarget);

        IExpense CreateExpense(string pId, string pText, System.Drawing.Image pReceipt, decimal pValue, IUser pUser, IInteraction pTarget);

        IExpense CreateExpense(string pId, string pText, IUser pUser, IInteraction pTarget);

        IProject CreateProject(string pId, string pText, bool pEnableBalance, bool pEnableSurvey, DateTime pStartDT, DateTime pEndDT, IUser pCreator);

        IProject CreateProject(string pId, string pText, bool pEnableBalance, bool pEnableSurvey, DateTime pStartDT, DateTime pEndDT, IUser pCreator, IUser pOwner, List<IUser> MemberList, List<IUser> InvitationList, List<ITask> TaskList, List<ISurvey> SurveyList, string pName);

        IInteraction CreateChat(string pTextTitle, IUser pCreator, List<IUser> pUsers);

        IInteraction CreateChat(string pTextTitle, IUser pCreator, List<IUser> pUsers, DateTime pStartDateTime, DateTime pEndDateTime, bool pAllowSelfdestructing);

        IInteraction CreateInteraction(string pId,
            DateTime pStartDateTime,
            DateTime pEndDateTime,
            bool pIsActive,
            string pText,
            InteractionType pType,
            InteractionState pState,
            IUser pOwner,
            IUser pCreator,
            DateTime pCreated,
            DateTime pModified);
    }
}