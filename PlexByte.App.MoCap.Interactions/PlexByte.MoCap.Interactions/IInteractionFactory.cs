//////////////////////////////////////////////////////////////
//                      Interface IInteractionFactory                              
//      Author: Christian B. Sax            Date:   2016/02/23
//      Defined the interface to create any object inheriting from IInteraction
using System;
using System.Collections.Generic;

public interface IInteractionFactory 
{
	IInteraction CreateTask(string pId, string pText, IUser pCreator);

	IInteraction CreateTask(string pId, string pText, IUser pCreator, DateTime pStartDT, DateTime pEndDT, DateTime pDueDT);

    IInteraction CreateTask(string pId,
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
        int pProgress);


    IInteraction CreateSurvey(string pId, string pText, List<ISurveyOption> pOptions, IUser pCreator);

	IInteraction CreateSurvey(string pId, string pText, List<string> pOptions, IUser pCreator);

    IInteraction CreateAccount(string pId, string pText, IUser pCreator);

    IInteraction CreateAccount(string pId, string pText, List<IExpense> pExpenseList, List<ITimeslice> pTimesliceList, IUser pCreator);

    IInteraction CreateProject(string pId, string pText, bool pEnableBalance, bool pEnableSurvey, IUser pCreator);

	IInteraction CreateProject(string pId, string pText, IUser pCreatur, IUser pOwner, List<IUser> MemberList, List<IUser> InvitationList, bool pEnableBalance, bool pEnableSurvey, List<ITask> TaskList, List<ISurvey> SurveyList);

	IInteraction CreateChat(string pTextTitle, IUser pCreator, List<IUser> pUsers);

	IInteraction CreateChat(string pTextTitle, IUser pCreator, List<IUser> pUsers, DateTime pStartDateTime, DateTime pEndDateTime, bool pAllowSelfdestructing);

}

