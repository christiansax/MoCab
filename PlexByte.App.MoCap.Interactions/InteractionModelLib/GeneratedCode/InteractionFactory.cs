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

public class InteractionFactory : IInteractionFactory
{
	public virtual IInteraction CreateTask(string pId, string pText, IUser pCreator)
	{
		throw new System.NotImplementedException();
	}

	public virtual IInteraction CreateTask(string pId, string pText, IUser pCreator, DateTime pStartDT, DateTime pEndDT, DateTime pDueDT)
	{
		throw new System.NotImplementedException();
	}

	public virtual ITask CreateTask(string pId, string pText, IUser pCreator, DateTime pStartDT, DateTime pEndDT, DateTime pDueDT, decimal pBudget, int pDuration, int pPriority, InteractionState pState, List<IExpense> pExpenses, List<ITimeslice> pTime, List<ITask> pSubTask, int pProgress = 0)
	{
		throw new System.NotImplementedException();
	}

	public virtual IInteraction CreateSurvey(string pId, string pText, List<ISurveyOption> pOptions, IUser pCreator)
	{
		throw new System.NotImplementedException();
	}

	public virtual IInteraction CreateSurvey(string pId, string pText, List<string> pOptions, IUser pCreator)
	{
		throw new System.NotImplementedException();
	}

	public virtual IInteraction CreateAccount(string pId, object pCreator, object IUser)
	{
		throw new System.NotImplementedException();
	}

	public virtual IInteraction CreateProject(string pId, string pText, bool pEnableBalance, bool pEnableSurvey, IUser pCreator)
	{
		throw new System.NotImplementedException();
	}

	public virtual IInteraction CreateProject(string pId, string pText, IUser pCreatur, List<string> MemberList, List<string> InvitationList, bool pEnableBalance, bool pEnableSurvey, List<ITask> TaskList, List<ISurvey> SurveyList)
	{
		throw new System.NotImplementedException();
	}

	public virtual IInteraction CreateChat(string pTextTitle, IUser pCreator, List<IUser> pUsers)
	{
		throw new System.NotImplementedException();
	}

	public virtual IInteraction CreateChat(string pTextTitle, IUser pCreator, List<IUser> pUsers, DateTime pStartDateTime, DateTime pEndDateTime, bool pAllowSelfdestructing)
	{
		throw new System.NotImplementedException();
	}

}

