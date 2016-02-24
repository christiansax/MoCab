﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IInteractionFactory 
{
	IInteraction CreateTask(string pId, string pText, IUser pCreator);

	IInteraction CreateTask(string pId, string pText, IUser pCreator, DateTime pStartDT, DateTime pEndDT, DateTime pDueDT);

	IInteraction CreateTask(string pId, string pText, IUser pCreator, DateTime pStartDT, DateTime pEndDT, DateTime pDueDT, decimal pBudget, int pDuration, int pPriority, InteractionState pState, decimal pBudgetUsed, int pTimeUsed, List<ITask> pSubTask, int pProgress = 0);

	IInteraction CreateSurvey(string pId, string pText, List<ISurveyOption> pOptions, IUser pCreator);

	IInteraction CreateSurvey(string pId, string pText, List<string> pOptions, IUser pCreator);

	IInteraction CreateAccount(string pId, object pCreator, object IUser);

	IInteraction CreateProject(string pId, string pText, bool pEnableBalance, bool pEnableSurvey, IUser pCreator);

	IInteraction CreateProject(string pId, string pText, IUser pCreatur, IUser pOwner, List<string> MemberList, List<string> InvitationList, bool pEnableBalance, bool pEnableSurvey, List<ITask> TaskList, List<ISurvey> SurveyList);

	IInteraction CreateChat(string pTextTitle, IUser pCreator, List<IUser> pUsers);

	IInteraction CreateChat(string pTextTitle, IUser pCreator, List<IUser> pUsers, DateTime pStartDateTime, DateTime pEndDateTime, bool pAllowSelfdestructing);

}

